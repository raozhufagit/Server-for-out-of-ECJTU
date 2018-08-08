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
using LCX.DBUtility;

public partial class Supply_BuyOrderAdd : System.Web.UI.Page
{


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LCX.Common.PublicMethod.CheckSession();
            //�����ϴ��ĸ���Ϊ��
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", "");
            string str = Request.QueryString["name"];
            LCX.BLL.LCXBuyOrder Model = new LCX.BLL.LCXBuyOrder();
            txtSerils.Text = Model.GetSerils();
            this.txtOrderName.Text = str;
            this.txtGongYingShangName.Attributes.Add("readonly", "true");
            string sql = "insert into LCXBuyChanPin(OrderName,ProductName,Danjia,ShuLiang,ZongJia,YiFuKuan,QianKuanShu,IFJiaoFu) select HeTongName,ChanPinName,DanJia,ShuLiang,ZongJia,YiFuKuan,QianKuanShu,IFJiaoFu from LCXCProduct where HeTongName='" + str + "'";
            DbHelperSQL.ExecuteSql(sql.ToString());
        }
    }
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        LCX.BLL.LCXBuyOrder Model = new LCX.BLL.LCXBuyOrder();
        LCX.BLL.LCXContract Model1 = new LCX.BLL.LCXContract();
        if (LCX.Common.PublicMethod.IFExists("OrderName", "LCXBuyOrder", 0, this.txtOrderName.Text) == true)
        {
            Model.OrderName = this.txtOrderName.Text.ToString();
            Model.GongYingShangName = this.txtGongYingShangName.Text.ToString();
            Model.Serils = this.txtSerils.Text.ToString();
            Model.DingDanLeiXing = this.txtDingDanLeiXing.Text.ToString();
            Model.DingDanMiaoShu = this.txtDingDanMiaoShu.Text.ToString();
            Model.CreateDate = DateTime.Parse(this.txtCreateDate.Text);
            Model.LaiHuoDate = DateTime.Parse(this.txtLaiHuoDate.Text);
            Model.TiXingDate = DateTime.Parse(this.txtTiXingDate.Text);
            Model.ChuangJianRen = this.txtChuangJianRen.Text.ToString();
            Model.FuZeRen = this.txtFuZeRen.Text.ToString();
            Model.FuJianList = LCX.Common.PublicMethod.GetSessionValue("WenJianList");
            Model.NowState = "�ȴ����";
            Model.ShenPiTongGuoRen = "";
            Model.BackInfo = this.txtBackInfo.Text.ToString();
            Model.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            Model.TimeStr = DateTime.Now;

            Model.Add();
            DataSet ds = Model1.GetList("HeTongName='" + this.txtOrderName.Text + "'");
            if (ds.Tables[0].Rows.Count > 0)
            {
                string sql = "update  LCXContract set NowState='���ڲɹ�' where ID=" + ds.Tables[0].Rows[0]["ID"].ToString() + "";
                DbHelperSQL.ExecuteSql(sql.ToString());
            }

            //дϵͳ��־
            LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
            MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
            MyRiZhi.DoSomething = "�û���Ӳɹ�������Ϣ(" + this.txtOrderName.Text + ")";
            MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
            MyRiZhi.Add();

            LCX.Common.MessageBox.ShowAndRedirect(this, "�ɹ�������Ϣ��ӳɹ���", "BuyDengJi.aspx");
        }
        else
        {
            LCX.Common.MessageBox.Show(this, "�ö��������Ѿ����ڣ�����������������ƣ�");
        }

    }
    protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
    {
        string FileNameStr = LCX.Common.PublicMethod.UploadFileIntoDir(this.FileUpload1, DateTime.Now.Ticks.ToString() + System.IO.Path.GetExtension(FileUpload1.PostedFile.FileName));
        if (LCX.Common.PublicMethod.GetSessionValue("WenJianList").Trim() == "")
        {
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", FileNameStr);
        }
        else
        {
            LCX.Common.PublicMethod.SetSessionValue("WenJianList", LCX.Common.PublicMethod.GetSessionValue("WenJianList") + "|" + FileNameStr);
        }
        LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
    }
    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            for (int i = 0; i < this.CheckBoxList1.Items.Count; i++)
            {
                if (this.CheckBoxList1.Items[i].Selected == true)
                {
                    LCX.Common.PublicMethod.SetSessionValue("WenJianList", LCX.Common.PublicMethod.GetSessionValue("WenJianList").Replace(this.CheckBoxList1.Items[i].Text, "").Replace("||", "|"));
                }
            }
            LCX.Common.PublicMethod.BindDDL(this.CheckBoxList1, LCX.Common.PublicMethod.GetSessionValue("WenJianList"));
        }
        catch
        { }
    }

    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CheckBoxList1.SelectedItem.Text.Trim().Length > 0)
            {
                Response.Write("<script>window.open('../DsoFramer/ReadFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Text + "');</script>");
            }
        }
        catch
        { }
    }
    protected void ImageButton5_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            if (this.CheckBoxList1.SelectedItem.Text.Trim().Length > 0)
            {
                Response.Write("<script>window.open('../DsoFramer/EditFile.aspx?FilePath=" + this.CheckBoxList1.SelectedItem.Text + "');</script>");
            }
        }
        catch
        { }
    }
}
