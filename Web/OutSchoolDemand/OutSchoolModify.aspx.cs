using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OutSchoolDemand_OutSchoolModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
            LCX.BLL.OutSchoolDemand model = new LCX.BLL.OutSchoolDemand();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.DemandName.Text= model.DemandName;
            this.PubCompany.Text = model.PubCompany;
            this.PredictedFinishTime.Text= model.PredictedFinishTime;
            this.PrE.Text= model.PrE;
            this.BackInfo.Text= model.BackInfo;
            this.DemandDetail.Text = model.DemandDetail;
            this.Push.Text=model.Push;
            this.ContactPerson.Text=model.ContactPerson;
            this.ContactEmail.Text=model.ContactEmail;
            this.ContactTel.Text=model.ContactTel;
            LCX.Common.PublicMethod.SetSessionValue("WenJianList",model.Attachment);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.OutSchoolDemand model = new LCX.BLL.OutSchoolDemand();
        model.DemandName = this.DemandName.Text;
        model.PubCompany = this.PubCompany.Text;
        model.PredictedFinishTime = this.PredictedFinishTime.Text;
        model.PrE = this.PrE.Text;
        model.PubPerson = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.PubTime = DateTime.Now;
        model.Attachment = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        model.BackInfo = this.BackInfo.Text;
        model.DemandDetail = this.DemandDetail.Text;
        model.Push = this.Push.Text;
        model.ContactPerson = this.ContactPerson.Text;
        model.ContactEmail = this.ContactEmail.Text;
        model.ContactTel = this.ContactTel.Text;
        model.Update();
        /*   LCX.BLL.LCXPinShen Approval = new LCX.BLL.LCXPinShen();
           Approval.ProjectName = model.ProjectName;
           Approval.ProjectSerils = model.ProjectState.ToString();//原来评审项目那边的项目编号变成项目的状态 0-公司提出、对外联络处可见，有修改并推送的权限 1-对外联络处同意推送，老师可见，公司也可见项目状态为上架  2-公司确认教师接单购买  3-项目进行中，老师填写相关进度 公司，学校都可见   4-项目完成，老师和公司进行评价 学校进行评审
           Approval.Add();*/

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加项目信息(" + this.DemandName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "项目信息添加成功！", "OutSchool.aspx?ProjectName= &TypeStr=");
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
}