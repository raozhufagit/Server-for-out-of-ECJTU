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

public partial class GongGao_VoteView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXVote MyModel = new LCX.BLL.LCXVote();
            MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.Label1.Text = MyModel.TitleStr;
            this.Label2.Text = LCX.Common.PublicMethod.GetVoteTable(MyModel.ContentStr, MyModel.ScoreStr, Request.QueryString["ID"].ToString(), LCX.Common.PublicMethod.StrIFIn("|" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "|", LCX.DBUtility.DbHelperSQL.GetSHSL("select TouPiaoRenList from LCXVote where ID="+Request.QueryString["ID"].ToString())));
            this.Label3.Text = MyModel.UserName;
            this.Label4.Text = MyModel.TimeStr.ToString();
        }
    }
}
