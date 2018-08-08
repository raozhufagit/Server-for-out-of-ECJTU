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

public partial class Personal_SystemTiXing : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXTiXing MyModel = new LCX.BLL.LCXTiXing();
            MyModel.GetModel(int.Parse(LCX.Common.PublicMethod.GetSessionValue("UserID")));
            this.DropDownList1.SelectedValue = MyModel.TiXingTime;
            this.DropDownList2.SelectedValue = MyModel.IfTiXing;

            //设定按钮权限            
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|011M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXTiXing MyModel = new LCX.BLL.LCXTiXing();
        MyModel.ID = int.Parse(LCX.Common.PublicMethod.GetSessionValue("UserID"));
        MyModel.TiXingTime = this.DropDownList1.SelectedItem.Value.ToString();
        MyModel.IfTiXing = this.DropDownList2.SelectedItem.Value.ToString();
        MyModel.Update();
        LCX.Common.MessageBox.Show(this, "修改系统提醒参数成功！");

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户设置系统提醒参数";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
    }
}