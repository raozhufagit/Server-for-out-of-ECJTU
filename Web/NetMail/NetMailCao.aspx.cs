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

public partial class NetMail_NetMailCao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataBindToGridview();

            //设定按钮权限
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|093A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|093M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|093D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|093E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }
    public void DataBindToGridview()
    {
        LCX.BLL.LCXNetEmail MyLanEmail = new LCX.BLL.LCXNetEmail();
        GVData.DataSource = MyLanEmail.GetList("EmailTitle like '%" + this.TextBox1.Text.Trim() + "%' and FromUser='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' and EmailState='草稿' order by ID desc");
        GVData.DataBind();
        LabPageSum.Text = Convert.ToString(GVData.PageCount);
        LabCurrentPage.Text = Convert.ToString(((int)GVData.PageIndex + 1));
        this.GoPage.Text = LabCurrentPage.Text.ToString();
    }
    #region  分页方法
    protected void ButtonGo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (GoPage.Text.Trim().ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('页码不可以为空!');</script>");
            }
            else if (GoPage.Text.Trim().ToString() == "0" || Convert.ToInt32(GoPage.Text.Trim().ToString()) > GVData.PageCount)
            {
                Response.Write("<script language='javascript'>alert('页码不是一个有效值!');</script>");
            }
            else if (GoPage.Text.Trim() != "")
            {
                int PageI = Int32.Parse(GoPage.Text.Trim()) - 1;
                if (PageI >= 0 && PageI < (GVData.PageCount))
                {
                    GVData.PageIndex = PageI;
                }
            }

            if (TxtPageSize.Text.Trim().ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('每页显示行数不可以为空!');</script>");
            }
            else if (TxtPageSize.Text.Trim().ToString() == "0")
            {
                Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
            }
            else if (TxtPageSize.Text.Trim() != "")
            {
                try
                {
                    int MyPageSize = int.Parse(TxtPageSize.Text.ToString().Trim());
                    this.GVData.PageSize = MyPageSize;
                }
                catch
                {
                    Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
                }
            }

            DataBindToGridview();
        }
        catch
        {
            DataBindToGridview();
            Response.Write("<script language='javascript'>alert('请输入有效数字！');</script>");
        }
    }
    protected void PagerButtonClick(object sender, ImageClickEventArgs e)
    {
        //获得Button的参数值
        string arg = ((ImageButton)sender).CommandName.ToString();
        switch (arg)
        {
            case ("Next"):
                if (this.GVData.PageIndex < (GVData.PageCount - 1))
                    GVData.PageIndex++;
                break;
            case ("Pre"):
                if (GVData.PageIndex > 0)
                    GVData.PageIndex--;
                break;
            case ("Last"):
                try
                {
                    GVData.PageIndex = (GVData.PageCount - 1);
                }
                catch
                {
                    GVData.PageIndex = 0;
                }

                break;
            default:
                //本页值
                GVData.PageIndex = 0;
                break;
        }
        DataBindToGridview();
    }
    #endregion
    protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LCX.Common.PublicMethod.GridViewRowDataBound(e);
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("NetEmailAdd.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string IDlist = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        if (LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXNetEmail set EmailState='已发' where ID in (" + IDlist + ")") == -1)
        {
            Response.Write("<script>alert('发送邮件时发生错误！请重新登陆后重试！');</script>");
        }
        else
        {
            string[] IDArray = IDlist.Split(',');
            for (int jk = 0; jk < IDArray.Length; jk++)
            {
                if (IDArray[jk].Trim().Length > 0 && IDArray[jk].Trim() != "0")
                {
                    LCX.BLL.LCXNetEmail MyModel = new LCX.BLL.LCXNetEmail();
                    MyModel.GetModel(int.Parse(IDArray[jk].Trim()));
                    //Jmail发送邮件到InterNet                    
                    LCX.BLL.LCXPOPAndSMTP MySMTPModel = new LCX.BLL.LCXPOPAndSMTP();
                    MySMTPModel.GetModel(int.Parse(LCX.Common.PublicMethod.GetSessionValue("UserID")));
                    //发送邮件到Internet地址
                    try
                    {
                        Pop3ForJmail.SendMail(MySMTPModel.SMTPUserName, MySMTPModel.SMTPUserPwd, MySMTPModel.SMTPServer, MyModel.EmailTitle, MyModel.EmailContent, MySMTPModel.SMTPFromEmail, MyModel.ToUser, MyModel.FuJian);
                    }
                    catch
                    {
                        //Response.Write("<script>alert('发送邮件时发生错误，请检查您的邮件参数设置是否正确！');</script>");
                    }
                }
            }

            DataBindToGridview();
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户发送草稿箱中的邮件";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            Response.Write("<script>alert('邮件发送完毕！');</script>");
        }
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string IDlist = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        if (LCX.DBUtility.DbHelperSQL.ExecuteSQL("delete from LCXNetEmail where ID in (" + IDlist + ")") == -1)
        {
            Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
        }
        else
        {
            DataBindToGridview();
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户删除草稿箱中的邮件";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string IDList = "0";
        for (int i = 0; i < GVData.Rows.Count; i++)
        {
            Label LabVis = (Label)GVData.Rows[i].FindControl("LabVisible");
            IDList = IDList + "," + LabVis.Text.ToString();
        }
        Hashtable MyTable = new Hashtable();
        MyTable.Add("EmailTitle", "邮件标题");
        MyTable.Add("ToUser", "接收人");
        MyTable.Add("TimeStr", "发送时间");
        MyTable.Add("EmailState", "邮件状态");
        LCX.Common.DataToExcel.GridViewToExcel(LCX.DBUtility.DbHelperSQL.GetDataSet("select EmailTitle,ToUser,TimeStr,EmailState from LCXNetEmail where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel报表");
    }
}