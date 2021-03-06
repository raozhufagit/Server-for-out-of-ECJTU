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

public partial class Car_CarShiYongView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXCarUse Model = new LCX.BLL.LCXCarUse();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblCarName.Text=Model.CarName.ToString();
			this.lblDriverUser.Text=Model.DriverUser.ToString();
			this.lblYongCheUser.Text=Model.YongCheUser.ToString();
			this.lblYongCheBuMen.Text=Model.YongCheBuMen.ToString();
			this.lblQiShiTime.Text=Model.QiShiTime.ToString();
			this.lblJieShuTime.Text=Model.JieShuTime.ToString();
			this.lblMuDiDi.Text=Model.MuDiDi.ToString();
			this.lblLiCheng.Text=Model.LiCheng.ToString();
			this.lblShengQingUser.Text=Model.ShengQingUser.ToString();
			this.lblDiaoDuUser.Text=Model.DiaoDuUser.ToString();
			this.lblShengQingShiYou.Text=Model.ShengQingShiYou.ToString();
			//this.lblNowState.Text=Model.NowState.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户查看车辆使用信息(" + this.lblCarName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
