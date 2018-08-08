using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScDetail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.UrlReferrer != null)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            }  

            LCX.Common.PublicMethod.CheckSession();            

            LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
            string userName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            if (!LCX.Common.PublicMethod.StrIFIn("," + userName + ",", "," + scSet.sc_JUser + ","))
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "当前没有权限！", ViewState["UrlReferrer"].ToString());
                return; 
            }
            DataBindToGridview();
            //设定按钮权限   
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|S001E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }
    public void DataBindToGridview()
    {
        LCX.BLL.LCXManuPc MyModel = new LCX.BLL.LCXManuPc();

        LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
        string userName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        if (LCX.Common.PublicMethod.StrIFIn("," + userName + ",", "," + scSet.sc_JUser + ","))
        {
            //订单审核权利的可以查看所有
            GVData.DataSource = MyModel.GetList("Pc_State<5 and Pc_Name Like '%" + this.TextBox1.Text + "%' order by ID desc");
        }
        else
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "当前没有权限！", ViewState["UrlReferrer"].ToString());
            return;
        }
       

        
        GVData.DataBind();
        LabPageSum.Text = Convert.ToString(GVData.PageCount);
        LabCurrentPage.Text = Convert.ToString(((int)GVData.PageIndex + 1));
        this.GoPage.Text = LabCurrentPage.Text.ToString();
    }

    #region  分页方法
    protected void ButtonGo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (GoPage.Text.Trim().ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('页码不可以为空!');</script>");
            }
            else if (GoPage.Text.Trim().ToString() == "0" || Convert.ToInt32(GoPage.Text.Trim().ToString()) > GVData.PageCount)
            {
                Response.Write("<script language='javascript'>alert('页码不是一个有效值!');</script>");
            }
            else if (GoPage.Text.Trim() != "")
            {
                int PageI = Int32.Parse(GoPage.Text.Trim()) - 1;
                if (PageI >= 0 && PageI < (GVData.PageCount))
                {
                    GVData.PageIndex = PageI;
                }
            }

            if (TxtPageSize.Text.Trim().ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('每页显示行数不可以为空!');</script>");
            }
            else if (TxtPageSize.Text.Trim().ToString() == "0")
            {
                Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
            }
            else if (TxtPageSize.Text.Trim() != "")
            {
                try
                {
                    int MyPageSize = int.Parse(TxtPageSize.Text.ToString().Trim());
                    this.GVData.PageSize = MyPageSize;
                }
                catch
                {
                    Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
                }
            }

            int id = Int32.Parse(Request.QueryString["ID"].ToString());
            DataBindToGridview();
        }
        catch
        {
            int id = Int32.Parse(Request.QueryString["ID"].ToString());
            DataBindToGridview();
            Response.Write("<script language='javascript'>alert('请输入有效数字！');</script>");
        }
    }
    protected void PagerButtonClick(object sender, ImageClickEventArgs e)
    {
        //获得Button的参数值
        string arg = ((ImageButton)sender).CommandName.ToString();
        switch (arg)
        {
            case ("Next"):
                if (this.GVData.PageIndex < (GVData.PageCount - 1))
                    GVData.PageIndex++;
                break;
            case ("Pre"):
                if (GVData.PageIndex > 0)
                    GVData.PageIndex--;
                break;
            case ("Last"):
                try
                {
                    GVData.PageIndex = (GVData.PageCount - 1);
                }
                catch
                {
                    GVData.PageIndex = 0;
                }

                break;
            default:
                //本页值
                GVData.PageIndex = 0;
                break;
        }
        int id = Int32.Parse(Request.QueryString["ID"].ToString());
        DataBindToGridview();
    }
    #endregion
    protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LCX.Common.PublicMethod.GridViewRowDataBound(e);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int Number = 9;
            try{
                Number=Int32.Parse(e.Row.Cells[5].Text.ToString());//这里我是第6列的，你根据需要改  
            
            }catch(Exception ex){

            }
            switch (Number)
            {
                case 0: { e.Row.Cells[5].Text = "<a class=\"bbk button small-long-btn\" href=\"ScDetail11.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">审核进度</a>"; break; }
                case 1: { e.Row.Cells[5].Text = "技术审核拒绝"; break; }
                case 2: { e.Row.Cells[5].Text = "<img src=../anywhere/images/ext_org/sync_ok.png></img>"; break; } //技术审核通过
                case 3: { e.Row.Cells[5].Text = "明细终审拒绝"; break; }
                case 4: { e.Row.Cells[5].Text = "明细审核通过"; break; }
                case 5: { e.Row.Cells[5].Text = "版本禁用"; break; }
                default: { e.Row.Cells[5].Text = "状态未知"; break; }
            } 
        }

         
    }




    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
       
        DataBindToGridview();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ScDetailAdd.aspx?ID="+Request.QueryString["ID"]);
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string IDList = "0";
        for (int i = 0; i < GVData.Rows.Count; i++)
        {
            Label LabVis = (Label)GVData.Rows[i].FindControl("LabVisible");
            IDList = IDList + "," + LabVis.Text.ToString();
        }
        Hashtable MyTable = new Hashtable();
        MyTable.Add("ProjectName", "项目名称");
        MyTable.Add("ProjectSerils", "项目编号");
        MyTable.Add("SuoShuKeHu", "所属客户");
        MyTable.Add("YuJiChengJiaoRiQi", "预计成交日");
        MyTable.Add("FuZeRen", "负责人");
        MyTable.Add("XiangMuJinE", "项目金额");
        LCX.Common.DataToExcel.GridViewToExcel(LCX.DBUtility.DbHelperSQL.GetDataSet("select ProjectName,ProjectSerils,SuoShuKeHu,YuJiChengJiaoRiQi,FuZeRen,XiangMuJinE from LCXProject where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel报表");
    }
   
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string CheckStr = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        string[] CheckStrArray = CheckStr.Split(',');
        Response.Redirect("ScDetailModify.aspx?ID=" + CheckStrArray[0].ToString());
    }
}