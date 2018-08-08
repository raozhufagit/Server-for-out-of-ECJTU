using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
    /// <summary>
    /// 类LCXQuestionKaoShi。
    /// </summary>
    public class LCXQuestionKaoShi
    {
        public LCXQuestionKaoShi()
        { }
        #region Model
        private int _id;
        private string _username;
        private DateTime? _timestr;
        private int? _shijuanid;
        private string _shijuanname;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 提交时间
        /// </summary>
        public DateTime? TimeStr
        {
            set { _timestr = value; }
            get { return _timestr; }
        }
        /// <summary>
        /// 所用试卷ID
        /// </summary>
        public int? ShiJuanID
        {
            set { _shijuanid = value; }
            get { return _shijuanid; }
        }
        /// <summary>
        /// 试卷名称
        /// </summary>
        public string ShiJuanName
        {
            set { _shijuanname = value; }
            get { return _shijuanname; }
        }
        #endregion Model


        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXQuestionKaoShi(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserName,TimeStr,ShiJuanID,ShiJuanName ");
            strSql.Append(" FROM LCXQuestionKaoShi ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["TimeStr"].ToString() != "")
                {
                    TimeStr = DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShiJuanID"].ToString() != "")
                {
                    ShiJuanID = int.Parse(ds.Tables[0].Rows[0]["ShiJuanID"].ToString());
                }
                ShiJuanName = ds.Tables[0].Rows[0]["ShiJuanName"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXQuestionKaoShi");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LCXQuestionKaoShi(");
            strSql.Append("UserName,TimeStr,ShiJuanID,ShiJuanName)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@TimeStr,@ShiJuanID,@ShiJuanName)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@TimeStr", SqlDbType.DateTime),
					new SqlParameter("@ShiJuanID", SqlDbType.Int,4),
					new SqlParameter("@ShiJuanName", SqlDbType.VarChar,500)};
            parameters[0].Value = UserName;
            parameters[1].Value = TimeStr;
            parameters[2].Value = ShiJuanID;
            parameters[3].Value = ShiJuanName;

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
            strSql.Append("update LCXQuestionKaoShi set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("TimeStr=@TimeStr,");
            strSql.Append("ShiJuanID=@ShiJuanID,");
            strSql.Append("ShiJuanName=@ShiJuanName");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@TimeStr", SqlDbType.DateTime),
					new SqlParameter("@ShiJuanID", SqlDbType.Int,4),
					new SqlParameter("@ShiJuanName", SqlDbType.VarChar,500)};
            parameters[0].Value = ID;
            parameters[1].Value = UserName;
            parameters[2].Value = TimeStr;
            parameters[3].Value = ShiJuanID;
            parameters[4].Value = ShiJuanName;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXQuestionKaoShi ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public void GetModel(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 ID,UserName,TimeStr,ShiJuanID,ShiJuanName ");
            strSql.Append(" FROM LCXQuestionKaoShi ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["TimeStr"].ToString() != "")
                {
                    TimeStr = DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ShiJuanID"].ToString() != "")
                {
                    ShiJuanID = int.Parse(ds.Tables[0].Rows[0]["ShiJuanID"].ToString());
                }
                ShiJuanName = ds.Tables[0].Rows[0]["ShiJuanName"].ToString();
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LCXQuestionKaoShi ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}

