using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    /// <summary>
    /// 类LCXCoopAgreement
    /// </summary>
    public class LCXCoopAgreement
    {
        public LCXCoopAgreement()
        { }
        #region Model
        private int _id;
        private string _title;
        private string _departmentA;
        private string _departmentB;
        private string _signatoryA;
        private string _signatoryB;
        private DateTime _signTime;
        private string _states;
        private string _content;
        private string _attchment;
        private string _outvisiting;
        ///<summary>
        ///
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 协议标题
        /// </summary>
        public string Title
        {
            set { _title = value; }
            get { return _title; }
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
        /// 合作状态
        /// </summary>
        public string States
        {
            set { _states = value; }
            get { return _states; }
        }
        /// <summary>
        /// 合作协议内容
        /// </summary>
        public string Content
        {
            set { _content = value; }
            get { return _content; }
        }
        /// <summary>
        ///附件
        /// </summary>
        public string Attchment
        {
            set { _attchment = value; }
            get { return _attchment; }
        }
        ///<summary>
        ///所属来访
        /// </summary>
        public string OutVisiting
        {
            set { _outvisiting = value; }
            get { return _outvisiting; }
        }
        #endregion Model


        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXCoopAgreement(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,Title,DepartmentA,DepartmentB,SignatoryA,SignatoryB,SignTime,States,Content,Attchment,OutVisiting ");
            strSql.Append(" FROM LCXCooperation ");
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
                Title = ds.Tables[0].Rows[0]["Title"].ToString();
                DepartmentA = ds.Tables[0].Rows[0]["DepartmentA"].ToString();
                DepartmentB = ds.Tables[0].Rows[0]["DepartmentB"].ToString();
                SignatoryA = ds.Tables[0].Rows[0]["SignatoryA"].ToString();
                SignatoryB = ds.Tables[0].Rows[0]["SignatoryB"].ToString();
                if (ds.Tables[0].Rows[0]["SignTime"].ToString() != "")
                {
                    SignTime = DateTime.Parse(ds.Tables[0].Rows[0]["SignTime"].ToString());
                }
                States = ds.Tables[0].Rows[0]["States"].ToString();
                Content = ds.Tables[0].Rows[0]["Content"].ToString();
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
            strSql.Append("select count(1) from LCXCooperation");
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
            strSql.Append("insert into LCXCooperation(");
            strSql.Append("Title,DepartmentA,DepartmentB,SignatoryA,SignatoryB,SignTime,States,Content,Attchment,OutVisiting)");
            strSql.Append(" values (");
            strSql.Append("@Title,@DepartmentA,@DepartmentB,@SignatoryA,@SignatoryB,@SignTime,@States,@Content,@Attchment,@OutVisiting)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@Title", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentA", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryA", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignTime", SqlDbType.DateTime,50),
                    new SqlParameter("@States", SqlDbType.VarChar,500),
                    new SqlParameter("@Content", SqlDbType.VarChar,5000),
                    new SqlParameter("@Attchment", SqlDbType.VarChar,500),
                    new SqlParameter("@OutVisiting",SqlDbType.VarChar,50)
                    };
            parameters[0].Value = Title;
            parameters[1].Value = DepartmentA;
            parameters[2].Value = DepartmentB;
            parameters[3].Value = SignatoryA;
            parameters[4].Value = SignatoryB;
            parameters[5].Value = SignTime;
            parameters[6].Value = States;
            parameters[7].Value = Content;
            parameters[8].Value = Attchment;
            parameters[9].Value = OutVisiting;

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
            strSql.Append("update LCXCooperation set ");
            strSql.Append("Title=@Title,");
            strSql.Append("DepartmentA=@DepartmentA,");
            strSql.Append("DepartmentB=@DepartmentB,");
            strSql.Append("SignatoryA=@SignatoryA,");
            strSql.Append("SignatoryB=@SignatoryB,");
            strSql.Append("SignTime=@SignTime,");
            strSql.Append("States=@States,");
            strSql.Append("Content=@Content,");
            strSql.Append("Aattchment=@Attchment,");
            strSql.Append("OutVisiting=@OutVisiting ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@Title", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentA", SqlDbType.VarChar,50),
                    new SqlParameter("@DepartmentB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryA", SqlDbType.VarChar,50),
                    new SqlParameter("@SignatoryB", SqlDbType.VarChar,50),
                    new SqlParameter("@SignTime", SqlDbType.DateTime,50),
                    new SqlParameter("@States", SqlDbType.VarChar,500),
                    new SqlParameter("@Content", SqlDbType.VarChar,5000),
                    new SqlParameter("@Attchment", SqlDbType.VarChar,500),
                    new SqlParameter("@OutVisiting",SqlDbType.VarChar,50)
                    };
            parameters[0].Value = ID;
            parameters[1].Value = Title;
            parameters[2].Value = DepartmentA;
            parameters[3].Value = DepartmentB;
            parameters[4].Value = SignatoryA;
            parameters[5].Value = SignatoryB;
            parameters[6].Value = SignTime;
            parameters[7].Value = States;
            parameters[8].Value = Content;
            parameters[9].Value = Attchment;
            parameters[10].Value = OutVisiting;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXCooperation ");
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
            strSql.Append("select  top 1 ID,Title,DepartmentA,DepartmentB,SignatoryA,SignatoryB,SignTime,States,Content,Attchment,OutVisiting");
            strSql.Append(" FROM LCXCooperation ");
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
                Title = ds.Tables[0].Rows[0]["Title"].ToString();
                DepartmentA = ds.Tables[0].Rows[0]["DepartmentA"].ToString();
                DepartmentB = ds.Tables[0].Rows[0]["DepartmentB"].ToString();
                SignatoryA = ds.Tables[0].Rows[0]["SignatoryA"].ToString();
                SignatoryB = ds.Tables[0].Rows[0]["SignatoryB"].ToString();
                if (ds.Tables[0].Rows[0]["SignTime"].ToString() != "")
                {
                    SignTime = DateTime.Parse(ds.Tables[0].Rows[0]["SignTime"].ToString());
                }
                States = ds.Tables[0].Rows[0]["States"].ToString();
                Content = ds.Tables[0].Rows[0]["Content"].ToString();
                Attchment = ds.Tables[0].Rows[0]["Attchment"].ToString();
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
            strSql.Append(" FROM LCXCooperation  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}

