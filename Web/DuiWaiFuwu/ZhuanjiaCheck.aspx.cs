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
using System.IO;

public partial class DuiWaiFuwu_ZhuanjiaCheck : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.BLL.ZhuanJia Model = new LCX.BLL.ZhuanJia();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblGongHao.Text = Model.GongHao.ToString();
            this.lblXingMing.Text = Model.XingMing.ToString();
            this.lblBuMen.Text = Model.BuMen.ToString();
            this.lblXingBie.Text = Model.XingBie.ToString();
            this.lblChuShengRiQi.Text = string.Format("{0:d}", Model.ChuShengRiQi);
            this.lblXueLi.Text = Model.XueLi.ToString();
            this.lblXueWei.Text = Model.XueWei.ToString();
            this.lblXueKe.Text = Model.XueKe.ToString();
            this.lblYanJiuLingYu.Text = Model.YanJiuLingYu.ToString();
            this.lblZhiWu.Text = Model.ZhiWu.ToString();
            this.lblZhiCheng.Text = Model.ZhiCheng.ToString();
            this.lblTimeStr.Text = string.Format("{0:d}", Model.TimeStr);
            this.lblResearchFind.Text = Model.ResearchFind.ToString();
            this.lblNation.Text = Model.Nation.ToString();
            this.lblPolitical.Text = Model.Political.ToString();
            this.lblJianJie.Text = Model.JianJie.ToString();
            this.Image1.ImageUrl = "../UploadFile/" + Model.PortraitPath;
            this.lblFuJianStr.Text = LCX.Common.PublicMethod.GetWenJian(Model.FuJianStr, "../UploadFile/");
            //LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.FuJianStr);
            //LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
            //this.HyperLink1.Text = Model.PortraitPath;
            //this.HyperLink1.NavigateUrl = "../UploadFile/" + Model.PortraitPath;
            if (Request.UrlReferrer != null)
            {
                ViewState["UrlReferrer"] = Request.UrlReferrer.ToString();
            }
            LCX.Common.PublicMethod.CheckSession();
            if (Request.QueryString["ID"] == null)
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！", ViewState["UrlReferrer"].ToString());
                return;
            }
            //获取传过来的ID值
            /*int id = 9;
            try
            {
                id = Int32.Parse(Request.QueryString["ID"].ToString());
            }
            catch (Exception ex)
            {

                LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！", ViewState["UrlReferrer"].ToString());
                return;
            }*/
            //判断审核状态
            switch(Model.States)
            {
                case 1: { this.lblStates.Text = "审核通过"; break; }
                case 2: { this.lblStates.Text = "审核不通过";break; }
                default: { this.lblStates.Text = "等待审核";break; }
            } 
        }

    }
    protected void subPass(object sender, EventArgs e)
    {
        LCX.BLL.ZhuanJia model = new LCX.BLL.ZhuanJia();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        if (model.States == 0 || String.Compare(model.States.ToString()," ")==0)
        {

        }
        else
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的专家信息不需再审核！", ViewState["UrlReferrer"].ToString());
            return;
        }


        string CheckUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.ID = int.Parse(Request.QueryString["ID"].ToString());
        model.CheckAdvision = this.txtCheckAdvision.Text;
        model.CheckTime = DateTime.Now;
        model.States = 1;
        //model.Update();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }

        //发送通知
        //SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "审批了生产订单【" + model.Jd_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = CheckUser + "审批了专家信息(" + model.XingMing + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "专家信息审批成功！", ViewState["UrlReferrer"].ToString());
    }
    protected void subRefuse(object sender, EventArgs e)
    {
        LCX.BLL.ZhuanJia model = new LCX.BLL.ZhuanJia();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        if (model.States == 0 || String.Compare(model.States.ToString(), " ") == 0)
        {

        }
        else
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的专家信息不需再审核！", ViewState["UrlReferrer"].ToString());
            return;
        }

        string CheckUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.ID = int.Parse(Request.QueryString["ID"].ToString());
        model.CheckAdvision = this.txtCheckAdvision.Text;
        model.CheckTime = DateTime.Now;
        model.States = 2;
       // model.Update();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }

        //发送通知
        //SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "拒绝了生产订单【" + model.Jd_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = CheckUser + "拒绝了专家审核信息(" + model.XingMing + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "专家审核拒绝成功！", ViewState["UrlReferrer"].ToString());
    }
}
