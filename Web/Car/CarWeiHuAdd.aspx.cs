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

public partial class Car_CarWeiHuAdd : System.Web.UI.Page
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
		LCX.BLL.LCXCarWeiHu Model = new LCX.BLL.LCXCarWeiHu();
		
		Model.CarName=this.txtCarName.Text.ToString();
		Model.WeiHuRiQi=this.txtWeiHuRiQi.Text.ToString();
		Model.WeiHuLeiXing=this.txtWeiHuLeiXing.Text.ToString();
		Model.WeiHuYuanYin=this.txtWeiHuYuanYin.Text.ToString();
		Model.JingBanUser=this.txtJingBanUser.Text.ToString();
		Model.WeiHuFeiYong=this.txtWeiHuFeiYong.Text.ToString();
		Model.NowState="";
		Model.UserName=LCX.Common.PublicMethod.GetSessionValue("UserName");
		Model.TimeStr=DateTime.Now;
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		
		Model.Add();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "�û���ӳ���ά����Ϣ(" + this.txtCarName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "����ά����Ϣ��ӳɹ���", "CarWeiHu.aspx");
	}
}
