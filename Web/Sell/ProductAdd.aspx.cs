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

public partial class Sell_ProductAdd : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXProduct Model = new LCX.BLL.LCXProduct();
		
		Model.ProductName=this.txtProductName.Text.ToString();
		Model.ProductSerils=this.txtProductSerils.Text.ToString();
		Model.GongYingShang=this.txtGongYingShang.Text.ToString();
		Model.ProductType=this.txtProductType.Text.ToString();
		Model.XingHao=this.txtXingHao.Text.ToString();
		Model.DanWei=this.txtDanWei.Text.ToString();
		Model.ChengBen=this.txtChengBen.Text.ToString();
		Model.ChuShou=this.txtChuShou.Text.ToString();
		Model.RuKuSum=decimal.Parse(this.txtRuKuSum.Text);
		Model.ChuKuSum=decimal.Parse(this.txtChuKuSum.Text);
		Model.NowKuCun=decimal.Parse(this.txtNowKuCun.Text);
		Model.KuCunBaoJing=decimal.Parse(this.txtKuCunBaoJing.Text);
		Model.CunChuWeiZhi=this.txtCunChuWeiZhi.Text.ToString();
		Model.ChanPinMiaoShu=this.txtChanPinMiaoShu.Text.ToString();
		Model.BackInfo=this.txtBackInfo.Text.ToString();
        Model.ProductSize = this.txtProductSize.Text;
        Model.Performance = this.txtPerformance.Text;
        Model.Coating = this.txtCoating.Text;
        Model.SurfaceTreatment = this.txtSurfaceTreatment.Text;
        Model.MagnetizingDirection = this.txtMagnetizingDirection.Text;
        Model.Tolerance = this.txtTolerance.Text;
        Model.IsContainingTax = Int32.Parse(rdoIsContainingTax.SelectedValue);
		Model.Add();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "�û���Ӳ�Ʒ��Ϣ(" + this.txtProductName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "��Ʒ��Ϣ��ӳɹ���", "Product.aspx");
	}
}
