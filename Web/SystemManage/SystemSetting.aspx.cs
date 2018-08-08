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

public partial class SystemManage_SystemSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //设定按钮权限
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|089M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));

            LCX.BLL.LCXSystem_Set MyModel = new LCX.BLL.LCXSystem_Set();
            MyModel.GetModel();
            TextBox1.Text = MyModel.FileType.Replace("||",",").Replace("|","");            
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXSystem_Set MyModel = new LCX.BLL.LCXSystem_Set();
        MyModel.FileType = "|"+TextBox1.Text.Trim().Replace(",","||")+"|";
        MyModel.Update();
        LCX.Common.MessageBox.Show(this, "修改系统参数成功！");

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户设置系统参数";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
    }
}