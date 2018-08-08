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

public partial class Car_CarBaoXianModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXCarBX Model = new LCX.BLL.LCXCarBX();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtCarName.Text=Model.CarName.ToString();
			this.txtFeiYongName.Text=Model.FeiYongName.ToString();
			this.txtProjectName.Text=Model.ProjectName.ToString();
			this.txtBaoXianPrice.Text=Model.BaoXianPrice.ToString();
			this.txtBaoXianDate.Text=Model.BaoXianDate.ToString();
			this.txtTiXingDate.Text=Model.TiXingDate.ToString();
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXCarBX Model = new LCX.BLL.LCXCarBX();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.CarName=this.txtCarName.Text.ToString();
		Model.FeiYongName=this.txtFeiYongName.Text.ToString();
		Model.ProjectName=this.txtProjectName.Text.ToString();
		Model.BaoXianPrice=this.txtBaoXianPrice.Text.ToString();
		Model.BaoXianDate=this.txtBaoXianDate.Text.ToString();
		Model.TiXingDate=this.txtTiXingDate.Text.ToString();
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		
		Model.Update();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "�û��޸ĳ������շ�����Ϣ(" + this.txtCarName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "�������շ�����Ϣ�޸ĳɹ���", "CarBaoXian.aspx");
	}

    protected void txtBaoXianDate_TextChanged(object sender, EventArgs e)
    {

    }

    protected void txtTiXingDate_TextChanged(object sender, EventArgs e)
    {

    }
}
