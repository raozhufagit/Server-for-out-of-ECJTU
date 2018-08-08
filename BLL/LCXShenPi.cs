using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
    /// <summary>
    /// 类LCXShenPi。
    /// </summary>
    public class LCXShenPi
    {
        public LCXShenPi()
        { }
        #region Model
        private int _id;
        private string _contentstr;
        private DateTime? _timestr;
        private string _username;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ContentStr
        {
            set { _contentstr = value; }
            get { return _contentstr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? TimeStr
        {
            set { _timestr = value; }
            get { return _timestr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        #endregion Model


        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXShenPi");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)				};
            parameters[0].Value = idstr;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LCXShenPi(");
            strSql.Append("ContentStr,TimeStr,UserName)");
            strSql.Append(" values (");
            strSql.Append("@ContentStr,@TimeStr,@UserName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ContentStr", SqlDbType.VarChar,5000),
					new SqlParameter("@TimeStr", SqlDbType.DateTime),
					new SqlParameter("@UserName", SqlDbType.VarChar,50)};
            parameters[0].Value = ContentStr;
            parameters[1].Value = TimeStr;
            parameters[2].Value = UserName;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LCXShenPi set ");
            strSql.Append("ContentStr=@ContentStr,");
            strSql.Append("TimeStr=@TimeStr,");
            strSql.Append("UserName=@UserName");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ContentStr", SqlDbType.VarChar,5000),
					new SqlParameter("@TimeStr", SqlDbType.DateTime),
					new SqlParameter("@UserName", SqlDbType.VarChar,50)};
            parameters[0].Value = ID;
            parameters[1].Value = ContentStr;
            parameters[2].Value = TimeStr;
            parameters[3].Value = UserName;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LCXShenPi ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)				};
            parameters[0].Value = idstr;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public void GetModel(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ContentStr,TimeStr,UserName ");
            strSql.Append(" FROM LCXShenPi ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)				};
            parameters[0].Value = idstr;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                ContentStr = ds.Tables[0].Rows[0]["ContentStr"].ToString();
                if (ds.Tables[0].Rows[0]["TimeStr"].ToString() != "")
                {
                    TimeStr = DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
                }
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID],[ContentStr],[TimeStr],[UserName] ");
            strSql.Append(" FROM LCXShenPi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}

