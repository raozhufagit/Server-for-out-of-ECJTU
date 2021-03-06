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

public partial class Work_TongXunLuAdd : System.Web.UI.Page
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
        LCX.BLL.LCXMail_List Model = new LCX.BLL.LCXMail_List();
        Model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        Model.IfShare = this.RadioButtonList1.SelectedItem.Text;
        Model.TypeStr = Request.QueryString["TypeStr"].ToString();
        Model.FenZu = this.TextBox1.Text.Trim();
        Model.NameStr = this.TextBox2.Text.Trim();
        Model.Sex = this.TextBox3.Text.Trim();
        Model.BirthDay = this.TextBox4.Text.Trim();
        Model.NiCheng = this.TextBox5.Text.Trim();
        Model.ZhiWu = this.TextBox6.Text.Trim();
        Model.PeiOu = this.TextBox7.Text.Trim();
        Model.ZiNv = this.TextBox8.Text.Trim();
        Model.DanWeiMingCheng = this.TextBox9.Text.Trim();
        Model.DanWeiDiZhi = this.TextBox10.Text.Trim();
        Model.DanWeiYouBian = this.TextBox11.Text.Trim();
        Model.DanWieDianHua = this.TextBox12.Text.Trim();
        Model.DanWeiChuanZhen = this.TextBox13.Text.Trim();
        Model.JiaTingZhuZhi = this.TextBox14.Text.Trim();
        Model.JiaTingYouBian = this.TextBox15.Text.Trim();
        Model.JiaTingDianHua = this.TextBox16.Text.Trim();
        Model.ShouJi = this.TextBox17.Text.Trim();
        Model.XiaoLingTong = this.TextBox18.Text.Trim();
        Model.Email = this.TextBox19.Text.Trim();
        Model.QQ = this.TextBox20.Text.Trim();
        Model.Msn = this.TextBox21.Text.Trim();
        Model.BackInfo = this.TxtContent.Text;
        Model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加联系人信息(" + this.TextBox1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "联系人信息添加成功！", "TongXunLu.aspx?TypeStr=" + Request.QueryString["TypeStr"].ToString());
    }
}