using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
    /// <summary>
    /// 类LCXProject。
    /// </summary>
    public class Post
    {
        public Post()
        { }
        #region Model
        private int _id;
        private string _PubCompany;
        private string _PostJobName;
        private DateTime? _PubTime;
        private string _PubPerson;
        private string _PostJobType;
        private string _RequiredProfession; 
        private string _RequiredAmount;
        private string _PostDetail;
        private string _ContactPerson;
        private string _ContactTel;
        private string _ContactEmail;
        private string _Push;
        private string _CompanyEvaluate;
        private string _PostState;
        private string _Teachers;
        private string _BeginTime;
        private string _EndTime;
        private string _BackInfo;
        private string _Attachment;

        /// <summary>
        /// 项目自编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 挂职单位名称
        /// </summary>
        public string PubCompany
        {
            set { _PubCompany = value; }
            get { return _PubCompany; }
        }
        /// <summary>
        /// 挂职职位名称
        /// </summary>
        public string PostJobName
        {
            set { _PostJobName = value; }
            get { return _PostJobName; }
        }
        /// <summary>
        /// 挂职信息发布时间
        /// </summary>
        public DateTime? PubTime
        {
            set { _PubTime = value; }
            get { return _PubTime; }
        }
        
       
        /// <summary>
        /// 挂职信息发布人
        /// </summary>
        public string PubPerson
        {
            set { _PubPerson = value; }
            get { return _PubPerson; }
        }
        /// <summary>
        /// 挂职职位类型 行政岗位挂职、专技岗位挂职等
        /// </summary>
        public string PostJobType
        {
            set { _PostJobType = value; }
            get { return _PostJobType; }
        }
        /// <summary>
        /// 挂职职位要求专业
        /// </summary>
        public string RequiredProfession
        {
            set { _RequiredProfession = value; }
            get { return _RequiredProfession; }
        }
        /// <summary>
        /// 挂职职位的数量
        /// </summary>
        public string RequiredAmount
        {
            set { _RequiredAmount = value; }
            get { return _RequiredAmount; }
        }
        /// <summary>
        /// 挂职职位的其他描述
        /// </summary>
        public string PostDetail
        {
            set { _PostDetail = value; }
            get { return _PostDetail; }
        }
        
        /// <summary>
        ///甲方联系人
        /// </summary>
        public string ContactPerson
        {
            set { _ContactPerson = value; }
            get { return _ContactPerson; }
        }
        /// <summary>
        /// 甲方联系人电话
        /// </summary>
        public string ContactTel
        {
            set { _ContactTel = value; }
            get { return _ContactTel; }
        }
        /// <summary>
        ///甲方联系人电子邮箱
        /// </summary>
        public string ContactEmail
        {
            set { _ContactEmail = value; }
            get { return _ContactEmail; }
        }
        /// <summary>
        ///挂职信息要推送的部门
        /// </summary>
        public string Push
        {
            set { _Push = value; }
            get { return _Push; }
        }
        /// <summary>
        /// 单位方面对挂职老师的评价
        /// </summary>
        public string CompanyEvaluate
        {
            set { _CompanyEvaluate = value; }
            get { return _CompanyEvaluate; }
        }
        /// <summary>
        /// 挂职职位的状态，分为0-公司发布 1-管理员审核通过 校内公示 2-老师和单位进行沟通后 老师确认挂职 挂职的状态改变 
        /// </summary>
        public string PostState
        {
            set { _PostState = value; }
            get { return _PostState; }
        }
        /// <summary>
        /// 挂职的老师姓名？如有多个老师挂职呢？？再说吧
        /// </summary>
        public string Teachers
        {
            set { _Teachers = value; }
            get { return _Teachers; }
        }
        /// <summary>
        /// 挂职开始时间
        /// </summary>
        public string BeginTime
        {
            set { _BeginTime = value; }
            get { return _BeginTime; }
        }
        /// <summary>
        /// 挂职结束时间
        /// </summary>
        public string EndTime
        {
            set { _EndTime = value; }
            get { return _EndTime; }
        }
        /// <summary>
        /// 挂职的其他说明和要求
        /// </summary>
        public string BackInfo
        {
            set { _BackInfo = value; }
            get { return _BackInfo; }
        }
        /// <summary>
        /// 附件
        /// </summary>
        public string Attachment
        {
            set { _Attachment = value; }
            get { return _Attachment; }
        }
       
      
    
        
        #endregion Model


        #region  成员方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Post(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PubCompany,PostJobName,PubTime,PubPerson,PostJobType,RequiredProfession,RequiredAmount,PostDetail,ContactPerson,ContactTel,ContactEmail,Push,CompanyEvaluate,PostState,Teachers,BeginTime,EndTime,BackInfo,Attachment ");
            strSql.Append(" FROM Post ");
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
                PostJobName = ds.Tables[0].Rows[0]["PostJobName"].ToString();
                if (ds.Tables[0].Rows[0]["PubTime"].ToString() != "")
                {
                    PubTime = DateTime.Parse(ds.Tables[0].Rows[0]["PubTime"].ToString());
                }
               
                PubPerson = ds.Tables[0].Rows[0]["PubPerson"].ToString();
                PostJobType = ds.Tables[0].Rows[0]["PostJobType"].ToString();
                RequiredProfession = ds.Tables[0].Rows[0]["RequiredProfession"].ToString();
                RequiredAmount = ds.Tables[0].Rows[0]["RequiredAmount"].ToString();
                PostDetail = ds.Tables[0].Rows[0]["PostDetail"].ToString();
                ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                ContactTel = ds.Tables[0].Rows[0]["ContactTel"].ToString();
                ContactEmail = ds.Tables[0].Rows[0]["ContactEmail"].ToString(); 
                Push = ds.Tables[0].Rows[0]["Push"].ToString();
                CompanyEvaluate = ds.Tables[0].Rows[0]["CompanyEvaluate"].ToString();
                PostState = ds.Tables[0].Rows[0]["PostState"].ToString();
                Teachers = ds.Tables[0].Rows[0]["Teachers"].ToString();
                BeginTime = ds.Tables[0].Rows[0]["BeginTime"].ToString();
                BackInfo = ds.Tables[0].Rows[0]["BackInfo"].ToString();
                Attachment = ds.Tables[0].Rows[0]["Attachment"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Post");
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
            strSql.Append("insert into Post(");
            strSql.Append("PubCompany,PostJobName,PubTime,PubPerson,PostJobType,RequiredProfession,RequiredAmount,PostDetail,ContactPerson,ContactTel,ContactEmail,Push,CompanyEvaluate,PostState,Teachers,BeginTime,EndTime,BackInfo,Attachment)");
            strSql.Append(" values (");
            strSql.Append("@PubCompany,@PostJobName,@PubTime,@PubPerson,@PostJobType,@RequiredProfession,@RequiredAmount,@PostDetail,@ContactPerson,@ContactTel,@ContactEmail,@Push,@CompanyEvaluate,@PostState,@Teachers,@BeginTime,@EndTime,@BackInfo,@Attachment)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@PubCompany", SqlDbType.NVarChar,50),
                    new SqlParameter("@PostJobName", SqlDbType.NVarChar,50),
                    new SqlParameter("@PubTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@PubPerson", SqlDbType.NVarChar,50),
                    new SqlParameter("@PostJobType", SqlDbType.NVarChar,50),
                    new SqlParameter("@RequiredProfession", SqlDbType.NVarChar,50),
                    new SqlParameter("@RequiredAmount", SqlDbType.NVarChar,50),
                    new SqlParameter("@PostDetail", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactEmail", SqlDbType.NVarChar,50),
                    new SqlParameter("@Push", SqlDbType.NVarChar,50),
                    new SqlParameter("@CompanyEvaluate", SqlDbType.NVarChar,50),
                    new SqlParameter("@PostState", SqlDbType.NVarChar,50),
                    new SqlParameter("@Teachers", SqlDbType.NVarChar,50),
                    new SqlParameter("@BeginTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@EndTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@BackInfo", SqlDbType.NVarChar,50),
                    new SqlParameter("@Attachment", SqlDbType.NVarChar,500)};
            parameters[0].Value = PubCompany;
            parameters[1].Value = PostJobName;
            parameters[2].Value = PubTime;
            parameters[3].Value = PubPerson;
            parameters[4].Value = PostJobType;
            parameters[5].Value = RequiredProfession;
            parameters[6].Value = RequiredAmount;
            parameters[7].Value = PostDetail;
            parameters[8].Value = ContactPerson;
            parameters[9].Value = ContactTel;
            parameters[10].Value = ContactEmail;
            parameters[11].Value = Push;
            parameters[12].Value = CompanyEvaluate;
            parameters[13].Value = PostState;
            parameters[14].Value = Teachers;
            parameters[15].Value = BeginTime;
            parameters[16].Value = EndTime;
            parameters[17].Value = BackInfo;
            parameters[18].Value = Attachment;

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
            strSql.Append("update Post set ");
            strSql.Append("PostJobName=@PostJobName,");
            /*strSql.Append("PostJobType=@PostJobType,");
            strSql.Append("RequiredProfession=@RequiredProfession,");
            strSql.Append("RequiredAmount=@RequiredAmount,");
            strSql.Append("PostDetail=@PostDetail,");
            strSql.Append("ContactPerson=@ContactPerson,");
            strSql.Append("ContactTel=@ContactTel,");
            strSql.Append("ContactEmail=@ContactEmail,");
            strSql.Append("Push=@Push,");
            strSql.Append("PostState=@PostState,");
            strSql.Append("Teachers=@Teachers,");
            strSql.Append("BeginTime=@BeginTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("BackInfo=@BackInfo,");
            strSql.Append("Attachment=@Attachment,");*/
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    //new SqlParameter("@PubCompany", SqlDbType.NVarChar,50)
                    new SqlParameter("@PostJobName", SqlDbType.NVarChar,50)
                    /*new SqlParameter("@PubTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@PubPerson", SqlDbType.NVarChar,50),
                    new SqlParameter("@PostJobType", SqlDbType.NVarChar,50),
                    new SqlParameter("@RequiredProfession", SqlDbType.NVarChar,50),
                    new SqlParameter("@RequiredAmount", SqlDbType.NVarChar,50),
                    new SqlParameter("@PostDetail", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactEmail", SqlDbType.NVarChar,50),
                    new SqlParameter("@Push", SqlDbType.NVarChar,50),
                    new SqlParameter("@CompanyEvaluate", SqlDbType.NVarChar,50),
                    new SqlParameter("@PostState", SqlDbType.NVarChar,50),
                    new SqlParameter("@Teachers", SqlDbType.NVarChar,50),
                    new SqlParameter("@BeginTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@EndTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@BackInfo", SqlDbType.NVarChar,50),
                    new SqlParameter("@Attachment", SqlDbType.NVarChar,500)*/  };
            parameters[0].Value = ID;
            //parameters[1].Value = PubCompany;
            parameters[1].Value = PostJobName;
            /*parameters[3].Value = PubTime;
            parameters[4].Value = PubPerson;
            parameters[5].Value = PostJobType;
            parameters[6].Value = RequiredProfession;
            parameters[7].Value = RequiredAmount;
            parameters[8].Value = PostDetail;
            parameters[9].Value = ContactPerson;
            parameters[10].Value = ContactTel;
            parameters[11].Value = ContactEmail;
            parameters[12].Value = Push;
            parameters[13].Value = CompanyEvaluate;
            parameters[14].Value = PostState;
            parameters[15].Value = Teachers;
            parameters[16].Value = BeginTime;
            parameters[17].Value = EndTime;
            parameters[18].Value = BackInfo;
            parameters[19].Value = Attachment;*/
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
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete Post ");
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
            strSql.Append("select ID,PubCompany,PostJobName,PubTime,PubPerson,PostJobType,RequiredProfession,RequiredAmount,PostDetail,ContactPerson,ContactTel,ContactEmail,Push,CompanyEvaluate,PostState,Teachers,BeginTime,EndTime,BackInfo,Attachment ");
            strSql.Append(" FROM Post ");
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
                PostJobName = ds.Tables[0].Rows[0]["PostJobName"].ToString();
                if (ds.Tables[0].Rows[0]["PubTime"].ToString() != "")
                {
                    PubTime = DateTime.Parse(ds.Tables[0].Rows[0]["PubTime"].ToString());
                }

                PubPerson = ds.Tables[0].Rows[0]["PubPerson"].ToString();
                PostJobType = ds.Tables[0].Rows[0]["PostJobType"].ToString();
                RequiredProfession = ds.Tables[0].Rows[0]["RequiredProfession"].ToString();
                RequiredAmount = ds.Tables[0].Rows[0]["RequiredAmount"].ToString();
                PostDetail = ds.Tables[0].Rows[0]["PostDetail"].ToString();
                ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                ContactTel = ds.Tables[0].Rows[0]["ContactTel"].ToString();
                ContactEmail = ds.Tables[0].Rows[0]["ContactEmail"].ToString();
                Push = ds.Tables[0].Rows[0]["Push"].ToString();
                CompanyEvaluate = ds.Tables[0].Rows[0]["CompanyEvaluate"].ToString();
                PostState = ds.Tables[0].Rows[0]["PostState"].ToString();
                Teachers = ds.Tables[0].Rows[0]["Teachers"].ToString();
                BeginTime = ds.Tables[0].Rows[0]["BeginTime"].ToString();
                BackInfo = ds.Tables[0].Rows[0]["BackInfo"].ToString();
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
            strSql.Append(" FROM Post ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}

