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

public partial class TelFile_FileView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.DBUtility.DbHelperSQL.BindDropDownList2("select * from LCXJSDIC where UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "'", this.DropDownList1, "DicName", "ID");


            LCX.BLL.LCXTelFile MyModel = new LCX.BLL.LCXTelFile();
            MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString().Trim()));
            this.Label1.Text=MyModel.TitleStr;
            this.Label2.Text=MyModel.FromUser;
            this.Label3.Text=MyModel.TimeStr.ToString();
            this.Label4.Text=MyModel.ToUser;
            this.Label5.Text=MyModel.YiJieShouRen;
            this.Label6.Text=MyModel.FileType;
            this.Label7.Text = LCX.Common.PublicMethod.GetWenJian(MyModel.FuJianStr, "../UploadFile/");
            this.Label8.Text=MyModel.ContentStr;
            this.Label9.Text = MyModel.ChuanYueYiJian;

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看文件(" + this.Label1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();            
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXTelFile set ChuanYueYiJian='" + this.Label9.Text + "<font color=#001EFF>" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "(" + DateTime.Now.ToString() + ")：</font>" + this.TextBox1.Text.Trim() + "<hr height=1px>" + "' where ID=" + Request.QueryString["ID"].ToString().Trim());
        this.Label9.Text = this.Label9.Text + "<font color=#001EFF>" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "(" + DateTime.Now.ToString() + ")：</font>" + this.TextBox1.Text.Trim() + "<hr height=1px>";
        this.TextBox1.Text = "";
        LCX.Common.MessageBox.Show(this, "传阅意见添加成功！");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        if (this.Label5.Text.Trim().Length > 0)
        {
            //判断是否在"已接收人"列表中存在
            if (LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", "," + this.Label5.Text + ",") == false)
            {
                LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXTelFile set QianShouHouIDList=QianShouHouIDList+'," + this.DropDownList1.SelectedItem.Value.ToString() + "',YiJieShouRen=YiJieShouRen+'," + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' where ID=" + Request.QueryString["ID"].ToString().Trim());
            }
            else
            {
                LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXTelFile set QianShouHouIDList=QianShouHouIDList+'," + this.DropDownList1.SelectedItem.Value.ToString() + "' where ID=" + Request.QueryString["ID"].ToString().Trim());
            }
        }
        else
        {
            LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXTelFile set  QianShouHouIDList=QianShouHouIDList+'," + this.DropDownList1.SelectedItem.Value.ToString() + "',YiJieShouRen='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' where ID=" + Request.QueryString["ID"].ToString().Trim());
        }
        LCX.Common.MessageBox.Show(this, "传阅文件签收成功！");
    }
}