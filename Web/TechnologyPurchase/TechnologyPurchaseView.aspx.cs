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

public partial class TechnologyPurchase_TechnologyPurchaseView : System.Web.UI.Page
{
    public string CustomNameStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
            LCX.BLL.TechnologyPurchase model = new LCX.BLL.TechnologyPurchase();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.TechnologyName.Text = model.TechnologyName;
            this.TechnologyType.Text = model.TechnologyType;
            this.PubCompany.Text = model.PubCompany;
            this.RequiredProfession.Text = model.RequiredProfession;
            this.ContactPerson.Text = model.ContactPerson;
            this.ContactEmail.Text = model.ContactEmail;
            this.ContactTel.Text = model.ContactTel;
            this.TechnologyDetail.Text = model.TechnologyDetail;
            this.Push.Text = model.Push;
            this.BeginTime.Text = model.BeginTime;
            this.EndTime.Text = model.EndTime;
            this.Attachment.Text = model.Attachment;
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看技术求购信息(" + this.TechnologyName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}
