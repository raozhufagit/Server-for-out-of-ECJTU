using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DuiWaiFuwu_LCXScientificResearchView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        LCX.Common.PublicMethod.CheckSession();

        LCX.BLL.LCXScientificResearch Model = new LCX.BLL.LCXScientificResearch();
        Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
        this.lblScientificName.Text = Model.ScientificName.ToString();
        this.lblScientificNo.Text = Model.ScientificNo.ToString();
        this.lblScientificType.Text = Model.ScientificType.ToString();
        this.lblHostPerson.Text = Model.HostPerson.ToString();
        this.lblStartTime.Text = Model.StartTime.ToString();
        this.lblEndTime.Text = Model.EndTime.ToString();
        this.lblParticipants.Text = Model.Participants.ToString();
        this.lblScientificDir.Text = Model.ScientificDir.ToString();
        this.lblResearchFind.Text = Model.ResearchFind.ToString();
        this.lblScientificStates.Text = Model.ScientificStates.ToString();
        this.lblRemarks.Text = Model.Remarks.ToString();
        this.lblApplicationDir.Text = Model.ApplicationDir.ToString();
        this.lblRemarks.Text = Model.Remarks.ToString();
        this.lblAttachment.Text = LCX.Common.PublicMethod.GetWenJian(Model.Attachment, "../UploadFile/");



        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户查看科研信息(" + this.lblScientificName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
    }
}