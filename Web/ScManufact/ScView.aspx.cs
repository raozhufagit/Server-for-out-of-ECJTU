using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXManuFact model = new LCX.BLL.LCXManuFact();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
            string username = LCX.Common.PublicMethod.GetSessionValue("UserName");
            if (LCX.Common.PublicMethod.StrIFIn("," + username + ",", "," + scSet.dd_User + ",") || model.Sc_Tjr == username)
            {
            }
            else
            { 
                LCX.Common.MessageBox.ShowAndRedirect(this, "您没有权限查看此订单信息！", "ScManage.aspx");
                return; 
            }
              
            this.lbSc_Name.Text = model.Sc_Name;
            this.lbSc_Custmoer.Text = model.Sc_Custmoer;
            if (model.Sc_Jtime != Convert.ToDateTime(null))
            {
                this.lbSc_Jtime.Text = model.Sc_Jtime.ToString();
            }
            this.lbSc_Tjr.Text=model.Sc_Tjr;
           
            if (model.Sc_Timer != Convert.ToDateTime(null))
            {
                this.lbSc_Timer.Text = model.Sc_Timer.ToString();
            }
            if (model.Sc_SpTime != Convert.ToDateTime(null))
            {
                this.lbSc_SpTime.Text = model.Sc_SpTime.ToString();
            }
            this.lbSc_Spr.Text=model.Sc_Spr;
            this.lbSc_Yij.Text=model.Sc_Yij;
            this.lbSc_State.Text="0";
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
            this.HyperLink1.NavigateUrl = "ScDetail.aspx?ID=" + model.ID; //转向详细信息
            this.HyperLink2.NavigateUrl = "ScManuPro.aspx?ID=" + model.ID;//转到详细进度
                        
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看项目信息(" + this.lbSc_Name.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}