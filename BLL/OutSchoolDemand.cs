using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    /// <summary>
    /// OutVisit。
    /// </summary>
    public class OutSchoolDemand
    {
        public OutSchoolDemand()
        { }
        #region Model  ///区域模型  变量名看意思 不想打了(>...<)!!!
        private int _ID;
        private DateTime? _PubTime;
        private string _PubCompany;
        private string _PubPerson;
        private string _DemandType;
        private string _DemandName;
        private string _DemandDetail;
        private string _ContactPerson;
        private string _ContactTel;
        private string _ContactEmail;
        private string _Push;
        private string _CheckPerson;
        private string _CheckOpinion;
        private string _CompanyEvaluate;
        private string _CompanyEvaluateStar;
        private string _TeacherEvaluate;
        private string _TeacherEvaluateStar;
        private int _DemandState;
        private int _VisibleType;
        private string _Teacher;
        private string _PredictedFinishTime;
        private string _BackInfo;
        private string _Attachment;
        private string _PrE;
        /// <summary>
        /// 编号
        /// </summary>
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        /// <summary>
        /// 需求发布日期
        /// </summary>
        public DateTime? PubTime
        {
            set { _PubTime = value; }
            get { return _PubTime; }
        }

        /// <summary>
        /// 需求甲方公司
        /// </summary>
        public string PubCompany
        {
            set { _PubCompany = value; }
            get { return _PubCompany; }
        }

        /// <summary>
        /// 甲方消息发布人
        /// </summary>
        public string PubPerson
        {
            set { _PubPerson = value; }
            get { return _PubPerson; }
        }

        /// <summary>
        /// 需求类型 挂职岗位 、项目合作、人才聘请、技术求购、其他
        /// </summary>
        public string DemandType
        {
            set { _DemandType = value; }
            get { return _DemandType; }
        }

        /// <summary>
        /// 需求名=需求类型+具体需求名 例如：【项目合作】铁路无损检测
        /// </summary>
        public string DemandName
        {
            set { _DemandName = value; }
            get { return _DemandName; }
        }

        /// <summary>
        /// 需求具体信息，
        /// </summary>
        public string DemandDetail
        {
            set { _DemandDetail = value; }
            get { return _DemandDetail; }
        }

        /// <summary>
        /// 甲方联系人
        /// </summary>
        public string ContactPerson
        {
            set { _ContactPerson = value; }
            get { return _ContactPerson; }
        }

        /// <summary>
        /// 联系人的电话
        /// </summary>
        public string ContactTel
        {
            set { _ContactTel = value; }
            get { return _ContactTel; }
        }

        /// <summary>
        /// 联系人的邮箱
        /// </summary>
        public string ContactEmail
        {
            set { _ContactEmail = value; }
            get { return _ContactEmail; }
        }

        /// <summary>
        /// 此条需求要推送的学院和部门
        /// </summary>
        public string Push
        {
            set { _Push = value; }
            get { return _Push; }
        }

        /// <summary>
        /// 审批人
        /// </summary>
        public string CheckPerson
        {
            set { _CheckPerson = value; }
            get { return _CheckPerson; }
        }

        /// <summary>
        /// 评审人意见
        /// </summary>
        public string CheckOpinion
        {
            set { _CheckOpinion = value; }
            get { return _CheckOpinion; }
        }
        /// <summary>
        /// 公司对此次合作的评价
        /// </summary>
        public string CompanyEvaluate
        {
            set { _CompanyEvaluate = value; }
            get { return _CompanyEvaluate; }
        }

        /// <summary>
        /// 公司对此次合作的评价
        /// </summary>
        public string CompanyEvaluateStar
        {
            set { _CompanyEvaluateStar = value; }
            get { return _CompanyEvaluateStar; }
        }

        /// <summary>
        /// 老师对此次合作的评价
        /// </summary>
        public string TeacherEvaluate
        {
            set { _TeacherEvaluate = value; }
            get { return _TeacherEvaluate; }
        }

        /// <summary>
        /// 老师对此次合作的评价
        /// </summary>
        public string TeacherEvaluateStar
        {
            set { _TeacherEvaluateStar = value; }
            get { return _TeacherEvaluateStar; }
        }

        /// <summary>
        ///需求的具体状态，类似于进度
        /// </summary>
        public int DemandState
        {
            set { _DemandState = value; }
            get { return _DemandState; }
        }
        /// <summary>
        ///是否可见，，，有点多余了
        /// </summary>
        public int VisibleType
        {
            set { _VisibleType = value; }
            get { return _VisibleType; }
        }
        /// <summary>
        /// 老师对此次合作的评价
        /// </summary>
        public string Teacher
        {
            set { _Teacher = value; }
            get { return _Teacher; }
        }
        /// <summary>
        /// 老师对此次合作的评价
        /// </summary>
        public string PredictedFinishTime
        {
            set { _PredictedFinishTime = value; }
            get { return _PredictedFinishTime; }
        }
        /// <summary>
        /// 老师对此次合作的评价
        /// </summary>
        public string BackInfo
        {
            set { _BackInfo = value; }
            get { return _BackInfo; }
        }
        /// <summary>
        ///_Attachment
        /// </summary>
        public string Attachment
        {
            set { _Attachment = value; }
            get { return _Attachment; }
        }
        /// <summary>
        ///项目经费
        /// </summary>
        public string PrE
        {
            set { _PrE = value; }
            get { return _PrE; }
        }
        #endregion Model


        #region  成员方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OutSchoolDemand(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PubCompany,PubTime,PubPerson,DemandType,DemandName,DemandDetail,ContactPerson,ContactTel,ContactEmail,Push,CheckPerson,CheckOpinion,CompanyEvaluate,CompanyEvaluateStar,TeacherEvaluate,TeacherEvaluateStar,DemandState,VisibleType,Teacher,PredictedFinishTime,BackInfo,Attachment,PrE ");
            strSql.Append(" FROM Demend ");
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
                PubCompany = ds.Tables[0].Rows[0]["PubCompany"].ToString();
                if (ds.Tables[0].Rows[0]["PubTime"].ToString() != "")
                {
                    PubTime = DateTime.Parse(ds.Tables[0].Rows[0]["PubTime"].ToString());
                }
                PubPerson = ds.Tables[0].Rows[0]["PubPerson"].ToString();
                DemandType = ds.Tables[0].Rows[0]["DemandType"].ToString();
                DemandName = ds.Tables[0].Rows[0]["DemandName"].ToString();
                DemandDetail = ds.Tables[0].Rows[0]["DemandDetail"].ToString();
                ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                ContactTel = ds.Tables[0].Rows[0]["ContactTel"].ToString();
                ContactEmail = ds.Tables[0].Rows[0]["ContactEmail"].ToString();
                Push = ds.Tables[0].Rows[0]["Push"].ToString();
                CheckPerson = ds.Tables[0].Rows[0]["CheckPerson"].ToString();
                CheckOpinion = ds.Tables[0].Rows[0]["CheckOpinion"].ToString();
                CompanyEvaluate = ds.Tables[0].Rows[0]["CompanyEvaluate"].ToString();
                CompanyEvaluateStar = ds.Tables[0].Rows[0]["CompanyEvaluateStar"].ToString();
                TeacherEvaluate = ds.Tables[0].Rows[0]["TeacherEvaluate"].ToString();
                TeacherEvaluateStar = ds.Tables[0].Rows[0]["TeacherEvaluateStar"].ToString();
                if (ds.Tables[0].Rows[0]["DemandState"].ToString() != "")
                {
                    DemandState = int.Parse(ds.Tables[0].Rows[0]["DemandState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VisibleType"].ToString() != "")
                {
                    VisibleType = int.Parse(ds.Tables[0].Rows[0]["VisibleType"].ToString());
                }
                Teacher = ds.Tables[0].Rows[0]["Teacher"].ToString();
                PredictedFinishTime = ds.Tables[0].Rows[0]["PredictedFinishTime"].ToString();
                BackInfo = ds.Tables[0].Rows[0]["BackInfo"].ToString();
                Attachment = ds.Tables[0].Rows[0]["Attachment"].ToString();
                PrE = ds.Tables[0].Rows[0]["PrE"].ToString();
            }
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {

            return DbHelperSQL.GetMaxID("ID", "Demand");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Demand");
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
            strSql.Append("insert into Demand(");
            strSql.Append("PubCompany,PubTime,PubPerson,DemandType,DemandName,DemandDetail,ContactPerson,ContactTel,ContactEmail,Push,CheckPerson,CheckOpinion,CompanyEvaluate,CompanyEvaluateStar,TeacherEvaluate,TeacherEvaluateStar,DemandState,VisibleType,Teacher,PredictedFinishTime,BackInfo,Attachment,PrE )");
            strSql.Append(" values (");
            strSql.Append("@PubCompany,@PubTime,@PubPerson,@DemandType,@DemandName,@DemandDetail,@ContactPerson,@ContactTel,@ContactEmail,@Push,@CheckPerson,@CheckOpinion,@CompanyEvaluate,@CompanyEvaluateStar,@TeacherEvaluate,@TeacherEvaluateStar,@DemandState,@VisibleType,@Teacher,@PredictedFinishTime,@BackInfo,@Attachment,@PrE )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@PubCompany", SqlDbType.NVarChar,50),
                new SqlParameter("@PubTime", SqlDbType.DateTime),
                new SqlParameter("@PubPerson", SqlDbType.NVarChar,50),
                new SqlParameter("@DemandType", SqlDbType.NVarChar,50),
                new SqlParameter("@DemandName", SqlDbType.NVarChar,50),
                new SqlParameter("@DemandDetail", SqlDbType.NVarChar,50),
                new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
                new SqlParameter("@ContactTel", SqlDbType.NVarChar,50),
                new SqlParameter("@ContactEmail", SqlDbType.NVarChar,50),
                new SqlParameter("@Push", SqlDbType.NVarChar,50),
                new SqlParameter("@CheckPerson", SqlDbType.NVarChar,50),
                new SqlParameter("@CheckOpinion", SqlDbType.NVarChar,50),
                new SqlParameter("@CompanyEvaluate", SqlDbType.NVarChar,50),
                new SqlParameter("@CompanyEvaluateStar", SqlDbType.Int,4),
                new SqlParameter("@TeacherEvaluate", SqlDbType.NVarChar,50),
                new SqlParameter("@TeacherEvaluateStar", SqlDbType.Int,4),
                new SqlParameter("@DemandState", SqlDbType.Int,4),
                new SqlParameter("@VisibleType", SqlDbType.Int,4),
                new SqlParameter("@Teacher", SqlDbType.NVarChar,50),
                new SqlParameter("@PredictedFinishTime",SqlDbType.DateTime),
                new SqlParameter("@BackInfo", SqlDbType.NVarChar,50),
                new SqlParameter("@Attachment", SqlDbType.NVarChar,500),
                new SqlParameter("@PrE", SqlDbType.NVarChar,50)};
            parameters[0].Value = PubCompany;
            parameters[1].Value = PubTime;
            parameters[2].Value = PubPerson;
            parameters[3].Value = DemandType;
            parameters[4].Value = DemandName;
            parameters[5].Value = DemandDetail;
            parameters[6].Value = ContactPerson;
            parameters[7].Value = ContactTel;
            parameters[8].Value = ContactEmail;
            parameters[9].Value = Push;
            parameters[10].Value = CheckPerson;
            parameters[11].Value = CheckOpinion;
            parameters[12].Value = CompanyEvaluate;
            parameters[13].Value = CompanyEvaluateStar;
            parameters[14].Value = CompanyEvaluate;
            parameters[15].Value = TeacherEvaluateStar;
            parameters[16].Value = DemandState;
            parameters[17].Value = VisibleType;
            parameters[18].Value = Teacher;
            parameters[19].Value = PredictedFinishTime;
            parameters[20].Value = BackInfo; 
            parameters[21].Value = Attachment;
            parameters[22].Value = PrE;
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
            strSql.Append("update Demand set ");
            strSql.Append("PubCompany=@PubCompany,");
            strSql.Append("PubTime=@PubTime,");
            strSql.Append("PubPerson=@PubPerson,");
            strSql.Append("DemandType=@DemandType,");
            strSql.Append("DemandName=@DemandName,");
            strSql.Append("DemandDetail=@DemandDetail,");
            strSql.Append("ContactPerson=@ContactPerson,");
            strSql.Append("ContactTel=@ContactTel,");
            strSql.Append("ContactEmail=@ContactEmail,");
            strSql.Append("Push=@Push,");
            strSql.Append("CheckPerson=@CheckPerson,");
            strSql.Append("CheckOpinion=@CheckOpinion,");
            strSql.Append("ApprovalDate=@ApprovalDate,");
            strSql.Append("ApprovalOpinion=@ApprovalOpinion,");
            strSql.Append("CompanyEvaluate=@CompanyEvaluate,");
            strSql.Append("TeacherEvaluate=@TeacherEvaluate,");
            strSql.Append("TeacherEvaluateStar=@TeacherEvaluateStar,");
            strSql.Append("DemandState=@DemandState,");
            strSql.Append("VisibleType=@VisibleType,");
            strSql.Append("Teacher=@Teacher ");
            strSql.Append("PredictedFinishTime=@PredictedFinishTime ");
            strSql.Append("BackInfo=@BackInfo ");
            strSql.Append("Attachment=@Attachment ");
            strSql.Append("PrE=@PrE ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
                new SqlParameter("@PubCompany", SqlDbType.NVarChar,50),
                new SqlParameter("@PubTime", SqlDbType.DateTime),
                new SqlParameter("@PubPerson", SqlDbType.NVarChar,50),
                new SqlParameter("@DemandType", SqlDbType.NVarChar,50),
                new SqlParameter("@DemandName", SqlDbType.NVarChar,50),
                new SqlParameter("@DemandDetail", SqlDbType.NVarChar,50),
                new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
                new SqlParameter("@ContactTel", SqlDbType.NVarChar,50),
                new SqlParameter("@ContactEmail", SqlDbType.NVarChar,50),
                new SqlParameter("@Push", SqlDbType.NVarChar,50),
                new SqlParameter("@CheckPerson", SqlDbType.NVarChar,50),
                new SqlParameter("@CheckOpinion", SqlDbType.NVarChar,50),
                new SqlParameter("@CompanyEvaluate", SqlDbType.NVarChar,50),
                new SqlParameter("@CompanyEvaluateStar", SqlDbType.Int,4),
                new SqlParameter("@TeacherEvaluate", SqlDbType.NVarChar,50),
                new SqlParameter("@TeacherEvaluateStar", SqlDbType.Int,4),
                new SqlParameter("@DemandState", SqlDbType.Int,4),
                new SqlParameter("@VisibleType", SqlDbType.Int,4),
                new SqlParameter("@Teacher", SqlDbType.NVarChar,50),
                new SqlParameter("@PredictedFinishTime",SqlDbType.DateTime),
                new SqlParameter("@BackInfo", SqlDbType.NVarChar,50),
                new SqlParameter("@Attachment", SqlDbType.NVarChar,500),
                new SqlParameter("@PrE", SqlDbType.NVarChar,50)};
            parameters[0].Value = ID;
            parameters[1].Value = PubCompany;
            parameters[2].Value = PubTime;
            parameters[3].Value = PubPerson;
            parameters[4].Value = DemandType;
            parameters[5].Value = DemandName;
            parameters[6].Value = DemandDetail;
            parameters[7].Value = ContactPerson;
            parameters[8].Value = ContactTel;
            parameters[9].Value = ContactEmail;
            parameters[10].Value = Push;
            parameters[11].Value = CheckPerson;
            parameters[12].Value = CheckOpinion;
            parameters[13].Value = CompanyEvaluate;
            parameters[14].Value = CompanyEvaluateStar;
            parameters[15].Value = CompanyEvaluate;
            parameters[16].Value = TeacherEvaluateStar;
            parameters[17].Value = DemandState;
            parameters[18].Value = VisibleType;
            parameters[19].Value = Teacher;
            parameters[20].Value = PredictedFinishTime;
            parameters[21].Value = BackInfo;
            parameters[22].Value = Attachment;
            parameters[23].Value = PrE;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Deamnd ");
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
            strSql.Append("select ID,PubCompany,PubTime,PubPerson,DemandType,DemandName,DemandDetail,ContactPerson,ContactTel,ContactEmail,Push,CompanyEvaluate,CompanyEvaluateStar,TeacherEvaluate,TeacherEvaluateStar,DemandState,VisibleType,Teacher,PredictedFinishTime,BackInfo,Attachment,PrE ");
            strSql.Append(" FROM Demand ");
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
                PubCompany = ds.Tables[0].Rows[0]["PubCompany"].ToString();
                if (ds.Tables[0].Rows[0]["PubTime"].ToString() != " ")
                {
                    PubTime = DateTime.Parse(ds.Tables[0].Rows[0]["PubTime"].ToString());
                }
                PubPerson = ds.Tables[0].Rows[0]["PubPerson"].ToString();
                DemandType = ds.Tables[0].Rows[0]["DemandType"].ToString();
                DemandName = ds.Tables[0].Rows[0]["DemandName"].ToString();
                DemandDetail = ds.Tables[0].Rows[0]["DemandDetail"].ToString();
                ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                ContactTel = ds.Tables[0].Rows[0]["ContactTel"].ToString();
                ContactEmail = ds.Tables[0].Rows[0]["ContactEmail"].ToString();
                Push = ds.Tables[0].Rows[0]["Push"].ToString();
                CompanyEvaluate = ds.Tables[0].Rows[0]["CompanyEvaluate"].ToString();
                CompanyEvaluateStar = ds.Tables[0].Rows[0]["CompanyEvaluateStar"].ToString();
                TeacherEvaluate = ds.Tables[0].Rows[0]["TeacherEvaluate"].ToString();
                TeacherEvaluateStar = ds.Tables[0].Rows[0]["TeacherEvaluateStar"].ToString();
                if (ds.Tables[0].Rows[0]["DemandState"].ToString() != "")
                {
                    DemandState = int.Parse(ds.Tables[0].Rows[0]["DemandState"].ToString());
                }
                if (ds.Tables[0].Rows[0]["VisibleType"].ToString() != "")
                {
                    VisibleType = int.Parse(ds.Tables[0].Rows[0]["VisibleType"].ToString());
                }
                Teacher = ds.Tables[0].Rows[0]["Teacher"].ToString();
                PredictedFinishTime = ds.Tables[0].Rows[0]["PredictedFinishTime"].ToString();
                BackInfo = ds.Tables[0].Rows[0]["BackInfo"].ToString(); 
                Attachment = ds.Tables[0].Rows[0]["Attachment"].ToString();
                PrE = ds.Tables[0].Rows[0]["PrE"].ToString();
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM Demand ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
       
        #endregion  成员方法
    }


}
