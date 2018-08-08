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

public partial class WorkPlan_WorkPlanView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //绑定页面数据
            LCX.BLL.LCXHuiBao MyModel = new LCX.BLL.LCXHuiBao();
            MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.Label1.Text = MyModel.TitleStr;
            this.Label2.Text = MyModel.CanLookUser;
            this.Label6.Text = MyModel.ContentStr;
            this.Label4.Text = MyModel.UserName;
            this.Label5.Text = MyModel.TimeStr.ToString();

            this.HyperLink1.NavigateUrl = "../LanEmail/LanEmailAdd.aspx?UserName=" + MyModel.UserName;

            this.Label3.Text = LCX.Common.PublicMethod.GetWenJian(MyModel.FuJianStr, "../UploadFile/");

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看工作汇报信息(" + this.Label1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}
