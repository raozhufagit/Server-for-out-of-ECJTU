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

public partial class SystemManage_PersonUserModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string username = LCX.Common.PublicMethod.GetSessionValue("UserName");
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.BLL.LCXUser Model = new LCX.BLL.LCXUser();
            string UID = DbHelperSQL.GetSHSLInt(" select ID from LCXUser where UserName='" + username + "'");
            Model.GetModel(int.Parse(UID));
            //Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtUserName.Text = Model.UserName.ToString();
            this.txtSerils.Text = Model.Serils.ToString();
            //this.Image1.ImageUrl = "../UploadFile/" + Model.PortraitPath;
            this.txtTrueName.Text = Model.TrueName.ToString();
            this.txtSex.Text = Model.Sex.ToString();
            this.txtZhengZhiMianMao.Text = Model.ZhengZhiMianMao.ToString();
            this.txtMingZu.Text = Model.MingZu.ToString();
            this.txtBirthDay.Text = string.Format("{0:d}", Model.BirthDay);
            this.txtXueLi.Text = Model.XueLi.ToString();
            this.txtJiGuan.Text = Model.JiGuan.ToString();
            this.txtHunYing.Text = Model.HunYing.ToString();
            this.txtDepartment.Text = Model.Department.ToString();
            this.txtZhiCheng.Text = Model.ZhiCheng.ToString();
            this.txtBiYeYuanXiao.Text = Model.BiYeYuanXiao.ToString();
            this.txtZhuanYe.Text = Model.ZhuanYe.ToString();
            this.txtEmailStr.Text = Model.EmailStr.ToString();
            this.txtJiaoSe.Text = Model.JiaoSe.ToString();
            this.txtZaiGang.Text = Model.ZaiGang.ToString();
            this.txtBackInfo.Text = Model.BackInfo.ToString();
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.FuJian);
            //this.txtFuJian.Text = LCX.Common.PublicMethod.GetWenJian(Model.FuJian, "../UploadFile/");

           
        }
    }

    protected void subPass(object sender, EventArgs e)
    {
            string username = LCX.Common.PublicMethod.GetSessionValue("UserName");
            string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload2, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload2.PostedFile.FileName));
            LCX.BLL.LCXUser Model = new LCX.BLL.LCXUser();
            //Model.ID = int.Parse(Request.QueryString["ID"].ToString());
            string UID = DbHelperSQL.GetSHSLInt(" select ID from LCXUser where UserName='" + username + "'");
            Model.GetModel(int.Parse(UID));
            Model.ID = int.Parse(UID);
            Model.UserName= this.txtUserName.Text.ToString();
            Model.Serils= this.txtSerils.Text.ToString();
        //this.Image1.ImageUrl = "../UploadFile/" + Model.PortraitPath;
            Model.TrueName= this.txtTrueName.Text.ToString();
            Model.Sex= this.txtSex.Text.ToString();
            Model.ZhengZhiMianMao= this.txtZhengZhiMianMao.Text.ToString();
            Model.MingZu= this.txtMingZu.Text.ToString();
            Model.BirthDay= DateTime.Parse(this.txtBirthDay.Text.ToString());
            Model.XueLi= this.txtXueLi.Text.ToString();
            Model.JiGuan= this.txtJiGuan.Text.ToString();
            Model.HunYing= this.txtHunYing.Text.ToString();
            Model.Department= this.txtDepartment.Text.ToString();
            Model.ZhiCheng= this.txtZhiCheng.Text.ToString();
            Model.BiYeYuanXiao= this.txtBiYeYuanXiao.Text.ToString();
            Model.ZhuanYe= this.txtZhuanYe.Text.ToString();
            Model.EmailStr= this.txtEmailStr.Text.ToString();
            Model.JiaoSe= this.txtJiaoSe.Text.ToString();
            Model.ZaiGang= this.txtZaiGang.Text.ToString();
            Model.BackInfo= this.txtBackInfo.Text.ToString();
        
            
            Model.FuJian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
            Model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            if (FileNameStr != "")
            {
                Model.PortraitPath = FileNameStr;
            }
            Model.Update();
                //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户修改基本信息(" + this.txtTrueName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "基本信息修改成功！", "PersonUserView.aspx");

    }

    protected void subReturn(object sender, EventArgs e)
    {
        Response.Redirect("../SystemManage/PersonUserView.aspx");
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

