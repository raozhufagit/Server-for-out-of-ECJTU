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

public partial class Supply_SupplysView : System.Web.UI.Page
{
    public string GongYingShang="";

	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXSupplys Model = new LCX.BLL.LCXSupplys();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblSupplysName.Text=Model.SupplysName.ToString();
            GongYingShang = Model.SupplysName.ToString();
			this.lblSerils.Text=Model.Serils.ToString();
			this.lblJianCheng.Text=Model.JianCheng.ToString();
			this.lblDianHua.Text=Model.DianHua.ToString();
			this.lblMobTel.Text=Model.MobTel.ToString();
			this.lblChuanZhen.Text=Model.ChuanZhen.ToString();
			this.lblURLStr.Text=Model.URLStr.ToString();
			this.lblEmailStr.Text=Model.EmailStr.ToString();
			this.lblDiQu.Text=Model.DiQu.ToString();
			this.lblYouBian.Text=Model.YouBian.ToString();
			this.lblAddress.Text=Model.Address.ToString();
			this.lblKaiHuHang.Text=Model.KaiHuHang.ToString();
			this.lblZhangHao.Text=Model.ZhangHao.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			
			//дϵͳ��־
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "�û��鿴��Ӧ����Ϣ(" + this.lblSupplysName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
