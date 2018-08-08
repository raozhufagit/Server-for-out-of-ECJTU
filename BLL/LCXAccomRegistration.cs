using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    public class LCXAccomRegistration
    {
        public LCXAccomRegistration()
        { }
        #region Model
        private int _id;//ID
        private string _outVisiting;//来访信息
        private string _accommationSite;//住宿地址 
        private int _peopleNum;//人数
        private int _costNum;//费用
        private string _remarks;//备注
        private DateTime _accomTime;//入住时间
        
        ///<summary>
        ///ID
        ///</summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        ///<summary>
        ///来访信息
        /// </summary>
        public string OutVisiting
        {
            set { _outVisiting = value; }
            get { return _outVisiting; }
        }
        ///<summary>
        ///住宿地址
        /// </summary>
        public string AccommationSite
        {
            set { _accommationSite = value; }
            get { return _accommationSite; }
        }
        ///<summary>
        ///住宿人数
        /// </summary>
        public int PeopleNum
        {
            set { _peopleNum = value; }
            get { return _peopleNum; }
        }
        ///<summary>
        ///费用
        /// </summary>
        public int CostNum
        {
            set { _costNum = value; }
            get { return _costNum; }
        }
        ///<summary>
        ///入住时间
        /// </summary>
        public DateTime AccomTime
        {
            set { _accomTime = value; }
            get { return _accomTime; }
        }
        ///<summary>
        ///备注
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        #endregion
        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXAccomRegistration(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,OutVisiting,AccommationSite,PeopleNum,CostNum,AccomTime,Remarks");
            strSql.Append(" FROM LCXAccomRegistration ");
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
                OutVisiting = ds.Tables[0].Rows[0]["OutVisiting"].ToString();
                AccommationSite = ds.Tables[0].Rows[0]["AccommationSite"].ToString();
                PeopleNum = int.Parse(ds.Tables[0].Rows[0]["PeopleNum"].ToString());
                CostNum = int.Parse(ds.Tables[0].Rows[0]["DepartmentB"].ToString());
                if (ds.Tables[0].Rows[0]["AccomTime"].ToString() != "")
                {
                    AccomTime = DateTime.Parse(ds.Tables[0].Rows[0]["AccomTime"].ToString());
                }
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXAccomRegistration");
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
            strSql.Append("insert into LCXAccomRegistration(");
            strSql.Append("OutVisiting,AccommationSite,PeopleNum,CostNum,AccomTime,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@OutVisiting,@AccommationSite,@PeopleNum,@CostNum,@AccomTime,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@OutVisiting", SqlDbType.VarChar,50),
                    new SqlParameter("@AccommationSite", SqlDbType.VarChar,50),
                    new SqlParameter("@PeopleNum", SqlDbType.Int,5),
                    new SqlParameter("@CostNum", SqlDbType.Int,10),
                    new SqlParameter("@AccomTime", SqlDbType.DateTime,50),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,500)
                    
                    };
            parameters[0].Value = OutVisiting;
            parameters[1].Value = AccommationSite;
            parameters[2].Value = PeopleNum;
            parameters[3].Value = CostNum;
            parameters[4].Value = AccomTime;
            parameters[5].Value = Remarks;
            
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
            strSql.Append("update LCXAccomRegistration set ");
            strSql.Append("OutVisiting=@OutVisiting,");
            strSql.Append("AccommationSite=@AccommationSite,");
            strSql.Append("PeopleNum=@PeopleNum,");
            strSql.Append("CostNum=@CostNum,");
            strSql.Append("AccomTime=@AccomTime,");
            strSql.Append("Remarks=@Remarks");
           
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@OutVisiting", SqlDbType.VarChar,50),
                    new SqlParameter("@AccommationSite", SqlDbType.VarChar,50),
                    new SqlParameter("@PeopleNum", SqlDbType.Int,5),
                    new SqlParameter("@CostNum", SqlDbType.Int,10), 
                    new SqlParameter("@AccomTime", SqlDbType.DateTime,50),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,500)
                    };
            parameters[0].Value = ID;
            parameters[1].Value = OutVisiting;
            parameters[2].Value = AccommationSite;
            parameters[3].Value = PeopleNum;
            parameters[4].Value = CostNum;
            parameters[5].Value = AccomTime;
            parameters[6].Value = Remarks;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXAccomRegistration ");
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
            strSql.Append("select  top 1 ID,OutVisiting,AccommationSite,PeopleNum,CostNum,AccomTime,Remarks");
            strSql.Append(" FROM LCXAccomRegistration ");
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
                OutVisiting = ds.Tables[0].Rows[0]["CAgreementNo"].ToString();
                AccommationSite = ds.Tables[0].Rows[0]["CAgreementName"].ToString();
                PeopleNum = int.Parse(ds.Tables[0].Rows[0]["DepartmentA"].ToString());
                CostNum = int.Parse(ds.Tables[0].Rows[0]["DepartmentB"].ToString());
                if (ds.Tables[0].Rows[0]["AccomTime"].ToString() != "")
                {
                    AccomTime = DateTime.Parse(ds.Tables[0].Rows[0]["AccomTime"].ToString());
                }
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LCXAccomRegistration ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
