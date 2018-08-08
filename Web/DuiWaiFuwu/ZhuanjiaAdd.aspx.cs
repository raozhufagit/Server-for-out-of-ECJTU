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

public partial class DuiWaiFuwu_ZhuanjiaAdd : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			//设置上传的附件为空
			 LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.ZhuanJia Model = new LCX.BLL.ZhuanJia();
        string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload2, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload2.PostedFile.FileName));

        // ,,,,,,,,,,,,JianJie,FuJianStr,UserName
        Model.GongHao = this.txtGongHao.Text.ToString();
        Model.XingMing = this.txtXingMing.Text.ToString();
        Model.BuMen = this.txtBuMen.Text.ToString();
        Model.XingBie = this.txtXingBie.Text.ToString();
        Model.ChuShengRiQi = DateTime.Parse(this.txtChuShengRiQi.Text);
        Model.XueLi = this.txtXueLi.Text.ToString();
        Model.XueWei = this.txtXueWei.Text.ToString();
        Model.XueKe = this.txtXueKe.Text.ToString();
        Model.YanJiuLingYu = this.txtYanJiuLingYu.Text.ToString();
        Model.ZhiWu = this.txtZhiWu.Text.ToString();
        Model.ZhiCheng = this.txtZhiCheng.Text.ToString();
        //Model.TimeStr = DateTime.Parse(this.txtTimeStr.Text);
        Model.TimeStr = DateTime.Now;
        Model.JianJie = this.txtJianJie.Text.ToString();
		Model.FuJianStr=LCX.Common.PublicMethod.GetSessionValue("WenJianList");
		Model.UserName=LCX.Common.PublicMethod.GetSessionValue("UserName");
        Model.ResearchFind = this.txtResearchFind.Text.ToString();
        Model.Nation = this.txtNation.Text.ToString();
        Model.Political = this.txtPolitical.Text.ToString();
        Model.PortraitPath = FileNameStr;
        Model.Add();
		
		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户添加专家信息(" + this.txtXingMing.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "专家信息添加成功！", "Zhuanjia.aspx");
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
