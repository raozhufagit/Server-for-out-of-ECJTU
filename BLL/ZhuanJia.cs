using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using LCX.DBUtility;//请先添加引用

namespace LCX.BLL
{
    /// <summary>
    /// 类ZhuanJia。
    /// </summary>
    public class ZhuanJia
    {
        public ZhuanJia()
        { }
        #region Model
        private int _id;
        private string _gonghao;
        private string _bumen;
        private string _xingming;
        private string _xingbie;
        private DateTime? _chushengriqi;
        private string _xueli;
        private string _xuewei;
        private string _xueke;
        private string _yanjiulingyu;
        private string _zhiwu;
        private string _zhicheng;
        private DateTime? _timestr;
        private string _jianjie;
        private string _fujianstr;
        private string _username;
        private string _nation;//民族
        private string _political;//政治面貌
        private string _researchFind;//研究成果
        private string _portraitPath;//头像路径
        private int _states;//审核状态
        private string _checkAdvision;//审核意见
        private DateTime _checkTime;//审核时间
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 工号
        /// </summary>
        public string GongHao
        {
            set { _gonghao = value; }
            get { return _gonghao; }
        }

        /// <summary>
        /// 部门
        /// </summary>
        public string BuMen
        {
            set { _bumen = value; }
            get { return _bumen; }
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string XingMing
        {
            set { _xingming = value; }
            get { return _xingming; }
        }

        /// <summary>
        /// 性别
        /// </summary>
        public string XingBie
        {
            set { _xingbie = value; }
            get { return _xingbie; }
        }

        /// <summary>
        /// 出生日期
        /// </summary>
        public DateTime? ChuShengRiQi
        {
            set { _chushengriqi = value; }
            get { return _chushengriqi; }
        }

        /// <summary>
        /// 学历
        /// </summary>
        public string XueLi
        {
            set { _xueli = value; }
            get { return _xueli; }
        }

        /// <summary>
        /// 学位
        /// </summary>
        public string XueWei
        {
            set { _xuewei = value; }
            get { return _xuewei; }
        }

        /// <summary>
        /// 学科
        /// </summary>
        public string XueKe
        {
            set { _xueke = value; }
            get { return _xueke; }
        }

        /// <summary>
        /// 研究领域
        /// </summary>
        public string YanJiuLingYu
        {
            set { _yanjiulingyu = value; }
            get { return _yanjiulingyu; }
        }

        /// <summary>
        /// 职务
        /// </summary>
        public string ZhiWu
        {
            set { _zhiwu = value; }
            get { return _zhiwu; }
        }

        /// <summary>
        /// 职称
        /// </summary>
        public string ZhiCheng
        {
            set { _zhicheng = value; }
            get { return _zhicheng; }
        }

        /// <summary>
        /// 录入时间
        /// </summary>
        public DateTime? TimeStr
        {
            set { _timestr = value; }
            get { return _timestr; }
        }


        /// <summary>
        /// 简介
        /// </summary>
        public string JianJie
        {
            set { _jianjie = value; }
            get { return _jianjie; }
        }

        /// <summary>
        /// 附件文件
        /// </summary>
        public string FuJianStr
        {
            set { _fujianstr = value; }
            get { return _fujianstr; }
        }
        /// <summary>
        /// 录入人
        /// </summary>
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 民族
        /// </summary>
        public string Nation
        {
            set { _nation = value; }
            get { return _nation; }
        }
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string Political
        {
            set { _political = value; }
            get { return _political; }
        }
        /// <summary>
        /// 研究成果
        /// </summary>
        public string ResearchFind
        {
            set { _researchFind = value; }
            get { return _researchFind; }
        }
        /// <summary>
        /// 头像路径
        /// </summary>
        public string PortraitPath
        {
            set { _portraitPath = value; }
            get { return _portraitPath; }
        }
        /// <summary>
        /// 审核状态
        /// </summary>
        public int States
        {
            set { _states = value; }
            get { return _states; }
        }
        /// <summary>
        /// 审核意见
        /// </summary>
        public string CheckAdvision
        {
            set { _checkAdvision = value; }
            get { return _checkAdvision; }
        }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime CheckTime
        {
            set { _checkTime = value; }
            get { return _checkTime; }
        }
        #endregion Model


        #region  成员方法

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ZhuanJia(int idstr)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select ID,GongHao,BuMen,XingMing,XingBie,ChuShengRiQi,XueLi,XueWei,XueKe,YanJiuLingYu,ZhiWu,ZhiCheng,TimeStr,JianJie,FuJianStr,UserName,ResearchFind,Nation,Political,PortraitPath,States,CheckAdvision,CheckTime ");
            strSql.Append(" FROM ZhuanJia ");
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
                GongHao = ds.Tables[0].Rows[0]["GongHao"].ToString();
                BuMen = ds.Tables[0].Rows[0]["BuMen"].ToString();
                XingMing = ds.Tables[0].Rows[0]["XingMing"].ToString();
                XingBie = ds.Tables[0].Rows[0]["XingBie"].ToString();
                if (ds.Tables[0].Rows[0]["ChuShengRiQi"].ToString() != "")
                {
                    ChuShengRiQi = DateTime.Parse(ds.Tables[0].Rows[0]["ChuShengRiQi"].ToString());
                }
                XueLi = ds.Tables[0].Rows[0]["XueLi"].ToString();
                XueWei = ds.Tables[0].Rows[0]["XueWei"].ToString();
                XueKe = ds.Tables[0].Rows[0]["XueKe"].ToString();
                YanJiuLingYu = ds.Tables[0].Rows[0]["YanJiuLingYu"].ToString();
                ZhiWu = ds.Tables[0].Rows[0]["ZhiWu"].ToString();
                ZhiCheng = ds.Tables[0].Rows[0]["ZhiCheng"].ToString();
                if (ds.Tables[0].Rows[0]["TimeStr"].ToString() != "")
                {
                    TimeStr = DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
                }
                JianJie = ds.Tables[0].Rows[0]["JianJie"].ToString();
                FuJianStr = ds.Tables[0].Rows[0]["FuJianStr"].ToString();
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                ResearchFind = ds.Tables[0].Rows[0]["ResearchFind"].ToString();
                Political = ds.Tables[0].Rows[0]["Political"].ToString();
                PortraitPath= ds.Tables[0].Rows[0]["PortraitPath"].ToString();
                States= int.Parse(ds.Tables[0].Rows[0]["States"].ToString());
                CheckAdvision= ds.Tables[0].Rows[0]["CheckAdvision"].ToString();
                if (ds.Tables[0].Rows[0]["CheckTime"].ToString() != "")
                {
                    CheckTime = DateTime.Parse(ds.Tables[0].Rows[0]["CheckTime"].ToString());
                }
            }
        }

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {

            return DbHelperSQL.GetMaxID("ID", "ZhuanJia");
        }

        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ZhuanJia");
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
            strSql.Append("insert into ZhuanJia(");
            strSql.Append("GongHao,BuMen,XingMing,XingBie,ChuShengRiQi,XueLi,XueWei,XueKe,YanJiuLingYu,ZhiWu,ZhiCheng,TimeStr,JianJie,FuJianStr,UserName,ResearchFind,Nation,Political,PortraitPath)");
            strSql.Append(" values (");
            strSql.Append("@GongHao,@BuMen,@XingMing,@XingBie,@ChuShengRiQi,@XueLi,@XueWei,@XueKe,@YanJiuLingYu,@ZhiWu,@ZhiCheng,@TimeStr,@JianJie,@FuJianStr,@UserName,@ResearchFind,@Nation,@Political,@PortraitPath )");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                new SqlParameter("@GongHao", SqlDbType.Char,10),
                new SqlParameter("@BuMen", SqlDbType.VarChar,100),
                new SqlParameter("@XingMing", SqlDbType.VarChar,50),
                new SqlParameter("@XingBie", SqlDbType.VarChar,10),
                new SqlParameter("@ChuShengRiQi", SqlDbType.Date),
                new SqlParameter("@XueLi", SqlDbType.VarChar,50),
                new SqlParameter("@XueWei", SqlDbType.VarChar,50),
                new SqlParameter("@XueKe", SqlDbType.VarChar,50),
                new SqlParameter("@YanJiuLingYu", SqlDbType.VarChar,100),
                new SqlParameter("@ZhiWu", SqlDbType.VarChar,50),
                new SqlParameter("@ZhiCheng", SqlDbType.VarChar,50),
                new SqlParameter("@TimeStr", SqlDbType.DateTime),
                new SqlParameter("@JianJie", SqlDbType.Text),
                new SqlParameter("@FuJianStr", SqlDbType.VarChar,500),
                new SqlParameter("@UserName", SqlDbType.VarChar,50), 
                new SqlParameter("@ResearchFind", SqlDbType.Text),
                new SqlParameter("@Nation", SqlDbType.VarChar,10),
                new SqlParameter("@Political", SqlDbType.VarChar,50),
                new SqlParameter("@PortraitPath", SqlDbType.VarChar,200)};
            parameters[0].Value = GongHao;
            parameters[1].Value = BuMen;
            parameters[2].Value = XingMing;
            parameters[3].Value = XingBie;
            parameters[4].Value = ChuShengRiQi;
            parameters[5].Value = XueLi;
            parameters[6].Value = XueWei;
            parameters[7].Value = XueKe;
            parameters[8].Value = YanJiuLingYu;
            parameters[9].Value = ZhiWu;
            parameters[10].Value = ZhiCheng;
            parameters[11].Value = TimeStr;
            parameters[12].Value = JianJie;
            parameters[13].Value = FuJianStr;
            parameters[14].Value = UserName;
            parameters[15].Value = ResearchFind;
            parameters[16].Value = Nation;
            parameters[17].Value = Political;
            parameters[18].Value = PortraitPath;
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
            strSql.Append("update ZhuanJia set ");
            strSql.Append("GongHao=@GongHao, ");
            strSql.Append("BuMen=@BuMen,");
            strSql.Append("XingMing=@XingMing, ");
            strSql.Append("XingBie=@XingBie,");
            strSql.Append("XueLi=@XueLi,");
            strSql.Append("XueWei=@XueWei,");
            strSql.Append("XueKe=@XueKe, ");
            strSql.Append("YanJiuLingYu=@YanJiuLingYu,");
            strSql.Append("ZhiWu=@ZhiWu,");
            strSql.Append("ZhiCheng=@ZhiCheng, ");
            strSql.Append("TimeStr=@TimeStr,");
            strSql.Append("JianJie=@JianJie,");
            strSql.Append("FuJianStr=@FuJianStr,");
            strSql.Append("UserName=@UserName,");
            strSql.Append("ResearchFind=@ResearchFind,");
            strSql.Append("Nation=@Nation, ");
            strSql.Append("Political=@Political, ");
            strSql.Append("PortraitPath=@PortraitPath, ");
            strSql.Append("States=@States, ");
            strSql.Append("CheckAdvision=@CheckAdvision, ");
            strSql.Append("CheckTime=@CheckTime  ");
            strSql.Append(" where ID=@ID ");
            SqlParameter[] parameters = {
                new SqlParameter("@ID", SqlDbType.Int,4),
                new SqlParameter("@GongHao", SqlDbType.Char,10),
                new SqlParameter("@BuMen", SqlDbType.VarChar,100),
                new SqlParameter("@XingMing", SqlDbType.VarChar,50),
                new SqlParameter("@XingBie", SqlDbType.VarChar,10),
                new SqlParameter("@XueLi", SqlDbType.VarChar,50),
                new SqlParameter("@XueWei", SqlDbType.VarChar,50),
                new SqlParameter("@XueKe", SqlDbType.VarChar,100),
                new SqlParameter("@YanJiuLingYu", SqlDbType.VarChar,100),
                new SqlParameter("@ZhiWu", SqlDbType.VarChar,50),
                new SqlParameter("@ZhiCheng", SqlDbType.VarChar,50),
                new SqlParameter("@TimeStr", SqlDbType.DateTime),
                new SqlParameter("@JianJie", SqlDbType.Text),
                new SqlParameter("@FuJianStr", SqlDbType.VarChar,500),
                new SqlParameter("@UserName", SqlDbType.VarChar,50),
                new SqlParameter("@ResearchFind", SqlDbType.Text),
                new SqlParameter("@Nation", SqlDbType.VarChar,10),
                new SqlParameter("@Political", SqlDbType.VarChar,20),
                new SqlParameter("@PortraitPath", SqlDbType.VarChar,200),
                new SqlParameter("@States", SqlDbType.Int,4),
                new SqlParameter("@CheckAdvision", SqlDbType.VarChar,200),
                new SqlParameter("@CheckTime", SqlDbType.DateTime)
            };
            parameters[0].Value = ID;
            parameters[1].Value = GongHao;
            parameters[2].Value = BuMen;
            parameters[3].Value = XingMing;
            parameters[4].Value = XingBie;
            parameters[5].Value = XueLi;
            parameters[6].Value = XueWei;
            parameters[7].Value = XueKe;
            parameters[8].Value = YanJiuLingYu;
            parameters[9].Value = ZhiWu;
            parameters[10].Value = ZhiCheng;
            parameters[11].Value = TimeStr;
            parameters[12].Value = JianJie;
            parameters[13].Value = FuJianStr;
            parameters[14].Value = UserName;
            parameters[15].Value = ResearchFind;
            parameters[16].Value = Nation;
            parameters[17].Value = Political;
            parameters[18].Value = PortraitPath;
            parameters[19].Value = States;
            parameters[20].Value = CheckAdvision;
            parameters[21].Value = DateTime.Now;
            return DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
        }
       

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public void Delete(int idstr)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ZhuanJia ");
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
            strSql.Append("select  top 1 ID,GongHao,BuMen,XingMing,XingBie,ChuShengRiQi,XueLi,XueWei,XueKe,YanJiuLingYu,ZhiWu,ZhiCheng,TimeStr,JianJie,FuJianStr,UserName,ResearchFind,Nation,Political,PortraitPath,States ");
            strSql.Append(" FROM ZhuanJia ");
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
                GongHao = ds.Tables[0].Rows[0]["GongHao"].ToString();
                BuMen = ds.Tables[0].Rows[0]["BuMen"].ToString();
                XingMing = ds.Tables[0].Rows[0]["XingMing"].ToString();
                XingBie = ds.Tables[0].Rows[0]["XingBie"].ToString();
                if (ds.Tables[0].Rows[0]["ChuShengRiQi"].ToString() != "")
                {
                    ChuShengRiQi = DateTime.Parse(ds.Tables[0].Rows[0]["ChuShengRiQi"].ToString());
                }
                XueLi = ds.Tables[0].Rows[0]["XueLi"].ToString();
                XueWei = ds.Tables[0].Rows[0]["XueWei"].ToString();
                XueKe = ds.Tables[0].Rows[0]["XueKe"].ToString();
                YanJiuLingYu = ds.Tables[0].Rows[0]["YanJiuLingYu"].ToString();
                ZhiWu = ds.Tables[0].Rows[0]["ZhiWu"].ToString();
                ZhiCheng = ds.Tables[0].Rows[0]["ZhiCheng"].ToString();
                if (ds.Tables[0].Rows[0]["TimeStr"].ToString() != "")
                {
                    TimeStr = DateTime.Parse(ds.Tables[0].Rows[0]["TimeStr"].ToString());
                }
                JianJie = ds.Tables[0].Rows[0]["JianJie"].ToString();
                FuJianStr = ds.Tables[0].Rows[0]["FuJianStr"].ToString();
                UserName = ds.Tables[0].Rows[0]["UserName"].ToString();
                ResearchFind = ds.Tables[0].Rows[0]["ResearchFind"].ToString();
                Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                Political = ds.Tables[0].Rows[0]["Political"].ToString();
                PortraitPath = ds.Tables[0].Rows[0]["PortraitPath"].ToString();
                if (ds.Tables[0].Rows[0]["States"].ToString() != "")
                {
                    States = int.Parse(ds.Tables[0].Rows[0]["States"].ToString());
                }
                //States= int.Parse(ds.Tables[0].Rows[0]["States"].ToString());
            }
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * ");
            strSql.Append(" FROM ZhuanJia ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        #endregion  成员方法
    }


}
