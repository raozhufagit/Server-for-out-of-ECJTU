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

public partial class Project_PinShenView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXPinShen model = new LCX.BLL.LCXPinShen();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblProjectName.Text = model.ProjectName;
            if (model.ProjectSerils == "0")
            {
                this.lblProjectSerils.Text = "企业提出项目需求";
            }
            else if (model.ProjectSerils == "1")
            {
                this.lblProjectSerils.Text = "企业和老师沟通中";
            }
            else if (model.ProjectSerils == "2")
            {
                this.lblProjectSerils.Text = "企业和老师确认承接项目";
            }
            else if (model.ProjectSerils == "3")
            {
                this.lblProjectSerils.Text = "老师实施项目中";
            }
            else if (model.ProjectSerils == "4")
            {
                this.lblProjectSerils.Text = "项目完成，老师和企业对项目进行评价总结";
            }
            else
            {
                this.lblProjectSerils.Text = " ";
            }
            this.lblPingShenTime.Text = model.PingShenTime;
            this.lblPingShenJieGuo.Text = model.PingShenJieGuo;
            this.lblUserName.Text = model.UserName;
            this.lblTimeStr.Text = model.TimeStr.ToString();
            this.lblBachInfo.Text = model.BachInfo;

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看评审信息(" + this.lblProjectName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}
