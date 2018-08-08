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

public partial class Project_PinShenAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            this.txtPingShenTime.Text = DateTime.Now.Date.ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXPinShen model = new LCX.BLL.LCXPinShen();
        string proName= Request.QueryString["ProjectName"].ToString();
        if (proName!=" ")
        {
            this.txtProjectName.Text = proName;
        }
        model.ProjectName = this.txtProjectName.Text;
        model.ProjectSerils = this.txtProjectSerils.Text;
        model.PingShenTime = this.txtPingShenTime.Text;
        model.PingShenJieGuo = this.txtPingShenJieGuo.Text;        
        model.BachInfo = this.txtBachInfo.Text;
        model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.TimeStr = DateTime.Now;        
        model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加评审信息(" + this.txtProjectName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "评审信息添加成功！", "PingShen.aspx?ProjectName="+Request.QueryString["ProjectName"].ToString());
    }

    protected void txtPingShenTime_TextChanged(object sender, EventArgs e)
    {

    }
}