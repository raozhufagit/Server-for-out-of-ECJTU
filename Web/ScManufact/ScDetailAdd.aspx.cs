using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScDetailAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            if (Request.QueryString["ID"] == null)
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！", "ScPlan.aspx");
                return;
            }
            try
            {
                int id = Int32.Parse(Request.QueryString["ID"].ToString()); 
            }
            catch (Exception ex)
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！", "ScPlan.aspx");
                return;
            }  
            LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
            if (!LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", "," + scSet.sc_User + ","))
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "你没有权限添加明细单！", "ScDetail.aspx");
                return;
            } 
            //设置上传的附件为空
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXManuPc model = new LCX.BLL.LCXManuPc();
        model.Pc_Name = this.txtPc_Name.Text.Trim();
        model.Pc_Vesion = this.txtPc_Vesion.Text.Trim();
        model.Pc_UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.Pc_Timer = DateTime.Now;
        model.Pc_NotUser = this.txtPc_NotUser.Text.Trim(); 
        model.Pc_mark = this.txtPc_mark.Text.Trim();
        model.Pc_Dd = Int32.Parse(Request.QueryString["ID"].ToString());
        model.Pc_Wenjian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        if (model.Add() < 1)
        {
            LCX.Common.MessageBox.Show(this, "添加失败！");
            return;
        }
        //发送通知
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "提交了新的生产明细单【" + model.Pc_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtPc_NotUser.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.Pc_UserName + "添加了新的生产明细单(" + this.txtPc_Name.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "生产明细单信息添加成功！", "ScDetail.aspx?ID" + Request.QueryString["ID"].ToString());
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
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
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
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
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
}