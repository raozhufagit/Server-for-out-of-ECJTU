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

public partial class Car_CarWeiZhangModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXCarPeccancy Model = new LCX.BLL.LCXCarPeccancy();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtCarName.Text=Model.CarName.ToString();
			this.txtWZDate.Text=Model.WZDate.ToString();
			this.txtDriverUser.Text=Model.DriverUser.ToString();
			this.txtWZAddress.Text=Model.WZAddress.ToString();
			this.txtKouFenNum.Text=Model.KouFenNum.ToString();
			this.txtFKJinE.Text=Model.FKJinE.ToString();
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXCarPeccancy Model = new LCX.BLL.LCXCarPeccancy();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.CarName=this.txtCarName.Text.ToString();
		Model.WZDate=this.txtWZDate.Text.ToString();
		Model.DriverUser=this.txtDriverUser.Text.ToString();
		Model.WZAddress=this.txtWZAddress.Text.ToString();
		Model.KouFenNum=this.txtKouFenNum.Text.ToString();
		Model.FKJinE=this.txtFKJinE.Text.ToString();
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		
		Model.Update();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户修改车辆违章记录信息(" + this.txtCarName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "车辆违章记录信息修改成功！", "CarWeiZhang.aspx");
	}
}
