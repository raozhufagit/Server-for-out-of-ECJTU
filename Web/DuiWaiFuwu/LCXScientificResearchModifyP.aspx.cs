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
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

public partial class DuiWaiFuwu_LCXScientificResearchModifyP : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            
            LCX.BLL.LCXScientificResearch Model = new LCX.BLL.LCXScientificResearch();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtScientificName.Text = Model.ScientificName.ToString();
            this.txtScientificNo.Text = Model.ScientificNo.ToString();
            this.txtScientificType.Text = Model.ScientificType.ToString();
            this.txtHostPerson.Text = Model.HostPerson.ToString();
            this.txtStartTime.Text = Model.StartTime.ToString();
            this.txtEndTime.Text = Model.EndTime.ToString();
            this.txtParticipants.Text = Model.Participants.ToString();
            this.txtScientificDir.Text = Model.ScientificDir.ToString();
            this.txtResearchFind.Text = Model.ResearchFind.ToString();
            this.txtScientificStates.Text = Model.ScientificStates.ToString();
            this.txtRemarks.Text = Model.Remarks.ToString();
            this.txtApplicationDir.Text = Model.ApplicationDir.ToString();
            this.txtRemarks.Text = Model.Remarks.ToString();
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.Attachment);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
            if (Model.States == 1 || Model.States == 2)
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的科研信息不能修改！", "LCXScientificResearchP.aspx");
                return;
            }
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXScientificResearch Model = new LCX.BLL.LCXScientificResearch();
        string username = LCX.Common.PublicMethod.GetSessionValue("UserName");
        Model.ScientificName = this.txtScientificName.Text.ToString();
        Model.ScientificNo = this.txtScientificNo.Text.ToString();
        Model.ScientificType = this.txtScientificType.Text.ToString();
        Model.HostPerson = this.txtHostPerson.Text.ToString();
        Model.StartTime = DateTime.Parse(this.txtStartTime.Text);
        Model.EndTime = DateTime.Parse(this.txtEndTime.Text);
        Model.Participants = this.txtParticipants.Text.ToString();
        Model.ScientificDir = this.txtScientificDir.Text.ToString();
        Model.ResearchFind = this.txtResearchFind.Text.ToString();
        Model.ScientificStates = this.txtScientificStates.Text.ToString();
        Model.ApplicationDir = this.txtApplicationDir.Text.ToString();
        Model.Remarks = this.txtRemarks.Text.ToString();
        Model.Attachment = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        if (Model.States == 1 || Model.States == 2)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "已审核的科研信息不能修改！", "LCXScientificResearch.aspx");
        }
        else
        {
            if (DbHelperSQL.Exists("select * from  LCXScientificResearch where HostPerson=(select TrueName from LCXUser where UserName='" + username + "') and ScientificName='" + this.txtScientificName.Text.ToString() + "'"))
            {
                Model.Update();
                //写系统日志
                LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
                MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
                MyRiZhi.DoSomething = "用户修改科研信息(" + this.txtScientificName.Text + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                MyRiZhi.Add();

                LCX.Common.MessageBox.ShowAndRedirect(this, "科研信息修改成功！", "LCXScientificResearch.aspx");
            }
            else
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "对不起，您不是主持人，不能修改该信息！", "LCXScientificResearchP.aspx");
            }
        }
        

       
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
