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

public partial class VisitingManage_LCXVisitingView : System.Web.UI.Page
{
    public string OutVisitStr = "";
    public string InVisitUnit = "";//来访单位
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXVisitingManagement model = new LCX.BLL.LCXVisitingManagement();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblInVisitUnit.Text = model.InVisitUnit;
            this.lblVisitTitle.Text = model.VisitingTitle;
            OutVisitStr = model.VisitingTitle;
            InVisitUnit = model.InVisitUnit;
            //this.HyperLink1.NavigateUrl = "TuXingJinDu.aspx?ProjectName=" + model.InVisitUnit;
            this.lblInVisitGroup.Text = model.InVisitGroup;
            this.lblVisitPurpose.Text = model.VisitPurpose;
            this.lblReceptionist.Text = model.Receptionist;
            this.lblWorkReport.Text = model.WorkReport;
            this.lblWorkProgress.Text = model.WorkProgress;
            this.lblVisitTime.Text = model.VisitTime.ToString();
            this.lblAttchment.Text = LCX.Common.PublicMethod.GetWenJian(model.Attchment, "../UploadFile/");
            

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看来访信息(" + this.lblInVisitUnit.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}
