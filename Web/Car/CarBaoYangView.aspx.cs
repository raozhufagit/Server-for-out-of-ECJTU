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

public partial class Car_CarBaoYangView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXCarBY Model = new LCX.BLL.LCXCarBY();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblCarName.Text=Model.CarName.ToString();
			this.lblBYDate.Text=Model.BYDate.ToString();
			this.lblJingBanUser.Text=Model.JingBanUser.ToString();
			this.lblZhuGuanUser.Text=Model.ZhuGuanUser.ToString();
			this.lblBYQianLCBNum.Text=Model.BYQianLCBNum.ToString();
			this.lblQiYouJinE.Text=Model.QiYouJinE.ToString();
			this.lblBYJinE.Text=Model.BYJinE.ToString();
			this.lblWeiXiuJinE.Text=Model.WeiXiuJinE.ToString();
			this.lblOtherJinE.Text=Model.OtherJinE.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户查看车辆保养记录信息(" + this.lblCarName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
