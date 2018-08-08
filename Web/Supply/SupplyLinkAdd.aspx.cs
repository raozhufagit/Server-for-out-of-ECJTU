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

public partial class Supply_SupplyLinkAdd : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
            this.txtSupplysName.Text = Request.QueryString["GongYingShang"].ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXSupplyLink Model = new LCX.BLL.LCXSupplyLink();
		
		Model.SupplysName=this.txtSupplysName.Text.ToString();
		Model.LinkManName=this.txtLinkManName.Text.ToString();
		Model.ZhiWei=this.txtZhiWei.Text.ToString();
		Model.Sex=this.txtSex.Text.ToString();
		Model.ShengRi=DateTime.Parse(this.txtShengRi.Text);
		Model.AiHao=this.txtAiHao.Text.ToString();
		Model.IFFirstLink=this.txtIFFirstLink.Text.ToString();
		Model.YouBian=this.txtYouBian.Text.ToString();
		Model.DiZhi=this.txtDiZhi.Text.ToString();
		Model.JobTel=this.txtJobTel.Text.ToString();
		Model.JiaTingTel=this.txtJiaTingTel.Text.ToString();
		Model.MobTel=this.txtMobTel.Text.ToString();
		Model.EmailStr=this.txtEmailStr.Text.ToString();
		Model.QQorMsn=this.txtQQorMsn.Text.ToString();
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		Model.UserName=LCX.Common.PublicMethod.GetSessionValue("UserName");
		Model.TimeStr=DateTime.Now;
		
		Model.Add();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加供应商联系人信息(" + this.txtSupplysName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "供应商联系人信息添加成功！", "SupplysLink.aspx?GongYingShang=" + Request.QueryString["GongYingShang"].ToString());
	}
}
