using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Meeting_zl_checkUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Response.ContentType = "text/xml";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            Response.Clear();

            Page.Response.Write("<?xml version=\"1.0\" encoding=\"GB2312\" ?>");
            Page.Response.Write("<Result isUser=\"true\"></Result>");
            Page.Response.End();
        }
    }
}