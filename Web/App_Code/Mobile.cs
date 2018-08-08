using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Net;
using System.IO;

/// <summary>
/// Mobile 的摘要说明
/// </summary>
public class Mobile
{
    public Mobile()
    {
        //
        // TODO: 在此处添加构造函数逻辑
        //
    }

    /// 发送短信到内部用户
    /// <param name="FaSongUser"></param>
    /// <param name="ToUserList"></param>
    /// <param name="ContentStr"></param>
    public static void SendSMS(string FaSongUser, string ToUserList, string ContentStr)
    {
        //根据用户名列表获取手机号码 admin,test,lcx,test123
        DataSet MyDT = LCX.DBUtility.DbHelperSQL.GetDataSet("select JiaTingDianHua from LCXUser where UserName in('" + ToUserList.Replace(",", "','") + "')");
        for (int i = 0; i < MyDT.Tables[0].Rows.Count; i++)
        {
            if (!string.IsNullOrEmpty(MyDT.Tables[0].Rows[i]["JiaTingDianHua"].ToString()) && CheckPhoneNumber(MyDT.Tables[0].Rows[i]["JiaTingDianHua"].ToString()))
            {
                LCX.BLL.LCXSms sms = new LCX.BLL.LCXSms(); 
                sms.smsType = 2; //OA消息
                sms.smsUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
                sms.smsTel = MyDT.Tables[0].Rows[i]["JiaTingDianHua"].ToString();
                sms.smsEnRey = false;
                //smodel.oaEventID = null;
                sms.smsContent = ContentStr;
                sms.smsState = 0;
                sms.smsTime = DateTime.Now;
                sms.Add();

                send(MyDT.Tables[0].Rows[i]["JiaTingDianHua"].ToString(), ContentStr);
            }
        }
    }

    /// 发送外部短信，直接是手机号码列表 
    /// </summary>
    /// <param name="FaSongUser"></param>
    /// <param name="ToUserList"></param>
    /// <param name="ContentStr"></param>
    public static void SendSMS2(string FaSongUser, string ToUserList, string ContentStr)
    {
        string[] sr=ToUserList.Split(',');
        for (int i = 0; i < sr.Length;i++ )
        {
            if (!string.IsNullOrEmpty(sr[i]) && CheckPhoneNumber(sr[i]))
            {
                LCX.BLL.LCXSms sms = new LCX.BLL.LCXSms();
                sms.smsType = 2; //2OA短信  1RTX短信
                sms.smsUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
                sms.smsTel = sr[i];
                sms.smsEnRey = false;
                //smodel.oaEventID = null;
                sms.smsContent = ContentStr;
                sms.smsState = 0;
                sms.smsTime = DateTime.Now;
                sms.Add();

                send(sr[i], ContentStr);
            }
        }
    }
    #region 电话号码判断
    /// <summary>
    /// 名称：CheckPhoneNumber
    /// 方法：判断是否合法的电话号码
    /// </summary>
    /// <param name="number">所要判断的电话号码或手机号码</param>
    /// <returns>true,false</returns>
    public static bool CheckPhoneNumber(string number)
    {
        if (System.Text.RegularExpressions.Regex.IsMatch(number, @"^(?:0(?:10|2[0-57-9]|[3-9]\d{2})[-—]?)\d{7,8}$"))
          {
             return true;
          }else if(System.Text.RegularExpressions.Regex.IsMatch(number, "^1\\d{10}$")){
                return true;
          }else{
                return false;
         }
    } 
    #endregion















    /********************************************************************************************************/

    //数据发送

    /********************************************************************************************************/

    #region 数据发送

    public static void send(string ToUserList, string ContentStr)
    {

        string sendurl = "http://api.sms.cn/mt/";

        string mobile = ToUserList;  //发送号码

        string strContent = "一品猪排您好,(www.ybmsw.com)免费为您提供订餐服务,您餐厅的帐号和密码是ypzzp,请及时维护您的信息【延边美食网】";

        StringBuilder sbTemp = new StringBuilder();

        string uid = ConfigurationManager.AppSettings["userName"];

        string pwd = ConfigurationManager.AppSettings["enPassword"];

        string Pass = FormsAuthentication.HashPasswordForStoringInConfigFile(pwd + uid, "MD5"); //密码进行MD5加密

        //POST 传值

        sbTemp.Append("uid=" + uid + "&pwd=" + Pass + "&mobile=" + mobile + "&content=" + strContent);

        byte[] bTemp = System.Text.Encoding.GetEncoding("GBK").GetBytes(sbTemp.ToString());

        String postReturn = doPostRequest(sendurl, bTemp);

        //Response.Write("Post response is: " + postReturn);  //测试返回结果

    }

    //POST方式发送得结果

    private static String doPostRequest(string url, byte[] bData)
    {

        System.Net.HttpWebRequest hwRequest;

        System.Net.HttpWebResponse hwResponse;



        string strResult = string.Empty;

        try
        {

            hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

            hwRequest.Timeout = 5000;

            hwRequest.Method = "POST";

            hwRequest.ContentType = "application/x-www-form-urlencoded";

            hwRequest.ContentLength = bData.Length;



            System.IO.Stream smWrite = hwRequest.GetRequestStream();

            smWrite.Write(bData, 0, bData.Length);

            smWrite.Close();

        }

        catch (System.Exception err)
        {

            WriteErrLog(err.ToString());

            return strResult;

        }



        //get response

        try
        {

            hwResponse = (HttpWebResponse)hwRequest.GetResponse();

            StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);

            strResult = srReader.ReadToEnd();

            srReader.Close();

            hwResponse.Close();

        }

        catch (System.Exception err)
        {

            WriteErrLog(err.ToString());

        }

        return strResult;

    }

    private static void WriteErrLog(string strErr)
    {

        Console.WriteLine(strErr);

        System.Diagnostics.Trace.WriteLine(strErr);

    }

    #endregion










}
