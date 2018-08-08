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


public partial class CooperationAgreement_LCXOutagreeImpleView : System.Web.UI.Page
{
    //public string TitleStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXOutagreeImple model = new LCX.BLL.LCXOutagreeImple();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblOutagreeName.Text = model.OutagreeName;
            //TitleStr = model.Title;
            //this.HyperLink1.NavigateUrl = "TuXingJinDu.aspx?ProjectName=" + model.Title;
            this.lblPhaseName.Text = model.PhaseName;
            this.lblStartTime.Text = model.StartTime.ToString();
            this.lblEndTime.Text = model.EndTime.ToString();
            this.lblCompletionDegree.Text = model.CompletionDegree;
            this.lblChargePerson.Text = model.ChargePerson;
            this.lblSubmitPerson.Text = model.SubmitPerson;
            this.lblSubmitTime.Text = model.SubmitTime.ToString();
            this.lblRemarks.Text = model.Remarks;
            this.lblAttachment.Text = LCX.Common.PublicMethod.GetWenJian(model.Attachment, "../UploadFile/");


            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看对外合作进度信息(" + this.lblPhaseName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}