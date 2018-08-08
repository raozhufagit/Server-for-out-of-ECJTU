using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScManage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataBindToGridview();

            //设定按钮权限            
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|S001A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|S001M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|S001D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|S001E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }
    public void DataBindToGridview()
    {
        LCX.BLL.LCXManuFact MyModel = new LCX.BLL.LCXManuFact();
        
        LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
        if (LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", "," + scSet.dd_User + ","))
        {
            //订单审核权利的可以查看所有
            GVData.DataSource = MyModel.GetList("Sc_Name Like '%" + this.TextBox1.Text + "%' order by ID desc");
        }
        else
        {
            //提交人只能查看自己的
            GVData.DataSource = MyModel.GetList("Sc_Tjr = '" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' and Sc_Name Like '%" + this.TextBox1.Text + "%' order by ID desc");
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

            DataBindToGridview();
        }
        catch
        {
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
        DataBindToGridview();
    }
    #endregion
    protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LCX.Common.PublicMethod.GridViewRowDataBound(e);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Number = e.Row.Cells[5].Text.ToString();//这里我是第6列的，你根据需要改
            if (Number == "0")
            { 
                LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
                if (LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", "," + scSet.dd_User + ","))
                {

                    e.Row.Cells[5].Text = "<a class=\"bbk button small-long-btn\" href=\"Sc_check.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">立即审核</a>";
                }
                else
                {
                    e.Row.Cells[5].Text = "等待审核";
                } 
            }  
            else if (Number == "1")
            {
                e.Row.Cells[5].Text = "<img src=../anywhere/images/ext_org/sync_error.png></img>";
            }
            else if (Number == "2")
            {
                e.Row.Cells[5].Text = "<img src=../anywhere/images/ext_org/sync_ok.png></img>";
            }
            else
            {
                e.Row.Cells[5].Text = "订单取消";
            } 
        }
       // GVData.Columns[6].Visible = false;//
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ScManuAdd.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string IDlist = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        string UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        int tdelete=LCX.DBUtility.DbHelperSQL.ExecuteSQL("delete from LCXManuFact where [Sc_State] <> 2 and [Sc_Tjr]='" + UserName + "' and  ID in (" + IDlist + ")");
        if ( tdelete== -1)
        {
            Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
        }
        else if (tdelete == 0)
        {
            Response.Write("<script>alert('删除记录失败！审核过后的订单记录不能删除！');</script>");
        }else
        {
            DataBindToGridview();
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户删除项目信息";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
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
        Response.Redirect("ScModify.aspx?ID=" + CheckStrArray[0].ToString());
    }
}