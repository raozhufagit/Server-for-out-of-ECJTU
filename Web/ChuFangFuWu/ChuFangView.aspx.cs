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

public partial class ChuFangFuWu_ChuFang_View : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.OutVisit Model = new LCX.BLL.OutVisit();///
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.VisitDate.Text = Model.VisitDate.ToString();
            this.VisitLenth.Text = Model.VisitLenth.ToString();
            this.LeadPerson.Text = Model.LeadPerson.ToString();
            this.FlowPerson.Text = Model.FlowPerson.ToString();
            this.VisitDepartment.Text = Model.VisitDepartment.ToString();
            this.VisitGoal.Text = Model.VisitGoal.ToString();
            this.VisitCost.Text = Model.VisitCost.ToString();
            this.Otherexplain.Text = Model.Otherexplain.ToString();
            this.RelationCOA.Text = Model.RelationCOA.ToString();
            this.RelationCoProject.Text = Model.RelationCoPro.ToString();
            this.EnteringPerson.Text = Model.EnteringPerson.ToString();
            this.ApprovalOpinion.Text = Model.ApprovalOpinion.ToString();
            this.ApprovalPerson.Text = Model.ApprovalPerson.ToString();
            this.VisitOtherResult.Text = Model.VisitOtherResult.ToString();
            this.VisitReportDate.Text = Model.VisitReportDate.ToString();
            this.VisitResultCopro.Text = Model.VisitResultCopro.ToString();
            this.VisitResultCOA.Text = Model.VisitResultCOA.ToString();

        }
    }


    
}