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

public partial class NWorkFlow_NWorkToDoView : System.Web.UI.Page
{
    public string PiLiangSet = "";//批量设置字段的可写、保密属性
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCX_WorkToDo Model = new LCX.BLL.LCX_WorkToDo();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.lblWorkName.Text=Model.WorkName.ToString();
            //this.lblFormID.Text=Model.FormID.ToString();
            //this.lblWorkFlowID.Text=Model.WorkFlowID.ToString();
			this.lblUserName.Text=Model.UserName.ToString();
			this.lblTimeStr.Text=Model.TimeStr.ToString();
			this.lblFormContent.Text=Model.FormContent.ToString();
			this.lblFuJianList.Text=LCX.Common.PublicMethod.GetWenJian(Model.FuJianList.ToString(),"../UpLoadFile/");
			this.lblShenPiYiJian.Text=Model.ShenPiYiJian.ToString();
			//this.lblJieDianID.Text=Model.JieDianID.ToString();
            this.lblJieDianName.Text = "<a href=\"NWorkFlowReView.aspx?WorkFlowID=" + Model.WorkFlowID.ToString() + "&FormID=" + Model.FormID.ToString() + "\" target=\"_blank\">" + Model.JieDianName.ToString() + "</a>";
			this.lblShenPiUserList.Text=Model.ShenPiUserList.ToString();
			this.lblOKUserList.Text=Model.OKUserList.ToString();
			this.lblStateNow.Text=Model.StateNow.ToString();
			this.lblLateTime.Text=Model.LateTime.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "用户查看工作管理信息(" + this.lblWorkName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();

            SetNodeInfoAndSet();
		}
	}

    /// <summary>
    /// 设置具体属性、当前判断权限、可写、保密等
    /// </summary>
    public void SetNodeInfoAndSet()
    {       
        LCX.BLL.LCX_WorkToDo MyModelWork = new LCX.BLL.LCX_WorkToDo();
        MyModelWork.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        //获取当前表单对应的工作数据列
        string[] FormItemList = LCX.DBUtility.DbHelperSQL.GetSHSL("select top 1 ItemsList from LCX_Form where ID=" + MyModelWork.FormID.ToString()).Split('|');        

        for (int ItemNum = 0; ItemNum < FormItemList.Length; ItemNum++)
        {
            if (FormItemList[ItemNum].ToString().Trim().Length > 0)
            {
                
                PiLiangSet = PiLiangSet + "document.getElementById(\"" + FormItemList[ItemNum].ToString().Split('_')[0] + "\").disabled=true;";//readOnly
            }
        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("PrintWork.aspx?ID=" + Request.QueryString["ID"].ToString());
    }
}
