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

public partial class DocFile_JiangChengZhiDuAdd : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			//�����ϴ��ĸ���Ϊ��
			 LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXPunishmentZhiDu Model = new LCX.BLL.LCXPunishmentZhiDu();
		
		Model.TitleStr=this.txtTitleStr.Text.ToString();
		Model.JianJie=this.txtJianJie.Text.ToString();
		Model.UserName=LCX.Common.PublicMethod.GetSessionValue("UserName");
		Model.TimeStr=DateTime.Now;
		Model.FuJianStr=LCX.Common.PublicMethod.GetSessionValue("WenJianList");
		Model.ConTentStr=this.txtConTentStr.Text.ToString();
		
		Model.Add();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "�û���ӽ����ƶ���Ϣ(" + this.txtTitleStr.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "�����ƶ���Ϣ��ӳɹ���", "JiangChengZhiDu.aspx");
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
