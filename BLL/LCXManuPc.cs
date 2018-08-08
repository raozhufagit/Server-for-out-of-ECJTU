using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    public class LCXManuPc
    {
        public LCXManuPc() { }
        #region Model 
        private int _id;
        private int _pc_Dd;
        private string _pc_Name;
        private string _pc_Vesion;
        private string _pc_Wenjian;
        private string _pc_UserName;
        private DateTime _pc_Timer;
        private string _pc_ViewUser;
        private string _pc_NotUser;
        private string _pc_accUser;
        private string _pc_JsSp;
        private DateTime _pc_JsStime;
        private string _pc_SpUser;
        private DateTime _pc_SpTimer;
        private string _pc_mark;
        private int _pc_State;
        private string _pc_Jsyj;
        private string _pc_Yj;

        public string Pc_Jsyj
        {
            set { _pc_Jsyj = value; }
            get { return _pc_Jsyj; }
        }
        public string Pc_Yj
        {
            set { _pc_Yj = value; }
            get { return _pc_Yj; }
        }


        public int ID{
            set{  _id= value;}
            get{ return _id;}
        }
        /// <summary>
        /// 生产订单ID
        /// </summary>
        public int Pc_Dd{
            set{ _pc_Dd = value;}
            get{ return _pc_Dd;}
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Pc_Name{
            set{_pc_Name  = value;}
            get{ return _pc_Name;}
        }
        /// <summary>
        /// 版本号
        /// </summary>
        public string Pc_Vesion{
            set{ _pc_Vesion = value;}
            get{ return _pc_Vesion;}
        }
        /// <summary>
        /// 文件
        /// </summary>
        public string Pc_Wenjian{
            set{_pc_Wenjian  = value;}
            get{ return _pc_Wenjian;}
        }
        /// <summary>
        /// 发起人
        /// </summary>
        public string Pc_UserName{
            set{ _pc_UserName = value;}
            get{ return _pc_UserName;}
        }
        /// <summary>
        /// 发布时间
        /// </summary>
        public DateTime Pc_Timer{
            set{ _pc_Timer = value;}
            get{ return _pc_Timer;}
        }
        /// <summary>
        /// 查看人
        /// </summary>
        public string Pc_ViewUser{
            set{_pc_ViewUser  = value;}
            get{ return _pc_ViewUser;}
        }
        /// <summary>
        /// 通知人员
        /// </summary>
        public string Pc_NotUser{
            set{ _pc_NotUser = value;}
            get{ return _pc_NotUser;}
        }
        /// <summary>
        /// 签到人员
        /// </summary>
        public string Pc_accUser{
            set{ _pc_accUser = value;}
            get{ return _pc_accUser;}
        }
        /// <summary>
        /// 技术审批人员
        /// </summary>
        public string Pc_JsSp
        {
            set { _pc_JsSp = value; }
            get { return _pc_JsSp; }
        }
        /// <summary>
        /// 技术审批时间
        /// </summary>
        public DateTime Pc_JsStime
        {
            set { _pc_JsStime = value; }
            get { return _pc_JsStime; }
        }

        /// <summary>
        /// 审批人员
        /// </summary>
        public string Pc_SpUser{
            set{ _pc_SpUser = value;}
            get{ return _pc_SpUser;}
        }
        /// <summary>
        /// 审批时间
        /// </summary>
        public DateTime Pc_SpTimer{
            set{ _pc_SpTimer = value;}
            get{ return _pc_SpTimer;}
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Pc_mark{
            set{ _pc_mark = value;}
            get{ return _pc_mark;}
        }
        /// <summary>
        /// 状态
        /// </summary>
        public int Pc_State{
            set{ _pc_State = value;}
            get{ return _pc_State;}
        }
        

/*

   ID                   int                  identity,
   Pc_Dd                int                  null,
   Pc_Name              nvarchar(100)        null,
   Pc_Vesion            nvarchar(100)        null,
   Pc_Wenjian           nvarchar(200)        null,
   Pc_UserName          nvarchar(100)        null,
   Pc_Timer             datetime             null,
   Pc_ViewUser          nvarchar(500)        null,
   Pc_NotUser           nvarchar(200)        null,
   Pc_accUser           nvarchar(200)        null,
   Pc_SpUser            nvarchar(200)        null,
   Pc_SpTimer           datetime             null,
   Pc_mark              nvarchar(200)        null,
   Pc_State  
 * */
        #endregion 

        public LCXManuPc(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Pc_Dd,Pc_Name,Pc_Vesion,Pc_Wenjian,Pc_UserName,Pc_Timer,Pc_ViewUser,Pc_NotUser,Pc_accUser,Pc_JsSp,Pc_JsStime,Pc_SpUser,Pc_SpTimer,Pc_mark,Pc_State ");
            strSql.Append(" FROM LCXManuPc ");
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
                if (ds.Tables[0].Rows[0]["Pc_Dd"].ToString() != "")
                {
                    Pc_Dd = Int32.Parse(ds.Tables[0].Rows[0]["Pc_Dd"].ToString());
                } 
                Pc_Name=ds.Tables[0].Rows[0]["Pc_Name"].ToString();
                Pc_Vesion=ds.Tables[0].Rows[0]["Pc_Name"].ToString();
                Pc_Wenjian=ds.Tables[0].Rows[0]["Pc_Name"].ToString();
                Pc_UserName=ds.Tables[0].Rows[0]["Pc_Name"].ToString(); 
                if (ds.Tables[0].Rows[0]["Pc_Timer"].ToString() != "")
                {
                    Pc_Timer = DateTime.Parse(ds.Tables[0].Rows[0]["Pc_Timer"].ToString());
                }
                Pc_ViewUser=ds.Tables[0].Rows[0]["Pc_Name"].ToString();
                Pc_NotUser=ds.Tables[0].Rows[0]["Pc_Name"].ToString();
                Pc_accUser=ds.Tables[0].Rows[0]["Pc_Name"].ToString();
                Pc_JsSp=ds.Tables[0].Rows[0]["Pc_Name"].ToString();

                if (ds.Tables[0].Rows[0]["Pc_JsStime"].ToString() != "")
                {
                    Pc_JsStime = DateTime.Parse(ds.Tables[0].Rows[0]["Pc_JsStime"].ToString());
                }
                Pc_SpUser=ds.Tables[0].Rows[0]["Pc_Name"].ToString();

                if (ds.Tables[0].Rows[0]["Pc_SpTimer"].ToString() != "")
                {
                    Pc_SpTimer = DateTime.Parse(ds.Tables[0].Rows[0]["Pc_SpTimer"].ToString());
                }
                Pc_mark = ds.Tables[0].Rows[0]["Pc_Name"].ToString(); 
                if (ds.Tables[0].Rows[0]["Pc_State"].ToString() != "")
                {
                    Pc_State = Int32.Parse(ds.Tables[0].Rows[0]["Pc_State"].ToString());
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
            strSql.Append("select count(1) from LCXManuPc");
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
            strSql.Append("insert into LCXManuPc(");
            strSql.Append("Pc_Dd,Pc_Name,Pc_Vesion,Pc_Wenjian,Pc_UserName,Pc_Timer,Pc_ViewUser,Pc_NotUser,Pc_accUser,Pc_JsSp,Pc_JsStime,Pc_SpUser,Pc_SpTimer,Pc_mark,Pc_State,Pc_Jsyj,Pc_Yj)");
            strSql.Append(" values (");
            strSql.Append("@Pc_Dd,@Pc_Name,@Pc_Vesion,@Pc_Wenjian,@Pc_UserName,@Pc_Timer,@Pc_ViewUser,@Pc_NotUser,@Pc_accUser,@Pc_JsSp,@Pc_JsStime,@Pc_SpUser,@Pc_SpTimer,@Pc_mark,@Pc_State,@Pc_Jsyj,@Pc_Yj)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {  
                    new SqlParameter("@Pc_Dd", SqlDbType.Int,4),
					new SqlParameter("@Pc_Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Pc_Vesion", SqlDbType.NVarChar,100),
					new SqlParameter("@Pc_Wenjian", SqlDbType.NVarChar,200),
					new SqlParameter("@Pc_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Pc_Timer", SqlDbType.DateTime),
					new SqlParameter("@Pc_ViewUser", SqlDbType.NVarChar,500),
					new SqlParameter("@Pc_NotUser", SqlDbType.NVarChar,500),
                    new SqlParameter("@Pc_accUser", SqlDbType.NVarChar,200),
					new SqlParameter("@Pc_JsSp", SqlDbType.NVarChar,50),
                    new SqlParameter("@Pc_JsStime", SqlDbType.DateTime),
                    new SqlParameter("@Pc_SpUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@Pc_SpTimer", SqlDbType.DateTime),
                    new SqlParameter("@Pc_mark", SqlDbType.NVarChar,200),
                    new SqlParameter("@Pc_State", SqlDbType.Int,4),
                    new SqlParameter("@Pc_Jsyj", SqlDbType.NVarChar,500),
                    new SqlParameter("@Pc_Yj", SqlDbType.NVarChar,500)
            }; 

            parameters[0].Value = Pc_Dd;
            parameters[1].Value = Pc_Name;
            parameters[2].Value = Pc_Vesion;
            parameters[3].Value = Pc_Wenjian;
            parameters[4].Value = Pc_UserName; 
            if (Pc_Timer == Convert.ToDateTime(null))
            {
                parameters[5].Value = null;//Sc_SpTime;
            }
            else
            {
                parameters[5].Value = Pc_Timer;
            }
            parameters[6].Value = Pc_ViewUser;
            parameters[7].Value = Pc_NotUser;
            parameters[8].Value = Pc_accUser;
            parameters[9].Value = Pc_JsSp;
            if (Pc_JsStime == Convert.ToDateTime(null))
            {
                parameters[10].Value = null;//Sc_SpTime;
            }
            else
            {
                parameters[10].Value = Pc_JsStime;
            } 
            parameters[11].Value = Pc_SpUser; 
            if (Pc_SpTimer == Convert.ToDateTime(null))
            {
                parameters[12].Value = null;//Sc_SpTime;
            }
            else
            {
                parameters[12].Value = Pc_SpTimer;
            }
            parameters[13].Value = Pc_mark;
            parameters[14].Value = Pc_State;
            parameters[15].Value = Pc_Jsyj;
            parameters[16].Value = Pc_Yj; 
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
            strSql.Append("update LCXManuPc set "); 
            strSql.Append("Pc_Dd=@Pc_Dd,");
            strSql.Append("Pc_Name=@Pc_Name,");
            strSql.Append("Pc_Vesion=@Pc_Vesion,");
            strSql.Append("Pc_Wenjian=@Pc_Wenjian,");
            strSql.Append("Pc_UserName=@Pc_UserName,");
            strSql.Append("Pc_Timer=@Pc_Timer,");
            strSql.Append("Pc_ViewUser=@Pc_ViewUser,");
            strSql.Append("Pc_NotUser=@Pc_NotUser,");
            strSql.Append("Pc_accUser=@Pc_accUser,");
            strSql.Append("Pc_JsSp=@Pc_JsSp,");
            strSql.Append("Pc_JsStime=@Pc_JsStime,");
            strSql.Append("Pc_SpUser=@Pc_SpUser,");
            strSql.Append("Pc_SpTimer=@Pc_SpTimer,");
            strSql.Append("Pc_mark=@Pc_mark,");
            strSql.Append("Pc_State=@Pc_State,");
            strSql.Append("Pc_Jsyj=@Pc_Jsyj,");
            strSql.Append("Pc_Yj=@Pc_Yj");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@Pc_Dd", SqlDbType.Int,4),
					new SqlParameter("@Pc_Name", SqlDbType.NVarChar,100),
					new SqlParameter("@Pc_Vesion", SqlDbType.NVarChar,100),
					new SqlParameter("@Pc_Wenjian", SqlDbType.NVarChar,200),
					new SqlParameter("@Pc_UserName", SqlDbType.NVarChar,50),
					new SqlParameter("@Pc_Timer", SqlDbType.DateTime),
					new SqlParameter("@Pc_ViewUser", SqlDbType.NVarChar,500),
					new SqlParameter("@Pc_NotUser", SqlDbType.NVarChar,500),
                    new SqlParameter("@Pc_accUser", SqlDbType.NVarChar,200),
					new SqlParameter("@Pc_JsSp", SqlDbType.NVarChar,50),
                    new SqlParameter("@Pc_JsStime", SqlDbType.DateTime),
                    new SqlParameter("@Pc_SpUser", SqlDbType.NVarChar,50),
                    new SqlParameter("@Pc_SpTimer", SqlDbType.DateTime),
                    new SqlParameter("@Pc_mark", SqlDbType.NVarChar,200),
                    new SqlParameter("@Pc_State", SqlDbType.Int,4),
                    new SqlParameter("@Pc_Jsyj", SqlDbType.NVarChar,500),
                    new SqlParameter("@Pc_Yj", SqlDbType.NVarChar,500)
            };
            parameters[0].Value = ID;
            parameters[1].Value = Pc_Dd;
            parameters[2].Value = Pc_Name;
            parameters[3].Value = Pc_Vesion;
            parameters[4].Value = Pc_Wenjian;
            parameters[5].Value = Pc_UserName;
            if (Pc_Timer == Convert.ToDateTime(null))
            {
                parameters[6].Value = null;//Sc_SpTime;
            }
            else
            {
                parameters[6].Value = Pc_Timer;
            }
            parameters[7].Value = Pc_ViewUser;
            parameters[8].Value = Pc_NotUser;
            parameters[9].Value = Pc_accUser;
            parameters[10].Value = Pc_JsSp;
            if (Pc_JsStime == Convert.ToDateTime(null))
            {
                parameters[11].Value = null;//Sc_SpTime;
            }
            else
            {
                parameters[11].Value = Pc_JsStime;
            }
            parameters[12].Value = Pc_SpUser;
            if (Pc_SpTimer == Convert.ToDateTime(null))
            {
                parameters[13].Value = null;//Sc_SpTime;
            }
            else
            {
                parameters[13].Value = Pc_SpTimer;
            }
            parameters[14].Value = Pc_mark;
            parameters[15].Value = Pc_State;
            parameters[16].Value = Pc_Jsyj;
            parameters[17].Value = Pc_Yj; 
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="idstr"></param>
        public int Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete LCXManuPc ");
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
            strSql.Append("select ID,Pc_Dd,Pc_Name,Pc_Vesion,Pc_Wenjian,Pc_UserName,Pc_Timer,Pc_ViewUser,Pc_NotUser,Pc_accUser,Pc_JsSp,Pc_JsStime,Pc_SpUser,Pc_SpTimer,Pc_mark,Pc_State,Pc_Jsyj,Pc_Yj ");
            strSql.Append(" FROM LCXManuPc ");
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
                if (ds.Tables[0].Rows[0]["Pc_Dd"].ToString() != "")
                {
                    Pc_Dd = Int32.Parse(ds.Tables[0].Rows[0]["Pc_Dd"].ToString());
                }
                Pc_Name = ds.Tables[0].Rows[0]["Pc_Name"].ToString();
                Pc_Vesion = ds.Tables[0].Rows[0]["Pc_Vesion"].ToString();
                Pc_Wenjian = ds.Tables[0].Rows[0]["Pc_Wenjian"].ToString();
                Pc_UserName = ds.Tables[0].Rows[0]["Pc_UserName"].ToString();
                if (ds.Tables[0].Rows[0]["Pc_Timer"].ToString() != "")
                {
                    Pc_Timer = DateTime.Parse(ds.Tables[0].Rows[0]["Pc_Timer"].ToString());
                }
                Pc_ViewUser = ds.Tables[0].Rows[0]["Pc_ViewUser"].ToString();
                Pc_NotUser = ds.Tables[0].Rows[0]["Pc_NotUser"].ToString();
                Pc_accUser = ds.Tables[0].Rows[0]["Pc_accUser"].ToString();
                Pc_JsSp = ds.Tables[0].Rows[0]["Pc_JsSp"].ToString();

                if (ds.Tables[0].Rows[0]["Pc_JsStime"].ToString() != "")
                {
                    Pc_JsStime = DateTime.Parse(ds.Tables[0].Rows[0]["Pc_JsStime"].ToString());
                }
                Pc_SpUser = ds.Tables[0].Rows[0]["Pc_SpUser"].ToString();

                if (ds.Tables[0].Rows[0]["Pc_SpTimer"].ToString() != "")
                {
                    Pc_SpTimer = DateTime.Parse(ds.Tables[0].Rows[0]["Pc_SpTimer"].ToString());
                }
                Pc_mark = ds.Tables[0].Rows[0]["Pc_mark"].ToString();
                if (ds.Tables[0].Rows[0]["Pc_State"].ToString() != "")
                {
                    Pc_State = Int32.Parse(ds.Tables[0].Rows[0]["Pc_State"].ToString());
                }
                Pc_Jsyj = ds.Tables[0].Rows[0]["Pc_Jsyj"].ToString();
                Pc_Yj = ds.Tables[0].Rows[0]["Pc_Yj"].ToString();
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
            strSql.Append("select [ID],[Pc_Dd],[Pc_Name],[Pc_Vesion],[Pc_Wenjian],[Pc_UserName],[Pc_Timer],[Pc_ViewUser],[Pc_NotUser],[Pc_accUser],[Pc_JsSp],[Pc_JsStime],[Pc_SpUser],[Pc_SpTimer],[Pc_mark],[Pc_State],[Pc_Jsyj],[Pc_Yj]");
            strSql.Append(" FROM LCXManuPc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        public string GetVersion(int Pc_Ddstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top (1)  [Pc_Vesion] ");
            strSql.Append(" FROM LCXManuPc WHERE [Pc_State]=4 and [Pc_Dd]=" + Pc_Ddstr + " order by ID desc"); 
            return DbHelperSQL.GetSHSLInt(strSql.ToString()); 
        }
    }
}
