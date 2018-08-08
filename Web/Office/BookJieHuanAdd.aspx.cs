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

public partial class Office_BookJieHuanAdd : System.Web.UI.Page
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
		LCX.BLL.LCXBookBorrow Model = new LCX.BLL.LCXBookBorrow();
		
		Model.BookName=this.txtBookName.Text.ToString();
		Model.JieShuDate=this.txtJieShuDate.Text.ToString();
        Model.GuiHuanDate = this.txtGuiHuanDate.Text.ToString();
        Model.JieHuanState = this.txtJieHuanState.Text.ToString();
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		Model.UserName=this.txtUserName.Text;
		Model.TimeStr=DateTime.Now;
		
		Model.Add();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "�û����ͼ��軹��¼��Ϣ(" + this.txtBookName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "ͼ��軹��¼��Ϣ��ӳɹ���", "BookJieHuan.aspx");
	}
}
