using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
    public class LCXManuFact
    {
        public LCXManuFact()
        {

        } 
        #region Model
        private int _id;
        private string _sc_Name;
        private string _sc_Tjr;
        private DateTime _sc_Timer;
        private string _sc_Spr;
        private DateTime _sc_SpTime;
        private string _sc_Yij;
        private string _sc_Fuj; 
        private string _sc_Custmoer;
        private int _sc_State;
        private string _sc_Maoshu;
        private DateTime _sc_Jtime;
        public int ID{
            set{ _id=value;}
            get{return _id;}
        }
        public string Sc_Name
        {
            set{ _sc_Name=value;}
            get{return _sc_Name;}
        }
        public string Sc_Tjr
        {
            set{ _sc_Tjr=value;}
            get{return _sc_Tjr;}
        }
        public DateTime Sc_Timer
        {
            set{_sc_Timer =value;}
            get{return _sc_Timer;}
        }
        public string Sc_Spr
        {
            set{_sc_Spr =value;}
            get{return _sc_Spr;}
        }
        public DateTime Sc_SpTime
        {
            set{_sc_SpTime =value;}
            get{return _sc_SpTime;}
        }
        public string Sc_Yij
        {
            set{_sc_Yij =value;}
            get{return _sc_Yij;}
        }
        public string Sc_Fuj
        {
            set{ _sc_Fuj=value;}
            get{return _sc_Fuj;}
        } 
        public string Sc_Custmoer
        {
            set{_sc_Custmoer =value;}
            get{return _sc_Custmoer;}
        }
        public int Sc_State
        {
            set{ _sc_State=value;}
            get{return _sc_State;}
        }
        public string Sc_Maoshu
        {
            set{_sc_Maoshu =value;}
            get{return _sc_Maoshu;}
        }
        public DateTime Sc_Jtime
        {
            set { _sc_Jtime = value; }
            get { return _sc_Jtime; }
        }
        #endregion

        public LCXManuFact(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Sc_Name,Sc_Tjr,Sc_Timer,Sc_Spr,Sc_SpTime,Sc_Yij,Sc_Fuj,Sc_Custmoer,Sc_State,Sc_Maoshu,Sc_Jtime ");
            strSql.Append(" FROM LCXManuFact ");
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
                Sc_Name = ds.Tables[0].Rows[0]["Sc_Name"].ToString();
                Sc_Tjr = ds.Tables[0].Rows[0]["Sc_Tjr"].ToString();
                if (ds.Tables[0].Rows[0]["Sc_Timer"].ToString() != "")
                {
                    Sc_Timer = DateTime.Parse(ds.Tables[0].Rows[0]["Sc_Timer"].ToString());
                }
                Sc_Spr = ds.Tables[0].Rows[0]["Sc_Spr"].ToString();

                if (ds.Tables[0].Rows[0]["Sc_SpTime"].ToString() != "")
                {
                    Sc_SpTime = DateTime.Parse(ds.Tables[0].Rows[0]["Sc_SpTime"].ToString());
                }

                Sc_Yij = ds.Tables[0].Rows[0]["Sc_Yij"].ToString();
                Sc_Fuj = ds.Tables[0].Rows[0]["Sc_Fuj"].ToString();
                Sc_Custmoer = ds.Tables[0].Rows[0]["Sc_Custmoer"].ToString();
                if (ds.Tables[0].Rows[0]["Sc_State"].ToString() != "")
                {
                    Sc_State = int.Parse(ds.Tables[0].Rows[0]["Sc_State"].ToString());
                }
                Sc_Maoshu = ds.Tables[0].Rows[0]["Sc_Maoshu"].ToString();
                if (ds.Tables[0].Rows[0]["Sc_Jtime"].ToString() != "")
                {
                    Sc_Jtime = DateTime.Parse(ds.Tables[0].Rows[0]["Sc_Jtime"].ToString());
                }
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
            strSql.Append("select count(1) from LCXManuFact");
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
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LCXManuFact(");
            strSql.Append("Sc_Name,Sc_Tjr,Sc_Timer,Sc_Spr,Sc_SpTime,Sc_Yij,Sc_Fuj,Sc_Custmoer,Sc_State,Sc_Maoshu,Sc_Jtime)");
            strSql.Append(" values (");
            strSql.Append("@Sc_Name,@Sc_Tjr,@Sc_Timer,@Sc_Spr,@Sc_SpTime,@Sc_Yij,@Sc_Fuj,@Sc_Custmoer,@Sc_State,@Sc_Maoshu,@Sc_Jtime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@Sc_Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Sc_Tjr", SqlDbType.NVarChar,50),
					new SqlParameter("@Sc_Timer", SqlDbType.DateTime),
					new SqlParameter("@Sc_Spr", SqlDbType.NVarChar,50),
					new SqlParameter("@Sc_SpTime", SqlDbType.DateTime),
					new SqlParameter("@Sc_Yij", SqlDbType.NVarChar,200),
					new SqlParameter("@Sc_Fuj", SqlDbType.NVarChar,50),
					new SqlParameter("@Sc_Custmoer", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sc_State", SqlDbType.Int,4),
					new SqlParameter("@Sc_Maoshu", SqlDbType.NVarChar,200),
                    new SqlParameter("@Sc_Jtime", SqlDbType.DateTime)
                                        };
            parameters[0].Value = Sc_Name;
            parameters[1].Value = Sc_Tjr;
            parameters[2].Value = Sc_Timer;
            parameters[3].Value = Sc_Spr;
            if (Sc_SpTime == Convert.ToDateTime(null)) 
            {
                parameters[4].Value = null;//Sc_SpTime;
            }
            else
            {
                parameters[4].Value = Sc_SpTime;
            }
           
            parameters[5].Value = Sc_Yij;
            parameters[6].Value = Sc_Fuj;
            parameters[7].Value = Sc_Custmoer;
            parameters[8].Value = Sc_State;
            parameters[9].Value = Sc_Maoshu;
            if (Sc_Jtime == Convert.ToDateTime(null))
            {
                parameters[10].Value = null;//Sc_SpTime;
            }
            else
            {
                parameters[10].Value = Sc_Jtime; 
            }
           
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
            //Sc_Name,Sc_Tjr,Sc_Timer,Sc_Spr,Sc_SpTime,Sc_Yij,Sc_Fuj,Sc_Custmoer,Sc_State,Sc_Maoshu
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LCXManuFact set ");
            strSql.Append("Sc_Name=@Sc_Name,");
            strSql.Append("Sc_Tjr=@Sc_Tjr,");
            strSql.Append("Sc_Timer=@Sc_Timer,");
            strSql.Append("Sc_Spr=@Sc_Spr,");
            strSql.Append("Sc_SpTime=@Sc_SpTime,");
            strSql.Append("Sc_Yij=@Sc_Yij,");
            strSql.Append("Sc_Fuj=@Sc_Fuj,");
            strSql.Append("Sc_Custmoer=@Sc_Custmoer,");
            strSql.Append("Sc_State=@Sc_State,");
            strSql.Append("Sc_Maoshu=@Sc_Maoshu,");
            strSql.Append("Sc_Jtime=@Sc_Jtime"); 
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Sc_Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Sc_Tjr", SqlDbType.NVarChar,50),
					new SqlParameter("@Sc_Timer", SqlDbType.DateTime),
					new SqlParameter("@Sc_Spr", SqlDbType.NVarChar,50),
					new SqlParameter("@Sc_SpTime", SqlDbType.DateTime),
					new SqlParameter("@Sc_Yij", SqlDbType.NVarChar,200),
					new SqlParameter("@Sc_Fuj", SqlDbType.NVarChar,50),
					new SqlParameter("@Sc_Custmoer", SqlDbType.NVarChar,50),
                    new SqlParameter("@Sc_State", SqlDbType.Int,4),
					new SqlParameter("@Sc_Maoshu", SqlDbType.NVarChar,200),
                    new SqlParameter("@Sc_Jtime", SqlDbType.DateTime)};
            parameters[0].Value = ID;
            parameters[1].Value = Sc_Name;
            parameters[2].Value = Sc_Tjr; 
            if (Sc_Timer == Convert.ToDateTime(null))
            {
                parameters[3].Value = null;//Sc_SpTime;
            }
            else
            {
                parameters[3].Value = Sc_Timer;
            }
            parameters[4].Value = Sc_Spr;
            
            if (Sc_SpTime == Convert.ToDateTime(null))
            {
                parameters[5].Value = null;//Sc_SpTime;
            }
            else
            {
                parameters[5].Value = Sc_SpTime;
            }
            parameters[6].Value = Sc_Yij;
            parameters[7].Value = Sc_Fuj;
            parameters[8].Value = Sc_Custmoer;
            parameters[9].Value = Sc_State;
            parameters[10].Value = Sc_Maoshu;
             
            if (Sc_Jtime == Convert.ToDateTime(null))
            {
                parameters[11].Value = null;//Sc_SpTime;
            }
            else
            {
                parameters[11].Value = Sc_Jtime;
            }
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }



        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="idstr"></param>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LCXManuFact ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 获取一个实体
        /// </summary>
        /// <param name="idstr"></param>
        public void GetModel(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Sc_Name,Sc_Tjr,Sc_Timer,Sc_Spr,Sc_SpTime,Sc_Yij,Sc_Fuj,Sc_Custmoer,Sc_State,Sc_Maoshu,Sc_Jtime ");
            strSql.Append(" FROM LCXManuFact ");
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
                Sc_Name = ds.Tables[0].Rows[0]["Sc_Name"].ToString();
                Sc_Tjr = ds.Tables[0].Rows[0]["Sc_Tjr"].ToString();
                if (ds.Tables[0].Rows[0]["Sc_Timer"].ToString() != "")
                {
                    Sc_Timer = DateTime.Parse(ds.Tables[0].Rows[0]["Sc_Timer"].ToString());
                }
                Sc_Spr = ds.Tables[0].Rows[0]["Sc_Spr"].ToString();

                if (ds.Tables[0].Rows[0]["Sc_SpTime"].ToString() != "")
                {
                    Sc_SpTime = DateTime.Parse(ds.Tables[0].Rows[0]["Sc_SpTime"].ToString());
                }

                Sc_Yij = ds.Tables[0].Rows[0]["Sc_Yij"].ToString();
                Sc_Fuj = ds.Tables[0].Rows[0]["Sc_Fuj"].ToString();
                Sc_Custmoer = ds.Tables[0].Rows[0]["Sc_Custmoer"].ToString();
                if (ds.Tables[0].Rows[0]["Sc_State"].ToString() != "")
                {
                    Sc_State = int.Parse(ds.Tables[0].Rows[0]["Sc_State"].ToString());
                }
                Sc_Maoshu = ds.Tables[0].Rows[0]["Sc_Maoshu"].ToString();
                if (ds.Tables[0].Rows[0]["Sc_Jtime"].ToString() != "")
                {
                    Sc_Jtime = DateTime.Parse(ds.Tables[0].Rows[0]["Sc_Jtime"].ToString());
                }
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
            strSql.Append("select [ID],[Sc_Name],[Sc_Tjr],[Sc_Timer],[Sc_Spr],[Sc_SpTime],[Sc_Yij],[Sc_Fuj],[Sc_Custmoer],[Sc_State],[Sc_Maoshu],[Sc_Jtime] ");
            strSql.Append(" FROM LCXManuFact ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
