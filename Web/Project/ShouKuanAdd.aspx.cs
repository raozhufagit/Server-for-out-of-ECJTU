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

public partial class Project_ShouKuanAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXShouKuan model = new LCX.BLL.LCXShouKuan();
        model.ProjectName = this.txtProjectName.Text;
        model.ProjectSerils = this.txtProjectSerils.Text;
        model.JieDuanName = this.txtJieDuanName.Text;
        model.ShouKuanE = this.txtShouKuanE.Text;
        model.FaPiaoHao = this.txtFaPiaoHao.Text;
        model.ShouKuanDate = this.txtShouKuanDate.Text;
        model.DaoKuanDate = this.txtDaoKuanDate.Text;
        model.ShengYuE = this.txtShengYuE.Text;
        model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.TimeStr = DateTime.Now;
        model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加收款信息(" + this.txtProjectName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "收款信息添加成功！", "ShouKuan.aspx?ProjectName=" + Request.QueryString["ProjectName"].ToString());
    }
}