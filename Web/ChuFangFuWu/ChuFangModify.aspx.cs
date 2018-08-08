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

public partial class ChuFangFuWu_ChuFangModify : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.OutVisit Model = new LCX.BLL.OutVisit();///
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.VisitGoal.Text=Model.VisitGoal.ToString();
            this.VisitDate.Text = Model.VisitDate.ToString();//DateTime.Parse(Model.VisitDate);
            this.VisitLenth.Text = Model.VisitLenth.ToString();
            this.LeadPerson.Text = Model.LeadPerson.ToString();
            this.FlowPerson.Text = Model.FlowPerson.ToString();
            this.VisitDepartment.Text = Model.VisitDepartment.ToString();
            this.VisitCost.Text = Model.VisitCost.ToString();
            this.Otherexplain.Text=Model.Otherexplain.ToString();
            this.RelationCOA.Text=Model.RelationCOA.ToString();
            this.RelationCoPro.Text = Model.RelationCoPro.ToString();
            this.EnteringPerson.Text = Model.EnteringPerson.ToString();
           

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

        LCX.BLL.OutVisit Model = new LCX.BLL.OutVisit();
        Model.ID = int.Parse(Request.QueryString["ID"].ToString());
        Model.VisitGoal = this.VisitGoal.Text.ToString();
        Model.VisitDate = DateTime.Parse(this.VisitDate.Text);
        Model.VisitLenth = this.VisitLenth.Text.ToString();
        Model.LeadPerson = this.LeadPerson.Text.ToString();
        Model.FlowPerson = this.FlowPerson.Text.ToString();
        Model.VisitDepartment = this.VisitDepartment.Text.ToString();
        Model.VisitCost = this.VisitCost.Text.ToString();
        Model.EnteringPerson = this.EnteringPerson.Text.ToString();
        Model.RelationCOA = this.RelationCOA.Text.ToString();
        Model.RelationCoPro = this.RelationCoPro.Text.ToString();
        Model.Otherexplain = this.Otherexplain.Text.ToString();
        Model.Update();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改(" + this.LeadPerson.Text + ")领队出访(" + this.VisitDepartment .Text + ")信息";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "出访信息修改成功！", "ChuFang.aspx?TypeStr=我的出访");
    }
   
}
