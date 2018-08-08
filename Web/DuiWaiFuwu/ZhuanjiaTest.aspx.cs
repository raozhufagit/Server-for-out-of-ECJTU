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

public partial class DuiWaiFuwu_ZhuanjiaTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.ZhuanJia Model = new LCX.BLL.ZhuanJia();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtXingMing.Text = Model.XingMing.ToString();
            this.txtXueKe.Text = Model.XueKe.ToString(); 
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.ZhuanJia Model = new LCX.BLL.ZhuanJia();

        Model.ID = int.Parse(Request.QueryString["ID"].ToString());
        Model.XingMing = this.txtXingMing.Text.ToString();
        Model.XueKe = this.txtXueKe.Text.ToString(); 
        Model.Update();

        //写系统日志
       
         LCX.Common.MessageBox.ShowAndRedirect(this, "专家信息修改成功！", "ZhuanJia.aspx");
    }
}