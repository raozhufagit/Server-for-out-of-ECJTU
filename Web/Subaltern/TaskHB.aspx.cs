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

public partial class Subaltern_TaskHB : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXTaskFP Model = new LCX.BLL.LCXTaskFP();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblTaskTitle.Text = Model.TaskTitle.ToString();
            this.lblTaskContent.Text = Model.TaskContent.ToString();
            this.lblFromUser.Text = Model.FromUser.ToString();
            this.lblToUserList.Text = Model.ToUserList.ToString();
            this.lblXinXiGouTong.Text = Model.XinXiGouTong.ToString();
            this.lblJinDu.Text = Model.JinDu.ToString() + "%";
            this.lblWanCheng.Text = Model.WanCheng.ToString();
            this.lblNowState.Text = Model.NowState.ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        string SqlStr = "update LCXTaskFP set JinDu=" + this.txtJinDu.Text.Trim() + ",WanCheng='" + this.txtWanCheng.Text.Trim() + "',XinXiGouTong='"+GetNowString()+"' where ID=" + Request.QueryString["ID"].ToString();

        LCX.DBUtility.DbHelperSQL.ExecuteSQL(SqlStr);
        
        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户汇报任务最新信息(" + this.lblTaskTitle.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "任务最新情况汇报成功！", "Task.aspx");
    }

    public string GetNowString()
    {
        string ReturnStr = "";
        ReturnStr = "汇报用户：" + LCX.Common.PublicMethod.GetSessionValue("UserName") +"&nbsp;&nbsp;时间：" + DateTime.Now.ToString();        
        ReturnStr = ReturnStr + "&nbsp;&nbsp;最新进度：" + "<img src=\"../images/vote_bg.gif\" width=" + this.txtJinDu.Text.Trim() + "  height=10 />&nbsp;" + this.txtJinDu.Text.Trim() + "%";
        ReturnStr =ReturnStr+ "<br>完成情况：" + this.txtWanCheng.Text.Trim();
        ReturnStr =ReturnStr+ "<br>汇报内容：" + this.TextBox1.Text.Trim() + "<hr style=\"height:1px; color: #006600;\">" + this.lblXinXiGouTong.Text;

        return ReturnStr;
    }
}
