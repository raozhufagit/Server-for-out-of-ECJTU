using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    public class LCXInnovationPlat
    {
        public LCXInnovationPlat()
        { }
        #region Model
        private int _id;//ID
        private string _platFormName;//创新平台名称
        private string _manager;//管理人
        private string _teacherGroup;//教师团队
        private string _researchFind;//研究成果
        private string _teamIntr;//团队介绍
        private string _serviceContent;//服务内容
        private string _remarks;//备注
        
        ///<summary>
        ///
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PlatFormName
        {
            set { _platFormName = value; }
            get { return _platFormName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherGroup
        {
            set { _teacherGroup = value; }
            get { return _teacherGroup; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ResearchFind
        {
            set { _researchFind = value; }
            get { return _researchFind; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeamIntr
        {
            set { _teamIntr = value; }
            get { return _teamIntr; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string ServiceContent
        {
            set { _serviceContent = value; }
            get { return _serviceContent; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Manager
        {
            set { _manager = value; }
            get { return _manager; }
        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }

        #endregion Model


        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXInnovationPlat(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PlatFormName,Manager,TeacherGroup,ResearchFind,TeamIntr,ServiceContent,Remarks");
            strSql.Append(" FROM LCXInnovationPlat ");
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
                PlatFormName = ds.Tables[0].Rows[0]["PlatFormName"].ToString();
                Manager = ds.Tables[0].Rows[0]["Manager"].ToString();
                TeacherGroup = ds.Tables[0].Rows[0]["TeacherGroup"].ToString();
                ResearchFind = ds.Tables[0].Rows[0]["ResearchFind"].ToString();
                TeamIntr = ds.Tables[0].Rows[0]["TeamIntr"].ToString();
                ServiceContent = ds.Tables[0].Rows[0]["ServiceContent"].ToString();
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXInnovationPlat");
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
            strSql.Append("insert into LCXInnovationPlat(");
            strSql.Append("PlatFormName,Manager,TeacherGroup,ResearchFind,TeamIntr,ServiceContent,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@PlatFormName,@Manager,@TeacherGroup,@ResearchFind,@TeamIntr,@ServiceContent,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@PlatFormName", SqlDbType.VarChar,50),
                    new SqlParameter("@Manager", SqlDbType.VarChar,50),
                    new SqlParameter("@TeacherGroup", SqlDbType.VarChar,1000),
                    new SqlParameter("@ResearchFind", SqlDbType.VarChar,2000),
                    new SqlParameter("@TeamIntr", SqlDbType.VarChar,2000),
                    new SqlParameter("@ServiceContent", SqlDbType.VarChar,1000),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,500)
                    
                    };
            parameters[0].Value = PlatFormName;
            parameters[1].Value = Manager;
            parameters[2].Value = TeacherGroup;
            parameters[3].Value = ResearchFind;
            parameters[4].Value = TeamIntr;
            parameters[5].Value = ServiceContent;
            parameters[6].Value = Remarks;
            

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
            strSql.Append("update LCXInnovationPlat set ");
            strSql.Append("PlatFormName=@PlatFormName,");
            strSql.Append("Manager=@Manager,");
            strSql.Append("TeacherGroup=@TeacherGroup,");
            strSql.Append("ResearchFind=@ResearchFind,");
            strSql.Append("TeamIntr=@TeamIntr,");
            strSql.Append("ServiceContent=@ServiceContent,");
            strSql.Append("Remarks=@Remarks ");
            
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@PlatFormName", SqlDbType.VarChar,50),
                    new SqlParameter("@Manager", SqlDbType.VarChar,50),
                    new SqlParameter("@TeacherGroup", SqlDbType.VarChar,1000),
                    new SqlParameter("@ResearchFind", SqlDbType.VarChar,2000),
                    new SqlParameter("@TeamIntr", SqlDbType.VarChar,2000),
                    new SqlParameter("@ServiceContent", SqlDbType.VarChar,1000),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,500)
                    
                    };
            parameters[0].Value = ID;
            parameters[1].Value = PlatFormName;
            parameters[2].Value = Manager;
            parameters[3].Value = TeacherGroup;
            parameters[4].Value = ResearchFind;
            parameters[5].Value = TeamIntr;
            parameters[6].Value = ServiceContent;
            parameters[7].Value = Remarks;
           
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXInnovationPlat ");
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
            strSql.Append("select  top 1 ID,PlatFormName,Manager,TeacherGroup,ResearchFind,TeamIntr,ServiceContent,Remarks");
            strSql.Append(" FROM LCXInnovationPlat ");
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
                PlatFormName = ds.Tables[0].Rows[0]["PlatFormName"].ToString();
                Manager = ds.Tables[0].Rows[0]["Manager"].ToString();
                TeacherGroup = ds.Tables[0].Rows[0]["TeacherGroup"].ToString();
                ResearchFind = ds.Tables[0].Rows[0]["ResearchFind"].ToString();
                TeamIntr = ds.Tables[0].Rows[0]["TeamIntr"].ToString();
                ServiceContent = ds.Tables[0].Rows[0]["ServiceContent"].ToString();
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
            strSql.Append(" FROM LCXInnovationPlat  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
