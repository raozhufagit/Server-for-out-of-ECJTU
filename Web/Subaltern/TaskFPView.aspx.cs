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

public partial class Subaltern_TaskFPView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXTaskFP Model = new LCX.BLL.LCXTaskFP();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblTaskTitle.Text=Model.TaskTitle.ToString();
			this.lblTaskContent.Text=Model.TaskContent.ToString();
			this.lblFromUser.Text=Model.FromUser.ToString();
			this.lblToUserList.Text=Model.ToUserList.ToString();
			this.lblXinXiGouTong.Text=Model.XinXiGouTong.ToString();
			this.lblJinDu.Text=Model.JinDu.ToString()+"%";
			this.lblWanCheng.Text=Model.WanCheng.ToString();
			this.lblNowState.Text=Model.NowState.ToString();
            this.Label1.Text = Model.KSSJ.ToString();
            this.Label2.Text = Model.JSSJ.ToString();
            this.Label3.Text = Model.SFFK.ToString();
            this.Label4.Text = Model.FKSJ.ToString();
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户查看任务分配信息(" + this.lblTaskTitle.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
