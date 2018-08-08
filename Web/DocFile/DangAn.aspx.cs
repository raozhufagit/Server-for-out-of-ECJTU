
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

public partial class DocFile_DangAn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataBindToGridview();           

            //设定按钮权限            
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|123A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|123M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|123D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|123E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
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
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview();
    }

    public string GetDicNameCondition()
    {
        string ReturnStr = " 0=0 ";
        try
        {
            this.Label1.Text = Request.QueryString["JuanKuName"].ToString();
            if (Request.QueryString["JuanKuName"].ToString().Trim().Length > 0)
            {
                ReturnStr = " JuanKuName='" + Request.QueryString["JuanKuName"].ToString() + "' ";
            }
            else
            {
                ReturnStr = " 0=0 ";
            }
        }
        catch
        { }
        return ReturnStr;
    }

	public void DataBindToGridview()
	{
		LCX.BLL.LCXDangAn MyModel = new LCX.BLL.LCXDangAn();
        GVData.DataSource = MyModel.GetList(" IFDel='否' and  FileName Like '%" + this.TextBox1.Text + "%'  and " + GetDicNameCondition() + " order by ID desc");
		GVData.DataBind();
		LabPageSum.Text = Convert.ToString(GVData.PageCount);
		LabCurrentPage.Text = Convert.ToString(((int)GVData.PageIndex + 1));
		this.GoPage.Text = LabCurrentPage.Text.ToString();
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
        Response.Redirect("DangAnAdd.aspx?JuanKuName=" + Request.QueryString["JuanKuName"].ToString());
	}
	protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
	{
		string IDlist = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
		if (LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXDangAn set IFDel='是' where ID in (" + IDlist + ")") == -1)
		{
			Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
		}
		else
		{
			DataBindToGridview();
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户删除档案信息";
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
		MyTable.Add("FileName", "文件名称");
		MyTable.Add("JuanKuName", "所属卷库");
		MyTable.Add("FileSerils", "文件编号");
		MyTable.Add("FileTitle", "文件主题");
		MyTable.Add("FaWenDanWei", "发文单位");
		MyTable.Add("FaWenDate", "发文日期");
		MyTable.Add("MiJi", "密级");
		MyTable.Add("JingJi", "紧急");
		MyTable.Add("TypeStr", "文件分类");
		MyTable.Add("GongWenType", "公文类别");
		MyTable.Add("FilePage", "文件页数");
		MyTable.Add("FuJianList", "附件文件");
		MyTable.Add("UserName", "录入人");
		MyTable.Add("TimeStr", "录入时间");
		LCX.Common.DataToExcel.GridViewToExcel(LCX.DBUtility.DbHelperSQL.GetDataSet("select  FileName,JuanKuName,FileSerils,FileTitle,FaWenDanWei,FaWenDate,MiJi,JingJi,TypeStr,GongWenType,FilePage,FuJianList,UserName,TimeStr  from LCXDangAn where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel报表");
	}
	protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
	{
		string CheckStr = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
		string[] CheckStrArray = CheckStr.Split(',');
        Response.Redirect("DangAnModify.aspx?ID=" + CheckStrArray[0].ToString() + "&JuanKuName=" + Request.QueryString["JuanKuName"].ToString());
	}
}
