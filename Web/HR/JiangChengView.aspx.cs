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

public partial class HRNew_JiangChengView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXPunishment Model = new LCX.BLL.LCXPunishment();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblJCUser.Text=Model.JCUser.ToString();
			this.lblJiangChengQuFen.Text=Model.JiangChengQuFen.ToString();
			this.lblJiangChengType.Text=Model.JiangChengType.ToString();
			this.lblShouYuDanWei.Text=Model.ShouYuDanWei.ToString();
			this.lblJiangChengDate.Text=Model.JiangChengDate.ToString();
			this.lblJiangChengMingMu.Text=Model.JiangChengMingMu.ToString();
			this.lblJiangChengYuanYin.Text=Model.JiangChengYuanYin.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看奖惩记录信息(" + this.lblJCUser.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
