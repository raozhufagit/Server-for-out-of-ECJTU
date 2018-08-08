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

public partial class DuiWaiFuwu_LCXEquipmentView : System.Web.UI.Page
{
    public string EquipmentNoStr = "";
    protected void Page_Load(object sender, EventArgs e)
     {
          if (!Page.IsPostBack)
          {
            LCX.Common.PublicMethod.CheckSession();
            LCX.BLL.LCXEquipment Model = new LCX.BLL.LCXEquipment();
            Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.lblEquipmentName.Text = Model.EquipmentName.ToString();
            this.lblEquipmentNo.Text = Model.EquipmentNo.ToString();
            EquipmentNoStr = Model.EquipmentNo;
            this.lblFactoryNo.Text = Model.FactoryNo.ToString();
            this.lblFactoryName.Text = Model.FactoryName.ToString();
            this.lblEquipmentType.Text = Model.EquipmentType.ToString();
            this.lblEquipmentModel.Text = Model.EquipmentModel.ToString();
            this.lblBelongDept.Text = Model.BelongDept.ToString();
            this.lblBuyTime.Text = Model.BuyTime.ToString();
            this.lblBuyPrice.Text = Model.BuyPrice.ToString();
            this.lblManager.Text = Model.Manager.ToString();
            this.lblStoragePosition.Text = Model.StoragePosition.ToString();
            this.lblMattersAttention.Text = Model.MattersAttention.ToString();
            this.lblChecker.Text = Model.Checker.ToString();
            this.lblCheckTime.Text = Model.CheckTime.ToString();
            //Model.CheckStates = this.lblCheckStates.Text.ToString();
            this.lblEquipStates.Text = Model.EquipStates.ToString();
            this.lblRemarks.Text = Model.Remarks.ToString();
            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
                MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
                MyRiZhi.DoSomething = "用户查看仪器设备信息(" + this.lblEquipmentName.Text + ")";
                MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
                MyRiZhi.Add();

          }
     }
}