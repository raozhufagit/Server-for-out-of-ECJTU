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

public partial class SystemManage_SystemJiaoSeView : System.Web.UI.Page
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
            this.Label1.Text = MyModel.JiaoSeName;
            this.Label2.Text = MyModel.BackInfo;
            LCX.Common.PublicMethod.GetCheckList(this.CheckBoxList1, MyModel.QuanXian);

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看角色信息(" + this.Label1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

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
}
