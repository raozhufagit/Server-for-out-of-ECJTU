using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class NWorkFlow_GoToNextNode : System.Web.UI.Page
{    
    protected void Page_Load(object sender, EventArgs e)
    {
        //该节点根据传过来的工作的ID信息，查询到使用的工作流、当前节点信息（全部通过往下流转、一个通过往下流转）
        //根据节点信息、该工作的通过人列表信息、审批人列表信息===>该节点是否应该继续往下流转
        //如果要往下流转则显示页面上的下一节点设置信息，否则用程序跳转回待办事项页面。

        //根据Type参数属性，Type为0时为正常下一节点，Type为1时为绑定所有节点供选择。
        if (!Page.IsPostBack)
        {
            LCX.BLL.LCX_WorkToDo MyModel = new LCX.BLL.LCX_WorkToDo();
            MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));
            this.Label1.Text = MyModel.WorkName;
            this.Label4.Text = MyModel.FormContent.Replace("disabled", "").Replace("hidden", "visible");
            
            //判断 当前节点信息（全部通过可向下流转、一人通过可向下流转）  该工作的通过人列表信息、审批人列表信息
            string SPMoShi = LCX.DBUtility.DbHelperSQL.GetSHSL("select top 1 PSType from LCX_WorkFlowNode where ID=" + MyModel.JieDianID.ToString());
            if (CheCkIfOk(MyModel.OKUserList, MyModel.ShenPiUserList, SPMoShi) == true)
            {
                //绑定下一个节点
                try
                {
                    //绑定下一节点  正常状态
                    if (Request.QueryString["Type"].ToString().Trim() == "0")
                    {
                        //绑定下一节点
                        string[] NextStrList = LCX.DBUtility.DbHelperSQL.GetSHSL("select NextNode from LCX_WorkFlowNode where ID=" + MyModel.JieDianID.ToString()).Split(',');
                        for (int i = 0; i < NextStrList.Length; i++)
                        {
                            ListItem MyItem = new ListItem();
                            MyItem.Value = LCX.DBUtility.DbHelperSQL.GetSHSL("select ID from LCX_WorkFlowNode where NodeSerils='" + NextStrList[i].ToString() + "' and WorkFlowID=" + MyModel.WorkFlowID.ToString());//根据序号和workflowID获得节点ID
                            MyItem.Text = "节点序号：" + NextStrList[i].ToString() + "--节点名称：" + LCX.DBUtility.DbHelperSQL.GetSHSL("select NodeName from LCX_WorkFlowNode where NodeSerils='" + NextStrList[i].ToString() + "' and WorkFlowID=" + MyModel.WorkFlowID.ToString());
                            if (MyItem.Value.ToString().Length > 0)
                            {
                                this.DropDownList3.Items.Add(MyItem);
                            }
                        }
                    }
                    else //绑定所有节点（除开始节点）
                    {
                        //清除根据条件决定下一节点选项
                        this.CheckBox1.Checked = false;
                        this.CheckBox1.Enabled = false;


                        DataSet MyDS = LCX.DBUtility.DbHelperSQL.GetDataSet("select ID,NodeSerils,NodeName from LCX_WorkFlowNode where WorkFlowID=" + MyModel.WorkFlowID.ToString());
                        for (int jjj = 0; jjj < MyDS.Tables[0].Rows.Count; jjj++)
                        {
                            ListItem MyItem = new ListItem();
                            MyItem.Value = MyDS.Tables[0].Rows[jjj]["ID"].ToString();
                            MyItem.Text = "节点序号：" + MyDS.Tables[0].Rows[jjj]["NodeSerils"].ToString() + "--节点名称：" + MyDS.Tables[0].Rows[jjj]["NodeName"].ToString();
                            if (MyItem.Value.ToString().Length > 0)
                            {
                                this.DropDownList3.Items.Add(MyItem);
                            }
                        }
                    }

                    //根据选择的节点，绑定人员等信息。
                    LCX.BLL.LCX_WorkFlowNode MyJieDian = new LCX.BLL.LCX_WorkFlowNode();
                    MyJieDian.GetModel(int.Parse(this.DropDownList3.SelectedItem.Value.ToString()));
                    this.TextBox1.Text = MyJieDian.PSType;
                    this.TextBox2.Text = MyJieDian.SPType;

                    SetPageFromPSStr(MyJieDian.SPType, MyJieDian.SPDefaultList);
                }
                catch
                { }
            }
            else
            {
                LCX.Common.MessageBox.ShowAndRedirect(this, "该节点工作需要等待其他人全部办理后才能继续往下流转，请继续等待！", "NowWorkFlow.aspx");
            }

            //~~~~~~~~~~~~~~~~~当前节点为空！并且下一节点的下拉框也为空！······直接进行提交操作！
            if (this.DropDownList3.Items.Count <= 0 && LCX.DBUtility.DbHelperSQL.GetSHSL("select NodeAddr from LCX_WorkFlowNode where ID=" + MyModel.JieDianID.ToString()) == "结束")
            {
                this.RequiredFieldValidator2.Enabled = false;
                LCX.Common.MessageBox.ResponseScript(this, "document.getElementById('ImageButton1').click();");
            }
            //~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }
    }
    /// <summary>
    /// 根据审批模式字符串设置页面显示
    /// </summary>
    /// <param name="SPStr"></param>
    public void SetPageFromPSStr(string SPStr, string DefultStr)
    {
        if (SPStr == "审批时自由指定")
        {
            this.TextBox5.Text = "";
        }
        else if (SPStr == "从默认审批人中选择")
        {
            this.TextBox5.Text = DefultStr;
        }
        else if (SPStr == "从默认审批部门中选择")
        {
            string SqlWhere = "";
            string[] DefultList = DefultStr.Split(',');
            for (int i = 0; i < DefultList.Length; i++)
            {
                if (SqlWhere.Trim().Length > 0)
                {
                    SqlWhere = SqlWhere + " or  " + " ','+Department+',' like '%," + DefultList[i].ToString() + ",%' ";
                }
                else
                {
                    SqlWhere = " ','+Department+',' like '%," + DefultList[i].ToString() + ",%' ";
                }
            }

            this.TextBox5.Text = LCX.DBUtility.DbHelperSQL.GetStringList("select UserName from LCXUser where " + SqlWhere).Replace("|", ",");
        }
        else if (SPStr == "从默认审批角色中选择")
        {
            string SqlWhere = "";
            string[] DefultList = DefultStr.Split(',');
            for (int i = 0; i < DefultList.Length; i++)
            {
                if (SqlWhere.Trim().Length > 0)
                {
                    SqlWhere = SqlWhere + " or  " + " ','+JiaoSe+',' like '%," + DefultList[i].ToString() + ",%' ";
                }
                else
                {
                    SqlWhere = " ','+JiaoSe+',' like '%," + DefultList[i].ToString() + ",%' ";
                }
            }

            this.TextBox5.Text = LCX.DBUtility.DbHelperSQL.GetStringList("select UserName from LCXUser where " + SqlWhere).Replace("|", ",");
        }
        else if (SPStr == "自动选择流程发起人")
        {
            this.TextBox5.Text = LCX.Common.PublicMethod.GetSessionValue("UserName");
        }
        else if (SPStr == "自动选择本部门主管")
        {
            this.TextBox5.Text = LCX.DBUtility.DbHelperSQL.GetSHSL("select top 1 ChargeMan from LCXDept where BuMenName='" + LCX.Common.PublicMethod.GetSessionValue("Department") + "'");
        }
        else if (SPStr == "自动选择上级部门主管")
        {
            this.TextBox5.Text = LCX.DBUtility.DbHelperSQL.GetSHSL("select top 1 ChargeMan from LCXDept where ID=(select top 1 DirID from LCXDept where BuMenName='" + LCX.Common.PublicMethod.GetSessionValue("Department") + "')");
        }
    }
    protected bool CheCkIfOk(string TongGuoStr, string ShenPiList, string TiaoJianStr)
    {
        if (Request.QueryString["DoType"].ToString() == "putong")
        {
            if (TiaoJianStr == "一人通过可向下流转")
            {
                return true;
            }
            else
            {
                //判断审批人列表是否全部在通过人列表中
                string[] ShenPiArry = ShenPiList.Split(',');
                for (int i = 0; i < ShenPiArry.Length; i++)
                {
                    if (LCX.Common.PublicMethod.StrIFIn("," + ShenPiArry[i] + ",", "," + TongGuoStr + ",") == false)
                    {
                        //检测到任何一个审批人不在已经通过列表中，则返回false
                        return false;
                    }
                }
                return true;
            }
        }
        else
        {
            return true;
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //根据选择的节点，绑定人员等信息。
            LCX.BLL.LCX_WorkFlowNode MyJieDian = new LCX.BLL.LCX_WorkFlowNode();
            MyJieDian.GetModel(int.Parse(this.DropDownList3.SelectedItem.Value.ToString()));
            this.TextBox1.Text = MyJieDian.PSType;
            this.TextBox2.Text = MyJieDian.SPType;

            SetPageFromPSStr(MyJieDian.SPType, MyJieDian.SPDefaultList);
        }
        catch
        { }
    }

    public int CheckCondition(string DefaultNodeID)
    {
        LCX.BLL.LCX_WorkToDo MyModel = new LCX.BLL.LCX_WorkToDo();
        MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        //格式如：DEFG_请假天数→大于→10→3|ABCD_请假天数→大于→10→3
        string[] TiaoJianList = LCX.DBUtility.DbHelperSQL.GetSHSL("select ConditionSet from LCX_WorkFlowNode where ID=" + MyModel.JieDianID.ToString()).Split('|');
        for (int i = 0; i < TiaoJianList.Length; i++)
        {
            if (TiaoJianList[i].Trim().Length > 0)
            {
                string NextIDStr = CheckTiaoJian(TiaoJianList[i].ToString());
                if (NextIDStr != "0")
                {
                    return int.Parse(NextIDStr);
                    break; //跳出当前循环
                }
            }
        }
        return int.Parse(DefaultNodeID);
    }
    /// <summary>
    /// 比较两个字符串，返回结果是否正确
    /// </summary>
    /// <param name="Str1"></param>
    /// <param name="Str2"></param>
    /// <param name="BiJiaoTiaoJian"></param>
    /// <param name="LeiXing"></param>
    /// <returns></returns>
    protected bool BiaoJiaoTwoStr(string Str1, string Str2, string BiJiaoTiaoJian)
    {
        try
        {
            double A1 = double.Parse(Str1);
            double A2 = double.Parse(Str2); //大于  大于等于   小于  小于等于   等于   不等于  包含  不包含
            if (BiJiaoTiaoJian == "大于" && A1 > A2)
            {
                return true;
            }
            else if (BiJiaoTiaoJian == "大于等于" && A1 >= A2)
            {
                return true;
            }
            else if (BiJiaoTiaoJian == "小于" && A1 < A2)
            {
                return true;
            }
            else if (BiJiaoTiaoJian == "小于等于" && A1 <= A2)
            {
                return true;
            }
            else if (BiJiaoTiaoJian == "等于" && A1 == A2)
            {
                return true;
            }
            else if (BiJiaoTiaoJian == "不等于" && A1 != A2)
            {
                return true;
            }
            else if (BiJiaoTiaoJian == "包含" && LCX.Common.PublicMethod.StrIFIn(Str2, Str1))
            {
                return true;
            }
            else if (BiJiaoTiaoJian == "不包含")
            {
                if (LCX.Common.PublicMethod.StrIFIn(Str2, Str1))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
        catch
        {
            if (BiJiaoTiaoJian == "等于" && Str1 == Str2)
            {
                return true;
            }
            else if (BiJiaoTiaoJian == "不等于" && Str1 != Str2)
            {
                return true;
            }
            else if (BiJiaoTiaoJian == "包含" && LCX.Common.PublicMethod.StrIFIn(Str2, Str1))
            {
                return true;
            }
            else if (BiJiaoTiaoJian == "不包含")
            {
                if (LCX.Common.PublicMethod.StrIFIn(Str2, Str1))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 判断条件，返回下一节点ID
    /// </summary>
    /// <param name="FormCcontent"></param>
    /// <param name="TiaoJianStr"></param>
    /// <param name="WorkFlowIDStr"></param>
    /// <returns></returns>
    protected string CheckTiaoJian(string TiaoJianStr)
    {
        LCX.BLL.LCX_WorkToDo MyModel = new LCX.BLL.LCX_WorkToDo();
        MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        //条件格式如：ABCD_请假天数→大于→10→3        
        string ZiDuanStrEN = TiaoJianStr.Split('_')[0]; //字段名称EN 如：ABCD        
        string ZiDuanStrCN = TiaoJianStr.Split('_')[1]; //字段名称CN 如：请假天数        
        string BiJiaoStr = TiaoJianStr.Split('→')[1]; //条件比较  如：大于
        string ZhiStr = TiaoJianStr.Split('→')[2];//比较的值，如： 10
        string JieDianXuHaoStr = TiaoJianStr.Split('→')[3];//跳转的节点序号，如： 3

        string NowValue = "";
        try
        {
            NowValue = Request.Form[ZiDuanStrEN].ToString();
        }
        catch
        { }

        if (BiaoJiaoTwoStr(NowValue, ZhiStr, BiJiaoStr) == true)
        {
            return LCX.DBUtility.DbHelperSQL.GetSHSLInt("select top 1 ID from LCX_WorkFlowNode where NodeSerils='" + JieDianXuHaoStr + "' and WorkFlowID=" + MyModel.WorkFlowID.ToString());
        }
        else
        {
            return "0";
        }
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        BanLiWork();
    }

    public void BanLiWork()
    {
        LCX.BLL.LCX_WorkToDo XMyModel = new LCX.BLL.LCX_WorkToDo();
        XMyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        //初始化
        string XJieDianIDStr = "0";
        string XJieDianNameStr = "";
        string XShenPiUserListStr = "";
        string XTongGuoRenListStr = "";
        string XStateNowStr = "正在办理";

        string JingBanRenStr = "";//条件判断时读取经办人
        try
        {
            if (CheckBox1.Checked == true)
            {
                //条件未找到或者没有匹配项时，采用选择好的节点
                XJieDianIDStr = this.DropDownList3.SelectedValue.ToString();
                try
                {
                    ///////////根据条件获取下一审批节点信息                    
                    XJieDianIDStr = CheckCondition(this.DropDownList3.SelectedValue.ToString()).ToString();
                }
                catch
                {
                    XJieDianIDStr = this.DropDownList3.SelectedValue.ToString();
                }
            }
            else
            {
                XJieDianIDStr = this.DropDownList3.SelectedValue.ToString();
            }
            XStateNowStr = "正在办理";
            XJieDianNameStr = LCX.DBUtility.DbHelperSQL.GetSHSL("select NodeName from LCX_WorkFlowNode where ID=" + XJieDianIDStr);
        }
        catch
        {
            if (LCX.DBUtility.DbHelperSQL.GetSHSL("select NodeAddr from LCX_WorkFlowNode where ID=" + XMyModel.JieDianID.ToString()) == "结束")
            {
                XStateNowStr = "正常结束";
                XJieDianIDStr = XMyModel.JieDianID.ToString();
                GetDetailsData();//写入明细表
            }
            else
            {
                XStateNowStr = "强制结束";
                XJieDianIDStr = XMyModel.JieDianID.ToString();
                GetDetailsData();//写入明细表
            }
            XJieDianNameStr = "结束";
        }
        if (JingBanRenStr == "")
        {
            XShenPiUserListStr = LCX.Common.PublicMethod.WorkWeiTuoUserList(this.TextBox5.Text);
        }
        else
        {
            XShenPiUserListStr = LCX.Common.PublicMethod.WorkWeiTuoUserList(JingBanRenStr);
        }
        if (XShenPiUserListStr.Trim().Length <= 0)
        {
            XShenPiUserListStr = "工作已办结";
        }
        XTongGuoRenListStr = "默认";
        //执行uodate语句
        LCX.DBUtility.DbHelperSQL.ExecuteSQL("update LCX_WorkToDo set LateTime='" + DateTime.Now.AddHours(double.Parse(LCX.DBUtility.DbHelperSQL.GetSHSLInt("select top 1 JieShuHours from LCX_WorkFlowNode where ID=" + XJieDianIDStr))).ToString() + "',JieDianID=" + XJieDianIDStr + ",JieDianName='" + XJieDianNameStr + "',ShenPiUserList='" + XShenPiUserListStr + "',OKUserList='" + XTongGuoRenListStr + "',StateNow='" + XStateNowStr + "' where ID=" + Request.QueryString["ID"].ToString());



        if (XStateNowStr == "正在办理")
        {
            //发送短信
            SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, "您有新的工作需要办理！(" + this.Label1.Text + ")", LCX.Common.PublicMethod.WorkWeiTuoUserList(this.TextBox5.Text.Trim()), HttpContext.Current.Request.Url.Host + "/NWorkFlow/DoWork.aspx?DoType=putong&ID=" + Request.QueryString["ID"].ToString());
        }
        else if (XStateNowStr == "正常结束")
        {
            SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, "您的工作已经正常结束！(" + this.Label1.Text + ")", XMyModel.UserName);
        }
        else
        {
            SendMainAndSms.SendMessage(CHKSMS, CHKRTX, CHKMOB, "您的工作已经被强制结束！(" + this.Label1.Text + ")", XMyModel.UserName);
        }





        //写系统日志
        LCX.BLL.LCXRiZhi MyRiZhi = new LCX.BLL.LCXRiZhi();
        MyRiZhi.UserName = LCX.Common.PublicMethod.GetSessionValue("UserName");
        MyRiZhi.DoSomething = "用户办理工作(" + this.Label1.Text + ")";
        MyRiZhi.IpStr = System.Web.HttpContext.Current.Request.UserHostAddress.ToString();
        MyRiZhi.Add();

        LCX.Common.MessageBox.ShowAndRedirect(this, "工作办理成功！", "NowWorkFlow.aspx");
    }
    /// <summary>
    /// 将表单中个数据列的数据写入明细记录表中，便于后期统计
    /// </summary>
    public void GetDetailsData()
    {
        LCX.BLL.LCX_WorkToDo MyModel = new LCX.BLL.LCX_WorkToDo();
        MyModel.GetModel(int.Parse(Request.QueryString["ID"].ToString()));

        //获取当前表单对应的工作数据列
        string[] FormItemList = LCX.DBUtility.DbHelperSQL.GetSHSL("select top 1 ItemsList from LCX_Form where ID=" + MyModel.FormID.ToString()).Split('|');

        for (int i = 0; i < FormItemList.Length; i++)
        {
            if (FormItemList[i].Trim().Length > 0)
            {
                try
                {
                    LCX.BLL.LCX_WorkDetails Model = new LCX.BLL.LCX_WorkDetails();
                    Model.WorkID = int.Parse(Request.QueryString["ID"].ToString());
                    Model.ItemsNameCN = FormItemList[i].Split('_')[1];
                    Model.ItemsNameEn = FormItemList[i].Split('_')[0];
                    Model.ItemsValue = Request.Form[FormItemList[i].Split('_')[0]].ToString();

                    Model.Add();
                }
                catch { }
            }
        }
    }
}
