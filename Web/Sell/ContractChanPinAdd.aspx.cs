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

public partial class Sell_ContractChanPinAdd : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
            this.txtHeTongName.Attributes.Add("readonly", "true");
            this.txtChanPinName.Attributes.Add("readonly", "true");
            this.txtHeTongName.Text = Request.QueryString["HeTongName"].ToString();
            this.txtYiFuKuan.Text = "0";
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXCProduct Model = new LCX.BLL.LCXCProduct();
		
		Model.HeTongName=this.txtHeTongName.Text.ToString();
		Model.ChanPinName=this.txtChanPinName.Text.ToString();
		Model.DanJia=decimal.Parse(this.txtDanJia.Text);
		Model.ShuLiang=decimal.Parse(this.txtShuLiang.Text);
		Model.ZongJia=decimal.Parse(this.txtZongJia.Text);
		Model.YiFuKuan=decimal.Parse(this.txtYiFuKuan.Text);
		Model.QianKuanShu=decimal.Parse(this.txtQianKuanShu.Text);
		Model.IFJiaoFu=this.RadioButtonList1.SelectedItem.Text;
        Model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		Model.TimeStr=DateTime.Now;
		Model.BackInfo=this.txtBackInfo.Text.ToString();

        if (this.RadioButtonList1.SelectedItem.Text == "已交付")
        {
            //从产品库存中减去
            string TempSqlStr = "update LCXProduct set  ChuKuSum=ChuKuSum+" + this.txtShuLiang.Text + ",NowKuCun=NowKuCun-" + this.txtShuLiang.Text + " where ProductName='" + this.txtChanPinName.Text.ToString()+"'";
            LCX.DBUtility.DbHelperSQL.ExecuteSQL(TempSqlStr);
        }
		
		Model.Add();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户添加合同产品信息(" + this.txtHeTongName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "合同产品信息添加成功！", "SellLog.aspx?HeTongName=" + Request.QueryString["HeTongName"].ToString());
	}
    protected void txtChanPinName_TextChanged(object sender, EventArgs e)
    {
        LCX.BLL.LCXProduct Model = new LCX.BLL.LCXProduct();
        Model.GetModelByName(txtChanPinName.Text);
        this.txtProductSize.Text = Model.ProductSize;
        this.txtPerformance.Text = Model.Performance;
        this.txtCoating.Text = Model.Coating;
        this.txtSurfaceTreatment.Text = Model.SurfaceTreatment;
        this.txtMagnetizingDirection.Text = Model.MagnetizingDirection;
        this.txtTolerance.Text = Model.Tolerance;
        this.rdoIsContainingTax.SelectedValue = Model.IsContainingTax.ToString();
    }
    protected void txtDanJia_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal dDanJia = decimal.Parse(String.IsNullOrEmpty(this.txtDanJia.Text) ? "0" : this.txtDanJia.Text);
            decimal dShuLiang = decimal.Parse(String.IsNullOrEmpty(this.txtShuLiang.Text) ? "0" : this.txtShuLiang.Text);
            decimal dYiFu = decimal.Parse(String.IsNullOrEmpty(this.txtYiFuKuan.Text) ? "0" : this.txtYiFuKuan.Text);
            txtZongJia.Text = (dDanJia * dShuLiang).ToString();
            txtQianKuanShu.Text = (dDanJia * dShuLiang - dYiFu).ToString();
        }
        catch
        {

        }
    }
    protected void txtShuLiang_TextChanged(object sender, EventArgs e)
    {
        try
        {
            decimal dDanJia = decimal.Parse(String.IsNullOrEmpty(this.txtDanJia.Text) ? "0" : this.txtDanJia.Text);
            decimal dShuLiang = decimal.Parse(String.IsNullOrEmpty(this.txtShuLiang.Text) ? "0" : this.txtShuLiang.Text);
            decimal dYiFu = decimal.Parse(String.IsNullOrEmpty(this.txtYiFuKuan.Text) ? "0" : this.txtYiFuKuan.Text);
            txtZongJia.Text = (dDanJia * dShuLiang).ToString();
            txtQianKuanShu.Text = (dDanJia * dShuLiang - dYiFu).ToString();
        }
        catch
        {

        }
    }
    protected void txtZongJia_TextChanged(object sender, EventArgs e)
    {
        decimal dZongJia = decimal.Parse(String.IsNullOrEmpty(this.txtZongJia.Text) ? "0" : this.txtZongJia.Text);
        decimal dYiFu = decimal.Parse(String.IsNullOrEmpty(this.txtYiFuKuan.Text) ? "0" : this.txtYiFuKuan.Text);
        txtQianKuanShu.Text = (dZongJia - dYiFu).ToString();
    }
    protected void txtYiFuKuan_TextChanged(object sender, EventArgs e)
    {
        decimal dZongJia = decimal.Parse(String.IsNullOrEmpty(this.txtZongJia.Text) ? "0" : this.txtZongJia.Text);
        decimal dYiFu = decimal.Parse(String.IsNullOrEmpty(this.txtYiFuKuan.Text) ? "0" : this.txtYiFuKuan.Text);
        txtQianKuanShu.Text = (dZongJia - dYiFu).ToString();
    }
}
