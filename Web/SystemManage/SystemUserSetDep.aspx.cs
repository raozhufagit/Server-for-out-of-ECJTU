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

public partial class SystemManage_SystemUserSetDep : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            this.Label1.Text = Request.QueryString["UserName"].ToString();
            this.TextBox1.Text = LCX.DBUtility.DbHelperSQL.GetSHSL("select top 1 XiaShuUser from LCXUser where UserName='" + Request.QueryString["UserName"].ToString() + "'");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXUser set XiaShuUser='" + this.TextBox1.Text.Trim() + "' where UserName='" + Request.QueryString["UserName"].ToString() + "'");


        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户设置下属员工(" + this.Label1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "下属员工设置成功！", "SystemUser.aspx");
    }
}
