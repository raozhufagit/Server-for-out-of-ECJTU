using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.Script.Serialization;
using LCX.Common;
using LCX.DBUtility;

public partial class anywhere_menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        foreach (DataRow idd in getMenuID(0, false))
        {
            if (getMenuID(Int32.Parse(idd["ID"].ToString()), false).Count > 0)
            {
                Response.Write("func_array[\"m" + idd["ID"] + "\"]=[\"" + idd["TextStr"] + "\",\"" + idd["ImageUrlStr"] + "\"];\n");
                foreach (DataRow ids in getMenuID(Int32.Parse(idd["ID"].ToString()), false))
                {
                    if (getMenuID(Int32.Parse(ids["ID"].ToString()), false).Count > 0)
                    {
                        Response.Write("func_array[\"f" + ids["ID"] + "\"]=[\"" + ids["TextStr"] + "\",\"@" + ids["ImageUrlStr"] + "\",\"@"+ ids["ImageUrlStr"]+"\"];\n");
                        // func_array["f44"]=["客户关系","@crm","@crm"];
                    }
                    else
                    {
                        Response.Write("func_array[\"f" + ids["ID"] + "\"]=[\"" + ids["TextStr"] + "\",\"" + ids["NavigateUrlStr"] + "\",\"" + ids["ImageUrlStr"] + "\"];\n");
                    }
                }
            }
        } 

    }


    //根据ID值获取菜单
    public ArrayList getMenuID(int IDStr, Boolean fs)
    {
        ArrayList _menu = new ArrayList();
        foreach (DataRow tr in BindTree(IDStr))
        {
            if (fs)
            {
                _menu.Add(tr["ID"].ToString());
            }
            else
            {
                _menu.Add(tr);
            }
        }
        return _menu;
    }



    //  返回一级分类
    private ArrayList BindTree(int IDStr)
    {
        ArrayList menuStr = new ArrayList();
        DataSet MYDT = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from LCXTreeList where ParentID=" + IDStr.ToString() + " order by PaiXuStr asc,ID asc");
        for (int i = 0; i < MYDT.Tables[0].Rows.Count; i++)
        {
            if (QuanXian(MYDT.Tables[0].Rows[i]["ValueStr"].ToString()))
            {
                menuStr.Add(MYDT.Tables[0].Rows[i]);
            }
        }
        return menuStr;
    }

    //权限判定
    public Boolean QuanXian(string idIndex)
    {
        if (PublicMethod.StrIFIn("|" + idIndex + "|", LCX.Common.PublicMethod.GetSessionValue("QuanXian")) == false)
        {
            return false;
        }
        return true;
    }
}