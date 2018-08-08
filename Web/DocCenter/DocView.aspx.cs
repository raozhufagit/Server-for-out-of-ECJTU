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

public partial class DocCenter_DocView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();

            LCX.BLL.LCXFileList MyModel = new LCX.BLL.LCXFileList();
            MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.Label8.Text = MyModel.FileName;
            //this.HyperLink1.Text = MyModel.FileName;
            //this.HyperLink1.NavigateUrl = "../UploadFile/" + MyModel.FilePath;
            this.Label7.Text = LCX.Common.PublicMethod.GetWenJian(MyModel.FilePath, "../UploadFile/");

            this.Label1.Text = MyModel.BianHao;
            this.Label6.Text = MyModel.BackInfo;

            this.Label2.Text = MyModel.DaXiao.ToString();
            this.Label3.Text = MyModel.ShangChuanTime.ToString();
            this.Label4.Text = MyModel.UserName;
            this.Label5.Text = MyModel.FileType;

            this.Label9.Text = MyModel.CanView;
            this.Label10.Text = MyModel.CanAdd;
            this.Label11.Text = MyModel.CanMod;
            this.Label12.Text = MyModel.CanDel;

            
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看文件信息(" + this.Label8.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}
