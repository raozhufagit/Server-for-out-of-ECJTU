using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using System.Collections;
using System.Text;

public partial class Main_dtpUser : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string t = Request.Form["t"];
            switch (Int32.Parse(t))
            {
                case 0: { bmstr(); break; }//查询部门
                case 3: { userSelect();break; }
            }
        }
        
    }
    public JavaScriptSerializer jss = new JavaScriptSerializer();
    #region 获取部门JSON 根据传入的ID 获取子部门
    private void bmstr()
    {
        int bmid = 0;
        if (Request.Form["ID"] == null)
        {
            bmid = 0;
        }
        else
        {
            bmid = Int32.Parse(Request.Form["ID"]);
        }
        LCX.BLL.LCXDept bm = new LCX.BLL.LCXDept();
        DataSet ds = bm.GetList("DirID=" + bmid);
        if (ds.Tables[0].Rows.Count > 0)
        {
            List<Hashtable> a = new List<Hashtable>();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                Hashtable msg = new Hashtable();
                msg.Add("id", dr["ID"]);
                if (bm.childExists(Int32.Parse(dr["ID"].ToString())))
                {
                    msg.Add("isParent", true);
                }
                else
                {
                    msg.Add("isParent", false);
                }
                if (bmid == 0)
                {
                    msg.Add("icon", "/anywhere/images/user_list3/root.png");
                }
                else
                {
                    msg.Add("icon", "/anywhere/images/user_list3/org.png");
                }
                
                msg.Add("name", dr["BuMenName"]);
                a.Add(msg);
            }
            Response.Write(jss.Serialize(a).ToString());
        }
        else
        {
            Response.Write("[]");
        }
        Response.End();
    }
    #endregion
    #region 获取人员根据条件
    private void userSelect()
    {
        if (Request.Form["type"] == "selected")
        {
            usrOnline();
        }
        else if (Request.Form["type"] == "dept")
        {
            usrDept();
        }
        else if (Request.Form["type"] == "priv")
        {
            role();
        }
        else if (Request.Form["type"] == "bypriv")
        {
            usrRole();
        }
        else if (Request.Form["type"] == "online")
        {
            usrline();
        }
        else if (Request.Form["type"] == "query")
        {
            usrquery();
        }
        else
        {
            Response.End();
        }
    }
    #endregion
    #region 根据传入的ID获取在线人员姓名
    private void usrOnline()
    {        
        string iditem = Request.Form["item"];
        LCX.BLL.LCXUser usr = new LCX.BLL.LCXUser();
        string[] sArray = iditem.Split(new Char[] { ',' });
        string rsp = "<div class=\"block-right\" id=\"selected_item_0\">";
        rsp += "<div class=\"block-right-header\" title=\"已经选中人员\">已经选中人员</div>";
        rsp += "<div class=\"block-right-add\">全部添加</div>";
        rsp += "<div class=\"block-right-remove\">全部删除</div>";
        Hashtable msg = new Hashtable();
        
        foreach (string usrid in sArray)
        {
            if (usrid != "")
            {
                if(usr.GetUser(usrid)>0){
                    rsp += "<div class=\"block-right-item\" item_id=\"" + usr.UserName + "\" item_name=\"" + usr.TrueName + "\" user_id=\"" + usr.UserName + "\" title=\"" + usr.TrueName + "\"><span class=\"name\">" + usr.TrueName + "</span></div>";
                } 
            }
        }
        rsp += "</div>";
        msg.Add("item", rsp);
        Response.Write(jss.Serialize(msg).ToString());
        Response.End();
    }
    #endregion
    #region 根据传入的部门ID获取部门所有用户
    private void usrDept()
    {
        int bmid = 0;
        if (Request.Form["item"] == null)
        {
            return;
        }
        bmid = Int32.Parse(Request.Form["item"]);
        LCX.BLL.LCXDept bm = new LCX.BLL.LCXDept();
        bm.GetModel(bmid);
        string dept = bm.BuMenName;
        LCX.BLL.LCXUser usr = new LCX.BLL.LCXUser();
        DataSet ds = usr.GetList("Department='" + dept + "'");
        Hashtable msg = new Hashtable();
        string rsp = "<div class=\"block-right\" id=\"dept_item_"+bmid+"\">";
        rsp += "<div class=\"block-right-header\" title=\"" + dept + "\">" + dept + "</div>";
        rsp += "<div class=\"block-right-add\">全部添加</div>";
        rsp += "<div class=\"block-right-remove\">全部删除</div>";

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                rsp += "<div class=\"block-right-item\" item_id=\"" + dr["UserName"] + "\" item_name=\"" + dr["TrueName"] + "\" user_id=\"" + dr["UserName"] + "\" title=\"" + dr["TrueName"] + "\"><span class=\"name\">" + dr["TrueName"] + "</span></div>";
            }
        }

        rsp += "</div>";
        msg.Add("item", rsp);
        if (Request.QueryString["check"] == "true")
        {
            msg.Add("checked", true);
        }
        else
        {
            msg.Add("checked", false);
        }
       
        Response.Write(jss.Serialize(msg).ToString());
        Response.End();
    }
    #endregion
    #region 根据角色ID查询当前角色下面的所有人员
    private void role()
    {  
        LCX.BLL.LCXRole_Info bm = new LCX.BLL.LCXRole_Info();
        DataSet ds = bm.GetList("");
        Hashtable msg = new Hashtable();
        string str = "<div class=\"block-left-header\">按角色选择</div>";
        if (ds.Tables[0].Rows.Count > 0)
        {           
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
              str+="<div class=\"block-left-item\" block=\"priv\" item_id=\""+dr["ID"]+"\" query_string=\"\"><span>"+dr["JiaoSeName"]+"</span></div>";
            }            
        }
        msg.Add("item", "<div class=\"message\">请选择角色</div>");
        msg.Add("menu", str);
        Response.Write(jss.Serialize(msg).ToString());
        Response.End();
    }
    #endregion
    #region 根据传入的角色ID获取角色下所有用户
    private void usrRole()
    {
        int roleid = 0;
        if (Request.Form["item"] == null)
        {
            return;
        }
        roleid = Int32.Parse(Request.Form["item"]);
        LCX.BLL.LCXRole_Info js = new LCX.BLL.LCXRole_Info();
        js.GetModel(roleid);
        string jsname = js.JiaoSeName;
        LCX.BLL.LCXUser usr = new LCX.BLL.LCXUser();
        DataSet ds = usr.GetList("JiaoSe='" + jsname + "'");
        Hashtable msg = new Hashtable();
        string rsp = "<div class=\"block-right\" id=\"priv_item_" + roleid + "\">";

        rsp += "<div class=\"block-right-header\" title=\"" + jsname + "\">" + jsname + "</div>";
        rsp += "<div class=\"block-right-add\">全部添加</div>";
        rsp += "<div class=\"block-right-remove\">全部删除</div>";

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {                
                rsp += "<div class=\"block-right-item\" item_id=\"" + dr["UserName"] + "\" item_name=\"" + dr["TrueName"] + "\" user_id=\"" + dr["UserName"] + "\" title=\"" + dr["TrueName"] + "\"><span class=\"name\">" + dr["TrueName"] + "</span></div>";
            }
        }

        rsp += "</div>";
        msg.Add("item", rsp);        

        Response.Write(jss.Serialize(msg).ToString());
        Response.End();
    }
    #endregion
    #region 获取在线的用户
    private void usrline()
    {
        LCX.BLL.LCXUser usr = new LCX.BLL.LCXUser();
        DataSet ds = usr.GetList("datediff(minute,ActiveTime,getdate())<20");
        Hashtable msg = new Hashtable();
        string rsp = "<div class=\"block-right\" id=\"online_item_0\">";

        rsp += "<div class=\"block-right-header\" title=\"全部在线人员\">全部在线人员</div>";
        rsp += "<div class=\"block-right-add\">全部添加</div>";
        rsp += "<div class=\"block-right-remove\">全部删除</div>";

        if (ds.Tables[0].Rows.Count > 0)
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                rsp += "<div class=\"block-right-item\" item_id=\"" + dr["UserName"] + "\" item_name=\"" + dr["TrueName"] + "\" user_id=\"" + dr["UserName"] + "\" title=\"" + dr["TrueName"] + "\"><span class=\"name\">" + dr["TrueName"] + "</span></div>";             
            }
        }

        rsp += "</div>";
        msg.Add("item", rsp);

        Response.Write(jss.Serialize(msg).ToString());
        Response.End();
        
    }
    #endregion
    #region 根据用户名或编辑查询
    private void usrquery()
    { 

        string trname = "";
        Hashtable msg = new Hashtable();
        string rsp = "<div class=\"block-right\" id=\"query_item_0\">";
        rsp += "<div class=\"block-right-header\" title=\"查询人员\">查询人员</div>"; 
        try
        {
            trname = HttpUtility.UrlDecode(Request.Form["item"]);
            try
            {
                LCX.BLL.LCXUser usr = new LCX.BLL.LCXUser();
                DataSet ds = usr.GetList("TrueName like '%" + trname + "%'");
                if (ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        rsp += "<div class=\"block-right-item\" item_id=\"" + dr["UserName"] + "\" item_name=\"" + dr["TrueName"] + "\" user_id=\"" + dr["UserName"] + "\" title=\"" + dr["TrueName"] + "\"><span class=\"name\">" + dr["TrueName"] + "</span></div>";
                    }
                }
                else
                {
                    rsp += "<div class=\"message\">无符合条件的用户</div>";
                }

            }
            catch (Exception e)
            {
                rsp += "<div class=\"message\">查询错误!联系管理员</div>";
            }
        }catch(Exception e){
            rsp += "<div class=\"message\">查询请求参数错误</div>";
        }
        

        rsp += "</div>";
        msg.Add("item", rsp);

        Response.Write(jss.Serialize(msg).ToString());
        Response.End();

    }
    #endregion

}
