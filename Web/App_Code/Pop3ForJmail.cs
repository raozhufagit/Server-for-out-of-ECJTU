using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using jmail;
using System.IO;
using System.Text;
using System.Collections;
using System.Globalization;
using System.Web;
/// <summary>
/// Pop3ForJmail 的摘要说明
/// </summary>
public class Pop3ForJmail
{
    public Pop3ForJmail()
    {
        
    }





    private static int iss = 1;

    /// <summary>
    /// 收取新邮件、不删除老邮件、收取邮件后写入数据库
    /// </summary>
    public static void GetNewMailIntoDataBase(string UserName,string PassWord,string PopServer,int Port,DateTime MaxDate)
    {
        POP3 NewMail = new POP3();
        NewMail.Connect(UserName, PassWord, PopServer, Port); 
       
        for (int i = 1; i <= NewMail.Count; i++)
        {
            

            //判断是否跟当前最大的时间作比较，大于当前时间就处理
            DateTime CurrentEmailDate = DateTime.Now;
            try
            {
                CurrentEmailDate = DateTime.Parse(NewMail.Messages[i].Date.ToString());
            }
            catch
            { }

            try
            {
                if (CurrentEmailDate.CompareTo(MaxDate) > 0)
                {
                    iss =iss+1;
                    string _filename = DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss")+iss.ToString() + ".eml";
                    FolderCreate(HttpContext.Current.Server.MapPath("eml\\") + DateTime.Now.ToString("yyyyMMdd"));
                    

                    string filePath = HttpContext.Current.Server.MapPath("eml\\") + _filename; //邮件文件内容
                    FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                    StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("utf-8"));


                    string EmailFuJian = "";   
                    NewMail.Messages[i].Charset = "utf-8";
                   // NewMail.Messages[i].Encoding = "Base64";
                    for (int j = 0; j < NewMail.Messages[i].Attachments.Count; j++)
                    {
                        //NewMail.Messages[i].Charset = "GB2312";
                        NewMail.Messages[i].Encoding = "Base64"; //设置邮件的附件编码方式
                        NewMail.Messages[i].ISOEncodeHeaders = false; //是否将信头编码成iso-8859-1字符集
                        NewMail.Messages[i].ContentType = "text/html";//接收的文件类型 .ContentType = "text/html"; 
                        try
                        {
                            string FileName = DateTime.Now.Ticks.ToString() + NewMail.Messages[i].Attachments[j].Name;
                            //符合上传要求就保存，否则提示文件名未下载
                            if (LCX.Common.PublicMethod.IfOkFile(FileName) == true)
                            {
                                NewMail.Messages[i].Attachments[j].SaveToFile(System.Web.HttpContext.Current.Request.MapPath("../UploadFile") + "\\MailAttachments\\" + FileName);
                            }
                            else
                            {
                                System.Web.HttpContext.Current.Response.Write("<script>alert('邮件附件文件：" + NewMail.Messages[i].Attachments[j].Name + " 不符合本服务器文件保存权限设置，禁止下载！已自动跳过本附件！');</script>");
                            }
                            if (EmailFuJian.Trim().Length > 0)
                            {
                                EmailFuJian = EmailFuJian + "|MailAttachments/" + FileName;
                            }
                            else
                            {
                                EmailFuJian = "MailAttachments/" + FileName;
                            }
                        }
                        catch (Exception e)
                        {
                            System.Web.HttpContext.Current.Response.Write("<script>alert('" + e.Message.ToString() + "');</script>");
                        }
                    }



                   
                    LCX.BLL.LCXNetEmail MyModel = new LCX.BLL.LCXNetEmail();
                    MyModel.EmailState = "未读";
                    String _codeType = "";
                    String[] _title={};
                    try
                    {
                        _codeType = NewMail.Messages[i].Headers.GetHeader("Subject").Split('?')[1];
                        _title = NewMail.Messages[i].Headers.GetHeader("Subject").Split('?');
                    }
                    catch
                    {
                        _codeType = "";
                    }

                    if (_codeType == "")
                    {
                        MyModel.EmailTitle = NewMail.Messages[i].Subject;
                        MyModel.FromUser = NewMail.Messages[i].FromName + "（" + NewMail.Messages[i].From + "）";
                        MyModel.EmailContent = _filename;
                        sw.Write(System.Web.HttpContext.Current.Server.HtmlEncode(NewMail.Messages[i].MailData));
                    }
                    else if (_codeType.ToUpper() == "UTF-8")
                    {
                        if (_title[2].ToUpper() == "Q")   
                        {
                            MyModel.EmailTitle = QuotedPrintableDecode(_title[3]);
                        }else{
                            MyModel.EmailTitle = base64Utf8Decode(_title[3]);
                        }

                        MyModel.EmailContent = _filename;
                        sw.Write(System.Web.HttpContext.Current.Server.HtmlEncode(NewMail.Messages[i].MailData));
                       // sw.Write(MyModel.EmailContent);
                    }else{
                        if (_title[2].ToUpper() == "Q")
                        {
                            MyModel.EmailTitle = QuotedPrintableDecode(_title[3]);
                        }else{
                            MyModel.EmailTitle = NewMail.Messages[i].Subject;
                        }
                        MyModel.FromUser = NewMail.Messages[i].FromName + "（" + NewMail.Messages[i].From + "）";

                        MyModel.EmailContent = _filename;
                        sw.Write(System.Web.HttpContext.Current.Server.HtmlEncode(NewMail.Messages[i].MailData));

                    }                    
                    MyModel.FuJian = EmailFuJian;
                    try
                    {
                        MyModel.TimeStr = DateTime.Parse(NewMail.Messages[i].Date.ToString());
                    }
                    catch
                    {
                        MyModel.TimeStr = DateTime.Now;
                    }
                    MyModel.ToUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
                    MyModel.Add();
                    sw.Close();
                    fs.Close();
                }               
            }
            catch (Exception ee)
            {
                System.Web.HttpContext.Current.Response.Write("<script>alert('" + ee.Message.ToString() + "');</script>");
            }

        }
        NewMail.Disconnect();
    }




    /*UTF8转GB2312*/
    public static string UTF8ToGB2312(String _content)
    {
        try
        {
            Encoding utf8 = Encoding.GetEncoding(65001);
            Encoding gb2312 = Encoding.GetEncoding("gb2312");
            byte[] temp = utf8.GetBytes(_content);
            byte[] temp1 = Encoding.Convert(utf8, gb2312, temp);
            string result = gb2312.GetString(temp1);
            return result;
        }
        catch (Exception ex)
        {
            return null;
        }
    }

    public static string QuotedPrintableDecode(string codeString)// 解码
    {
        //编码的字符集  
        string mailEncoding = "GB2312";
        StringBuilder strBud = new StringBuilder();
        for (int i = 0; i < codeString.Length; i++)
        {
            if (codeString[i] == '=')
            {
                if (Convert.ToInt32((codeString[i + 1] + codeString[i + 2]).ToString(), 16) < 127)
                {
                    strBud.Append(
                    Encoding.GetEncoding(mailEncoding).GetString(
                    new byte[] { Convert.ToByte((codeString[i + 1] + codeString[i + 2]).ToString(), 16) }));

                    i += 2;
                    continue;
                }

                if (codeString[i + 3] == '=')
                {
                    strBud.Append(
                    Encoding.GetEncoding(mailEncoding).GetString(
                    new byte[] { Convert.ToByte((codeString[i + 1].ToString() + codeString[i + 2].ToString()), 16),  
                 Convert.ToByte((codeString[i + 4].ToString() + codeString[i + 5].ToString()), 16) }));

                    i += 5;
                    continue;
                }
            }
            else
            {
                strBud.Append(codeString[i]);
            }
        }
        return strBud.ToString();  
    }
    

    #region base64解码
    public static string base64GbkDecode(string data)
    {
        string decode = "";
        byte[] bytes = Convert.FromBase64String(data);
        try
        {
            decode = Encoding.GetEncoding("gb2312").GetString(bytes);
        }
        catch (Exception ex1)
        {
            //return "Error in base64Encode" + ex1.Message;
        }
        return decode;
    }

    public static string base64Utf8Decode(string data)
    {
        string result = "";
        try
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(data);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            result = new String(decoded_char);
        }
        catch (Exception e)
        {
            //return "Error in base64Encode" + e.Message;
        }
        return result;
    }



    //base64解码
    public static string DecodeStr(string allstr, string code)
    {
        //形如=?...?=是结束开始的标志
        //=?utf-8?B?5rWL6K+V5o6l5pS25pys6YKu5Lu26L+Z5piv5Li76aKY?=
        //=?gbk?B?suLK1L3TytXN4rK/08q8/tXiuPbKx9b3zOU=?=
        //返回的字符串
        string str = "";  
        if (code == "GBK" || code == "GB2312")
        {
            str = base64GbkDecode(allstr);
        }
        else if (code == "UTF-8")
        {
            str = base64Utf8Decode(allstr);
        }
        else
        {
            str = base64GbkDecode(allstr);
        }

        return str;
    }
    #endregion


    public static void FolderCreate(string Path)
    {
        // 判断目标目录是否存在如果不存在则新建之  
        if (!Directory.Exists(Path))
            Directory.CreateDirectory(Path);
    }  



    /// <summary>
    /// 发送邮件到网络
    /// </summary>
    public static void SendMail(string UserName, string PassWord, string SMTPServer, string Subject, string body, string FromEmail, string ToEmail,string FuJianList)
    {
        try
        {
            Message Jmail = new Message();
            DateTime t = DateTime.Now;

            //Slient属性:如果设置为true,Jmail不会抛出例外错误，Jmail.Send()会根据操作结果返回True或False
            Jmail.Silent = false;

            //Jmail创建的日志，提前loging属性设置为True
            Jmail.Logging = true;

            //字符集，缺省为"US-ASCII";
            Jmail.Charset = "GB2312";

            //信件的ContentType,缺省为"Text/plain",字符串如果你以Html格式发送邮件，改为"Text/Html"即可。
            
          // Jmail.ContentType = "text/html";  //真是郁闷

            //添加收件人
            Jmail.AddRecipient(ToEmail, "", "");
            Jmail.From = FromEmail;

            //发件人邮件用户名
            Jmail.MailServerUserName = UserName;

            //发件人邮件密码
            Jmail.MailServerPassWord = PassWord;

            //设置邮件标题
            Jmail.Subject = Subject;

            //邮件添加附件（多附件的话，可以再加一条Jmail.AddAttachment("c:\test.jpg",true,null);就可以搞定了。
            //注意：为了添加附件，要把上面的Jmail.ContentType="text/html";删掉，否则会在邮件里出现乱码
            string[] FuJian = FuJianList.Split('|');
            for (int kk = 0; kk < FuJian.Length; kk++)
            {
                if (FuJian[kk].Trim().Length > 0)
                {
                    Jmail.AddAttachment(System.Web.HttpContext.Current.Request.MapPath("../UploadFile") + "\\" + FuJian[kk].ToString(), true, null);
                }
            }

            //邮件内容
            Jmail.Body = body + t.ToString();

            //Jmail发送的方法
            Jmail.Send(SMTPServer, false);
            Jmail.Close();
        }
        catch (Exception e)
        {
            System.Web.HttpContext.Current.Response.Write("<script>alert('" + e.Message.ToString() + "');</script>");
        }
    }
}
