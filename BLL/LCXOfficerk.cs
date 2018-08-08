using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    /// <summary>
    /// 类LCXOffice入库。
    /// </summary>
    public class LCXOfficerk
    {
        public LCXOfficerk()
        { }
        #region Model
        private int _id;
        private string _serils;
        private string _officename;
        private string _fujianstr;
        private string _typestr;
        private string _gongyingshang;
        private string _danwei;
        private double _rknum;
        private double _danjia;
        private double _totalmoeny;
        private string _paytype;
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
        /// 入库数量
        /// </summary>
        public double RkNum
        {
            set { _rknum = value; }
            get { return _rknum; }
        }
        /// <summary>
        /// 单价
        /// </summary>
        public double DanJia
        {
            set { _danjia = value; }
            get { return _danjia; }
        }
        /// <summary>
        /// 总金额
        /// </summary>
        public double TotalMoeny
        {
            set { _totalmoeny = value; }
            get { return _totalmoeny; }
        }
        /// <summary>
        /// 供应商
        /// </summary>
        public string GongYingShang
        {
            set { _gongyingshang = value; }
            get { return _gongyingshang; }
        }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PayType
        {
            set { _paytype = value; }
            get { return _paytype; }
        }
        /// <summary>
        /// 创建人
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 创建时间
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
        public LCXOfficerk(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,OfficeName,Serils,FuJianStr,TypeStr,GongYingShang,DanWei,RkNum,DanJia,TotalMoeny,PayType,UserName,TimeStr,MiaoShu ");
            strSql.Append(" FROM LCXOfficerk ");
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
                GongYingShang = ds.Tables[0].Rows[0]["GongYingShang"].ToString();
                DanWei = ds.Tables[0].Rows[0]["DanWei"].ToString();
                RkNum = Double.Parse(ds.Tables[0].Rows[0]["RkNum"].ToString());
                DanJia = Double.Parse(ds.Tables[0].Rows[0]["DanJia"].ToString());
                TotalMoeny = Double.Parse(ds.Tables[0].Rows[0]["TotalMoeny"].ToString());
                PayType = ds.Tables[0].Rows[0]["PayType"].ToString();
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
            strSql.Append("select count(1) from LCXOfficerk");
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
            strSql.Append("insert into LCXOfficerk(");
            strSql.Append("OfficeName,Serils,FuJianStr,TypeStr,GongYingShang,DanWei,RkNum,DanJia,TotalMoeny,PayType,UserName,TimeStr,MiaoShu)");
            strSql.Append(" values (");
            strSql.Append("@OfficeName,@Serils,@FuJianStr,@TypeStr,@GongYingShang,@DanWei,@RkNum,@DanJia,@TotalMoeny,@PayType,@UserName,@TimeStr,@MiaoShu)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
					new SqlParameter("@OfficeName", SqlDbType.VarChar,50),
                    new SqlParameter("@Serils", SqlDbType.VarChar,50),
                    new SqlParameter("@FuJianStr", SqlDbType.VarChar,500),
                    new SqlParameter("@TypeStr", SqlDbType.VarChar,100),
                    new SqlParameter("@GongYingShang", SqlDbType.VarChar,100),
                    new SqlParameter("@DanWei", SqlDbType.VarChar,50),
                    new SqlParameter("@RkNum", SqlDbType.Float),
                    new SqlParameter("@DanJia", SqlDbType.Float),
                    new SqlParameter("@TotalMoeny", SqlDbType.Float),
                    new SqlParameter("@PayType", SqlDbType.VarChar,50),
                    new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@TimeStr", SqlDbType.DateTime),
                    new SqlParameter("@MiaoShu", SqlDbType.VarChar,5000)
                };
                   
            parameters[0].Value = OfficeName;
            parameters[1].Value = Serils;
            parameters[2].Value = FuJianStr;
            parameters[3].Value = TypeStr;
            parameters[4].Value = GongYingShang;
            parameters[5].Value = DanWei;
            parameters[6].Value = RkNum;
            parameters[7].Value = DanJia;
            parameters[8].Value = TotalMoeny;
            parameters[9].Value = PayType;
            parameters[10].Value = UserName;
            parameters[11].Value = TimeStr;
            parameters[12].Value = MiaoShu;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                LCXOffice eof = new LCXOffice();
                eof.UpdateNum(Serils, RkNum);
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update()
        {
           // ID,OfficeName,Serils,FuJianStr,TypeStr,GongYingShang,DanWei,RkNum,DanJia,TotalMoeny,PayType,UserName,TimeStr,MiaoShu
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LCXOfficerk set ");
            strSql.Append("OfficeName=@OfficeName,");
            strSql.Append("Serils=@Serils,");
            strSql.Append("FuJianStr=@FuJianStr,");
            strSql.Append("TypeStr=@TypeStr,");
            strSql.Append("GongYingShang=@GongYingShang,");
            strSql.Append("DanWei=@DanWei,");
            strSql.Append("RkNum=@RkNum,");
            strSql.Append("DanJia=@DanJia,");
            strSql.Append("TotalMoeny=@TotalMoeny,");
            strSql.Append("PayType=@PayType,");
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
                    new SqlParameter("@GongYingShang", SqlDbType.VarChar,100),
                    new SqlParameter("@DanWei", SqlDbType.VarChar,50),
                    new SqlParameter("@RkNum", SqlDbType.Float),
                    new SqlParameter("@DanJia", SqlDbType.Float),
                    new SqlParameter("@TotalMoeny", SqlDbType.Float),
                    new SqlParameter("@PayType", SqlDbType.VarChar,50),
                    new SqlParameter("@UserName", SqlDbType.VarChar,50),
                    new SqlParameter("@TimeStr", SqlDbType.DateTime),
                    new SqlParameter("@MiaoShu", SqlDbType.VarChar,5000)
                                        };
            parameters[0].Value = ID;
            parameters[1].Value = OfficeName;
            parameters[2].Value = Serils;
            parameters[3].Value = FuJianStr;
            parameters[4].Value = TypeStr;
            parameters[5].Value = GongYingShang;
            parameters[6].Value = DanWei;
            parameters[7].Value = RkNum;
            parameters[8].Value = DanJia;
            parameters[9].Value = TotalMoeny;
            parameters[10].Value = PayType;
            parameters[11].Value = UserName;
            parameters[12].Value = TimeStr;
            parameters[13].Value = MiaoShu;
          return (DbHelperSQL.ExecuteSql(strSql.ToString(), parameters));
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXOfficerk ");
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
            strSql.Append("select  top 1 ID,OfficeName,Serils,FuJianStr,TypeStr,GongYingShang,DanWei,RkNum,DanJia,TotalMoeny,PayType,UserName,TimeStr,MiaoShu ");
            strSql.Append(" FROM LCXOfficerk ");
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
                GongYingShang = ds.Tables[0].Rows[0]["GongYingShang"].ToString();
                DanWei = ds.Tables[0].Rows[0]["DanWei"].ToString();
                RkNum = Double.Parse(ds.Tables[0].Rows[0]["RkNum"].ToString());
                DanJia = Double.Parse(ds.Tables[0].Rows[0]["DanJia"].ToString());
                TotalMoeny = Double.Parse(ds.Tables[0].Rows[0]["TotalMoeny"].ToString());
                PayType = ds.Tables[0].Rows[0]["PayType"].ToString();
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
            strSql.Append(" FROM LCXOfficerk ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
