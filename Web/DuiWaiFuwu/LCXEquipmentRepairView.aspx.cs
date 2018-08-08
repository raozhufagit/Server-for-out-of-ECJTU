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

public partial class DuiWaiFuwu_LCXEquipmentRepairView : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXEquipmentRepair Model = new LCX.BLL.LCXEquipmentRepair();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblEquipmentName.Text = Model.EquipmentName.ToString();
            this.lblEquipmentNo.Text = Model.EquipmentNo.ToString();
            this.lblRepairDept.Text = Model.RepairDept.ToString();
            this.lblRepairCost.Text = Model.RepairCost.ToString();
            this.lblRepairTime.Text = Model.RepairTime.ToString();
            this.lblChecker.Text = Model.Checker.ToString();
            this.lblRemarks.Text = Model.Remarks.ToString();
            this.lblSubPerson.Text = Model.SubPerson.ToString();
        }
    }
}