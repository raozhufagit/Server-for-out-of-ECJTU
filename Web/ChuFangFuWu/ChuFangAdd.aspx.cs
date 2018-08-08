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

public partial class ChuFangFuWu_ChuFangAdd : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            this.EnteringPerson.Text= LCX.Common.PublicMethod.GetSessionValue("UserName");
            this.VisitDate.Text = DateTime.Now.Date.ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        //出访信息填写
        LCX.BLL.OutVisit Model = new LCX.BLL.OutVisit();
        Model.VisitGoal=this.VisitGoal.Text.ToString();
        Model.VisitDate = DateTime.Parse(this.VisitDate.Text);
        Model.VisitLenth = this.VisitLenth.Text.ToString();
        Model.LeadPerson = this.LeadPerson.Text.ToString();
        Model.FlowPerson = this.FlowPerson.Text.ToString();
        Model.VisitDepartment = this.VisitDepartment.Text.ToString();
        Model.EnteringPerson = this.EnteringPerson.Text.ToString();
        Model.RelationCOA = this.RelationCOA.Text.ToString();
        Model.RelationCoPro =this.RelationCoPro.Text.ToString();
        Model.Otherexplain = this.Otherexplain.Text.ToString();
        Model.ApprovalPerson = "admin";
        //LCX.Common.MessageBox.Show(this, Model.Add().ToString());
        if (Model.Add()==1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }
       
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "提出了【" + Model.LeadPerson + "】出访申请", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()), HttpContext.Current.Request.Url.Host + "/ChuFang/OutVisitCheck?ID=" + Model.ID);//

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
       // MyRiZhi.DoSomething = "用户添加出访信息(" + this.txtLingDuigh.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "出访信息添加成功！", "ChuFang.aspx?TypeStr=我的出访");
    }


 }
