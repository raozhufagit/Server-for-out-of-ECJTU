using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ScManufact_saveXML : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
                       
            LCX.Common.PublicMethod.CheckSession();
            if (Request.Form["filename"] == null || Request.Form["data"] == null)
            {
                Response.Write("数据保存参数不正确！");
                Response.End();
                return;
            }
            try
            {   string filePath=Server.MapPath("xml\\"+Request.Form["filename"]);
                string data = System.Web.HttpUtility.UrlDecode(Request.Form["data"], System.Text.Encoding.UTF8);
                 FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
                  

                 StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.GetEncoding("UTF-8"));
                 fs.SetLength(0);//首先把文件清空了。
                 sw.Write(data);//写你的字符串。
                 sw.Close();

                // byte[] bytes = System.Text.Encoding.Default.GetBytes(data);
                // fs.Write(bytes, 0, bytes.Length); 
                 fs.Close();


                 Response.Write("数据保成成功");
                 Response.End();
            }
            catch (Exception ex)
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "ID参数不正确！" + ex, "ScPlan.aspx");
                return;
            }
        }
    }
}