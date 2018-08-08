using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    public class LCXOfficeAcc
    {
        public LCXOfficeAcc()
        {

        }
        #region Model
        private int _id;
        private string _officename;
        private string _serils;
        private string _fujianstr;
        private string _typestr;
        private string _acceptdepart;
        private string _danwei;
        private string _acceptpeople;
        private double _acceptnum;
        private string _username;   
        private DateTime? _timestr;
        private string _miaoshu;


        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 办公用品名称

        /// </summary>
        public string OfficeName
        {
            set { _officename = value; }
            get { return _officename; }
        }
        /// <summary>
        /// 办公用品描述
        /// </summary>
        public string MiaoShu
        {
            set { _miaoshu = value; }
            get { return _miaoshu; }
        }
        /// <summary>
        /// 附件上传
        /// </summary>
        public string FuJianStr
        {
            set { _fujianstr = value; }
            get { return _fujianstr; }
        }
        /// <summary>
        /// 办公用品类别
        /// </summary>
        public string TypeStr
        {
            set { _typestr = value; }
            get { return _typestr; }
        }
        /// <summary>
        /// 办公用品编码
        /// </summary>
        public string Serils
        {
            set { _serils = value; }
            get { return _serils; }
        }
        /// <summary>
        /// 计量单位
        /// </summary>
        public string DanWei
        {
            set { _danwei = value; }
            get { return _danwei; }
        }
        /// <summary>
        /// 领用数量
        /// </summary>
        public double AcceptNum
        {
            set { _acceptnum = value; }
            get { return _acceptnum; }
        }
        /// <summary>
        /// 领用人
        /// </summary>
        public string AcceptPeople
        {
            set { _acceptpeople = value; }
            get { return _acceptpeople; }
        }
        /// <summary>
        /// 领用部门
        /// </summary>
        public string AcceptDepart
        {
            set { _acceptdepart = value; }
            get { return _acceptdepart; }
        }

        /// <summary>
        /// 操作员
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 领用时间
        /// </summary>
        public DateTime? TimeStr
        {
            set { _timestr = value; }
            get { return _timestr; }
        }
        #endregion Model
    
    #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXOfficeAcc(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,OfficeName,Serils,FuJianStr,TypeStr,AcceptDepart,DanWei,AcceptPeople,AcceptNum,UserName,TimeStr,MiaoShu ");                    
            strSql.Append(" FROM LCXOfficeAcc ");
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

                OfficeName = ds.Tables[0].Rows[0]["OfficeName"].ToString();
                Serils = ds.Tables[0].Rows[0]["Serils"].ToString();
                FuJianStr = ds.Tables[0].Rows[0]["FuJianStr"].ToString();
                TypeStr = ds.Tables[0].Rows[0]["TypeStr"].ToString();
                AcceptDepart = ds.Tables[0].Rows[0]["AcceptDepart"].ToString();
                DanWei = ds.Tables[0].Rows[0]["DanWei"].ToString();
                AcceptPeople = ds.Tables[0].Rows[0]["AcceptPeople"].ToString();
                AcceptNum = Double.Parse(ds.Tables[0].Rows[0]["AcceptNum"].ToString());               
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                 if (ds.Tables[0].Rows[0]["TimeStr"].ToString() != "")
                {
                    TimeStr = DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
                }

                MiaoShu = ds.Tables[0].Rows[0]["MiaoShu"].ToString();  
            }
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXOfficeAcc");
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
            strSql.Append("insert into LCXOfficeAcc(");
            strSql.Append("OfficeName,Serils,FuJianStr,TypeStr,AcceptDepart,DanWei,AcceptPeople,AcceptNum,UserName,TimeStr,MiaoShu)");
            strSql.Append(" values (");
            strSql.Append("@OfficeName,@Serils,@FuJianStr,@TypeStr,@AcceptDepart,@DanWei,@AcceptPeople,@AcceptNum,@UserName,@TimeStr,@MiaoShu)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeName", SqlDbType.VarChar,50),
                    new SqlParameter("@Serils", SqlDbType.VarChar,50),
                    new SqlParameter("@FuJianStr", SqlDbType.VarChar,500),
                    new SqlParameter("@TypeStr", SqlDbType.VarChar,100),
                    new SqlParameter("@AcceptDepart", SqlDbType.VarChar,100),
                    new SqlParameter("@DanWei", SqlDbType.VarChar,50),
                     new SqlParameter("@AcceptPeople", SqlDbType.VarChar,100),
                    new SqlParameter("@AcceptNum", SqlDbType.Float),                 
                    new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@TimeStr", SqlDbType.DateTime),
                    new SqlParameter("@MiaoShu", SqlDbType.VarChar,5000)
                };
                   
            parameters[0].Value = OfficeName;
            parameters[1].Value = Serils;
            parameters[2].Value = FuJianStr;
            parameters[3].Value = TypeStr;
            parameters[4].Value = AcceptDepart;
            parameters[5].Value = DanWei;
            parameters[6].Value = AcceptPeople;
            parameters[7].Value = AcceptNum;
            parameters[8].Value = UserName;
            parameters[9].Value = TimeStr;
            parameters[10].Value = MiaoShu;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                LCXOffice eof = new LCXOffice();
                eof.UpdateNum(Serils, (0-AcceptNum));
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update()
        {
        
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LCXOfficeAcc set ");
            strSql.Append("OfficeName=@OfficeName,");
            strSql.Append("Serils=@Serils,");
            strSql.Append("FuJianStr=@FuJianStr,");
            strSql.Append("TypeStr=@TypeStr,");
            strSql.Append("AcceptDepart=@AcceptDepart,");
            strSql.Append("DanWei=@DanWei,");
            strSql.Append("AcceptPeople=@AcceptPeople,");
            strSql.Append("AcceptNum=@AcceptNum,");           
            strSql.Append("UserName=@UserName,");
            strSql.Append("TimeStr=@TimeStr,");
            strSql.Append("MiaoShu=@MiaoShu");  
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
					new SqlParameter("@ID", SqlDbType.Int,4),
					new SqlParameter("@OfficeName", SqlDbType.VarChar,50),
                    new SqlParameter("@Serils", SqlDbType.VarChar,50),
                    new SqlParameter("@FuJianStr", SqlDbType.VarChar,500),
                    new SqlParameter("@TypeStr", SqlDbType.VarChar,100),
                    new SqlParameter("@AcceptDepart", SqlDbType.VarChar,100),
                    new SqlParameter("@DanWei", SqlDbType.VarChar,50),
                    new SqlParameter("@AcceptPeople", SqlDbType.VarChar,50),
                    new SqlParameter("@AcceptNum", SqlDbType.Float),                 
                    new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@TimeStr", SqlDbType.DateTime),
                    new SqlParameter("@MiaoShu", SqlDbType.VarChar,5000)
                                        };
            parameters[0].Value = ID;
            parameters[1].Value = OfficeName;
            parameters[2].Value = Serils;
            parameters[3].Value = FuJianStr;
            parameters[4].Value = TypeStr;
            parameters[5].Value = AcceptDepart;
            parameters[6].Value = DanWei;
            parameters[7].Value = AcceptPeople;
            parameters[8].Value = AcceptNum;        
            parameters[9].Value = UserName;
            parameters[10].Value = TimeStr;
            parameters[11].Value = MiaoShu;
          return (DbHelperSQL.ExecuteSql(strSql.ToString(), parameters));
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXOfficeAcc ");
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
            strSql.Append("select  top 1 ID,OfficeName,Serils,FuJianStr,TypeStr,AcceptDepart,DanWei,AcceptPeople,AcceptNum,UserName,TimeStr,MiaoShu ");
            strSql.Append(" FROM LCXOfficeAcc ");
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

                OfficeName = ds.Tables[0].Rows[0]["OfficeName"].ToString();
                Serils = ds.Tables[0].Rows[0]["Serils"].ToString();
                FuJianStr = ds.Tables[0].Rows[0]["FuJianStr"].ToString();
                TypeStr = ds.Tables[0].Rows[0]["TypeStr"].ToString();
                AcceptDepart = ds.Tables[0].Rows[0]["AcceptDepart"].ToString();
                DanWei = ds.Tables[0].Rows[0]["DanWei"].ToString();
                AcceptPeople = ds.Tables[0].Rows[0]["AcceptPeople"].ToString();
                AcceptNum = Double.Parse(ds.Tables[0].Rows[0]["AcceptNum"].ToString());               
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                if (ds.Tables[0].Rows[0]["TimeStr"].ToString() != "")
                {
                    TimeStr = DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
                }

                MiaoShu = ds.Tables[0].Rows[0]["MiaoShu"].ToString(); 
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LCXOfficeAcc ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
