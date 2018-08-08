using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Management;
using Microsoft.Win32;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //需要真正清空登录用户时，请启用下面这句代码。考虑到部分用户不需要真正清空用户信息，只是转回登陆页。此处，留待自定义启用
       // LCX.Common.PublicMethod.SetSessionValue("UserName", null);
        //验证序列号是否正确
        if (!Page.IsPostBack)
        {
         
        }


        //判断系统的IP限制
        PassORNo();
    }

    private void PassORNo()
    {
        string NowIPStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();//访问者IP
        string[] LCXIPStr = ConfigurationManager.AppSettings["LCXIP"].ToString().Trim().Split('|');//允许的IP字符串组数组

        for (int i = 0; i < LCXIPStr.Length; i++)
        {
            if (LCX.Common.PublicMethod.StrIFIn(LCXIPStr[i].ToString(), NowIPStr) == true || LCXIPStr[i].ToString()=="*")
            {
                return;
            }
        }
        //执行到最后，不允许访问！
        this.TxtUserName.Enabled = false;
        this.TxtUserPwd.Enabled = false;
        this.ImageButton1.Enabled = false;

        LCX.Common.MessageBox.Show(this, "您的访问IP不在系统允许范围内，您不能登录系统，请联系管理员admin！");
    
    }



    //获得网卡序列号----MAc地址
    public string GetMoAddress()
    {
        try
        {
            //读取硬盘序列号
            ManagementObject disk;
            disk = new ManagementObject("win32_logicaldisk.deviceid=\"c:\"");
            disk.Get();



            string MoAddress = "BD-CNSOFTWEB";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            foreach (ManagementObject mo in moc2)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    string a = mo["MacAddress"].ToString();
                    string c = disk.GetPropertyValue("VolumeSerialNumber").ToString();
                    MoAddress = "BD-" + a + "-" + c + "-CNSOFTWEB";
                    break;
                }
            }
            return MoAddress.ToString().Replace(":", "");
        }
        catch
        {
            return "BD-ERR-CNSOFTWEB";
        }
    }

    /**/
    /// <summary>
    /// 分析用户请求是否正常
    /// </summary>
    /// <param name="Str">传入用户提交数据</param>
    /// <returns>返回是否含有SQL注入式攻击代码</returns>
    public string ProcessSqlStr(string Str)
    {
        string SqlStr = "exec|insert|select|delete|update|count|chr|mid|master|truncate|char|declare";
        string ReturnValue = Str;
        try
        {
            if (Str != "")
            {
                string[] anySqlStr = SqlStr.Split('|');
                foreach (string ss in anySqlStr)
                {
                    if (Str.ToLower().IndexOf(ss) >= 0)
                    {
                        ReturnValue = "";
                    }
                }
            }
        }
        catch
        {
            ReturnValue = "";
        }
        if (Str.Length > 20)
        {
            ReturnValue = "";
        }
        return ReturnValue;
    }
    protected void ImageButton1_Click1(object sender, EventArgs e)
    {
        if (TxtUserName.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请先填写用户名!');</script>");
            return;
        }
        if (TxtUserPwd.Text.Trim() == "")
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "", "<script>alert('请填写密码!');</script>");
            return;
        }
        string IFPop = "否";
        
        LCX.BLL.LCXUser MyUser = new LCX.BLL.LCXUser();
        string theme = "anywhere/Default.aspx";       
        //string theme = "Main/Main.aspx";
        //string theme = "Main/MyDesk.aspx";
        MyUser.UserLogin(TxtUserName.Text.Trim(), LCX.Common.DEncrypt.DESEncrypt.Encrypt(TxtUserPwd.Text), IFPop, ConfigurationManager.AppSettings["OALogin"].ToString().Trim(),theme);
    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
}
