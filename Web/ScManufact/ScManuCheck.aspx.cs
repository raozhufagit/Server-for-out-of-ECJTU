using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScManuCheck : System.Web.UI.Page
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
            int id = 9;
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
            if (!LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", "," + scSet.jd_SUser + ","))
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "你没有权限添加明细单！", ViewState["UrlReferrer"].ToString());
                return;
            }


            LCX.BLL.LCXManuPro model = new LCX.BLL.LCXManuPro();
            model.GetModel(id);
            this.lbJd_Name.Text = model.Jd_Name;
            this.lbJd_Pic2.NavigateUrl = "ScManuView2.aspx?ID="+id; 

            if (model.Jd_Time != Convert.ToDateTime(null))
            {
                this.lbJd_Time.Text = model.Jd_Time.ToString();
            }
            if (model.Jd_OverTime != Convert.ToDateTime(null))
            {
                this.lbJd_OverTime.Text = model.Jd_OverTime.ToString();
            }
            this.lbJd_Content.Text = model.Jd_Content;
            switch (model.Jd_State)
            {
                case 0: { this.lbJd_State.Text = "等待审核"; break; }
                case 1: { this.lbJd_State.Text = "审核拒绝"; break; }
                case 2: { this.lbJd_State.Text = "<font color=\"#fff000\">禁用</font>"; break; }
                case 3: { this.lbJd_State.Text = "审核通过"; break; }
                case 4: { this.lbJd_State.Text = "草稿版本"; break; }
                default: { this.lbJd_State.Text = "状态未知"; break; }
            }
            this.lbJd_Fujian.Text = LCX.Common.PublicMethod.GetWenJian(model.Jd_Fujian, "../UploadFile/");
        }
    }
    protected void subPass(object sender, EventArgs e)
    {
        LCX.BLL.LCXManuPro model = new LCX.BLL.LCXManuPro();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
        
        if (model.Jd_State == 0 || model.Jd_State == 4)
        {
          
        }
        else
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的生产进度不需再审核！", ViewState["UrlReferrer"].ToString());
            return;
        }
        try
        {
            File.Copy(Server.MapPath("xml/") + model.Jd_Pic2, Server.MapPath("xml/ok") + model.Jd_Pic2, true);
        }
        catch (Exception ex)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "文件复制不成功！", ViewState["UrlReferrer"].ToString());
            return;
        }
        

        model.Jd_Spr = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.Jd_SpTime = DateTime.Now;
        model.Jd_State = 3;
        model.Jd_Pic = "ok"+model.Jd_Pic2;
        model.Jd_SpYj = this.txtJd_SpYj.Text.Trim();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }

        //发送通知
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "审批了生产订单【" + model.Jd_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.Jd_Spr + "审批了生产进度信息(" + model.Jd_Name + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Update();
        LCX.Common.MessageBox.ShowAndRedirect(this, "生产进度审批成功！", ViewState["UrlReferrer"].ToString());
    }
    protected void subRefuse(object sender, EventArgs e)
    {
        LCX.BLL.LCXManuPro model = new LCX.BLL.LCXManuPro();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        if (model.Jd_State == 0 || model.Jd_State == 4)
        {

        }
        else
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的生产进度不需再审核！", ViewState["UrlReferrer"].ToString());
            return;
        }

        model.Jd_Spr = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.Jd_SpTime = DateTime.Now;
        model.Jd_State = 1;
        model.Jd_SpYj = this.txtJd_SpYj.Text.Trim();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }

        //发送通知
        SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "拒绝了生产订单【" + model.Jd_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = model.Jd_Spr + "拒绝了生产进度信息(" + model.Jd_Name + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Update();
        LCX.Common.MessageBox.ShowAndRedirect(this, "生产进度拒绝成功！", ViewState["UrlReferrer"].ToString());
    }
}