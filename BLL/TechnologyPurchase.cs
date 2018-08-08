using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
    /// <summary>
    /// 类TechnologyPurchase。
    /// </summary>
    public class TechnologyPurchase
    {
        public TechnologyPurchase()
        { }
        #region Model
        private int _ID;
        private string _PubCompany;
        private string _TechnologyName;
        private DateTime? _PubTime;
        private string _PubPerson;
        private string _TechnologyType;
        private string _RequiredProfession;
        private string _TechnologyDetail;
        private string _ContactPerson;
        private string _ContactTel;
        private string _ContactEmail;
        private string _Push;
        private string _CompanyEvaluate;
        private int _TechnologyPurchaseState;
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
            set { _ID = value; }
            get { return _ID; }
        }
        /// <summary>
        /// 技术求购单位名称
        /// </summary>
        public string PubCompany
        {
            set { _PubCompany = value; }
            get { return _PubCompany; }
        }
        /// <summary>
        /// 技术名称
        /// </summary>
        public string TechnologyName
        {
            set { _TechnologyName = value; }
            get { return _TechnologyName; }
        }
        /// <summary>
        /// 技术求购发布时间
        /// </summary>
        public DateTime? PubTime
        {
            set { _PubTime = value; }
            get { return _PubTime; }
        }


        /// <summary>
        /// 技术求购发布人
        /// </summary>
        public string PubPerson
        {
            set { _PubPerson = value; }
            get { return _PubPerson; }
        }
        /// <summary>
        /// 技术求购的技术类型
        /// </summary>
        public string TechnologyType
        {
            set { _TechnologyType = value; }
            get { return _TechnologyType; }
        }
        /// <summary>
        /// 技术求购要求的专业人员
        /// </summary>
        public string RequiredProfession
        {
            set { _RequiredProfession = value; }
            get { return _RequiredProfession; }
        }
        
        /// <summary>
        /// 技术求购得其他描述
        /// </summary>
        public string TechnologyDetail
        {
            set { _TechnologyDetail = value; }
            get { return _TechnologyDetail; }
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
        /// 技术求购的状态，分为0-公司发布 1-管理员审核通过 校内公示 2-老师和单位进行沟通后 老师确认提供技术 挂职的状态改变 合作完成
        /// </summary>
        public int TechnologyPurchaseState
        {
            set { _TechnologyPurchaseState = value; }
            get { return _TechnologyPurchaseState; }
        }
        /// <summary>
        /// 认购技术的老师姓名？如有多个老师挂职呢？？再说吧
        /// </summary>
        public string Teachers
        {
            set { _Teachers = value; }
            get { return _Teachers; }
        }
        /// <summary>
        /// 技术支持开始时间
        /// </summary>
        public string BeginTime
        {
            set { _BeginTime = value; }
            get { return _BeginTime; }
        }
        /// <summary>
        /// 技术支持结束时间
        /// </summary>
        public string EndTime
        {
            set { _EndTime = value; }
            get { return _EndTime; }
        }
        /// <summary>
        /// 技术支持的其他说明和要求
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
        public TechnologyPurchase(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PubCompany,TechnologyName,PubTime,PubPerson,TechnologyType,RequiredProfession,TechnologyDetail,ContactPerson,ContactTel,ContactEmail,Push,CompanyEvaluate,TechnologyPurchaseState,Teachers,BeginTime,EndTime,BackInfo,Attachment ");
            strSql.Append(" FROM TechnologyPurchase ");
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
                TechnologyName = ds.Tables[0].Rows[0]["TechnologyName"].ToString();
                if (ds.Tables[0].Rows[0]["PubTime"].ToString() != "")
                {
                    PubTime = DateTime.Parse(ds.Tables[0].Rows[0]["PubTime"].ToString());
                }

                PubPerson = ds.Tables[0].Rows[0]["PubPerson"].ToString();
                TechnologyType = ds.Tables[0].Rows[0]["TechnologyType"].ToString();
                RequiredProfession = ds.Tables[0].Rows[0]["RequiredProfession"].ToString();
                TechnologyDetail = ds.Tables[0].Rows[0]["TechnologyDetail"].ToString();
                ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                ContactTel = ds.Tables[0].Rows[0]["ContactTel"].ToString();
                ContactEmail = ds.Tables[0].Rows[0]["ContactEmail"].ToString();
                Push = ds.Tables[0].Rows[0]["Push"].ToString();
                CompanyEvaluate = ds.Tables[0].Rows[0]["CompanyEvaluate"].ToString();
                if (ds.Tables[0].Rows[0]["TechnologyPurchaseState"].ToString() != "")
                {
                    TechnologyPurchaseState = int.Parse(ds.Tables[0].Rows[0]["TechnologyPurchaseState"].ToString());
                }
                
                Teachers = ds.Tables[0].Rows[0]["Teachers"].ToString();
                BeginTime = ds.Tables[0].Rows[0]["BeginTime"].ToString();
                EndTime= ds.Tables[0].Rows[0]["EndTime"].ToString();
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
            strSql.Append("select count(1) from TechnologyPurchase");
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
            strSql.Append("insert into TechnologyPurchase(");
            strSql.Append("PubCompany,TechnologyName,PubTime,PubPerson,TechnologyType,RequiredProfession,TechnologyDetail,ContactPerson,ContactTel,ContactEmail,Push,CompanyEvaluate,TechnologyPurchaseState,Teachers,BeginTime,EndTime,BackInfo,Attachment)");
            strSql.Append(" values (");
            strSql.Append("@PubCompany,@TechnologyName,@PubTime,@PubPerson,@TechnologyType,@RequiredProfession,@TechnologyDetail,@ContactPerson,@ContactTel,@ContactEmail,@Push,@CompanyEvaluate,@TechnologyPurchaseState,@Teachers,@BeginTime,@EndTime,@BackInfo,@Attachment)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@PubCompany", SqlDbType.NVarChar,50),
                    new SqlParameter("@TechnologyName", SqlDbType.NVarChar,50),
                    new SqlParameter("@PubTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@PubPerson", SqlDbType.NVarChar,50),
                    new SqlParameter("@TechnologyType", SqlDbType.NVarChar,50),
                    new SqlParameter("@RequiredProfession", SqlDbType.NVarChar,50),
                    new SqlParameter("@TechnologyDetail", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactEmail", SqlDbType.NVarChar,50),
                    new SqlParameter("@Push", SqlDbType.NVarChar,50),
                    new SqlParameter("@CompanyEvaluate", SqlDbType.NVarChar,50),
                    new SqlParameter("@TechnologyPurchaseState", SqlDbType.Int,4),
                    new SqlParameter("@Teachers", SqlDbType.NVarChar,50),
                    new SqlParameter("@BeginTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@EndTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@BackInfo", SqlDbType.NVarChar,50),
                    new SqlParameter("@Attachment", SqlDbType.NVarChar,500)};
            parameters[0].Value = PubCompany;
            parameters[1].Value = TechnologyName;
            parameters[2].Value = PubTime;
            parameters[3].Value = PubPerson;
            parameters[4].Value = TechnologyType;
            parameters[5].Value = RequiredProfession;
            parameters[6].Value = TechnologyDetail;
            parameters[7].Value = ContactPerson;
            parameters[8].Value = ContactTel;
            parameters[9].Value = ContactEmail;
            parameters[10].Value = Push;
            parameters[11].Value = CompanyEvaluate;
            parameters[12].Value = TechnologyPurchaseState;
            parameters[13].Value = Teachers;
            parameters[14].Value = BeginTime;
            parameters[15].Value = EndTime;
            parameters[16].Value = BackInfo;
            parameters[17].Value = Attachment;

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
            strSql.Append("update TechnologyPurchase set ");
            strSql.Append("TechnologyName=@TechnologyName,");
            strSql.Append("TechnologyType=@TechnologyType,");
            strSql.Append("RequiredProfession=@RequiredProfession,");
            strSql.Append("TechnologyDetail=@TechnologyDetail,");
            strSql.Append("ContactPerson=@ContactPerson,");
            strSql.Append("ContactTel=@ContactTel,");
            strSql.Append("ContactEmail=@ContactEmail,");
            strSql.Append("Push=@Push,");
            strSql.Append("CompanyEvaluate=@CompanyEvaluate,");
            strSql.Append("TechnologyPurchaseState=@TechnologyPurchaseState,");
            strSql.Append("Teachers=@Teachers,");
            strSql.Append("BeginTime=@BeginTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("BackInfo=@BackInfo,");
            strSql.Append("Attachment=@Attachment ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@TechnologyName", SqlDbType.NVarChar,50),
                    new SqlParameter("@TechnologyType", SqlDbType.NVarChar,50),
                    new SqlParameter("@RequiredProfession", SqlDbType.NVarChar,50),
                    new SqlParameter("@TechnologyDetail", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactEmail", SqlDbType.NVarChar,50),
                    new SqlParameter("@Push", SqlDbType.NVarChar,50),
                    new SqlParameter("@CompanyEvaluate", SqlDbType.NVarChar,50),
                    new SqlParameter("@TechnologyPurchaseState", SqlDbType.Int,4),
                    new SqlParameter("@Teachers", SqlDbType.NVarChar,50),
                    new SqlParameter("@BeginTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@EndTime", SqlDbType.NVarChar,50),
                    new SqlParameter("@BackInfo", SqlDbType.NVarChar,50),
                    new SqlParameter("@Attachment", SqlDbType.NVarChar,500) };
            parameters[0].Value = ID;
            parameters[1].Value = TechnologyName;
            parameters[2].Value = TechnologyType;
            parameters[3].Value = RequiredProfession;
            parameters[4].Value = TechnologyDetail;
            parameters[5].Value = ContactPerson;
            parameters[6].Value = ContactTel;
            parameters[7].Value = ContactEmail;
            parameters[8].Value = Push;
            parameters[9].Value = CompanyEvaluate;
            parameters[10].Value = TechnologyPurchaseState;
            parameters[11].Value = Teachers;
            parameters[12].Value = BeginTime;
            parameters[13].Value = EndTime;
            parameters[14].Value = BackInfo;
            parameters[15].Value = Attachment;
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
            strSql.Append("delete TechnologyPurchase ");
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
            strSql.Append("select ID,PubCompany,TechnologyName,PubTime,PubPerson,TechnologyType,RequiredProfession,TechnologyDetail,ContactPerson,ContactTel,ContactEmail,Push,CompanyEvaluate,TechnologyPurchaseState,Teachers,BeginTime,EndTime,BackInfo,Attachment ");
            strSql.Append(" FROM TechnologyPurchase ");
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
                TechnologyName = ds.Tables[0].Rows[0]["TechnologyName"].ToString();
                if (ds.Tables[0].Rows[0]["PubTime"].ToString() != "")
                {
                    PubTime = DateTime.Parse(ds.Tables[0].Rows[0]["PubTime"].ToString());
                }

                PubPerson = ds.Tables[0].Rows[0]["PubPerson"].ToString();
                TechnologyType = ds.Tables[0].Rows[0]["TechnologyType"].ToString();
                RequiredProfession = ds.Tables[0].Rows[0]["RequiredProfession"].ToString();
                TechnologyDetail = ds.Tables[0].Rows[0]["TechnologyDetail"].ToString();
                ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                ContactTel = ds.Tables[0].Rows[0]["ContactTel"].ToString();
                ContactEmail = ds.Tables[0].Rows[0]["ContactEmail"].ToString();
                Push = ds.Tables[0].Rows[0]["Push"].ToString();
                CompanyEvaluate = ds.Tables[0].Rows[0]["CompanyEvaluate"].ToString();
                if (ds.Tables[0].Rows[0]["TechnologyPurchaseState"].ToString() != "")
                {
                    TechnologyPurchaseState = int.Parse(ds.Tables[0].Rows[0]["TechnologyPurchaseState"].ToString());
                }
                Teachers = ds.Tables[0].Rows[0]["Teachers"].ToString();
                BeginTime = ds.Tables[0].Rows[0]["BeginTime"].ToString();
                EndTime = ds.Tables[0].Rows[0]["EndTime"].ToString();
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
            strSql.Append(" FROM TechnologyPurchase ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
