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

public partial class SystemManage_SystemUserModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //绑定页面数据
            LCX.BLL.LCXUser MyBuMen = new LCX.BLL.LCXUser();
            MyBuMen.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.TextBox1.Text = MyBuMen.UserName;
            this.TextBox2.Text =LCX.Common.DEncrypt.DESEncrypt.Decrypt(MyBuMen.UserPwd);
            this.TextBox3.Text = MyBuMen.TrueName;
            this.TextBox4.Text = MyBuMen.Serils;
            this.TextBox5.Text = MyBuMen.Department;
            this.TextBox6.Text = MyBuMen.JiaoSe;
            this.TextBox7.Text = MyBuMen.ZhiWei;
            this.TextBox8.Text = MyBuMen.ZaiGang;
            this.TextBox9.Text = MyBuMen.EmailStr;
            this.RadioButtonList1.SelectedValue = MyBuMen.IfLogin;
            this.TextBox10.Text = MyBuMen.Sex;
            this.TextBox11.Text = MyBuMen.BackInfo;
            this.TextBox12.Text = MyBuMen.BirthDay.ToString();
            this.TextBox13.Text = MyBuMen.MingZu;
            this.TextBox14.Text = MyBuMen.SFZSerils;
            this.TextBox15.Text = MyBuMen.HunYing;
            this.TextBox16.Text = MyBuMen.ZhengZhiMianMao;
            this.TextBox17.Text = MyBuMen.JiGuan;
            this.TextBox18.Text = MyBuMen.HuKou;
            this.TextBox19.Text = MyBuMen.XueLi;
            this.TextBox20.Text = MyBuMen.ZhiCheng;
            this.TextBox21.Text = MyBuMen.BiYeYuanXiao;
            this.TextBox22.Text = MyBuMen.ZhuanYe;
            this.TextBox23.Text = MyBuMen.CanJiaGongZuoTime;
            this.TextBox24.Text = MyBuMen.JiaRuBenDanWeiTime;
            this.TextBox25.Text = MyBuMen.JiaTingDianHua;
            this.TextBox26.Text = MyBuMen.JiaTingAddress;
            this.TextBox27.Text = MyBuMen.GangWeiBianDong;
            this.TextBox28.Text = MyBuMen.JiaoYueBeiJing;
            this.TextBox29.Text = MyBuMen.GongZuoJianLi;
            this.TextBox30.Text = MyBuMen.SheHuiGuanXi;
            this.TextBox31.Text = MyBuMen.JiangChengJiLu;
            this.TextBox32.Text = MyBuMen.ZhiWuQingKuang;
            this.TextBox33.Text = MyBuMen.PeiXunJiLu;
            this.TextBox34.Text = MyBuMen.DanBaoJiLu;
            this.TextBox35.Text = MyBuMen.NaoDongHeTong;
            this.TextBox36.Text = MyBuMen.SheBaoJiaoNa;
            this.TextBox37.Text = MyBuMen.TiJianJiLu;
            this.TextBox38.Text = MyBuMen.BeiZhuStr;
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", MyBuMen.FuJian);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (LCX.Common.PublicMethod.IFExists("UserName", "LCXUser", int.Parse(Request.QueryString["ID"].ToString()), this.TextBox1.Text) == true)
        {
            if (LCX.Common.PublicMethod.IFExists("TrueName", "LCXUser", int.Parse(Request.QueryString["ID"].ToString()), this.TextBox3.Text) == true)
            {
                LCX.BLL.LCXUser MyBuMen = new LCX.BLL.LCXUser();
                MyBuMen.ID = int.Parse(Request.QueryString["ID"].ToString());
                MyBuMen.UserName = this.TextBox1.Text;
                MyBuMen.UserPwd = LCX.Common.DEncrypt.DESEncrypt.Encrypt(this.TextBox2.Text);
                MyBuMen.TrueName = this.TextBox3.Text;
                MyBuMen.Serils = this.TextBox4.Text;
                MyBuMen.Department = this.TextBox5.Text;
                MyBuMen.JiaoSe = this.TextBox6.Text;
                MyBuMen.ZhiWei = this.TextBox7.Text;
                MyBuMen.ZaiGang = this.TextBox8.Text;
                MyBuMen.EmailStr = this.TextBox9.Text;
                MyBuMen.IfLogin = this.RadioButtonList1.SelectedItem.Text;
                MyBuMen.Sex = this.TextBox10.Text;
                MyBuMen.BackInfo = this.TextBox11.Text;
                MyBuMen.BirthDay = DateTime.Parse(this.TextBox12.Text);
                MyBuMen.MingZu = this.TextBox13.Text;
                MyBuMen.SFZSerils = this.TextBox14.Text;
                MyBuMen.HunYing = this.TextBox15.Text;
                MyBuMen.ZhengZhiMianMao = this.TextBox16.Text;
                MyBuMen.JiGuan = this.TextBox17.Text;
                MyBuMen.HuKou = this.TextBox18.Text;
                MyBuMen.XueLi = this.TextBox19.Text;
                MyBuMen.ZhiCheng = this.TextBox20.Text;
                MyBuMen.BiYeYuanXiao = this.TextBox21.Text;
                MyBuMen.ZhuanYe = this.TextBox22.Text;
                MyBuMen.CanJiaGongZuoTime = this.TextBox23.Text;
                MyBuMen.JiaRuBenDanWeiTime = this.TextBox24.Text;
                MyBuMen.JiaTingDianHua = this.TextBox25.Text;
                MyBuMen.JiaTingAddress = this.TextBox26.Text;
                MyBuMen.GangWeiBianDong = this.TextBox27.Text;
                MyBuMen.JiaoYueBeiJing = this.TextBox28.Text;
                MyBuMen.GongZuoJianLi = this.TextBox29.Text;
                MyBuMen.SheHuiGuanXi = this.TextBox30.Text;
                MyBuMen.JiangChengJiLu = this.TextBox31.Text;
                MyBuMen.ZhiWuQingKuang = this.TextBox32.Text;
                MyBuMen.PeiXunJiLu = this.TextBox33.Text;
                MyBuMen.DanBaoJiLu = this.TextBox34.Text;
                MyBuMen.NaoDongHeTong = this.TextBox35.Text;
                MyBuMen.SheBaoJiaoNa = this.TextBox36.Text;
                MyBuMen.TiJianJiLu = this.TextBox37.Text;
                MyBuMen.BeiZhuStr = this.TextBox38.Text;
                MyBuMen.FuJian = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
                if (MyBuMen.Update() > 0)
                {
                    LCX.BLL.LCXRtx rtx = new LCX.BLL.LCXRtx();
                    if (rtx.Exists(MyBuMen.UserName))
                    {
                        Rtx.updatePhone(MyBuMen.UserName,MyBuMen.JiaTingDianHua);
                         //更新RTX帐号
                    }
                   
                } 


                //写系统日志
                LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
                MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
                MyRiZhi.DoSomething = "用户修改人事档案信息(" + this.TextBox1.Text + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                MyRiZhi.Add();
                LCX.Common.MessageBox.ShowAndRedirect(this, "人事档案信息修改成功！", "RenShiInfo.aspx");
            }
            else
            {
                LCX.Common.MessageBox.Show(this, "该登录账号已经存在，请更换其他登录账号！");
            }
        }
        else
        {
            LCX.Common.MessageBox.Show(this, "该用户名已经存在，请更换其他用户名！");
        }
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
}