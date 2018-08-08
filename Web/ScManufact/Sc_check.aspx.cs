using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_Sc_check : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXManuFact model = new LCX.BLL.LCXManuFact();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString())); 
            
            LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
             if (!LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", "," + scSet.dd_User + ","))
             {
                 LCX.Common.MessageBox.ShowAndRedirect(this, "您没有权限审批此订单信息！", "ScManage.aspx");
                 return;
             } 
             
            this.lbSc_Name.Text = model.Sc_Name;
            this.lbSc_Custmoer.Text = model.Sc_Custmoer;
            if (model.Sc_Jtime != Convert.ToDateTime(null))
            {
                this.lbSc_Jtime.Text = model.Sc_Jtime.ToString();
            }
         
            this.lbSc_Tjr.Text = model.Sc_Tjr;

            if (model.Sc_Timer != Convert.ToDateTime(null))
            {
                this.lbSc_Timer.Text = model.Sc_Timer.ToString();
            }
          
            this.lbSc_State.Text = "0";
            if (model.Sc_State == 0)
            {
                this.lbSc_State.Text = "等待审核";

            }
            else if (model.Sc_State == 1)
            {
                this.lbSc_State.Text = "审核拒绝";
            }
            else if (model.Sc_State == 2)
            {
                this.lbSc_State.Text = "<font color=\"#fff000\">审核通过</font>";
            }
            else
            {
                this.lbSc_State.Text = "订单取消";
            }
            this.lbSc_Maoshu.Text = model.Sc_Maoshu;
            this.lblSc_Fuj.Text = LCX.Common.PublicMethod.GetWenJian(model.Sc_Fuj, "../UploadFile/");


            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看项目信息(" + this.lbSc_Name.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }

    }
    protected void subPass(object sender, EventArgs e)
    {
        LCX.BLL.LCXManuFact model = new LCX.BLL.LCXManuFact();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString())); 
        model.Sc_Spr = LCX.Common.PublicMethod.GetSessionValue("UserName"); 
        model.Sc_SpTime = DateTime.Now;
        if (model.Sc_State == 2)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的订单信息不能修改！", "ScManage.aspx");
            return;
        }
        model.Sc_State = 2;
        model.Sc_Yij = this.txtSc_Yij.Text.Trim();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }
        //发送通知
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "审批了生产订单【" + model.Sc_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()), HttpContext.Current.Request.Url.Host + "/ScManufact/ScView.aspx?ID=" + model.ID);

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.Sc_Tjr + "审批了生产订单信息(" + model.Sc_Name + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Update();
        LCX.Common.MessageBox.ShowAndRedirect(this, "生产订单审批成功！", "ScManage.aspx");
    }
    protected void subRefuse(object sender, EventArgs e)
    {
        LCX.BLL.LCXManuFact model = new LCX.BLL.LCXManuFact();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString())); 
        model.Sc_Spr = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.Sc_SpTime = DateTime.Now;
        if (model.Sc_State == 2)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的订单信息不能修改！", "ScManage.aspx");
            return;
        }
        model.Sc_State = 1;
        model.Sc_Yij = this.txtSc_Yij.Text.Trim();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }
        //发送通知
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "拒绝审批了生产订单【" + model.Sc_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()), HttpContext.Current.Request.Url.Host + "/ScManufact/ScView.aspx?ID=" + model.ID);

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.Sc_Tjr + "拒绝审批了生产订单信息(" + model.Sc_Name + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Update();
        LCX.Common.MessageBox.ShowAndRedirect(this, "拒绝审批生产订单成功！", "ScManage.aspx");
    }
}