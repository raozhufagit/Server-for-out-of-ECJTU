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

public partial class Financial_ReimburseModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXReimburse Model = new LCX.BLL.LCXReimburse();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtHeTongName.Text = Model.HeTongName.ToString();
            this.txtUserName.Text = Model.UserName.ToString();
            this.txtQianYueKeHu.Text = Model.QianYueKeHu.ToString();
            this.txtReimburseContent.Text = Model.ReimburseContent.ToString();
            this.txtApplyTime.Text = Model.ApplyTime.ToString();
            this.txtMemo.Text = Model.Memo.ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXReimburse Model = new LCX.BLL.LCXReimburse();
        //Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
        Model.ID = int.Parse(Request.QueryString["ID"].ToString());
        Model.UserName = this.txtUserName.Text.ToString();
        Model.HeTongName = this.txtHeTongName.Text.ToString();
        Model.QianYueKeHu = this.txtQianYueKeHu.Text.ToString();
        Model.ReimburseContent = this.txtReimburseContent.Text.ToString();
        Model.ApplyTime = this.txtApplyTime.Text.ToString();
        Model.Memo = this.txtMemo.Text.ToString();

        Model.Update();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改报销单信息(" + this.txtReimburseContent.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "报销单信息修改成功！", "Reimburse.aspx");
    }
    
}
