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
using System.IO;
public partial class NetMail_NetEmailAdd : System.Web.UI.Page
{
    /*检测FORM提交值
    protected void Page_Error(object sender, EventArgs e)
    {
        Exception ex = Server.GetLastError();
        if (ex is HttpRequestValidationException)
        {
            Response.Write("请您输入合法字符串。");
            Server.ClearError(); // 如果不ClearError()这个异常会继续传到Application_Error()。
        }
    }
    */


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            try
            {
                this.TextBox2.Text = Request.QueryString["Emaillist"].ToString();
            }
            catch
            { }
            //设置上传的附件为空
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");


            //检测是回复或者转发
            try
            {
                if (Request.QueryString["Type"].ToString().Trim() == "HuiFu")
                {
                    LCX.BLL.LCXNetEmail MyModel = new LCX.BLL.LCXNetEmail();
                    MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
                    //设置页面数据
                    this.TextBox1.Text = "Re：" + MyModel.EmailTitle;
                    this.TextBox2.Text = MyModel.FromUser;
                }
            }
            catch
            { }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            try
            {
                if (Request.QueryString["Type"].ToString().Trim() == "ZhuanFa")
                {
                    LCX.BLL.LCXNetEmail MyModel = new LCX.BLL.LCXNetEmail();
                    MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
                    //设置页面数据
                    this.TextBox1.Text = "RW：" + MyModel.EmailTitle;
                    if (MyModel.EmailContent != "")
                    {
                        StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("eml\\") + MyModel.EmailContent);
                        this.TxtContent.Text = sr.ReadToEnd();
                        sr.Close();
                    }                     
                }
            }
            catch
            { }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXNetEmail MyModel = new LCX.BLL.LCXNetEmail();
        MyModel.EmailTitle = this.TextBox1.Text;
        MyModel.EmailContent = emlTofile(this.TxtContent.Text); //内容

        MyModel.FuJian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        MyModel.FromUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyModel.EmailState = "已发";
        MyModel.TimeStr = DateTime.Now;
        string[] ToWhoList = this.TextBox2.Text.Trim().Split(',');
        for (int i = 0; i < ToWhoList.Length; i++)
        {
            if (ToWhoList[i].Trim().Length > 0)
            {
                MyModel.ToUser = ToWhoList[i].Trim();
                MyModel.Add();

                //获取现有设置
                LCX.BLL.LCXPOPAndSMTP MySMTPModel = new LCX.BLL.LCXPOPAndSMTP();
                MySMTPModel.GetModel(int.Parse(LCX.Common.PublicMethod.GetSessionValue("UserID")));
                //发送邮件到Internet地址
                try
                {
                    Pop3ForJmail.SendMail(MySMTPModel.SMTPUserName, MySMTPModel.SMTPUserPwd, MySMTPModel.SMTPServer, MyModel.EmailTitle, this.TxtContent.Text, MySMTPModel.SMTPFromEmail, MyModel.ToUser, MyModel.FuJian);
                }
                catch
                {
                    Response.Write("<script>alert('发送邮件时发生错误，请检查您的邮件参数设置是否正确！');</script>");
                }
            }
        }
        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加新邮件(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "Internet邮件添加成功！", "NetMailShou.aspx");
    }
    private static int iss = 1;
    private string emlTofile(string _emlcontent)
    {
        try
        {
            iss = +1;
            FolderCreate(HttpContext.Current.Server.MapPath("eml\\") + "s" + DateTime.Now.ToString("yyyyMMdd"));
            string _filename = "s" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + iss.ToString() + ".eml";
            string filePath = HttpContext.Current.Server.MapPath("eml\\") + _filename; //邮件文件内容
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("utf-8"));
            sw.Write(_emlcontent); //邮件内容
            sw.Close();
            fs.Close();
            return _filename;
        }
        catch (Exception e)
        {
            return "";
        }  
    }
    #region 判断文件夹是否存在  不存在就新建
    public void FolderCreate(string Path)
    {
        // 判断目标目录是否存在如果不存在则新建之  
        if (!Directory.Exists(Path))
            Directory.CreateDirectory(Path);
    }
    #endregion

    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
        if (LCX.Common.PublicMethod.GetSessionValue("WenJianList").Trim() == "")
        {
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", FileNameStr);
        }
        else
        {
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", LCX.Common.PublicMethod.GetSessionValue("WenJianList") + "|" + FileNameStr);
        }
        LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)
            {
                if (this.CheckBoxList1.Items[i].Selected == true)
                {
                    LCX.Common.PublicMethod.SetSessionValue("WenJianList", LCX.Common.PublicMethod.GetSessionValue("WenJianList").Replace(this.CheckBoxList1.Items[i].Value, "").Replace("||", "|"));
                }
            }
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
        catch
        { }
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        //草稿
        LCX.BLL.LCXNetEmail MyModel = new LCX.BLL.LCXNetEmail();

        MyModel.EmailTitle = this.TextBox1.Text;
        MyModel.EmailContent = this.TxtContent.Text;
        MyModel.FuJian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        MyModel.FromUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyModel.EmailState = "草稿";
        MyModel.TimeStr = DateTime.Now;
        string[] ToWhoList = this.TextBox2.Text.Trim().Split(',');
        for (int i = 0; i < ToWhoList.Length; i++)
        {
            if (ToWhoList[i].Trim().Length > 0)
            {
                MyModel.ToUser = ToWhoList[i].Trim();
                MyModel.Add();
            }
        }

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加新邮件(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "Internet邮件添加成功！", "NetMailShou.aspx");
    }
}