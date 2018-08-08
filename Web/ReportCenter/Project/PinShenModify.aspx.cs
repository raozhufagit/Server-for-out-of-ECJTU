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
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

public partial class Project_PinShenModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXPinShen model = new LCX.BLL.LCXPinShen();
            model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtProjectName.Text = model.ProjectName;
           // LCX.BLL.LCXProject mode2 = new LCX.BLL.LCXProject();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Push,ProjectState ");
            strSql.Append(" FROM LCXProject ");
            strSql.Append(" where ProjectName=@ProjectName ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ProjectName", SqlDbType.VarChar,200)};
            parameters[0].Value = model.ProjectName;
            int Proid = 21;
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    Proid = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                this.Push.Text = ds.Tables[0].Rows[0]["Push"].ToString();
                if (ds.Tables[0].Rows[0]["ProjectState"].ToString() != "")
                {
                    this.txtProjectSerils.Text = ds.Tables[0].Rows[0]["ProjectState"].ToString();
                }
            }

            this.Label1.Text = Proid.ToString();
            if (model.ProjectSerils == "0")
            {
                this.txtProjectSerils.Text = "企业提出项目需求";
            }
            else if (model.ProjectSerils == "1")
            {
                this.txtProjectSerils.Text = "企业和老师沟通中";
            }
            else if (model.ProjectSerils == "2")
            {
                this.txtProjectSerils.Text = "企业和老师确认承接项目";
            }
            else if (model.ProjectSerils == "3")
            {
                this.txtProjectSerils.Text = "老师实施项目中";
            }
            else if (model.ProjectSerils == "4")
            {
                this.txtProjectSerils.Text = "项目完成，老师和企业对项目进行评价总结";
            }
            else
            {
                this.txtProjectSerils.Text = " ";
            }
            this.txtPingShenTime.Text = DateTime .Now.ToString();
            this.txtPingShenJieGuo.Text = model.PingShenJieGuo;
            this.txtBachInfo.Text = model.BachInfo;
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXPinShen model = new LCX.BLL.LCXPinShen();
        model.ID = int.Parse(Request.QueryString["ID"].ToString());
        model.ProjectName = this.txtProjectName.Text;
        model.ProjectSerils = this.txtProjectSerils.Text;
        model.PingShenTime = this.txtPingShenTime.Text;
        model.PingShenJieGuo = this.txtPingShenJieGuo.Text;
        model.BachInfo = this.txtBachInfo.Text;
        model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.TimeStr = DateTime.Now;
        model.Update();
        LCX.BLL.LCXProject mode2 = new LCX.BLL.LCXProject(int.Parse(this.Label1.Text));
        mode2.Push = this.Push.Text;
        mode2.ProjectState = 1;
        mode2.Update();
        string[] SendMsgToDep= mode2.Push.Split(',');
     //   string[]
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select UserName ");
        strSql.Append(" FROM LCXUser ");
        strSql.Append(" where Department=@Department ");
        SqlParameter[] parameters = {
                    new SqlParameter("@Department", SqlDbType.VarChar,50)};
        for(int i=0;i< SendMsgToDep.Length; i++)
        {
            parameters[0].Value = SendMsgToDep[i];
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            for(int j=0;j< ds.Tables[0].Rows.Count; j++)
            SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, mode2.UserName + "发布了新的生产明细单【" + model.ProjectName + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(ds.Tables[0].Rows[j]["UserName"].ToString()));
        }
       
      

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改评审信息(" + this.txtProjectName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "评审信息修改成功！", "PingShen.aspx?ProjectName=" + model.ProjectName);
    }
}