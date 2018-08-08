
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

public partial class NWorkFlow_NWorkFlow : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            DataBindToGridview("");

            //�趨��ťȨ��            
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|023A|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton5.Visible = LCX.Common.PublicMethod.StrIFIn("|023M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton3.Visible = LCX.Common.PublicMethod.StrIFIn("|023D|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
            ImageButton2.Visible = LCX.Common.PublicMethod.StrIFIn("|023E|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));

            if (Request.QueryString["FormID"].ToString().Trim() == "0")
            {
                ImageButton1.Visible = false;
                ImageButton2.Visible = false;
                ImageButton3.Visible = false;
                ImageButton5.Visible = false;
            }

            this.Label1.Text ="["+ LCX.DBUtility.DbHelperSQL.GetSHSL("select FormName from LCX_Form where ID=" + Request.QueryString["FormID"].ToString().Trim())+"]";
        }
    }
    #region  ��ҳ����
    protected void ButtonGo_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (GoPage.Text.Trim().ToString() == "")
            {
                Response.Write("<script language='javascript'>alert('ҳ�벻����Ϊ��!');</script>");
            }
            else if (GoPage.Text.Trim().ToString() == "0" || Convert.ToInt32(GoPage.Text.Trim().ToString()) > GVData.PageCount)
            {
                Response.Write("<script language='javascript'>alert('ҳ�벻��һ����Чֵ!');</script>");
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
                Response.Write("<script language='javascript'>alert('ÿҳ��ʾ����������Ϊ��!');</script>");
            }
            else if (TxtPageSize.Text.Trim().ToString() == "0")
            {
                Response.Write("<script language='javascript'>alert('ÿҳ��ʾ��������һ����Чֵ!');</script>");
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
                    Response.Write("<script language='javascript'>alert('ÿҳ��ʾ��������һ����Чֵ!');</script>");
                }
            }

            DataBindToGridview("");
        }
        catch
        {
            DataBindToGridview("");
            Response.Write("<script language='javascript'>alert('��������Ч���֣�');</script>");
        }
    }
    protected void PagerButtonClick(object sender, ImageClickEventArgs e)
    {
        //���Button�Ĳ���ֵ
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
                //��ҳֵ
                GVData.PageIndex = 0;
                break;
        }
        DataBindToGridview("");
    }
    #endregion
    protected void GVData_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        LCX.Common.PublicMethod.GridViewRowDataBound(e);

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Label LabID = (Label)e.Row.FindControl("LabVisible");
            HyperLink MyHyp = (HyperLink)e.Row.FindControl("HyperLink10");
            
            string NumStr=LCX.DBUtility.DbHelperSQL.GetSHSLInt("select count(*) from LCX_WorkToDo where StateNow='���ڰ���'  and WorkFlowID="+LabID.Text.Trim());
            if (NumStr!="0")
            {
                MyHyp.Text = "��"+NumStr+"���������ڰ������ɶ���ڵ㣡";
                MyHyp.NavigateUrl = "javascript:void(0);";
            }
        }

        //�ж��Ƿ���Ȩ��
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            HyperLink MyHyp = (HyperLink)e.Row.FindControl("HyperLink10");
            MyHyp.Visible = LCX.Common.PublicMethod.StrIFIn("|023N|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }

    }
    protected void ImageButton6_Click(object sender, ImageClickEventArgs e)
    {
        //������һ�β�ѯ���
        string JJ = "0";
        for (int i = 0; i < this.GVData.Rows.Count; i++)
        {
            Label LabV = (Label)GVData.Rows[i].FindControl("LabVisible");
            JJ = JJ + "," + LabV.Text.Trim();
        }
        DataBindToGridview(JJ);
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        DataBindToGridview("");
    }
	public void DataBindToGridview(string IDList)
	{
		LCX.BLL.LCX_WorkFlow MyModel = new LCX.BLL.LCX_WorkFlow();
		if (IDList.Trim().Length > 0)
		{
            GVData.DataSource = MyModel.GetList(" " + DropDownList2.SelectedItem.Value.ToString() + " like '%" + this.TextBox3.Text.Trim() + "%' and FormID=" + Request.QueryString["FormID"].ToString() + " and ID in(" + IDList + ") order by PaiXuStr asc,ID desc");
		}
		else
		{
            GVData.DataSource = MyModel.GetList(" " + DropDownList2.SelectedItem.Value.ToString() + " like '%" + this.TextBox3.Text.Trim() + "%' and FormID=" + Request.QueryString["FormID"].ToString() + " order by PaiXuStr asc,ID desc");
		}
		GVData.DataBind();
		LabPageSum.Text = Convert.ToString(GVData.PageCount);
		LabCurrentPage.Text = Convert.ToString(((int)GVData.PageIndex + 1));
		this.GoPage.Text = LabCurrentPage.Text.ToString();
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
        Response.Redirect("NWorkFlowAdd.aspx?FormID=" + Request.QueryString["FormID"].ToString());
	}
	protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
	{
		string IDlist = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
		if (LCX.DBUtility.DbHelperSQL.ExecuteSQL("delete from LCX_WorkFlow where ID in (" + IDlist + ")") == -1)
		{
			Response.Write("<script>alert('ɾ��ѡ�м�¼ʱ�������������µ�½�����ԣ�');</script>");
		}
		else
		{
			DataBindToGridview("");
			//дϵͳ��־
			LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
			MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
			MyRiZhi.DoSomething = "�û�ɾ�����̶�����Ϣ";
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
		MyTable.Add("WorkFlowName", "��������");
		MyTable.Add("FormID", "���ñ�");
		MyTable.Add("UserListOK", "����ʹ����");
		MyTable.Add("DepListOK", "����ʹ�ò���");
		MyTable.Add("JiaoSeListOK", "����ʹ�ý�ɫ");
		MyTable.Add("PaiXuStr", "�����ַ�");
		MyTable.Add("UserName", "¼����");
		MyTable.Add("TimeStr", "¼��ʱ��");
		MyTable.Add("BackInfo", "��Ҫ˵��");
		MyTable.Add("IFOK", "�Ƿ�����");
		LCX.Common.DataToExcel.GridViewToExcel(LCX.DBUtility.DbHelperSQL.GetDataSet("select  WorkFlowName,FormID,UserListOK,DepListOK,JiaoSeListOK,PaiXuStr,UserName,TimeStr,BackInfo,IFOK  from LCX_WorkFlow where ID in (" + IDList + ") order by ID desc"), MyTable, "Excel����");
	}
	protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
	{
		string CheckStr = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
		string[] CheckStrArray = CheckStr.Split(',');
		Response.Redirect("NWorkFlowModify.aspx?FormID=" + Request.QueryString["FormID"].ToString()+"&ID=" + CheckStrArray[0].ToString());
	}
    protected void ImageButton7_Click(object sender, ImageClickEventArgs e)
    {
        string CheckStr = LCX.Common.PublicMethod.CheckCbx(this.GVData, "CheckSelect", "LabVisible");
        string[] CheckStrArray = CheckStr.Split(',');

        string CopyStr = "insert into LCX_WorkFlow([WorkFlowName], [FormID], [UserListOK], [DepListOK], [JiaoSeListOK], [PaiXuStr], [UserName], [TimeStr], [BackInfo], [IFOK]) (select [WorkFlowName]+'-����', [FormID], [UserListOK], [DepListOK], [JiaoSeListOK], [PaiXuStr], [UserName], [TimeStr], [BackInfo], [IFOK] from LCX_WorkFlow where ID=" + CheckStrArray[0].ToString() + ")";
        LCX.DBUtility.DbHelperSQL.ExecuteSQL(CopyStr);

        string MaxIDStr = LCX.DBUtility.DbHelperSQL.GetSHSLInt("select top 1 ID from LCX_WorkFlow order by ID desc");
        //���ƽڵ�
        string CopyNodeStr = "insert into LCX_WorkFlowNode([WorkFlowID], [NodeSerils], [NodeName], [NodeAddr], [NextNode], [IFCanJump], [IFCanView], [IFCanEdit], [IFCanDel], [JieShuHours], [PSType], [SPType], [SPDefaultList], [CanWriteSet], [SecretSet], [ConditionSet], [NodeLeft], [NodeTop])(select " + MaxIDStr + ", [NodeSerils], [NodeName], [NodeAddr], [NextNode], [IFCanJump], [IFCanView], [IFCanEdit], [IFCanDel], [JieShuHours], [PSType], [SPType], [SPDefaultList], [CanWriteSet], [SecretSet], [ConditionSet], [NodeLeft], [NodeTop] from LCX_WorkFlowNode where WorkFLowID=" + CheckStrArray[0].ToString() + ")";
        LCX.DBUtility.DbHelperSQL.ExecuteSQL(CopyNodeStr);

        LCX.Common.MessageBox.Show(this, "�����������ݸ�����ɣ�");
        DataBindToGridview("");
    }
}
