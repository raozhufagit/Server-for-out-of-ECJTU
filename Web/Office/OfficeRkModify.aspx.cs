﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Office_OfficeRkModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXOfficerk Model = new LCX.BLL.LCXOfficerk();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtOfficeName.Text = Model.OfficeName.ToString();
            this.txtSerils.Text = Model.Serils.ToString();
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.FuJianStr);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
            this.txtTypeStr.Text = Model.TypeStr.ToString();   
            this.txtGongYingShang.Text = Model.GongYingShang.ToString();    
            this.txtDanWei.Text = Model.DanWei.ToString();    
            this.txtRkNum.Text = Model.RkNum.ToString();
            this.txtDanJia.Text = Model.DanJia.ToString();
            this.txtTotalMoeny.Text = Model.TotalMoeny.ToString();
            this.txtPayType.Text = Model.PayType.ToString();
            this.txtMiaoShu.Text = Model.MiaoShu.ToString();
            this.txtUserName.Text = Model.UserName.ToString();
            this.txtTimeStr.Text = Model.TimeStr.ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXOfficerk Model = new LCX.BLL.LCXOfficerk();
        Model.ID = Int32.Parse(Request.QueryString["ID"].ToString());
        Model.GetModel(Model.ID);//获取原始数据
        double oldRkNum = Model.RkNum;
        string oldSerils = Model.Serils;

        Model.OfficeName = this.txtOfficeName.Text.ToString();
        Model.Serils = this.txtSerils.Text.ToString();
        Model.FuJianStr = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        Model.TypeStr = this.txtTypeStr.Text.ToString();
        Model.GongYingShang = this.txtGongYingShang.Text.ToString();
        Model.DanWei = this.txtDanWei.Text.ToString();
        Model.RkNum = Double.Parse(this.txtRkNum.Text.ToString());
        Model.DanJia = Double.Parse(this.txtDanJia.Text.ToString());
        Model.TotalMoeny = Double.Parse(this.txtTotalMoeny.Text.ToString());
        Model.PayType = this.txtPayType.Text.ToString();
        Model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        Model.TimeStr = DateTime.Now;
        Model.MiaoShu = this.txtMiaoShu.Text.ToString();
        //当更新入库数据成功扣
        if (Model.Update() > 0)
        {
            LCX.BLL.LCXOffice eof = new LCX.BLL.LCXOffice();
            if (eof.UpdateNum(oldSerils, (0 - oldRkNum)) == 0)  //更新库存信息成功
            {
                Response.Write("<script>alert('删除选中记录时库存发生错误！请重新登陆后重试！');</script>");
                return;
            }
            else
            {
                if (eof.UpdateNum(Model.Serils, (Model.RkNum)) == 0) //更新库存信息成功
                {
                    Response.Write("<script>alert('删除选中记录时库存发生错误！请重新登陆后重试！');</script>");
                    return;
                }
            }
        }
        else
        {
            Response.Write("<script>alert('删除选中记录时库存发生错误！" + Model.RkNum + "请重新登陆后重试！');</script>");
            return;
        }

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改办公用品信息(" + this.txtOfficeName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "办公用品入库修改成功！", "Officerk.aspx");
    }


    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
        if (LCX.Common.PublicMethod.GetSessionValue("WenJianList").Trim() == "")
        {
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", FileNameStr);
        }
        else
        {
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", LCX.Common.PublicMethod.GetSessionValue("WenJianList") + "|" + FileNameStr);
        }
        LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)
            {
                if (this.CheckBoxList1.Items[i].Selected == true)
                {
                    LCX.Common.PublicMethod.SetSessionValue("WenJianList", LCX.Common.PublicMethod.GetSessionValue("WenJianList").Replace(this.CheckBoxList1.Items[i].Value, "").Replace("||", "|"));
                }
            }
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
        catch
        { }
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CheckBoxList1.SelectedItem.Text.Trim().Length > 0)
            {
                Response.Write("<script>window.open('../DsoFramer/ReadFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Value + "');</script>");
            }
        }
        catch
        { }
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CheckBoxList1.SelectedItem.Text.Trim().Length > 0)
            {
                Response.Write("<script>window.open('../DsoFramer/EditFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Value + "');</script>");
            }
        }
        catch
        { }
    }
}