using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    /// <summary>
    /// 类LCXVisitingManagement
    /// </summary>
    public class LCXVisitingManagement
    {
        public LCXVisitingManagement()
        {}
        #region Model
        private int _id;
        private string _invisitgroup;
        private string _invisitunit;
        private string _visitpurpose;
        private string _receptionist;
        private DateTime _visittime;
        private string _workreport;
        private string _workprogress;
        private string _attchment;
        private string _visitingtitle;//外出标题
        ///<summary>
        ///
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 校内单位
        /// </summary>
        public string InVisitGroup
        {
            set { _invisitgroup = value; }
            get { return _invisitgroup; }
        }
        /// <summary>
        /// 来访单位
        /// </summary>
        public string InVisitUnit
        {
            set { _invisitunit = value; }
            get { return _invisitunit; }
        }
        /// <summary>
        /// 来访目的
        /// </summary>
        public string VisitPurpose
        {
            set { _visitpurpose = value; }
            get { return _visitpurpose; }
        }
        /// <summary>
        /// 接待人员
        /// </summary>
        public string Receptionist
        {
            set { _receptionist = value; }
            get { return _receptionist; }
        }
        /// <summary>
        /// 来访时间
        /// </summary>
        public DateTime VisitTime
        {
            set { _visittime = value; }
            get { return _visittime; }
        }
        /// <summary>
        /// 工作报告
        /// </summary>
        public string WorkReport
        {
            set { _workreport = value; }
            get { return _workreport; }
        }
        /// <summary>
        /// 图书名称
        /// </summary>
        public string WorkProgress
        {
            set { _workprogress = value; }
            get { return _workprogress; }
        }
        /// <summary>
        ///附件
        /// </summary>
        public string Attchment
        {
            set { _attchment = value; }
            get { return _attchment; }
        }
        ///<summary>
        ///外出主题
        /// </summary>
        public string VisitingTitle
        {
            set { _visitingtitle = value; }
            get { return _visitingtitle; }
        }
        #endregion Model


        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXVisitingManagement(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,InVisitGroup,InVisitUnit,VisitPurpose,Receptionist,VisitTime,WorkReport,WorkProgress,Attchment,VisitingTitle ");
            strSql.Append(" FROM LCXVisitingManagement ");
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
                InVisitGroup = ds.Tables[0].Rows[0]["InVisitGroup"].ToString();
                InVisitUnit = ds.Tables[0].Rows[0]["BookSerils"].ToString();
                VisitPurpose = ds.Tables[0].Rows[0]["VisitPurpose"].ToString();
                Receptionist = ds.Tables[0].Rows[0]["Receptionist"].ToString();
                if (ds.Tables[0].Rows[0]["VisitTime"].ToString() != "")
                {
                    VisitTime = DateTime.Parse(ds.Tables[0].Rows[0]["VisitTime"].ToString());
                }
                WorkReport = ds.Tables[0].Rows[0]["WorkReport"].ToString();
                WorkProgress = ds.Tables[0].Rows[0]["WorkProgress"].ToString();
                Attchment = ds.Tables[0].Rows[0]["Attchment"].ToString();
                VisitingTitle = ds.Tables[0].Rows[0]["VisitingTitle"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXVisitingManagement");
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
            strSql.Append("insert into LCXVisitingManagement(");
            strSql.Append("InVisitGroup,InVisitUnit,VisitPurpose,Receptionist,VisitTime,WorkReport,WorkProgress,Attchment,VisitingTitle)");
            strSql.Append(" values (");
            strSql.Append("@InVisitGroup,@InVisitUnit,@VisitPurpose,@Receptionist,@VisitTime,@WorkReport,@WorkProgress,@Attchment,@VisitingTitle)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@InVisitGroup", SqlDbType.VarChar,50),
                    new SqlParameter("@InVisitUnit", SqlDbType.VarChar,50),
                    new SqlParameter("@VisitPurpose", SqlDbType.VarChar,50),
                    new SqlParameter("@Receptionist", SqlDbType.VarChar,50),
                    new SqlParameter("@VisitTime", SqlDbType.DateTime,50),
                    new SqlParameter("@WorkReport", SqlDbType.VarChar,5000),
                    new SqlParameter("@WorkProgress", SqlDbType.VarChar,500),
                    new SqlParameter("@Attchment", SqlDbType.VarChar,500),
                    new SqlParameter("@VisitingTitle", SqlDbType.VarChar,100),
                    };
            parameters[0].Value = InVisitGroup;
            parameters[1].Value = InVisitUnit;
            parameters[2].Value = VisitPurpose;
            parameters[3].Value = Receptionist;
            parameters[4].Value = VisitTime;
            parameters[5].Value = WorkReport;
            parameters[6].Value = WorkProgress;
            parameters[7].Value = Attchment;
            parameters[8].Value = VisitingTitle;

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
            strSql.Append("update LCXVisitingManagement set ");
            strSql.Append("InVisitGroup=@InVisitGroup,");
            strSql.Append("InVisitUnit=@InVisitUnit,");
            strSql.Append("VisitPurpose=@VisitPurpose,");
            strSql.Append("Receptionist=@Receptionist,");
            strSql.Append("VisitTime=@VisitTime,");
            strSql.Append("WorkReport=@WorkReport,");
            strSql.Append("WorkProgress=@WorkProgress,");
            strSql.Append("Attchment=@Attchment,");
            strSql.Append("VisitingTitle=@VisitingTitle");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@InVisitGroup", SqlDbType.VarChar,100),
                    new SqlParameter("@InVisitUnit", SqlDbType.VarChar,100),
                    new SqlParameter("@VisitPurpose", SqlDbType.VarChar,50),
                    new SqlParameter("@Receptionist", SqlDbType.VarChar,50),
                    new SqlParameter("@VisitTime", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkReport", SqlDbType.VarChar,50),
                    new SqlParameter("@WorkProgress", SqlDbType.VarChar,50),
                    new SqlParameter("@Attchment", SqlDbType.VarChar,50),
                    new SqlParameter("@VisitingTitle", SqlDbType.VarChar,100),
                    };
            parameters[0].Value = ID;
            parameters[1].Value = InVisitGroup;
            parameters[2].Value = InVisitUnit;
            parameters[3].Value = VisitPurpose;
            parameters[4].Value = Receptionist;
            parameters[5].Value = VisitTime;
            parameters[6].Value = WorkReport;
            parameters[7].Value = WorkProgress;
            parameters[8].Value = Attchment;
            parameters[9].Value = VisitingTitle;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXVisitingManagement ");
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
            strSql.Append("select  top 1 ID,InVisitGroup,InVisitUnit,VisitPurpose,Receptionist,VisitTime,WorkReport,WorkProgress,Attchment,VisitingTitle");
            strSql.Append(" FROM LCXVisitingManagement ");
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
                InVisitGroup = ds.Tables[0].Rows[0]["InVisitGroup"].ToString();
                InVisitUnit = ds.Tables[0].Rows[0]["InVisitUnit"].ToString();
                VisitPurpose = ds.Tables[0].Rows[0]["VisitPurpose"].ToString();
                Receptionist = ds.Tables[0].Rows[0]["Receptionist"].ToString();
                if (ds.Tables[0].Rows[0]["VisitTime"].ToString() != "")
                {
                    VisitTime = DateTime.Parse(ds.Tables[0].Rows[0]["VisitTime"].ToString());
                }
                WorkReport = ds.Tables[0].Rows[0]["WorkReport"].ToString();
                WorkProgress = ds.Tables[0].Rows[0]["WorkProgress"].ToString();
                Attchment = ds.Tables[0].Rows[0]["Attchment"].ToString();
                VisitingTitle = ds.Tables[0].Rows[0]["VisitingTitle"].ToString();
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LCXVisitingManagement ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
