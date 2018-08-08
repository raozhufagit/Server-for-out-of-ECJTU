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

public partial class HRNew_JiangChengAdd : System.Web.UI.Page
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
		LCX.BLL.LCXPunishment Model = new LCX.BLL.LCXPunishment();
		
		Model.JCUser=this.txtJCUser.Text.ToString();
		Model.JiangChengQuFen=this.txtJiangChengQuFen.Text.ToString();
		Model.JiangChengType=this.txtJiangChengType.Text.ToString();
		Model.ShouYuDanWei=this.txtShouYuDanWei.Text.ToString();
		Model.JiangChengDate=this.txtJiangChengDate.Text.ToString();
		Model.JiangChengMingMu=this.txtJiangChengMingMu.Text.ToString();
		Model.JiangChengYuanYin=this.txtJiangChengYuanYin.Text.ToString();
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		Model.UserName=LCX.Common.PublicMethod.GetSessionValue("UserName");
		Model.TimeStr=DateTime.Now;
		
		Model.Add();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "�û���ӽ��ͼ�¼��Ϣ(" + this.txtJCUser.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "���ͼ�¼��Ϣ��ӳɹ���", "JiangCheng.aspx");
	}
}
