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

public partial class CooperationAgreement_LCXContractImpleModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXContractImple Model = new LCX.BLL.LCXContractImple();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtContractName.Text = Model.ContractName.ToString();
            this.txtPhaseName.Text = Model.PhaseName.ToString();
            this.txtStartTime.Text=Model.StartTime.ToString() ;
            this.txtEndTime.Text=Model.EndTime.ToString();
            this.txtCompletionDegree.Text = Model.CompletionDegree.ToString();
            this.txtChargePerson.Text = Model.ChargePerson.ToString();
            this.txtRemarks.Text = Model.Remarks.ToString();
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.Attachment);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXContractImple Model = new LCX.BLL.LCXContractImple();

        // ,,,,,,,,,,,,JianJie,FuJianStr,UserName
        Model.ContractName = this.txtContractName.Text.ToString();
        Model.PhaseName = this.txtPhaseName.Text.ToString();
        Model.StartTime = DateTime.Parse(this.txtStartTime.Text);
        Model.EndTime = DateTime.Parse(this.txtEndTime.Text);
        Model.CompletionDegree = this.txtCompletionDegree.Text.ToString();
        Model.ChargePerson = this.txtChargePerson.Text.ToString();
        Model.Remarks = this.txtRemarks.Text.ToString();
        Model.SubmitTime = DateTime.Parse(DateTime.Now.ToString());
        Model.SubmitPerson = LCX.Common.PublicMethod.GetSessionValue("UserName");
        //Model.Content = this.txtContent.Text.ToString();
        Model.Attachment = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        Model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加合同进度信息(" + this.txtPhaseName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "合同实施进度信息添加成功！", "LCXContractImple.aspx?ContractName=" + this.txtContractName.Text.ToString());

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