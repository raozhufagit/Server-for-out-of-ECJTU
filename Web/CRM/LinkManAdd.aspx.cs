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

public partial class CRM_LinkManAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            this.txtCustomName.Text = Request.QueryString["CustomName"].ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXLinkMan model = new LCX.BLL.LCXLinkMan();
        model.CustomName = this.txtCustomName.Text;
        model.NameStr = this.txtNameStr.Text;
        model.Sex = this.txtSex.Text;
        model.BirthDay = this.txtBirthDay.Text;
        model.SuoChuJiaoSe = this.txtSuoChuJiaoSe.Text;
        model.ZhiWu = this.txtZhiWu.Text;
        model.PeiOu = this.txtPeiOu.Text;
        model.ZiNv = this.txtZiNv.Text;
        model.DanWieDianHua = this.txtDanWieDianHua.Text;
        model.DanWeiChuanZhen = this.txtDanWeiChuanZhen.Text;
        model.JiaTingZhuZhi = this.txtJiaTingZhuZhi.Text;
        model.JiaTingYouBian = this.txtJiaTingYouBian.Text;
        model.JiaTingDianHua = this.txtJiaTingDianHua.Text;
        model.ShouJi = this.txtShouJi.Text;
        model.XiaoLingTong = this.txtXiaoLingTong.Text;
        model.Email = this.txtEmail.Text;
        model.QQ = this.txtQQ.Text;
        model.Msn = this.txtMsn.Text;
        model.BackInfo = this.txtBackInfo.Text;
        model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.TimeStr = DateTime.Now;
        model.IFShare = this.txtIFShare.Text;
        model.CusBakA = this.txtCusBakA.Text;
        model.CusBakB = this.txtCusBakB.Text;
        model.CusBakC = this.txtCusBakC.Text;
        model.CusBakD = this.txtCusBakD.Text;
        model.CusBakE = this.txtCusBakE.Text;
        model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加联系人信息(" + this.txtCustomName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "联系人信息添加成功！", "MyCustomLinkMan.aspx?CustomName=" + Request.QueryString["CustomName"].ToString());        
    }
}