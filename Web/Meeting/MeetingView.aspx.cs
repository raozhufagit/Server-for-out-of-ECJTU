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

public partial class Meeting_MeetingView : System.Web.UI.Page
{
    public string MettingIp = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //绑定页面数据
            LCX.BLL.LCXMeet Model = new LCX.BLL.LCXMeet();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.Label1.Text = Model.MeetingTitle;
            this.Label9.Text = Model.HuiYiJiYao;
            this.Label2.Text = Model.MeetingZhuTi;
            this.Label3.Text = Model.MiaoShu;
            this.Label4.Text = Model.ChuXiRen;
            this.Label5.Text = Model.WangLuoHuiYiShiIP;
            MettingIp = this.Label5.Text;
            this.Label6.Text = Model.HuiYiZhuChi;
            this.Label7.Text = Model.KaiShiTime.ToString();            
            this.Label8.Text = Model.JieShuTime.ToString();            
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户进入会议(" + this.Label1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }

    }

    protected void btnChat_Click(object sender, EventArgs e)
    {
        Session["connStr"] = "preloader?userName=" + Session["UserName"].ToString() + "&password=&mediaServer=rtmp://" + ConfigurationManager.AppSettings["MeetingIP"] + "&role=3&roomID=" + Request.QueryString["ID"].ToString() + "&scriptType=aspx";
        string urls = "<script language='javascript'> window.open('meet.aspx', 'newwindow', 'height=600, width=900'); </script>";
        ClientScript.RegisterStartupScript(this.GetType(), "openwin", urls);
    }
}
