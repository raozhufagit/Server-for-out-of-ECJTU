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

public partial class Project_BaoXiaoAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXBaoXiao model = new LCX.BLL.LCXBaoXiao();
        model.ProjectName = this.txtProjectName.Text;
        model.FeiYongType = this.txtFeiYongType.Text;
        model.ShenQingRen = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.ShenPiRen = this.txtShenPiRen.Text;
        model.ShenQingContent = this.txtShenQingContent.Text;
        model.JinE = this.txtJinE.Text;
        model.StateNow = "待批";
        model.Username = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.ShenQingTime = DateTime.Now; ;        
        model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加报销申请(" + this.txtProjectName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "报销申请添加成功！", "BaoXiaoShenQing.aspx?ProjectName=" + Request.QueryString["ProjectName"].ToString());
    }
}