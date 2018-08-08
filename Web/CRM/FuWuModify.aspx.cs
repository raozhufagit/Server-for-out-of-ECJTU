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

public partial class CRM_FuWuModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXCustomFuWu model = new LCX.BLL.LCXCustomFuWu();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtCustomName.Text = model.CustomName;
            this.txtFuWuTitle.Text = model.FuWuTitle;
            this.txtFuWuType.Text = model.FuWuType;
            this.txtFuWuResult.Text = model.FuWuResult;
            this.txtFuWuTime.Text = model.FuWuTime;
            this.Label1.Text = model.UserName;
            this.Label2.Text = model.TimeStr.ToString();
            this.txtIFShare.Text = model.IFShare;
            this.txtCusBakA.Text = model.CusBakA;
            this.txtCusBakB.Text = model.CusBakB;
            this.txtCusBakC.Text = model.CusBakC;
            this.txtCusBakD.Text = model.CusBakD;
            this.txtCusBakE.Text = model.CusBakE;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXCustomFuWu model = new LCX.BLL.LCXCustomFuWu();
        model.ID = int.Parse(Request.QueryString["ID"].ToString());
        model.CustomName = this.txtCustomName.Text;
        model.FuWuTitle = this.txtFuWuTitle.Text;
        model.FuWuType = this.txtFuWuType.Text;
        model.FuWuResult = this.txtFuWuResult.Text;
        model.FuWuTime = this.txtFuWuTime.Text;
        model.UserName = this.Label1.Text;
        model.TimeStr = DateTime.Parse(this.Label2.Text);
        model.IFShare = this.txtIFShare.Text;
        model.CusBakA = this.txtCusBakA.Text;
        model.CusBakB = this.txtCusBakB.Text;
        model.CusBakC = this.txtCusBakC.Text;
        model.CusBakD = this.txtCusBakD.Text;
        model.CusBakE = this.txtCusBakE.Text;
        model.Update();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改服务记录(" + this.txtCustomName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "服务记录信息修改成功！", "MyCustomService.aspx?CustomName=" + Request.QueryString["CustomName"].ToString());
    }
}