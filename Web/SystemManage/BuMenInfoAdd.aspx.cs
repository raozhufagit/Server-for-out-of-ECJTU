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

public partial class SystemManage_BuMenInfoAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        //如果需要同步系统  
        if (System.Configuration.ConfigurationManager.AppSettings["rtx"] == "1") {
            if (Rtx.IsDeptExist(this.TextBox1.Text) > 0)
            {
                LCX.Common.MessageBox.Show(this, "该部门在系统中已经存在，请检查系统服务器！");
                return;
            }
            else
            {
                int parentDept = int.Parse(Request.QueryString["DirID"].ToString());
                if (parentDept > 0)
                {
                    LCX.BLL.LCXDept MyBuMen = new LCX.BLL.LCXDept();
                    MyBuMen.GetModel(int.Parse(Request.QueryString["DirID"].ToString()));
                    if (!Rtx.addDepart(this.TextBox1.Text, MyBuMen.BuMenName))
                    {
                        LCX.Common.MessageBox.Show(this, "该部门在系统中添加失败，请检查系统服务器！");
                    }
                }
                else
                {
                    if (!Rtx.addDepart(this.TextBox1.Text, ""))
                    {
                        LCX.Common.MessageBox.Show(this, "该部门在系统中添加失败，请检查系统服务器！");
                        return;
                    }
                }
            }
        }
        
       




        if (LCX.Common.PublicMethod.IFExists("BuMenName", "LCXDept", 0, this.TextBox1.Text) == true)
        {
            LCX.BLL.LCXDept MyBuMen = new LCX.BLL.LCXDept();
            MyBuMen.BuMenName = this.TextBox1.Text;
            MyBuMen.ChargeMan = this.TextBox2.Text;
            MyBuMen.TelStr = this.TextBox3.Text;
            MyBuMen.ChuanZhen = this.TextBox4.Text;
            MyBuMen.BackInfo = this.TextBox5.Text;
            MyBuMen.DirID = int.Parse(Request.QueryString["DirID"].ToString());
            MyBuMen.Add();


            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户添加部门信息(" + this.TextBox1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            LCX.Common.MessageBox.ShowAndRedirect(this, "部门信息添加成功！", "BuMenInfo.aspx?View=" + Request.QueryString["View"].ToString() + "&Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + Request.QueryString["DirID"].ToString());
        }
        else
        {
            LCX.Common.MessageBox.Show(this, "该部门已经存在，请更换名称！");
        }
    }
}
