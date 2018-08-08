using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用
namespace LCX.BLL
{
    public class LCXEquipment
    {
        public LCXEquipment()
        { }
        #region Model
        private int _id;//ID
        private string _equipmentNo;//设备编号
        private string _equipmentName;//设备名称
        private string _equipmentType;//设备类型
        private string _factoryNo;//出厂编号
        private string _factoryName;//生产厂家
        private string _equipmentModel;//设备型号
        private string _belongDept;//所属部门
        private DateTime _buyTime;//购买时间
        private DateTime _checkTime;//审核时间
        private string _buyPrice;//购买价格
        private string _manager;//管理人员
        private string _storagePosition;//存放位置
        private string _mattersAttention;//注意事项
        private string _checker;//审核人
        private string _checkStates;//审核状态
        private string _equipStates;//设备状态
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
        public string EquipmentNo
        {
            set { _equipmentNo = value; }
            get { return _equipmentNo; }
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
        public string EquipmentType
        {
            set { _equipmentType = value; }
            get { return _equipmentType; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FactoryNo
        {
            set { _factoryNo = value; }
            get { return _factoryNo; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FactoryName
        {
            set { _factoryName = value; }
            get { return _factoryName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string EquipmentModel
        {
            set { _equipmentModel = value; }
            get { return _equipmentModel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BelongDept
        {
            set { _belongDept = value; }
            get { return _belongDept; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime BuyTime
        {
            set { _buyTime = value; }
            get { return _buyTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CheckTime
        {
            set { _checkTime = value; }
            get { return _checkTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string BuyPrice
        {
            set { _buyPrice = value; }
            get { return _buyPrice; }
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
        /// 
        /// </summary>
        public string StoragePosition
        {
            set { _storagePosition = value; }
            get { return _storagePosition; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string MattersAttention
        {
            set { _mattersAttention = value; }
            get { return _mattersAttention; }
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
        /// 
        /// </summary>
        public string Checker
        {
            set { _checker = value; }
            get { return _checker; }
        }
        ///<summary>
        ///
        /// </summary>
        public string CheckStates
        {
            set { _checkStates = value; }
            get { return _checkStates; }
        }

        /// <summary>
        ///
        /// </summary>
        public string EquipStates
        {
            set { _equipStates = value; }
            get { return _equipStates; }
        }
        #endregion Model


        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXEquipment(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,EquipmentName,EquipmentNo,FactoryNo,FactoryName,EquipmentType,EquipmentModel,BelongDept,BuyTime,BuyPrice,Manager,StoragePosition,MattersAttention,Checker,CheckTime,CheckStates,EquipStates,Remarks");
            strSql.Append(" FROM LCXEquipment ");
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
                FactoryNo = ds.Tables[0].Rows[0]["FactoryNo"].ToString();
                FactoryName = ds.Tables[0].Rows[0]["FactoryName"].ToString();
                EquipmentType = ds.Tables[0].Rows[0]["EquipmentType"].ToString();
                EquipmentModel = ds.Tables[0].Rows[0]["EquipmentModel"].ToString();
                BelongDept = ds.Tables[0].Rows[0]["BelongDept"].ToString();
                if (ds.Tables[0].Rows[0]["BuyTime"].ToString() != "")
                {
                    BuyTime = DateTime.Parse(ds.Tables[0].Rows[0]["BuyTime"].ToString());
                }
                BuyPrice = ds.Tables[0].Rows[0]["BuyPrice"].ToString();
                Manager = ds.Tables[0].Rows[0]["Manager"].ToString();
                StoragePosition = ds.Tables[0].Rows[0]["StoragePosition"].ToString();
                MattersAttention = ds.Tables[0].Rows[0]["MattersAttention"].ToString();
                Checker = ds.Tables[0].Rows[0]["Checker"].ToString();
                if (ds.Tables[0].Rows[0]["CheckTime"].ToString() != "")
                {
                    CheckTime = DateTime.Parse(ds.Tables[0].Rows[0]["CheckTime"].ToString());
                }
                CheckStates = ds.Tables[0].Rows[0]["CheckStates"].ToString();
                EquipStates = ds.Tables[0].Rows[0]["EquipStates"].ToString();
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXEquipment");
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
            strSql.Append("insert into LCXEquipment(");
            strSql.Append("EquipmentName,EquipmentNo,FactoryNo,FactoryName,EquipmentType,EquipmentModel,BelongDept,BuyTime,BuyPrice,Manager,StoragePosition,MattersAttention,Checker,CheckTime,CheckStates,EquipStates,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@EquipmentName,@EquipmentNo,@FactoryNo,@FactoryName,@EquipmentType,@EquipmentModel,@BelongDept,@BuyTime,@BuyPrice,@Manager,@StoragePosition,@MattersAttention,@Checker,@CheckTime,@CheckStates,@EquipStates,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@EquipmentName", SqlDbType.VarChar,50),
                    new SqlParameter("@EquipmentNo", SqlDbType.VarChar,50),
                    new SqlParameter("@FactoryNo", SqlDbType.VarChar,50),
                    new SqlParameter("@FactoryName", SqlDbType.VarChar,50),
                    new SqlParameter("@EquipmentType", SqlDbType.VarChar,50),
                    new SqlParameter("@EquipmentModel", SqlDbType.VarChar,50),
                    new SqlParameter("@BelongDept", SqlDbType.VarChar,50),
                    new SqlParameter("@BuyTime", SqlDbType.DateTime,50),
                    new SqlParameter("@BuyPrice", SqlDbType.VarChar,50),
                    new SqlParameter("@Manager", SqlDbType.VarChar,20),
                    new SqlParameter("@StoragePosition", SqlDbType.VarChar,500),
                    new SqlParameter("@MattersAttention", SqlDbType.VarChar,500),
                    new SqlParameter("@Checker", SqlDbType.VarChar,20),
                    new SqlParameter("@CheckTime", SqlDbType.DateTime,20),
                    new SqlParameter("@CheckStates", SqlDbType.VarChar,10),
                    new SqlParameter("@EquipStates",SqlDbType.VarChar,10),
                    new SqlParameter("@Remarks",SqlDbType.VarChar,4000)
                    };
            parameters[0].Value = EquipmentName;
            parameters[1].Value = EquipmentNo;
            parameters[2].Value = FactoryNo;
            parameters[3].Value = FactoryName;
            parameters[4].Value = EquipmentType;
            parameters[5].Value = EquipmentModel;
            parameters[6].Value = BelongDept;
            parameters[7].Value = BuyTime;
            parameters[8].Value = BuyPrice;
            parameters[9].Value = Manager;
            parameters[10].Value = StoragePosition;
            parameters[11].Value = MattersAttention;
            parameters[12].Value = Checker;
            parameters[13].Value = CheckTime;
            parameters[14].Value = CheckStates;
            parameters[15].Value = EquipStates;
            parameters[16].Value = Remarks;
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
        public int  Update()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update LCXEquipment set ");
            strSql.Append("EquipmentName=@EquipmentName,");
            strSql.Append("EquipmentNo=@EquipmentNo,");
            strSql.Append("FactoryNo=@FactoryNo,");
            strSql.Append("FactoryName=@FactoryName,");
            strSql.Append("EquipmentType=@EquipmentType,");
            strSql.Append("EquipmentModel=@EquipmentModel,");
            strSql.Append("BelongDept=@BelongDept,");
            strSql.Append("BuyTime=@BuyTime,");
            strSql.Append("BuyPrice=@BuyPrice,");
            strSql.Append("Manager=@Manager,");
            strSql.Append("StoragePosition=@StoragePosition,");
            strSql.Append("MattersAttention=@MattersAttention,");
            strSql.Append("Checker=@Checker,");
            strSql.Append("CheckTime=@CheckTime,");
            strSql.Append("CheckStates=@CheckStates,");
            strSql.Append("EquipStates=@EquipStates,");
            strSql.Append("Remarks=@Remarks ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@EquipmentName", SqlDbType.VarChar,50),
                    new SqlParameter("@EquipmentNo", SqlDbType.VarChar,50),
                    new SqlParameter("@FactoryNo", SqlDbType.VarChar,50),
                    new SqlParameter("@FactoryName", SqlDbType.VarChar,50),
                    new SqlParameter("@EquipmentType", SqlDbType.VarChar,50),
                    new SqlParameter("@EquipmentModel", SqlDbType.VarChar,50),
                    new SqlParameter("@BelongDept", SqlDbType.VarChar,50),
                    new SqlParameter("@BuyTime", SqlDbType.DateTime,50),
                    new SqlParameter("@BuyPrice", SqlDbType.VarChar,5),
                    new SqlParameter("@Manager", SqlDbType.VarChar,5000),
                    new SqlParameter("@StoragePosition", SqlDbType.VarChar,50),
                    new SqlParameter("@MattersAttention", SqlDbType.VarChar,50),
                    new SqlParameter("@Checker", SqlDbType.VarChar,20),
                    new SqlParameter("@CheckTime", SqlDbType.DateTime,20),
                    new SqlParameter("@CheckStates", SqlDbType.VarChar,10),
                    new SqlParameter("@EquipStates",SqlDbType.VarChar,10),
                    new SqlParameter("@Remarks",SqlDbType.VarChar,4000)
                    };
            parameters[0].Value = ID;
            parameters[1].Value = EquipmentName;
            parameters[2].Value = EquipmentNo;
            parameters[3].Value = FactoryNo;
            parameters[4].Value = FactoryName;
            parameters[5].Value = EquipmentType;
            parameters[6].Value = EquipmentModel;
            parameters[7].Value = BelongDept;
            parameters[8].Value = BuyTime;
            parameters[9].Value = BuyPrice;
            parameters[10].Value = Manager;
            parameters[11].Value = StoragePosition;
            parameters[12].Value = MattersAttention;
            parameters[13].Value = Checker;
            parameters[14].Value = CheckTime;
            parameters[15].Value = CheckStates;
            parameters[16].Value = EquipStates;
            parameters[17].Value = Remarks;

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXEquipment ");
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
            strSql.Append("select  top 1 ID,EquipmentName,EquipmentNo,FactoryNo,FactoryName,EquipmentType,EquipmentModel,BelongDept,BuyTime,BuyPrice,Manager,StoragePosition,MattersAttention,Checker,CheckTime,CheckStates,EquipStates,Remarks");
            strSql.Append(" FROM LCXEquipment ");
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
                FactoryNo = ds.Tables[0].Rows[0]["FactoryNo"].ToString();
                FactoryName = ds.Tables[0].Rows[0]["FactoryName"].ToString();
                EquipmentType = ds.Tables[0].Rows[0]["EquipmentType"].ToString();
                EquipmentModel = ds.Tables[0].Rows[0]["EquipmentModel"].ToString();
                BelongDept = ds.Tables[0].Rows[0]["BelongDept"].ToString();
                if (ds.Tables[0].Rows[0]["BuyTime"].ToString() != "")
                {
                    BuyTime = DateTime.Parse(ds.Tables[0].Rows[0]["BuyTime"].ToString());
                }
                BuyPrice = ds.Tables[0].Rows[0]["BuyPrice"].ToString();
                Manager = ds.Tables[0].Rows[0]["Manager"].ToString();
                StoragePosition = ds.Tables[0].Rows[0]["StoragePosition"].ToString();
                MattersAttention = ds.Tables[0].Rows[0]["MattersAttention"].ToString();
                Checker = ds.Tables[0].Rows[0]["Checker"].ToString();
                if (ds.Tables[0].Rows[0]["CheckTime"].ToString() != "")
                {
                    CheckTime = DateTime.Parse(ds.Tables[0].Rows[0]["CheckTime"].ToString());
                }
                CheckStates = ds.Tables[0].Rows[0]["CheckStates"].ToString();
                EquipStates = ds.Tables[0].Rows[0]["EquipStates"].ToString();
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
            strSql.Append(" FROM LCXEquipment  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
