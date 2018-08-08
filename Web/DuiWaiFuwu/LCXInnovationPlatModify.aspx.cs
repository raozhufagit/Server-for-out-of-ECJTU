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

public partial class DuiWaiFuwu_LCXInnovationPlatModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXInnovationPlat Model = new LCX.BLL.LCXInnovationPlat();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtPlatFormName.Text = Model.PlatFormName.ToString();
            this.txtManager.Text = Model.Manager.ToString();
            this.txtTeacherGroup.Text = Model.TeacherGroup.ToString();
            this.txtResearchFind.Text = Model.ResearchFind.ToString();
            this.txtTeamIntr.Text = Model.TeamIntr.ToString();
            this.txtServiceContent.Text = Model.ServiceContent.ToString();
            this.txtRemarks.Text = Model.Remarks.ToString();


        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXInnovationPlat Model = new LCX.BLL.LCXInnovationPlat();

        Model.PlatFormName = this.txtPlatFormName.Text.ToString();
        Model.Manager = this.txtManager.Text.ToString();
        Model.TeacherGroup = this.txtTeacherGroup.Text.ToString();
        Model.ResearchFind = this.txtResearchFind.Text.ToString();
        Model.TeamIntr = this.txtTeamIntr.Text.ToString();
        Model.ServiceContent = this.txtServiceContent.Text.ToString();
        Model.Remarks = this.txtRemarks.Text.ToString();
        Model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改创新平台信息(" + this.txtPlatFormName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "创新平台信息修改成功！", "LCXInnovationPlat.aspx");
    }
}