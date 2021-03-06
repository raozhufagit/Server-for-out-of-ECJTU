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

public partial class SystemManage_SystemJiaoSeModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();

            //加载节点进入CheCkBoxList中
            LCX.Common.PublicMethod.AddItmesInCheCKList(this.CheckBoxList1);

            LCX.BLL.LCXRole_Info MyModel = new LCX.BLL.LCXRole_Info();
            MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.TextBox1.Text = MyModel.JiaoSeName;
            this.TextBox2.Text = MyModel.BackInfo;
            LCX.Common.PublicMethod.GetCheckList(this.CheckBoxList1, MyModel.QuanXian);
            for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)
            {
                if (this.CheckBoxList1.Items[i].Text.Trim() == "")
                {
                    this.CheckBoxList1.Items[i].Enabled = false;
                    this.CheckBoxList1.Items[i].Attributes.CssStyle.Add("DISPLAY", "none");
                }
            }
        }
    }



    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (LCX.Common.PublicMethod.IFExists("JiaoSeName", "LCXRole_Info", int.Parse(Request.QueryString["ID"].ToString()), this.TextBox1.Text) == true)
        {
            LCX.BLL.LCXRole_Info MyModel = new LCX.BLL.LCXRole_Info();
            MyModel.ID = int.Parse(Request.QueryString["ID"].ToString());
            MyModel.JiaoSeName = this.TextBox1.Text;
            MyModel.BackInfo = this.TextBox2.Text;
            MyModel.QuanXian = LCX.Common.PublicMethod.GetStringFromCheckList(this.CheckBoxList1);
            MyModel.Update();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户修改角色信息(" + this.TextBox1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            LCX.Common.MessageBox.ShowAndRedirect(this, "角色信息修改成功！", "SystemJiaoSe.aspx");
        }
        else
        {
            LCX.Common.MessageBox.Show(this, "该角色名已经存在，请更换其他名称！");
        }
    }
}
