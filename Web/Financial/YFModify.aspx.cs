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

public partial class Financial_YFModify : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataEntityDataContext context = new DataEntityDataContext();
            LCXYS Model = new LCXYS();
            Model = context.LCXYS.SingleOrDefault(p => p.ID == int.Parse(Request.QueryString["ID"].ToString()));
            this.txtHeTongName.Attributes.Add("readonly", "true");
            this.txtQianYueKeHu.Attributes.Add("readonly", "true");
            this.txtHeTongMiaoShu.Attributes.Add("readonly", "true");
            this.txtShengXiaoDate.Attributes.Add("readonly", "true");
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
        LCXYS Model = new LCXYS();
        Model = context.LCXYS.SingleOrDefault(p => p.ID == int.Parse(Request.QueryString["ID"].ToString()));
        Model.SFDK = this.DZ.Value;
        LCXRecive model2 = context.LCXRecive.SingleOrDefault(p => p.ID == Model.FKID);
        model2.SFDK = this.DZ.Value;
        context.SubmitChanges();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改应付信息(" + this.txtHeTongName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "应付信息修改成功！", "YF.aspx");
    }
}
