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

public partial class DocFile_JiangChengZhiDuView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXPunishmentZhiDu Model = new LCX.BLL.LCXPunishmentZhiDu();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblTitleStr.Text=Model.TitleStr.ToString();
			this.lblJianJie.Text=Model.JianJie.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			this.lblFuJianStr.Text=LCX.Common.PublicMethod.GetWenJian(Model.FuJianStr.ToString(),"../UpLoadFile/");
			this.lblConTentStr.Text=Model.ConTentStr.ToString();
			
			//дϵͳ��־
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "�û��鿴�����ƶ���Ϣ(" + this.lblTitleStr.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
