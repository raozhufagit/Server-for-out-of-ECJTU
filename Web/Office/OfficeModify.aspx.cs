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

public partial class Office_OfficeModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXOffice Model = new LCX.BLL.LCXOffice();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtOfficeName.Text=Model.OfficeName.ToString();
			this.txtMiaoShu.Text=Model.MiaoShu.ToString();
		LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.FuJianStr);
		LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
			this.txtTypeStr.Text=Model.TypeStr.ToString();
			this.txtSerils.Text=Model.Serils.ToString();
			this.txtDanWei.Text=Model.DanWei.ToString();
			this.txtDanJia.Text=Model.DanJia.ToString();
			this.txtGongYingShang.Text=Model.GongYingShang.ToString();
			this.txtMinNum.Text=Model.MinNum.ToString();
			this.txtMaxNum.Text=Model.MaxNum.ToString();
			this.txtNowNum.Text=Model.NowNum.ToString();
			this.txtUserName.Text=Model.UserName.ToString();
			this.txtTimeStr.Text=Model.TimeStr.ToString();
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXOffice Model = new LCX.BLL.LCXOffice();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.OfficeName=this.txtOfficeName.Text.ToString();
		Model.MiaoShu=this.txtMiaoShu.Text.ToString();
		Model.FuJianStr=LCX.Common.PublicMethod.GetSessionValue("WenJianList");
		Model.TypeStr=this.txtTypeStr.Text.ToString();
		Model.Serils=this.txtSerils.Text.ToString();
		Model.DanWei=this.txtDanWei.Text.ToString();
		Model.DanJia=this.txtDanJia.Text.ToString();
		Model.GongYingShang=this.txtGongYingShang.Text.ToString();
		Model.MinNum=Double.Parse(this.txtMinNum.Text.ToString());
		Model.MaxNum=Double.Parse(this.txtMaxNum.Text.ToString());
		Model.NowNum=Double.Parse(this.txtNowNum.Text.ToString());
		Model.UserName=this.txtUserName.Text.ToString();
		Model.TimeStr=DateTime.Parse(this.txtTimeStr.Text);
		
		Model.Update();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户修改办公用品信息(" + this.txtOfficeName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "办公用品信息修改成功！", "Office.aspx");
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

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CheckBoxList1.SelectedItem.Text.Trim().Length > 0)
            {
                Response.Write("<script>window.open('../DsoFramer/ReadFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Value + "');</script>");
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
                Response.Write("<script>window.open('../DsoFramer/EditFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Value + "');</script>");
            }
        }
        catch
        { }
    }
}
