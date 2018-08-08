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


public partial class ChuFangFuWu_OutVisitCheck : System.Web.UI.Page
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
            this.ApprovalPerson.Text = Model.EnteringPerson.ToString();// Model.ApprovalPerson.ToString();
        }
       
    }

    protected void subPass(object sender, EventArgs e)
    {
        LCX.BLL.OutVisit model = new LCX.BLL.OutVisit();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
        //model.ApprovalPerson = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.ApprovalDate = DateTime.Now;
        if (model.Visitstat == 1)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的订单信息不能修改！", "ChuFang.aspx ? TypeStr = 全部出访");
            return;
        }
        model.Visitstat = 1;
        model.ApprovalOpinion = this.ApprovalOpinion.Text.ToString();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }
        //发送通知
        //SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "审批了你的出访申请【" + model.Sc_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()), HttpContext.Current.Request.Url.Host + "/ScManufact/ScView.aspx?ID=" + model.ID);

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.ApprovalPerson + "审批了(" + model.LeadPerson +model.VisitDate+ ")出访(" + model.VisitDepartment + ")的信息";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Update();
        LCX.Common.MessageBox.ShowAndRedirect(this, "出访申请审批成功！", "ChuFang.aspx?TypeStr=全部出访");
    }
    protected void subRefuse(object sender, EventArgs e)
    {
        LCX.BLL.OutVisit model = new LCX.BLL.OutVisit();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
       // model.ApprovalPerson = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.ApprovalDate = DateTime.Now;
        if (model.Visitstat == 1)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的订单信息不能修改！", "ChuFang.aspx?TypeStr=全部出访");
            return;
        }
        model.Visitstat = 2;
        model.ApprovalOpinion = this.ApprovalOpinion.Text.Trim();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }
        //发送通知
        //SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "拒绝审批了生产订单【" + model.Sc_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()), HttpContext.Current.Request.Url.Host + "/ScManufact/ScView.aspx?ID=" + model.ID);

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.ApprovalPerson + "拒绝了(" + model.LeadPerson + model.VisitDate + ")出访(" + model.VisitDepartment + ")的信息";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Update();
        LCX.Common.MessageBox.ShowAndRedirect(this, "拒绝审批生产订单成功！", "ChuFang.aspx?TypeStr=全部出访");
    }
}