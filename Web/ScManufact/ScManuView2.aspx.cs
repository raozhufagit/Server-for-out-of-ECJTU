using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScManuView2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
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
}