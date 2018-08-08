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

public partial class Project_ProjectAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
            string username = LCX.Common.PublicMethod.GetSessionValue("UserName");
            LCX.BLL.LCXUser model = new LCX.BLL.LCXUser();
            model.GetUser(username);
            this.txtSuoShuKeHu.Text = model.Department;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXProject model = new LCX.BLL.LCXProject();
        model.ProjectName = this.txtProjectName.Text;
        model.SuoShuKeHu = this.txtSuoShuKeHu.Text;
        model.YuJiChengJiaoRiQi = this.txtYuJiChengJiaoRiQi.Text;
        model.TiXingDate = this.txtTiXingDate.Text;
        model.XiangMuJinE = this.txtXiangMuJinE.Text;
        model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.TimeStr = DateTime.Now;
        model.HeTongAndFuJian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        model.BackInfo = this.txtBackInfo.Text;
        model.XiangMuDaXiao = this.CooperationWays.Text;
        model.Push = this.Push.Text;
        model.ContactPerson = this.ContactPerson.Text;
        model.ContactEmail = this.ContactEmail.Text;
        model.ContactTel = this.ContactTel.Text;
        if (model.Add() == 1)
        {
            LCX.Common.MessageBox.Show(this, "添加失败！");
            return;
        }
        LCX.BLL.LCXPinShen Approval = new LCX.BLL.LCXPinShen();
        Approval.ProjectName = model.ProjectName;
        Approval.ProjectSerils = model.ProjectState.ToString();//原来评审项目那边的项目编号变成项目的状态 0-公司提出、对外联络处可见，有修改并推送的权限 1-对外联络处同意推送，老师可见，公司也可见项目状态为上架  2-公司确认教师接单购买  3-项目进行中，老师填写相关进度 公司，学校都可见   4-项目完成，老师和公司进行评价 学校进行评审
        Approval.Add();
        LCX.BLL.OutSchoolDemand Demand = new LCX.BLL.OutSchoolDemand();
        Demand.DemandName =  model.ProjectName;
        Demand.DemandType = "项目合作";
        Demand.PubCompany = model.SuoShuKeHu;
        Demand.PubTime = model.TimeStr;
        Demand.Push = model.Push;
        Demand.ContactPerson = model.ContactPerson;
        Demand.ContactEmail = model.ContactEmail;
        Demand.ContactTel = model.ContactTel;
        Demand.DemandState = model.ProjectState;
        Demand.Teacher = model.FuZeRen;
        Demand.VisibleType = model.ID;
        Demand.Add();


        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi(); 
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加项目信息(" + this.txtProjectName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "项目信息添加成功！", "ProjectManage.aspx?ProjectName= &TypeStr=我发布的项目");
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
        LCX.Common.MessageBox.ShowAndRedirect(this, "返回我发布的项目", "ProjectManage.aspx?ProjectName= &TypeStr=我发布的项目");
    }
    
}