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

public partial class SystemManage_RedHeadAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
        if (FileNameStr.Trim().Length > 0)
        {
            LCX.BLL.LCXRedHead MyModel = new LCX.BLL.LCXRedHead();
            MyModel.FilePath = FileNameStr;
            MyModel.FileName = this.TextBox1.Text;
            MyModel.TimeStr = DateTime.Now;
            MyModel.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyModel.Add();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户添加红头文件(" + this.TextBox1.Text+ ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            LCX.Common.MessageBox.ShowAndRedirect(this, "红头文件添加成功！", "RedHeadFile.aspx");
        }
    }
}