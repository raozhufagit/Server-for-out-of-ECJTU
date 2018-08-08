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
using System.IO;

public partial class DocCenter_DocCenter : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataBindToGridview();
            GetDaoHang(int.Parse(Request.QueryString["DirID"].ToString()));
        }
    }
    public void GetDaoHang(int DirID)
    {
        if (DirID == 0)
        {
            if (this.Label1.Text.Trim() == "")
            {
                this.Label1.Text = "<a href=\"DocCenter.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=0\" >" + Request.QueryString["Type"].ToString() + "</a>";
            }
            else
            {
                this.Label1.Text = "<a href=\"DocCenter.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=0\" >" + Request.QueryString["Type"].ToString() + "</a>" + "\\" + this.Label1.Text;
            }
        }
        else
        {
            if (this.Label1.Text.Trim() == "")
            {
                this.Label1.Text = "<a href=\"DocCenter.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + DirID.ToString() + "\" >" + LCX.DBUtility.DbHelperSQL.GetSHSL("select FileName from LCXFileList where ID=" + DirID.ToString()) + "</a>";
            }
            else
            {
                this.Label1.Text = "<a href=\"DocCenter.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + DirID.ToString() + "\" >" + LCX.DBUtility.DbHelperSQL.GetSHSL("select FileName from LCXFileList where ID=" + DirID.ToString()) + "</a>" + "\\" + this.Label1.Text;
            }
            int FatherID = int.Parse(LCX.DBUtility.DbHelperSQL.GetSHSLInt("select DirID from LCXFileList where ID=" + DirID.ToString()));
            if (FatherID == 0)
            {
                this.Label1.Text = this.Label1.Text = "<a href=\"DocCenter.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=0\" >" + Request.QueryString["Type"].ToString() + "</a>" + "\\" + this.Label1.Text;
            }
            else
            {
                GetDaoHang(FatherID);
            }
        }
    }
    public void DataBindToGridview()
    {
        string DirID = "0";
        try
        {
            DirID = Request.QueryString["DirID"].ToString();
        }
        catch { }

        LCX.BLL.LCXFileList MyModel = new LCX.BLL.LCXFileList();
        if (Request.QueryString["Type"].ToString().Trim() == "个人文件")
        {
            //设定按钮权限            
            ImageButton6.Visible = LCX.Common.PublicMethod.StrIFIn("|029N|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|029A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|029M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|029D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|029E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));

            GVData.DataSource = MyModel.GetList("DirID=" + DirID + " and TypeName='" + Request.QueryString["Type"].ToString().Trim() + "' and IFDel='否' and UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "' and FileName Like '%" + this.TextBox1.Text + "%' order by DirOrFile desc,ID desc");
        }        
        else if (Request.QueryString["Type"].ToString().Trim() == "单位文件")
        {
            //设定按钮权限            
            ImageButton6.Visible = LCX.Common.PublicMethod.StrIFIn("|030N|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|030A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|030M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|030D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|030E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            GVData.DataSource = MyModel.GetList("DirID=" + DirID + " and  (( ','+CanView+',' like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%') or UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "') and TypeName='" + Request.QueryString["Type"].ToString().Trim() + "' and IFDel='否' and FileName Like '%" + this.TextBox1.Text + "%' order by DirOrFile desc,ID desc");
        }
        else if (Request.QueryString["Type"].ToString().Trim() == "项目文件")
        {
            //设定按钮权限            
            ImageButton6.Visible = LCX.Common.PublicMethod.StrIFIn("|031N|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|031A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|031M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|031D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|031E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            GVData.DataSource = MyModel.GetList("DirID=" + DirID + " and  (( ','+CanView+',' like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%') or UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "') and TypeName='" + Request.QueryString["Type"].ToString().Trim() + "' and IFDel='否' and FileName Like '%" + this.TextBox1.Text + "%' order by DirOrFile desc,ID desc");
        }
        else if (Request.QueryString["Type"].ToString().Trim() == "电子刊物")
        {
            //设定按钮权限            
            ImageButton6.Visible = LCX.Common.PublicMethod.StrIFIn("|032N|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|032A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|032M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|032D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|032E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            GVData.DataSource = MyModel.GetList("DirID=" + DirID + " and  (( ','+CanView+',' like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%') or UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "') and TypeName='" + Request.QueryString["Type"].ToString().Trim() + "' and IFDel='否' and FileName Like '%" + this.TextBox1.Text + "%' order by DirOrFile desc,ID desc");
        }
        else if (Request.QueryString["Type"].ToString().Trim() == "重要文件")
        {
            //设定按钮权限            
            ImageButton6.Visible = LCX.Common.PublicMethod.StrIFIn("|033N|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|033A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|033M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|033D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|033E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            GVData.DataSource = MyModel.GetList("DirID=" + DirID + " and  (( ','+CanView+',' like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%') or UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "') and TypeName='" + Request.QueryString["Type"].ToString().Trim() + "' and IFDel='否' and FileName Like '%" + this.TextBox1.Text + "%' order by DirOrFile desc,ID desc");
        }
        else if (Request.QueryString["Type"].ToString().Trim() == "机密文件")
        {
            //设定按钮权限            
            ImageButton6.Visible = LCX.Common.PublicMethod.StrIFIn("|034N|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|034A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|034M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|034D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|034E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            GVData.DataSource = MyModel.GetList("DirID=" + DirID + " and  (( ','+CanView+',' like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%') or UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "') and TypeName='" + Request.QueryString["Type"].ToString().Trim() + "' and IFDel='否' and FileName Like '%" + this.TextBox1.Text + "%' order by DirOrFile desc,ID desc");
        }
        else if (Request.QueryString["Type"].ToString().Trim() == "知识库")
        {
            //设定按钮权限            
            ImageButton6.Visible = LCX.Common.PublicMethod.StrIFIn("|035N|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|035A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|035M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|035D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|035E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            GVData.DataSource = MyModel.GetList("DirID=" + DirID + " and  (( ','+CanView+',' like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%') or UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "') and TypeName='" + Request.QueryString["Type"].ToString().Trim() + "' and IFDel='否' and FileName Like '%" + this.TextBox1.Text + "%' order by DirOrFile desc,ID desc");
        }
        else if (Request.QueryString["Type"].ToString().Trim() == "技术文件")
        {
            //设定按钮权限
            ImageButton6.Visible = LCX.Common.PublicMethod.StrIFIn("|036N|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|036A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|036M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|036D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|036E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            GVData.DataSource = MyModel.GetList("DirID=" + DirID + " and  (( ','+CanView+',' like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%') or UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "') and TypeName='" + Request.QueryString["Type"].ToString().Trim() + "' and IFDel='否' and FileName Like '%" + this.TextBox1.Text + "%' order by DirOrFile desc,ID desc");
        }
        else if (Request.QueryString["Type"].ToString().Trim() == "共享文件")
        {
            if (DirID == "0")
            {
                GVData.DataSource = MyModel.GetList("IFDel='否' and IfShare='是' and FileName Like '%" + this.TextBox1.Text + "%' order by DirOrFile desc,ID desc");
            }
            else
            {
                GVData.DataSource = MyModel.GetList("DirID=" + DirID + " and IFDel='否' and FileName Like '%" + this.TextBox1.Text + "%' order by DirOrFile desc,ID desc");
            }
            //隐藏添加、修改、删除
            this.ImageButton1.Visible = false;
            this.ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|037E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            this.ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|037D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            this.ImageButton5.Visible = false;
            this.ImageButton6.Visible = false;
        }        
        GVData.DataBind();
        LabPageSum.Text = Convert.ToString(GVData.PageCount);
        LabCurrentPage.Text = Convert.ToString(((int)GVData.PageIndex + 1));
        this.GoPage.Text = LabCurrentPage.Text.ToString();


        //重新根据当前文件夹可添加、可删除、可修改 重新判读按钮显示(非第一级目录)
        if (DirID != "0" && Request.QueryString["Type"].ToString().Trim() != "个人文件" && Request.QueryString["Type"].ToString().Trim() != "共享文件")
        {
            DataSet MYQXDT = LCX.DBUtility.DbHelperSQL.GetDataSet("select * from LCXFileList where ID=" + DirID);
            if (MYQXDT.Tables[0].Rows.Count > 0)
            {
                string CanAddStr = "," + MYQXDT.Tables[0].Rows[0]["CanAdd"].ToString() + "," + MYQXDT.Tables[0].Rows[0]["UserName"].ToString() + ",";
                string CanModStr = "," + MYQXDT.Tables[0].Rows[0]["CanMod"].ToString() + "," + MYQXDT.Tables[0].Rows[0]["UserName"].ToString() + ",";
                string CanDelStr = "," + MYQXDT.Tables[0].Rows[0]["CanDel"].ToString() + "," + MYQXDT.Tables[0].Rows[0]["UserName"].ToString() + ",";

                ImageButton6.Visible = LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", CanAddStr);
                ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", CanAddStr);
                ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", CanModStr);
                ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", CanDelStr);
            }
        }
    }
    #region  分页方法
    protected void ButtonGo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (GoPage.Text.Trim().ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('页码不可以为空!');</script>");
            }
            else if (GoPage.Text.Trim().ToString() == "0" || Convert.ToInt32(GoPage.Text.Trim().ToString()) > GVData.PageCount)
            {
                Response.Write("<script language='javascript'>alert('页码不是一个有效值!');</script>");
            }
            else if (GoPage.Text.Trim() != "")
            {
                int PageI = Int32.Parse(GoPage.Text.Trim()) - 1;
                if (PageI >= 0 && PageI < (GVData.PageCount))
                {
                    GVData.PageIndex = PageI;
                }
            }

            if (TxtPageSize.Text.Trim().ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('每页显示行数不可以为空!');</script>");
            }
            else if (TxtPageSize.Text.Trim().ToString() == "0")
            {
                Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
            }
            else if (TxtPageSize.Text.Trim() != "")
            {
                try
                {
                    int MyPageSize = int.Parse(TxtPageSize.Text.ToString().Trim());
                    this.GVData.PageSize = MyPageSize;
                }
                catch
                {
                    Response.Write("<script language='javascript'>alert('每页显示行数不是一个有效值!');</script>");
                }
            }

            DataBindToGridview();
        }
        catch
        {
            DataBindToGridview();
            Response.Write("<script language='javascript'>alert('请输入有效数字！');</script>");
        }
    }
    protected void PagerButtonClick(object sender, ImageClickEventArgs e)
    {
        //获得Button的参数值
        string arg = ((ImageButton)sender).CommandName.ToString();
        switch (arg)
        {
            case ("Next"):
                if (this.GVData.PageIndex < (GVData.PageCount - 1))
                    GVData.PageIndex++;
                break;
            case ("Pre"):
                if (GVData.PageIndex > 0)
                    GVData.PageIndex--;
                break;
            case ("Last"):
                try
                {
                    GVData.PageIndex = (GVData.PageCount - 1);
                }
                catch
                {
                    GVData.PageIndex = 0;
                }

                break;
            default:
                //本页值
                GVData.PageIndex = 0;
                break;
        }
        DataBindToGridview();
    }
    #endregion
    protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LCX.Common.PublicMethod.GridViewRowDataBound(e);
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label MyLab = (Label)e.Row.FindControl("LabVisible");
            HyperLink MyHyp = (HyperLink)e.Row.FindControl("HyperLink1");
            Image MyImage = (Image)e.Row.FindControl("Image1");
            string ImagePath = "../images/filetype/" + LCX.DBUtility.DbHelperSQL.GetSHSL("select FileType from LCXFileList where ID=" + MyLab.Text.Trim()) + ".gif";
            if (File.Exists(Server.MapPath(ImagePath)) == true)
            {
                MyImage.ImageUrl = ImagePath;
                //共享文件夹
                if (LCX.DBUtility.DbHelperSQL.GetSHSL("select FileType from LCXFileList where ID=" + MyLab.Text.Trim()) == "dir")
                {
                    //设置点击后进入相应文件夹
                    MyHyp.NavigateUrl = "DocCenter.aspx?DirID=" + MyLab.Text.Trim() + "&Type=" + Request.QueryString["Type"].ToString();
                    MyHyp.Text=LCX.DBUtility.DbHelperSQL.GetSHSL("select FileName from LCXFileList where ID=" + MyLab.Text.Trim());
                    if (LCX.DBUtility.DbHelperSQL.GetSHSL("select IfShare from LCXFileList where ID=" + MyLab.Text.Trim()) == "是")
                    {
                        MyImage.ImageUrl = "../images/filetype/sharedir.gif";
                    }
                }
            }
            else
            {
                MyImage.ImageUrl = "../images/filetype/unknown.gif";
            }
        }
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview();
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("DocAdd.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + Request.QueryString["DirID"].ToString());
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        string IDlist = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        if (LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCXFileList set IFDel='是' where ( (UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "') or (','+CanDel+',' like '%," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",%')) and ID in (" + IDlist + ")") == -1)
        {
            Response.Write("<script>alert('删除选中记录时发生错误！请重新登陆后重试！');</script>");
        }
        else
        {
            DataBindToGridview();
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户删除文档信息";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
        }
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string IDList = "0";
        for (int i = 0; i < GVData.Rows.Count; i++)
        {
            Label LabVis = (Label)GVData.Rows[i].FindControl("LabVisible");
            IDList = IDList + "," + LabVis.Text.ToString();
        }
        Hashtable MyTable = new Hashtable();
        MyTable.Add("FileName", "文件名");
        MyTable.Add("BianHao", "文档编号");
        MyTable.Add("DaXiao", "大小(KB)");
        MyTable.Add("ShangChuanTime", "上传时间");
        MyTable.Add("UserName", "上传人");
        MyTable.Add("IfShare", "是否共享");

        LCX.Common.DataToExcel.GridViewToExcel(LCX.DBUtility.DbHelperSQL.GetDataSet("select FileName,BianHao,DaXiao,ShangChuanTime,UserName,IfShare from LCXFileList where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel报表");
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        string CheckStr = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        string[] CheckStrArray = CheckStr.Split(',');

        //判断当前选定的这个文件或者文件夹，是否有权限修改，没有就提示，不做操作
        if (Request.QueryString["Type"].ToString() != "个人文件")
        {
            string CanModStr = ',' + LCX.DBUtility.DbHelperSQL.GetSHSL("select top 1 CanMod from LCXFileList where ID=" + CheckStrArray[0].ToString()) + ",";
            string UserNameStr = LCX.DBUtility.DbHelperSQL.GetSHSL("select top 1 UserName from LCXFileList where ID=" + CheckStrArray[0].ToString());

            if (LCX.Common.PublicMethod.StrIFIn("," + LCX.Common.PublicMethod.GetSessionValue("UserName") + ",", CanModStr) == false && UserNameStr != LCX.Common.PublicMethod.GetSessionValue("UserName"))
            {
                LCX.Common.MessageBox.Show(this, "您没有修改这个文件或者文件夹的权限！");
                return;
            }
        }
        //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        if (LCX.DBUtility.DbHelperSQL.GetSHSL("select FileType from LCXFileList where ID=" + CheckStrArray[0].ToString()) == "dir")
        {
            Response.Redirect("DirModify.aspx?Type=" + Request.QueryString["Type"].ToString() + "&ID=" + CheckStrArray[0].ToString() + "&DirID=" + Request.QueryString["DirID"].ToString());
        }
        else
        {
            Response.Redirect("DocModify.aspx?Type=" + Request.QueryString["Type"].ToString() + "&ID=" + CheckStrArray[0].ToString() + "&DirID=" + Request.QueryString["DirID"].ToString());
        }
    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("DocDirAdd.aspx?Type=" + Request.QueryString["Type"].ToString() + "&DirID=" + Request.QueryString["DirID"].ToString());
    }
}