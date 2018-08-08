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

public partial class Personal_MailSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXPOPAndSMTP MyModel = new LCX.BLL.LCXPOPAndSMTP();
            MyModel.GetModel(int.Parse(LCX.Common.PublicMethod.GetSessionValue("UserID")));
            this.TextBox1.Text = MyModel.POP3UserName;
            this.TextBox2.Text = MyModel.POP3UserPwd;
            this.TextBox3.Text = MyModel.POP3Server;
            this.TextBox4.Text = MyModel.POP3Port;
            this.TextBox5.Text = MyModel.SMTPUserName;
            this.TextBox6.Text = MyModel.SMTPUserPwd;
            this.TextBox7.Text = MyModel.SMTPServer;
            this.TextBox8.Text = MyModel.SMTPFromEmail;

            TextBox2.Attributes.Add("value", MyModel.POP3UserPwd);
            TextBox6.Attributes.Add("value", MyModel.SMTPUserPwd); 

            //设定按钮权限            
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|096M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXPOPAndSMTP MyModel = new LCX.BLL.LCXPOPAndSMTP();
        MyModel.ID = int.Parse(LCX.Common.PublicMethod.GetSessionValue("UserID"));
        MyModel.POP3UserName = this.TextBox1.Text;
        MyModel.POP3UserPwd = this.TextBox2.Text;
        MyModel.POP3Server = this.TextBox3.Text;
        MyModel.POP3Port = this.TextBox4.Text;
        MyModel.SMTPUserName = this.TextBox5.Text;
        MyModel.SMTPUserPwd = this.TextBox6.Text;
        MyModel.SMTPServer = this.TextBox7.Text;
        MyModel.SMTPFromEmail = this.TextBox8.Text;
        MyModel.Update();
        LCX.Common.MessageBox.Show(this, "修改邮件参数成功！");

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户设置邮件参数";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
    }
}