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

public partial class Office_BookView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXBook Model = new LCX.BLL.LCXBook();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblBookName.Text=Model.BookName.ToString();
			this.lblBookSerils.Text=Model.BookSerils.ToString();
			this.lblSuoShuBuMen.Text=Model.SuoShuBuMen.ToString();
			this.lblBookType.Text=Model.BookType.ToString();
			this.lblAuother.Text=Model.Auother.ToString();
			this.lblISBN.Text=Model.ISBN.ToString();
			this.lblCoperStr.Text=Model.CoperStr.ToString();
			this.lblChuBanDate.Text=Model.ChuBanDate.ToString();
			this.lblCunFangDian.Text=Model.CunFangDian.ToString();
			this.lblShuLiang.Text=Model.ShuLiang.ToString();
			this.lblJiaGe.Text=Model.JiaGe.ToString();
			this.lblNeiRong.Text=Model.NeiRong.ToString();
			this.lblNowState.Text=Model.NowState.ToString();
			this.lblBackInfo.Text=Model.BackInfo.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			
			//дϵͳ��־
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "�û��鿴ͼ����Ϣ(" + this.lblBookName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
