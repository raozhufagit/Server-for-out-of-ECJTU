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

public partial class GongGao_GongGaoModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();

            LCX.BLL.LCXNotice MyModel = new LCX.BLL.LCXNotice();
            MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.TextBox1.Text = MyModel.TitleStr;
            this.TxtContent.Text = MyModel.ContentStr;
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", MyModel.FuJian);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));

            this.TextBox2.Text = MyModel.UserBuMen.ToString();

            //不是单位通知，那么不显示收阅部门信息
            if (Request.QueryString["Type"].ToString() != "单位")
            {
                this.Label1.Visible = false;
                this.TextBox2.Visible = false;
                this.IMG1.Visible = false;
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXNotice Model = new LCX.BLL.LCXNotice();
        Model.TitleStr = this.TextBox1.Text;        
        Model.FuJian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        Model.TypeStr = Request.QueryString["Type"].ToString();
        Model.ContentStr = this.TxtContent.Text;       

        Model.ID = int.Parse(Request.QueryString["ID"].ToString());
        Model.Update();

        //更新公告通知的收阅部门
        if (Request.QueryString["Type"].ToString() == "单位")        
        {
            LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXNotice set UserBuMen='" + this.TextBox2.Text.Trim() + "' where ID=" + Request.QueryString["ID"].ToString());
        }


        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改公告通知信息(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "公告通知信息修改成功！", "GongGao.aspx?Type=" + Request.QueryString["Type"].ToString());
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
        try
        {
            if (this.CheckBoxList1.SelectedItem.Text.Trim().Length > 0)
            {
                Response.Write("<script>window.open('../DsoFramer/ReadFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Value + "');</script>");
            }
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
                Response.Write("<script>window.open('../DsoFramer/EditFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Value + "');</script>");
            }
        }
        catch
        { }
    }
}