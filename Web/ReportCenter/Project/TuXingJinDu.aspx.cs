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

public partial class Project_TuXingJinDu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            this.lblProjectName.Text = Request.QueryString["ProjectName"].ToString();

            //绘出图形化显示  根据项目名称，获取最大进度日期和最小进度日期
            string MaxDate = LCX.DBUtility.DbHelperSQL.GetSHSL("select Max(EndTime) from LCXJinDu where ProjectName='" + Request.QueryString["ProjectName"].ToString() + "'");
            string MinDate = LCX.DBUtility.DbHelperSQL.GetSHSL("select Min(StartTime) from LCXJinDu where ProjectName='" + Request.QueryString["ProjectName"].ToString() + "'");


            DataSet MyDT = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from LCXJinDu where ProjectName='" + Request.QueryString["ProjectName"].ToString() + "' order by StartTime asc");
            for (int i = 0; i < MyDT.Tables[0].Rows.Count; i++)
            {
                string NowStart = MyDT.Tables[0].Rows[i]["StartTime"].ToString();
                string NowEnd = MyDT.Tables[0].Rows[i]["EndTime"].ToString();
                int JianGeA = int.Parse(LCX.DBUtility.DbHelperSQL.GetSHSL("select datediff(d,'" + MinDate + "','" + NowStart + "')"));
                int JianGeB = int.Parse(LCX.DBUtility.DbHelperSQL.GetSHSL("select datediff(d,'" + NowStart + "','" + NowEnd + "')"));
                this.Label1.Text = Label1.Text + "<table><tr><td width=" + JianGeA * 10 + "></td><td><img src=\"../images/vote_bg.gif\" height=10 width=" + JianGeB * 10 + " />&nbsp;" + NowStart.Split(' ')[0] + "&nbsp;~&nbsp;" + NowEnd.Split(' ')[0] + "(" + MyDT.Tables[0].Rows[i]["JieDuanName"].ToString() + ")</td></tr></table>";
            }
        }        
    }
}
