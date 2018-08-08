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

public partial class DocFile_MianShiModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXInterView Model = new LCX.BLL.LCXInterView();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtMSName.Text=Model.MSName.ToString();
			this.txtMSDate.Text=Model.MSDate.ToString();
			this.txtMSSex.Text=Model.MSSex.ToString();
			this.txtMSAge.Text=Model.MSAge.ToString();
			this.txtXueLi.Text=Model.XueLi.ToString();
			this.txtZhuanYe.Text=Model.ZhuanYe.ToString();
			this.txtMSZhiWei.Text=Model.MSZhiWei.ToString();
			this.txtMSJieGuo.Text=Model.MSJieGuo.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
		LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.FuJianStr);
		LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXInterView Model = new LCX.BLL.LCXInterView();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.MSName=this.txtMSName.Text.ToString();
		Model.MSDate=this.txtMSDate.Text.ToString();
		Model.MSSex=this.txtMSSex.Text.ToString();
		Model.MSAge=this.txtMSAge.Text.ToString();
		Model.XueLi=this.txtXueLi.Text.ToString();
		Model.ZhuanYe=this.txtZhuanYe.Text.ToString();
		Model.MSZhiWei=this.txtMSZhiWei.Text.ToString();
		Model.MSJieGuo=this.txtMSJieGuo.Text.ToString();
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		Model.FuJianStr=LCX.Common.PublicMethod.GetSessionValue("WenJianList");
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		
		Model.Update();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户修改面试数据信息(" + this.txtMSName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "面试数据信息修改成功！", "MianShi.aspx");
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
