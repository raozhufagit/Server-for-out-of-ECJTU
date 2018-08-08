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

public partial class TalkRoom_SettingConfig : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.BLL.LCXTalkSetting MyModel = new LCX.BLL.LCXTalkSetting();
            MyModel.GetModel();
            TextBox1.Text = MyModel.TalkName;

            //设定按钮权限
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|119M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXTalkSetting MyModel = new LCX.BLL.LCXTalkSetting();
        MyModel.TalkName =TextBox1.Text.Trim();
        MyModel.Update();
        LCX.Common.MessageBox.Show(this, "修改聊天室参数成功！");

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户设置聊天室参数";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
    }
}