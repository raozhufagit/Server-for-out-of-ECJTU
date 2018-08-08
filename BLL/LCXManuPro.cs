using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    public class LCXManuPro
    {
        public LCXManuPro(){ }
        #region Model

        private int _id;
        private int _jd_Dd;
        private string _Jd_User;
        private string _Jd_Name;
        private DateTime _Jd_Time;
        private DateTime _Jd_OverTime;
        private string _Jd_Fujian;
        private string _Jd_Content;
        private string _Jd_Spr;
        private string _Jd_SpYj;
        private DateTime _Jd_SpTime;
        private string _Jd_ZrUser;
        private DateTime _Jd_WcTime;
        private int _Jd_State;
        private string _Jd_Pic;
        private string _Jd_Pic2;

        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public int Jd_Dd
        {
            set { _jd_Dd = value; }
            get { return _jd_Dd; }
        }
        public string Jd_User
        {
            set { _Jd_User = value; }
            get { return _Jd_User; }
        }
        public string Jd_Name
        {
            set { _Jd_Name = value; }
            get { return _Jd_Name; }
        }
        public DateTime Jd_Time
        {
            set { _Jd_Time = value; }
            get { return _Jd_Time; }
        }
        public DateTime Jd_OverTime
        {
            set { _Jd_OverTime = value; }
            get { return _Jd_OverTime; }
        }
        public string Jd_Fujian
        {
            set { _Jd_Fujian = value; }
            get { return _Jd_Fujian; }
        }
        public string Jd_Content
        {
            set { _Jd_Content = value; }
            get { return _Jd_Content; }
        }
        public string Jd_Spr
        {
            set { _Jd_Spr = value; }
            get { return _Jd_Spr; }
        }
        public string Jd_SpYj
        {
            set { _Jd_SpYj = value; }
            get { return _Jd_SpYj; }
        }
        public DateTime Jd_SpTime
        {
            set { _Jd_SpTime = value; }
            get { return _Jd_SpTime; }
        }
        public string Jd_ZrUser
        {
            set { _Jd_ZrUser = value; }
            get { return _Jd_ZrUser; }
        }
        public DateTime Jd_WcTime
        {
            set { _Jd_WcTime = value; }
            get { return _Jd_WcTime; }
        }
        public int Jd_State
        {
            set { _Jd_State = value; }
            get { return _Jd_State; }
        }
        public string Jd_Pic
        {
            set { _Jd_Pic = value; }
            get { return _Jd_Pic; }
        }
        public string Jd_Pic2
        {
            set { _Jd_Pic2 = value; }
            get { return _Jd_Pic2; }
        }
        #endregion
 

        public LCXManuPro(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Jd_Dd,Jd_User,Jd_Name,Jd_Time,Jd_OverTime,Jd_Fujian,Jd_Content,Jd_Spr,Jd_SpYj,Jd_SpTime,Jd_ZrUser,Jd_WcTime,Jd_State,Jd_Pic,Jd_Pic2 ");
            strSql.Append(" FROM LCXManuPro ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr; 
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    ID = Int32.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                //ID,Jd_Dd,Jd_User,Jd_Name,Jd_Time,Jd_OverTime,Jd_Fujian,Jd_Content,Jd_Spr,Jd_SpYj,Jd_SpTime,Jd_ZrUser,Jd_WcTime,Jd_State,Jd_Pic,Jd_Pic2
                if (ds.Tables[0].Rows[0]["Jd_Dd"].ToString() != "")
                {
                    Jd_Dd = Int32.Parse(ds.Tables[0].Rows[0]["Jd_Dd"].ToString());
                }
                Jd_User = ds.Tables[0].Rows[0]["Jd_User"].ToString();
                Jd_Name = ds.Tables[0].Rows[0]["Jd_Name"].ToString();

                if (ds.Tables[0].Rows[0]["Jd_Time"].ToString() != "")
                {
                    Jd_Time = DateTime.Parse(ds.Tables[0].Rows[0]["Jd_Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Jd_OverTime"].ToString() != "")
                {
                    Jd_OverTime = DateTime.Parse(ds.Tables[0].Rows[0]["Jd_OverTime"].ToString());
                }

                Jd_Fujian = ds.Tables[0].Rows[0]["Jd_Fujian"].ToString();
                Jd_Content = ds.Tables[0].Rows[0]["Jd_Content"].ToString();
                Jd_Spr = ds.Tables[0].Rows[0]["Jd_Spr"].ToString();
                Jd_SpYj = ds.Tables[0].Rows[0]["Jd_SpYj"].ToString();

                if (ds.Tables[0].Rows[0]["Jd_SpTime"].ToString() != "")
                {
                    Jd_SpTime = DateTime.Parse(ds.Tables[0].Rows[0]["Jd_SpTime"].ToString());
                }
                Jd_ZrUser = ds.Tables[0].Rows[0]["Jd_ZrUser"].ToString();

                if (ds.Tables[0].Rows[0]["Jd_WcTime"].ToString() != "")
                {
                    Jd_WcTime = DateTime.Parse(ds.Tables[0].Rows[0]["Jd_WcTime"].ToString());
                } 
                if (ds.Tables[0].Rows[0]["Jd_State"].ToString() != "")
                {
                    Jd_State = Int32.Parse(ds.Tables[0].Rows[0]["Jd_State"].ToString());
                }
                Jd_Pic = ds.Tables[0].Rows[0]["Jd_Pic"].ToString();
                Jd_Pic2 = ds.Tables[0].Rows[0]["Jd_Pic2"].ToString(); 
            }
        }
        /// <summary>
        /// 根据ID值判断是否存在
        /// </summary>
        /// <param name="idstr">ID值</param>
        /// <returns>true false</returns>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXManuPro");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 添加一个实体
        /// </summary>
        /// <returns></returns>
        public int Add()
        {
            // //ID,Jd_Dd,Jd_User,Jd_Name,Jd_Time,Jd_OverTime,Jd_Fujian,Jd_Content,Jd_Spr,Jd_SpYj,Jd_SpTime,Jd_ZrUser,Jd_WcTime,Jd_State,Jd_Pic,Jd_Pic2
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LCXManuPro(");
            strSql.Append("Jd_Dd,Jd_User,Jd_Name,Jd_Time,Jd_OverTime,Jd_Fujian,Jd_Content,Jd_Spr,Jd_SpYj,Jd_SpTime,Jd_ZrUser,Jd_WcTime,Jd_State,Jd_Pic,Jd_Pic2)");
            strSql.Append(" values (");
            strSql.Append("@Jd_Dd,@Jd_User,@Jd_Name,@Jd_Time,@Jd_OverTime,@Jd_Fujian,@Jd_Content,@Jd_Spr,@Jd_SpYj,@Jd_SpTime,@Jd_ZrUser,@Jd_WcTime,@Jd_State,@Jd_Pic,@Jd_Pic2)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {  
                    new SqlParameter("@Jd_Dd", SqlDbType.Int,4),
					new SqlParameter("@Jd_User", SqlDbType.NVarChar,50),
					new SqlParameter("@Jd_Name", SqlDbType.NVarChar,200),
					new SqlParameter("@Jd_Time", SqlDbType.DateTime),
					new SqlParameter("@Jd_OverTime", SqlDbType.DateTime),
					new SqlParameter("@Jd_Fujian", SqlDbType.NVarChar,200),
                    new SqlParameter("@Jd_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@Jd_Spr", SqlDbType.NVarChar,50),
					new SqlParameter("@Jd_SpYj", SqlDbType.NVarChar,50),
                    new SqlParameter("@Jd_SpTime", SqlDbType.DateTime),
					new SqlParameter("@Jd_ZrUser", SqlDbType.NVarChar,500),
                    new SqlParameter("@Jd_WcTime", SqlDbType.DateTime),
                    new SqlParameter("@Jd_State", SqlDbType.Int),
                    new SqlParameter("@Jd_Pic", SqlDbType.NVarChar,200),
                    new SqlParameter("@Jd_Pic2", SqlDbType.NVarChar,200)
            };

            parameters[0].Value = Jd_Dd;
            parameters[1].Value = Jd_User;
            parameters[2].Value = Jd_Name;
            if (Jd_Time == Convert.ToDateTime(null))
            {
                parameters[3].Value = null; 
            }
            else
            {
                parameters[3].Value = Jd_Time;
            }
            if (Jd_OverTime == Convert.ToDateTime(null))
            {
                parameters[4].Value = null;
            }
            else
            {
                parameters[4].Value = Jd_OverTime;
            }
            parameters[5].Value = Jd_Fujian;
            parameters[6].Value = Jd_Content;
            parameters[7].Value = Jd_Spr;
            parameters[8].Value = Jd_SpYj;
           
             if (Jd_SpTime == Convert.ToDateTime(null))
            {
                parameters[9].Value = null;
            }
            else
            {
                parameters[9].Value = Jd_SpTime;
            }
            parameters[10].Value = Jd_ZrUser;
             if (Jd_WcTime == Convert.ToDateTime(null))
            {
                parameters[11].Value = null;
            }
            else
            {
                parameters[11].Value = Jd_WcTime;
            }
            parameters[12].Value = Jd_State;
            parameters[13].Value = Jd_Pic;
            parameters[14].Value = Jd_Pic2; 
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
        /// <summary>
        /// 修改实体
        /// </summary>
        public int Update()
        {
            //Jd_Dd,Jd_User,Jd_Name,Jd_Time,Jd_OverTime,Jd_Fujian,Jd_Content,Jd_Spr,Jd_SpYj,Jd_SpTime,Jd_ZrUser,Jd_WcTime,Jd_State,Jd_Pic,Jd_Pic2
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LCXManuPro set ");
            strSql.Append("Jd_Dd=@Jd_Dd,");
            strSql.Append("Jd_User=@Jd_User,");
            strSql.Append("Jd_Name=@Jd_Name,");
            strSql.Append("Jd_Time=@Jd_Time,");
            strSql.Append("Jd_OverTime=@Jd_OverTime,");
            strSql.Append("Jd_Fujian=@Jd_Fujian,");
            strSql.Append("Jd_Content=@Jd_Content,");
            strSql.Append("Jd_Spr=@Jd_Spr,");
            strSql.Append("Jd_SpYj=@Jd_SpYj,");
            strSql.Append("Jd_SpTime=@Jd_SpTime,");
            strSql.Append("Jd_ZrUser=@Jd_ZrUser,");
            strSql.Append("Jd_WcTime=@Jd_WcTime,");
            strSql.Append("Jd_State=@Jd_State,");
            strSql.Append("Jd_Pic=@Jd_Pic,");
            strSql.Append("Jd_Pic2=@Jd_Pic2"); 
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					  new SqlParameter("@Jd_Dd", SqlDbType.Int,4),
					new SqlParameter("@Jd_User", SqlDbType.NVarChar,50),
					new SqlParameter("@Jd_Name", SqlDbType.NVarChar,200),
					new SqlParameter("@Jd_Time", SqlDbType.DateTime),
					new SqlParameter("@Jd_OverTime", SqlDbType.DateTime),
					new SqlParameter("@Jd_Fujian", SqlDbType.NVarChar,200),
                    new SqlParameter("@Jd_Content", SqlDbType.NVarChar,500),
					new SqlParameter("@Jd_Spr", SqlDbType.NVarChar,50),
					new SqlParameter("@Jd_SpYj", SqlDbType.NVarChar,50),
                    new SqlParameter("@Jd_SpTime", SqlDbType.DateTime),
					new SqlParameter("@Jd_ZrUser", SqlDbType.NVarChar,500),
                    new SqlParameter("@Jd_WcTime", SqlDbType.DateTime),
                    new SqlParameter("@Jd_State", SqlDbType.Int),
                    new SqlParameter("@Jd_Pic", SqlDbType.NVarChar,200),
                    new SqlParameter("@Jd_Pic2", SqlDbType.NVarChar,200)
            };
            parameters[0].Value = ID;
            parameters[1].Value = Jd_Dd;
            parameters[2].Value = Jd_User;
            parameters[3].Value = Jd_Name;
            if (Jd_Time == Convert.ToDateTime(null))
            {
                parameters[4].Value = null;
            }
            else
            {
                parameters[4].Value = Jd_Time;
            }
            if (Jd_OverTime == Convert.ToDateTime(null))
            {
                parameters[5].Value = null;
            }
            else
            {
                parameters[5].Value = Jd_OverTime;
            }
            parameters[6].Value = Jd_Fujian;
            parameters[7].Value = Jd_Content;
            parameters[8].Value = Jd_Spr;
            parameters[9].Value = Jd_SpYj;

            if (Jd_SpTime == Convert.ToDateTime(null))
            {
                parameters[10].Value = null;
            }
            else
            {
                parameters[10].Value = Jd_SpTime;
            }
            parameters[11].Value = Jd_ZrUser;
            if (Jd_WcTime == Convert.ToDateTime(null))
            {
                parameters[12].Value = null;
            }
            else
            {
                parameters[12].Value = Jd_WcTime;
            }
            parameters[13].Value = Jd_State;
            parameters[14].Value = Jd_Pic;
            parameters[15].Value = Jd_Pic2; 
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="idstr"></param>
        public int Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LCXManuPro ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="idstr"></param>
        public void GetModel(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Jd_Dd,Jd_User,Jd_Name,Jd_Time,Jd_OverTime,Jd_Fujian,Jd_Content,Jd_Spr,Jd_SpYj,Jd_SpTime,Jd_ZrUser,Jd_WcTime,Jd_State,Jd_Pic,Jd_Pic2 ");
            strSql.Append(" FROM LCXManuPro ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    ID = Int32.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                //ID,Jd_Dd,Jd_User,Jd_Name,Jd_Time,Jd_OverTime,Jd_Fujian,Jd_Content,Jd_Spr,Jd_SpYj,Jd_SpTime,Jd_ZrUser,Jd_WcTime,Jd_State,Jd_Pic,Jd_Pic2
                if (ds.Tables[0].Rows[0]["Jd_Dd"].ToString() != "")
                {
                    Jd_Dd = Int32.Parse(ds.Tables[0].Rows[0]["Jd_Dd"].ToString());
                }
                Jd_User = ds.Tables[0].Rows[0]["Jd_User"].ToString();
                Jd_Name = ds.Tables[0].Rows[0]["Jd_Name"].ToString();

                if (ds.Tables[0].Rows[0]["Jd_Time"].ToString() != "")
                {
                    Jd_Time = DateTime.Parse(ds.Tables[0].Rows[0]["Jd_Time"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Jd_OverTime"].ToString() != "")
                {
                    Jd_OverTime = DateTime.Parse(ds.Tables[0].Rows[0]["Jd_OverTime"].ToString());
                }

                Jd_Fujian = ds.Tables[0].Rows[0]["Jd_Fujian"].ToString();
                Jd_Content = ds.Tables[0].Rows[0]["Jd_Content"].ToString();
                Jd_Spr = ds.Tables[0].Rows[0]["Jd_Spr"].ToString();
                Jd_SpYj = ds.Tables[0].Rows[0]["Jd_SpYj"].ToString();

                if (ds.Tables[0].Rows[0]["Jd_SpTime"].ToString() != "")
                {
                    Jd_SpTime = DateTime.Parse(ds.Tables[0].Rows[0]["Jd_SpTime"].ToString());
                }
                Jd_ZrUser = ds.Tables[0].Rows[0]["Jd_ZrUser"].ToString();

                if (ds.Tables[0].Rows[0]["Jd_WcTime"].ToString() != "")
                {
                    Jd_WcTime = DateTime.Parse(ds.Tables[0].Rows[0]["Jd_WcTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Jd_State"].ToString() != "")
                {
                    Jd_State = Int32.Parse(ds.Tables[0].Rows[0]["Jd_State"].ToString());
                }
                Jd_Pic = ds.Tables[0].Rows[0]["Jd_Pic"].ToString();
                Jd_Pic2 = ds.Tables[0].Rows[0]["Jd_Pic2"].ToString();
            }
        }
        /// <summary>
        /// 根据条件获取一个DATASET列表
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select [ID],[Jd_Dd],[Jd_User],[Jd_Name],[Jd_Time],[Jd_OverTime],[Jd_Fujian],[Jd_Content],[Jd_Spr],[Jd_SpYj],[Jd_SpTime],[Jd_ZrUser],[Jd_WcTime],[Jd_State],[Jd_Pic],[Jd_Pic2]");
            strSql.Append(" FROM LCXManuPro ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
