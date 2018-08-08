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

public partial class DuiWaiFuwu_LCXInnovationPlatView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXInnovationPlat Model = new LCX.BLL.LCXInnovationPlat();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblPlatFormName.Text = Model.PlatFormName.ToString();
            this.lblManager.Text = Model.Manager.ToString();
            this.lblTeacherGroup.Text = Model.TeacherGroup.ToString();
            this.lblResearchFind.Text = Model.ResearchFind.ToString();
            this.lblTeamIntr.Text = Model.TeamIntr.ToString();
            this.lblServiceContent.Text = Model.ServiceContent.ToString();
            this.lblRemarks.Text = Model.Remarks.ToString();


        }
    }
  
}