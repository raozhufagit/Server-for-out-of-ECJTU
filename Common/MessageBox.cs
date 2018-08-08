using System;
using System.Text;
namespace LCX.Common
{
	/// <summary>
	/// ��ʾ��Ϣ��ʾ�Ի���
    /// lcx
    /// 2008.4
	/// </summary>
	public class MessageBox
	{		
		private  MessageBox()
		{			
		}

		/// <summary>
		/// ��ʾ��Ϣ��ʾ�Ի���
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		public static void  Show(System.Web.UI.Page page,string msg)
		{            
            page.ClientScript.RegisterStartupScript(page.GetType(),"message", "<script language='javascript' defer>alert('" + msg.ToString() + "');</script>");
		}

        public static void  Close(System.Web.UI.Page page)
		{            
            page.ClientScript.RegisterStartupScript(page.GetType(),"message", "<script language='javascript'>window.opener=null;window.open('','_self');window.close();</script>");
		}
        

		/// <summary>
		/// �ؼ���� ��Ϣȷ����ʾ��
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		public static void  ShowConfirm(System.Web.UI.WebControls.WebControl Control,string msg)
		{
			//Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
			Control.Attributes.Add("onclick", "return confirm('" + msg + "');") ;
		}

		/// <summary>
		/// ��ʾ��Ϣ��ʾ�Ի��򣬲�����ҳ����ת
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="msg">��ʾ��Ϣ</param>
		/// <param name="url">��ת��Ŀ��URL</param>
		public static void ShowAndRedirect(System.Web.UI.Page page,string msg,string url)
		{
			StringBuilder Builder=new StringBuilder();
			Builder.Append("<script language='javascript' defer>");
			Builder.AppendFormat("alert('{0}');",msg);
			Builder.AppendFormat("window.location.href='{0}'",url);
			Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

		}
        /// <summary>
        /// ������Ϣ��������һҳ
        /// </summary>
        /// <param name="page"></param>
        /// <param name="msg"></param>
        public static void ShowAndBack(System.Web.UI.Page page,string msg)
		{
			StringBuilder Builder=new StringBuilder();
			Builder.Append("<script language='javascript'>");
			Builder.AppendFormat("alert('{0}');",msg);
            Builder.Append("history.go(-1);");
			Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());

		}
        
		/// <summary>
		/// ����Զ���ű���Ϣ
		/// </summary>
		/// <param name="page">��ǰҳ��ָ�룬һ��Ϊthis</param>
		/// <param name="script">����ű�</param>
		public static void ResponseScript(System.Web.UI.Page page,string script)
		{
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");
             
		}

	}
}
