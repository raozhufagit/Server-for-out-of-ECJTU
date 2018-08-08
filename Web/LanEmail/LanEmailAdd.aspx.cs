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

public partial class LanEmail_LanEmailAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");

            try
            {
                this.TextBox2.Text = Request.QueryString["UserName"].ToString();
            }
            catch
            { }

            //检测是回复或者转发
            try
            {
                if (Request.QueryString["Type"].ToString().Trim() == "HuiFu")
                {
                    LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();
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
                    LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();
                    MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
                    //设置页面数据
                    this.TextBox1.Text = "RW：" + MyModel.EmailTitle;
                    this.TxtContent.Text= MyModel.EmailContent;
                    LCX.Common.PublicMethod.SetSessionValue("WenJianList", MyModel.FuJian);
                    LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
                }
            }
            catch
            { }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();

        MyModel .EmailTitle = this.TextBox1.Text;
        MyModel.EmailContent = this.TxtContent.Text;
        MyModel.FuJian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        MyModel.FromUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyModel.EmailState = "未读";
        string[] ToWhoList=this.TextBox2.Text.Trim().Split(',');
        for(int i=0;i<ToWhoList.Length;i++)
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

        LCX.Common.MessageBox.ShowAndRedirect(this, "内部邮件添加成功！", "LanEmailShou.aspx");
    }

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
        LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();

        MyModel.EmailTitle = this.TextBox1.Text;
        MyModel.EmailContent = this.TxtContent.Text;
        MyModel.FuJian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        MyModel.FromUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyModel.EmailState = "草稿";
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

        LCX.Common.MessageBox.ShowAndRedirect(this, "内部邮件添加成功！", "LanEmailShou.aspx");
    }
}