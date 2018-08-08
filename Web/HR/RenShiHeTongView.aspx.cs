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

public partial class HRNew_RenShiHeTongView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXP_Contract Model = new LCX.BLL.LCXP_Contract();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblHeTongUser.Text=Model.HeTongUser.ToString();
			this.lblNowState.Text=Model.NowState.ToString();
			this.lblSerils.Text=Model.Serils.ToString();
			this.lblTypeStr.Text=Model.TypeStr.ToString();
			this.lblJingYe.Text=Model.JingYe.ToString();
			this.lblBaoMiXieYi.Text=Model.BaoMiXieYi.ToString();
			this.lblQianYueDate.Text=Model.QianYueDate.ToString();
			this.lblManYueDate.Text=Model.ManYueDate.ToString();
			this.lblJianZhengJiGuan.Text=Model.JianZhengJiGuan.ToString();
			this.lblJianZhengDate.Text=Model.JianZhengDate.ToString();
			this.lblWeiYueZeRen.Text=Model.WeiYueZeRen.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			this.lblFuJianList.Text=LCX.Common.PublicMethod.GetWenJian(Model.FuJianList.ToString(),"../UploadFile/");
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看人事合同信息(" + this.lblHeTongUser.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
