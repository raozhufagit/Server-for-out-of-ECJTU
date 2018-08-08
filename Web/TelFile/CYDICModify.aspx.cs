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

public partial class Car_CYDICModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXCYDIC Model = new LCX.BLL.LCXCYDIC();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtDicName.Text=Model.DicName.ToString();
			this.txtBackinfo.Text=Model.Backinfo.ToString();
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXCYDIC Model = new LCX.BLL.LCXCYDIC();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.DicName=this.txtDicName.Text.ToString();
		Model.Backinfo=this.txtBackinfo.Text.ToString();
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		
		Model.Update();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "�û��޸Ĵ����ļ�����Ϣ(" + this.txtDicName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "�����ļ�����Ϣ�޸ĳɹ���", "CYDIC.aspx");
	}
}
