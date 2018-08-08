using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Project_PingShen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession(); 
            this.TextBox1.Text = Request.QueryString["ProjectName"].ToString();
            DataBindToGridview();

            //设定按钮权限            
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|X002A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|X002M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|X002D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|X002E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }
    public void DataBindToGridview()
    {
        LCX.BLL.LCXPinShen MyModel = new LCX.BLL.LCXPinShen();
        GVData.DataSource = MyModel.GetList("ProjectName Like '%" + this.TextBox1.Text + "%' order by ID desc");
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
        string name = LCX.Common.PublicMethod.GetSessionValue("UserName");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string ProjectName = e.Row.Cells[1].Text.ToString();
            string Lead = "admin";
            string Number = e.Row.Cells[2].Text.ToString();//这里我是第6列的，你根据需要改
            if (Number == "0")
            {
                LCX.BLL.OutVisit check_state = new LCX.BLL.OutVisit();
                if (name == "admin")
                {

                    e.Row.Cells[2].Text = "<a class=\"bbk button small-long-btn\" href=\"PinShenModify.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">立即审核</a>";
                }
                else
                {
                    e.Row.Cells[2].Text = "等待审核";
                }
            }
            else if (Number == "2" && name == Lead)
            {
                e.Row.Cells[2].Text = "<a class=\"bbk button small-long-btn\" href=\"PinShenModify.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">已被驳回</a>";
            }
            else if (Number == "2")
            {
                e.Row.Cells[2].Text = "已被驳回";
            }
            else if (Number == "1" && name == Lead)
            {
                e.Row.Cells[2].Text = "<a class=\"bbk button small-long-btn\" href=\"PinShenModify.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">填写报告</a>";
            }
            else if (Number == "1")
            {
                e.Row.Cells[2].Text = "待填报告";
            }
            else if (Number == "3" && name == Lead)
            {
                e.Row.Cells[2].Text = "<a class=\"bbk button small-long-btn\" href=\"PinShenModify.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">已填报告</a>";
            }
            else
            {
                e.Row.Cells[2].Text = "已填报告";
            }
        }
    }
   
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PinShenAdd.aspx?ProjectName=" + Request.QueryString["ProjectName"].ToString());
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string IDlist = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        if (LCX.DBUtility.DbHelperSQL.ExecuteSQL("delete from LCXPinShen where ID in (" + IDlist + ")") == -1)
        {
            Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
        }
        else
        {
            DataBindToGridview();
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户删除评审信息";
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
        MyTable.Add("PingShenTime", "评审时间");
        MyTable.Add("PingShenJieGuo", "评审结果");
        LCX.Common.DataToExcel.GridViewToExcel(LCX.DBUtility.DbHelperSQL.GetDataSet("select ProjectName,ProjectSerils,PingShenTime,PingShenJieGuo from LCXPinShen where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel报表");
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string CheckStr = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        string[] CheckStrArray = CheckStr.Split(',');
        Response.Redirect("PinShenModify.aspx?ProjectName=" + Request.QueryString["ProjectName"].ToString()+"&ID=" + CheckStrArray[0].ToString());
    }
}