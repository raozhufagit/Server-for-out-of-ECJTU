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

public partial class CRM_BaoJiaView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXBaoJia model = new LCX.BLL.LCXBaoJia();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblCustomName.Text = model.CustomName;
            this.lblBaoJiaTitle.Text = model.BaoJiaTitle;
            this.lblBaoJiaType.Text = model.BaoJiaType;
            this.lblBaoJiaJinE.Text = model.BaoJiaJinE;
            this.lblBaoJiaContent.Text = model.BaoJiaContent;
            this.lblBaoJiaResult.Text = model.BaoJiaResult;
            this.lblBaoJiaTime.Text = model.BaoJiaTime;
            this.lblBackInfo.Text = model.BackInfo;
            this.lblUserName.Text = model.UserName;
            this.lblTimeStr.Text = model.TimeStr.ToString();
            this.lblIFShare.Text = model.IFShare;
            this.lblCusBakA.Text = model.CusBakA;
            this.lblCusBakB.Text = model.CusBakB;
            this.lblCusBakC.Text = model.CusBakC;
            this.lblCusBakD.Text = model.CusBakD;
            this.lblCusBakE.Text = model.CusBakE;

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看报价信息(" + this.lblCustomName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}
