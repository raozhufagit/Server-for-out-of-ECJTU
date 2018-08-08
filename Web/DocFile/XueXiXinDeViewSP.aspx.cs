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

public partial class DocFile_XueXiXinDeView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXStudyXinDe Model = new LCX.BLL.LCXStudyXinDe();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblXinDeTitle.Text=Model.XinDeTitle.ToString();
			this.lblXinDeContent.Text=Model.XinDeContent.ToString();
			this.lblFuJianStr.Text=LCX.Common.PublicMethod.GetWenJian(Model.FuJianStr.ToString(),"../UpLoadFile/");
			this.TextBox1.Text=Model.ShenPiContent.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户查看学习心得信息(" + this.lblXinDeTitle.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
    protected void Button1_Click(object sender, EventArgs e)
    {
        LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXStudyXinDe set ShenPiContent='" + this.TextBox1.Text.Trim() + "' where ID=" + Request.QueryString["ID"].ToString());
        LCX.Common.MessageBox.ShowAndRedirect(this, "签注意见完成！", "XueXiXinDeOK.aspx");
    }
}
