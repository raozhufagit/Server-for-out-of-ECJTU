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

public partial class Project_LiRunView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXLiRun model = new LCX.BLL.LCXLiRun();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblProjectName.Text = model.ProjectName;
            this.lblProjectSerils.Text = model.ProjectSerils;
            this.lblSumJinE.Text = model.SumJinE;
            this.lblFeiYong.Text = model.FeiYong;
            this.lblChengBen.Text = model.ChengBen;
            this.lblFangZu.Text = model.FangZu;
            this.lblShuiE.Text = model.ShuiE;
            this.lblGongZi.Text = model.GongZi;
            this.lblTiCheng.Text = model.TiCheng;
            this.lblQiTa.Text = model.QiTa;
            this.lblShiJi.Text = model.ShiJi;
            this.lblUserName.Text = model.UserName;
            this.lblTimeStr.Text = model.TimeStr.ToString();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看利润核算信息(" + this.lblProjectName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}
