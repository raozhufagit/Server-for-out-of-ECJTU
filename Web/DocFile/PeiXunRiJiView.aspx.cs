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

public partial class DocFile_PeiXunRiJiView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXTrainRiJi Model = new LCX.BLL.LCXTrainRiJi();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblPeiXunName.Text=Model.PeiXunName.ToString();
			this.lblRiJiTitle.Text=Model.RiJiTitle.ToString();
			this.lblRiJiDate.Text=Model.RiJiDate.ToString();
			this.lblRiJiContent.Text=Model.RiJiContent.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看培训日志信息(" + this.lblPeiXunName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
