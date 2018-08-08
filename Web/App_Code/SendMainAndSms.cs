using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// SendMainAndSms 的摘要说明
/// </summary>
public class SendMainAndSms
{
    public SendMainAndSms()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }
    /// <summary>
    /// 发送内部短信和手机短信
    /// </summary>
    /// <param name="MailChk">内部短信选择框</param>
    /// <param name="SmsChk">手机短信选择框</param>
    /// <param name="ContentStr">发送消息内容</param>
    /// <param name="ToUserList">接收人列表</param>
    public static void SendMessage(CheckBox MailChk,CheckBox SmsChk,string ContentStr,string ToUserList)
    {
        
        if (SmsChk.Checked == true)
        {
            //发送手机信息
            Mobile.SendSMS("系统消息", ToUserList, ContentStr);
        }

        string[] UserListStr = ToUserList.Split(',');
        for (int i = 0; i < UserListStr.Length; i++)
        {
            if (MailChk.Checked == true)
            {
                //发送内部信息
                LCX.BLL.LCXLanEmail MyMail = new LCX.BLL.LCXLanEmail();
                MyMail.EmailContent = ContentStr;
                MyMail.EmailState = "未读";
                MyMail.EmailTitle = ContentStr;
                MyMail.FromUser = "系统消息";
                MyMail.FuJian = "";
                MyMail.TimeStr = DateTime.Now;
                MyMail.ToUser = UserListStr[i].ToString();
                MyMail.Add();
            }
        }
    }
    
    #region  带微信发送  手机  邮件
    public static void SendMessage(CheckBox MailChk,CheckBox RtxChk, CheckBox SmsChk, string ContentStr, string ToUserList)
    { 
        if (SmsChk.Checked == true)
        {
            //发送手机信息
            Mobile.SendSMS("系统消息", ToUserList, ContentStr);
        }
        if (RtxChk.Checked == true)
        {
            //发送公文信息
            Rtx.sendNotifyList("系统消息！",ToUserList, ContentStr);
        }
        string[] UserListStr = ToUserList.Split(',');
        for (int i = 0; i < UserListStr.Length; i++)
        {
            if (MailChk.Checked == true)
            {
                //发送内部信息
                LCX.BLL.LCXLanEmail MyMail = new LCX.BLL.LCXLanEmail();
                MyMail.EmailContent = ContentStr;
                MyMail.EmailState = "未读";
                MyMail.EmailTitle = ContentStr;
                MyMail.FromUser = "系统消息";
                MyMail.FuJian = "";
                MyMail.TimeStr = DateTime.Now;
                MyMail.ToUser = UserListStr[i].ToString();
                MyMail.Add();
            }
        }
    }
    #endregion
    #region  发送手机 邮件  腾讯 带网址发送
    public static void SendMessage(CheckBox MailChk, CheckBox RtxChk, CheckBox SmsChk, string ContentStr, string ToUserList,string url)
    {
        if (SmsChk.Checked == true)
        {
            //发送手机信息
            Mobile.SendSMS("系统消息", ToUserList, ContentStr);
        }
        if (RtxChk.Checked == true)
        {
            //发送公文信息
            Rtx.sendNotifyList("系统消息！", ToUserList, ContentStr);
        }
        string[] UserListStr = ToUserList.Split(',');
        for (int i = 0; i < UserListStr.Length; i++)
        {
            if (MailChk.Checked == true)
            {
                //发送内部信息
                LCX.BLL.LCXLanEmail MyMail = new LCX.BLL.LCXLanEmail();
                MyMail.EmailContent = ContentStr + "处理地址：<a href=\"http://" + url + "\">点击查看处理</a>";
                MyMail.EmailState = "未读";
                MyMail.EmailTitle = ContentStr;
                MyMail.FromUser = "系统消息";
                MyMail.FuJian = "";
                MyMail.TimeStr = DateTime.Now;
                MyMail.ToUser = UserListStr[i].ToString();
                MyMail.Add();
            }
        }
    }
    #endregion





    public static void SendMobileMessage(string ContentStr, string ToUserList)
    {
         //发送手机信息
            Mobile.SendSMS("系统消息", ToUserList, ContentStr);
    }
}
