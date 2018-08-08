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

public partial class HR_KaoQinSetting : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();

            LCX.BLL.LCXAttendanceSetting MyModel = new LCX.BLL.LCXAttendanceSetting();
            MyModel.GetModel(int.Parse(LCX.DBUtility.DbHelperSQL.GetSHSLInt("select top 1 [ID] FROM LCXAttendanceSetting")));

            string GuiDingTime1 = MyModel.GuiDingTime1;
            this.DropDownList1.SelectedValue = GuiDingTime1.Split(':')[0];
            this.DropDownList2.SelectedValue = GuiDingTime1.Split(':')[1];
            string GuiDingTime2 = MyModel.GuiDingTime2;
            this.DropDownList3.SelectedValue = GuiDingTime2.Split(':')[0];
            this.DropDownList4.SelectedValue = GuiDingTime2.Split(':')[1];
            string GuiDingTime3 = MyModel.GuiDingTime3;
            this.DropDownList5.SelectedValue = GuiDingTime3.Split(':')[0];
            this.DropDownList6.SelectedValue = GuiDingTime3.Split(':')[1];
            string GuiDingTime4 = MyModel.GuiDingTime4;
            this.DropDownList7.SelectedValue = GuiDingTime4.Split(':')[0];
            this.DropDownList8.SelectedValue = GuiDingTime4.Split(':')[1];
            string GuiDingTime5 = MyModel.GuiDingTime5;
            this.DropDownList9.SelectedValue = GuiDingTime5.Split(':')[0];
            this.DropDownList10.SelectedValue = GuiDingTime5.Split(':')[1];
            string GuiDingTime6 = MyModel.GuiDingTime6;
            this.DropDownList11.SelectedValue = GuiDingTime6.Split(':')[0];
            this.DropDownList12.SelectedValue = GuiDingTime6.Split(':')[1];

            //设定按钮权限            
            ImageButton1.Visible = LCX.Common.PublicMethod.StrIFIn("|106M|", LCX.Common.PublicMethod.GetSessionValue("QuanXian"));
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXAttendanceSetting Model = new LCX.BLL.LCXAttendanceSetting();
        Model.ID = int.Parse(LCX.DBUtility.DbHelperSQL.GetSHSLInt("select top 1 [ID] FROM LCXAttendanceSetting"));
        Model.GuiDingTime1 = this.DropDownList1.SelectedItem.Text + ":" + this.DropDownList2.SelectedItem.Text + ":00";
        Model.GuiDingTime2 = this.DropDownList3.SelectedItem.Text + ":" + this.DropDownList4.SelectedItem.Text + ":00";
        Model.GuiDingTime3 = this.DropDownList5.SelectedItem.Text + ":" + this.DropDownList6.SelectedItem.Text + ":00";
        Model.GuiDingTime4 = this.DropDownList7.SelectedItem.Text + ":" + this.DropDownList8.SelectedItem.Text + ":00";
        Model.GuiDingTime5 = this.DropDownList9.SelectedItem.Text + ":" + this.DropDownList10.SelectedItem.Text + ":00";
        Model.GuiDingTime6 = this.DropDownList11.SelectedItem.Text + ":" + this.DropDownList12.SelectedItem.Text + ":00";
        Model.Update();

        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户修改考勤时间设置";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();
        LCX.Common.MessageBox.ShowAndRedirect(this, "考勤时间设置成功！", "KaoQinSetting.aspx");
    }
}
