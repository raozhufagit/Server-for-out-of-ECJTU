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

public partial class Project_ShouKuanView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXShouKuan model = new LCX.BLL.LCXShouKuan();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblProjectName.Text = model.ProjectName;
            this.lblProjectSerils.Text = model.ProjectSerils;
            this.lblJieDuanName.Text = model.JieDuanName;
            this.lblShouKuanE.Text = model.ShouKuanE;
            this.lblFaPiaoHao.Text = model.FaPiaoHao;
            this.lblShouKuanDate.Text = model.ShouKuanDate;
            this.lblDaoKuanDate.Text = model.DaoKuanDate;
            this.lblShengYuE.Text = model.ShengYuE;
            this.lblUserName.Text = model.UserName;
            this.lblTimeStr.Text = model.TimeStr.ToString();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看收款信息(" + this.lblProjectName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}
