using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class NetMail_EmlView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string s = Request.QueryString["file"];
            if (s != "")
            {
                StreamReader sr = new StreamReader(HttpContext.Current.Server.MapPath("eml\\") + s);
                this.Label1.Text = sr.ReadToEnd();              
                sr.Close();
            }        
        
        }
    }
}