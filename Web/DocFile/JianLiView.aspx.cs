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

public partial class DocFile_JianLiView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXJianLi Model = new LCX.BLL.LCXJianLi();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblYPName.Text=Model.YPName.ToString();
			this.lblYPDate.Text=Model.YPDate.ToString();
			this.lblYPSex.Text=Model.YPSex.ToString();
			this.lblYPAge.Text=Model.YPAge.ToString();
			this.lblXueLi.Text=Model.XueLi.ToString();
			this.lblZhuanYe.Text=Model.ZhuanYe.ToString();
			this.lblYPZhiWei.Text=Model.YPZhiWei.ToString();
			this.lblYPJieGuo.Text=Model.YPJieGuo.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			this.lblFuJianStr.Text=LCX.Common.PublicMethod.GetWenJian(Model.FuJianStr.ToString(),"../UpLoadFile/");
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户查看人员简历信息(" + this.lblYPName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
