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

public partial class Car_CarJiaYouModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXCarJiaYou Model = new LCX.BLL.LCXCarJiaYou();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtCarName.Text=Model.CarName.ToString();
			this.txtJYDate.Text=Model.JYDate.ToString();
			this.txtJingBanUser.Text=Model.JingBanUser.ToString();
			this.txtDriverUser.Text=Model.DriverUser.ToString();
			this.txtJiaYouAddress.Text=Model.JiaYouAddress.ToString();
			this.txtStartNum.Text=Model.StartNum.ToString();
			this.txtJiaYouNum.Text=Model.JiaYouNum.ToString();
			this.txtYouFeiJinE.Text=Model.YouFeiJinE.ToString();
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXCarJiaYou Model = new LCX.BLL.LCXCarJiaYou();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.CarName=this.txtCarName.Text.ToString();
		Model.JYDate=this.txtJYDate.Text.ToString();
		Model.JingBanUser=this.txtJingBanUser.Text.ToString();
		Model.DriverUser=this.txtDriverUser.Text.ToString();
		Model.JiaYouAddress=this.txtJiaYouAddress.Text.ToString();
		Model.StartNum=this.txtStartNum.Text.ToString();
		Model.JiaYouNum=this.txtJiaYouNum.Text.ToString();
		Model.YouFeiJinE=this.txtYouFeiJinE.Text.ToString();
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		
		Model.Update();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "�û��޸ĳ������ͼ�¼��Ϣ(" + this.txtCarName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "�������ͼ�¼��Ϣ�޸ĳɹ���", "CarJiaYou.aspx");
	}
}
