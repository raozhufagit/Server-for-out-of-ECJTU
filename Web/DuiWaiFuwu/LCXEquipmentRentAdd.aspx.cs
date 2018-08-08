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

public partial class DuiWaiFuwu_LCXEquipmentRentAdd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //设置上传的附件为空
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXEquipmentRent Model = new LCX.BLL.LCXEquipmentRent();

        Model.EquipmentName = this.txtEquipmentName.Text.ToString();
        Model.EquipmentNo = this.txtEquipmentNo.Text.ToString();
        Model.BorrowType = this.txtBorrowType.Text.ToString();
        Model.BorrowDept = this.txtBorrowDept.Text.ToString();
        if (this.txtStartTime.Text != "")
        {
            Model.StartTime = DateTime.Parse(this.txtStartTime.Text);
        }
        if (this.txtEndTime.Text != "")
        {
            Model.EndTime = DateTime.Parse(this.txtEndTime.Text);
        }
        if (this.txtReturnTime.Text != "")
        {
            Model.ReturnTime = DateTime.Parse(this.txtReturnTime.Text);
        }
        Model.BorrowPerson = this.txtBorrowPerson.Text.ToString();
        Model.WhetherContinue = this.txtWhetherContinue.Text.ToString();
        Model.Remarks = this.txtRemarks.Text.ToString();
        Model.SubPerson = LCX.Common.PublicMethod.GetSessionValue("UserName");
        Model.SubTime = DateTime.Now;
        Model.Remarks = this.txtRemarks.Text.ToString();
        
        Model.Add();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户添加设备租借信息(" + this.txtEquipmentName.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "设备租借信息添加成功！", "LCXEquipmentRent.aspx?EquipmentNo="+ this.txtEquipmentNo.Text.ToString());
    }
}