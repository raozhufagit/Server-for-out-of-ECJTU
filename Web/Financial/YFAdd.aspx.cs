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

public partial class Financial_YFAdd : System.Web.UI.Page
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
        DataEntityDataContext context = new DataEntityDataContext();
        LCXYS Model = new LCXYS();

        Model.HeTongName = this.txtHeTongName.Text.ToString();
        Model.QianYueKeHu = this.txtQianYueKeHu.Text.ToString();
        Model.HTJE = this.txtHeTongMiaoShu.Text.ToString();
        Model.TiXingDate = DateTime.Parse(this.txtShengXiaoDate.Text);
        Model.DaoKuanDate = DateTime.Parse(this.txtTiXingDate.Text);
        Model.CreateTime = DateTime.Now;
        Model.CreateUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        Model.BackInfo = this.txtBackInfo.Text.ToString();
        Model.SFDK = this.DZ.Value;
        Model.NowState = "F";
        context.LCXYS.InsertOnSubmit(Model);
        context.SubmitChanges();

        //дϵͳ��־
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "�û����Ӧ���ƻ���Ϣ(" + this.txtHeTongName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "Ӧ����Ϣ��ӳɹ���", "YF.aspx");
    }





}
