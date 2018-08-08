using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
    /// <summary>
    /// 类LCXTalkSetting。
    /// </summary>
    public class LCXTalkSetting
    {
        public LCXTalkSetting()
        { }
        #region Model
        private int _id;
        private string _talkname;
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
        public string TalkName
        {
            set { _talkname = value; }
            get { return _talkname; }
        }
        #endregion Model


        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXTalkSetting");
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
            strSql.Append("insert into LCXTalkSetting(");
            strSql.Append("TalkName)");
            strSql.Append(" values (");
            strSql.Append("@TalkName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TalkName", SqlDbType.VarChar,5000)};
            parameters[0].Value = TalkName;

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
            strSql.Append("update LCXTalkSetting set ");
            strSql.Append("TalkName=@TalkName");            
            SqlParameter[] parameters = {					
					new SqlParameter("@TalkName", SqlDbType.VarChar,5000)};            
            parameters[0].Value = TalkName;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LCXTalkSetting ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)				};
            parameters[0].Value = idstr;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public void GetModel()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select TalkName ");
            strSql.Append(" FROM LCXTalkSetting ");            
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = ID;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {                
                TalkName = ds.Tables[0].Rows[0]["TalkName"].ToString();
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID],[TalkName] ");
            strSql.Append(" FROM LCXTalkSetting ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}