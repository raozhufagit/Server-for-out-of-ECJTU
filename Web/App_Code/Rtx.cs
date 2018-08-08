using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using RTXSAPILib;

/// <summary>
///Rtx 的摘要说明
/// </summary>
public class Rtx
{
    private static RTXSAPILib.RTXSAPIRootObj RootObj=  new RTXSAPIRootObj();
    private static RTXSAPILib.RTXSAPIUserManager UserManagerObj =RootObj.UserManager;
    private static RTXSAPILib.RTXSAPIDeptManager DeptManagerObj = RootObj.DeptManager;       //声明一个应用对象 
	public Rtx()
	{
       
		//
		//TODO: 在此处添加构造函数逻辑
        //
    }
    //发出RTX消息
    public static int sendMsg(string msg, string toUser)
    {
        
        return  0;
    }
    //由系统发出通知消息
    public static bool sendNotify(string msgContent, string toUserList)
    {
        string[] sr = toUserList.Split(',');
        for (int i = 0; i < sr.Length; i++)
        {
            try
            {
                RootObj.ServerIP = System.Configuration.ConfigurationManager.AppSettings["rtxip"]; //设置服务器IP
                RootObj.ServerPort = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["rtxport"]); //设置服务器端口
                RootObj.SendNotify(sr[i], "系统提示", 10000000, msgContent); //
              //("发送成功");
            }
            catch (Exception e)
            {
                return false;
            }
        }
        return true;
    }
    //RTX单个发送通知
    public static bool sendNotifyS(string title, string msgContent, string toUser)
    {
        try
            {
                RootObj.ServerIP = System.Configuration.ConfigurationManager.AppSettings["rtxip"]; //设置服务器IP
                RootObj.ServerPort = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["rtxport"]); //设置服务器端口
                int _Viewminutes = Convert.ToInt16(System.Configuration.ConfigurationManager.AppSettings["rtxwait"]); //设置服务器端口
                msgContent += "   请登陆[OA系统|10.10.10.201]办理。 发送时间:" + DateTime.Now.ToString();
                RootObj.SendNotify(toUser, title, _Viewminutes*1000, msgContent); //获取版本信息              
            }
            catch (Exception e)
            {
                return false;
            }        
        return true;
    }
    //RTX发送通知LIST
    public static void sendNotifyList(string title,string ToUserList, string ContentStr)
    {
        DataSet MyDT = LCX.DBUtility.DbHelperSQL.GetDataSet("select UserName from LCXRtx where UserName in('" + ToUserList.Replace(",", "','") + "')");
        for (int i = 0; i < MyDT.Tables[0].Rows.Count; i++)
        {
            if (!string.IsNullOrEmpty(MyDT.Tables[0].Rows[i]["UserName"].ToString()))
            {
                sendNotifyS(title, ContentStr, MyDT.Tables[0].Rows[i]["UserName"].ToString());
                
            }
        }
      
    }
    #region  用户操作区    
    //RTX添加用户
    public static bool addUser(string txtUserName, int txtAuthType)
    {
        try
        {
            UserManagerObj.AddUser(txtUserName, txtAuthType);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    //设置用户密码
    public static bool setPwd(string txtUserName,string txtPwd)
    {
        try
        {
            UserManagerObj.SetUserPwd(txtUserName, txtPwd);
            return true;
        }catch (Exception ex){
            return false;
        }
    }
    //删除用户
    public static bool delUser(string txtUserName)
    {
        try
        {
            UserManagerObj.DeleteUser(txtUserName);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    //查询用户是否存在 2 是错误 0是存在
    public static int isExist(string txtUserName)
    {
        try
        {
            if (UserManagerObj.IsUserExist(txtUserName) == true)
            {
                return 1;
            }else{
                return 0;
            }
        }
        catch (Exception ex)
        {
            return 2;
        }
    }

    public static bool updatePhone(string userName,string phonestr)
    {
        string pbstrName;
        int plGender;
        string pbstrMobile;
        string pbstrEMail;
        string pbstrPhone;
        string sexstr="女";
        int plAuthType;
        UserManagerObj.GetUserBasicInfo(userName, out pbstrName, out plGender, out pbstrMobile, out pbstrEMail, out pbstrPhone, out plAuthType);
        if (plGender == 0)
        {
            sexstr = "男";
        } 
        return setUser(userName, pbstrName, sexstr, phonestr, pbstrEMail, pbstrPhone, "", plAuthType);
    }
    
    //设置用户资料
    public static bool setUser(string txtUserName, string trueName, string sex, string mob, string email, string phone,string DptName, int AuthTYpe)
    {
        int IGender = 0;
        if (sex == "男")
        {
            IGender = 0;
        }else{
            IGender = 1;
        }
        if (DptName != "")  //设置用户所属部门
        {
            if (!usrToDpt(txtUserName, DptName))
            {
                return false;
            }
        }
        
        try
        {
            UserManagerObj.SetUserBasicInfo(txtUserName, trueName, IGender, mob, email, phone, AuthTYpe);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
      
    }
    //一次性添加用户
    public static bool addU(string txtUserName, string txtPwd, string trueName, string sex, string mob, string email, string phone,string DptName,int AuthTYpe)
    {
        if (isExist(txtUserName) > 0)
        {
            return false;
        }
        if (addUser(txtUserName, AuthTYpe))
        {
            if (!setPwd(txtUserName, txtPwd))
            {
                delUser(txtUserName);
            }
            else
            {
                if (setUser(txtUserName, trueName, sex, mob, email, phone, DptName, AuthTYpe))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        return true;
    }
    //修改用户
    public static bool updateU(string txtUserName, string txtPwd, string trueName, string sex, string mob, string email, string phone, string DptName)
    {
        if (!setPwd(txtUserName, txtPwd))
        {
            delUser(txtUserName);
        }else{
           if (setUser(txtUserName, trueName, sex, mob, email, phone,DptName,0)){
                return true;
            }
        }
        return false;
    }
    #endregion

    #region 部门操作
    //添加部门
    public static bool addDepart(String txtDeptName, string txtParentDept)
    {
        try
        {
            DeptManagerObj.AddDept(txtDeptName, txtParentDept); //添加部门,如果用户没有上级部门，txtParentDept不需填写，为空即可
            return true;            
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    //修改部门名称
    public static bool updateDeapart(string oldDepartName, string newDepartName)
    {
        try
        {
            DeptManagerObj.SetDeptName(oldDepartName, newDepartName); //'设置部门名称
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    //查询部门是否存在
    public static int IsDeptExist(string DepartName)
    {
        try
        {
            bool bRet;

            bRet = DeptManagerObj.IsDeptExist(DepartName);

            if (bRet == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception ex)
        {
            return 2;
        }
    }
    //删除部门
    public static bool DelDept(string DepartName)
    {
        try
        {
            DeptManagerObj.DelDept(DepartName, true); //'删除部门
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
    #endregion
    //设置用户所属部门
    public static bool usrToDpt(string userName,string deptName)
    {
        try
        {
            DeptManagerObj.AddUserToDept(userName, null, deptName, false); //添加用户进某个部门,如果用户没有所属部门，源部门名为null即可。
            return true;
        }
        catch(Exception ex)
        {
            return false;
        }
    }
}