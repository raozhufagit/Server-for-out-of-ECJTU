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

public partial class SystemManage_TreeListModify : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!Page.IsPostBack)
		{
			LCX.Common.PublicMethod.CheckSession();
			LCX.BLL.LCXTreeList Model = new LCX.BLL.LCXTreeList();
			Model.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
			this.txtTextStr.Text=Model.TextStr.ToString();
			this.txtImageUrlStr.Text=Model.ImageUrlStr.ToString();
			this.txtValueStr.Text=Model.ValueStr.ToString();
			this.txtNavigateUrlStr.Text=Model.NavigateUrlStr.ToString();
			this.txtTarget.Text=Model.Target.ToString();
			this.txtParentID.Text=Model.ParentID.ToString();
			this.txtQuanXianList.Text=Model.QuanXianList.ToString();
			this.txtPaiXuStr.Text=Model.PaiXuStr.ToString();
            this.SelClass.SelectedValue = Model.ParentClass;
		}
	}
	protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        if (LCX.Common.PublicMethod.IFExists("ValueStr", "LCXTreeList", int.Parse(Request.QueryString["ID"].ToString()), this.txtValueStr.Text) == true)
        {
            LCX.BLL.LCXTreeList Model = new LCX.BLL.LCXTreeList();

            Model.ID = int.Parse(Request.QueryString["ID"].ToString());
            Model.TextStr = this.txtTextStr.Text.ToString();
            Model.ImageUrlStr = this.txtImageUrlStr.Text.ToString();
            Model.ValueStr = this.txtValueStr.Text.ToString();
            Model.NavigateUrlStr = this.txtNavigateUrlStr.Text.ToString();
            Model.Target = this.txtTarget.Text.ToString();
            Model.ParentID = int.Parse(this.txtParentID.Text);
            Model.QuanXianList = this.txtQuanXianList.Text.ToString();
            Model.PaiXuStr = int.Parse(this.txtPaiXuStr.Text);
            Model.ParentClass = this.SelClass.SelectedItem.Value;
            Model.Update();

            //写系统日志
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "用户修改菜单管理信息(" + this.txtTextStr.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            LCX.Common.MessageBox.ShowAndRedirect(this, "菜单管理信息修改成功！", "TreeList.aspx");
        }
        else
        {
            LCX.Common.MessageBox.Show(this, "当前指定的后台数值已经存在，为了保持唯一性，请重新指定！");
        }
	}
}
