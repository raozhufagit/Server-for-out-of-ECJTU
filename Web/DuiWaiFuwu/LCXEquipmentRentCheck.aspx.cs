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

public partial class DuiWaiFuwu_LCXEquipmentRentCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXEquipmentRent Model = new LCX.BLL.LCXEquipmentRent();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblEquipmentName.Text = Model.EquipmentName.ToString();
            this.lblEquipmentNo.Text = Model.EquipmentNo.ToString();
            this.lblBorrowType.Text = Model.BorrowType.ToString();
            this.lblBorrowDept.Text = Model.BorrowDept.ToString();
            this.lblStartTime.Text = Model.StartTime.ToString();
            this.lblEndTime.Text = Model.EndTime.ToString();
            this.lblBorrowPerson.Text = Model.BorrowPerson.ToString();
            this.lblWhetherContinue.Text = Model.WhetherContinue.ToString();
            this.lblRemarks.Text = Model.Remarks.ToString();
        }
    }


    protected void subReturn(object sender, EventArgs e)
    {
        
        Response.Redirect("LCXEquipmentRent.aspx?EquipmentNo="+ this.lblEquipmentNo.Text.ToString());
    }

    protected void subPass(object sender, EventArgs e)
    {
        LCX.BLL.LCXEquipmentRent Model = new LCX.BLL.LCXEquipmentRent();
        string CheckUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
        if (Model.States == 0 || String.Compare(Model.States.ToString(), " ") == 0)
        {

        }
        else
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的设备租借不需再审核！", "LCXScientificResearch.aspx");
            return;
        }
        Model.ID = int.Parse(Request.QueryString["ID"].ToString());
        Model.States = 1; 
        //LCX.Common.MessageBox.Show(this, this.lblEquipmentNo.Text.ToString());
        
        //model.ID = int.Parse(Request.QueryString["ID"].ToString());
        LCX.BLL.LCXEquipment model = new LCX.BLL.LCXEquipment();
        string UID = LCX.DBUtility.DbHelperSQL.GetSHSLInt(" SELECT * FROM LCXEquipment where EquipmentNo='" + this.lblEquipmentNo.Text.ToString()+"'");
        model.GetModel(int.Parse(UID));
        model.ID = int.Parse(UID);
        //LCX.Common.MessageBox.Show(this,UID);
        model.EquipStates = "3";
        
        if (Model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "借出失败！");
            return;
        }
        else
        {
            model.Update();
        }

        //发送通知
        //SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "审批了生产订单【" + model.Jd_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.txtGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = CheckUser + "借出设备信息(" + model.EquipmentName + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "设备借出成功！", "LCXEquipmentRent.aspx?EquipmentNo=" + this.lblEquipmentNo.Text.ToString());
    }
}