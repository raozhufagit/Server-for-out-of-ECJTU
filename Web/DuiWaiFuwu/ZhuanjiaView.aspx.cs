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

public partial class DuiWaiFuwu_ZhuanjiaView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.BLL.ZhuanJia Model = new LCX.BLL.ZhuanJia();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblGongHao.Text = Model.GongHao.ToString();
            this.lblXingMing.Text = Model.XingMing.ToString();
            this.lblBuMen.Text = Model.BuMen.ToString();
            this.lblXingBie.Text = Model.XingBie.ToString();
            this.lblChuShengRiQi.Text = string.Format("{0:d}", Model.ChuShengRiQi);
            this.lblXueLi.Text = Model.XueLi.ToString();
            this.lblXueWei.Text = Model.XueWei.ToString();
            this.lblXueKe.Text = Model.XueKe.ToString();
            this.lblYanJiuLingYu.Text = Model.YanJiuLingYu.ToString();
            this.lblZhiWu.Text = Model.ZhiWu.ToString();
            this.lblZhiCheng.Text = Model.ZhiCheng.ToString();
            this.lblTimeStr.Text = string.Format("{0:d}",Model.TimeStr);
            this.lblResearchFind.Text = Model.ResearchFind.ToString();
            this.lblNation.Text = Model.Nation.ToString();
            this.lblPolitical.Text = Model.Political.ToString();
            this.lblJianJie.Text = Model.JianJie.ToString();
            this.Image1.ImageUrl = "../UploadFile/" + Model.PortraitPath;
            this.lblFuJianStr.Text = LCX.Common.PublicMethod.GetWenJian(Model.FuJianStr, "../UploadFile/");
            //LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.FuJianStr);
            //LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
            //this.HyperLink1.Text = Model.PortraitPath;
            //this.HyperLink1.NavigateUrl = "../UploadFile/" + Model.PortraitPath;

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户查看专家信息(" + this.lblXingMing.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
