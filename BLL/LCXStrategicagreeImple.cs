using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    public class LCXStrategicagreeImple
    {
        public LCXStrategicagreeImple()
        { }
        #region  Model
        private int _id;
        private string _strategicagreeName;//合同名称
        private string _phaseName;//阶段名称
        private DateTime _startTime; //开始时间
        private DateTime _endTime;//结束时间
        private string _completionDegree;//完成度
        private string _chargePerson;//主持人
        private string _submitPerson;//提交人
        private DateTime _submitTime;//提交人
        private string _remarks;//备注
        private string _attachment;//附件


        ///<summary>
        ///ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        ///<summary>
        ///合同名称
        ///</summary>
        public string StrategicagreeName
        {
            set { _strategicagreeName = value; }
            get { return _strategicagreeName; }
        }
        ///<summary>
        ///阶段名称
        ///</summary>
        public string PhaseName
        {
            set { _phaseName = value; }
            get { return _phaseName; }
        }
        ///<summary>
        ///开始时间
        ///</summary>
        public DateTime StartTime
        {
            set { _startTime = value; }
            get { return _startTime; }
        }
        ///<summary>
        ///结束时间
        ///</summary>
        public DateTime EndTime
        {
            set { _endTime = value; }
            get { return _endTime; }
        }
        ///<summary>
        ///完成度
        ///</summary>
        public string CompletionDegree
        {
            set { _completionDegree = value; }
            get { return _completionDegree; }
        }
        ///<summary>
        ///主持人
        ///</summary>
        public string ChargePerson
        {
            set { _chargePerson = value; }
            get { return _chargePerson; }
        }
        ///<summary>
        ///提交人
        ///</summary>
        public string SubmitPerson
        {
            set { _submitPerson = value; }
            get { return _submitPerson; }
        }
        ///<summary>
        ///提交时间
        ///</summary>
        public DateTime SubmitTime
        {
            set { _submitTime = value; }
            get { return _submitTime; }
        }
        ///<summary>
        ///备注
        ///</summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        ///<summary>
        ///附件
        ///</summary>
        public string Attachment
        {
            set { _attachment = value; }
            get { return _attachment; }
        }
        #endregion
        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXStrategicagreeImple(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,StrategicagreeName,PhaseName,StartTime,EndTime,CompletionDegree,ChargePerson,SubmitPerson,SubmitTime,Remarks,Attachment");
            strSql.Append(" FROM LCXStrategicagreeImple ");
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
                StrategicagreeName = ds.Tables[0].Rows[0]["StrategicagreeName"].ToString();
                PhaseName = ds.Tables[0].Rows[0]["PhaseName"].ToString();
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }

                CompletionDegree = ds.Tables[0].Rows[0]["CompletionDegree"].ToString();
                ChargePerson = ds.Tables[0].Rows[0]["ChargePerson"].ToString();
                SubmitPerson = ds.Tables[0].Rows[0]["SubmitPerson"].ToString();
                if (ds.Tables[0].Rows[0]["SubmitTime"].ToString() != "")
                {
                    SubmitTime = DateTime.Parse(ds.Tables[0].Rows[0]["SubmitTime"].ToString());
                }
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                Attachment = ds.Tables[0].Rows[0]["Attachment"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXStrategicagreeImple");
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
            strSql.Append("insert into LCXStrategicagreeImple(");
            strSql.Append("StrategicagreeName,PhaseName,StartTime,EndTime,CompletionDegree,ChargePerson,SubmitPerson,SubmitTime,Remarks,Attachment)");
            strSql.Append(" values (");
            strSql.Append("@StrategicagreeName,@PhaseName,@StartTime,@EndTime,@CompletionDegree,@ChargePerson,@SubmitPerson,@SubmitTime,@Remarks,@Attachment)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@StrategicagreeName", SqlDbType.VarChar,50),
                    new SqlParameter("@PhaseName", SqlDbType.VarChar,50),
                    new SqlParameter("@StartTime", SqlDbType.DateTime,50),
                    new SqlParameter("@EndTime", SqlDbType.DateTime,50),
                    new SqlParameter("@CompletionDegree", SqlDbType.VarChar,50),
                    new SqlParameter("@ChargePerson", SqlDbType.VarChar,50),
                    new SqlParameter("@SubmitPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@SubmitTime", SqlDbType.DateTime,50),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,500),
                    new SqlParameter("@Attachment", SqlDbType.VarChar,50)

                    };
            parameters[0].Value = StrategicagreeName;
            parameters[1].Value = PhaseName;
            parameters[2].Value = StartTime;
            parameters[3].Value = EndTime;
            parameters[4].Value = CompletionDegree;
            parameters[5].Value = ChargePerson;
            parameters[6].Value = SubmitPerson;
            parameters[7].Value = SubmitTime;
            parameters[8].Value = Remarks;
            parameters[9].Value = Attachment;


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
            strSql.Append("update LCXStrategicagreeImple set ");
            strSql.Append("StrategicagreeName=@StrategicagreeName,");
            strSql.Append("PhaseName=@PhaseName,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("CompletionDegree=@CompletionDegree,");
            strSql.Append("ChargePerson=@ChargePerson,");
            strSql.Append("SubmitPerson=@SubmitPerson,");
            strSql.Append("SubmitTime=@SubmitTime,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("Attachment=@Attachment ");

            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@StrategicagreeName", SqlDbType.VarChar,50),
                    new SqlParameter("@PhaseName", SqlDbType.VarChar,50),
                    new SqlParameter("@StartTime", SqlDbType.DateTime,50),
                    new SqlParameter("@EndTime", SqlDbType.DateTime,50),
                    new SqlParameter("@CompletionDegree", SqlDbType.VarChar,50),
                    new SqlParameter("@ChargePerson", SqlDbType.VarChar,50),
                    new SqlParameter("@SubmitPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@SubmitTime", SqlDbType.DateTime,50),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,500),
                    new SqlParameter("@Attachment", SqlDbType.VarChar,100)

                    };
            parameters[0].Value = ID;
            parameters[1].Value = StrategicagreeName;
            parameters[2].Value = PhaseName;
            parameters[3].Value = StartTime;
            parameters[4].Value = EndTime;
            parameters[5].Value = CompletionDegree;
            parameters[6].Value = ChargePerson;
            parameters[7].Value = SubmitPerson;
            parameters[8].Value = SubmitTime;
            parameters[9].Value = Remarks;
            parameters[10].Value = Attachment;


            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXStrategicagreeImple ");
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
            strSql.Append("select  top 1 ID,StrategicagreeName,PhaseName,StartTime,EndTime,CompletionDegree,ChargePerson,SubmitPerson,SubmitTime,Remarks,Attachment");
            strSql.Append(" FROM LCXStrategicagreeImple ");
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
                StrategicagreeName = ds.Tables[0].Rows[0]["StrategicagreeName"].ToString();
                PhaseName = ds.Tables[0].Rows[0]["PhaseName"].ToString();
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                CompletionDegree = ds.Tables[0].Rows[0]["CompletionDegree"].ToString();
                ChargePerson = ds.Tables[0].Rows[0]["ChargePerson"].ToString();
                SubmitPerson = ds.Tables[0].Rows[0]["SubmitPerson"].ToString();
                if (ds.Tables[0].Rows[0]["SubmitTime"].ToString() != "")
                {
                    SubmitTime = DateTime.Parse(ds.Tables[0].Rows[0]["SubmitTime"].ToString());
                }
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                Attachment = ds.Tables[0].Rows[0]["Attachment"].ToString();
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LCXStrategicagreeImple ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
