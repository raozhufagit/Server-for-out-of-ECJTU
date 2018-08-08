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
    public class LCXProject
    {
        public LCXProject()
        { }
        #region Model
        private int _id;
        private string _projectname;
        private string _projectserils;
        private string _suoshukehu;
        private string _yujichengjiaoriqi;
        private string _tixingdate;
        private string _fuzeren;
        private string _xiangmujine;
        private string _xiangmuyusuan;
        private string _xiangmudaxiao;
        private string _peiherenlist;
        private string _username;
        private DateTime? _timestr;
        private string _hetongandfujian;
        private string _backinfo;
        private string _ProjectType;
        private string _ContactPerson;
        private string _ContactTel;
        private string _ContactEmail;
        private string _Push;
        private string _CompanyEvaluate;
        private int _CompanyEvaluateStar;
        private string _TeacherEvaluate;
        private int _TeacherEvaluateStar;
        private int _ProjectState;

        /// <summary>
        /// 项目自编号
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName
        {
            set { _projectname = value; }
            get { return _projectname; }
        }
        /// <summary>
        /// 项目编号
        /// </summary>
        public string ProjectSerils
        {
            set { _projectserils = value; }
            get { return _projectserils; }
        }
        /// <summary>
        /// 发布项目的公司
        /// </summary>
        public string SuoShuKeHu
        {
            set { _suoshukehu = value; }
            get { return _suoshukehu; }
        }
        /// <summary>
        /// 预计成交日期
        /// </summary>
        public string YuJiChengJiaoRiQi
        {
            set { _yujichengjiaoriqi = value; }
            get { return _yujichengjiaoriqi; }
        }
        /// <summary>
        /// 提醒日期
        /// </summary>
        public string TiXingDate
        {
            set { _tixingdate = value; }
            get { return _tixingdate; }
        }
        /// <summary>
        /// 校内负责人
        /// </summary>
        public string FuZeRen
        {
            set { _fuzeren = value; }
            get { return _fuzeren; }
        }
        /// <summary>
        /// 项目金额
        /// </summary>
        public string XiangMuJinE
        {
            set { _xiangmujine = value; }
            get { return _xiangmujine; }
        }
        /// <summary>
        /// 项目预算
        /// </summary>
        public string XiangMuYuSuan
        {
            set { _xiangmuyusuan = value; }
            get { return _xiangmuyusuan; }
        }
        /// <summary>
        /// 项目大小
        /// </summary>
        public string XiangMuDaXiao
        {
            set { _xiangmudaxiao = value; }
            get { return _xiangmudaxiao; }
        }
        /// <summary>
        /// 项目校内配合人
        /// </summary>
        public string PeiHeRenList
        {
            set { _peiherenlist = value; }
            get { return _peiherenlist; }
        }
        /// <summary>
        /// 公司方面项目发布人
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 项目录入时间
        /// </summary>
        public DateTime? TimeStr
        {
            set { _timestr = value; }
            get { return _timestr; }
        }
        /// <summary>
        /// 项目需求或者合同以及附件
        /// </summary>
        public string HeTongAndFuJian
        {
            set { _hetongandfujian = value; }
            get { return _hetongandfujian; }
        }
        /// <summary>
        /// 项目的其他说明和要求
        /// </summary>
        public string BackInfo
        {
            set { _backinfo = value; }
            get { return _backinfo; }
        }
        /// <summary>
        /// 项目类型  科技开发、科技服务、科学研究、合作办学等。
        /// </summary>
        public string ProjectType
        {
            set { _ProjectType = value; }
            get { return _ProjectType; }
        }
        /// <summary>
        /// 项目联系人
        /// </summary>
        public string ContactPerson
        {
            set { _ContactPerson = value; }
            get { return _ContactPerson; }
        }
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string ContactTel
        {
            set { _ContactTel = value; }
            get { return _ContactTel; }
        }
        /// <summary>
        /// 联系人电子邮箱
        /// </summary>
        public string ContactEmail
        {
            set { _ContactEmail = value; }
            get { return _ContactEmail; }
        }
        /// <summary>
        /// 项目要推送的部门
        /// </summary>
        public string Push
        {
            set { _Push = value; }
            get { return _Push; }
        }
        /// <summary>
        /// 公司方面对项目的评价
        /// </summary>
        public string CompanyEvaluate
        {
            set { _CompanyEvaluate = value; }
            get { return _CompanyEvaluate; }
        }
        /// <summary>
        /// 公司方面对项目的评价星级（5星制度）
        /// </summary>
        public int CompanyEvaluateStar
        {
            set { _CompanyEvaluateStar = value; }
            get { return _CompanyEvaluateStar; }
        }
        /// <summary>
        /// 教室方面对于项目的评价
        /// </summary>
        public string TeacherEvaluate
        {
            set { _TeacherEvaluate = value; }
            get { return _TeacherEvaluate; }
        }
        /// <summary>
        /// 教室方面对于项目的评价星级5星制度
        /// </summary>
        public int TeacherEvaluateStar
        {
            set { _TeacherEvaluateStar = value; }
            get { return _TeacherEvaluateStar; }
        }
        /// <summary>
        /// 项目的状态 0-公司提出、对外联络处可见，有修改并推送的权限 1-对外联络处同意推送，老师可见，公司也可见项目状态为上架  2-公司确认教师接单购买  3-项目进行中，老师填写相关进度 公司，学校都可见   4-项目完成，老师和公司进行评价 学校进行评审
        /// </summary>
        public int ProjectState
        {
            set { _ProjectState = value; }
            get { return _ProjectState; }
        }
        #endregion Model


        #region  成员方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXProject(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ProjectName,ProjectSerils,SuoShuKeHu,YuJiChengJiaoRiQi,TiXingDate,FuZeRen,XiangMuJinE,XiangMuYuSuan,XiangMuDaXiao,PeiHeRenList,UserName,TimeStr,HeTongAndFuJian,BackInfo,ProjectType,ContactPerson,ContactTel,ContactEmail,Push,CompanyEvaluate,CompanyEvaluateStar,TeacherEvaluate,TeacherEvaluateStar,ProjectState ");
            strSql.Append(" FROM LCXProject ");
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
                ProjectName = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                ProjectSerils = ds.Tables[0].Rows[0]["ProjectSerils"].ToString();
                SuoShuKeHu = ds.Tables[0].Rows[0]["SuoShuKeHu"].ToString();
                YuJiChengJiaoRiQi = ds.Tables[0].Rows[0]["YuJiChengJiaoRiQi"].ToString();
                TiXingDate = ds.Tables[0].Rows[0]["TiXingDate"].ToString();
                FuZeRen = ds.Tables[0].Rows[0]["FuZeRen"].ToString();
                XiangMuJinE = ds.Tables[0].Rows[0]["XiangMuJinE"].ToString();
                XiangMuYuSuan = ds.Tables[0].Rows[0]["XiangMuYuSuan"].ToString();
                XiangMuDaXiao = ds.Tables[0].Rows[0]["XiangMuDaXiao"].ToString();
                PeiHeRenList = ds.Tables[0].Rows[0]["PeiHeRenList"].ToString();
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["TimeStr"].ToString() != "")
                {
                    TimeStr = DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
                }
                HeTongAndFuJian = ds.Tables[0].Rows[0]["HeTongAndFuJian"].ToString();
                BackInfo = ds.Tables[0].Rows[0]["BackInfo"].ToString();
                ProjectType = ds.Tables[0].Rows[0]["ProjectType"].ToString();
                ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                ContactTel = ds.Tables[0].Rows[0]["ContactTel"].ToString();
                ContactEmail = ds.Tables[0].Rows[0]["ContactEmail"].ToString();
                Push = ds.Tables[0].Rows[0]["Push"].ToString();
                CompanyEvaluate = ds.Tables[0].Rows[0]["CompanyEvaluate"].ToString();
                if (ds.Tables[0].Rows[0]["CompanyEvaluateStar"].ToString() != "")
                {
                    CompanyEvaluateStar = int.Parse(ds.Tables[0].Rows[0]["CompanyEvaluateStar"].ToString());
                }
                TeacherEvaluate = ds.Tables[0].Rows[0]["TeacherEvaluate"].ToString();
                if (ds.Tables[0].Rows[0]["TeacherEvaluateStar"].ToString() != "")
                {
                    TeacherEvaluateStar = int.Parse(ds.Tables[0].Rows[0]["TeacherEvaluateStar"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProjectState"].ToString() != "")
                {
                    ProjectState = int.Parse(ds.Tables[0].Rows[0]["ProjectState"].ToString());
                }
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXProject");
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
            //
            //
            strSql.Append("insert into LCXProject(");
            strSql.Append("ProjectName,ProjectSerils,SuoShuKeHu,YuJiChengJiaoRiQi,TiXingDate,FuZeRen,XiangMuJinE,XiangMuYuSuan,XiangMuDaXiao,PeiHeRenList,UserName,TimeStr,HeTongAndFuJian,BackInfo,ProjectType,ContactPerson,ContactTel,ContactEmail,Push,CompanyEvaluate,CompanyEvaluateStar,TeacherEvaluate,TeacherEvaluateStar,ProjectState)");
            strSql.Append(" values (");
            strSql.Append("@ProjectName,@ProjectSerils,@SuoShuKeHu,@YuJiChengJiaoRiQi,@TiXingDate,@FuZeRen,@XiangMuJinE,@XiangMuYuSuan,@XiangMuDaXiao,@PeiHeRenList,@UserName,@TimeStr,@HeTongAndFuJian,@BackInfo,@ProjectType,@ContactPerson,@ContactTel,@ContactEmail,@Push,@CompanyEvaluate,@CompanyEvaluateStar,@TeacherEvaluate,@TeacherEvaluateStar,@ProjectState)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@ProjectName", SqlDbType.VarChar,200),
					new SqlParameter("@ProjectSerils", SqlDbType.VarChar,50),
					new SqlParameter("@SuoShuKeHu", SqlDbType.VarChar,200),
					new SqlParameter("@YuJiChengJiaoRiQi", SqlDbType.VarChar,50),
					new SqlParameter("@TiXingDate", SqlDbType.VarChar,5000),
					new SqlParameter("@FuZeRen", SqlDbType.VarChar,50),
					new SqlParameter("@XiangMuJinE", SqlDbType.VarChar,200),
					new SqlParameter("@XiangMuYuSuan", SqlDbType.VarChar,200),
					new SqlParameter("@XiangMuDaXiao", SqlDbType.VarChar,50),
					new SqlParameter("@PeiHeRenList", SqlDbType.VarChar,500),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@TimeStr", SqlDbType.DateTime),
					new SqlParameter("@HeTongAndFuJian", SqlDbType.VarChar,5000),
					new SqlParameter("@BackInfo", SqlDbType.VarChar,5000),
                    new SqlParameter("@ProjectType", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactEmail", SqlDbType.NVarChar,50),
                    new SqlParameter("@Push", SqlDbType.NVarChar,50),
                    new SqlParameter("@CompanyEvaluate", SqlDbType.NVarChar,50),
                    new SqlParameter("@CompanyEvaluateStar", SqlDbType.Int,4),
                    new SqlParameter("@TeacherEvaluate", SqlDbType.NVarChar,50),
                    new SqlParameter("@TeacherEvaluateStar", SqlDbType.Int,4),
                    new SqlParameter("@ProjectState", SqlDbType.Int,4)};
            parameters[0].Value = ProjectName;
            parameters[1].Value = ProjectSerils;
            parameters[2].Value = SuoShuKeHu;
            parameters[3].Value = YuJiChengJiaoRiQi;
            parameters[4].Value = TiXingDate;
            parameters[5].Value = FuZeRen;
            parameters[6].Value = XiangMuJinE;
            parameters[7].Value = XiangMuYuSuan;
            parameters[8].Value = XiangMuDaXiao;
            parameters[9].Value = PeiHeRenList;
            parameters[10].Value = UserName;
            parameters[11].Value = TimeStr;
            parameters[12].Value = HeTongAndFuJian;
            parameters[13].Value = BackInfo;
            parameters[14].Value = ProjectType;
            parameters[15].Value = ContactPerson;
            parameters[16].Value = ContactTel;
            parameters[17].Value = ContactEmail;
            parameters[18].Value = FuZeRen;
            parameters[19].Value = Push;
            parameters[20].Value = CompanyEvaluate;
            parameters[21].Value = CompanyEvaluateStar;
            parameters[22].Value = TeacherEvaluate;
            parameters[23].Value = ProjectState;

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
            strSql.Append("update LCXProject set ");
            strSql.Append("ProjectName=@ProjectName,");
            strSql.Append("ProjectSerils=@ProjectSerils,");
            strSql.Append("SuoShuKeHu=@SuoShuKeHu,");
            strSql.Append("YuJiChengJiaoRiQi=@YuJiChengJiaoRiQi,");
            strSql.Append("TiXingDate=@TiXingDate,");
            strSql.Append("FuZeRen=@FuZeRen,");
            strSql.Append("XiangMuJinE=@XiangMuJinE,");
            strSql.Append("XiangMuYuSuan=@XiangMuYuSuan,");
            strSql.Append("XiangMuDaXiao=@XiangMuDaXiao,");
            strSql.Append("PeiHeRenList=@PeiHeRenList,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("TimeStr=@TimeStr,");
            strSql.Append("HeTongAndFuJian=@HeTongAndFuJian,");
            strSql.Append("BackInfo=@BackInfo,");
            strSql.Append("ProjectType=@ProjectType,");
            strSql.Append("ContactPerson=@ContactPerson,");
            strSql.Append("ContactTel=@ContactTel,");
            strSql.Append("ContactEmail=@ContactEmail,");
            strSql.Append("Push=@Push,");
            strSql.Append("CompanyEvaluate=@CompanyEvaluate,");
            strSql.Append("CompanyEvaluateStar=@CompanyEvaluateStar,");
            strSql.Append("TeacherEvaluate=@TeacherEvaluate,");
            strSql.Append("TeacherEvaluateStar=@TeacherEvaluateStar,");
            strSql.Append("ProjectState=@ProjectState");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@ProjectName", SqlDbType.VarChar,200),
					new SqlParameter("@ProjectSerils", SqlDbType.VarChar,50),
					new SqlParameter("@SuoShuKeHu", SqlDbType.VarChar,200),
					new SqlParameter("@YuJiChengJiaoRiQi", SqlDbType.VarChar,50),
					new SqlParameter("@TiXingDate", SqlDbType.VarChar,5000),
					new SqlParameter("@FuZeRen", SqlDbType.VarChar,50),
					new SqlParameter("@XiangMuJinE", SqlDbType.VarChar,200),
					new SqlParameter("@XiangMuYuSuan", SqlDbType.VarChar,200),
					new SqlParameter("@XiangMuDaXiao", SqlDbType.VarChar,50),
					new SqlParameter("@PeiHeRenList", SqlDbType.VarChar,500),
					new SqlParameter("@UserName", SqlDbType.VarChar,50),
					new SqlParameter("@TimeStr", SqlDbType.DateTime),
					new SqlParameter("@HeTongAndFuJian", SqlDbType.VarChar,5000),
					new SqlParameter("@BackInfo", SqlDbType.VarChar,5000),
                    new SqlParameter("@ProjectType", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactPerson", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactTel", SqlDbType.NVarChar,50),
                    new SqlParameter("@ContactEmail", SqlDbType.NVarChar,50),
                    new SqlParameter("@Push", SqlDbType.NVarChar,50),
                    new SqlParameter("@CompanyEvaluate", SqlDbType.NVarChar,50),
                    new SqlParameter("@CompanyEvaluateStar", SqlDbType.Int,4),
                    new SqlParameter("@TeacherEvaluate", SqlDbType.NVarChar,50),
                    new SqlParameter("@TeacherEvaluateStar", SqlDbType.Int,4),
                    new SqlParameter("@ProjectState", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            parameters[1].Value = ProjectName;
            parameters[2].Value = ProjectSerils;
            parameters[3].Value = SuoShuKeHu;
            parameters[4].Value = YuJiChengJiaoRiQi;
            parameters[5].Value = TiXingDate;
            parameters[6].Value = FuZeRen;
            parameters[7].Value = XiangMuJinE;
            parameters[8].Value = XiangMuYuSuan;
            parameters[9].Value = XiangMuDaXiao;
            parameters[10].Value = PeiHeRenList;
            parameters[11].Value = UserName;
            parameters[12].Value = TimeStr;
            parameters[13].Value = HeTongAndFuJian;
            parameters[14].Value = BackInfo;
            parameters[15].Value = ProjectType;
            parameters[16].Value = ContactPerson;
            parameters[17].Value = ContactTel;
            parameters[18].Value = ContactEmail;
            parameters[19].Value = Push;
            parameters[20].Value = CompanyEvaluate;
            parameters[21].Value = CompanyEvaluateStar;
            parameters[22].Value = TeacherEvaluate;
            parameters[23].Value = TeacherEvaluateStar;
            parameters[24].Value = ProjectState;
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
            strSql.Append("delete LCXProject ");
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
            strSql.Append("select ID,ProjectName,ProjectSerils,SuoShuKeHu,YuJiChengJiaoRiQi,TiXingDate,FuZeRen,XiangMuJinE,XiangMuYuSuan,XiangMuDaXiao,PeiHeRenList,UserName,TimeStr,HeTongAndFuJian,BackInfo,ProjectType,ContactPerson,ContactTel,ContactEmail,Push,CompanyEvaluate,CompanyEvaluateStar,TeacherEvaluate,TeacherEvaluateStar,ProjectState ");
            strSql.Append(" FROM LCXProject ");
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
                ProjectName = ds.Tables[0].Rows[0]["ProjectName"].ToString();
                ProjectSerils = ds.Tables[0].Rows[0]["ProjectSerils"].ToString();
                SuoShuKeHu = ds.Tables[0].Rows[0]["SuoShuKeHu"].ToString();
                YuJiChengJiaoRiQi = ds.Tables[0].Rows[0]["YuJiChengJiaoRiQi"].ToString();
                TiXingDate = ds.Tables[0].Rows[0]["TiXingDate"].ToString();
                FuZeRen = ds.Tables[0].Rows[0]["FuZeRen"].ToString();
                XiangMuJinE = ds.Tables[0].Rows[0]["XiangMuJinE"].ToString();
                XiangMuYuSuan = ds.Tables[0].Rows[0]["XiangMuYuSuan"].ToString();
                XiangMuDaXiao = ds.Tables[0].Rows[0]["XiangMuDaXiao"].ToString();
                PeiHeRenList = ds.Tables[0].Rows[0]["PeiHeRenList"].ToString();
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["TimeStr"].ToString() != "")
                {
                    TimeStr = DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
                }
                HeTongAndFuJian = ds.Tables[0].Rows[0]["HeTongAndFuJian"].ToString();
                BackInfo = ds.Tables[0].Rows[0]["BackInfo"].ToString();
                ProjectType = ds.Tables[0].Rows[0]["ProjectType"].ToString();
                ContactPerson = ds.Tables[0].Rows[0]["ContactPerson"].ToString();
                ContactTel = ds.Tables[0].Rows[0]["ContactTel"].ToString();
                ContactEmail = ds.Tables[0].Rows[0]["ContactEmail"].ToString();
                Push = ds.Tables[0].Rows[0]["Push"].ToString();
                CompanyEvaluate = ds.Tables[0].Rows[0]["CompanyEvaluate"].ToString();
                if (ds.Tables[0].Rows[0]["CompanyEvaluateStar"].ToString() != "")
                {
                    CompanyEvaluateStar = int.Parse(ds.Tables[0].Rows[0]["CompanyEvaluateStar"].ToString());
                }
                TeacherEvaluate = ds.Tables[0].Rows[0]["TeacherEvaluate"].ToString();
                if (ds.Tables[0].Rows[0]["TeacherEvaluateStar"].ToString() != "")
                {
                    TeacherEvaluateStar = int.Parse(ds.Tables[0].Rows[0]["TeacherEvaluateStar"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ProjectState"].ToString() != "")
                {
                    ProjectState = int.Parse(ds.Tables[0].Rows[0]["ProjectState"].ToString());
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
            strSql.Append(" FROM LCXProject ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}

