using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScDetailModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if(Request.UrlReferrer!=null){  
             ViewState["UrlReferrer"]=Request.UrlReferrer.ToString();
            }   

            LCX.Common.PublicMethod.CheckSession();

            LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
            if (!LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", "," + scSet.sc_User + ","))
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "你没有权限修改明细单！", "ScDetail.aspx");
                return;
            }  
            LCX.BLL.LCXManuPc model = new LCX.BLL.LCXManuPc();
            model.GetModel(Int32.Parse(Request.QueryString["ID"].ToString())); 
            this.txtPc_Name.Text=model.Pc_Name;
            this.txtPc_Vesion.Text=model.Pc_Vesion; 
            this.txtPc_NotUser.Text=model.Pc_NotUser;
            this.txtPc_mark.Text=model.Pc_mark; 
            if (model.Pc_State == 0 || model.Pc_State ==1 || model.Pc_State ==3)
            {

            }
            else
            {
                LCX.Common.MessageBox.Show(this, "当前版本已经通过审核不能修改此信息！");
                return;
            } 
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", model.Pc_Wenjian);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXManuPc model = new LCX.BLL.LCXManuPc();
        model.GetModel(Int32.Parse(Request.QueryString["ID"].ToString())); 


        if (model.Pc_State == 2 || model.Pc_State == 4 || model.Pc_State==5)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的订单信息不能修改！", "ScManage.aspx");
            return;
        }
        model.Pc_Name = this.txtPc_Name.Text.Trim();
        model.Pc_Vesion = this.txtPc_Vesion.Text.Trim();
        model.Pc_UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.Pc_Timer = DateTime.Now;
        model.Pc_NotUser = this.txtPc_NotUser.Text.Trim();
        model.Pc_mark = this.txtPc_mark.Text.Trim();
        model.Pc_accUser = "";
        model.Pc_JsSp = "";
        model.Pc_JsStime = Convert.ToDateTime(null);
        model.Pc_SpUser = "";
        model.Pc_SpTimer = Convert.ToDateTime(null);
        model.Pc_Wenjian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        model.Pc_State = 0;
        model.Pc_Jsyj = "";
        model.Pc_Yj = "";
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "修改失败！");
            return;
        }
        //发送通知
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "修改了新的生产明细单【" + model.Pc_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtPc_NotUser.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.Pc_UserName + "修改了新的生产明细单信息(" + this.txtPc_Name.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Update();
        LCX.Common.MessageBox.Show(this, "生产明细单信息修改成功！");
        Response.Redirect(ViewState["UrlReferrer"].ToString());  //返回上级菜单修改完成后
        //LCX.Common.MessageBox.ShowAndRedirect(this, "生产明细单信息修改成功！", "ScManage.aspx");
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