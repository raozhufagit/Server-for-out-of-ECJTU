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

public partial class Office_SheBeiAdd : System.Web.UI.Page
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
		LCX.BLL.LCXSheBei Model = new LCX.BLL.LCXSheBei();
		
		Model.SheBeiName=this.txtSheBeiName.Text.ToString();
		Model.YuanBianHao=this.txtYuanBianHao.Text.ToString();
		Model.CaiWuBianHao=this.txtCaiWuBianHao.Text.ToString();
		Model.JiBuBianHao=this.txtJiBuBianHao.Text.ToString();
		Model.SheBeiLeiBie=this.txtSheBeiLeiBie.Text.ToString();
		Model.XingHao=this.txtXingHao.Text.ToString();
		Model.XiangMu=this.txtXiangMu.Text.ToString();
		Model.ChuChangBianHao=this.txtChuChangBianHao.Text.ToString();
		Model.ShiYongBuMen=this.txtShiYongBuMen.Text.ToString();
		Model.ShengChanChangJia=this.txtShengChanChangJia.Text.ToString();
		Model.DanWei=this.txtDanWei.Text.ToString();
		Model.DanJia=this.txtDanJia.Text.ToString();
		Model.SuYuanFangShi=this.txtSuYuanFangShi.Text.ToString();
		Model.SuYaunDanWei=this.txtSuYaunDanWei.Text.ToString();
		Model.SuYuanZhouQi=this.txtSuYuanZhouQi.Text.ToString();
		Model.ShangCiSuYuanDate=this.txtShangCiSuYuanDate.Text.ToString();
		Model.JiHuaSuYaunDate=this.txtJiHuaSuYaunDate.Text.ToString();
		Model.ZhengShuBianHao=this.txtZhengShuBianHao.Text.ToString();
		Model.CeLiangFanWei=this.txtCeLiangFanWei.Text.ToString();
		Model.BuQueDingDu=this.txtBuQueDingDu.Text.ToString();
		Model.ShiYongCeLiangFanWei=this.txtShiYongCeLiangFanWei.Text.ToString();
		Model.JingDu=this.txtJingDu.Text.ToString();
		Model.JieGuoPingJia=this.txtJieGuoPingJia.Text.ToString();
		Model.PingJiaUser=this.txtPingJiaUser.Text.ToString();
		Model.QianZiDate=this.txtQianZiDate.Text.ToString();
		Model.ZhengGai=this.txtZhengGai.Text.ToString();
		Model.ChuCiSuYuanDate=this.txtChuCiSuYuanDate.Text.ToString();
		Model.QiYongDate=this.txtQiYongDate.Text.ToString();
		Model.CunFangAddr=this.txtCunFangAddr.Text.ToString();
		Model.GuanLiUser=this.txtGuanLiUser.Text.ToString();
		Model.JiFei=this.txtJiFei.Text.ToString();
		Model.ZhuangTai=this.txtZhuangTai.Text.ToString();
		Model.BeiZhu=this.txtBeiZhu.Text.ToString();
		Model.HeDuiUser=this.txtHeDuiUser.Text.ToString();
		Model.TiXingDate=this.txtTiXingDate.Text.ToString();
		Model.TiXingUser=this.txtTiXingUser.Text.ToString();
		Model.UserName=LCX.Common.PublicMethod.GetSessionValue("UserName");
		Model.TimeStr=DateTime.Now;
		
		Model.Add();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户添加仪器设备信息(" + this.txtSheBeiName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "仪器设备信息添加成功！", "SheBei.aspx");
	}
}
