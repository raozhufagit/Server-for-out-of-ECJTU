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

public partial class Car_CarBaoXianAdd : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			//设置上传的附件为空
			 LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXCarBX Model = new LCX.BLL.LCXCarBX();
		
		Model.CarName=this.txtCarName.Text.ToString();
		Model.FeiYongName=this.txtFeiYongName.Text.ToString();
		Model.ProjectName=this.txtProjectName.Text.ToString();
		Model.BaoXianPrice=this.txtBaoXianPrice.Text.ToString();
		Model.BaoXianDate=this.txtBaoXianDate.Text.ToString();
		Model.TiXingDate=this.txtTiXingDate.Text.ToString();
        Model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName"); ;
        Model.TimeStr = DateTime.Now;
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		
		Model.Add();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户添加车辆保险费用信息(" + this.txtCarName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "车辆保险费用信息添加成功！", "CarBaoXian.aspx");
	}
}
