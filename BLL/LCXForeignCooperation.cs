using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用


namespace LCX.BLL
{
    public class LCXForeignCooperation
    {
        public LCXForeignCooperation()
        { }
        #region Model
        private int _id;//ID
        private string _cagreementNo;//合作编号
        private string _cagreementName;//合作名称 
        private string _departmentA;//单位A
        private string _departmentB;//单位B
        private string _signatoryA;//单位A签署人
        private string _signatoryB;//单位B签署人
        private DateTime _signTime;//签署时间
        private string _content;//合作内容
        private string _strategiCoop;//所属战略合作协议
        private string _remarks;//备注
        private string _states;//合同状态
        private string _attchment;//文件
        private string _outvisiting;//所属出访
        ///<summary>
        ///
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 合同编号
        /// </summary>
        public string CAgreementNo
        {
            set { _cagreementNo = value; }
            get { return _cagreementNo; }
        }
        /// <summary>
        /// 合同名称
        /// </summary>
        public string CAgreementName
        {
            set { _cagreementName = value; }
            get { return _cagreementName; }
        }
        /// <summary>
        /// 单位A
        /// </summary>
        public string DepartmentA
        {
            set { _departmentA = value; }
            get { return _departmentA; }
        }
        /// <summary>
        /// 单位B
        /// </summary>
        public string DepartmentB
        {
            set { _departmentB = value; }
            get { return _departmentB; }
        }
        /// <summary>
        /// 签署人A
        /// </summary>
        public string SignatoryA
        {
            set { _signatoryA = value; }
            get { return _signatoryA; }
        }
        /// <summary>
        /// 签署人B
        /// </summary>
        public string SignatoryB
        {
            set { _signatoryB = value; }
            get { return _signatoryB; }
        }
        /// <summary>
        /// 签署时间
        /// </summary>
        public DateTime SignTime
        {
            set { _signTime = value; }
            get { return _signTime; }
        }
        ///<summary>
        ///所属出访
        /// </summary>
        public string OutVisiting
        {
            set { _outvisiting = value; }
            get { return _outvisiting; }
        }
        /// <summary>
        /// 所属战略合作协议
        /// </summary>
        public string StrategiCooperation
        {
            set { _strategiCoop = value; }
            get { return _strategiCoop; }
        }
        /// <summary>
        /// 合作内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        /// 合作状态
        /// </summary>
        public string States
        {
            set { _states = value; }
            get { return _states; }
        }

