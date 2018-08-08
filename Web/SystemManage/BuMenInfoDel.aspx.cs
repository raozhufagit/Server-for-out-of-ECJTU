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

public partial class SystemManage_BuMenInfoDel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (LCX.DBUtility.DbHelperSQL.GetSHSLInt("select top 1 ID from LCXDept where DirID=" + Request.QueryString["ID"].ToString()) == "0")
        {
            LCX.BLL.LCXDept bm = new LCX.BLL.LCXDept();
            bm.GetModel(Int32.Parse(Request.QueryString["ID"].ToString()));

            LCX.DBUtility.DbHelperSQL.ExecuteSQL("delete from LCXDept where ID=" + Request.QueryString["ID"].ToString());
            if (System.Configuration.ConfigurationManager.AppSettings["rtx"] == "1")   
            {
                if (Rtx.IsDeptExist(bm.BuMenName) != 1)
                {
                    LCX.Common.MessageBox.Show(this, "系统部门不存在！");                   
                }
                else
                {
                    if (!Rtx.DelDept(bm.BuMenName))
                    {
                        LCX.Common.MessageBox.Show(this, "系统部门删除失败！请手工删除！");
                    }
                }
               
            }
            LCX.Common.MessageBox.Show(this, "选定部门已经删除！");
            Response.Redirect("BuMenInfo.aspx?View=" + Request.QueryString["View"].ToString() + "&Type=&DirID=0");
        }
        else
        {            
            LCX.Common.MessageBox.Show(this, "当前部门下有子部门的存在，请先删除子部门后，再删除当前部门数据！");
            Response.Redirect("BuMenInfo.aspx?View=" + Request.QueryString["View"].ToString() + "&Type=&DirID=0");
        }
    }
}
