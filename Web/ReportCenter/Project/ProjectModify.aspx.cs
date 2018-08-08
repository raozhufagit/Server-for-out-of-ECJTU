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

public partial class Project_ProjectModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXProject model = new LCX.BLL.LCXProject();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));            
            this.txtProjectName.Text = model.ProjectName;
            this.txtSuoShuKeHu.Text = model.SuoShuKeHu;
            this.txtYuJiChengJiaoRiQi.Text = model.YuJiChengJiaoRiQi;
            this.txtTiXingDate.Text = model.TiXingDate;
            this.txtXiangMuJinE.Text = model.XiangMuJinE;
            this.CooperationWays.Text = model.XiangMuDaXiao;
            this.Push.Text = model.Push;           
            this.txtBackInfo.Text = model.BackInfo;
            this.ContactPerson.Text = model.ContactPerson;
            this.ContactEmail.Text = model.ContactEmail;
            this.ContactTel.Text  = model.ContactTel;
            this.FuZeRen.Text = model.FuZeRen;



            LCX.Common.PublicMethod.SetSessionValue("WenJianList", model.HeTongAndFuJian);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXProject model = new LCX.BLL.LCXProject();
        model.ID = int.Parse(Request.QueryString["ID"].ToString());
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
        model.Update();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改项目信息(" + this.txtProjectName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

       LCX.Common.MessageBox.ShowAndRedirect(this, "项目信息修改成功！", "ProjectManage.aspx?ProjectName=");
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