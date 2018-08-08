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

public partial class NWorkFlow_NFormModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCX_Form Model = new LCX.BLL.LCX_Form();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtFormName.Text=Model.FormName.ToString();			
			this.txtUserListOK.Text=Model.UserListOK.ToString();
			this.txtDepListOK.Text=Model.DepListOK.ToString();
			this.txtJiaoSeListOK.Text=Model.JiaoSeListOK.ToString();
			this.txtPaiXuStr.Text=Model.PaiXuStr.ToString();			
			this.DropDownList1.SelectedValue=Model.IFOK.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCX_Form Model = new LCX.BLL.LCX_Form();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.FormName=this.txtFormName.Text.ToString();
		Model.UserListOK=this.txtUserListOK.Text.ToString();
		Model.DepListOK=this.txtDepListOK.Text.ToString();
		Model.JiaoSeListOK=this.txtJiaoSeListOK.Text.ToString();
		Model.PaiXuStr=this.txtPaiXuStr.Text.ToString();
		Model.IFOK=this.DropDownList1.SelectedValue.ToString();
		
		Model.Update();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户修改流程表单信息(" + this.txtFormName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "流程表单信息修改成功！", "NForm.aspx?TypeID="+Request.QueryString["TypeID"].ToString());
	}
}
