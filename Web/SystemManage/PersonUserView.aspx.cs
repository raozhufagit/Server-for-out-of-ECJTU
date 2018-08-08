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

public partial class SystemManage_PersonUserView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string username = LCX.Common.PublicMethod.GetSessionValue("UserName");
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.BLL.LCXUser Model = new LCX.BLL.LCXUser();
            string UID = DbHelperSQL.GetSHSLInt(" select ID from LCXUser where UserName='"+username+"'");
            Model.GetModel(int.Parse(UID));
            this.lblUserName.Text = Model.UserName.ToString();
            this.lblSerils.Text = Model.Serils.ToString();
            this.Image1.ImageUrl = "../UploadFile/" + Model.PortraitPath;
            this.lblTrueName.Text = Model.TrueName.ToString();
            this.lblSex.Text = Model.Sex.ToString();
            this.lblZhengZhiMianMao.Text = Model.ZhengZhiMianMao.ToString();
            this.lblMingZu.Text = Model.MingZu.ToString();
            this.lblBirthDay.Text = string.Format("{0:d}", Model.BirthDay);
            this.lblXueLi.Text = Model.XueLi.ToString();
            this.lblJiGuan.Text = Model.JiGuan.ToString();
            this.lblHunYing.Text = Model.HunYing.ToString();
            this.lblDepartment.Text = Model.Department.ToString();
            this.lblZhiCheng.Text = Model.ZhiCheng.ToString();
            this.lblBiYeYuanXiao.Text = Model.BiYeYuanXiao.ToString();
            this.lblZhuanYe.Text =  Model.ZhuanYe.ToString();
            this.lblEmailStr.Text = Model.EmailStr.ToString();
            this.lblJiaoSe.Text = Model.JiaoSe.ToString();
            this.lblZaiGang.Text = Model.ZaiGang.ToString();
            this.lblBackInfo.Text = Model.BackInfo.ToString();
            
            this.lblFuJian.Text = LCX.Common.PublicMethod.GetWenJian(Model.FuJian, "../UploadFile/");
            //LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.FuJianStr);
            //LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
            //this.HyperLink1.Text = Model.PortraitPath;
            //this.HyperLink1.NavigateUrl = "../UploadFile/" + Model.PortraitPath;

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看专家信息(" + this.lblTrueName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

        }
    }
}