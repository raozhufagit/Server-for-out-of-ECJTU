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

public partial class CooperationAgreement_LCXContractManageViewP : System.Web.UI.Page
{
    public string TitleStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXContractManage model = new LCX.BLL.LCXContractManage();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblContractNo.Text = model.ContractNo;
            this.lblContractName.Text = model.ContractName;
            TitleStr = model.ContractName;
            this.lblContractType.Text = model.ContractType;
            //this.HyperLink1.NavigateUrl = "TuXingJinDu.aspx?ProjectName=" + model.Title;
            this.lblDepartmentA.Text = model.DepartmentA;
            this.lblDepartmentB.Text = model.DepartmentB;
            this.lblSignatoryA.Text = model.SignatoryA;
            this.lblSignatoryB.Text = model.SignatoryB;
            this.lblSignTime.Text = model.SignTime.ToString();
            this.lblEndTime.Text = model.EndTime.ToString();
            this.lblWhetherSecrecy.Text = model.WhetherSecrecy.ToString();
            this.lblProject.Text = model.Project.ToString();
            this.lblAgreement.Text = model.Agreement.ToString();
            this.lblContractContent.Text = model.ContractContent;
            this.lblAttchment.Text = LCX.Common.PublicMethod.GetWenJian(model.Attchment, "../UploadFile/");

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看对外合作协议信息(" + this.lblContractName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}