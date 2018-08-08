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

public partial class Project_ShiShiView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXShiShi model = new LCX.BLL.LCXShiShi();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblProjectName.Text = model.ProjectName;
            this.lblProjectSerils.Text = model.ProjectSerils;
            this.lblShiShiTime.Text = model.ShiShiTime;
            this.lblShiShiRen.Text = model.ShiShiRen;
            this.lblShiShiContent.Text = model.ShiShiContent;
            this.lblWanGongLiang.Text = model.WanGongLiang;
            this.lblPingJia.Text = model.PingJia;
            this.lblXiaoJie.Text = model.XiaoJie;
            this.lblWenTi.Text = model.WenTi;
            this.lblYuJiJieJueRiQi.Text = model.YuJiJieJueRiQi;
            this.lblWenTiJieDa.Text = model.WenTiJieDa;
            this.lblUserName.Text = model.UserName;
            this.lblTimeStr.Text = model.TimeStr.ToString();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看实施日志信息(" + this.lblProjectName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}
