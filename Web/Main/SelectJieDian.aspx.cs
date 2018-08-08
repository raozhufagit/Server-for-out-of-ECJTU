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

public partial class Main_SelectJieDian : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataBindToGridview();
        }
    }
    public void DataBindToGridview()
    {
        LCX.DBUtility.DbHelperSQL.BindGridView("select NodeSerils as SelectContent,NodeName from LCX_WorkFlowNode where WorkFlowID=" + Request.QueryString["WorkFlowID"].ToString() + " order by SelectContent asc", this.GridView1);
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        this.GridView1.PageIndex = e.NewPageIndex;
        DataBindToGridview();
    }    
}