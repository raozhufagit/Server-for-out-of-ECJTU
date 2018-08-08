using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DuiWaiFuwu_LCXScientificResearchCheck : System.Web.UI.Page
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

        if (Request.UrlReferrer != null)
        {
            ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
        }
        LCX.Common.PublicMethod.CheckSession();
        if (Request.QueryString["ID"] == null)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！", ViewState["UrlReferrer"].ToString());
            return;
        }
        //获取传过来的ID值
        int id = 9;
        try
        {
            id = Int32.Parse(Request.QueryString["ID"].ToString());
        }
        catch (Exception ex)
        {

            LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！", "LCXScientificResearch.aspx");
            return;
        }
        

       
    }
    protected void subPass(object sender, EventArgs e)
    {
        LCX.BLL.LCXScientificResearch model = new LCX.BLL.LCXScientificResearch();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        if (model.States == 0 || String.Compare(model.States.ToString(), " ") == 0)
        {

        }
        else
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的科研信息不需再审核！", "LCXScientificResearch.aspx");
            return;
        }


        string CheckUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.ID = int.Parse(Request.QueryString["ID"].ToString());
        //model.CheckAdvision = this.txtCheckAdvision.Text;
        //model.CheckTime = DateTime.Now;
        model.States = 1;
        //model.Update();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }

        //发送通知
        //SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "审批了生产订单【" + model.Jd_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = CheckUser + "审批了专家信息(" + model.ScientificName + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "科研信息审批成功！", "LCXScientificResearch.aspx");
    }
    protected void subRefuse(object sender, EventArgs e)
    {
        LCX.BLL.LCXScientificResearch model = new LCX.BLL.LCXScientificResearch();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        if (model.States == 0 || String.Compare(model.States.ToString(), " ") == 0)
        {

        }
        else
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的科研信息不需再审核！", "LCXScientificResearch.aspx");
            return;
        }

        string CheckUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.ID = int.Parse(Request.QueryString["ID"].ToString());
        //model.CheckAdvision = this.txtCheckAdvision.Text;
        //model.CheckTime = DateTime.Now;
        model.States = 2;
        // model.Update();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }

        //发送通知
        //SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "拒绝了生产订单【" + model.Jd_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = CheckUser + "拒绝了科研审核信息(" + model.ScientificName + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "科研审核拒绝成功！", "LCXScientificResearch.aspx");
    }
}