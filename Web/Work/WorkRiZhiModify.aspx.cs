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

public partial class Work_WorkRiZhiModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //绑定页面数据
            LCX.BLL.LCXWork_Log Model = new LCX.BLL.LCXWork_Log();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.TextBox1.Text = Model.TitleStr;
            this.TxtContent.Text = Model.ContentStr;
            this.TextBox5.Text = Model.TypeStr;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXWork_Log Model = new LCX.BLL.LCXWork_Log();
        Model.TitleStr = this.TextBox1.Text;
        Model.ContentStr = this.TxtContent.Text;
        Model.TypeStr = this.TextBox5.Text.Trim();
        Model.ID = int.Parse(Request.QueryString["ID"].ToString());
        Model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        Model.Update();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改工作日志信息(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "工作日志修改成功！", "WorkRiZhi.aspx");
    }
}