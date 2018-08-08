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

public partial class DocFile_TiKuTypeModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXQuestionType Model = new LCX.BLL.LCXQuestionType();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtTiKuName.Text=Model.TiKuName.ToString();
			this.txtPaiXu.Text=Model.PaiXu.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXQuestionType Model = new LCX.BLL.LCXQuestionType();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.TiKuName=this.txtTiKuName.Text.ToString();
		Model.PaiXu=this.txtPaiXu.Text.ToString();
		
		Model.Update();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户修改题库分类信息(" + this.txtTiKuName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "题库分类信息修改成功！", "TiKuType.aspx");
	}
}
