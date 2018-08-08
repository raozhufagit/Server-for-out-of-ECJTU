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

public partial class DuiWaiFuwu_LCXEquipmentModify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXEquipment Model = new LCX.BLL.LCXEquipment();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.txtEquipmentName.Text = Model.EquipmentName.ToString();
            this.txtEquipmentNo.Text = Model.EquipmentNo.ToString();
            this.txtFactoryNo.Text = Model.FactoryNo.ToString();
            this.txtFactoryName.Text = Model.FactoryName.ToString();
            this.txtEquipmentType.Text = Model.EquipmentType.ToString();
            this.txtEquipmentModel.Text = Model.EquipmentModel.ToString();
            this.txtBelongDept.Text = Model.BelongDept.ToString();
            this.txtBuyTime.Text = Model.BuyTime.ToString();
            this.txtBuyPrice.Text = Model.BuyPrice.ToString();
            this.txtManager.Text = Model.Manager.ToString();
            this.txtStoragePosition.Text = Model.StoragePosition.ToString();
            this.txtMattersAttention.Text = Model.MattersAttention.ToString();
            this.txtChecker.Text = Model.Checker.ToString();
            this.txtCheckTime.Text = Model.CheckTime.ToString();
            //Model.CheckStates = this.txtCheckStates.Text.ToString();
            this.txtEquipStates.Text = Model.EquipStates.ToString();
            this.txtRemarks.Text = Model.Remarks.ToString();
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXEquipment Model = new LCX.BLL.LCXEquipment();

        Model.EquipmentName = this.txtEquipmentName.Text.ToString();
        Model.EquipmentNo = this.txtEquipmentNo.Text.ToString();
        Model.FactoryNo = this.txtFactoryNo.Text.ToString();
        Model.FactoryName = this.txtFactoryName.Text.ToString();
        Model.EquipmentType = this.txtEquipmentType.Text.ToString();
        Model.EquipmentModel = this.txtEquipmentModel.Text.ToString();
        Model.BelongDept = this.txtBelongDept.Text.ToString();
        Model.BuyTime = DateTime.Parse(this.txtBuyTime.Text.ToString());
        Model.BuyPrice = this.txtBuyPrice.Text.ToString();
        Model.Manager = this.txtManager.Text.ToString();
        Model.StoragePosition = this.txtStoragePosition.Text.ToString();
        Model.MattersAttention = this.txtMattersAttention.Text.ToString();
        Model.Checker = this.txtChecker.Text.ToString();
        Model.CheckTime = DateTime.Parse(this.txtCheckTime.Text.ToString());
        //Model.CheckStates = this.txtCheckStates.Text.ToString();
        Model.EquipStates = this.txtEquipStates.Text.ToString();
        Model.Remarks = this.txtRemarks.Text.ToString();
        

        Model.Update();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改仪器设备信息(" + this.txtEquipmentName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "仪器设备信息修改成功！", "LCXEquipment.aspx");
    }
}