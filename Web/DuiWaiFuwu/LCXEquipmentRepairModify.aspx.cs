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

public partial class DuiWaiFuwu_LCXEquipmentRepairModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXEquipmentRepair Model = new LCX.BLL.LCXEquipmentRepair();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtEquipmentName.Text = Model.EquipmentName.ToString();
            this.txtEquipmentNo.Text = Model.EquipmentNo.ToString();
            this.txtRepairDept.Text = Model.RepairDept.ToString();
            this.txtRepairCost.Text = Model.RepairCost.ToString();
            this.txtRepairTime.Text = Model.RepairTime.ToString();
            this.txtChecker.Text = Model.Checker.ToString();
            this.txtRemarks.Text = Model.Remarks.ToString();

        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXEquipmentRepair Model = new LCX.BLL.LCXEquipmentRepair();

        Model.EquipmentName = this.txtEquipmentName.Text.ToString();
        Model.EquipmentNo = this.txtEquipmentNo.Text.ToString();
        Model.RepairDept = this.txtRepairDept.Text.ToString();
        Model.RepairCost = this.txtRepairCost.Text.ToString();
        if (this.txtRepairTime.Text != "")
        {
            Model.RepairTime = DateTime.Parse(this.txtRepairTime.Text);
        }

        Model.Checker = this.txtChecker.Text.ToString();
        Model.Remarks = this.txtRemarks.Text.ToString();
        Model.SubPerson = LCX.Common.PublicMethod.GetSessionValue("UserName");


        Model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改设备维修信息(" + this.txtEquipmentName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "设备维修信息修改成功！", "LCXEquipmentRepair.aspx?EquipmentNo=" + this.txtEquipmentNo.Text.ToString());
    }
}