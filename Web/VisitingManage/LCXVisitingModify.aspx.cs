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


public partial class VisitingManage_LCXVisitingModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXVisitingManagement Model = new LCX.BLL.LCXVisitingManagement();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtInVisitUnit.Text = Model.InVisitUnit.ToString();
            this.txtInVisitGroup.Text = Model.InVisitGroup.ToString();
            this.txtVisitPurpose.Text = Model.VisitPurpose.ToString();
            this.txtReceptionist.Text = Model.Receptionist.ToString();
            this.txtVisitTime.Text = Model.VisitTime.ToString();
            this.txtWorkProgress.Text = Model.WorkProgress.ToString();
            this.txtWorkReport.Text = Model.WorkReport.ToString();
            this.txtVisitingTitle.Text = Model.VisitingTitle.ToString();
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.Attchment);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXVisitingManagement Model = new LCX.BLL.LCXVisitingManagement();

        Model.ID = int.Parse(Request.QueryString["ID"].ToString());
        Model.InVisitUnit = this.txtInVisitUnit.Text.ToString();
        Model.InVisitGroup = this.txtInVisitGroup.Text.ToString();
        Model.VisitPurpose = this.txtVisitPurpose.Text.ToString();
        Model.WorkProgress = this.txtWorkProgress.Text.ToString();
        Model.WorkReport = this.txtWorkReport.Text.ToString();
        Model.VisitTime = DateTime.Parse(this.txtVisitTime.Text);
        Model.Attchment = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        Model.VisitingTitle = this.txtVisitingTitle.Text.ToString();
        Model.Update();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改来访信息(" + this.txtInVisitUnit.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "来访信息修改成功！", "LCXVisitingManagement.aspx");
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
}