        /// <summary>
        ///附件
        /// </summary>
        public string Attchment
        {
            set { _attchment = value; }
            get { return _attchment; }
        }
        #endregion Model

        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXForeignCooperation(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,CAgreementNo,CAgreementName,DepartmentA,DepartmentB,SignatoryA,SignatoryB,SignTime,Content,Remarks,States,Attachment,StrategiCooperation,OutVisiting");
            strSql.Append(" FROM LCXForeignCooperation ");
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
                CAgreementNo = ds.Tables[0].Rows[0]["CAgreementNo"].ToString();
                CAgreementName = ds.Tables[0].Rows[0]["CAgreementName"].ToString();
                DepartmentA = ds.Tables[0].Rows[0]["DepartmentA"].ToString();
                DepartmentB = ds.Tables[0].Rows[0]["DepartmentB"].ToString();
                SignatoryA = ds.Tables[0].Rows[0]["SignatoryA"].ToString();
                SignatoryB = ds.Tables[0].Rows[0]["SignatoryB"].ToString();
                if (ds.Tables[0].Rows[0]["SignTime"].ToString() != "")
                {
                    SignTime = DateTime.Parse(ds.Tables[0].Rows[0]["SignTime"].ToString());
                }
                Content = ds.Tables[0].Rows[0]["Content"].ToString();
                States = ds.Tables[0].Rows[0]["States"].ToString();
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                Attchment = ds.Tables[0].Rows[0]["Attchment"].ToString();
                StrategiCooperation = ds.Tables[0].Rows[0]["StrategiCooperation"].ToString();
                OutVisiting = ds.Tables[0].Rows[0]["OutVisiting"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXForeignCooperation");
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
            strSql.Append("insert into LCXForeignCooperation(");
            strSql.Append("CAgreementNo,CAgreementName,DepartmentA,DepartmentB,SignatoryA,SignatoryB,SignTime,Content,States,Remarks,Attachment,StrategiCooperation,OutVisiting)");
            strSql.Append(" values (");
            strSql.Append("@CAgreementNo,@CAgreementName,@DepartmentA,@DepartmentB,@SignatoryA,@SignatoryB,@SignTime,@Content,@States,@Remarks,@Attchment,@StrategiCooperation,@OutVisiting)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@CAgreementNo", SqlDbType.VarChar,50),
                    new SqlParameter("@CAgreementName", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentA", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryA", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignTime", SqlDbType.DateTime,50),
                    new SqlParameter("@Content", SqlDbType.VarChar,5000),
                    new SqlParameter("@States", SqlDbType.VarChar,5),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,50),
                    new SqlParameter("@Attchment", SqlDbType.VarChar,500),
                    new SqlParameter("@StrategiCooperation",SqlDbType.VarChar,100),
                    new SqlParameter("@OutVisiting",SqlDbType.VarChar,50)
                    };
            parameters[0].Value = CAgreementNo;
            parameters[1].Value = CAgreementName;
            parameters[2].Value = DepartmentA;
            parameters[3].Value = DepartmentB;
            parameters[4].Value = SignatoryA;
            parameters[5].Value = SignatoryB;
            parameters[6].Value = SignTime;
            parameters[7].Value =Content;
            parameters[8].Value = States;
            parameters[9].Value = Remarks;
            parameters[10].Value = Attchment;
            parameters[11].Value = StrategiCooperation;
            parameters[12].Value = OutVisiting;
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
            strSql.Append("update LCXForeignCooperation set ");
            strSql.Append("CAgreementNo=@CAgreementNo,");
            strSql.Append("CAgreementName=@CAgreementName,");
            strSql.Append("DepartmentA=@DepartmentA,");
            strSql.Append("DepartmentB=@DepartmentB,");
            strSql.Append("SignatoryA=@SignatoryA,");
            strSql.Append("SignatoryB=@SignatoryB,");
            strSql.Append("SignTime=@SignTime,");
            strSql.Append("Content=@Content,");
            strSql.Append("States=@States,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("Attachment=@Attchment,");
            strSql.Append("StrategiCooperation=@StrategiCooperation,");
            strSql.Append("OutVisiting=@OutVisiting ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@CAgreementNo", SqlDbType.VarChar,50),
                    new SqlParameter("@CAgreementName", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentA", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryA", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignTime", SqlDbType.DateTime,50),
                    new SqlParameter("@Content", SqlDbType.VarChar,5000),
                    new SqlParameter("@States", SqlDbType.VarChar,5),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,500),
                    new SqlParameter("@Attchment", SqlDbType.VarChar,500),
                    new SqlParameter("@StrategiCooperation", SqlDbType.VarChar,50),
                    new SqlParameter("@OutVisiting", SqlDbType.VarChar,50)
                    };
            parameters[0].Value = ID;
            parameters[1].Value = CAgreementNo;
            parameters[2].Value = CAgreementName;
            parameters[3].Value = DepartmentA;
            parameters[4].Value = DepartmentB;
            parameters[5].Value = SignatoryA;
            parameters[6].Value = SignatoryB;
            parameters[7].Value = SignTime;
            parameters[8].Value = Content;
            parameters[9].Value = States;
            parameters[10].Value = Remarks;           
            parameters[11].Value = Attchment;
            parameters[12].Value = StrategiCooperation;
            parameters[13].Value = OutVisiting;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXForeignCooperation ");
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
            strSql.Append("select  top 1 ID,CAgreementNo,CAgreementName,DepartmentA,DepartmentB,SignatoryA,SignatoryB,SignTime,Content,Remarks,States,Attachment,StrategiCooperation,OutVisiting");
            strSql.Append(" FROM LCXForeignCooperation ");
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
                CAgreementNo = ds.Tables[0].Rows[0]["CAgreementNo"].ToString();
                CAgreementName = ds.Tables[0].Rows[0]["CAgreementName"].ToString();
                DepartmentA = ds.Tables[0].Rows[0]["DepartmentA"].ToString();
                DepartmentB = ds.Tables[0].Rows[0]["DepartmentB"].ToString();
                SignatoryA = ds.Tables[0].Rows[0]["SignatoryA"].ToString();
                SignatoryB = ds.Tables[0].Rows[0]["SignatoryB"].ToString();
                if (ds.Tables[0].Rows[0]["SignTime"].ToString() != "")
                {
                    SignTime = DateTime.Parse(ds.Tables[0].Rows[0]["SignTime"].ToString());
                }
                Content = ds.Tables[0].Rows[0]["Content"].ToString();
                States = ds.Tables[0].Rows[0]["States"].ToString();
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                Attchment = ds.Tables[0].Rows[0]["Attachment"].ToString();
                StrategiCooperation = ds.Tables[0].Rows[0]["StrategiCooperation"].ToString();
                OutVisiting = ds.Tables[0].Rows[0]["OutVisiting"].ToString();
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LCXForeignCooperation ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
