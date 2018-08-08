using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScManuPic2 : System.Web.UI.Page
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
                LCX.Common.MessageBox.Show(this, "ID参数不正确！");
                return;
            }
            int id = 9;
            try
            {
                id = Int32.Parse(Request.QueryString["ID"].ToString());
            }
            catch (Exception ex)
            {
                LCX.Common.MessageBox.Show(this, "ID参数不正确！");
                return;
            } 
          
        }
    }
    public string jd_pic2()
    {
        LCX.BLL.LCXManuPro model = new LCX.BLL.LCXManuPro();
        model.GetModel(Int32.Parse(Request.QueryString["ID"].ToString()));
        return model.Jd_Pic2;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect(ViewState["UrlReferrer"].ToString());
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //进度表更新
        LCX.BLL.LCXScSeting scSet = new LCX.BLL.LCXScSeting();
        if (!LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", "," + scSet.jd_User + ","))
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "你没有权限更新进度表！", ViewState["UrlReferrer"].ToString());
            return;
        }


        LCX.BLL.LCXManuPro model = new LCX.BLL.LCXManuPro();
        model.GetModel(Int32.Parse(Request.QueryString["ID"].ToString()));
        model.Jd_State = 4;
        if (model.Update() > 0)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "提交审核成功！", ViewState["UrlReferrer"].ToString());
        }
        else
        {
            LCX.Common.MessageBox.Show(this, "提交审核失败！");
        }
    }
}