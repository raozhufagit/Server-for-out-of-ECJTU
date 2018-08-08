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
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

public partial class Main_allUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindTree(this.ListTreeView.Nodes, 0);
        }
    }
    private void BindTree(TreeNodeCollection Nds, int IDStr)
    {
        //SqlConnection Conn = new SqlConnection(DecryptDBStr(ConfigurationManager.AppSettings["SQLConnectionString"].ToString(),"zhangweilong"));
        SqlConnection Conn = new SqlConnection(ConfigurationManager.AppSettings["SQLConnectionString"].ToString());
        Conn.Open();
        SqlCommand MyCmd = new SqlCommand("select * from LCXDept where DirID=" + IDStr.ToString() + " order by ID asc", Conn);
        SqlDataReader MyReader = MyCmd.ExecuteReader();
        while (MyReader.Read())
        {
            TreeNode OrganizationNode = new TreeNode();
            OrganizationNode.Text = MyReader["BuMenName"].ToString();
            OrganizationNode.Value = MyReader["ID"].ToString();
            int strId = int.Parse(MyReader["ID"].ToString());
            OrganizationNode.ImageUrl = "~/images/user_group.gif";
            OrganizationNode.SelectAction = TreeNodeSelectAction.Expand;
            OrganizationNode.Expanded = false;//modified by zhangheng

            /////////////////////////////////////////////////////////////////////////////////////////////////////
            //在当前节点下加入用户    
            SqlConnection Conn1 = new SqlConnection(ConfigurationManager.AppSettings["SQLConnectionString"].ToString());
            Conn1.Open();
            SqlCommand MyCmd1 = new SqlCommand("select * from LCXUser where Department='" + MyReader["BuMenName"].ToString() + "' order by ID asc", Conn1);
            SqlDataReader MyReader1 = MyCmd1.ExecuteReader();

            while (MyReader1.Read())
            {
                TreeNode UserNode = new TreeNode();
                UserNode.Text = MyReader1["TrueName"].ToString() + "&nbsp;<a class=\"BlueCss\" style=\"cursor:pointer\" OnClick='top.openURL(\"197\", \"写邮件\", \"../LanEmail/LanEmailAdd.aspx?UserName=" + MyReader1["UserName"].ToString() + "\")'>[发邮件]</a> <a class=\"BlueCss\" style=\"cursor:pointer\" OnClick='top.openURL(\"999\", \"发短信\", \"../Mobile/MobileSmsAdd.aspx?ShouJilist=" + MyReader1["UserName"].ToString() + "\")'>[发短信]</a>";
                UserNode.Value = MyReader1["ID"].ToString();
                UserNode.ToolTip = MyReader1["UserName"].ToString();
                UserNode.ImageUrl = OnLinePic(MyReader1["ID"].ToString());
                    // UserNode.NavigateUrl = "../LanEmail/LanEmailAdd.aspx?UserName=" + MyReader1["UserName"].ToString();
                OrganizationNode.ChildNodes.Add(UserNode);
                
            }
            MyReader1.Close();
            Conn1.Close();
            /////////////////////////////////////////////////////////////////////////////////////////////////////

            Nds.Add(OrganizationNode);

            //递归循环
            BindTree(Nds[Nds.Count - 1].ChildNodes, strId);
        }
        MyReader.Close();
        Conn.Close();
    }

    private string OnLinePic(string IDStr)
    {
        string ReturnStr = "~/images/U01.gif";
        //判断是否在线
        string OnlineUserName = LCX.DBUtility.DbHelperSQL.GetSHSL("select UserName from LCXUser where ID=" + IDStr + " and datediff(minute,ActiveTime,getdate())<20");
        if (OnlineUserName.Trim().Length > 0)
        {
            ReturnStr = "~/images/U01.gif";
        }
        else
        {
            ReturnStr = "~/images/U02.gif";
        }
        return ReturnStr;
    }
    //判断是否在线返回TRUE或FALSE
    private bool OnLine(string IDStr)
    {
        string OnlineUserName = LCX.DBUtility.DbHelperSQL.GetSHSL("select UserName from LCXUser where ID=" + IDStr + " and datediff(minute,ActiveTime,getdate())<20");
        if (OnlineUserName.Trim().Length > 0)
        {
            return true;
        }
        return false;
    }
}