using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    public class LCXEquipmentRepair
    {
        public LCXEquipmentRepair()
        { }
        #region Model
        private int _id;//ID
        private string _equipmentNo;//设备编号
        private string _equipmentName;//设备名称 
        private DateTime _repairTime;//维修时间
        private string _repairCost;//维修花费
        private string _checker;//核对人员
        private string _subPerson;//提交人
        private string _repairDept;//维修单位
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
        public DateTime RepairTime
        {
            set { _repairTime = value; }
            get { return _repairTime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string RepairCost
        {
            set { _repairCost = value; }
            get { return _repairCost; }
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
        public string RepairDept
        {
            set { _repairDept = value; }
            get { return _repairDept; }
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

        #endregion Model


        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public LCXEquipmentRepair(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ID,EquipmentName,EquipmentNo,RepairTime,RepairCost,Checker,SubPerson,RepairDept,Remarks");
            strSql.Append(" FROM LCXEquipmentRepair ");
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
                if (ds.Tables[0].Rows[0]["RepairTime"].ToString() != "")
                {
                    RepairTime = DateTime.Parse(ds.Tables[0].Rows[0]["RepairTime"].ToString());
                }
                RepairCost = ds.Tables[0].Rows[0]["RepairCost"].ToString();
                Checker = ds.Tables[0].Rows[0]["Checker"].ToString();
                SubPerson = ds.Tables[0].Rows[0]["SubPerson"].ToString();
                RepairDept = ds.Tables[0].Rows[0]["RepairDept"].ToString();
                Checker = ds.Tables[0].Rows[0]["Checker"].ToString();
                Remarks = ds.Tables[0].Rows[0]["Remarks"].ToString();
            }
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from LCXEquipmentRepair");
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
            strSql.Append("insert into LCXEquipmentRepair(");
            strSql.Append("EquipmentName,EquipmentNo,RepairTime,RepairCost,Checker,SubPerson,RepairDept,Remarks)");
            strSql.Append(" values (");
            strSql.Append("@EquipmentName,@EquipmentNo,@RepairTime,@RepairCost,@Checker,@SubPerson,@RepairDept,@Remarks)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@EquipmentName", SqlDbType.VarChar,50),
                    new SqlParameter("@EquipmentNo", SqlDbType.VarChar,50),
                    new SqlParameter("@RepairTime", SqlDbType.DateTime,50),
                    new SqlParameter("@RepairCost", SqlDbType.VarChar,50),
                    new SqlParameter("@Checker", SqlDbType.VarChar,20),
                    new SqlParameter("@SubPerson", SqlDbType.VarChar,20),
                    new SqlParameter("@RepairDept", SqlDbType.VarChar,50),
                    new SqlParameter("@Remarks",SqlDbType.VarChar,500)
                    };
            parameters[0].Value = EquipmentName;
            parameters[1].Value = EquipmentNo;
            parameters[2].Value = RepairTime;
            parameters[3].Value = RepairCost;
            parameters[4].Value = Checker;
            parameters[5].Value = SubPerson;
            parameters[6].Value = RepairDept;
            parameters[7].Value = Remarks;
            
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
            strSql.Append("update LCXEquipmentRepair set ");
            strSql.Append("EquipmentName=@EquipmentName,");
            strSql.Append("EquipmentNo=@EquipmentNo,");
            strSql.Append("RepairTime=@RepairTime,");
            strSql.Append("RepairCost=@RepairCost,");
            strSql.Append("Checker=@Checker,");
            strSql.Append("SubPerson=@SubPerson,");
            strSql.Append("RepairDept=@RepairDept,");
            strSql.Append("Remarks=@Remarks ");
            
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@ID", SqlDbType.Int,4),
                    new SqlParameter("@EquipmentName", SqlDbType.VarChar,50),
                    new SqlParameter("@EquipmentNo", SqlDbType.VarChar,50),
                    new SqlParameter("@RepairTime", SqlDbType.DateTime,50),
                    new SqlParameter("@RepairCost", SqlDbType.VarChar,50),
                    new SqlParameter("@Checker", SqlDbType.VarChar,50),
                    new SqlParameter("@SubPerson", SqlDbType.VarChar,50),
                    new SqlParameter("@RepairDept", SqlDbType.VarChar,50),
                    new SqlParameter("@Remarks", SqlDbType.VarChar,500)
                    
                    };
            parameters[0].Value = ID;
            parameters[1].Value = EquipmentName;
            parameters[2].Value = EquipmentNo;
            parameters[3].Value = RepairTime;
            parameters[4].Value = RepairCost;
            parameters[5].Value = Checker;
            parameters[6].Value = SubPerson;
            parameters[7].Value = RepairDept;
            parameters[8].Value = Remarks;
            

            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from LCXEquipmentRepair ");
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
            strSql.Append("select  top 1 ID,EquipmentName,EquipmentNo,RepairTime,RepairCost,Checker,SubPerson,RepairDept,Remarks");
            strSql.Append(" FROM LCXEquipmentRepair ");
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
                if (ds.Tables[0].Rows[0]["RepairTime"].ToString() != "")
                {
                    RepairTime = DateTime.Parse(ds.Tables[0].Rows[0]["RepairTime"].ToString());
                }
                RepairCost = ds.Tables[0].Rows[0]["RepairCost"].ToString();
                Checker = ds.Tables[0].Rows[0]["Checker"].ToString();
                SubPerson = ds.Tables[0].Rows[0]["SubPerson"].ToString();
                RepairDept = ds.Tables[0].Rows[0]["RepairDept"].ToString();
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
            strSql.Append(" FROM LCXEquipmentRepair  ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }
}
