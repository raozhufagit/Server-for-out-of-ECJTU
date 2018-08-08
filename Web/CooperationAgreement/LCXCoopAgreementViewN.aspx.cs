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

public partial class CooperationAgreement_LCXCoopAgreementViewN : System.Web.UI.Page
{
    public string TitleStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXCoopAgreement model = new LCX.BLL.LCXCoopAgreement();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblTitle.Text = model.Title;
            TitleStr = model.Title;
            this.HyperLink1.NavigateUrl = "TuXingJinDu.aspx?ProjectName=" + model.Title;
            this.lblDepartmentA.Text = model.DepartmentA;
            this.lblDepartmentB.Text = model.DepartmentB;
            this.lblSignatoryA.Text = model.SignatoryA;
            this.lblSignatoryB.Text = model.SignatoryB;
            this.lblContent.Text = model.Content;
            this.lblSignTime.Text = model.SignTime.ToString();
            this.lblAttchment.Text = LCX.Common.PublicMethod.GetWenJian(model.Attchment, "../UploadFile/");


            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看战略合作协议信息(" + this.lblTitle.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}