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

public partial class Project_LiRunAdd : System.Web.UI.Page
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
        LCX.BLL.LCXLiRun model = new LCX.BLL.LCXLiRun();
        model.ProjectName = this.txtProjectName.Text;
        model.ProjectSerils = this.txtProjectSerils.Text;
        model.SumJinE = this.txtSumJinE.Text;
        model.FeiYong = this.txtFeiYong.Text;
        model.ChengBen = this.txtChengBen.Text;
        model.FangZu = this.txtFangZu.Text;
        model.ShuiE = this.txtShuiE.Text;
        model.GongZi = this.txtGongZi.Text;
        model.TiCheng = this.txtTiCheng.Text;
        model.QiTa = this.txtQiTa.Text;
        model.ShiJi = this.txtShiJi.Text;
        model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.TimeStr = DateTime.Now;
        model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加利润核算信息(" + this.txtProjectName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "利润核算信息添加成功！", "LiRuiGuanLi.aspx?ProjectName=" + Request.QueryString["ProjectName"].ToString());
    }
}