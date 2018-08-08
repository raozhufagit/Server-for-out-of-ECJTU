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

public partial class Personal_ChangPwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            this.Label1.Text = LCX.Common.PublicMethod.GetSessionValue("UserName");

            //设定按钮权限
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|012M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXUser MyModel = new LCX.BLL.LCXUser();
        MyModel.ID = int.Parse(LCX.Common.PublicMethod.GetSessionValue("UserID"));
        MyModel.UserPwd = LCX.Common.DEncrypt.DESEncrypt.Encrypt(this.TextBox1.Text);
        MyModel.UpdatePwd();
        LCX.Common.MessageBox.Show(this, "修改用户密码成功！");

        
        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改密码";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
    }
}