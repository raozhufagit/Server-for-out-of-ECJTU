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

public partial class DocFile_TiKuView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXQuestion Model = new LCX.BLL.LCXQuestion();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblTitleStr.Text=Model.TitleStr.ToString();
			this.lblItemsA.Text=Model.ItemsA.ToString();
			this.lblItemsB.Text=Model.ItemsB.ToString();
			this.lblItemsC.Text=Model.ItemsC.ToString();
			this.lblItemsD.Text=Model.ItemsD.ToString();
			this.lblItemsE.Text=Model.ItemsE.ToString();
			this.lblItemsF.Text=Model.ItemsF.ToString();
			this.lblItemsG.Text=Model.ItemsG.ToString();
			this.lblItemsH.Text=Model.ItemsH.ToString();
			this.lblAnswerStr.Text=Model.AnswerStr.ToString();

            //判断题目类型，然后设置Panel的显示与否
            if (Request.QueryString["FenLeiStr"].ToString() == "判断题")
            {
                this.Panel2.Visible = false;
                this.Panel1.Visible = true;
            }
            else if (Request.QueryString["FenLeiStr"].ToString() == "填空题")
            {
                this.Panel1.Visible = false;
                this.Panel2.Visible = false;
            }
            else if (Request.QueryString["FenLeiStr"].ToString() == "简答题")
            {
                this.Panel1.Visible = false;
                this.Panel2.Visible = false;
            }
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户查看题库管理信息(" + this.lblTitleStr.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
