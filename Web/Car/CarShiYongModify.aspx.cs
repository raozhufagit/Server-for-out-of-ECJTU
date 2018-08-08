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

public partial class Car_CarShiYongModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXCarUse Model = new LCX.BLL.LCXCarUse();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtCarName.Text=Model.CarName.ToString();
			this.txtDriverUser.Text=Model.DriverUser.ToString();
			this.txtYongCheUser.Text=Model.YongCheUser.ToString();
			this.txtYongCheBuMen.Text=Model.YongCheBuMen.ToString();
			this.txtQiShiTime.Text=Model.QiShiTime.ToString();
			this.txtJieShuTime.Text=Model.JieShuTime.ToString();
			this.txtMuDiDi.Text=Model.MuDiDi.ToString();
			this.txtLiCheng.Text=Model.LiCheng.ToString();
			this.txtShengQingUser.Text=Model.ShengQingUser.ToString();
			this.txtDiaoDuUser.Text=Model.DiaoDuUser.ToString();
			this.txtShengQingShiYou.Text=Model.ShengQingShiYou.ToString();
			//this.txtNowState.Text=Model.NowState.ToString();
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXCarUse Model = new LCX.BLL.LCXCarUse();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.CarName=this.txtCarName.Text.ToString();
		Model.DriverUser=this.txtDriverUser.Text.ToString();
		Model.YongCheUser=this.txtYongCheUser.Text.ToString();
		Model.YongCheBuMen=this.txtYongCheBuMen.Text.ToString();
		Model.QiShiTime=this.txtQiShiTime.Text.ToString();
		Model.JieShuTime=this.txtJieShuTime.Text.ToString();
		Model.MuDiDi=this.txtMuDiDi.Text.ToString();
		Model.LiCheng=this.txtLiCheng.Text.ToString();
		Model.ShengQingUser=this.txtShengQingUser.Text.ToString();
		Model.DiaoDuUser=this.txtDiaoDuUser.Text.ToString();
		Model.ShengQingShiYou=this.txtShengQingShiYou.Text.ToString();
		Model.NowState="";
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		
		Model.Update();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "�û��޸ĳ���ʹ����Ϣ(" + this.txtCarName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "����ʹ����Ϣ�޸ĳɹ���", "CarShiYong.aspx");
	}
}
