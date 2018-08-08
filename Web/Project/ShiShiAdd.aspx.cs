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

public partial class Project_ShiShiAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXShiShi model = new LCX.BLL.LCXShiShi();
        model.ProjectName = this.txtProjectName.Text;
        model.ProjectSerils = this.txtProjectSerils.Text;
        model.ShiShiTime = this.txtShiShiTime.Text;
        model.ShiShiRen = this.txtShiShiRen.Text;
        model.ShiShiContent = this.txtShiShiContent.Text;
        model.WanGongLiang = this.txtWanGongLiang.Text;
        model.PingJia = this.txtPingJia.Text;
        model.XiaoJie = this.txtXiaoJie.Text;
        model.WenTi = this.txtWenTi.Text;
        model.YuJiJieJueRiQi = this.txtYuJiJieJueRiQi.Text;
        model.WenTiJieDa = this.txtWenTiJieDa.Text;
        model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.TimeStr = DateTime.Now;
        model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加实施信息(" + this.txtProjectName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "实施日志信息添加成功！", "ShiShiRiZhi.aspx?ProjectName=" + Request.QueryString["ProjectName"].ToString());
    }
}