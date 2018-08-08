using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScDetailView : System.Web.UI.Page
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
                Response.Redirect(ViewState["UrlReferrer"].ToString());  
               // LCX.Common.MessageBox.Show(this, "ID参数不正确！");
                return;
            }
            int id = 9;
            try
            {
                id = Int32.Parse(Request.QueryString["ID"].ToString());
            }
            catch (Exception ex)
            {
                Response.Redirect(ViewState["UrlReferrer"].ToString());  
                //LCX.Common.MessageBox.Show(this, "ID参数不正确！");
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
            this.lbPc_JsSp.Text = model.Pc_JsSp;
            if (model.Pc_JsStime != Convert.ToDateTime(null))
            {
                this.lbPc_JsStime.Text = model.Pc_JsStime.ToString();
            }
            this.lbPc_Jsyj.Text = model.Pc_Jsyj;
            this.lbPc_SpUser.Text = model.Pc_SpUser;

            if (model.Pc_SpTimer != Convert.ToDateTime(null))
            {
                this.lbPc_SpTimer.Text = model.Pc_SpTimer.ToString();
            }
            this.lbPc_Yj.Text = model.Pc_Yj; 
            this.lbPc_mark.Text = model.Pc_mark; 
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
}