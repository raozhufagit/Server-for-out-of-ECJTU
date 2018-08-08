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

public partial class Supply_SupplysAdd : System.Web.UI.Page
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
		LCX.BLL.LCXSupplys Model = new LCX.BLL.LCXSupplys();
		
		Model.SupplysName=this.txtSupplysName.Text.ToString();
		Model.Serils=this.txtSerils.Text.ToString();
		Model.JianCheng=this.txtJianCheng.Text.ToString();
		Model.DianHua=this.txtDianHua.Text.ToString();
		Model.MobTel=this.txtMobTel.Text.ToString();
		Model.ChuanZhen=this.txtChuanZhen.Text.ToString();
		Model.URLStr=this.txtURLStr.Text.ToString();
		Model.EmailStr=this.txtEmailStr.Text.ToString();
		Model.DiQu=this.txtDiQu.Text.ToString();
		Model.YouBian=this.txtYouBian.Text.ToString();
		Model.Address=this.txtAddress.Text.ToString();
		Model.KaiHuHang=this.txtKaiHuHang.Text.ToString();
		Model.ZhangHao=this.txtZhangHao.Text.ToString();
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		Model.UserName=LCX.Common.PublicMethod.GetSessionValue("UserName");
		Model.TimeStr=DateTime.Now;
		
		Model.Add();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "�û���ӹ�Ӧ����Ϣ(" + this.txtSupplysName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "��Ӧ����Ϣ��ӳɹ���", "Supplys.aspx");
	}
}
