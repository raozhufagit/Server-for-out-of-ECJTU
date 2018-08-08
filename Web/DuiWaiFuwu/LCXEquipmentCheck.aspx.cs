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

public partial class DuiWaiFuwu_LCXEquipmentCheck : System.Web.UI.Page
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


        }
    }
    protected void subPass(object sender, EventArgs e)
    {
        LCX.BLL.LCXEquipment model = new LCX.BLL.LCXEquipment();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
        //LCX.Common.MessageBox.Show(this, model.ZhuangTai.ToString());
        if (model.CheckStates== "1" || model.CheckStates == "2")
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的设备不需再审核！", "LCXEquipment.aspx");
            return;
        }


        string CheckUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.ID = int.Parse(Request.QueryString["ID"].ToString());
        //model.CheckAdvision = this.lblCheckAdvision.Text;
        //model.EquipStates = this.lblZhengGai.Text.ToString();
        model.CheckStates = "1";
        //model.Update();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }

        //发送通知
        //SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "审批了生产订单【" + model.Jd_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.lblGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = CheckUser + "审批了设备信息(" + model.EquipmentName + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "设备信息审批成功！", "LCXEquipment.aspx");
    }
    protected void subRefuse(object sender, EventArgs e)
    {
        LCX.BLL.LCXEquipment model = new LCX.BLL.LCXEquipment();
        model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        if (model.CheckStates == "1"|| model.CheckStates == "2" )
        {
            LCX.Common.MessageBox.ShowAndRedirect(this, "审核过后的设备信息不需再审核！", "LCXEquipment.aspx");
            return;
        }

        string CheckUser = LCX.Common.PublicMethod.GetSessionValue("UserName");
        model.ID = int.Parse(Request.QueryString["ID"].ToString());
        //model.CheckAdvision = this.lblCheckAdvision.Text;
        //model.CheckTime = DateTime.Now;
        //model.ZhengGai = this.lblZhengGai.Text.ToString();
        model.CheckStates = "2";
        // model.Update();
        if (model.Update() < 1)
        {
            LCX.Common.MessageBox.Show(this, "审批失败！");
            return;
        }

        //发送通知
        //SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, LCX.Common.PublicMethod.GetSessionValue("TrueName") + "拒绝了生产订单【" + model.Jd_Name + "】", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.lblGongGao.Text.Trim()));

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = CheckUser + "拒绝了设备审核信息(" + model.EquipmentName + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "设备审核拒绝成功！", "LCXEquipment.aspx");
    }
}