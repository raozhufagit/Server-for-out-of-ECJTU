using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_ScMpView : System.Web.UI.Page
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
            LCX.BLL.LCXManuPro model = new LCX.BLL.LCXManuPro();
            model.GetModel(id);
             
            this.lbJd_Name.Text = model.Jd_Name; 
            if (model.Jd_Time != Convert.ToDateTime(null))
            {
                this.lbJd_Time.Text = model.Jd_Time.ToString();
            }
            if (model.Jd_OverTime != Convert.ToDateTime(null))
            {
                this.lbJd_OverTime.Text = model.Jd_OverTime.ToString();
            } 
            this.lbJd_Spr.Text = model.Jd_Spr;
            if (model.Jd_SpTime != Convert.ToDateTime(null))
            {
                this.lbJd_SpTime.Text = model.Jd_SpTime.ToString();
            }
            this.lbJd_SpYj.Text = model.Jd_SpYj; 
            this.lbJd_Content.Text = model.Jd_Content;   

            switch (model.Jd_State)
            {
                case 0: { this.lbJd_State.Text = "等待审核"; break; }
                case 1: { this.lbJd_State.Text = "审核拒绝"; break; }
                case 2: { this.lbJd_State.Text = "禁用"; break; }
                case 3: { this.lbJd_State.Text = "审核通过"; break; }
                case 4: { this.lbJd_State.Text = "等待更新"; break; }
                default: { this.lbJd_State.Text = "状态未知"; break; }
            }

            this.lbJd_Fujian.Text = LCX.Common.PublicMethod.GetWenJian(model.Jd_Fujian, "../UploadFile/");
        }
    }
}

