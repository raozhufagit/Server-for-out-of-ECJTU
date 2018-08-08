using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using LumiSoft.Net;
using LumiSoft.Net.Log;
using LumiSoft.Net.MIME;
using LumiSoft.Net.Mail;
using LumiSoft.Net.POP3.Client;

/// <summary>
///lumisoft 的摘要说明
/// </summary>
public class lumisoft
{
    POP3_Client pop3 = new POP3_Client();
	public lumisoft()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    #region 连接POP服务器
    public string m_pConnect(string m_pServer, string m_pUserName,string m_pPassword, int m_pPort)
    {
        if (m_pUserName == "")
        {            
            return "Please fill user name !";
        }       
        try
        {
            pop3.Logger = new Logger();
            pop3.Logger.WriteLog += m_pLogCallback; //写入日志不需要了
            //pop3.Connect(m_pServer, m_pPort, true);
            //pop3.Authenticate(m_pUserName, m_pPassword, true);
            pop3.Connect(m_pServer, (int)m_pPort, false);
            pop3.Login(m_pUserName, m_pPassword);
            return "ok";
        }
        catch (Exception x)
        {
          pop3.Dispose(); 
          return "POP3 server returned: " + x.Message + " !";
        }
    }
    #endregion
    private void m_pLogCallback(object sender, WriteLogEventArgs e)
    {

    }


    #region 获取所有邮件
    public void FillMessagesList(DateTime MaxDate)
    {       
        try
        {
            foreach (POP3_ClientMessage message in pop3.Messages)
            {
                Mail_Message mime = Mail_Message.ParseFromByte(message.HeaderToByte());
                //判断是否跟当前最大的时间作比较，大于当前时间就处理
                DateTime CurrentEmailDate = DateTime.Now;
                try
                {
                    CurrentEmailDate = DateTime.Parse(mime.Date.ToString());
                }
                catch
                {

                }
                if (CurrentEmailDate.CompareTo(MaxDate) > 0)
                {
                    LCX.BLL.LCXNetEmail MyModel = new LCX.BLL.LCXNetEmail();
                    //邮件状态标记
                    MyModel.EmailState = "未读";
                    //邮件发送用户
                    if (mime.From != null)
                    {
                        MyModel.FromUser = mime.From.ToString();
                    }
                    else
                    {
                        MyModel.FromUser = "<none>";
                    }


                    //邮件标题
                    if (string.IsNullOrEmpty(mime.Subject))
                    {
                        MyModel.EmailTitle="<none>";
                    }
                    else
                    {
                        MyModel.EmailTitle=mime.Subject;
                        MyModel.TimeStr = DateTime.Parse(mime.Date.ToString());
                        try
                        {
                            MyModel.FuJian = getEmlContent(message);
                        }
                        catch (Exception ex)
                        {
                            MyModel.FuJian = "";
                        }
                        try
                        {
                            MyModel.EmailContent = getEmlfile(message);
                        }
                        catch (Exception ex)
                        {
                            MyModel.EmailContent = "";
                        }
                        MyModel.ToUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
                        MyModel.Add();

                    }
                    
                }   
            }
        }
        catch (Exception x)
        {
           // MessageBox.Show(this, "Error: " + x.Message, "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
       
    }
   
    #endregion 
    
    private static int iss = 0;
    #region 保存附件
    private string getEmlContent(POP3_ClientMessage message)
    {                
        Mail_Message mime = Mail_Message.ParseFromByte(message.MessageToByte()); //转化成mail_message
        string EmailFuJian = "";   
        foreach (MIME_Entity entity in mime.Attachments)  //读取所有的附件并保存
        {
            if (entity.ContentDisposition != null && entity.ContentDisposition.Param_FileName != null)
            {
                string attachmentName =DateTime.Now.ToString("yyyyMMddhhmmss") + entity.ContentDisposition.Param_FileName; //附件名
                File.WriteAllBytes(System.Web.HttpContext.Current.Request.MapPath("../UploadFile") + "\\MailAttachments\\"+attachmentName, ((MIME_b_SinglepartBase)entity.Body).Data);
                if (EmailFuJian.Trim().Length > 0) //设置附件中的文件名
                {
                    EmailFuJian = EmailFuJian + "|MailAttachments/" + attachmentName;
                }
                else
                {
                    EmailFuJian = "MailAttachments/" + attachmentName;
                }
            }
        }
        return EmailFuJian;
    }
    #endregion

    #region 保存邮件正文内容
    private string getEmlfile(POP3_ClientMessage message)
    {
        Mail_Message mime = Mail_Message.ParseFromByte(message.MessageToByte()); //转化成mail_message        
        FolderCreate(HttpContext.Current.Server.MapPath("eml\\") + DateTime.Now.ToString("yyyyMMdd"));
        if (mime.BodyHtmlText != null) //判断正文是否为空
        {
            iss = iss + 1;
            string _filename = DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + iss.ToString() + ".eml";
            string filePath = HttpContext.Current.Server.MapPath("eml\\") + _filename; //邮件文件内容
            FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("utf-8"));
            sw.Write(mime.BodyHtmlText); //邮件内容
            sw.Close();
            fs.Close();
            return _filename;
        }
        else
        {
            return "";
        }
    }
    #endregion

    #region 判断文件夹是否存在  不存在就新建
    public void FolderCreate(string Path)
    {
        // 判断目标目录是否存在如果不存在则新建之  
        if (!Directory.Exists(Path))
            Directory.CreateDirectory(Path);
    }
    #endregion
}