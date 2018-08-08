using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScDetail11 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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
            int id;
            try
            {
                id = Int32.Parse(Request.QueryString["ID"].ToString());
            }
            catch (Exception ex)
            {

                LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！", ViewState["UrlReferrer"].ToString());
                return;
            }

            //权限判断
            LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
            if (!LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", "," + scSet.sc_JUser + ","))
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "你没有权限审批生产明细单！", ViewState["UrlReferrer"].ToString());
                return;
            }


            LCX.BLL.LCXManuPc model = new LCX.BLL.LCXManuPc();
            model.GetModel(id);
            this.lbPc_Name.Text = model.Pc_Name;
            this.lbPc_Vesion.Text = model.Pc_Vesion;
            this.lbPc_UserName.Text = model.Pc_UserName;
            if (model.Pc_Timer != Convert.ToDateTime(null))
            {
                this.lbPc_Timer.Text = model.Pc_Timer.ToString();
            }
            this.lbPc_mark.Text = model.Pc_mark;


            this.lbPc_JsSp.Text = model.Pc_JsSp;
            this.lbPc_Jsyj.Text = model.Pc_Jsyj;
            if (model.Pc_JsStime != Convert.ToDateTime(null))
            {
                this.lbPc_JsStime.Text = model.Pc_JsStime.ToString();
            }


            if (model.Pc_State == 0)
            {
                this.lbPc_State.Text = "等待技术审核";
            }
            else if (model.Pc_State == 1)
            {
                this.lbPc_State.Text = "技术审核拒绝";
            }
            else if (model.Pc_State == 2)
            {
                this.lbPc_State.Text = "<font color=\"#fff000\">等待归档审核</font>";
            }
            else if (model.Pc_State == 3)
            {
                this.lbPc_State.Text = "审核拒绝";
            }
            else if (model.Pc_State == 4)
            {
                this.lbPc_State.Text = "审核通过";
            }
            else if (model.Pc_State == 5)
            {
                this.lbPc_State.Text = "版本禁用";
            }
            else
            {
                this.lbPc_State.Text = "未知状态";
            }
            this.lbPc_Wenjian.Text = LCX.Common.PublicMethod.GetWenJian(model.Pc_Wenjian, "../UploadFile/"); 
        }
    }
    protected void subPass(object sender, EventArgs e)
    {
        LCX.BLL.LCXManuPc model = new LCX.BLL.LCXManuPc();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString())); 
        if (model.Pc_State !=2)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "当前生产明细单状态改变，不允许审核！", ViewState["UrlReferrer"].ToString());
            return;
        }
        model.Pc_JsSp = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.Pc_JsStime = DateTime.Now;
        model.Pc_State = 4;
        model.Pc_Jsyj = this.txtPc_Jsyj.Text.Trim();

        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }

        //发送通知
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "审批了生产明细单【" + model.Pc_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.Pc_JsSp + "审批了生产进度信息(" + model.Pc_Name + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Update();
        LCX.Common.MessageBox.ShowAndRedirect(this, "生产明细单审批成功！", ViewState["UrlReferrer"].ToString());
    }
    protected void subRefuse(object sender, EventArgs e)
    {
        LCX.BLL.LCXManuPc model = new LCX.BLL.LCXManuPc();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
        if (model.Pc_State != 2)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "当前生产明细单状态改变，不允许拒绝审核！", ViewState["UrlReferrer"].ToString());
            return;
        }
        model.Pc_JsSp = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.Pc_JsStime = DateTime.Now;
        model.Pc_State = 3;
        model.Pc_Jsyj = this.txtPc_Jsyj.Text.Trim();

        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }

        //发送通知
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "拒绝审批了生产明细单【" + model.Pc_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.Pc_JsSp + "拒绝了生产进度信息(" + model.Pc_Name + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Update();
        LCX.Common.MessageBox.ShowAndRedirect(this, "生产明细单审批成功！", ViewState["UrlReferrer"].ToString());
    }
}