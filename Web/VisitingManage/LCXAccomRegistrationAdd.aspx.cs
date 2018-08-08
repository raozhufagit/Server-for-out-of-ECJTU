﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
public partial class VisitingManage_LCXAccomRegistrationAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
        MyRiZhi.DoSomething = "用户添加住宿信息(" + this.txtOutVisiting.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "住宿信息添加成功！", "LCXAccomRegistrationN.aspx");
    }
}