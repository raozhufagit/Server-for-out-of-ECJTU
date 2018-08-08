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

public partial class NWorkFlow_NWorkFlowNodeView : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCX_WorkFlowNode Model = new LCX.BLL.LCX_WorkFlowNode();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			
			this.lblNodeSerils.Text=Model.NodeSerils.ToString();
			this.lblNodeName.Text=Model.NodeName.ToString();
			this.lblNodeAddr.Text=Model.NodeAddr.ToString();
			this.lblNextNode.Text=Model.NextNode.ToString();
			this.lblIFCanJump.Text=Model.IFCanJump.ToString();
			this.lblIFCanView.Text=Model.IFCanView.ToString();
			this.lblIFCanEdit.Text=Model.IFCanEdit.ToString();
			this.lblIFCanDel.Text=Model.IFCanDel.ToString();
			this.lblJieShuHours.Text=Model.JieShuHours.ToString();
			this.lblPSType.Text=Model.PSType.ToString();
			this.lblSPType.Text=Model.SPType.ToString();
			this.lblSPDefaultList.Text=Model.SPDefaultList.ToString();
			this.lblCanWriteSet.Text=Model.CanWriteSet.ToString();
			this.lblSecretSet.Text=Model.SecretSet.ToString();
			this.lblConditionSet.Text=Model.ConditionSet.ToString();
			
			//写系统日志
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户查看节点定义信息(" + this.lblNodeName.Text + ")";
			MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
			MyRiZhi.Add();
			
		}
	}
}
