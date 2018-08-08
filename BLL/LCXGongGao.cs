using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
    /// <summary>
    /// 类LCXNotice。
    /// </summary>
    public class LCXNotice
    {
        public LCXNotice()
        { }
        #region Model
        private int _id;
        private string _titlestr;
        private string _username;
        private string _userbumen;
        private string _fujian;
        private string _contentstr;
        private string _typestr;
        private string _timestr;
        /// <summary>
        /// 
        /// </summary>
        public string TimeStr
        {
            set { _timestr = value; }
            get { return _timestr; }
        }
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
        public string TitleStr
        {
            set { _titlestr = value; }
            get { return _titlestr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 部门公告通知用此列
        /// </summary>
        public string UserBuMen
        {
            set { _userbumen = value; }
            get { return _userbumen; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FuJian
        {
            set { _fujian = value; }
            get { return _fujian; }
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
        public string TypeStr
        {
            set { _typestr = value; }
            get { return _typestr; }
        }
        #endregion Model


        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXNotice");
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
            strSql.Append("insert into LCXNotice(");
            strSql.Append("TitleStr,UserName,UserBuMen,FuJian,ContentStr,TypeStr)");
            strSql.Append(" values (");
            strSql.Append("@TitleStr,@UserName,@UserBuMen,@FuJian,@ContentStr,@TypeStr)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@TitleStr", SqlDbType.VarChar,500),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@UserBuMen", SqlDbType.VarChar,5000),
					new SqlParameter("@FuJian", SqlDbType.VarChar,2000),
					new SqlParameter("@ContentStr", SqlDbType.Text),
					new SqlParameter("@TypeStr", SqlDbType.VarChar,50)};
            parameters[0].Value = TitleStr;
            parameters[1].Value = UserName;
            parameters[2].Value = UserBuMen;
            parameters[3].Value = FuJian;
            parameters[4].Value = ContentStr;
            parameters[5].Value = TypeStr;

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
            strSql.Append("update LCXNotice set ");
            strSql.Append("TitleStr=@TitleStr,");            
            strSql.Append("FuJian=@FuJian,");
            strSql.Append("ContentStr=@ContentStr,");
            strSql.Append("TypeStr=@TypeStr");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@TitleStr", SqlDbType.VarChar,500),					
					new SqlParameter("@FuJian", SqlDbType.VarChar,2000),
					new SqlParameter("@ContentStr", SqlDbType.Text),
					new SqlParameter("@TypeStr", SqlDbType.VarChar,50)};
            parameters[0].Value = ID;
            parameters[1].Value = TitleStr;            
            parameters[2].Value = FuJian;
            parameters[3].Value = ContentStr;
            parameters[4].Value = TypeStr;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LCXNotice ");
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
            strSql.Append("select ID,TitleStr,UserName,UserBuMen,FuJian,ContentStr,TypeStr,TimeStr ");
            strSql.Append(" FROM LCXNotice ");
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
                TitleStr = ds.Tables[0].Rows[0]["TitleStr"].ToString();
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                UserBuMen = ds.Tables[0].Rows[0]["UserBuMen"].ToString();
                FuJian = ds.Tables[0].Rows[0]["FuJian"].ToString();
                ContentStr = ds.Tables[0].Rows[0]["ContentStr"].ToString();
                TypeStr = ds.Tables[0].Rows[0]["TypeStr"].ToString();
                TimeStr = ds.Tables[0].Rows[0]["TimeStr"].ToString();
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID],[TitleStr],[TimeStr],[UserName],[UserBuMen],[FuJian],[ContentStr],[TypeStr] ");
            strSql.Append(" FROM LCXNotice ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}