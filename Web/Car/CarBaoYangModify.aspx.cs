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

public partial class Car_CarBaoYangModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXCarBY Model = new LCX.BLL.LCXCarBY();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtCarName.Text=Model.CarName.ToString();
			this.txtBYDate.Text=Model.BYDate.ToString();
			this.txtJingBanUser.Text=Model.JingBanUser.ToString();
			this.txtZhuGuanUser.Text=Model.ZhuGuanUser.ToString();
			this.txtBYQianLCBNum.Text=Model.BYQianLCBNum.ToString();
			this.txtQiYouJinE.Text=Model.QiYouJinE.ToString();
			this.txtBYJinE.Text=Model.BYJinE.ToString();
			this.txtWeiXiuJinE.Text=Model.WeiXiuJinE.ToString();
			this.txtOtherJinE.Text=Model.OtherJinE.ToString();
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXCarBY Model = new LCX.BLL.LCXCarBY();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.CarName=this.txtCarName.Text.ToString();
		Model.BYDate=this.txtBYDate.Text.ToString();
		Model.JingBanUser=this.txtJingBanUser.Text.ToString();
		Model.ZhuGuanUser=this.txtZhuGuanUser.Text.ToString();
		Model.BYQianLCBNum=this.txtBYQianLCBNum.Text.ToString();
		Model.QiYouJinE=this.txtQiYouJinE.Text.ToString();
		Model.BYJinE=this.txtBYJinE.Text.ToString();
		Model.WeiXiuJinE=this.txtWeiXiuJinE.Text.ToString();
		Model.OtherJinE=this.txtOtherJinE.Text.ToString();
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		
		Model.Update();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户修改车辆保养记录信息(" + this.txtCarName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "车辆保养记录信息修改成功！", "CarBaoYang.aspx");
	}
}
