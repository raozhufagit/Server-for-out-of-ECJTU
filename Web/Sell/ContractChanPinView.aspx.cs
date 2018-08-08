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

public partial class Sell_ContractChanPinView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXCProduct Model = new LCX.BLL.LCXCProduct();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblHeTongName.Text=Model.HeTongName.ToString();
			this.lblChanPinName.Text=Model.ChanPinName.ToString();
			this.lblDanJia.Text=Model.DanJia.ToString();
			this.lblShuLiang.Text=Model.ShuLiang.ToString();
			this.lblZongJia.Text=Model.ZongJia.ToString();
			this.lblYiFuKuan.Text=Model.YiFuKuan.ToString();
			this.lblQianKuanShu.Text=Model.QianKuanShu.ToString();
			this.lblIFJiaoFu.Text=Model.IFJiaoFu.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();

            LCX.BLL.LCXProduct ModelProduct = new LCX.BLL.LCXProduct();
            ModelProduct.GetModelByName(Model.ChanPinName.ToString());
            this.lblProductSize.Text = ModelProduct.ProductSize;
            this.lblPerformance.Text = ModelProduct.Performance;
            this.lblCoating.Text = ModelProduct.Coating;
            this.lblSurfaceTreatment.Text = ModelProduct.SurfaceTreatment;
            this.lblMagnetizingDirection.Text = ModelProduct.MagnetizingDirection;
            this.lblTolerance.Text = ModelProduct.Tolerance;
            this.lblIsContainingTax.Text = ModelProduct.IsContainingTax == 1 ? "是" : "否";

			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看订单产品信息(" + this.lblHeTongName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
