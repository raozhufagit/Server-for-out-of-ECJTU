using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

public partial class Meeting_meet : System.Web.UI.Page
{
    public string MeetingIP = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack==false)
        {
            MeetingIP = ConfigurationManager.AppSettings["MeetingIP"];
        }
    }
}