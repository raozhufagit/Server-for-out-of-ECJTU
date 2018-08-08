﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class DocCenter_DocModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();

            LCX.BLL.LCXFileList MyModel = new LCX.BLL.LCXFileList();
            MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            //this.HyperLink1.Text = MyModel.FileName;
            //this.HyperLink1.NavigateUrl = "../UploadFile/" + MyModel.FilePath;
            this.Label4.Text = LCX.Common.PublicMethod.GetWenJian2(MyModel.FilePath, "../UploadFile/");

            this.Label5.Text = MyModel.FileName;
            this.TextBox1.Text = MyModel.BianHao;
            this.TxtContent.Text = MyModel.BackInfo;

            this.Label1.Text = MyModel.DaXiao.ToString();
            this.Label2.Text = MyModel.FileType;
            this.Label3.Text = MyModel.FilePath;

            txtCanView.Text = MyModel.CanView;
            txtCanAdd.Text = MyModel.CanAdd;
            txtCanMod.Text = MyModel.CanMod;
            txtCanDel.Text = MyModel.CanDel;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (this.FileUpload1.FileName.Trim().Length > 0)
        {
            string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
            if (FileNameStr.Trim().Length > 0)
            {
                LCX.BLL.LCXFileList MyModel = new LCX.BLL.LCXFileList();
                MyModel.FileName = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                MyModel.ID = int.Parse(Request.QueryString["ID"].ToString());
                MyModel.BianHao = this.TextBox1.Text;
                MyModel.BackInfo = this.TxtContent.Text;
                MyModel.DaXiao = (this.FileUpload1.PostedFile.ContentLength / 1024) + 1;
                try
                {
                    MyModel.FileType = this.FileUpload1.FileName.Remove(0, this.FileUpload1.FileName.LastIndexOf('.') + 1);
                }
                catch
                { }
                MyModel.DirID = int.Parse(Request.QueryString["DirID"].ToString());
                MyModel.ShangChuanTime = DateTime.Now;
                MyModel.FilePath = FileNameStr;
                MyModel.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
                MyModel.IFDel = "否";
                MyModel.TypeName = Request.QueryString["Type"].ToString();
                MyModel.IfShare = "否";
                MyModel.DirOrFile = 0;

                MyModel.CanView = txtCanView.Text;
                MyModel.CanAdd = txtCanAdd.Text;
                MyModel.CanMod = txtCanMod.Text;
                MyModel.CanDel = txtCanDel.Text;

                MyModel.Update();

                //写系统日志
                LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
                MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
                MyRiZhi.DoSomething = "用户修改文件信息(" + System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName) + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                MyRiZhi.Add();

                LCX.Common.MessageBox.ShowAndRedirect(this, "文件修改成功！", "DocCenter.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + Request.QueryString["DirID"].ToString());
            }
        }
        else
        {
            LCX.BLL.LCXFileList MyModel = new LCX.BLL.LCXFileList();
            MyModel.FileName = this.Label5.Text;
            MyModel.ID = int.Parse(Request.QueryString["ID"].ToString());
            MyModel.BianHao = this.TextBox1.Text;
            MyModel.BackInfo = this.TxtContent.Text;
            MyModel.DaXiao = int.Parse(this.Label1.Text);
            try
            {
                MyModel.FileType = this.Label2.Text;
            }
            catch
            { }
            MyModel.DirID = int.Parse(Request.QueryString["DirID"].ToString());
            MyModel.ShangChuanTime = DateTime.Now;
            MyModel.FilePath = this.Label3.Text;
            MyModel.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyModel.IFDel = "否";
            MyModel.TypeName = Request.QueryString["Type"].ToString();
            MyModel.IfShare = "否";
            MyModel.DirOrFile = 0;
            MyModel.Update();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户修改文件信息(" + this.Label5.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            LCX.Common.MessageBox.ShowAndRedirect(this, "文件修改成功！", "DocCenter.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + Request.QueryString["DirID"].ToString());
        }
    }
}