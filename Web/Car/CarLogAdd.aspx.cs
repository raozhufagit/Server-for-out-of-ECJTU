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

public partial class Car_CarLogAdd : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			//�����ϴ��ĸ���Ϊ��
			 LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXCarLog Model = new LCX.BLL.LCXCarLog();
		
		Model.CarName=this.txtCarName.Text.ToString();
		Model.LogDate=this.txtLogDate.Text.ToString();
		Model.JingBanUser=this.txtJingBanUser.Text.ToString();
		Model.DriverUser=this.txtDriverUser.Text.ToString();
		Model.ChuCheDate=this.txtChuCheDate.Text.ToString();
		Model.StartNum=this.txtStartNum.Text.ToString();
		Model.EndNum=this.txtEndNum.Text.ToString();
		Model.XingShiTime=this.txtXingShiTime.Text.ToString();
		Model.ShiYou=this.txtShiYou.Text.ToString();
		Model.XingShiLiCheng=this.txtXingShiLiCheng.Text.ToString();
		Model.YouHaoShu=this.txtYouHaoShu.Text.ToString();
		Model.DaoDaAddress=this.txtDaoDaAddress.Text.ToString();
		Model.UserName=LCX.Common.PublicMethod.GetSessionValue("UserName");
		Model.TimeStr=DateTime.Now;
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		
		Model.Add();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "�û���ӳ�����־��¼��Ϣ(" + this.txtCarName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "������־��¼��Ϣ��ӳɹ���", "CarLog.aspx");
	}
}
