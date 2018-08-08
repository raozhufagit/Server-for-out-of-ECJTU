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

public partial class Post_PostModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
            LCX.BLL.Post model = new LCX.BLL.Post();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
           // model.PubTime = DateTime.Now;
           // model.PubPerson = LCX.Common.PublicMethod.GetSessionValue("UserName");
            //model.PostState = "1";
            this.PostJobName.Text = model.PostJobName;
            this.PostJobType.SelectedItem.Value= model.PostJobType ;
            this.PubCompany.Text= model.PubCompany ;
            this.RequiredProfession.SelectedItem.Value= model.RequiredProfession;
            this.RequiredAmount.Text= model.RequiredAmount;
            this.ContactPerson.Text= model.ContactPerson;
            this.ContactEmail.Text= model.ContactEmail;
            this.ContactTel.Text= model.ContactTel;
            this.PostDetail.Text= model.PostDetail;
            this.Push.Text= model.Push;
            this.BeginTime.Text= model.BeginTime;
            this.EndTime.Text= model.EndTime;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.Post model = new LCX.BLL.Post();
        // model.PubTime = DateTime.Now;
        //model.PubPerson = LCX.Common.PublicMethod.GetSessionValue("UserName");
        //model.PostState = "1";
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
        model.PostJobName = this.PostJobName.Text;
        model.PostJobType = this.PostJobType.SelectedItem.Value.ToString();
        model.PubCompany = this.PubCompany.Text;
        model.RequiredProfession = this.RequiredProfession.SelectedItem.Value.ToString();
        model.RequiredAmount = this.RequiredAmount.Text;
        model.ContactPerson = this.ContactPerson.Text;
        model.ContactEmail = this.ContactEmail.Text;
        model.ContactTel = this.ContactTel.Text;
        model.PostDetail = this.PostDetail.Text;
        model.Push = this.Push.Text;
        model.BeginTime = this.BeginTime.Text;
        model.EndTime = this.EndTime.Text;
        model.Attachment = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        model.Update();
        /*LCX.BLL.LCXPinShen Approval = new LCX.BLL.LCXPinShen();
        Approval.ProjectName = model.PostJobName;
        Approval.ProjectSerils = model.PostState;
        //原来评审项目那边的项目编号变成项目的状态 0-公司提出、对外联络处可见，有修改并推送的权限 1-对外联络处同意推送，老师可见，公司也可见项目状态为上架  2-公司确认教师接单购买  3-项目进行中，老师填写相关进度 公司，学校都可见   4-项目完成，老师和公司进行评价 学校进行评审
        Approval.Add();
        LCX.BLL.OutSchoolDemand Demand = new LCX.BLL.OutSchoolDemand();
        Demand.DemandName = "【挂职岗位】" + model.PostJobName;
        Demand.DemandType = "挂职岗位";
        Demand.PubCompany = model.PubCompany;
        Demand.PubTime = model.PubTime;
        Demand.Push = model.Push;
        Demand.ContactPerson = model.ContactPerson;
        Demand.ContactEmail = model.ContactEmail;
        Demand.ContactTel = model.ContactTel;
        Demand.DemandState = int.Parse(model.PostState);
        Demand.Teacher = model.Teachers;
        Demand.Add();*/


        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改挂职岗位信息(" + this.PostJobName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "挂职岗位修改成功！", "PostManage.aspx?ProjectName= &TypeStr=我发布的挂职岗位");
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

    protected void Back_Click(object sender, ImageClickEventArgs e)
    {
        LCX.Common.MessageBox.ShowAndRedirect(this, "返回我发布的项目", "PostManage.aspx?ProjectName= &TypeStr=我发布的挂职岗位");
    }

}