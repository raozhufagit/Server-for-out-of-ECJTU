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

public partial class Car_CarWeiHuView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXCarWeiHu Model = new LCX.BLL.LCXCarWeiHu();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblCarName.Text=Model.CarName.ToString();
			this.lblWeiHuRiQi.Text=Model.WeiHuRiQi.ToString();
			this.lblWeiHuLeiXing.Text=Model.WeiHuLeiXing.ToString();
			this.lblWeiHuYuanYin.Text=Model.WeiHuYuanYin.ToString();
			this.lblJingBanUser.Text=Model.JingBanUser.ToString();
			this.lblWeiHuFeiYong.Text=Model.WeiHuFeiYong.ToString();
			//this.lblNowState.Text=Model.NowState.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看车辆维护信息(" + this.lblCarName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
