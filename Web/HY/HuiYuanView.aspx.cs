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

public partial class HY_HuiYuanView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXVip Model = new LCX.BLL.LCXVip();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblNameStr.Text=Model.NameStr.ToString();
			this.lblRuHuiDate.Text=Model.RuHuiDate.ToString();
			this.lblJieShaoRen.Text=Model.JieShaoRen.ToString();
			this.lblSexStr.Text=Model.SexStr.ToString();
			this.lblJiGuan.Text=Model.JiGuan.ToString();
			this.lblJingJi.Text=Model.JingJi.ToString();
			this.lblChuShengDate.Text=Model.ChuShengDate.ToString();
			this.lblXueLi.Text=Model.XueLi.ToString();
			this.lblZiLi.Text=Model.ZiLi.ToString();
			this.lblGeXing.Text=Model.GeXing.ToString();
			this.lblAiHao.Text=Model.AiHao.ToString();
			this.lblAddress.Text=Model.Address.ToString();
			this.lblTel.Text=Model.Tel.ToString();
			this.lblMobTel.Text=Model.MobTel.ToString();
			this.lblZuiJiaTime.Text=Model.ZuiJiaTime.ToString();
			this.lblChangYong.Text=Model.ChangYong.ToString();
			this.lblZiXin.Text=Model.ZiXin.ToString();
			this.lblJieLun.Text=Model.JieLun.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户查看会员信息(" + this.lblNameStr.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
