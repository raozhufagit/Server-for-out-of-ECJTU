using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScSeting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXScSeting MyModel = new LCX.BLL.LCXScSeting();
            this.txtdd_User.Text=MyModel.dd_User;
            this.txtsc_User.Text=MyModel.sc_User;
            this.txtsc_JUser.Text=MyModel.sc_JUser;
            this.txtsc_SUser.Text=MyModel.sc_SUser;
            this.txtjd_User.Text=MyModel.jd_User;
            this.txtjd_SUser.Text=MyModel.jd_SUser; 
            //设定按钮权限            
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|011M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXScSeting MyModel = new LCX.BLL.LCXScSeting();
        MyModel.dd_User=this.txtdd_User.Text.Trim();
        MyModel.sc_User =this.txtsc_User.Text.Trim();
        MyModel.sc_JUser =this.txtsc_JUser.Text.Trim();
        MyModel.sc_SUser=this.txtsc_SUser.Text.Trim();
        MyModel.jd_User = this.txtjd_User.Text.Trim();
        MyModel.jd_SUser = this.txtjd_SUser.Text.Trim();
        if (MyModel.Update() > 0)
        {
            LCX.Common.MessageBox.Show(this, "修改生产审核人员成功！");
            LCX.Common.MessageBox.Close(this);
        }
        else
        {
            LCX.Common.MessageBox.Show(this, "修改生产审核人员失败！");
            return;
        }
        

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "生产用户设置系统提醒参数";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
    }
}