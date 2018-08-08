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

public partial class Supply_BuyOrderView : System.Web.UI.Page
{
    public string OrderName = "";

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXBuyOrder Model = new LCX.BLL.LCXBuyOrder();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblOrderName.Text=Model.OrderName.ToString();
            OrderName = Model.OrderName.ToString();
			this.lblGongYingShangName.Text=Model.GongYingShangName.ToString();
			this.lblSerils.Text=Model.Serils.ToString();
			this.lblDingDanLeiXing.Text=Model.DingDanLeiXing.ToString();
			this.lblDingDanMiaoShu.Text=Model.DingDanMiaoShu.ToString();
            this.lblCreateDate.Text = Model.CreateDate.ToString().Replace(" 0:00:00", "");
            this.lblLaiHuoDate.Text = Model.LaiHuoDate.ToString().Replace(" 0:00:00", "");
            this.lblTiXingDate.Text = Model.TiXingDate.ToString().Replace(" 0:00:00", "");
			this.lblChuangJianRen.Text=Model.ChuangJianRen.ToString();
			this.lblFuZeRen.Text=Model.FuZeRen.ToString();
            this.lblFuJianList.Text = LCX.Common.PublicMethod.GetWenJian(Model.FuJianList.ToString(), "../UploadFile/");
			this.lblNowState.Text=Model.NowState.ToString();
			this.lblShenPiTongGuoRen.Text=Model.ShenPiTongGuoRen.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看采购订单信息(" + this.lblOrderName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
