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

public partial class ReportCenter_ReportView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXReport Model = new LCX.BLL.LCXReport();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblReportName.Text=Model.ReportName.ToString();
			this.lblReportSql.Text=Model.ReportSql.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			this.lblTypeID.Text=Model.TypeID.ToString();
			this.lblUserListOK.Text=Model.UserListOK.ToString();
			this.lblDepListOK.Text=Model.DepListOK.ToString();
			this.lblJiaoSeListOK.Text=Model.JiaoSeListOK.ToString();
			this.lblPaiXuStr.Text=Model.PaiXuStr.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			
			//дϵͳ��־
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "�û��鿴���������Ϣ(" + this.lblReportName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
