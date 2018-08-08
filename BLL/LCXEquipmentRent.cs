using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    public class LCXEquipmentRent
    {
        public LCXEquipmentRent()
        { }
        #region Model
        private int _id;
        private string _equipmentName;//设备名称
        private string _equipmentNo;//设备编号
        private string _borrowType;//租借类型
        private string _borrowDept;//租借单位
        private string _borrowPerson;//租借人
        private DateTime _startTime;//开始时间
        private DateTime _endTime;//结束时间
        private DateTime _returnTime;//归还时间
        private string _subPerson;//提交人
        private DateTime _subTime;//提交时间
        private string _whetherContinue;//是否续借
        private string _remarks;//备注评价
        private int _states;//审核状态
        private string _serviceAsse;//服务评价
        private string _restitutionReg;//归还登记
        private string _rentStates;//归还状态
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
        public string EquipmentName
        {
            set { _equipmentName = value; }
            get { return _equipmentName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EquipmentNo
        {
            set { _equipmentNo = value; }
            get { return _equipmentNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BorrowType
        {
            set { _borrowType = value; }
            get { return _borrowType; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BorrowDept
        {
            set { _borrowDept = value; }
            get { return _borrowDept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BorrowPerson
        {
            set { _borrowPerson = value; }
            get { return _borrowPerson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime StartTime
        {
            set { _startTime = value; }
            get { return _startTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime EndTime
        {
            set { _endTime = value; }
            get { return _endTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ReturnTime
        {
            set { _returnTime = value; }
            get { return _returnTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string SubPerson
        {
            set { _subPerson = value; }
            get { return _subPerson; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime SubTime
        {
            set { _subTime = value; }
            get { return _subTime; }
        }
        /// <summary>
        ///
        /// </summary>
        public string WhetherContinue
        {
            set { _whetherContinue = value; }
            get { return _whetherContinue; }
        }
        /// <summary>
        ///
        /// </summary>
        public string Remarks
        {
            set { _remarks = value; }
            get { return _remarks; }
        }
        /// <summary>
        ///
        /// </summary>
        public int States
        {
            set { _states = value; }
            get { return _states; }
        }
        /// <summary>
        ///
        /// </summary>
        public string ServiceAsse
        {
            set { _serviceAsse = value; }
            get { return _serviceAsse; }
        }
        /// <summary>
        ///
        /// </summary>
        public string RestitutionReg
        {
            set { _restitutionReg = value; }
            get { return _restitutionReg; }
        }
        /// <summary>
        ///
        /// </summary>
        public string RentStates
        {
            set { _rentStates = value; }
            get { return _rentStates; }
        }
        #endregion Model


        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXEquipmentRent(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,EquipmentName,EquipmentNo,BorrowType,BorrowDept,BorrowPerson,StartTime,EndTime,ReturnTime,SubPerson,SubTime,WhetherContinue,Remarks,States,ServiceAsse,RestitutionReg,RentStates");
            strSql.Append(" FROM LCXEquipmentRent ");
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
                EquipmentName = ds.Tables[0].Rows[0]["EquipmentName"].ToString();
                EquipmentNo = ds.Tables[0].Rows[0]["EquipmentNo"].ToString();
                BorrowType = ds.Tables[0].Rows[0]["BorrowType"].ToString();
                BorrowDept = ds.Tables[0].Rows[0]["BorrowDept"].ToString();
                BorrowPerson = ds.Tables[0].Rows[0]["BorrowPerson"].ToString();
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnTime"].ToString() != "")
                {
                    ReturnTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReturnTime"].ToString());
                }
                SubPerson = ds.Tables[0].Rows[0]["SubPerson"].ToString();
                if (ds.Tables[0].Rows[0]["SubTime"].ToString() != "")
                {
                    SubTime = DateTime.Parse(ds.Tables[0].Rows[0]["SubTime"].ToString());
                }
                WhetherContinue = ds.Tables[0].Rows[0]["WhetherContinue"].ToString();
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                if (ds.Tables[0].Rows[0]["States"].ToString() != "")
                {
                    States = int.Parse(ds.Tables[0].Rows[0]["Remarks"].ToString());
                }
                ServiceAsse=ds.Tables[0].Rows[0]["ServiceAsse"].ToString();
                RestitutionReg=ds.Tables[0].Rows[0]["RestitutionReg"].ToString();
                RentStates= ds.Tables[0].Rows[0]["RentStates"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXEquipmentRent");
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
            strSql.Append("insert into LCXEquipmentRent(");
            strSql.Append("EquipmentName,EquipmentNo,BorrowType,BorrowDept,BorrowPerson,StartTime,EndTime,ReturnTime,SubPerson,SubTime,WhetherContinue,Remarks,RentStates)");
            strSql.Append(" values (");
            strSql.Append("@EquipmentName,@EquipmentNo,@BorrowType,@BorrowDept,@BorrowPerson,@StartTime,@EndTime,@ReturnTime,@SubPerson,@SubTime,@WhetherContinue,@Remarks,@RentStates)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@EquipmentName", SqlDbType.VarChar,50),
                    new SqlParameter("@EquipmentNo", SqlDbType.VarChar,50),
                    new SqlParameter("@BorrowType", SqlDbType.VarChar,50),
                    new SqlParameter("@BorrowDept", SqlDbType.VarChar,50),
                    new SqlParameter("@BorrowPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@StartTime", SqlDbType.DateTime,50),
                    new SqlParameter("@EndTime", SqlDbType.DateTime,50),
                    new SqlParameter("@ReturnTime", SqlDbType.DateTime,50),
                    new SqlParameter("@SubPerson", SqlDbType.VarChar,500),
                    new SqlParameter("@SubTime", SqlDbType.DateTime,50),
                    new SqlParameter("@WhetherContinue", SqlDbType.VarChar,50),
                    new SqlParameter("@Remarks",SqlDbType.VarChar,4000),
                    new SqlParameter("@RentStates",SqlDbType.VarChar,10)
                    };
            parameters[0].Value = EquipmentName;
            parameters[1].Value = EquipmentNo;
            parameters[2].Value = BorrowType;
            parameters[3].Value = BorrowDept;
            parameters[4].Value = BorrowPerson;
            parameters[5].Value = StartTime;
            parameters[6].Value = EndTime;
            parameters[7].Value = ReturnTime;
            parameters[8].Value = SubPerson;
            parameters[9].Value = SubTime;
            parameters[10].Value = WhetherContinue;
            parameters[11].Value = Remarks;
            parameters[12].Value = RentStates;
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
            strSql.Append("update LCXEquipmentRent set ");
            strSql.Append("EquipmentName=@EquipmentName,");
            strSql.Append("EquipmentNo=@EquipmentNo,");
            strSql.Append("BorrowType=@BorrowType,");
            strSql.Append("BorrowDept=@BorrowDept,");
            strSql.Append("BorrowPerson=@BorrowPerson,");
            strSql.Append("StartTime=@StartTime,");
            strSql.Append("EndTime=@EndTime,");
            strSql.Append("ReturnTime=@ReturnTime,");
            strSql.Append("SubPerson=@SubPerson,");
            strSql.Append("SubTime=@SubTime,");
            strSql.Append("WhetherContinue=@WhetherContinue,");
            strSql.Append("Remarks=@Remarks, ");
            strSql.Append("States=@States, ");
            strSql.Append("ServiceAsse=@ServiceAsse, ");
            strSql.Append("RestitutionReg=@RestitutionReg, ");
            strSql.Append("RentStates=@RentStates ");
            strSql.Append(" where ID=@ID");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@EquipmentName", SqlDbType.VarChar,50),
                    new SqlParameter("@EquipmentNo", SqlDbType.VarChar,50),
                    new SqlParameter("@BorrowType", SqlDbType.VarChar,50),
                    new SqlParameter("@BorrowDept", SqlDbType.VarChar,50),
                    new SqlParameter("@BorrowPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@StartTime", SqlDbType.DateTime,50),
                    new SqlParameter("@EndTime", SqlDbType.DateTime,50),
                    new SqlParameter("@ReturnTime", SqlDbType.DateTime,50),
                    new SqlParameter("@SubPerson", SqlDbType.VarChar,500),
                    new SqlParameter("@SubTime", SqlDbType.DateTime,50),
                    new SqlParameter("@WhetherContinue", SqlDbType.VarChar,50),
                    new SqlParameter("@Remarks",SqlDbType.VarChar,4000),
                    new SqlParameter("@States",SqlDbType.Int,4),
                    new SqlParameter("@ServiceAsse", SqlDbType.VarChar,400),
                    new SqlParameter("@RestitutionReg", SqlDbType.VarChar,400),
                    new SqlParameter("@RentStates", SqlDbType.VarChar,10)};
            parameters[0].Value = ID;
            parameters[1].Value = EquipmentName;
            parameters[2].Value = EquipmentNo;
            parameters[3].Value = BorrowType;
            parameters[4].Value = BorrowDept;
            parameters[5].Value = BorrowPerson;
            parameters[6].Value = StartTime;
            parameters[7].Value = EndTime;
            parameters[8].Value = ReturnTime;
            parameters[9].Value = SubPerson;
            parameters[10].Value = SubTime;
            parameters[11].Value = WhetherContinue;
            parameters[12].Value = Remarks;
            parameters[13].Value = States;
            parameters[14].Value = ServiceAsse;
            parameters[15].Value = RestitutionReg;
            parameters[16].Value = RentStates;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXEquipmentRent ");
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
            strSql.Append("select  top 1 ID,EquipmentName,EquipmentNo,BorrowType,BorrowDept,BorrowPerson,StartTime,EndTime,ReturnTime,SubPerson,SubTime,WhetherContinue,Remarks,States,ServiceAsse,RestitutionReg,RentStates");
            strSql.Append(" FROM LCXEquipmentRent ");
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
                EquipmentName = ds.Tables[0].Rows[0]["EquipmentName"].ToString();
                EquipmentNo = ds.Tables[0].Rows[0]["EquipmentNo"].ToString();
                BorrowType = ds.Tables[0].Rows[0]["BorrowType"].ToString();
                BorrowDept = ds.Tables[0].Rows[0]["BorrowDept"].ToString();
                BorrowPerson = ds.Tables[0].Rows[0]["BorrowPerson"].ToString();
                if (ds.Tables[0].Rows[0]["StartTime"].ToString() != "")
                {
                    StartTime = DateTime.Parse(ds.Tables[0].Rows[0]["StartTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["EndTime"].ToString() != "")
                {
                    EndTime = DateTime.Parse(ds.Tables[0].Rows[0]["EndTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ReturnTime"].ToString() != "")
                {
                    ReturnTime = DateTime.Parse(ds.Tables[0].Rows[0]["ReturnTime"].ToString());
                }
                SubPerson = ds.Tables[0].Rows[0]["SubPerson"].ToString();
                if (ds.Tables[0].Rows[0]["SubTime"].ToString() != "")
                {
                    SubTime = DateTime.Parse(ds.Tables[0].Rows[0]["SubTime"].ToString());
                }
                WhetherContinue = ds.Tables[0].Rows[0]["WhetherContinue"].ToString();
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
                if (ds.Tables[0].Rows[0]["States"].ToString() != "")
                {
                    States = int.Parse(ds.Tables[0].Rows[0]["States"].ToString());
                }
                ServiceAsse= ds.Tables[0].Rows[0]["ServiceAsse"].ToString();
                RestitutionReg = ds.Tables[0].Rows[0]["RestitutionReg"].ToString();
                RentStates = ds.Tables[0].Rows[0]["RentStates"].ToString();
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM LCXEquipmentRent  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法

    }
}
