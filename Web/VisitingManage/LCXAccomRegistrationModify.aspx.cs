﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class VisitingManage_LCXAccomRegistrationModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXAccomRegistration Model = new LCX.BLL.LCXAccomRegistration();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtOutVisiting.Text = Model.OutVisiting.ToString();
            this.txtAccommationSite.Text = Model.AccommationSite.ToString();
            this.txtPeopleNum.Text = Model.PeopleNum.ToString();
            this.txtCostNum.Text = Model.CostNum.ToString();
            this.txtAccomTime.Text = Model.AccomTime.ToString();
            this.txtRemarks.Text = Model.Remarks.ToString();


        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXAccomRegistration Model = new LCX.BLL.LCXAccomRegistration();

        // ,,,,,,,,,,,,JianJie,FuJianStr,UserName
        Model.OutVisiting = this.txtOutVisiting.Text.ToString();
        Model.AccommationSite = this.txtAccommationSite.Text.ToString();
        Model.PeopleNum = int.Parse(this.txtPeopleNum.Text.ToString());
        Model.CostNum = int.Parse(this.txtCostNum.Text.ToString());
        Model.AccomTime = DateTime.Parse(this.txtAccomTime.Text);
        Model.Remarks = this.txtRemarks.Text.ToString();

        Model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改住宿信息(" + this.txtOutVisiting.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "住宿信息修改成功！", "LCXAccomRegistrationN.aspx");
    }
}