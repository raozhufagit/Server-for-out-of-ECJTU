
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

public partial class ChuFangFuWu_ChuFang: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataBindToGridview("");
                //设定按钮权限            
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|048A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|048M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|048D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|048E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            int count = GVData.Rows.Count;
            if (Request.QueryString["TypeStr"].ToString().Trim() == "全部出访")
            {
                this.Total.Text = "目前全校已登记出访共有"+count+"次";
            }
            else
                this.Total.Text = "目前您已登记出访共有" + count+ "次";

        }
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

            DataBindToGridview("");
        }
        catch
        {
            DataBindToGridview("");
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
        DataBindToGridview("");
    }
    #endregion
    protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LCX.Common.PublicMethod.GridViewRowDataBound(e);
        string name = LCX.Common.PublicMethod.GetSessionValue("UserName");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string Lead= e.Row.Cells[2].Text.ToString();
            string Number = e.Row.Cells[10].Text.ToString();//这里我是第6列的，你根据需要改
            if (Number == "0")
            {
                LCX.BLL.OutVisit check_state = new LCX.BLL.OutVisit();
                if (name == "admin")
                {

                    e.Row.Cells[10].Text = "<a class=\"bbk button small-long-btn\" href=\"OutVisitCheck.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">立即审核</a>";
                }
                else
                {
                    e.Row.Cells[10].Text = "等待审核";
                }
            }
            else if (Number == "2" && name == Lead)
            {
                e.Row.Cells[10].Text = "<a class=\"bbk button small-long-btn\" href=\"ChuFangModify.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">已被驳回</a>";
            }
            else if (Number == "2")
            {
                e.Row.Cells[10].Text = "已被驳回";
            }
            else if (Number == "1" && name == Lead)
            {
                e.Row.Cells[10].Text = "<a class=\"bbk button small-long-btn\" href=\"VisitReport.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">填写报告</a>";
            }
            else if (Number == "1")
            {
                e.Row.Cells[10].Text = "待填报告";
            }
            else if (Number == "3" && name == Lead)
            {
                e.Row.Cells[10].Text = "<a class=\"bbk button small-long-btn\" href=\"VisitReport.aspx?ID=" + DataBinder.Eval(e.Row.DataItem, "ID").ToString() + "\">已填报告</a>";
            }
            else
            {
                e.Row.Cells[10].Text = "已填报告";
            }
        }
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        //保存上一次查询结果
        string JJ = "0";
        for (int i = 0; i < this.GVData.Rows.Count; i++)
        {
            Label LabV = (Label)GVData.Rows[i].FindControl("LabVisible");
            JJ = JJ + "," + LabV.Text.Trim();
        }
        DataBindToGridview(JJ);
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview("");
    }
    public void DataBindToGridview(string IDList)
    {
        LCX.BLL.OutVisit MyModel = new LCX.BLL.OutVisit();
        string role = LCX.Common.PublicMethod.GetSessionValue("JiaoSe");
        if (Request.QueryString["TypeStr"].ToString().Trim() == "全部出访")
        {
            if (IDList.Trim().Length > 0)
            {
                GVData.DataSource = MyModel.GetList(" " + DropDownList2.SelectedItem.Value.ToString() + " like '%" + this.TextBox3.Text.Trim() + "%' and ID in(" + IDList + ") order by ID desc");
            }
            else
            {
                GVData.DataSource = MyModel.GetList(" " + DropDownList2.SelectedItem.Value.ToString() + " like '%" + this.TextBox3.Text.Trim() + "%' order by ID desc");
            }
        }
        else
        {
            if (IDList.Trim().Length > 0)
            {
                GVData.DataSource = MyModel.GetList(" " + DropDownList2.SelectedItem.Value.ToString() + " like '%" + this.TextBox3.Text.Trim() + "%' and LeadPerson='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' and ID in(" + IDList + ") order by ID desc");
            }
            else
            {
                GVData.DataSource = MyModel.GetList(" " + DropDownList2.SelectedItem.Value.ToString() + " like '%" + this.TextBox3.Text.Trim() + "%' and LeadPerson='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' order by ID desc");
            }

        }
        GVData.DataBind();
        LabPageSum.Text = Convert.ToString(GVData.PageCount);
        LabCurrentPage.Text = Convert.ToString(((int)GVData.PageIndex + 1));
        this.GoPage.Text = LabCurrentPage.Text.ToString();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ChuFangAdd.aspx");
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string IDlist = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        if (LCX.DBUtility.DbHelperSQL.ExecuteSQL("delete from OutVisit where ID in (" + IDlist + ")") == -1)
        {
            Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
        }
        else
        {
            DataBindToGridview("");
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户删除出访信息";
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
        MyTable.Add("VisitDate", "出访时间");
        MyTable.Add("VisitLenth", "出访时长");
        MyTable.Add("LeadPerson", "领队");
        MyTable.Add("FlowPerson", "随行人员");
        MyTable.Add("VisitDepartment", "出访去向");
        MyTable.Add("VisitGoal", "出访意义");
        MyTable.Add("VisitCost", "经费");
        MyTable.Add("EnteringPerson", "录入人员");
        MyTable.Add("ApproalPerson", "审批人员");
        MyTable.Add("ApproalOpinion", "审批意见");
        LCX.Common.DataToExcel.GridViewToExcel(LCX.DBUtility.DbHelperSQL.GetDataSet("select VisitDate,VisitLenth,FlowPerson,VisitDepartment,VisitGoal,VisitCost,EnteringPerson,ApprovalPerson,ApprovalOpinion from Outvisit where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel报表");
        //,RelationCOA,RelationCoPro,Otherexplain,   ApprovalDate,,VisitReportDate,VisitResultCOA,VisitResultCopro,VisultOtherRusult,VisitResultAttachmentn
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
       string  UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        string CheckStr = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        string[] CheckStrArray = CheckStr.Split(',');
        ID = CheckStrArray[0].ToString();
        LCX.BLL.OutVisit IFApproal= new LCX.BLL.OutVisit(int.Parse(ID));
        
    if (IFApproal.Visitstat != 0 && IFApproal.LeadPerson != UserName || IFApproal.EnteringPerson != UserName)
        { Response.Write("<script>alert('只有领队本人或者录入人员可以在出访被审核之前修改出访信息！');</script>"); }
        else
        { Response.Redirect("ChuFangModify.aspx?ID=" + CheckStrArray[0].ToString()); }
    }


    protected void GoPage_TextChanged(object sender, EventArgs e)
    {

    }
}
