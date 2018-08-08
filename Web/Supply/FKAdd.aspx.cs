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

public partial class Supply_FKAdd : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.txtHeTongName.Attributes.Add("readonly", "true");
            this.txtQianYueKeHu.Attributes.Add("readonly", "true");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        DataEntityDataContext context = new DataEntityDataContext();
        LCXRecive Model = new LCXRecive();
        
        Model.HeTongName = this.txtHeTongName.Text.ToString();
        Model.QianYueKeHu = this.txtQianYueKeHu.Text.ToString();
        Model.HTJE = this.txtHeTongMiaoShu.Text.ToString();
        Model.TiXingDate = DateTime.Parse(this.txtShengXiaoDate.Text);
        Model.DaoKuanDate = DateTime.Parse(this.txtTiXingDate.Text);
        Model.CreateTime = DateTime.Now;
        Model.CreateUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        Model.BackInfo = this.txtBackInfo.Text.ToString();
        Model.SFDK = "否";
        Model.NowState = "F";
        context.LCXRecive.InsertOnSubmit(Model);
        context.SubmitChanges();

        LCXYS ys = new LCXYS();
        ys.FKID = Model.ID;
        ys.HeTongName = this.txtHeTongName.Text.ToString();
        ys.QianYueKeHu = this.txtQianYueKeHu.Text.ToString();
        ys.HTJE = this.txtHeTongMiaoShu.Text.ToString();
        ys.TiXingDate = DateTime.Parse(this.txtShengXiaoDate.Text);
        ys.DaoKuanDate = DateTime.Parse(this.txtTiXingDate.Text);
        ys.CreateTime = DateTime.Now;
        ys.CreateUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        ys.BackInfo = this.txtBackInfo.Text.ToString();
        ys.SFDK = "否";
        ys.NowState = "F";
        context.LCXYS.InsertOnSubmit(ys);
        context.SubmitChanges();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加付款计划信息(" + this.txtHeTongName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "付款计划信息添加成功！", "FK.aspx");
    }





}
