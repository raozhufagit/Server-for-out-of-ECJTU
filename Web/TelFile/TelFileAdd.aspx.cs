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

public partial class TelFile_TelFileAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.DBUtility.DbHelperSQL.BindDropDownList2("select * from LCXCYDIC where UserName='"+LCX.Common.PublicMethod.GetSessionValue("UserName")+"'", this.DropDownList1, "DicName", "ID");

            //设置上传的附件为空
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");

            try
            {
                this.TextBox2.Text = Request.QueryString["UserName"].ToString();
            }
            catch
            { }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXTelFile MyModel = new LCX.BLL.LCXTelFile();

        MyModel.ChuanYueYiJian = "";
        MyModel.FileType = this.TextBox3.Text;
        MyModel.TimeStr = DateTime.Now;
        MyModel.TitleStr = this.TextBox1.Text;
        MyModel.ContentStr = this.TxtContent.Text;
        MyModel.FuJianStr = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        MyModel.FromUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyModel.ToUser = this.TextBox2.Text;
        MyModel.YiJieShouRen = "";
        MyModel.ChuanYueHouIDList1 = this.DropDownList1.SelectedItem.Value.ToString();
        MyModel.QianShouHouIDList = "0";
        MyModel.Add();

        
        //发送短信
        SendMainAndSms.SendMessage(CHKSMS,CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName")+"发来新的公文文件需要接收！(" + this.TextBox1.Text + ")", this.TextBox2.Text.Trim());


        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加传阅文件(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "传阅文件添加成功！", "SendFile.aspx");
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
                    LCX.Common.PublicMethod.SetSessionValue("WenJianList", LCX.Common.PublicMethod.GetSessionValue("WenJianList").Replace(this.CheckBoxList1.Items[i].Text, "").Replace("||", "|"));
                }
            }
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
        catch
        { }
    }    
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CheckBoxList1.SelectedItem.Text.Trim().Length > 0)
            {
                Response.Write("<script>window.open('../DsoFramer/ReadFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Text + "');</script>");
            }
        }
        catch
        { }
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CheckBoxList1.SelectedItem.Text.Trim().Length > 0)
            {
                Response.Write("<script>window.open('../DsoFramer/EditFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Text + "');</script>");
            }
        }
        catch
        { }
    }
}