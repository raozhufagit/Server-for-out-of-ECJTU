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

public partial class WorkFlow_YinZhangModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();

            LCX.BLL.LCXSeal MyModel = new LCX.BLL.LCXSeal();
            MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.HyperLink1.Text = MyModel.ImgPath;
            this.HyperLink1.NavigateUrl = "../UploadFile/" + MyModel.ImgPath;

            this.TextBox1.Text = MyModel.YinZhangName;
            this.TextBox2.Text= MyModel.YinZhangMiMa;            
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //判断名称是否唯一性
        if (LCX.Common.PublicMethod.IFExists("YinZhangName", "LCXSeal", int.Parse(Request.QueryString["ID"].ToString()), this.TextBox1.Text) == false)
        {
            LCX.Common.MessageBox.Show(this, "该印章名称已经存在！");
            return;
        }

        if (this.FileUpload1.FileName.Trim().Length > 0)
        {
            string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
            if (FileNameStr.Trim().Length > 0)
            {
                LCX.BLL.LCXSeal MyModel = new LCX.BLL.LCXSeal();
                MyModel.ID = int.Parse(Request.QueryString["ID"].ToString());
                MyModel.ImgPath = FileNameStr;
                MyModel.TimeStr = DateTime.Now;
                MyModel.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
                MyModel.YinZhangLeiBie = Request.QueryString["Type"].ToString();
                MyModel.YinZhangMiMa = this.TextBox2.Text;
                MyModel.YinZhangName = this.TextBox1.Text;
                MyModel.Update();

                //写系统日志
                LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
                MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
                MyRiZhi.DoSomething = "用户修改印章信息(" + this.TextBox1.Text + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                MyRiZhi.Add();

                LCX.Common.MessageBox.ShowAndRedirect(this, "印章信息修改成功！", "PublicSeal.aspx?Type=" + Request.QueryString["Type"].ToString());
            }
        }
        else
        {
            LCX.BLL.LCXSeal MyModel = new LCX.BLL.LCXSeal();
            MyModel.ID = int.Parse(Request.QueryString["ID"].ToString());
            MyModel.ImgPath =this.HyperLink1.Text;
            MyModel.TimeStr = DateTime.Now;
            MyModel.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyModel.YinZhangLeiBie = Request.QueryString["Type"].ToString();
            MyModel.YinZhangMiMa = this.TextBox2.Text;
            MyModel.YinZhangName = this.TextBox1.Text;
            MyModel.Update();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户修改印章信息(" + this.TextBox1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            LCX.Common.MessageBox.ShowAndRedirect(this, "印章信息修改成功！", "PublicSeal.aspx?Type=" + Request.QueryString["Type"].ToString());
        }
    }
}