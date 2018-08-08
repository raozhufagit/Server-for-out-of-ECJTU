using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
   public class LCXSms
    {
        public LCXSms()
        {

        }
        #region Model;
        /// <summary>
        /// 索引ID
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        private int _id;
        /// <summary> 
        /// 消息类型 1 OA短信 2 RTX短信
        /// </summary>
        public int smsType
        {
            set { _smsType = value; }
            get { return _smsType; }
        }
        private int _smsType; 
        /// <summary>
        /// 发送者
        /// </summary>
        public string smsUser
        {
            set { _smsUser = value; }
            get { return _smsUser; }
        }
        private string _smsUser;
        /// <summary>
        /// 目标手机号码
        /// </summary>
        public string smsTel
        {
            set { _smsTel = value; }
            get { return _smsTel; }
        }
        private string _smsTel;
        /// <summary>
        /// 消息内容  true可回复  false不可回复
        /// </summary>
        public bool smsEnRey
        {
            set { _smsEnRey = value; }
            get { return _smsEnRey; }
        }
        private bool _smsEnRey;
         

        /// <summary>
        /// OA事件ID字段
        /// </summary>
        public string oaEventID
        {
            set { _oaEventID = value; }
            get { return _oaEventID; }
        }
        private string _oaEventID;
        /// <summary>
        /// 发送内容
        /// </summary>
        public string smsContent
        {
            set { _smsContent = value; }
            get { return _smsContent; }
        }
        private string _smsContent;
        /// <summary>
        /// 回复内容
        /// </summary>
        public string oaResult
        {
            set { _oaResult = value; }
            get { return _oaResult; }
        }
        private string _oaResult;
        /// <summary>
        /// 发送状态  0未发送 1发送成功  2发送失败
        /// </summary>
        public int smsState
        {
            set { _smsState = value; }
            get { return _smsState; }
        }
        private int _smsState;

        private DateTime _smsTime;
        public DateTime smsTime
        {
            set { _smsTime = value; }
            get { return _smsTime; }
        }


        #endregion


       // ID,smsType,smsUser,smsTel,msEnRey,oaEventID,smsContent,oaResult,smsState

        #region  成员方法
        /// <summary>
		/// 得到一个对象实体
		/// </summary>
        public LCXSms(int idstr)
		{
			StringBuilder strSql=new StringBuilder();
            strSql.Append("select ID,smsType,smsUser,smsTel,smsEnRey,oaEventID,smsContent,oaResult,smsState,smsTime ");
			strSql.Append(" FROM SMS ");
			strSql.Append(" where ID=@ID ");
			SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{

				ID=Int32.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                smsType =Int32.Parse(ds.Tables[0].Rows[0]["smsType"].ToString());
                smsUser = ds.Tables[0].Rows[0]["smsUser"].ToString();
                smsTel = ds.Tables[0].Rows[0]["smsTel"].ToString();  
                smsEnRey = Convert.ToBoolean(ds.Tables[0].Rows[0]["smsEnRey"].ToString());
                oaEventID = ds.Tables[0].Rows[0]["oaEventID"].ToString();
                smsContent = ds.Tables[0].Rows[0]["smsContent"].ToString();
                oaResult = ds.Tables[0].Rows[0]["oaResult"].ToString();
                smsState = Int32.Parse(ds.Tables[0].Rows[0]["smsState"].ToString());
                if (ds.Tables[0].Rows[0]["smsTime"].ToString() != "")
                {
                    smsTime = DateTime.Parse(ds.Tables[0].Rows[0]["smsTime"].ToString());
                } 
			}
		}

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from SMS");
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
            strSql.Append("insert into SMS(");
            strSql.Append("smsType,smsUser,smsTel,smsEnRey,oaEventID,smsContent,oaResult,smsState,smsTime)");
            strSql.Append(" values (");
            strSql.Append("@smsType,@smsUser,@smsTel,@smsEnRey,@oaEventID,@smsContent,@oaResult,@smsState,@smsTime)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@smsType", SqlDbType.Int),
					new SqlParameter("@smsUser", SqlDbType.VarChar,20),
					new SqlParameter("@smsTel", SqlDbType.VarChar,20),
					new SqlParameter("@smsEnRey", SqlDbType.Bit),
					new SqlParameter("@oaEventID", SqlDbType.VarChar,20),
					new SqlParameter("@smsContent", SqlDbType.VarChar,200),
					new SqlParameter("@oaResult", SqlDbType.VarChar,200),
					new SqlParameter("@smsState", SqlDbType.Int),
					new SqlParameter("@smsTime", SqlDbType.DateTime)
					};
            parameters[0].Value = smsType;
            parameters[1].Value = smsUser;
            parameters[2].Value = smsTel;
            parameters[3].Value = smsEnRey;
            parameters[4].Value = oaEventID;
            parameters[5].Value = smsContent;
            parameters[6].Value = oaResult;
            parameters[7].Value = smsState;
            parameters[8].Value = smsTime;  
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

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public void Update()
        {
            // ID,smsType,smsUser,smsTel,msEnRey,oaEventID,smsContent,oaResult,smsState
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SMS set ");
            strSql.Append("smsType=@smsType,");
            strSql.Append("smsUser=@smsUser,");
            strSql.Append("smsTel=@smsTel,");
            strSql.Append("smsEnRey=@smsEnRey,");
            strSql.Append("oaEventID=@oaEventID,");
            strSql.Append("smsContent=@smsContent,");
            strSql.Append("oaResult=@oaResult,");
            strSql.Append("smsState=@smsState,");
            strSql.Append("smsTime=@smsTime"); 
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@smsType", SqlDbType.Int),
					new SqlParameter("@smsUser", SqlDbType.VarChar,20),
					new SqlParameter("@smsTel", SqlDbType.VarChar,20),
					new SqlParameter("@smsEnRey", SqlDbType.Bit),
					new SqlParameter("@oaEventID", SqlDbType.VarChar,20),
					new SqlParameter("@smsContent", SqlDbType.VarChar,200),
					new SqlParameter("@oaResult", SqlDbType.VarChar,200),
					new SqlParameter("@smsState", SqlDbType.Int),
					new SqlParameter("@smsTime", SqlDbType.DateTime)};
            parameters[0].Value = ID;
            parameters[1].Value = smsType;
            parameters[2].Value = smsUser;
            parameters[3].Value = smsTel;
            parameters[4].Value = smsEnRey;
            parameters[5].Value = oaEventID;
            parameters[6].Value = smsContent;
            parameters[7].Value = oaResult;
            parameters[8].Value = smsState;
            parameters[9].Value = smsTime;  
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete SMS ");
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
            strSql.Append("select ID,smsType,smsUser,smsTel,msEnRey,oaEventID,smsContent,oaResult,smsState,smsTime ");
            strSql.Append(" FROM SMS ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4)};
            parameters[0].Value = idstr;

            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ID = int.Parse(ds.Tables[0].Rows[0]["ID"].ToString());
                smsType = Int32.Parse(ds.Tables[0].Rows[0]["smsType"].ToString());
                smsUser = ds.Tables[0].Rows[0]["smsUser"].ToString();
                smsTel = ds.Tables[0].Rows[0]["smsTel"].ToString();
                smsEnRey = Convert.ToBoolean(ds.Tables[0].Rows[0]["msEnRey"].ToString());
                oaEventID = ds.Tables[0].Rows[0]["NeedTime"].ToString();
                smsContent = ds.Tables[0].Rows[0]["NeedLike"].ToString();
                oaResult = ds.Tables[0].Rows[0]["JingZhengDuiShou"].ToString();
                smsState = Int32.Parse(ds.Tables[0].Rows[0]["HeZuoYiYuan"].ToString());
                if (ds.Tables[0].Rows[0]["smsTime"].ToString() != "")
                {
                    smsTime = DateTime.Parse(ds.Tables[0].Rows[0]["smsTime"].ToString());
                } 
            }
        }
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,smsType,smsUser,smsTel,smsEnRey,oaEventID,smsContent,oaResult,smsState,smsTime ");
            strSql.Append(" FROM SMS ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }
        /// <summary>
        /// 更新短消息状态
        /// </summary>
        /// <param name="idstr"></param>
        public void UpdateState(int idstr,int stateStr)
        {
            // ID,smsType,smsUser,smsTel,msEnRey,oaEventID,smsContent,oaResult,smsState
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update SMS set ");
            strSql.Append("smsState=@smsState");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@smsState", SqlDbType.Int)};
            parameters[0].Value = idstr;
            parameters[1].Value = stateStr;
            DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
        #endregion
    }
}
