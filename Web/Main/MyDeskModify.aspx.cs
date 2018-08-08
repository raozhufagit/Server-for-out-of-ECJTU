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

public partial class Main_MyDeskModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //绑定页面数据
            LCX.BLL.LCXUserDesk MyModel = new LCX.BLL.LCXUserDesk();
            MyModel.GetModel(int.Parse(LCX.DBUtility.DbHelperSQL.GetSHSLInt("select ID from LCXUserDesk where UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' and ModelName='" + Request.QueryString["ModelName"].ToString() + "'")));
            this.Label1.Text = MyModel.ModelName;
            this.TextBox1.Text = MyModel.LookNum.ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXUserDesk set LookNum=" + this.TextBox1.Text.Trim() + " where UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' and ModelName='"+this.Label1.Text.ToString()+"'");

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改桌面显示信息(" + this.Label1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "桌面显示设置修改成功！", "MyDesk.aspx");
    }
}
