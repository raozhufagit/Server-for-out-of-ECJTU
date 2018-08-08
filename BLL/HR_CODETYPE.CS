using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
using System.Text;

namespace LCX.BLL
{
    public class LCX_HR_CODETYPE
    {
        public LCX_HR_CODETYPE() { }
        #region Model
        private int _ID;
        private int _PARENT_ORDER;
        private string _PARENT_NO;
        private string _PARENT_NAME;
       
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _ID = value; }
            get { return _ID; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int PARENT_ORDER
        {
            set { _PARENT_ORDER = value; }
            get { return _PARENT_ORDER; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PARENT_NO
        {
            set { _PARENT_NO = value; }
            get { return _PARENT_NO; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string PARENT_NAME
        {
            set { _PARENT_NAME = value; }
            get { return _PARENT_NAME; }
        }        
        #endregion Model

        public LCX_HR_CODETYPE(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,PARENT_ORDER,PARENT_NO,PARENT_NAME ");
            strSql.Append(" FROM LCX_HR_CODETYPE ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int)};
            parameters[0].Value = idstr;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["ID"].ToString() != "")
                {
                    ID = Int32.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PARENT_ORDER"].ToString() != "")
                {
                    PARENT_ORDER = Int32.Parse(ds.Tables[0].Rows[0]["PARENT_ORDER"].ToString());
                }
                PARENT_NO = ds.Tables[0].Rows[0]["UserName"].ToString();
                PARENT_NAME = ds.Tables[0].Rows[0]["TitleStr"].ToString();
               
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LCX_HR_CODETYPE(");
            strSql.Append("PARENT_ORDER,PARENT_NO,PARENT_NAME)");
            strSql.Append(" values (");
            strSql.Append("@PARENT_ORDER,@PARENT_NO,@PARENT_NAME)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@PARENT_ORDER", SqlDbType.Int),			
					new SqlParameter("@PARENT_NO", SqlDbType.NVarChar,200),
					new SqlParameter("@PARENT_NAME", SqlDbType.NVarChar,500)};
            parameters[0].Value = PARENT_ORDER;
            parameters[1].Value = PARENT_NO;
            parameters[2].Value = PARENT_NAME;   
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }


    }
}
