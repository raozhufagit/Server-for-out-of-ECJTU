using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            this.txtSc_Jtime.Attributes.Add("readonly","true");  //设置日期文本框为只读
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXManuFact model = new LCX.BLL.LCXManuFact();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            if (model.Sc_Tjr != LCX.Common.PublicMethod.GetSessionValue("UserName"))
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "您没有权限修改此订单信息！", "ScManage.aspx");
                return;
            }
            if (model.Sc_State == 2)
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的订单信息不能修改！", "ScManage.aspx");
                return;
            }
            this.txtSc_Name.Text = model.Sc_Name;
            this.txtSc_Custmoer.Text = model.Sc_Custmoer;
            if (model.Sc_Jtime != Convert.ToDateTime(null))
            {
                this.txtSc_Jtime.Text = model.Sc_Jtime.ToString();
            } 
            this.txtMark.Text = model.Sc_Maoshu;  
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", model.Sc_Fuj);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }

    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXManuFact model = new LCX.BLL.LCXManuFact();
        model.GetModel(Int32.Parse(Request.QueryString["ID"].ToString()));
        model.Sc_Name = this.txtSc_Name.Text.Trim();
        model.Sc_Custmoer = this.txtSc_Custmoer.Text.Trim();
        if (this.txtSc_Jtime.Text.Trim() != "")
        {
            try
            {
                model.Sc_Jtime = DateTime.Parse(this.txtSc_Jtime.Text);
            }
            catch
            {
                LCX.Common.MessageBox.Show(this, "交货日期不正确！");
                return;
            }
        }
        else
        {
            LCX.Common.MessageBox.Show(this, "交货日期不能为空！");
            return;
        } 
        model.Sc_Tjr = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.Sc_Fuj = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        model.Sc_Timer = DateTime.Now;
        if(model.Sc_State != 2 ){
            model.Sc_Yij = null;
            model.Sc_Spr = null;
            model.Sc_State = 0;
            model.Sc_SpTime = Convert.ToDateTime(null);
        }else{
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的订单信息不能修改！", "ScManage.aspx");
            return;
        }
        model.Sc_Maoshu = this.txtMark.Text.Trim();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "修改失败！");
            return;
        }
        //发送通知
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "提交了新的生产订单【" + model.Sc_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.Sc_Tjr + "修改了新的生产订单信息(" + this.txtSc_Name.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Update();
        LCX.Common.MessageBox.ShowAndRedirect(this, "生产订单信息修改成功！", "ScManage.aspx");
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