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

public partial class NWorkFlow_DoWork : System.Web.UI.Page
{
    public string PiLiangSet = "";//批量设置字段的可写、保密属性
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCX_WorkToDo MyModel = new LCX.BLL.LCX_WorkToDo();
            MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.Label1.Text = MyModel.WorkName;
            this.Label2.Text = MyModel.JieDianName;
            this.TextBox3.Text = MyModel.FormContent;

            LCX.Common.PublicMethod.SetSessionValue("WenJianList", MyModel.FuJianList);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));

            this.Label5.Text = MyModel.ShenPiYiJian;
            this.HyperLink1.NavigateUrl = "NWorkFlowReView.aspx?WorkFlowID=" + MyModel.WorkFlowID.ToString();

            //绑定常用审批
            LCX.DBUtility.DbHelperSQL.BindDropDownList2("select ContentStr from LCXShenPi where UserName='" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "'", this.DropDownList1, "ContentStr", "ContentStr");

            SetNodeInfoAndSet();
        }

        //刷新界面后，将label1赋值
        this.Label3.Text = this.TextBox3.Text;
    }

    /// <summary>
    /// 设置具体属性、当前判断权限、可写、保密等
    /// </summary>
    public void SetNodeInfoAndSet()
    {
        //当前开始节点是否有查看、编辑、删除按钮？当前按钮属性
        string NowNodeID = LCX.DBUtility.DbHelperSQL.GetSHSLInt("select JieDianID from LCX_WorkToDo where ID=" + Request.QueryString["ID"].ToString());
        LCX.BLL.LCX_WorkFlowNode MyJieDianNow = new LCX.BLL.LCX_WorkFlowNode();
        MyJieDianNow.GetModel(int.Parse(NowNodeID));
        if (MyJieDianNow.IFCanDel == "否")
        {
            this.ImageButton3.Visible = false;
        }
        if (MyJieDianNow.IFCanView == "否")
        {
            this.ImageButton4.Visible = false;
        }
        if (MyJieDianNow.IFCanEdit == "否")
        {
            this.ImageButton5.Visible = false;
        }
        if (MyJieDianNow.IFCanJump == "否")
        {
            this.Button3.Visible = false;
        }

        LCX.BLL.LCX_WorkToDo MyModelWork = new LCX.BLL.LCX_WorkToDo();
        MyModelWork.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        //获取当前表单对应的工作数据列
        string[] FormItemList = LCX.DBUtility.DbHelperSQL.GetSHSL("select top 1 ItemsList from LCX_Form where ID=" + MyModelWork.FormID.ToString()).Split('|');
        //获取当前节点的可写权限、保密权限
        string CanWriteStr = MyJieDianNow.CanWriteSet;
        string SecretStr = MyJieDianNow.SecretSet;

        for (int ItemNum = 0; ItemNum < FormItemList.Length; ItemNum++)
        {
            if (FormItemList[ItemNum].ToString().Trim().Length > 0)
            {
                if (LCX.Common.PublicMethod.StrIFIn(FormItemList[ItemNum].ToString(), CanWriteStr) == false)//不属于可写字段
                {
                    PiLiangSet = PiLiangSet + "document.getElementById(\"" + FormItemList[ItemNum].ToString().Split('_')[0] + "\").disabled=true;";//readOnly
                }
                else
                {
                    PiLiangSet = PiLiangSet + "document.getElementById(\"" + FormItemList[ItemNum].ToString().Split('_')[0] + "\").disabled=false;";//readOnly
                }
                if (LCX.Common.PublicMethod.StrIFIn(FormItemList[ItemNum].ToString(), SecretStr) == true)//属于保密字段
                {
                    PiLiangSet = PiLiangSet + "document.getElementById(\"" + FormItemList[ItemNum].ToString().Split('_')[0] + "\").style.visibility=\"hidden\";";
                }
                else
                {
                    PiLiangSet = PiLiangSet + "document.getElementById(\"" + FormItemList[ItemNum].ToString().Split('_')[0] + "\").style.visibility=\"visible\";";
                }
            }
        }
    }
    //保存通过
    protected void Button1_Click(object sender, EventArgs e)
    {
        //找到下一节点
        string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
        if (FileNameStr.Trim().Length > 0)
        {
            string PiShiStr = "<font color=#0000FF>" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "&nbsp;&nbsp;" + DateTime.Now.ToString() + "&nbsp;&nbsp;</font><BR>" + this.TextBox1.Text.ToString() + "<br>审批附件：<a href=../UploadFile/" + FileNameStr + ">[右键下载]</a><hr>" + this.Label5.Text;
            LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCX_WorkToDo set FuJianList='" + LCX.Common.PublicMethod.GetSessionValue("WenJianList") + "',OKUserList=OKUserList+'," + LCX.Common.PublicMethod.GetSessionValue("UserName") + "',ShenPiYiJian='" + PiShiStr + "' where ID=" + Request.QueryString["ID"].ToString());

            LCX.BLL.LCX_WorkToDo Mymodel = new LCX.BLL.LCX_WorkToDo();
            Mymodel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            Mymodel.ID = int.Parse(Request.QueryString["ID"].ToString());
            Mymodel.FormContent = this.TextBox3.Text;
            Mymodel.UpdateBD();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户审批工作信息(" + this.Label1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();
            Response.Redirect("GoToNextNode.aspx?DoType="+Request.QueryString["DoType"].ToString()+"&Type=0&ID=" + Request.QueryString["ID"].ToString());
        }
        else if (FileUpload1.PostedFile.FileName.Trim().Length <= 0)
        {
            string PiShiStr = "<font color=#0000FF>" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "&nbsp;&nbsp;" + DateTime.Now.ToString() + "&nbsp;&nbsp;</font><BR>" + this.TextBox1.Text.ToString() + "<hr>" + this.Label5.Text;
            LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCX_WorkToDo set FuJianList='" + LCX.Common.PublicMethod.GetSessionValue("WenJianList") + "',OKUserList=OKUserList+'," + LCX.Common.PublicMethod.GetSessionValue("UserName") + "',ShenPiYiJian='" + PiShiStr + "' where ID=" + Request.QueryString["ID"].ToString());

            LCX.BLL.LCX_WorkToDo Mymodel = new LCX.BLL.LCX_WorkToDo();
            Mymodel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            Mymodel.ID = int.Parse(Request.QueryString["ID"].ToString());
            Mymodel.FormContent = this.TextBox3.Text;
            Mymodel.UpdateBD();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户审批工作信息(" + this.Label1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            Response.Redirect("GoToNextNode.aspx?DoType=" + Request.QueryString["DoType"].ToString() + "&Type=0&ID=" + Request.QueryString["ID"].ToString());
        }
    }
    //保存拨回到原发文人
    protected void Button2_Click(object sender, EventArgs e)
    {
        string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
        if (FileNameStr.Trim().Length > 0)
        {
            string PiShiStr = "<font color=#0000FF>" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "&nbsp;&nbsp;" + DateTime.Now.ToString() + "&nbsp;&nbsp;</font><BR>" + this.TextBox1.Text.ToString() + "<br>审批附件：<a href=../UploadFile/" + FileNameStr + ">[右键下载]</a><hr>" + this.Label5.Text;
            LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCX_WorkToDo set FuJianList='" + LCX.Common.PublicMethod.GetSessionValue("WenJianList") + "',ShenPiYiJian='" + PiShiStr + "',StateNow='已被驳回' where ID=" + Request.QueryString["ID"].ToString());

            LCX.BLL.LCX_WorkToDo Mymodel = new LCX.BLL.LCX_WorkToDo();
            Mymodel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            Mymodel.ID = int.Parse(Request.QueryString["ID"].ToString());
            Mymodel.FormContent = this.TextBox3.Text;

            //发邮件通知发文拟稿人
            LCX.BLL.LCXLanEmail MyMail = new LCX.BLL.LCXLanEmail();
            MyMail.EmailContent = "您的工作已经被驳回！(" + this.Label1.Text + ")";
            MyMail.EmailState = "未读";
            MyMail.EmailTitle = "您的工作已经被驳回！(" + this.Label1.Text + ")"; ;
            MyMail.FromUser = "系统消息";
            MyMail.FuJian = "";
            MyMail.TimeStr = DateTime.Now;
            MyMail.ToUser = Mymodel.UserName;
            MyMail.Add();


            Mymodel.UpdateBD();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户审批工作信息(" + this.Label1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            LCX.Common.MessageBox.ShowAndRedirect(this, "审批操作完成！", "NowWorkFlow.aspx");
        }
        else if (FileUpload1.PostedFile.FileName.Trim().Length <= 0)
        {
            string PiShiStr = "<font color=#0000FF>" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "&nbsp;&nbsp;" + DateTime.Now.ToString() + "&nbsp;&nbsp;</font><BR>" + this.TextBox1.Text.ToString() + "<hr>" + this.Label5.Text;
            LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCX_WorkToDo set FuJianList='" + LCX.Common.PublicMethod.GetSessionValue("WenJianList") + "',ShenPiYiJian='" + PiShiStr + "',StateNow='已被驳回' where ID=" + Request.QueryString["ID"].ToString());

            LCX.BLL.LCX_WorkToDo Mymodel = new LCX.BLL.LCX_WorkToDo();
            Mymodel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            Mymodel.ID = int.Parse(Request.QueryString["ID"].ToString());
            Mymodel.FormContent = this.TextBox3.Text;

            //发邮件通知发文拟稿人
            LCX.BLL.LCXLanEmail MyMail = new LCX.BLL.LCXLanEmail();
            MyMail.EmailContent = "您的工作已经被驳回！(" + this.Label1.Text + ")";
            MyMail.EmailState = "未读";
            MyMail.EmailTitle = "您的工作已经被驳回！(" + this.Label1.Text + ")"; ;
            MyMail.FromUser = "系统消息";
            MyMail.FuJian = "";
            MyMail.TimeStr = DateTime.Now;
            MyMail.ToUser = Mymodel.UserName;
            MyMail.Add();


            Mymodel.UpdateBD();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户审批工作信息(" + this.Label1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            LCX.Common.MessageBox.ShowAndRedirect(this, "审批操作完成！", "NowWorkFlow.aspx");
        }
    }
    //保存并驳回到其他节点
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)
            {
                if (this.CheckBoxList1.Items[i].Selected == true)
                {
                    LCX.Common.PublicMethod.SetSessionValue("WenJianList", LCX.Common.PublicMethod.GetSessionValue("WenJianList").Replace(this.CheckBoxList1.Items[i].Value, "").Replace("||", "|"));
                }
            }
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
        catch
        { }
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CheckBoxList1.SelectedItem.Text.Trim().Length > 0)
            {
                Response.Write("<script>window.open('../DsoFramer/ReadFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Value + "');</script>");
            }
        }
        catch
        { }
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CheckBoxList1.SelectedItem.Text.Trim().Length > 0)
            {
                Response.Write("<script>window.open('../DsoFramer/EditFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Value + "');</script>");
            }
        }
        catch
        { }
    }
    protected void Button3_Click(object sender, EventArgs e)
    {

        //找到下一节点
        string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
        if (FileNameStr.Trim().Length > 0)
        {
            string PiShiStr = "<font color=#0000FF>" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "&nbsp;&nbsp;" + DateTime.Now.ToString() + "&nbsp;&nbsp;</font><BR>" + this.TextBox1.Text.ToString() + "<br>审批附件：<a href=../UploadFile/" + FileNameStr + ">[右键下载]</a><hr>" + this.Label5.Text;
            LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCX_WorkToDo set FuJianList='" + LCX.Common.PublicMethod.GetSessionValue("WenJianList") + "',OKUserList=OKUserList+'," + LCX.Common.PublicMethod.GetSessionValue("UserName") + "',ShenPiYiJian='" + PiShiStr + "' where ID=" + Request.QueryString["ID"].ToString());

            LCX.BLL.LCX_WorkToDo Mymodel = new LCX.BLL.LCX_WorkToDo();
            Mymodel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            Mymodel.ID = int.Parse(Request.QueryString["ID"].ToString());
            Mymodel.FormContent = this.TextBox3.Text;
            Mymodel.UpdateBD();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户审批工作信息(" + this.Label1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            Response.Redirect("GoToNextNode.aspx?DoType=" + Request.QueryString["DoType"].ToString() + "&Type=1&ID=" + Request.QueryString["ID"].ToString());
        }
        else if (FileUpload1.PostedFile.FileName.Trim().Length <= 0)
        {
            string PiShiStr = "<font color=#0000FF>" + LCX.Common.PublicMethod.GetSessionValue("UserName") + "&nbsp;&nbsp;" + DateTime.Now.ToString() + "&nbsp;&nbsp;</font><BR>" + this.TextBox1.Text.ToString() + "<hr>" + this.Label5.Text;
            LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCX_WorkToDo set FuJianList='" + LCX.Common.PublicMethod.GetSessionValue("WenJianList") + "',OKUserList=OKUserList+'," + LCX.Common.PublicMethod.GetSessionValue("UserName") + "',ShenPiYiJian='" + PiShiStr + "' where ID=" + Request.QueryString["ID"].ToString());

            LCX.BLL.LCX_WorkToDo Mymodel = new LCX.BLL.LCX_WorkToDo();
            Mymodel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            Mymodel.ID = int.Parse(Request.QueryString["ID"].ToString());
            Mymodel.FormContent = this.TextBox3.Text;
            Mymodel.UpdateBD();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户审批工作信息(" + this.Label1.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            Response.Redirect("GoToNextNode.aspx?DoType=" + Request.QueryString["DoType"].ToString() + "&Type=1&ID=" + Request.QueryString["ID"].ToString());
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PrintWork.aspx?ID=" + Request.QueryString["ID"].ToString());
    }
}
