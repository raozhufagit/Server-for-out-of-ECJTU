using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    public class LCXScSeting
    {
         
        #region Model
        private int _id;   
        private string _dd_User;
        private string _sc_User;
        private string _sc_JUser;
        private string _sc_SUser;
        private string _jd_User;
        private string _jd_SUser;

        /// <summary>
        /// ID索引值
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 订单审核人
        /// </summary>
        public string dd_User
        {
            set { _dd_User = value; }
            get { return _dd_User; }
        }
        /// <summary>
        /// 生产单制单人
        /// </summary>
        public string sc_User
        {
            set { _sc_User = value; }
            get { return _sc_User; }
        }
        /// <summary>
        /// 生产单技术审核人
        /// </summary>
        public string sc_JUser
        {
            set { _sc_JUser = value; }
            get { return _sc_JUser; }
        }
        /// <summary>
        /// 生产单最终审核人
        /// </summary>
        public string sc_SUser
        {
            set { _sc_SUser = value; }
            get { return _sc_SUser; }
        }
        /// <summary>
        /// 进度制单人
        /// </summary>
        public string jd_User
        {
            set { _jd_User = value; }
            get { return _jd_User; }
        }
        /// <summary>
        /// 进度审核人
        /// </summary> 
        public string jd_SUser
        {
            set { _jd_SUser = value; }
            get { return _jd_SUser; }
        }
         
        #endregion

        public LCXScSeting()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top(1) * ");
            strSql.Append(" FROM LCXManufSet ");
            SqlParameter[] parameters = {
					 }; 
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                dd_User = ds.Tables[0].Rows[0]["dd_User"].ToString();
                sc_User = ds.Tables[0].Rows[0]["sc_User"].ToString();
                sc_JUser = ds.Tables[0].Rows[0]["sc_JUser"].ToString();
                sc_SUser = ds.Tables[0].Rows[0]["sc_SUser"].ToString();
                jd_User = ds.Tables[0].Rows[0]["jd_User"].ToString(); 
                jd_SUser = ds.Tables[0].Rows[0]["jd_SUser"].ToString();
            }
        }
        /// <summary>
        /// 添加生产设置信息
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LCXManufSet(");
            strSql.Append("dd_User,sc_User,sc_JUser,sc_SUser,jd_User,jd_SUser)");
            strSql.Append(" values (");
            strSql.Append("@dd_User,@sc_User,@sc_JUser,@sc_SUser,@jd_User,@jd_SUser)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@dd_User", SqlDbType.NVarChar,200),
					new SqlParameter("@sc_User", SqlDbType.NVarChar,200),
					new SqlParameter("@sc_JUser", SqlDbType.NVarChar,200),
					new SqlParameter("@sc_SUser", SqlDbType.NVarChar,200),
					new SqlParameter("@jd_User", SqlDbType.NVarChar,200),
					new SqlParameter("@jd_SUser", SqlDbType.NVarChar,200) 
                                        };
            parameters[0].Value = dd_User;
            parameters[1].Value = sc_User;
            parameters[2].Value = sc_JUser;
            parameters[3].Value = sc_SUser;
            parameters[4].Value = jd_User;
            parameters[5].Value = jd_SUser; 
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
        public int Update()
        {
            //dd_User,sc_User,sc_JUser,sc_SUser,jd_User,jd_SUser 
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LCXManufSet set ");
            strSql.Append("dd_User=@dd_User,");
            strSql.Append("sc_User=@sc_User,");
            strSql.Append("sc_JUser=@sc_JUser,");
            strSql.Append("sc_SUser=@sc_SUser,");
            strSql.Append("jd_User=@jd_User,");
            strSql.Append("jd_SUser=@jd_SUser");  
            //strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@dd_User", SqlDbType.NVarChar,200),
					new SqlParameter("@sc_User", SqlDbType.NVarChar,200),
					new SqlParameter("@sc_JUser", SqlDbType.NVarChar,200),
					new SqlParameter("@sc_SUser", SqlDbType.NVarChar,200),
					new SqlParameter("@jd_User", SqlDbType.NVarChar,200),
					new SqlParameter("@jd_SUser", SqlDbType.NVarChar,200) 
                                        };
            parameters[0].Value = dd_User;
            parameters[1].Value = sc_User;
            parameters[2].Value = sc_JUser;
            parameters[3].Value = sc_SUser;
            parameters[4].Value = jd_User;
            parameters[5].Value = jd_SUser;
            if (DbHelperSQL.ExecuteSql(strSql.ToString(), parameters) == 0)
            {
                return Add();
            }
            else
            {
                return 1;
            } 
        }

         

    }
}
