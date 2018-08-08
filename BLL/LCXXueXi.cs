using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//�����������
namespace LCX.BLL
{
	/// <summary>
	/// ��LCXStudy��
	/// </summary>
	public class LCXStudy
	{
		public LCXStudy()
		{}
		#region Model
		private int _id;
		private string _titlestr;
		private string _backinfo;
		private string _fujianstr;
		private string _username;
		private DateTime? _timestr;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// ���ϱ���
		/// </summary>
		public string TitleStr
		{
			set{ _titlestr=value;}
			get{return _titlestr;}
		}
		/// <summary>
		/// ѧϰ����
		/// </summary>
		public string BackInfo
		{
			set{ _backinfo=value;}
			get{return _backinfo;}
		}
		/// <summary>
		/// �����ļ�
		/// </summary>
		public string FuJianStr
		{
			set{ _fujianstr=value;}
			get{return _fujianstr;}
		}
		/// <summary>
		/// ¼����
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// ¼��ʱ��
		/// </summary>
		public DateTime? TimeStr
		{
			set{ _timestr=value;}
			get{return _timestr;}
		}
		#endregion Model


		#region  ��Ա����

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public LCXStudy(int idstr)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,TitleStr,BackInfo,FuJianStr,UserName,TimeStr ");
			strSql.Append(" FROM LCXStudy ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				TitleStr=ds.Tables[0].Rows[0]["TitleStr"].ToString();
				BackInfo=ds.Tables[0].Rows[0]["BackInfo"].ToString();
				FuJianStr=ds.Tables[0].Rows[0]["FuJianStr"].ToString();
				UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				if(ds.Tables[0].Rows[0]["TimeStr"].ToString()!="")
				{
					TimeStr=DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
				}
			}
		}

		/// <summary>
		/// �õ����ID
		/// </summary>
		public int GetMaxId()
		{

		return DbHelperSQL.GetMaxID("ID", "LCXStudy"); 
		}

		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
        public bool Exists(int idstr)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LCXStudy");
			strSql.Append(" where ID=@ID ");

			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// ����һ������
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LCXStudy(");
			strSql.Append("TitleStr,BackInfo,FuJianStr,UserName,TimeStr)");
			strSql.Append(" values (");
			strSql.Append("@TitleStr,@BackInfo,@FuJianStr,@UserName,@TimeStr)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@TitleStr", SqlDbType.VarChar,200),
					new SqlParameter("@BackInfo", SqlDbType.Text),
					new SqlParameter("@FuJianStr", SqlDbType.VarChar,500),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@TimeStr", SqlDbType.DateTime)};
			parameters[0].Value = TitleStr;
			parameters[1].Value = BackInfo;
			parameters[2].Value = FuJianStr;
			parameters[3].Value = UserName;
			parameters[4].Value = TimeStr;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 1;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LCXStudy set ");
			strSql.Append("TitleStr=@TitleStr,");
			strSql.Append("BackInfo=@BackInfo,");
			strSql.Append("FuJianStr=@FuJianStr,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("TimeStr=@TimeStr");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TitleStr", SqlDbType.VarChar,200),
					new SqlParameter("@BackInfo", SqlDbType.Text),
					new SqlParameter("@FuJianStr", SqlDbType.VarChar,500),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@TimeStr", SqlDbType.DateTime)};
			parameters[0].Value = ID;
			parameters[1].Value = TitleStr;
			parameters[2].Value = BackInfo;
			parameters[3].Value = FuJianStr;
			parameters[4].Value = UserName;
			parameters[5].Value = TimeStr;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
        public void Delete(int idstr)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LCXStudy ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
        public void GetModel(int idstr)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,TitleStr,BackInfo,FuJianStr,UserName,TimeStr ");
			strSql.Append(" FROM LCXStudy ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["ID"].ToString()!="")
				{
					ID=int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
				}
				TitleStr=ds.Tables[0].Rows[0]["TitleStr"].ToString();
				BackInfo=ds.Tables[0].Rows[0]["BackInfo"].ToString();
				FuJianStr=ds.Tables[0].Rows[0]["FuJianStr"].ToString();
				UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				if(ds.Tables[0].Rows[0]["TimeStr"].ToString()!="")
				{
					TimeStr=DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
				}
			}
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM LCXStudy ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  ��Ա����
	}
}

