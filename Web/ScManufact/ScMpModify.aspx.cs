using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScMpModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.txtJd_Time.Attributes.Add("readonly", "true");  //设置日期文本框为只读
            this.txtJd_OverTime.Attributes.Add("readonly", "true");  //设置日期文本框为只读
            if (Request.UrlReferrer != null)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            }
            LCX.Common.PublicMethod.CheckSession();
            if (Request.QueryString["ID"] == null)
            {
                Response.Redirect(ViewState["UrlReferrer"].ToString());  //返回上级菜单修改完成后
                return;
            }
            try
            {
                int id = Int32.Parse(Request.QueryString["ID"].ToString());
            }
            catch (Exception ex)
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！", ViewState["UrlReferrer"].ToString());
                return;
            }
            LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
            if (!LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", "," + scSet.jd_User + ","))
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "你没有权限修改生产进度信息！", ViewState["UrlReferrer"].ToString());
                return;
            }
            LCX.BLL.LCXManuPro model = new LCX.BLL.LCXManuPro();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtJd_Name.Text=model.Jd_Name;

            if (model.Jd_Time != Convert.ToDateTime(null))
            {
                this.txtJd_Time.Text = model.Jd_Time.ToString();
            }
            if (model.Jd_OverTime != Convert.ToDateTime(null))
            {
                this.txtJd_OverTime.Text = model.Jd_OverTime.ToString();
            }
            this.txtJd_Content.Text = model.Jd_Content;
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", model.Jd_Fujian);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
           
            


            //设置上传的附件为空
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXManuPro model = new LCX.BLL.LCXManuPro();        
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
        if (model.Jd_State < 3)
        {
            model.Jd_Spr = null;
            model.Jd_SpYj = null;
            model.Jd_State = 0;
            model.Jd_SpTime = Convert.ToDateTime(null);
        }else{
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的进度信息不能修改！", ViewState["UrlReferrer"].ToString());
            return;
        }

        model.Jd_Name = this.txtJd_Name.Text.Trim();
        try
        {
            model.Jd_Time = Convert.ToDateTime(this.txtJd_Time.Text.Trim());
            model.Jd_OverTime = Convert.ToDateTime(this.txtJd_OverTime.Text.Trim());
        }
        catch (Exception ex)
        {

        }

        model.Jd_User = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.Jd_WcTime = DateTime.Now;
        model.Jd_State = 0;
        model.Jd_Fujian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");




        model.Jd_Content = this.txtJd_Content.Text.Trim();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "修改失败！");
            return;
        }
        //发送通知
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "修改了生产进度【" + model.Jd_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtPc_NotUser.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.Jd_User + "修改了生产进度信息(" + this.txtJd_Name.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Update();
        LCX.Common.MessageBox.ShowAndRedirect(this, "生产进度信息修改成功！", ViewState["UrlReferrer"].ToString());

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