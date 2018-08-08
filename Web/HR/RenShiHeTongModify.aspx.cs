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

public partial class HRNew_RenShiHeTongModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXP_Contract Model = new LCX.BLL.LCXP_Contract();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtHeTongUser.Text=Model.HeTongUser.ToString();
			this.txtNowState.Text=Model.NowState.ToString();
			this.txtSerils.Text=Model.Serils.ToString();
			this.txtTypeStr.Text=Model.TypeStr.ToString();
			this.txtJingYe.Text=Model.JingYe.ToString();
			this.txtBaoMiXieYi.Text=Model.BaoMiXieYi.ToString();
			this.txtQianYueDate.Text=Model.QianYueDate.ToString();
			this.txtManYueDate.Text=Model.ManYueDate.ToString();
			this.txtJianZhengJiGuan.Text=Model.JianZhengJiGuan.ToString();
			this.txtJianZhengDate.Text=Model.JianZhengDate.ToString();
			this.txtWeiYueZeRen.Text=Model.WeiYueZeRen.ToString();
			this.txtBackInfo.Text=Model.BackInfo.ToString();
		    LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.FuJianList);
		    LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXP_Contract Model = new LCX.BLL.LCXP_Contract();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.HeTongUser=this.txtHeTongUser.Text.ToString();
		Model.NowState=this.txtNowState.Text.ToString();
		Model.Serils=this.txtSerils.Text.ToString();
		Model.TypeStr=this.txtTypeStr.Text.ToString();
		Model.JingYe=this.txtJingYe.Text.ToString();
		Model.BaoMiXieYi=this.txtBaoMiXieYi.Text.ToString();
		Model.QianYueDate=this.txtQianYueDate.Text.ToString();
		Model.ManYueDate=this.txtManYueDate.Text.ToString();
		Model.JianZhengJiGuan=this.txtJianZhengJiGuan.Text.ToString();
		Model.JianZhengDate=this.txtJianZhengDate.Text.ToString();
		Model.WeiYueZeRen=this.txtWeiYueZeRen.Text.ToString();
		Model.BackInfo=this.txtBackInfo.Text.ToString();
		Model.FuJianList=LCX.Common.PublicMethod.GetSessionValue("WenJianList");
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		
		Model.Update();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改人事合同信息(" + this.txtHeTongUser.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "人事合同信息修改成功！", "RenShiHeTong.aspx");
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
