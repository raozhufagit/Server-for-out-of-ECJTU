using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Xml;

using System.Net;
using System.Security.Cryptography.X509Certificates;

public partial class login : System.Web.UI.Page
{
    // Local specific CAS host
    private const string CASHOST = "http://cas.ecjtu.edu.cn/cas/";

    protected void Page_Load(object sender, EventArgs e)
    {
        System.Net.ServicePointManager.CertificatePolicy = new MyPolicy();
        // Look for the "ticket=" after the "?" in the URL
        string tkt = Request.QueryString["ticket"];
        string Rurl = Request.QueryString["redirectUrl"];
        // This page is the CAS service=, but discard any query string residue
        string service = Request.Url.GetLeftPart(UriPartial.Path);


        if (Rurl != null)
        {
            service = service + "?redirectUrl=" + Rurl;
        }


        // First time through there is no ticket=, so redirect to CAS login
        if (tkt == null || tkt.Length == 0)
        {
            string redir = CASHOST + "login?" + "service=" + service;
            Response.Redirect(redir);
            return;
        }

        // Second time (back from CAS) there is a ticket= to validate
        string validateurl = CASHOST + "serviceValidate?" +
        "ticket=" + tkt + "&" +
        "service=" + service;
        StreamReader Reader = new StreamReader(new WebClient().OpenRead(validateurl));
        string resp = Reader.ReadToEnd();
        // I like to have the text in memory for debugging rather than parsing the stream

        // Some boilerplate to set up the parse.
        NameTable nt = new NameTable();
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(nt);
        XmlParserContext context = new XmlParserContext(null, nsmgr, null, XmlSpace.None);
        XmlTextReader reader = new XmlTextReader(resp, XmlNodeType.Element, context);

        string netid = null;

        // A very dumb use of XML. Just scan for the "user". If it isn't there, its an error.
        while (reader.Read())
        {
            if (reader.IsStartElement())
            {
                string tag = reader.LocalName;
                if (tag == "user")
                    netid = reader.ReadString();
            }
        }
        // if you want to parse the proxy chain, just add the logic above
        reader.Close();
        // If there was a problem, leave the message on the screen. Otherwise, return to original page.
        if (netid == null)
        {
            //取得用户账号为空，按集成系统业务逻辑处理
            Response.Redirect("../Default.aspx");

        }
        else
        {
            //netid即为用户账号，根据账号实现集成系统的登录

            //如果登录成功，执行下面代码，否则按集成系统业务逻辑处理
            string newURL = Request.QueryString["redirectUrl"];
            if (newURL == null || newURL.Length == 0)
            {
                newURL = "../anywhere/Default.aspx";
                // newURL = "../Main/Main.aspx";
                //newURL = "../Main/MyDesk.aspx";
               // newURL = "../anywhere/Default.aspx";
            }
            Label1.Text = netid;

            //跳转到newURL的页面
    
             string IFPop = "否";
            LCX.BLL.LCXUser MyUser = new LCX.BLL.LCXUser();
         
            MyUser.UserLogin(netid, "jichengrenzheng", IFPop,"1", newURL);
      







        }
    }
}

public class MyPolicy : ICertificatePolicy
{
    public bool CheckValidationResult(
          ServicePoint srvPoint
        , X509Certificate certificate
        , WebRequest request
        , int certificateProblem)
    {

        //Return True to force the certificate to be accepted.
        return true;

    } // end CheckValidationResult
} // class MyPolicy
