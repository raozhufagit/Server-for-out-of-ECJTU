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
using LCX.DBUtility;
using System.Data.SqlClient;

public partial class OnlineCount : System.Web.UI.Page
{
    public string TiXingJianGe = "30";
    public string TanChuStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            LCX.Common.PublicMethod.CheckSession(); //判断是否在线
        }

        try
        {
            //统一模块发送提醒
            SendTXMail("LCXCustomInfo", "YuJiTiXing", "CustomName", "否", "您设定的客户信息提醒时间已到！");
            SendTXMail("LCXLinkMan", "BirthDay", "NameStr", "是", "您的客户联系人生日日期已到！");
            SendTXMail("LCXVip", "ChuShengDate", "NameStr", "是", "您的会员生日日期已到！");
            SendTXMail("LCXLinkLog", "CusBakE", "LinkTitle", "否", "您设定的客户联系记录提醒时间已到！");
            SendTXMail("LCXSongYang", "CusBakE", "SongYangLiaoHao", "否", "您设定的客户送样记录提醒时间已到！");
            SendTXMail("LCXContract", "TiXingDate", "HeTongName", "否", "您设定的销售合同提醒时间已到！");
            SendTXMail("LCXBuyOrder", "TiXingDate", "OrderName", "否", "您设定的采购订单提醒时间已到！");
            SendTXMail("LCXSupplyLink", "ShengRi", "LinkManName", "是", "您的供应商联系人生日日期已到！");
            SendTXMail("LCXProject", "TiXingDate", "ProjectName", "否", "您设定的项目信息提醒时间已到！");

            //检测产品库存情况报警
            CheckKuCun();

            //检测需要发送信息提醒的项---日程安排
            CheckRiCheng();
            //检测需要发送信息提醒的项---仪器设备
            CheckYiQi();
            //检测需要发送信息提醒的项---保险费用
            CheckBX();
            //检测需要发送信息提醒的项---超时发送催办提醒
            CheckChaoShi();
            CheckRW();


            LCX.Common.PublicMethod.CheckSession();
            //刷新当前用户的激活时间
            DbHelperSQL.ExecuteSQL("update LCXUser set ActiveTime=getdate() where UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "'");
            this.HyperLink1.Text = DbHelperSQL.GetSHSL("select count(*) from LCXUser where datediff(minute,ActiveTime,getdate())<20");

            //获得提醒的间隔时间，是否提醒
            LCX.BLL.LCXTiXing MyModel = new LCX.BLL.LCXTiXing();
            MyModel.GetModel(int.Parse(LCX.Common.PublicMethod.GetSessionValue("UserID")));
            TiXingJianGe = MyModel.TiXingTime;

            //是否需要提醒
            string IFTanChu = MyModel.IfTiXing;
            //获取新邮件个数
            int NewMailCount = int.Parse(LCX.DBUtility.DbHelperSQL.GetSHSLInt("select count(*) from LCXLanEmail where ToUser='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' and EmailState='未读'"));
            this.HyperLink2.Text = NewMailCount.ToString();

            //需要提醒，弹出提醒窗口
            if (IFTanChu.Trim() == "是")
            {
                if (NewMailCount > 0)
                {
                    TanChuStr = "<script language=\"javascript\">var num=Math.random();var abc=screen.height-250;focusid=setTimeout(\"focus();window.showModelessDialog('SmsShow.aspx?rad=\" + num + \"','','scroll:1;status:0;help:0;resizable:0;dialogLeft:3px;dialogTop:\"+abc+\"px;dialogWidth:350px;dialogHeight:200px')\",0000)</script>";
                }
            }
        }
        catch
        { }

        if (Request.Params["Online"] != null)
        {
            GetOnlineCount();
        }
    }

    public void GetOnlineCount()
    {
        DbHelperSQL.ExecuteSQL("update LCXUser set ActiveTime=getdate() where UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "'");
        string count = DbHelperSQL.GetSHSL("select count(*) from LCXUser where datediff(minute,ActiveTime,getdate())<20");
        int NewMailCount = int.Parse(LCX.DBUtility.DbHelperSQL.GetSHSLInt("select count(*) from LCXLanEmail where ToUser='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' and EmailState='未读'"));
        //获得提醒的间隔时间，是否提醒
        LCX.BLL.LCXTiXing MyModel = new LCX.BLL.LCXTiXing();
        MyModel.GetModel(int.Parse(LCX.Common.PublicMethod.GetSessionValue("UserID")));
        int TXSJ = int.Parse(MyModel.TiXingTime)*1000;
        Response.Write(count + ',' + NewMailCount.ToString() + ',' + TXSJ);
        Response.End();
    }




    //发送统一性的提醒邮件
    protected void SendTXMail(string TableName, string LieName, string TitleLieName, string IFOnlyDate, string MailContent)
    {
        string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();

        DataSet MyDataSet = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from " + TableName);
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            if (IFOnlyDate == "是")
            {
                ToDayStr = DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
                if (LCX.Common.PublicMethod.LongToShortStr(MyDataSet.Tables[0].Rows[j][LieName].ToString(), 5) == ToDayStr)
                {
                    LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();
                    MyModel.EmailContent = MailContent + "(" + MyDataSet.Tables[0].Rows[j][TitleLieName].ToString() + ")";
                    MyModel.EmailState = "未读";
                    MyModel.EmailTitle = MailContent + "(" + MyDataSet.Tables[0].Rows[j][TitleLieName].ToString() + ")";
                    MyModel.FromUser = "系统消息";
                    MyModel.FuJian = "";
                    MyModel.TimeStr = DateTime.Now;
                    MyModel.ToUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
                    if (LCX.Common.PublicMethod.IFExists("EmailTitle", "LCXLanEmail", 0, MyModel.EmailTitle) == true)
                    {
                        MyModel.Add();
                    }
                }
            }
            else
            {
                if (MyDataSet.Tables[0].Rows[j][LieName].ToString() == ToDayStr)
                {
                    LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();
                    MyModel.EmailContent = MailContent + "(" + MyDataSet.Tables[0].Rows[j][TitleLieName].ToString() + ")";
                    MyModel.EmailState = "未读";
                    MyModel.EmailTitle = MailContent + "(" + MyDataSet.Tables[0].Rows[j][TitleLieName].ToString() + ")";
                    MyModel.FromUser = "系统消息";
                    MyModel.FuJian = "";
                    MyModel.TimeStr = DateTime.Now;
                    MyModel.ToUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
                    if (LCX.Common.PublicMethod.IFExists("EmailTitle", "LCXLanEmail", 0, MyModel.EmailTitle) == true)
                    {
                        MyModel.Add();
                    }
                }
            }
        }
    }

    protected void CheckChaoShi()
    {
        DataSet MyDataSet = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from LCX_WorkToDo where getdate()>LateTime and StateNow='正在办理' and  ','+ShenPiUserList+',' like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%' and ','+OKUserList+',' not like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%' order by ID asc");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();
            MyModel.EmailContent = "您有待办工作未办理，时间已超时！。(" + MyDataSet.Tables[0].Rows[j]["WorkName"].ToString() + "-工作流水号：" + MyDataSet.Tables[0].Rows[j]["ID"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您有待办工作未办理，时间已超时！(" + MyDataSet.Tables[0].Rows[j]["WorkName"].ToString() + "-工作流水号：" + MyDataSet.Tables[0].Rows[j]["ID"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
            if (LCX.Common.PublicMethod.IFExists("EmailTitle", "LCXLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    //检测产品库存
    protected void CheckKuCun()
    {
        DataSet MyDataSet = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from LCXProduct  where NowKuCun<=KuCunBaoJing  order by ID asc");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();
            MyModel.EmailContent = "您的产品库存不足，请及时处理！(" + MyDataSet.Tables[0].Rows[j]["ProductName"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您的产品库存不足，请及时处理！(" + MyDataSet.Tables[0].Rows[j]["ProductName"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
            if (LCX.Common.PublicMethod.IFExists("EmailTitle", "LCXLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    protected void CheckBX()
    {
        string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        DataSet MyDataSet = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from LCXCarBX where UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "'  and TiXingDate='" + ToDayStr + "'");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();
            MyModel.EmailContent = "您所制定的车辆保险费用提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["CarName"].ToString() + "--" + MyDataSet.Tables[0].Rows[j]["FeiYongName"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您所制定的车辆保险费用提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["CarName"].ToString() + "--" + MyDataSet.Tables[0].Rows[j]["FeiYongName"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
            if (LCX.Common.PublicMethod.IFExists("EmailTitle", "LCXLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    protected void CheckRW()
    {
        string ToDayStr = DateTime.Now.ToString();  //有断点。
        DataSet MyDataSet = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from LCXTaskFP where  SFFK='是'  and FKSJ<='" + ToDayStr + "'");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            SendMainAndSms.SendMobileMessage("有需要您反馈的任务提醒时间已到，请尽快反馈。(" + MyDataSet.Tables[0].Rows[j]["TaskTitle"].ToString() + "--" + MyDataSet.Tables[0].Rows[j]["FromUser"].ToString() + "内容:" + MyDataSet.Tables[0].Rows[j]["TaskContent"].ToString() + ")", MyDataSet.Tables[0].Rows[j]["ToUserList"].ToString() + "," + MyDataSet.Tables[0].Rows[j]["FromUser"].ToString());
            LCX.DBUtility.DbHelperSQL.Query("update LCXTaskFP set SFFK='已发' where ID =" + MyDataSet.Tables[0].Rows[j]["ID"].ToString() + " ");
        }
    }


    protected void CheckSK()
    {
        string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        DataSet MyDataSet = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from LCXRecive where CreateUser='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' and NowState='S' and TiXingDate='" + ToDayStr + "'");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();
            MyModel.EmailContent = "您所制定的收款计划提醒时间已到。(" + MyDataSet.Tables[0].Rows[j]["HeTongName"].ToString() + "--" + MyDataSet.Tables[0].Rows[j]["QianYueKeHu"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您所制定的收款计划提醒时间已到。(" + MyDataSet.Tables[0].Rows[j]["HeTongName"].ToString() + "--" + MyDataSet.Tables[0].Rows[j]["QianYueKeHu"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
            if (LCX.Common.PublicMethod.IFExists("EmailTitle", "LCXLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    protected void CheckFK()
    {
        string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        DataSet MyDataSet = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from LCXRecive where CreateUser='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' and NowState='F' and TiXingDate='" + ToDayStr + "'");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();
            MyModel.EmailContent = "您所制定的付款计划提醒时间已到。(" + MyDataSet.Tables[0].Rows[j]["HeTongName"].ToString() + "--" + MyDataSet.Tables[0].Rows[j]["QianYueKeHu"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您所制定的付款计划提醒时间已到。(" + MyDataSet.Tables[0].Rows[j]["HeTongName"].ToString() + "--" + MyDataSet.Tables[0].Rows[j]["QianYueKeHu"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
            if (LCX.Common.PublicMethod.IFExists("EmailTitle", "LCXLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    protected void CheckYiQi()
    {
        string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        DataSet MyDataSet = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from LCXSheBei where ','+TiXingUser+',' like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%'  and TiXingDate='" + ToDayStr + "'");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();
            MyModel.EmailContent = "您所制定的仪器设备溯源提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["SheBeiName"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您所制定的仪器设备溯源提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["SheBeiName"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
            if (LCX.Common.PublicMethod.IFExists("EmailTitle", "LCXLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }

    protected void CheckRiCheng()
    {
        string ToDayStr = DateTime.Now.Year.ToString() + "-" + DateTime.Now.Month.ToString() + "-" + DateTime.Now.Day.ToString();
        DataSet MyDataSet = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from LCXArrange where UserName= '" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "'  and TimeTiXing='" + ToDayStr + "'");
        for (int j = 0; j < MyDataSet.Tables[0].Rows.Count; j++)
        {
            LCX.BLL.LCXLanEmail MyModel = new LCX.BLL.LCXLanEmail();
            MyModel.EmailContent = "您所制定的日程安排提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["TitleStr"].ToString() + ")";
            MyModel.EmailState = "未读";
            MyModel.EmailTitle = "您所制定的日程安排提醒时间到。(" + MyDataSet.Tables[0].Rows[j]["TitleStr"].ToString() + ")";
            MyModel.FromUser = "系统消息";
            MyModel.FuJian = "";
            MyModel.TimeStr = DateTime.Now;
            MyModel.ToUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
            if (LCX.Common.PublicMethod.IFExists("EmailTitle", "LCXLanEmail", 0, MyModel.EmailTitle) == true)
            {
                MyModel.Add();
            }
        }
    }
}
