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

public partial class SystemManage_SystemJiaoSeUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            this.Label1.Text = Request.QueryString["JiaoSeName"].ToString();

            this.TextBox1.Text = ReturnUserInJiaoSe(Request.QueryString["JiaoSeName"].ToString());
        }
    }

    public string ReturnUserInJiaoSe(string JiaoSeName)
    {
        string ReturnStr = "";
        DataSet MYDT = LCX.DBUtility.DbHelperSQL.GetDataSet("select UserName from LCXUser where ','+JiaoSe+','  like  '%," + JiaoSeName + ",%'");
        for (int i = 0; i < MYDT.Tables[0].Rows.Count; i++)
        {
            if (ReturnStr.Trim().Length > 0)
            {
                ReturnStr =ReturnStr+","+ MYDT.Tables[0].Rows[i]["UserName"].ToString();
            }
            else
            {
                ReturnStr = MYDT.Tables[0].Rows[i]["UserName"].ToString();
            }
        }
        return ReturnStr;
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //设置所有在文本框中的用户角色加上当前角色，先去掉所有角色，再加上对应角色
        string InitJiaoSeSql = "update LCXUser Set JiaoSe=','+JiaoSe+','";
        string RemoveJiaoSeSql = "update LCXUser Set JiaoSe=replace(JiaoSe,'," + Request.QueryString["JiaoSeName"].ToString() + ",',',') ";        
        //替换后，如果只有这个角色，那么替换后，只有 ， 所以加入一个，防止Sql运行出错
        string OKKTemp = "update LCXUser Set JiaoSe=',,' where JiaoSe=','";
        string OKJiaoSeSql1 = "update LCXUser Set JiaoSe=left(JiaoSe,len(JiaoSe)-1)";
        string OKJiaoSeSql2 = "update LCXUser Set JiaoSe=right(JiaoSe,len(JiaoSe)-1)";

        string AddJiaoSeSql1 = "update LCXUser Set JiaoSe='" + Request.QueryString["JiaoSeName"].ToString() + "'   where len(JiaoSe)<=1 and UserName in('" + this.TextBox1.Text.ToString().Replace(",", "','") + "')";
        string AddJiaoSeSql2 = "update LCXUser Set JiaoSe=JiaoSe+'," + Request.QueryString["JiaoSeName"].ToString() + "'   where len(JiaoSe)>1 and JiaoSe!='" + Request.QueryString["JiaoSeName"].ToString() + "' and UserName in('" + this.TextBox1.Text.ToString().Replace(",", "','") + "')";

        LCX.DBUtility.DbHelperSQL.ExecuteSQL(InitJiaoSeSql);
        LCX.DBUtility.DbHelperSQL.ExecuteSQL(RemoveJiaoSeSql);
        LCX.DBUtility.DbHelperSQL.ExecuteSQL(OKKTemp);
        LCX.DBUtility.DbHelperSQL.ExecuteSQL(OKJiaoSeSql1);
        LCX.DBUtility.DbHelperSQL.ExecuteSQL(OKJiaoSeSql2);
        LCX.DBUtility.DbHelperSQL.ExecuteSQL(AddJiaoSeSql1);
        LCX.DBUtility.DbHelperSQL.ExecuteSQL(AddJiaoSeSql2);

        LCX.Common.MessageBox.ShowAndRedirect(this, "角色用户设置成功！", "SystemJiaoSe.aspx");
    }
}
