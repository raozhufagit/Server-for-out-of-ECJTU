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

public partial class Car_CarShiYongAdd : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXCarUse Model = new LCX.BLL.LCXCarUse();
		
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
		Model.UserName=LCX.Common.PublicMethod.GetSessionValue("UserName");
		Model.TimeStr=DateTime.Now;
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		
		Model.Add();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户添加车辆使用信息(" + this.txtCarName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "车辆使用信息添加成功！", "CarShiYong.aspx");
	}
}
