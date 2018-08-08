using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.IO;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class NetMail_NetEmailView : System.Web.UI.Page
{
    public string file;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();

            LCX.BLL.LCXNetEmail MyLanEmail = new LCX.BLL.LCXNetEmail();
            MyLanEmail.GetModel(int.Parse(Request.QueryString["ID"].ToString().Trim()));
            this.Label1.Text = MyLanEmail.EmailTitle;
            this.Label2.Text = MyLanEmail.FromUser;
            this.Label3.Text = MyLanEmail.ToUser;
            this.Label4.Text = MyLanEmail.TimeStr.ToString();
            this.Label5.Text = LCX.Common.PublicMethod.GetWenJian(MyLanEmail.FuJian, "../UploadFile/");
            file = MyLanEmail.EmailContent;
            //this.Label6.Text = System.Web.HttpContext.Current.Server.HtmlDecode(MyLanEmail.EmailContent);
            /*if (MyLanEmail.EmailContent != "")
            {
                StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("eml\\") + MyLanEmail.EmailContent);
                this.Label6.Text = sr.ReadToEnd();
                sr.Close();
            }
            */


            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看邮件(" + this.Label1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            //设置为已读
            if (MyLanEmail.ToUser.Trim() == LCX.Common.PublicMethod.GetSessionValue("UserName").Trim())
            {
                if (MyLanEmail.EmailState == "未读")
                {
                    LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXNetEmail set EmailState='已读' where ID=" + Request.QueryString["ID"].ToString().Trim());
                }
            }
        }
    }
}
