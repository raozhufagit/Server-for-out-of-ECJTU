using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace Show_Socut_Data
{
	/// <summary>
	/// _default ��ժҪ˵����
	/// </summary>
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            // �ڴ˴������û������Գ�ʼ��ҳ��
            if (Session["UserName"] == null)
            {
                //����û�δ��½
                T2.Visible = false;//���ر���
            }
            else//�����½
            {
                T1.Visible = false;//���ر��һ
                Label1.Text = Session["UserName"].ToString();//��ʾ�û���
            }
        }

        protected void Button1_Click(object sender, System.EventArgs e)
        {
        }
    }
}
