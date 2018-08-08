using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using LCX.DBUtility;//请先添加引用
using System.Text;

namespace LCX.BLL
{
  public class LCXRtx
    {
        public LCXRtx()
        {

        }
        #region Model
        private int _id;
        private string _username;
        private string _rtxname;
        private string _rtxpwd;
        private bool _rtxstate;     

        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        public string RtxName
        {
            set { _rtxname = value; }
            get { return _rtxname; }
        }
        public string RtxPwd
        {
            set { _rtxpwd = value; }
            get { return _rtxpwd; }
        }
        public bool RtxState
        {
            set { _rtxstate = value; }
            get { return _rtxstate; }
        }

        #endregion
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string UserNameStr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXRtx");
            strSql.Append(" where UserName=@UserName "); 
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50)	
                  };
            parameters[0].Value = UserNameStr;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LCXRtx(");
            strSql.Append("UserName,RtxName,RtxPwd,RtxState)");
            strSql.Append(" values (");
            strSql.Append("@UserName,@RtxName,@RtxPwd,@RtxState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@RtxName", SqlDbType.VarChar,50),
					new SqlParameter("@RtxPwd", SqlDbType.VarChar,50),
                    new SqlParameter("@RtxState", SqlDbType.Bit)
                                        };
            parameters[0].Value = UserName;
            parameters[1].Value = RtxName;
            parameters[2].Value = RtxPwd;
            parameters[3].Value = RtxState;

            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        public void Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LCXRtx set ");
            strSql.Append("UserName=@UserName,");
            strSql.Append("RtxName=@RtxName,");
            strSql.Append("RtxPwd=@RtxPwd,");
            strSql.Append("RtxState=@RtxState");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@RtxName", SqlDbType.VarChar,50),
					new SqlParameter("@RtxPwd", SqlDbType.VarChar,50),
                    new SqlParameter("@RtxState", SqlDbType.Bit)};
            parameters[0].Value = ID;
            parameters[1].Value = UserName;
            parameters[2].Value = RtxName;
            parameters[3].Value = RtxPwd;
            parameters[4].Value = RtxState;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LCXRtx ");
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
            strSql.Append("select ID,UserName,RtxName,RtxPwd,RtxState");
            strSql.Append(" FROM LCXRtx");
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
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                RtxName = ds.Tables[0].Rows[0]["RtxName"].ToString();
                RtxPwd = ds.Tables[0].Rows[0]["RtxPwd"].ToString();
                RtxState = Convert.ToBoolean(ds.Tables[0].Rows[0]["RtxState"].ToString());
            }
        }
        /// <summary>
        /// 获取一个RTX实体
        /// </summary>
        /// <param name="ID"></param>
        public void GetModel(string usernamestr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,UserName,RtxName,RtxPwd,RtxState");
            strSql.Append(" FROM LCXRtx");
            strSql.Append(" where UserName=@username ");
            SqlParameter[] parameters = {
					new SqlParameter("@username", SqlDbType.NVarChar,50)				};
            parameters[0].Value = usernamestr;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                RtxName = ds.Tables[0].Rows[0]["RtxName"].ToString();
                RtxPwd = ds.Tables[0].Rows[0]["RtxPwd"].ToString();
                RtxState = Convert.ToBoolean(ds.Tables[0].Rows[0]["RtxState"].ToString());
            }
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID],[UserName],[RtxName],[RtxPwd],[RtxState] ");
            strSql.Append(" FROM LCXRtx ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        #endregion
    }
}
