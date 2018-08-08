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

public partial class SystemManage_BuMenInfoModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXDept MyBuMen = new LCX.BLL.LCXDept();
            MyBuMen.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.TextBox1.Text = MyBuMen.BuMenName;
            this.TextBox2.Text = MyBuMen.ChargeMan;
            this.TextBox3.Text = MyBuMen.TelStr;
            this.TextBox4.Text = MyBuMen.ChuanZhen;
            this.TextBox5.Text = MyBuMen.BackInfo;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {     
        if (LCX.Common.PublicMethod.IFExists("BuMenName", "LCXDept", int.Parse(Request.QueryString["ID"].ToString()), this.TextBox1.Text) == true)
        {
           
            LCX.BLL.LCXDept MyBuMen = new LCX.BLL.LCXDept();
            MyBuMen.ID = int.Parse(Request.QueryString["ID"].ToString());
            MyBuMen.GetModel(MyBuMen.ID);
            string oldRtxDept = MyBuMen.BuMenName;

            MyBuMen.BuMenName = this.TextBox1.Text;
            MyBuMen.ChargeMan = this.TextBox2.Text;
            MyBuMen.TelStr = this.TextBox3.Text;
            MyBuMen.ChuanZhen = this.TextBox4.Text;
            MyBuMen.BackInfo = this.TextBox5.Text;
            MyBuMen.DirID = int.Parse(Request.QueryString["DirID"].ToString());
            MyBuMen.Update();

            if (System.Configuration.ConfigurationManager.AppSettings["rtx"] == "1")
            {
                if (Rtx.IsDeptExist(oldRtxDept) != 1)
                {
                    LCX.Common.MessageBox.Show(this, "部门不存在！");
                    return;
                }
                else
                {
                    if (!Rtx.updateDeapart(oldRtxDept, this.TextBox1.Text))
                    {
                        LCX.Common.MessageBox.Show(this, "该部门在系统中修改失败，请检查系统服务器！");
                    }
                } 
            }






            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户修改部门信息(" + this.TextBox1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            LCX.Common.MessageBox.ShowAndRedirect(this, "部门信息添加成功！", "BuMenInfo.aspx?View="+Request.QueryString["View"].ToString()+"&Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + Request.QueryString["DirID"].ToString());
        }
        else
        {
            LCX.Common.MessageBox.Show(this, "该部门已经存在，请更换名称！");
        }
    }
}
