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

public partial class Project_ProjectView : System.Web.UI.Page
{
    public string CustomNameStr = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXProject model = new LCX.BLL.LCXProject();
            /*if (Request.QueryString["ID"].ToString() != "1")
            {
                model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            }
            else {*/
                
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select ID ");
                strSql.Append(" FROM LCXProject ");
                strSql.Append(" where ProjectName=@ProjectName ");
                SqlParameter[] parameters = {
                    new SqlParameter("@ProjectName", SqlDbType.VarChar,200)};
                parameters[0].Value = Request.QueryString["DemandName"].ToString();
                int Proid = 0;
                DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                    {
                        Proid = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                    }
                }
                model.GetModel(Proid);
           // }
            this.ProjectName.Text = model.ProjectName;
            CustomNameStr = model.ProjectName;
            this.HyperLink1.NavigateUrl = "TuXingJinDu.aspx?ProjectName=" + model.ProjectName;
            this.ProjectSerils.Text = model.ProjectSerils;
            this.SuoShuKeHu.Text = model.SuoShuKeHu;
            this.YuJiChengJiaoRiQi.Text = model.YuJiChengJiaoRiQi;
            this.TiXingDate.Text = model.TiXingDate;
            this.FuZeRen.Text = model.FuZeRen;
            this.XiangMuJinE.Text = model.XiangMuJinE;
            this.XiangMuDaXiao.Text = model.XiangMuDaXiao;
            this.PeiHeRenList.Text = model.PeiHeRenList;
            this.UserName.Text = model.UserName;
            this.TimeStr.Text = model.TimeStr.ToString();
            this.HeTongAndFuJian.Text = LCX.Common.PublicMethod.GetWenJian(model.HeTongAndFuJian, "../UploadFile/"); 
            this.BackInfo.Text = model.BackInfo;
            this.ContactPerson.Text = model.ContactPerson;
            this.ContactTel.Text = model.ContactTel;
            this.ContactEmail.Text = model.ContactEmail;
            this.Push.Text = model.Push;

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "查看项目信息(" + this.ProjectName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
}
