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

public partial class Financial_ReimburseView : System.Web.UI.Page
{
    public string HeTongName = "";

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXReimburse Model = new LCX.BLL.LCXReimburse();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblHeTongName.Text=Model.HeTongName.ToString();
            HeTongName = Model.HeTongName.ToString();
            this.lblUserName.Text = Model.UserName.ToString();
			this.lblQianYueKeHu.Text=Model.QianYueKeHu.ToString();
            this.lblReimburseContent.Text = Model.ReimburseContent.ToString();
            this.lblApplyTime.Text = Model.ApplyTime.ToString();
            this.lblMemo.Text = Model.Memo.ToString();
			
			//дϵͳ��־
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "�û��鿴��������Ϣ(" + this.lblReimburseContent.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
