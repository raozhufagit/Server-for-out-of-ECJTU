
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

public partial class DocFile_TiKuKaoShi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataBindToGridview("");

            //设定按钮权限            
            //ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|047A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            //ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|047M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|047D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|047E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
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

        //判定各项得分
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label LabID = (Label)e.Row.FindControl("LabVisible"); //考试ID

            Label Labz = (Label)e.Row.FindControl("Label1");//总分
            Label Labd = (Label)e.Row.FindControl("Label2");//电脑
            Label Labr = (Label)e.Row.FindControl("Label3");//人工

            Labz.Text = LCX.DBUtility.DbHelperSQL.GetSHSLInt("select sum(DeFen)  from LCXQuestionKSJG where DeFen is not null and KaoShiID=" + LabID.Text.ToString());
            Labd.Text = LCX.DBUtility.DbHelperSQL.GetSHSLInt("select sum(DeFen)  from LCXQuestionKSJG where TiMuID not in (select ID from LCXQuestion where FenLeiStr='简答题') and  DeFen is not null and KaoShiID=" + LabID.Text.ToString());
            Labr.Text = LCX.DBUtility.DbHelperSQL.GetSHSLInt("select sum(DeFen)  from LCXQuestionKSJG where TiMuID in (select ID from LCXQuestion where FenLeiStr='简答题') and  DeFen is not null and KaoShiID=" + LabID.Text.ToString());
        }

        //判定是否有权限
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink MyHyp = (HyperLink)e.Row.FindControl("HyperLink2");
            MyHyp.Visible = LCX.Common.PublicMethod.StrIFIn("|047N|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
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
		LCX.BLL.LCXQuestionKaoShi MyModel = new LCX.BLL.LCXQuestionKaoShi();
		if (IDList.Trim().Length > 0)
		{
		    GVData.DataSource = MyModel.GetList(" " + DropDownList2.SelectedItem.Value.ToString() + " like '%" + this.TextBox3.Text.Trim() + "%' and ID in(" + IDList + ") order by ID desc");
		}
		else
		{
		    GVData.DataSource = MyModel.GetList(" " + DropDownList2.SelectedItem.Value.ToString() + " like '%" + this.TextBox3.Text.Trim() + "%' order by ID desc");
		}
		GVData.DataBind();
		LabPageSum.Text = Convert.ToString(GVData.PageCount);
		LabCurrentPage.Text = Convert.ToString(((int)GVData.PageIndex + 1));
		this.GoPage.Text = LabCurrentPage.Text.ToString();
	}
	
	protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
	{
		string IDlist = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
		if (LCX.DBUtility.DbHelperSQL.ExecuteSQL("delete from LCXQuestionKaoShi where ID in (" + IDlist + ")") == -1)
		{
			Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
		}
		else
		{
			DataBindToGridview("");
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户删除在线考试信息";
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
		MyTable.Add("UserName", "用户名");
		MyTable.Add("TimeStr", "考试时间");
		MyTable.Add("ShiJuanName", "所用试卷");
		LCX.Common.DataToExcel.GridViewToExcel(LCX.DBUtility.DbHelperSQL.GetDataSet("select  UserName,TimeStr,ShiJuanName  from LCXQuestionKaoShi where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel报表");
	}
}
