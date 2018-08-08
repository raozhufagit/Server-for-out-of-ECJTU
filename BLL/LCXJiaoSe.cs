using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
    /// <summary>
    /// 类LCXRole_Info。
    /// </summary>
    public class LCXRole_Info
    {
        public LCXRole_Info()
        { }
        #region Model
        private int _id;
        private string _jiaosename;
        private string _backinfo;
        private string _quanxian;
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
        public string JiaoSeName
        {
            set { _jiaosename = value; }
            get { return _jiaosename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BackInfo
        {
            set { _backinfo = value; }
            get { return _backinfo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string QuanXian
        {
            set { _quanxian = value; }
            get { return _quanxian; }
        }
        #endregion Model


        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXRole_Info");
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
            strSql.Append("insert into LCXRole_Info(");
            strSql.Append("JiaoSeName,BackInfo,QuanXian)");
            strSql.Append(" values (");
            strSql.Append("@JiaoSeName,@BackInfo,@QuanXian)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@JiaoSeName", SqlDbType.VarChar,50),
					new SqlParameter("@BackInfo", SqlDbType.VarChar,1000),
					new SqlParameter("@QuanXian", SqlDbType.VarChar,8000)};
            parameters[0].Value = JiaoSeName;
            parameters[1].Value = BackInfo;
            parameters[2].Value = QuanXian;

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
            strSql.Append("update LCXRole_Info set ");
            strSql.Append("JiaoSeName=@JiaoSeName,");
            strSql.Append("BackInfo=@BackInfo,");
            strSql.Append("QuanXian=@QuanXian");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@JiaoSeName", SqlDbType.VarChar,50),
					new SqlParameter("@BackInfo", SqlDbType.VarChar,1000),
					new SqlParameter("@QuanXian", SqlDbType.VarChar,8000)};
            parameters[0].Value = ID;
            parameters[1].Value = JiaoSeName;
            parameters[2].Value = BackInfo;
            parameters[3].Value = QuanXian;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LCXRole_Info ");
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
            strSql.Append("select ID,JiaoSeName,BackInfo,QuanXian ");
            strSql.Append(" FROM LCXRole_Info ");
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
                JiaoSeName = ds.Tables[0].Rows[0]["JiaoSeName"].ToString();
                BackInfo = ds.Tables[0].Rows[0]["BackInfo"].ToString();
                QuanXian = ds.Tables[0].Rows[0]["QuanXian"].ToString();
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID],[JiaoSeName],[BackInfo],[QuanXian] ");
            strSql.Append(" FROM LCXRole_Info ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}