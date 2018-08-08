using System;
using System.Data;
using System.Data.Linq;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Linq;

public partial class Sell_ReviceModify : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataEntityDataContext context = new DataEntityDataContext();
            LCXRecive Model = new LCXRecive();
            this.txtHeTongName.Attributes.Add("readonly", "true");
            this.txtQianYueKeHu.Attributes.Add("readonly", "true");
            Model = context.LCXRecive.SingleOrDefault(p => p.ID == int.Parse(Request.QueryString["ID"].ToString()));

            this.txtHeTongName.Text = Model.HeTongName.ToString();
            this.txtQianYueKeHu.Text = Model.QianYueKeHu.ToString();
            this.txtHeTongMiaoShu.Text = Model.HTJE.ToString();

            this.txtShengXiaoDate.Text = Model.TiXingDate.ToString().Replace(" 0:00:00", "");

            this.txtTiXingDate.Text = Model.DaoKuanDate.ToString().Replace(" 0:00:00", "");

            this.DZ.Value = Model.SFDK;
            this.txtBackInfo.Text = Model.BackInfo.ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        DataEntityDataContext context = new DataEntityDataContext();
        LCXRecive Model = new LCXRecive();
        Model = context.LCXRecive.SingleOrDefault(p => p.ID == int.Parse(Request.QueryString["ID"].ToString()));

        Model.ID = int.Parse(Request.QueryString["ID"].ToString());
        Model.HeTongName = this.txtHeTongName.Text.ToString();
        Model.QianYueKeHu = this.txtQianYueKeHu.Text.ToString();
        Model.HTJE = this.txtHeTongMiaoShu.Text.ToString();
        Model.TiXingDate = DateTime.Parse(this.txtShengXiaoDate.Text);
        Model.DaoKuanDate = DateTime.Parse(this.txtTiXingDate.Text);
        Model.BackInfo = this.txtBackInfo.Text.ToString();

        LCXYS ys = new LCXYS();
        ys = context.LCXYS.SingleOrDefault(p => p.FKID == Model.ID);
        ys.HeTongName = this.txtHeTongName.Text.ToString();
        ys.QianYueKeHu = this.txtQianYueKeHu.Text.ToString();
        ys.HTJE = this.txtHeTongMiaoShu.Text.ToString();
        ys.TiXingDate = DateTime.Parse(this.txtShengXiaoDate.Text);
        ys.DaoKuanDate = DateTime.Parse(this.txtTiXingDate.Text);
        ys.BackInfo = this.txtBackInfo.Text.ToString();
        ys.NowState = "F";

        context.SubmitChanges();
        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改收款计划信息(" + this.txtHeTongName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "收款计划信息修改成功！", "Revice.aspx");
    }
}
