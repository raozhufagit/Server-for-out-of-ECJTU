using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    public class LCXScientificResearch
    {
        public LCXScientificResearch()
        { }
        #region   Model
        private int _id;
        private string _scientificName;//研究名称
        private string _scientificNo;//科研编号
        private string _scientificType;//科研类型
        private string _hostPerson;//主持人
        private string _participants;//参与人
        private string _scientficDir;//科研方向
        private string _researchFind;//研究成果
        private string _applicationDir;//科研应用
        private string _remarks;//备注
        private string _scientificStates;//科研状态
        private int _states;//审核状态
        private string _attachment;//附件
        private DateTime _startTime;//开始时间
        private DateTime _endTime;//结束时间
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        public string ScientificName
        {
            set { _scientificName = value; }
            get { return _scientificName; }
        }
        public string ScientificNo
        {
            set { _scientificNo = value; }
            get { return _scientificNo; }
        }
        public string ScientificType
        {
            set { _scientificType = value; }
            get { return _scientificType; }
        }
        public string HostPerson
        {
            set { _hostPerson = value; }
            get { return _hostPerson; }
        }
        public string Participants
        {
            set { _participants = value; }
            get { return _participants; }
        }
        public string ScientificDir
        {
            set { _scientficDir = value; }
            get { return _scientficDir; }
        }
        public string ResearchFind
        {
            set { _researchFind = value; }
            get { return _researchFind; }
        }
        public string ApplicationDir
        {
            set { _applicationDir = value; }
            get { return _applicationDir; }
        }
        public string ScientificStates
        {
            set { _scientificStates = value; }
            get { return _scientificStates; }
        }
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        public int States
        {
            set { _states = value; }
            get { return _states; }
        }
        public string Attachment
        {
            set { _attachment = value; }
            get { return _attachment; }
        }
        public DateTime StartTime
        {
            set { _startTime = value; }
            get { return _startTime; }
        }
        public DateTime EndTime
        {
            set { _endTime = value; }
            get { return _endTime; }
        }
        #endregion Model
        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXScientificResearch(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ScientificName,ScientificNo,ScientificType,HostPerson,Participants,ScientificDir,ScientificStates,ResearchFind,ApplicationDir,Remarks,States,Attachment,StartTime,EndTime");
            strSql.Append(" FROM LCXScientificResearch ");
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
                ScientificName = ds.Tables[0].Rows[0]["ScientificName"].ToString();
                ScientificNo = ds.Tables[0].Rows[0]["ScientificNo"].ToString();
                ScientificType = ds.Tables[0].Rows[0]["ScientificType"].ToString();
                HostPerson = ds.Tables[0].Rows[0]["HostPerson"].ToString();
                Participants = ds.Tables[0].Rows[0]["Participants"].ToString();
                ScientificDir = ds.Tables[0].Rows[0]["ScientificDir"].ToString();
                ScientificStates = ds.Tables[0].Rows[0]["ScientificStates"].ToString();
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                if (ds.Tables[0].Rows[0]["States"].ToString() != "")
                {
                    States = int.Parse(ds.Tables[0].Rows[0]["States"].ToString());
                }
                Attachment = ds.Tables[0].Rows[0]["Attachment"].ToString();
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }

            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXScientificResearch");
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
            strSql.Append("insert into LCXScientificResearch(");
            strSql.Append("ScientificName,ScientificNo,ScientificType,HostPerson,Participants,ScientificDir,ScientificStates,ResearchFind,ApplicationDir,Remarks,States,Attachment,StartTime,EndTime)");
            strSql.Append(" values (");
            strSql.Append("@ScientificName,@ScientificNo,@ScientificType,@HostPerson,@Participants,@ScientificDir,@ScientificStates,@ResearchFind,@ApplicationDir,@Remarks,@States,@Attachment,@StartTime,@EndTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ScientificName", SqlDbType.VarChar,100),
                    new SqlParameter("@ScientificNo", SqlDbType.VarChar,50),
                    new SqlParameter("@ScientificType", SqlDbType.VarChar,50),
                    new SqlParameter("@HostPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@Participants", SqlDbType.VarChar,100),
                    new SqlParameter("@ScientificDir", SqlDbType.VarChar,100),
                    new SqlParameter("@ScientificStates", SqlDbType.VarChar,20),
                    new SqlParameter("@ResearchFind", SqlDbType.VarChar,2000),
                    new SqlParameter("@ApplicationDir", SqlDbType.VarChar,500),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,1000),
                    new SqlParameter("@States", SqlDbType.Int,4),
                    new SqlParameter("@Attachment", SqlDbType.VarChar,200),
                    new SqlParameter("@StartTime",SqlDbType.DateTime,50),
                    new SqlParameter("@EndTime",SqlDbType.DateTime,50)
                    };
            parameters[0].Value = ScientificName;
            parameters[1].Value = ScientificNo;
            parameters[2].Value = ScientificType;
            parameters[3].Value = HostPerson;
            parameters[4].Value = Participants;
            parameters[5].Value = ScientificDir;
            parameters[6].Value = ScientificStates;
            parameters[7].Value = ResearchFind;
            parameters[8].Value = ApplicationDir;
            parameters[9].Value = Remarks;
            parameters[10].Value = States;
            parameters[11].Value = Attachment;
            parameters[12].Value = StartTime;
            parameters[13].Value = EndTime;

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
        public int Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LCXScientificResearch set ");
            strSql.Append("ScientificName=@ScientificName,");
            strSql.Append("ScientificNo=@ScientificNo,");
            strSql.Append("ScientificType=@ScientificType,");
            strSql.Append("HostPerson=@HostPerson,");
            strSql.Append("Participants=@Participants,");
            strSql.Append("ScientificDir=@ScientificDir,");
            strSql.Append("ResearchFind=@ResearchFind,");
            strSql.Append("ScientificStates=@ScientificStates,");
            strSql.Append("ApplicationDir=@ApplicationDir,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("States=@States,");
            strSql.Append("Attachment=@Attachment,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@ScientificName", SqlDbType.VarChar,100),
                    new SqlParameter("@ScientificNo", SqlDbType.VarChar,50),
                    new SqlParameter("@ScientificType", SqlDbType.VarChar,50),
                    new SqlParameter("@HostPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@Participants", SqlDbType.VarChar,100),
                    new SqlParameter("@ScientificDir", SqlDbType.VarChar,100),
                    new SqlParameter("@ScientificStates", SqlDbType.VarChar,20),
                    new SqlParameter("@ResearchFind", SqlDbType.VarChar,2000),
                    new SqlParameter("@ApplicationDir", SqlDbType.VarChar,500),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,1000),
                    new SqlParameter("@States", SqlDbType.Int,4),
                    new SqlParameter("@Attachment", SqlDbType.VarChar,200),
                    new SqlParameter("@StartTime",SqlDbType.DateTime,50),
                    new SqlParameter("@EndTime",SqlDbType.DateTime,50)
                    };
            parameters[0].Value = ID;
            parameters[1].Value = ScientificName;
            parameters[2].Value = ScientificNo;
            parameters[3].Value = ScientificType;
            parameters[4].Value = HostPerson;
            parameters[5].Value = Participants;
            parameters[6].Value = ScientificDir;
            parameters[7].Value = ScientificStates;
            parameters[8].Value = ResearchFind;
            parameters[9].Value = ApplicationDir;
            parameters[10].Value = Remarks;
            parameters[11].Value = States;
            parameters[12].Value = Attachment;
            parameters[13].Value = StartTime;
            parameters[14].Value = EndTime;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXScientificResearch ");
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
            strSql.Append("select  top 1 ID,ScientificName,ScientificNo,ScientificType,HostPerson,Participants,ScientificDir,ScientificStates,ResearchFind,ApplicationDir,Remarks,States,Attachment,StartTime,EndTime");
            strSql.Append(" FROM LCXScientificResearch ");
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
                ScientificName = ds.Tables[0].Rows[0]["ScientificName"].ToString();
                ScientificNo = ds.Tables[0].Rows[0]["ScientificNo"].ToString();
                ScientificType = ds.Tables[0].Rows[0]["ScientificType"].ToString();
                HostPerson = ds.Tables[0].Rows[0]["HostPerson"].ToString();
                Participants = ds.Tables[0].Rows[0]["Participants"].ToString();
                ScientificDir = ds.Tables[0].Rows[0]["ScientificDir"].ToString();
                ScientificStates = ds.Tables[0].Rows[0]["ScientificStates"].ToString();
                ResearchFind = ds.Tables[0].Rows[0]["ResearchFind"].ToString();
                ApplicationDir= ds.Tables[0].Rows[0]["ApplicationDir"].ToString();
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                if (ds.Tables[0].Rows[0]["States"].ToString() != "")
                {
                    States = int.Parse(ds.Tables[0].Rows[0]["States"].ToString());
                }
                Attachment = ds.Tables[0].Rows[0]["Attachment"].ToString();
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LCXScientificResearch  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
