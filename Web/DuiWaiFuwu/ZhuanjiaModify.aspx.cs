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

public partial class DuiWaiFuwu_ZhuanjiaModify : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.BLL.ZhuanJia Model = new LCX.BLL.ZhuanJia();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtGongHao.Text = Model.GongHao.ToString();
            this.txtXingMing.Text = Model.XingMing.ToString();
            this.txtBuMen.Text = Model.BuMen.ToString();
            this.txtXingBie.Text = Model.XingBie.ToString();
            this.txtChuShengRiQi.Text = Model.ChuShengRiQi.ToString();
            this.txtXueLi.Text = Model.XueLi.ToString();
            this.txtXueWei.Text = Model.XueWei.ToString();
            this.txtXueKe.Text = Model.XueKe.ToString();
            this.txtYanJiuLingYu.Text = Model.YanJiuLingYu.ToString();
            this.txtZhiWu.Text = Model.ZhiWu.ToString();
            this.txtZhiCheng.Text = Model.ZhiCheng.ToString();
            this.txtTimeStr.Text = Model.TimeStr.ToString();
            this.txtResearchFind.Text = Model.ResearchFind.ToString();
            this.txtNation.Text = Model.Nation.ToString();
            this.txtPolitical.Text = Model.Political.ToString();
            this.txtJianJie.Text = Model.JianJie.ToString();
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.FuJianStr);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
            this.Image1.ImageUrl = "../UploadFile/" + Model.PortraitPath;
           
            if (Model.States == 1 || Model.States == 2)
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的专家信息不能修改！", "ZhuanJia.aspx");
                return;
            }
            //this.txtUserName.Text = Model.UserName.ToString();
            //this.txtTimeStr.Text = Model.TimeStr.ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //string username = LCX.Common.PublicMethod.GetSessionValue("UserName");
        string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload2, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload2.PostedFile.FileName));
        LCX.BLL.ZhuanJia Model = new LCX.BLL.ZhuanJia();
        Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
        // ,,,,,,,,,,,,JianJie,FuJianStr,UserName
        Model.ID = int.Parse(Request.QueryString["ID"].ToString());
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
        Model.TimeStr = DateTime.Parse(this.txtTimeStr.Text);
        //Model.TimeStr = DateTime.Now;
        Model.ResearchFind = this.txtResearchFind.Text.ToString();
        Model.Nation = this.txtNation.Text.ToString();
        Model.Political = this.txtPolitical.Text.ToString();
        Model.JianJie = this.txtJianJie.Text.ToString();
        Model.FuJianStr = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        Model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        if (FileNameStr != "")
        {
            Model.PortraitPath = FileNameStr;
        }
        if (Model.States == 1 || Model.States == 2)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的专家信息不能修改！", "ZhuanJia.aspx");
            return;
        }
        else
        {
                Model.Update();
                //写系统日志
                LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
                MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
                MyRiZhi.DoSomething = "用户修改专家信息(" + this.txtXingMing.Text + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                MyRiZhi.Add();

           
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
