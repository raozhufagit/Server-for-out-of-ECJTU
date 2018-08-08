﻿using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class CooperationAgreement_LCXContractModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXContractManage Model = new LCX.BLL.LCXContractManage();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtContractNo.Text = Model.ContractNo.ToString();
            this.txtContractName.Text = Model.ContractName.ToString();
            this.txtContractType.Text = Model.ContractType.ToString();
            this.txtDepartmentA.Text = Model.DepartmentA.ToString();
            this.txtDepartmentB.Text = Model.DepartmentB.ToString();
            this.txtSignatoryA.Text = Model.SignatoryA.ToString();
            this.txtSignatoryB.Text = Model.SignatoryB.ToString();
            this.txtSignTime.Text = Model.SignTime.ToString();
            this.txtEndTime.Text = Model.EndTime.ToString();
            this.txtWhetherSecrecy.Text = Model.WhetherSecrecy.ToString();
            this.txtContractContent.Text = Model.ContractContent.ToString();
            this.txtProject.Text = Model.Project.ToString();
            this.txtAgreement.Text = Model.Agreement.ToString();
            this.txtStates.Text = Model.States.ToString();
            this.txtOutVisiting.Text=Model.OutVisiting;
            //this.txtStrategiCooperation.Text = Model.StrategiCooperation.ToString();
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", Model.Attchment);
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXContractManage Model = new LCX.BLL.LCXContractManage();

        Model.ID = int.Parse(Request.QueryString["ID"].ToString());
        Model.ContractNo = this.txtContractNo.Text.ToString();
        Model.ContractName = this.txtContractName.Text.ToString();
        Model.ContractType = this.txtContractType.Text.ToString();
        Model.DepartmentA = this.txtDepartmentA.Text.ToString();
        Model.DepartmentB = this.txtDepartmentB.Text.ToString();
        Model.SignatoryA = this.txtSignatoryA.Text.ToString();
        Model.SignatoryB = this.txtSignatoryB.Text.ToString(); 
        Model.SignTime = DateTime.Parse(this.txtSignTime.Text);       
        Model.EndTime = DateTime.Parse(this.txtEndTime.Text);
        Model.WhetherSecrecy = this.txtWhetherSecrecy.Text.ToString();
        Model.ContractContent = this.txtContractContent.Text.ToString();
        Model.Project = this.txtProject.Text.ToString();
        Model.Agreement = this.txtAgreement.Text.ToString();
        Model.Remarks = this.txtRemarks.Text.ToString();
        Model.States = this.txtStates.Text.ToString();
        Model.Attchment = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
        Model.OutVisiting = this.txtOutVisiting.Text.ToString();
        //Model.StrategiCooperation = this.txtStrategiCooperation.Text.ToString();
        Model.Update();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改合同信息(" + this.txtContractName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        if (String.Compare(this.txtStates.Text.ToString(), "1") == 0)
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "合同信息修改成功！", "LCXContractManage.aspx");
        }
        else
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "合同信息修改成功！", "LCXContractManageN.aspx");
        }
        // LCX.Common.MessageBox.ShowAndRedirect(this, "合作协议信息修改成功！", "LCXVisitingManagement.aspx");
    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
        if (LCX.Common.PublicMethod.GetSessionValue("WenJianList").Trim() == "")
        {
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", FileNameStr);
        }
        else
        {
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", LCX.Common.PublicMethod.GetSessionValue("WenJianList") + "|" + FileNameStr);
        }
        LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
    }
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
}