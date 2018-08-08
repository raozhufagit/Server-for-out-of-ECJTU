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
    public class OutVisit
    {
        public OutVisit()
        { }
        #region Model  ///区域模型  变量名看意思 不想打了(>...<)!!!
        private int _ID;
        private DateTime? _VisitDate;
        private string _VisitLenth;
        private string _LeadPerson;
        private string _FlowPerson;
        private string _VisitDepartment;
        private string _VisitGoal;
        private string _VisitCost;
        private string _EnteringPerson;
        private string _RelationCOA;
        private string _RelationCoPro;
        private string _Otherexplain;
        private string _ApprovalPerson;
        private DateTime? _ApprovalDate;
        private string _ApprovalOpinion;
        private DateTime? _VisitReportDate;
        private string _VisitResultCOA;
        private string _VisitResultCopro;
        private string _VisitOtherResult;
        private string _VisitResultAttachment;
        private int _Visitstat;
        /// <summary>
        /// 编号
        /// </summary>
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        /// <summary>
        /// 出访日期
        /// </summary>
        public DateTime? VisitDate
        {
            set { _VisitDate = value; }
            get { return _VisitDate; }
        }

        /// <summary>
        /// 出访时长
        /// </summary>
        public string VisitLenth
        {
            set { _VisitLenth = value; }
            get { return _VisitLenth; }
        }

        /// <summary>
        /// 出访领队
        /// </summary>
        public string LeadPerson
        {
            set { _LeadPerson = value; }
            get { return _LeadPerson; }
        }

        /// <summary>
        /// 出访随行人员
        /// </summary>
        public string FlowPerson
        {
            set { _FlowPerson = value; }
            get { return _FlowPerson; }
        }

        /// <summary>
        /// 出访目的地
        /// </summary>
        public string VisitDepartment
        {
            set { _VisitDepartment = value; }
            get { return _VisitDepartment; }
        }

        /// <summary>
        /// 出访的目的
        /// </summary>
        public string VisitGoal
        {
            set { _VisitGoal = value; }
            get { return _VisitGoal; }
        }

        /// <summary>
        /// 出访经费
        /// </summary>
        public string VisitCost
        {
            set { _VisitCost = value; }
            get { return _VisitCost; }
        }

        /// <summary>
        /// 录入出访的人员
        /// </summary>
        public string EnteringPerson
        {
            set { _EnteringPerson = value; }
            get { return _EnteringPerson; }
        }

        /// <summary>
        /// 出访有关的战略合作协议
        /// </summary>
        public string RelationCOA
        {
            set { _RelationCOA = value; }
            get { return _RelationCOA; }
        }

        /// <summary>
        /// 出访有关的合作项目
        /// </summary>
        public string RelationCoPro
        {
            set { _RelationCoPro = value; }
            get { return _RelationCoPro; }
        }

        /// <summary>
        /// 出访其他的说明
        /// </summary>
        public string Otherexplain
        {
            set { _Otherexplain = value; }
            get { return _Otherexplain; }
        }

        /// <summary>
        /// 评审人
        /// </summary>
        public string ApprovalPerson
        {
            set { _ApprovalPerson = value; }
            get { return _ApprovalPerson; }
        }

        /// <summary>
        /// 评审日期
        /// </summary>
        public DateTime? ApprovalDate
        {
            set { _ApprovalDate = value; }
            get { return _ApprovalDate; }
        }

        /// <summary>
        /// 评审人意见
        /// </summary>
        public string ApprovalOpinion
        {
            set { _ApprovalOpinion = value; }
            get { return _ApprovalOpinion; }
        }

        /// <summary>
        /// 报告填写时间
        /// </summary>
        public DateTime? VisitReportDate
        {
            set { _VisitReportDate = value; }
            get { return _VisitReportDate; }
        }
        /// <summary>
        /// 报告中的战略合作协议
        /// </summary>
        public string VisitResultCOA
        {
            set { _VisitResultCOA = value; }
            get { return _VisitResultCOA; }
        }

        /// <summary>
        /// 报告中的合作项目
        /// </summary>
        public string VisitResultCopro
        {
            set { _VisitResultCopro = value; }
            get { return _VisitResultCopro; }
        }

        /// <summary>
        ///报告其他成果
        /// </summary>
        public String VisitOtherResult
        {
            set { _VisitOtherResult = value; }
            get { return _VisitOtherResult; }
        }

        /// <summary>
        /// 报告附件
        /// </summary>
        public string VisitResultAttachment
        {
            set { _VisitResultAttachment = value; }
            get { return _VisitResultAttachment; }
        }
        /// <summary>
        /// 出访状态
        /// </summary>
        public int Visitstat
        {
            set { _Visitstat = value; }
            get { return _Visitstat; }
        }
        #endregion Model


        #region  成员方法
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public OutVisit(int idstr)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select ID,VisitDate,VisitLenth,LeadPerson,FlowPerson,VisitDepartment,VisitGoal,VisitCost,EnteringPerson,RelationCOA,RelationCoPro,Otherexplain,ApprovalPerson,ApprovalDate,ApprovalOpinion,VisitReportDate,VisitResultCOA,VisitResultCopro,VisitOtherResult,VisitResultAttachment,Visitstat ");
            strSql.Append(" FROM OutVisit ");
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
                if (ds.Tables[0].Rows[0]["VisitDate"].ToString() != "")
                {
                    VisitDate = DateTime.Parse(ds.Tables[0].Rows[0]["VisitDate"].ToString());
                }
                VisitLenth = ds.Tables[0].Rows[0]["VisitLenth"].ToString();
                LeadPerson = ds.Tables[0].Rows[0]["LeadPerson"].ToString();
                FlowPerson = ds.Tables[0].Rows[0]["FlowPerson"].ToString();
                VisitDepartment = ds.Tables[0].Rows[0]["VisitDepartment"].ToString();
                VisitGoal = ds.Tables[0].Rows[0]["VisitGoal"].ToString();
                VisitCost = ds.Tables[0].Rows[0]["VisitCost"].ToString();
                EnteringPerson = ds.Tables[0].Rows[0]["EnteringPerson"].ToString();
                RelationCOA = ds.Tables[0].Rows[0]["RelationCOA"].ToString();
                RelationCoPro = ds.Tables[0].Rows[0]["RelationCoPro"].ToString();
                Otherexplain = ds.Tables[0].Rows[0]["Otherexplain"].ToString();
                ApprovalPerson = ds.Tables[0].Rows[0]["ApprovalPerson"].ToString();
                if (ds.Tables[0].Rows[0]["ApprovalDate"].ToString() != "")
                {
                    ApprovalDate = DateTime.Parse(ds.Tables[0].Rows[0]["ApprovalDate"].ToString());
                }
                ApprovalOpinion = ds.Tables[0].Rows[0]["ApprovalOpinion"].ToString();
                if (ds.Tables[0].Rows[0]["VisitReportDate"].ToString() != "")
                {
                    VisitReportDate = DateTime.Parse(ds.Tables[0].Rows[0]["VisitReportDate"].ToString());
                }
                VisitResultCOA = ds.Tables[0].Rows[0]["VisitResultCOA"].ToString();
                VisitResultCopro = ds.Tables[0].Rows[0]["VisitResultCopro"].ToString();
                VisitOtherResult = ds.Tables[0].Rows[0]["VisitOtherResult"].ToString();
                VisitResultAttachment = ds.Tables[0].Rows[0]["VisitResultAttachment"].ToString();
                Visitstat = int.Parse(ds.Tables[0].Rows[0]["Visitstat"].ToString());
            }
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {

            return DbHelperSQL.GetMaxID("ID", "OutVisit");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from OutVisit");
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
            //
            //
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into OutVisit(");
            strSql.Append("VisitDate,VisitLenth,LeadPerson)");
            strSql.Append(" values (");
            strSql.Append("@VisitDate,@VisitLenth,@LeadPerson)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@VisitDate", SqlDbType.DateTime),
                new SqlParameter("@VisitLenth", SqlDbType.VarChar,50),
                new SqlParameter("@LeadPerson", SqlDbType.VarChar,50)
                /*new SqlParameter("@FlowPerson", SqlDbType.VarChar,50),
                new SqlParameter("@VisitDepartment", SqlDbType.VarChar,50),
                new SqlParameter("@VisitGoal", SqlDbType.Text),
                new SqlParameter("@VisitCost", SqlDbType.VarChar,50),
                new SqlParameter("@EnteringPerson", SqlDbType.VarChar,50),
                new SqlParameter("@RelationCOA", SqlDbType.VarChar,50),
                new SqlParameter("@RelationCoPro", SqlDbType.VarChar,50),
                new SqlParameter("@Otherexplain", SqlDbType.VarChar,50),
                new SqlParameter("@ApprovalPerson", SqlDbType.VarChar,50),
                new SqlParameter("@ApprovalDate", SqlDbType.DateTime),
                new SqlParameter("@ApprovalOpinion", SqlDbType.VarChar,50),
                new SqlParameter("@VisitReportDate", SqlDbType.DateTime),
                new SqlParameter("@VisitResultCOA", SqlDbType.VarChar,50),
                new SqlParameter("@VisitResultCopro", SqlDbType.VarChar,50),
                new SqlParameter("@VisitOtherResult", SqlDbType.Text),
                new SqlParameter("@VisitResultAttachment", SqlDbType.VarChar,500)*/};
            parameters[0].Value = VisitDate;
            parameters[1].Value = VisitLenth;
            parameters[2].Value = LeadPerson;
            /*parameters[3].Value = FlowPerson;
            parameters[4].Value = VisitDepartment;
            parameters[5].Value = VisitGoal;
            parameters[6].Value = VisitCost;
            parameters[7].Value = EnteringPerson;
            parameters[8].Value = RelationCOA;
            parameters[9].Value = RelationCoPro;
            parameters[10].Value = Otherexplain;
            parameters[11].Value = ApprovalPerson;
            parameters[12].Value = ApprovalDate;
            parameters[13].Value = ApprovalOpinion;
            parameters[14].Value = VisitReportDate;
            parameters[15].Value = VisitResultCOA;
            parameters[16].Value = VisitResultCopro;
            parameters[17].Value = VisitOtherResult;
            parameters[18].Value = VisitResultAttachment;*/
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
            strSql.Append("update OutVisit set ");
            strSql.Append("VisitDate=@VisitDate,");
            strSql.Append("VisitLenth=@VisitLenth,");
            strSql.Append("LeadPerson=@LeadPerson,");
            strSql.Append("FlowPerson=@FlowPerson,");
            strSql.Append("VisitDepartment=@VisitDepartment,");
            strSql.Append("VisitGoal=@VisitGoal,");
            strSql.Append("VisitCost=@VisitCost,");
            strSql.Append("EnteringPerson=@EnteringPerson,");
            strSql.Append("RelationCOA=@RelationCOA,");
            strSql.Append("RelationCoPro=@RelationCoPro,");
            strSql.Append("Otherexplain=@Otherexplain,");
            strSql.Append("ApprovalPerson=@ApprovalPerson,");
            strSql.Append("ApprovalDate=@ApprovalDate,");
            strSql.Append("ApprovalOpinion=@ApprovalOpinion,");
            strSql.Append("VisitReportDate=@VisitReportDate,");
            strSql.Append("VisitResultCOA=@VisitResultCOA,");
            strSql.Append("VisitResultCopro=@VisitResultCopro,");
            strSql.Append("VisitOtherResult=@VisitOtherResult,");
            strSql.Append("VisitResultAttachment=@VisitResultAttachment,");
            strSql.Append("Visitstat=@Visitstat ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
                new SqlParameter("@VisitDate", SqlDbType.DateTime),
                new SqlParameter("@VisitLenth", SqlDbType.VarChar,50),
                new SqlParameter("@LeadPerson", SqlDbType.VarChar,50),
                new SqlParameter("@FlowPerson", SqlDbType.VarChar,50),
                new SqlParameter("@VisitDepartment", SqlDbType.VarChar,50),
                new SqlParameter("@VisitGoal", SqlDbType.Text),
                new SqlParameter("@VisitCost", SqlDbType.VarChar,50),
                new SqlParameter("@EnteringPerson", SqlDbType.VarChar,50),
                new SqlParameter("@RelationCOA", SqlDbType.VarChar,50),
                new SqlParameter("@RelationCoPro", SqlDbType.VarChar,50),
                new SqlParameter("@Otherexplain", SqlDbType.VarChar,50),
                new SqlParameter("@ApprovalPerson", SqlDbType.VarChar,50),
                new SqlParameter("@ApprovalDate", SqlDbType.DateTime),
                new SqlParameter("@ApprovalOpinion", SqlDbType.VarChar,50),
                new SqlParameter("@VisitReportDate", SqlDbType.DateTime),
                new SqlParameter("@VisitResultCOA", SqlDbType.VarChar,50),
                new SqlParameter("@VisitResultCopro", SqlDbType.VarChar,50),
                new SqlParameter("@VisitOtherResult", SqlDbType.Text),
                new SqlParameter("@VisitResultAttachment", SqlDbType.VarChar,500),
                new SqlParameter("@Visitstat", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            parameters[1].Value = VisitDate;
            parameters[2].Value = VisitLenth;
            parameters[3].Value = LeadPerson;
            parameters[4].Value = FlowPerson;
            parameters[5].Value = VisitDepartment;
            parameters[6].Value = VisitGoal;
            parameters[7].Value = VisitCost;
            parameters[8].Value = EnteringPerson;
            parameters[9].Value = RelationCOA;
            parameters[10].Value = RelationCoPro;
            parameters[11].Value = Otherexplain;
            parameters[12].Value = ApprovalPerson;
            parameters[13].Value = ApprovalDate;
            parameters[14].Value = ApprovalOpinion;
            parameters[15].Value = VisitReportDate;
            parameters[16].Value = VisitResultCOA;
            parameters[17].Value = VisitResultCopro;
            parameters[18].Value = VisitOtherResult;
            parameters[19].Value = VisitResultAttachment;
            parameters[20].Value = Visitstat;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from OutVisit ");
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
            strSql.Append("select ID,VisitDate,VisitLenth,LeadPerson,FlowPerson,VisitDepartment,VisitGoal,VisitCost,EnteringPerson,RelationCOA,RelationCoPro,Otherexplain,ApprovalPerson,ApprovalDate,ApprovalOpinion,VisitReportDate,VisitResultCOA,VisitResultCopro,VisitOtherResult,VisitResultAttachment,Visitstat ");
            strSql.Append(" FROM OutVisit ");
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
                if (ds.Tables[0].Rows[0]["VisitDate"].ToString() != "")
                {
                    VisitDate = DateTime.Parse(ds.Tables[0].Rows[0]["VisitDate"].ToString());
                }
                VisitLenth = ds.Tables[0].Rows[0]["VisitLenth"].ToString();
                LeadPerson = ds.Tables[0].Rows[0]["LeadPerson"].ToString();
                FlowPerson = ds.Tables[0].Rows[0]["FlowPerson"].ToString();
                VisitDepartment = ds.Tables[0].Rows[0]["VisitDepartment"].ToString();
                VisitGoal = ds.Tables[0].Rows[0]["VisitGoal"].ToString();
                VisitCost = ds.Tables[0].Rows[0]["VisitCost"].ToString();
                EnteringPerson = ds.Tables[0].Rows[0]["EnteringPerson"].ToString();
                RelationCOA = ds.Tables[0].Rows[0]["RelationCOA"].ToString();
                RelationCoPro = ds.Tables[0].Rows[0]["RelationCoPro"].ToString();
                Otherexplain = ds.Tables[0].Rows[0]["Otherexplain"].ToString();
                ApprovalPerson = ds.Tables[0].Rows[0]["ApprovalPerson"].ToString();
                if (ds.Tables[0].Rows[0]["ApprovalDate"].ToString() != "")
                {
                    ApprovalDate = DateTime.Parse(ds.Tables[0].Rows[0]["ApprovalDate"].ToString());
                }
                ApprovalOpinion = ds.Tables[0].Rows[0]["ApprovalOpinion"].ToString();
                if (ds.Tables[0].Rows[0]["VisitReportDate"].ToString() != "")
                {
                    VisitReportDate = DateTime.Parse(ds.Tables[0].Rows[0]["VisitReportDate"].ToString());
                }
                VisitResultCOA = ds.Tables[0].Rows[0]["VisitResultCOA"].ToString();
                VisitResultCOA = ds.Tables[0].Rows[0]["VisitResultCOA"].ToString();
                VisitResultCopro = ds.Tables[0].Rows[0]["VisitResultCopro"].ToString();
                VisitOtherResult = ds.Tables[0].Rows[0]["VisitOtherResult"].ToString();
                VisitResultAttachment = ds.Tables[0].Rows[0]["VisitResultAttachment"].ToString();
                Visitstat = int.Parse(ds.Tables[0].Rows[0]["Visitstat"].ToString());
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM OutVisit ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        public int Update2()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update OutVisit set ");
            strSql.Append("VisitReportDate=@VisitReportDate,");
            strSql.Append("VisitResultCOA=@VisitResultCOA,");
            strSql.Append("VisitResultCopro=@VisitResultCopro,");
            strSql.Append("VisitOtherResult=@VisitOtherResult,");
            strSql.Append("VisitResultAttachment=@VisitResultAttachment,");
            strSql.Append("Visitstat=@Visitstat ");
            strSql.Append(" where ID=@ID ");

            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
                new SqlParameter("@VisitReportDate", SqlDbType.DateTime),
                new SqlParameter("@VisitResultCOA", SqlDbType.VarChar,50),
                new SqlParameter("@VisitResultCopro", SqlDbType.VarChar,50),
                new SqlParameter("@VisitOtherResult", SqlDbType.Text),
                new SqlParameter("@VisitResultAttachment", SqlDbType.VarChar,500),
                new SqlParameter("@Visitstat", SqlDbType.Int,4)};
            parameters[0].Value = ID;
            parameters[1].Value = VisitReportDate;
            parameters[2].Value = VisitResultCOA;
            parameters[3].Value = VisitResultCopro;
            parameters[4].Value = VisitOtherResult;
            parameters[5].Value = VisitResultAttachment;
            parameters[6].Value = Visitstat;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        #endregion  成员方法
    }


}
