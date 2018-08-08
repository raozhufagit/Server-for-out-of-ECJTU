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

public partial class TechnologyPurchase_TechnologyPurchaseModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
            LCX.BLL.TechnologyPurchase model = new LCX.BLL.TechnologyPurchase();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.TechnologyName.Text = model.TechnologyName;
            this.TechnologyType.SelectedItem.Value= model.TechnologyType;
            this.PubCompany.Text= model.PubCompany ;
            this.RequiredProfession.SelectedItem.Value= model.RequiredProfession;
            this.ContactPerson.Text= model.ContactPerson;
            this.ContactEmail.Text= model.ContactEmail;
            this.ContactTel.Text= model.ContactTel;
            this.TechnologyDetail.Text= model.TechnologyDetail;
            this.Push.Text= model.Push;
            this.BeginTime.Text= model.BeginTime;
            this.EndTime.Text= model.EndTime;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.TechnologyPurchase model = new LCX.BLL.TechnologyPurchase();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
        model.TechnologyName = this.TechnologyName.Text;
        model.TechnologyType = this.TechnologyType.SelectedItem.Value.ToString();
        model.PubCompany = this.PubCompany.Text;
        model.RequiredProfession = this.RequiredProfession.SelectedItem.Value.ToString();
        model.ContactPerson = this.ContactPerson.Text;
        model.ContactEmail = this.ContactEmail.Text;
        model.ContactTel = this.ContactTel.Text;
        model.TechnologyDetail = this.TechnologyDetail.Text;
        model.Push = this.Push.Text;
        model.BeginTime = this.BeginTime.Text;
        model.EndTime = this.EndTime.Text;
        model.Attachment = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        model.Update();
        


        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改技术求购信息(" + this.TechnologyName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "技术求购信息修改成功！", "TechnologyPurchaseMange.aspx?ProjectName= &TypeStr=我发布的技术求购");
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