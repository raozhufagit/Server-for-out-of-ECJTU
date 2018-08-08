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

public partial class Office_GuDingAdd : System.Web.UI.Page
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
		LCX.BLL.LCXGuDing Model = new LCX.BLL.LCXGuDing();
		
		Model.GDName=this.txtGDName.Text.ToString();
		Model.GDSerils=this.txtGDSerils.Text.ToString();
		Model.GDType=this.txtGDType.Text.ToString();
		Model.SuoShuBuMen=this.txtSuoShuBuMen.Text.ToString();
		Model.GDAllCount=this.txtGDAllCount.Text.ToString();
		Model.NowCount=this.txtNowCount.Text.ToString();
		Model.NianXian=this.txtNianXian.Text.ToString();
		Model.GDXingZhi=this.txtGDXingZhi.Text.ToString();
		Model.QiYongDate=this.txtQiYongDate.Text.ToString();
		Model.BaoGuanUser=this.txtBaoGuanUser.Text.ToString();
		Model.UserName=LCX.Common.PublicMethod.GetSessionValue("UserName");
		Model.TimeStr=DateTime.Now;
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		
		Model.Add();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "�û�����ʲ���Ϣ(" + this.txtGDName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "�ʲ���Ϣ��ӳɹ���", "GuDing.aspx");
	}
}
