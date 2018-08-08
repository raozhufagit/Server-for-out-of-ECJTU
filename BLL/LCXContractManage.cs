using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
     public class LCXContractManage
    {
        public LCXContractManage()
        { }
        #region Model
        private int _id;//ID
        private string _contractNo;//合同编号
        private string _contractName;//合同名称
        private string _contractnType;//合同类型
        private string _departmentA;//单位A
        private string _departmentB;//单位B
        private string _signatoryA;//单位A签署人
        private string _signatoryB;//单位B签署人
        private DateTime _signTime;//签署时间
        private DateTime _endTime;//结束时间
        private string _whetherSecrecy;//是否保密
        private string _contractContent;//合同内容
        private string _remarks;//备注
        private string _states;//合同状态
        private string _project;//所属项目
        private string _agreement;//所属协议
        private string _outvisiting;//所属来访
        private string _attchment;//文件
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
        public string ContractNo
        {
            set { _contractNo = value; }
            get { return _contractNo; }
        }
        /// <summary>
        /// 合同名称
        /// </summary>
        public string ContractName
        {
            set { _contractName = value; }
            get { return _contractName; }
        }
        /// <summary>
        /// 合同类型
        /// </summary>
        public string ContractType
        {
            set { _contractnType = value; }
            get { return _contractnType; }
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
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime EndTime
        {
            set { _endTime = value; }
            get { return _endTime; }
        }
        /// <summary>
        /// 是否保密
        /// </summary>
        public string WhetherSecrecy
        {
            set { _whetherSecrecy = value; }
            get { return _whetherSecrecy; }
        }
        /// <summary>
        /// 合同内容
        /// </summary>
        public string ContractContent
        {
            set { _contractContent = value; }
            get { return _contractContent; }
        }
        /// <summary>
        /// 所属项目
        /// </summary>
        public string Project
        {
            set { _project = value; }
            get { return _project; }
        }
        /// <summary>
        /// 所属协议
        /// </summary>
        public string Agreement
        {
            set { _agreement = value; }
            get { return _agreement; }
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
        /// 合同状态
        /// </summary>
        public string States
        {
            set { _states = value; }
            get { return _states; }
        }
        ///<summary>
        ///所属来访
        /// </summary>
        public string OutVisiting
        {
            set { _outvisiting = value; }
            get { return _outvisiting; }
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
        public LCXContractManage(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,ContractNo,ContractName,ContractType,DepartmentA,DepartmentB,SignatoryA,SignatoryB,SignTime,EndTime,WhetherSecrecy,ContractContent,Remarks,Project,Agreement,States,Attachment,OutVisiting ");
            strSql.Append(" FROM LCXContractManage ");
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
                ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                ContractName = ds.Tables[0].Rows[0]["ContractName"].ToString();
                ContractType = ds.Tables[0].Rows[0]["ContractType"].ToString();
                DepartmentA = ds.Tables[0].Rows[0]["DepartmentA"].ToString();
                DepartmentB = ds.Tables[0].Rows[0]["DepartmentB"].ToString();
                SignatoryA = ds.Tables[0].Rows[0]["SignatoryA"].ToString();
                SignatoryB = ds.Tables[0].Rows[0]["SignatoryB"].ToString();
                if (ds.Tables[0].Rows[0]["SignTime"].ToString() != "")
                {
                    SignTime = DateTime.Parse(ds.Tables[0].Rows[0]["SignTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                WhetherSecrecy = ds.Tables[0].Rows[0]["WhetherSecrecy"].ToString();
                ContractContent = ds.Tables[0].Rows[0]["ContractContent"].ToString();
                Project = ds.Tables[0].Rows[0]["Project"].ToString();
                Agreement = ds.Tables[0].Rows[0]["Agreement"].ToString();
                States = ds.Tables[0].Rows[0]["States"].ToString();
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                Attchment = ds.Tables[0].Rows[0]["Attchment"].ToString();
                OutVisiting = ds.Tables[0].Rows[0]["OutVisiting"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXContractManage");
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
            strSql.Append("insert into LCXContractManage(");
            strSql.Append("ContractNo,ContractName,ContractType,DepartmentA,DepartmentB,SignatoryA,SignatoryB,SignTime,EndTime,WhetherSecrecy,ContractContent,Project,Agreement,States,Remarks,Attachment,OutVisiting)");
            strSql.Append(" values (");
            strSql.Append("@ContractNo,@ContractName,@ContractType,@DepartmentA,@DepartmentB,@SignatoryA,@SignatoryB,@SignTime,@EndTime,@WhetherSecrecy,@ContractContent,@Project,@Agreement,@States,@Remarks,@Attachment,@OutVisiting)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@ContractNo", SqlDbType.VarChar,50),
                    new SqlParameter("@ContractName", SqlDbType.VarChar,50),
                    new SqlParameter("@ContractType", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentA", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryA", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignTime", SqlDbType.DateTime,50),
                    new SqlParameter("@EndTime", SqlDbType.DateTime,50),
                    new SqlParameter("@WhetherSecrecy", SqlDbType.VarChar,50),
                    new SqlParameter("@ContractContent", SqlDbType.VarChar,5000),
                    new SqlParameter("@Project", SqlDbType.VarChar,50),
                    new SqlParameter("@Agreement", SqlDbType.VarChar,50),
                    new SqlParameter("@States", SqlDbType.VarChar,5),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,50),
                    new SqlParameter("@Attachment", SqlDbType.VarChar,500),
                    new SqlParameter("OutVisiting",SqlDbType.VarChar,50)
                    };
            parameters[0].Value = ContractNo;
            parameters[1].Value = ContractName;
            parameters[2].Value = ContractType;
            parameters[3].Value = DepartmentA;
            parameters[4].Value = DepartmentB;
            parameters[5].Value = SignatoryA;
            parameters[6].Value = SignatoryB;
            parameters[7].Value = SignTime;
            parameters[8].Value = EndTime;
            parameters[9].Value = WhetherSecrecy;
            parameters[10].Value = ContractContent;
            parameters[11].Value = Project;
            parameters[12].Value = Agreement;
            parameters[13].Value = States;
            parameters[14].Value = Remarks;
            parameters[15].Value = Attchment;
            parameters[16].Value = OutVisiting;

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
            strSql.Append("update LCXContractManage set ");
            strSql.Append("ContractNo=@ContractNo,");
            strSql.Append("ContractName=@ContractName,");
            strSql.Append("ContractType=@ContractType,");
            strSql.Append("DepartmentA=@DepartmentA,");
            strSql.Append("DepartmentB=@DepartmentB,");
            strSql.Append("SignatoryA=@SignatoryA,");
            strSql.Append("SignatoryB=@SignatoryB,");
            strSql.Append("SignTime=@SignTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("WhetherSecrecy=@WhetherSecrecy,");
            strSql.Append("ContractContent=@ContractContent,");
            strSql.Append("Project=@Project,");
            strSql.Append("Agreement=@Agreement,");
            strSql.Append("States=@States,");
            strSql.Append("Remarks=@Remarks,");
            strSql.Append("Attachment=@Attachment,");
            strSql.Append("OutVisiting=@OutVisiting ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@ContractNo", SqlDbType.VarChar,50),
                    new SqlParameter("@ContractName", SqlDbType.VarChar,50),
                    new SqlParameter("@ContractType", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentA", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryA", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignTime", SqlDbType.DateTime,50),
                    new SqlParameter("@EndTime", SqlDbType.DateTime,50),
                    new SqlParameter("@WhetherSecrecy", SqlDbType.VarChar,5),
                    new SqlParameter("@ContractContent", SqlDbType.VarChar,5000),
                    new SqlParameter("@Project", SqlDbType.VarChar,50),
                    new SqlParameter("@Agreement", SqlDbType.VarChar,50),
                    new SqlParameter("@States", SqlDbType.VarChar,5),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,500),
                    new SqlParameter("@Attachment", SqlDbType.VarChar,500),
                    new SqlParameter("@OutVisiting",SqlDbType.VarChar,50)
                    };
            parameters[0].Value = ID;
            parameters[1].Value = ContractNo;
            parameters[2].Value = ContractName;
            parameters[3].Value = ContractType;
            parameters[4].Value = DepartmentA;
            parameters[5].Value = DepartmentB;
            parameters[6].Value = SignatoryA;
            parameters[7].Value = SignatoryB;
            parameters[8].Value = SignTime;
            parameters[9].Value = EndTime;
            parameters[10].Value = WhetherSecrecy;
            parameters[11].Value = ContractContent;
            parameters[12].Value = Project;
            parameters[13].Value = Agreement;
            parameters[14].Value = Remarks;
            parameters[15].Value = States;
            parameters[16].Value = Attchment;
            parameters[17].Value = OutVisiting;

            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXContractManage ");
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
            strSql.Append("select  top 1 ID,ContractNo,ContractName,ContractType,DepartmentA,DepartmentB,SignatoryA,SignatoryB,SignTime,EndTime,WhetherSecrecy,ContractContent,Remarks,Project,Agreement,States,Attachment,OutVisiting ");
            strSql.Append(" FROM LCXContractManage ");
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
                ContractNo = ds.Tables[0].Rows[0]["ContractNo"].ToString();
                ContractName = ds.Tables[0].Rows[0]["ContractName"].ToString();
                ContractType = ds.Tables[0].Rows[0]["ContractType"].ToString();
                DepartmentA = ds.Tables[0].Rows[0]["DepartmentA"].ToString();
                DepartmentB = ds.Tables[0].Rows[0]["DepartmentB"].ToString();
                SignatoryA = ds.Tables[0].Rows[0]["SignatoryA"].ToString();
                SignatoryB = ds.Tables[0].Rows[0]["SignatoryB"].ToString();
                if (ds.Tables[0].Rows[0]["SignTime"].ToString() != "")
                {
                    SignTime = DateTime.Parse(ds.Tables[0].Rows[0]["SignTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                WhetherSecrecy = ds.Tables[0].Rows[0]["WhetherSecrecy"].ToString();
                ContractContent = ds.Tables[0].Rows[0]["ContractContent"].ToString();
                Project = ds.Tables[0].Rows[0]["Project"].ToString();
                Agreement = ds.Tables[0].Rows[0]["Agreement"].ToString();
                States = ds.Tables[0].Rows[0]["States"].ToString();
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                Attchment = ds.Tables[0].Rows[0]["Attachment"].ToString();
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
            strSql.Append(" FROM LCXContractManage  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
