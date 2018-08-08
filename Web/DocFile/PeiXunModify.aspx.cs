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

public partial class DocFile_PeiXunModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXTrain Model = new LCX.BLL.LCXTrain();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtPeiXunName.Text=Model.PeiXunName.ToString();
			this.txtPeiXunUser.Text=Model.PeiXunUser.ToString();
			this.txtCanYuUser.Text=Model.CanYuUser.ToString();
			this.txtStartDate.Text=Model.StartDate.ToString();
			this.txtEndDate.Text=Model.EndDate.ToString();
			this.txtPeiXunMuDi.Text=Model.PeiXunMuDi.ToString();
			this.txtPeiXunNeiRong.Text=Model.PeiXunNeiRong.ToString();
			this.txtXiaoGuo.Text=Model.XiaoGuo.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
		    LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.FuJianList);
		    LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXTrain Model = new LCX.BLL.LCXTrain();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.PeiXunName=this.txtPeiXunName.Text.ToString();
		Model.PeiXunUser=this.txtPeiXunUser.Text.ToString();
		Model.CanYuUser=this.txtCanYuUser.Text.ToString();
		Model.StartDate=this.txtStartDate.Text.ToString();
		Model.EndDate=this.txtEndDate.Text.ToString();
		Model.PeiXunMuDi=this.txtPeiXunMuDi.Text.ToString();
		Model.PeiXunNeiRong=this.txtPeiXunNeiRong.Text.ToString();
		Model.XiaoGuo=this.txtXiaoGuo.Text.ToString();
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		Model.FuJianList=LCX.Common.PublicMethod.GetSessionValue("WenJianList");
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		
		Model.Update();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改培训信息(" + this.txtPeiXunName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "培训信息修改成功！", "PeiXun.aspx");
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
