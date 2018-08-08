using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    /// <summary>
    /// 出访信息
    /// </summary>
    public class LCXOutreach
    {
        public LCXOutreach()
        { }
        #region Model
        private int _id;
        private string _outvisitunitid;
        private string _outvisitgroupid;
        private string _visitpurpose;
        private DateTime _visittime;
        private string _workreport;
        private string _workprogress;
        private string _attchment;
        ///<summary>
        ///出访ID
        ///</summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        ///<summary>
        ///出访目的单位
        /// </summary>
        public string OutVisitUnitID
        {
            set { _outvisitunitid = value; }
            get { return _outvisitunitid; }
        }
        ///<summary>
        ///出访单位
        /// </summary>
        public string OutVisitGroupID
        {
            set { _outvisitgroupid = value; }
            get { return _outvisitgroupid; }
        }
        ///<summary>
        ///出访目的
        ///</summary>
        public string VisitPurpose
        {
            set { _visitpurpose = value; }
            get { return _visitpurpose; }
        }
        ///<summary>
        ///出访时间
        /// </summary>
        public DateTime VisitTime
        {
            set { _visittime = value; }
            get { return _visittime; }
        }
        ///<summary>
        ///合作报告
        /// </summary>
        public string WorkReport
        {
            set { _workreport = value; }
            get { return _workreport; }
        }
        ///<summary>
        ///工作进度
        /// </summary>
        public string WorkProgress
        {
            set { _workprogress = value; }
            get { return _workprogress; }
        }
        ///<summary>
        ///附件
        /// </summary>
        public string Attchment
        {
            set { _attchment = value; }
            get { return _attchment; }
        }

        public string FuJianStr { get; set; }
        public string UserName { get; set; }
        #endregion Model

        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXOutreach(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,OutVisitUnit,OutVisitGroup,VisitPurpose,VisitTime,WorkReport,WorkProgress,Attchment");
            strSql.Append(" FROM LCXOutreach ");
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
                // UnitID = ds.Tables[0].Rows[0]["UnitID"].ToString();
                OutVisitUnitID = ds.Tables[0].Rows[0]["OutVisitUnit"].ToString();
                OutVisitGroupID = ds.Tables[0].Rows[0]["OutVisitGroup"].ToString();
                VisitPurpose = ds.Tables[0].Rows[0]["VisitPurpose"].ToString();
                if (ds.Tables[0].Rows[0]["VisitTime"].ToString() != "")
                {
                    VisitTime = DateTime.Parse(ds.Tables[0].Rows[0]["VisitTime"].ToString());
                }
                WorkReport = ds.Tables[0].Rows[0]["WorkReport"].ToString();
                WorkProgress = ds.Tables[0].Rows[0]["WorkProgress"].ToString();
                Attchment = ds.Tables[0].Rows[0]["Attchment"].ToString();
            }
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {

            return DbHelperSQL.GetMaxID("ID", "LCXOutreach");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXOutreach");
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
            strSql.Append("insert into LCXOutreach(");
            strSql.Append("OutVisitUnit,OutVisitGroup,VisitPurpose,VisitTime,WorkReport,WorkProgress,Attchment)");
            strSql.Append(" values (");
            strSql.Append("@OutVisitUnit,@OutVisitGroup,@VisitPurpose,@VisitTime,@WorkReport,@WorkProgress,@Attchment)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OutVisitUnit", SqlDbType.VarChar,50),
                    new SqlParameter("@OutVisitGroup", SqlDbType.VarChar,50),
                    new SqlParameter("@VisitPurpose", SqlDbType.VarChar,50),
                    new SqlParameter("@VisitTime", SqlDbType.DateTime),
                    new SqlParameter("@WorkReport", SqlDbType.Text),
                    new SqlParameter("@WorkProgress", SqlDbType.VarChar,500),
                // new SqlParameter("@Attchment", SqlDbType.VarChar,500)
            };
            parameters[0].Value = OutVisitUnitID;
            parameters[1].Value = OutVisitGroupID;
            parameters[2].Value = VisitPurpose;
            parameters[3].Value = VisitTime;
            parameters[4].Value = WorkReport;
            parameters[5].Value = WorkProgress;
            //parameters[6].Value = Attchment;


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
            strSql.Append("update LCXOutreach set ");            
            strSql.Append("OutVisitUnit=@OutVisitUnit,");
            strSql.Append("OutVisitGroup=@OutVisitGroup,");
            strSql.Append("VisitPurpose=@VisitPurpose,");
            strSql.Append("VisitTime=@VisitTime,");
            strSql.Append("WorkReport=@WorkReport,");
            strSql.Append("WorkProgress=@WorkProgress,");
            strSql.Append("Attchment=@Attchment,");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@OutVisitUnit", SqlDbType.VarChar,50),
                    new SqlParameter("@OutVisitGroup", SqlDbType.VarChar,50),                   
                    new SqlParameter("@VisitPurpose", SqlDbType.VarChar,50),
                    new SqlParameter("@VisitTime", SqlDbType.DateTime),
                    new SqlParameter("@WorkReport", SqlDbType.VarChar,8000),
                    new SqlParameter("@WorkProgress", SqlDbType.VarChar,50),
                    new SqlParameter("@Attchment", SqlDbType.VarChar,5000)
                    };
            parameters[0].Value = ID;
            parameters[1].Value = OutVisitUnitID;
            parameters[2].Value = OutVisitGroupID;
            parameters[3].Value = VisitPurpose;
            parameters[4].Value = VisitTime;
            parameters[5].Value = WorkReport;
            parameters[6].Value = WorkProgress;
            parameters[7].Value = Attchment;
            

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXOutreach ");
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
            strSql.Append("select  top 1 ID,OutVisitUnit,OutVisitGroup,VisitPurpose,VisitTime,WorkReport,WorkProgress,Attchment");
            strSql.Append(" FROM LCXOutreach ");
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
                OutVisitUnitID =ds.Tables[0].Rows[0]["OutVisitUnit"].ToString();
                OutVisitGroupID = ds.Tables[0].Rows[0]["OutVisitGroup"].ToString();
                VisitPurpose = ds.Tables[0].Rows[0]["VisitPurpose"].ToString();
                if (ds.Tables[0].Rows[0]["VisitTime"].ToString() != "")
                {
                    VisitTime = DateTime.Parse(ds.Tables[0].Rows[0]["VisitTime"].ToString());
                }
                WorkReport = ds.Tables[0].Rows[0]["WorkReport"].ToString();
                WorkProgress = ds.Tables[0].Rows[0]["WorkProgress"].ToString();
               // Attchment = ds.Tables[0].Rows[0]["Attchment"].ToString();

            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LCXOutreach ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
