using System;
using System.Collections.Generic;
using System.Xml;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScManuProAdd : System.Web.UI.Page
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
                LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！", "ScPlan.aspx");
                return;
            }
            LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
            if (!LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", "," + scSet.jd_User + ","))
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
        string startdate = Convert.ToDateTime(this.txtJd_Time.Text.Trim()).ToString("yyyy,MM,dd");
        DateTime DateTime1 = Convert.ToDateTime(this.txtJd_Time.Text.Trim());
        DateTime DateTime2 = Convert.ToDateTime(this.txtJd_OverTime.Text.Trim());
        string planH = ((DateTime2 - DateTime1).TotalDays * 8).ToString();


        XmlDocument doc = new XmlDocument(); 
        doc.LoadXml(
            "<projects> " +
                    "<project name='" + this.txtJd_Name.Text.Trim() + "' id='0' planH = '" + planH + "' startdate = '" + startdate + "'>" +
                    "<task id='1'>" +
                    "<name>项目一</name>"+
                    "<planH>8</planH>"+
                    "<alarm></alarm>"+
                    "<startdate>" + startdate + "</startdate>" +
                    "<duration>8</duration>"+
                    "<percentcompleted>0</percentcompleted>"+
                    "<predecessortasks></predecessortasks>"+
                    "<childtasks></childtasks>"+
                    "</task>"+
                    "</project>" +
                    "</projects>"); 
        string _file = DateTime.Now.ToString("yyyymmddhhmmss") + ".xml";
        doc.Save(Server.MapPath("xml\\"+_file));
         

        LCX.BLL.LCXManuPro model = new LCX.BLL.LCXManuPro();
        model.Jd_Name = this.txtJd_Name.Text.Trim();
        try{
             model.Jd_Time = Convert.ToDateTime(this.txtJd_Time.Text.Trim());
             model.Jd_OverTime = Convert.ToDateTime(this.txtJd_OverTime.Text.Trim());
        }catch(Exception ex){

        } 
        model.Jd_User = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.Jd_WcTime = DateTime.Now;
        model.Jd_State = 0;
        model.Jd_Pic = "";
        model.Jd_Pic2 = _file; 
        model.Jd_Dd = Int32.Parse(Request.QueryString["ID"].ToString());
        model.Jd_Fujian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        model.Jd_Content = this.txtJd_Content.Text.Trim();
        if (model.Add() < 1)
        {
            LCX.Common.MessageBox.Show(this, "添加失败！");
            return;
        }
        //发送通知
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "提交了新的生产明细单【" + model.Jd_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtPc_NotUser.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.Jd_User + "添加了新的生产明细单(" + this.txtJd_Name.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        Response.Redirect(ViewState["UrlReferrer"].ToString());  //返回上级菜单修改完成后
        //LCX.Common.MessageBox.ShowAndRedirect(this, "生产明细单信息添加成功！", "ScManuPro.aspx?ID" + Request.QueryString["ID"].ToString());
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