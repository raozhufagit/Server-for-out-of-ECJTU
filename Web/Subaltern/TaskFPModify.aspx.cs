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

public partial class Subaltern_TaskFPModify : System.Web.UI.Page
{


	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXTaskFP Model = new LCX.BLL.LCXTaskFP();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtTaskTitle.Text=Model.TaskTitle.ToString();
			this.txtTaskContent.Text=Model.TaskContent.ToString();
			this.txtFromUser.Text=Model.FromUser.ToString();
			this.txtToUserList.Text=Model.ToUserList.ToString();
			this.txtXinXiGouTong.Text=Model.XinXiGouTong.ToString();
			this.txtJinDu.Text=Model.JinDu.ToString();
			this.txtWanCheng.Text=Model.WanCheng.ToString();
			this.DropDownList1.SelectedValue=Model.NowState.ToString();
            this.TextBox2.Text = Model.KSSJ.ToString().Split(' ')[0];
            this.DropDownList2.SelectedValue = DateTime.Parse(Model.KSSJ.ToString()).Hour.ToString("D2");
            this.DropDownList3.SelectedValue = DateTime.Parse(Model.KSSJ.ToString()).Minute.ToString("D2");

            this.TextBox3.Text = Model.JSSJ.ToString().Split(' ')[0];
            this.DropDownList4.SelectedValue = DateTime.Parse(Model.JSSJ.ToString()).Hour.ToString("D2");
            this.DropDownList5.SelectedValue = DateTime.Parse(Model.JSSJ.ToString()).Minute.ToString("D2");

            this.TextBox4.Text = Model.FKSJ.ToString().Split(' ')[0];
            this.DropDownList6.SelectedValue = DateTime.Parse(Model.FKSJ.ToString()).Hour.ToString("D2");
            this.DropDownList7.SelectedValue = DateTime.Parse(Model.FKSJ.ToString()).Minute.ToString("D2");
            this.TX.Value = Model.SFFK;
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
	{
		LCX.BLL.LCXTaskFP Model = new LCX.BLL.LCXTaskFP();
		
		Model.ID = int.Parse(Request.QueryString["ID"].ToString());
		Model.TaskTitle=this.txtTaskTitle.Text.ToString();
		Model.TaskContent=this.txtTaskContent.Text.ToString();
		Model.FromUser=this.txtFromUser.Text.ToString();
		Model.ToUserList=this.txtToUserList.Text.ToString();
		Model.XinXiGouTong=this.txtXinXiGouTong.Text.ToString();
		Model.JinDu=decimal.Parse(this.txtJinDu.Text);
		Model.WanCheng=this.txtWanCheng.Text.ToString();
        Model.NowState = this.DropDownList1.SelectedValue.ToString();
        Model.KSSJ = DateTime.Parse(this.TextBox3.Text.Trim() + " " + this.DropDownList2.SelectedItem.Text + ":" + this.DropDownList3.SelectedItem.Text + ":00");
        Model.JSSJ = DateTime.Parse(this.TextBox2.Text.Trim() + " " + this.DropDownList4.SelectedItem.Text + ":" + this.DropDownList5.SelectedItem.Text + ":00");
        Model.FKSJ = DateTime.Parse(this.TextBox4.Text.Trim() + " " + this.DropDownList6.SelectedItem.Text + ":" + this.DropDownList7.SelectedItem.Text + ":00");
        Model.SFFK = this.TX.Value;
		Model.Update();

        //发送短信
        SendMainAndSms.SendMessage(CHKSMS, CHKMOB, "您有新的任务需要执行！(" + this.txtTaskTitle.Text + ")", this.txtToUserList.Text.Trim());

		//写系统日志
		LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
		MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
		MyRiZhi.DoSomething = "用户修改任务分配信息(" + this.txtTaskTitle.Text + ")";
		MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
		MyRiZhi.Add();
		
		LCX.Common.MessageBox.ShowAndRedirect(this, "任务分配信息修改成功！", "TaskFP.aspx");
	}
}
