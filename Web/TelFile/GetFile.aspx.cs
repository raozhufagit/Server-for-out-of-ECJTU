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

public partial class TelFile_GetFile : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataBindToGridview();

            //设定按钮权限
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|101E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }

    public string GetDicNameCondition()
    {
        string ReturnStr = " 0=0 ";
        try
        {
            this.Label1.Text = "归档文件夹：" + Request.QueryString["DicName"].ToString();
            ReturnStr = " ','+QianShouHouIDList+',' like '%," + Request.QueryString["DicID"].ToString() + ",%' ";
        }
        catch
        { }
        return ReturnStr;
    }

    public void DataBindToGridview()
    {
        LCX.BLL.LCXTelFile MyLCXTelFile = new LCX.BLL.LCXTelFile();
        GVData.DataSource = MyLCXTelFile.GetList("TitleStr like '%" + this.TextBox1.Text.Trim() + "%' and ','+ToUser+',' like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%'  and  " + GetDicNameCondition() + " order by ID desc");
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
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label MyLabel = (Label)e.Row.FindControl("Label111");
            string NowUser = "," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",";
            string JieShouUser = "," + MyLabel.Text + ",";
            if (LCX.Common.PublicMethod.StrIFIn(NowUser, JieShouUser) == true)
            {
                MyLabel.Text = "已签收";
            }
            else
            {
                MyLabel.Text = "未签收";
                MyLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview();
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string IDList = "0";
        for (int i = 0; i < GVData.Rows.Count; i++)
        {
            Label LabVis = (Label)GVData.Rows[i].FindControl("LabVisible");
            IDList = IDList + "," + LabVis.Text.ToString();
        }
        Hashtable MyTable = new Hashtable();
        MyTable.Add("TitleStr", "文件主题");
        MyTable.Add("FromUser", "发送人");
        MyTable.Add("TimeStr", "发送时间");
        MyTable.Add("YiJieShouRen", "已签收人");
        LCX.Common.DataToExcel.GridViewToExcel(LCX.DBUtility.DbHelperSQL.GetDataSet("select TitleStr,FromUser,TimeStr,YiJieShouRen from LCXTelFile where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel报表");
    }
}