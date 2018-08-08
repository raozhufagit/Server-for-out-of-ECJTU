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

public partial class Office_GuDingJiLuModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXGuDingJiLu Model = new LCX.BLL.LCXGuDingJiLu();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtGDName.Text=Model.GDName.ToString();
			this.txtZJType.Text=Model.ZJType.ToString();
			this.txtZJDate.Text=Model.ZJDate.ToString();
			this.txtZJJinE.Text=Model.ZJJinE.ToString();
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXGuDingJiLu Model = new LCX.BLL.LCXGuDingJiLu();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.GDName=this.txtGDName.Text.ToString();
		Model.ZJType=this.txtZJType.Text.ToString();
		Model.ZJDate=this.txtZJDate.Text.ToString();
		Model.ZJJinE=this.txtZJJinE.Text.ToString();
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		
		Model.Update();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "�û��޸��۾ɼ�¼��Ϣ(" + this.txtGDName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "�۾ɼ�¼��Ϣ�޸ĳɹ���", "GuDingJiLu.aspx?GDName=" + Request.QueryString["GDName"].ToString());
	}
}
