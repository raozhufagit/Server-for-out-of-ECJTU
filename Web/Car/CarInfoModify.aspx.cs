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

public partial class Car_CarInfoModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXCarInfo Model = new LCX.BLL.LCXCarInfo();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtCarName.Text=Model.CarName.ToString();
			this.txtCarPaiHao.Text=Model.CarPaiHao.ToString();
			this.txtCarXingHao.Text=Model.CarXingHao.ToString();
			this.txtLeiXing.Text=Model.LeiXing.ToString();
			this.txtDriverUser.Text=Model.DriverUser.ToString();
			this.txtNowState.Text=Model.NowState.ToString();
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
            this.TextBox1.Text = Model.SuoShuDep.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXCarInfo Model = new LCX.BLL.LCXCarInfo();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.CarName=this.txtCarName.Text.ToString();
		Model.CarPaiHao=this.txtCarPaiHao.Text.ToString();
		Model.CarXingHao=this.txtCarXingHao.Text.ToString();
		Model.LeiXing=this.txtLeiXing.Text.ToString();
		Model.DriverUser=this.txtDriverUser.Text.ToString();
		Model.NowState=this.txtNowState.Text.ToString();
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		Model.BackInfo=this.txtBackInfo.Text.ToString();
        Model.SuoShuDep = this.TextBox1.Text.ToString();
		
		Model.Update();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改车辆管理信息(" + this.txtCarName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "车辆管理信息修改成功！", "CarInfo.aspx");
	}
}
