using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
	/// <summary>
	/// 类LCXPay。
	/// </summary>
	public class LCXPay
	{
		public LCXPay()
		{}
		#region Model
		private int _id;
		private string _xcname;
		private string _jianjie;
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
		/// 薪酬管理名称
		/// </summary>
		public string XCName
		{
			set{ _xcname=value;}
			get{return _xcname;}
		}
		/// <summary>
		/// 简要说明
		/// </summary>
		public string JianJie
		{
			set{ _jianjie=value;}
			get{return _jianjie;}
		}
		/// <summary>
		/// 录入人
		/// </summary>
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
		}
		/// <summary>
		/// 录入时间
		/// </summary>
		public DateTime? TimeStr
		{
			set{ _timestr=value;}
			get{return _timestr;}
		}
		#endregion Model


		#region  成员方法

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public LCXPay(int idstr)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ID,XCName,JianJie,UserName,TimeStr ");
			strSql.Append(" FROM LCXPay ");
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
				XCName=ds.Tables[0].Rows[0]["XCName"].ToString();
				JianJie=ds.Tables[0].Rows[0]["JianJie"].ToString();
				UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				if(ds.Tables[0].Rows[0]["TimeStr"].ToString()!="")
				{
					TimeStr=DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
				}
			}
		}

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{

		return DbHelperSQL.GetMaxID("ID", "LCXPay"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
        public bool Exists(int idstr)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from LCXPay");
			strSql.Append(" where ID=@ID ");

			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into LCXPay(");
			strSql.Append("XCName,JianJie,UserName,TimeStr)");
			strSql.Append(" values (");
			strSql.Append("@XCName,@JianJie,@UserName,@TimeStr)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@XCName", SqlDbType.VarChar,50),
					new SqlParameter("@JianJie", SqlDbType.VarChar,500),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@TimeStr", SqlDbType.DateTime)};
			parameters[0].Value = XCName;
			parameters[1].Value = JianJie;
			parameters[2].Value = UserName;
			parameters[3].Value = TimeStr;

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
		/// 更新一条数据
		/// </summary>
		public void Update()
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update LCXPay set ");
			strSql.Append("XCName=@XCName,");
			strSql.Append("JianJie=@JianJie,");
			strSql.Append("UserName=@UserName,");
			strSql.Append("TimeStr=@TimeStr");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@XCName", SqlDbType.VarChar,50),
					new SqlParameter("@JianJie", SqlDbType.VarChar,500),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@TimeStr", SqlDbType.DateTime)};
			parameters[0].Value = ID;
			parameters[1].Value = XCName;
			parameters[2].Value = JianJie;
			parameters[3].Value = UserName;
			parameters[4].Value = TimeStr;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
        public void Delete(int idstr)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from LCXPay ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

			DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
        public void GetModel(int idstr)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 ID,XCName,JianJie,UserName,TimeStr ");
			strSql.Append(" FROM LCXPay ");
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
				XCName=ds.Tables[0].Rows[0]["XCName"].ToString();
				JianJie=ds.Tables[0].Rows[0]["JianJie"].ToString();
				UserName=ds.Tables[0].Rows[0]["UserName"].ToString();
				if(ds.Tables[0].Rows[0]["TimeStr"].ToString()!="")
				{
					TimeStr=DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
				}
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM LCXPay ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		#endregion  成员方法
	}
}

