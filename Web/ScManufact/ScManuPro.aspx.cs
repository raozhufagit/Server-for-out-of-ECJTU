using System;
using System.Collections.Generic;
using System.Collections;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScManuPro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();

            if (Request.UrlReferrer != null)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            }  

            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect(ViewState["UrlReferrer"].ToString());  //返回上级菜单修改完成后
                //LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！", "ScPlan.aspx");
                return;
            }
            try
            {
                int id = Int32.Parse(Request.QueryString["ID"].ToString());
                DataBindToGridview(id);
            }
            catch (Exception ex)
            {
                Response.Redirect(ViewState["UrlReferrer"].ToString());  //返回上级菜单修改完成后
                //LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！", "ScManuPro.aspx");
                return;
            }

            LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
            string userName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            if (!LCX.Common.PublicMethod.StrIFIn("," + userName + ",", "," + scSet.jd_User + ","))
            {
                ImageButton1.Visible = false;
                ImageButton5.Visible = false;
                ImageButton3.Visible = false;
            }
            //设定按钮权限   
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|S001E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }
    public void DataBindToGridview(int idstr)
    {
        LCX.BLL.LCXManuPro MyModel = new LCX.BLL.LCXManuPro();

        LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
        string userName = LCX.Common.PublicMethod.GetSessionValue("UserName");


        if (LCX.Common.PublicMethod.StrIFIn("," + userName + ",", "," + scSet.jd_User + ",") || LCX.Common.PublicMethod.StrIFIn("," + userName + ",", "," + scSet.jd_SUser + ","))
        {
            //订单审核权利的可以查看所有
            GVData.DataSource = MyModel.GetList("Jd_Dd=" + idstr + " and Jd_Name Like '%" + this.TextBox1.Text + "%' order by ID desc");
        }else{
            GVData.DataSource = MyModel.GetList("Jd_State>2 and Jd_Dd=" + idstr + " and Jd_Name Like '%" + this.TextBox1.Text + "%' order by ID desc");
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
            DataBindToGridview(id);
        }
        catch
        {
            int id = Int32.Parse(Request.QueryString["ID"].ToString());
            DataBindToGridview(id);
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
        DataBindToGridview(id);
    }
    #endregion
    protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LCX.Common.PublicMethod.GridViewRowDataBound(e);
       
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            int Number = 9;
            try
            {
                Number = Int32.Parse(e.Row.Cells[6].Text.ToString());//这里我是第6列的，你根据需要改   
            }
            catch (Exception ex)
            {

            }
            switch (Number)
            {
                case 0: { e.Row.Cells[6].Text = "等待审核"; break; }
                case 1: { e.Row.Cells[6].Text = "审核拒绝"; break; }
                case 2: { e.Row.Cells[6].Text = "禁用"; break; }
                case 3: { e.Row.Cells[6].Text = "审核通过"; break; }
                case 4: { e.Row.Cells[6].Text = "等待更新"; break; }
                default: { e.Row.Cells[6].Text = "状态未知"; break; }
            }
            LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
            string userName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            //审核人点击审核
            if (LCX.Common.PublicMethod.StrIFIn("," + userName + ",", "," + scSet.jd_SUser + ","))
            {
                if (Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jd_State")) == 0 || Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "Jd_State")) == 4)
                {
                    e.Row.Cells[6].Text = "<a class=\"bbk button small-long-btn\" href=\"ScManuCheck.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">审核进度</a>";
                } 
            } 
            
            //作为提交人进行修改进度
            if (LCX.Common.PublicMethod.StrIFIn("," + userName + ",", "," + scSet.jd_User + ","))
            {
                e.Row.Cells[7].Text = "<a class=\"bbk button small-gary-btn\" href=\"ScManuPic2.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">修改</a>";
            }
            else
            {
                GVData.Columns[7].Visible = false;
            }
            
            //当确定进度版本为空时不进行显示
            if (DataBinder.Eval(e.Row.DataItem, "Jd_Pic").ToString() != "")
            {
                e.Row.Cells[1].Text = "<a title='点击查看当前生产进度实时详情' href=\"ScManuPic.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\"><img src=\"../anywhere/images/form/progressbar.gif\"</a>";
            }
            else
            {
                e.Row.Cells[1].Text = "";
            }
                 
        }


    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        int id = Int32.Parse(Request.QueryString["ID"].ToString());
        DataBindToGridview(id);
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ScManuProAdd.aspx?ID=" + Request.QueryString["ID"]);
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
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
        string userName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        if (!LCX.Common.PublicMethod.StrIFIn("," + userName + ",", "," + scSet.sc_User + ","))
        {
            Response.Write("<script>alert('您当前没有权限删除此明细单！');</script>");
            return;
        }

        string IDlist = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        int tdelete = LCX.DBUtility.DbHelperSQL.ExecuteSQL("delete from LCXManuPro where [Jd_User]='" + userName + "' and  ID in (" + IDlist + ")");
        if (tdelete == -1)
        {
            Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
        }
        else if (tdelete == 0)
        {
            Response.Write("<script>alert('删除记录失败！请检查您是否有权限删除记录！');</script>");
        }
        else
        {
            int id = Int32.Parse(Request.QueryString["ID"].ToString());
            DataBindToGridview(id);
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户删除项目信息";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string CheckStr = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        string[] CheckStrArray = CheckStr.Split(',');
        Response.Redirect("ScMpModify.aspx?ID=" + CheckStrArray[0].ToString());
    }
}