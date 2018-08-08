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

public partial class Main_SelectTXL : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataBindToGridview();
        }
    }
    public void DataBindToGridview()
    {
        LCX.DBUtility.DbHelperSQL.BindGridView("select ShouJi as SelectContent,NameStr,TypeStr from LCXMail_List where ((TypeStr='个人通讯簿' and UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "') or TypeStr='公共通讯簿'  or IfShare='是') and NameStr like '%" + this.TextBox1.Text + "%' ", this.GridView1);
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        DataBindToGridview();
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview();
    }
}
