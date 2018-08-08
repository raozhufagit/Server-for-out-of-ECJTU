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

public partial class DuiWaiFuwu_LCXEquipmentRentView : System.Web.UI.Page
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
            this.lblRestitutionReg.Text = Model.RestitutionReg.ToString();
        }
    }
    
}