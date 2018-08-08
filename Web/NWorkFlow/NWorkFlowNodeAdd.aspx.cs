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

public partial class NWorkFlow_NWorkFlowNodeAdd : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			//�����ϴ��ĸ���Ϊ��
			 LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");

             string ExsistID = LCX.DBUtility.DbHelperSQL.GetSHSL("select ID from LCX_WorkFlowNode where WorkFlowID=" + Request.QueryString["WorkFlowID"].ToString() + " and NodeAddr='��ʼ'");
             if (ExsistID.Trim().Length > 0)
             {
                 this.DropDownList1.Items.Remove(new ListItem("��ʼ"));
             }

             string ExsistID1 = LCX.DBUtility.DbHelperSQL.GetSHSL("select ID from LCX_WorkFlowNode where WorkFlowID=" + Request.QueryString["WorkFlowID"].ToString() + " and NodeAddr='����'");
             if (ExsistID1.Trim().Length > 0)
             {
                 this.DropDownList1.Items.Remove(new ListItem("����"));
             }
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
        //�жϿ�ʼ�����������ڵ��Ψһ�ԣ��м�ڵ����ָ����һ�ڵ�
        if (this.DropDownList1.SelectedItem.Text == "��ʼ")
        {
            string ExsistID = LCX.DBUtility.DbHelperSQL.GetSHSL("select ID from LCX_WorkFlowNode where WorkFlowID=" + Request.QueryString["WorkFlowID"].ToString() + " and NodeAddr='��ʼ'");
            if (ExsistID.Trim().Length > 0)
            {
                LCX.Common.MessageBox.Show(this, "�������Ѿ����ڡ���ʼ���ڵ㣬�벻Ҫ�ظ����ӣ�");
                return;
            }
        }
        if (this.DropDownList1.SelectedItem.Text == "����")
        {
            string ExsistID = LCX.DBUtility.DbHelperSQL.GetSHSL("select ID from LCX_WorkFlowNode where WorkFlowID=" + Request.QueryString["WorkFlowID"].ToString() + " and NodeAddr='����'");
            if (ExsistID.Trim().Length > 0)
            {
                LCX.Common.MessageBox.Show(this, "�������Ѿ����ڡ��������ڵ㣬�벻Ҫ�ظ����ӣ�");
                return;
            }
        }

        if (this.DropDownList1.SelectedItem.Text == "�м��" || this.DropDownList1.SelectedItem.Text == "��ʼ")
        {
            string ExsistID = this.txtNextNode.Text.Trim();
            if (ExsistID.Trim().Length <= 0)
            {
                LCX.Common.MessageBox.Show(this, "�м�κͿ�ʼ�ڵ����ָ����һ�ڵ���ţ�");
                return;
            }
        }
        //�жϽڵ���ŵ�Ψһ��
        string NodeSerils = LCX.DBUtility.DbHelperSQL.GetSHSL("select ID from LCX_WorkFlowNode where WorkFlowID=" + Request.QueryString["WorkFlowID"].ToString() + " and NodeSerils='" + this.txtNodeSerils.Text.Trim() + "'");
        if (NodeSerils.Trim().Length > 0)
        {
            LCX.Common.MessageBox.Show(this, "�ýڵ�����Ѿ����ڣ��벻Ҫ�ظ����ӣ�");
            return;
        }

		LCX.BLL.LCX_WorkFlowNode Model = new LCX.BLL.LCX_WorkFlowNode();

        Model.WorkFlowID = int.Parse(Request.QueryString["WorkFlowID"].ToString());
		Model.NodeSerils=this.txtNodeSerils.Text.ToString().Trim();
        Model.NodeName = this.txtNodeName.Text.ToString().Trim();
		Model.NodeAddr=this.DropDownList1.SelectedItem.Text.ToString();
        Model.NextNode = this.txtNextNode.Text.ToString().Trim();
        Model.IFCanJump = this.DropDownList2.SelectedItem.Text.ToString();
        Model.IFCanView = this.DropDownList3.SelectedItem.Text.ToString();
        Model.IFCanEdit = this.DropDownList4.SelectedItem.Text.ToString();
        Model.IFCanDel = this.DropDownList5.SelectedItem.Text.ToString();
        Model.JieShuHours = int.Parse(this.txtJieShuHours.Text.Trim());
        Model.PSType = this.DropDownList6.SelectedItem.Text.ToString();
        Model.SPType = this.DropDownList7.SelectedItem.Text.ToString();
        Model.SPDefaultList = this.txtSPDefaultList.Text.ToString().Trim();
		Model.CanWriteSet="";
		Model.SecretSet="";
		Model.ConditionSet="";
		
		Model.Add();
		
		//дϵͳ��־
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "�û����ӽڵ㶨����Ϣ(" + this.txtNodeName.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "�ڵ㶨����Ϣ���ӳɹ���", "NWorkFlowNode.aspx?WorkFlowID=" + Request.QueryString["WorkFlowID"].ToString());
	}
}