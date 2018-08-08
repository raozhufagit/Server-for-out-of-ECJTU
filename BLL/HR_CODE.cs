using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
using System.Text;

namespace LCX.BLL
{
    public class LCX_LCX_HR_CODE
    {
         public LCX_LCX_HR_CODE() { }
        #region Model
        private int _CODE_ID;   
        private string _CODE_NO;
        private string _CODE_NAME;
        private string _CODE_JM;
        private string _CODE_ORDER;
        private string _PARENT_NO;
        private string  _CODE_FLAG;
        /// <summary>
        /// 代码简码
        /// </summary>
        public string CODE_JM
        {
            set { _CODE_JM = value; }
            get { return _CODE_JM; }
        }
        /// <summary>
        /// 字典代码自增ID
        /// </summary>
        public int CODE_ID
        {
            set { _CODE_ID = value; }
            get { return _CODE_ID; }
        }
        /// <summary>
        /// 代码编号
        /// </summary>
        public string CODE_NO
        {
            set { _CODE_NO = value; }
            get { return _CODE_NO; }
        }
        /// <summary>
        /// 代码名称
        /// </summary>
        public string CODE_NAME
        {
            set { _CODE_NAME = value; }
            get { return _CODE_NAME; }
        }
        /// <summary>
        /// 排序号
        /// </summary>
        public string CODE_ORDER
        {
            set { _CODE_ORDER = value; }
            get { return _CODE_ORDER; }
        }
        /// <summary>
        /// 代码主分类编号
        /// </summary>
        public string PARENT_NO
        {
            set { _PARENT_NO = value; }
            get { return _PARENT_NO; }
        }
        /// <summary>
        /// 代码分类是否可以删除的标志(1-可删除,0-不可删除)
        /// </summary>
        public string CODE_FLAG
        {
            set { _CODE_FLAG = value; }
            get { return _CODE_FLAG; }
        }  
        #endregion Model

        public LCX_LCX_HR_CODE(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select CODE_ID,CODE_NO,CODE_NAME,CODE_ORDER,PARENT_NO,CODE_FLAG,CODE_JM ");
            strSql.Append(" FROM LCX_LCX_HR_CODE ");
            strSql.Append(" where CODE_ID=@CODE_ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE_ID", SqlDbType.Int)};
            parameters[0].Value = idstr;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["CODE_ID"].ToString() != "")
                {
                    CODE_ID = Int32.Parse(ds.Tables[0].Rows[0]["CODE_ID"].ToString());
                }
                PARENT_NO = ds.Tables[0].Rows[0]["PARENT_NO"].ToString();
                CODE_NAME = ds.Tables[0].Rows[0]["CODE_NAME"].ToString();
                CODE_ORDER = ds.Tables[0].Rows[0]["CODE_ORDER"].ToString();
                PARENT_NO = ds.Tables[0].Rows[0]["PARENT_NO"].ToString();
                CODE_FLAG = ds.Tables[0].Rows[0]["CODE_FLAG"].ToString();
                CODE_JM = ds.Tables[0].Rows[0]["CODE_JM"].ToString();
               
            }
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into LCX_LCX_HR_CODE(");
            strSql.Append("CODE_NO,CODE_NAME,CODE_ORDER,PARENT_NO,CODE_FLAG,CODE_JM)");
            strSql.Append(" values (");
            strSql.Append("@CODE_NO,@CODE_NAME,@CODE_ORDER,@PARENT_NO,@CODE_FLAG,@CODE_JM)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@CODE_NO", SqlDbType.NVarChar,200),			
					new SqlParameter("@CODE_NAME", SqlDbType.Text),
					new SqlParameter("@CODE_ORDER", SqlDbType.NVarChar,200),
                    new SqlParameter("@PARENT_NO", SqlDbType.NVarChar,200),
                    new SqlParameter("@CODE_FLAG", SqlDbType.NVarChar,20),
                    new SqlParameter("@CODE_JM", SqlDbType.NVarChar,20)
                               };
            parameters[0].Value = CODE_NO;
            parameters[1].Value = CODE_NAME;
            parameters[2].Value = CODE_ORDER;
            parameters[3].Value = PARENT_NO;
            parameters[4].Value = CODE_FLAG;
            parameters[5].Value = CODE_JM;   
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
