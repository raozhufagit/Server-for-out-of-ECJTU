<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectView.aspx.cs" Inherits="Project_ProjectView" %>
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
  <script language="javascript">
  function PrintTable()
    {
        document.getElementById("PrintHide") .style.visibility="hidden"    
        print();
        document.getElementById("PrintHide") .style.visibility="visible"    
    }
  </script>
        <style type="text/css">
            .auto-style2 {
                width: 300px;
                height: 25px;
                background-color: #D6E2F3;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;项目管理 &gt;&gt; 查看项目信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <img class="HerCss" onclick="PrintTable()" src="../images/Button/BtnPrint.jpg" />
                    &nbsp;<img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;</td>
            </tr>
            <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
    <table style="width: 600px;  margin:0px auto;"   bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
		<tr>
	<td class="auto-style2" align="right">
		项目名称：
	</td>

	<td style="padding-left: 5px;  background-color: #ffffff;"  >
		<asp:Label id="ProjectName" runat="server"></asp:Label>
        &nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
            NavigateUrl="TuXingJinDu.aspx?ProjectName=0">图形化进度显示</asp:HyperLink></td></tr>
	<tr>
	<td class="auto-style2" align="right">
		项目状态：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style2" >
		<asp:Label id="ProjectSerils" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		甲方客户单位：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="SuoShuKeHu" runat="server"></asp:Label>
	</td>
        </tr>
	<tr>
	<td class="auto-style2" align="right">
		甲方项目负责人姓名：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="ContactPerson" runat="server"></asp:Label>
	</td>
        </tr>
	<tr>
	<td class="auto-style2" align="right">
		甲方项目负责人电话：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="ContactTel" runat="server"></asp:Label>
	</td>
        </tr>
	<tr>
	<td class="auto-style2" align="right">
		甲方项目负责人电子邮箱：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="ContactEmail" runat="server"></asp:Label>
	</td>
        </tr>
	<tr>
	<td class="auto-style2" align="right">
		项目合作方式及内容：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="XiangMuDaXiao" runat="server"></asp:Label>
	</td>
        </tr>
	<tr>
	<td class="auto-style2" align="right">
		校内学院推送：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="Push" runat="server"></asp:Label>
	</td>
	</tr>
	<tr>
	<td class="auto-style2" align="right">
		预计成交日期：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="YuJiChengJiaoRiQi" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		提醒日期：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="TiXingDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		校内负责人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="FuZeRen" runat="server" Text="暂无"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		项目金额：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="XiangMuJinE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		项目配合人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="PeiHeRenList" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		发布人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="UserName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		更新时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="TimeStr" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		合同以及附件：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="HeTongAndFuJian" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		验收方式及其他说明：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="BackInfo" runat="server"></asp:Label>
	</td></tr>
</table>
<hr style="height:1px; color: #003333;">
    &nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="PingShen.aspx?ProjectName=<%=CustomNameStr %>">评审信息</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="ProjectJinDu.aspx?ProjectName=<%=CustomNameStr %>">项目进度</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="ShouKuan.aspx?ProjectName=<%=CustomNameStr %>">收款信息</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="ShiShiRiZhi.aspx?ProjectName=<%=CustomNameStr %>">实施日志</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="LiRuiGuanLi.aspx?ProjectName=<%=CustomNameStr %>">项目利润</a>&nbsp;&nbsp;
    
    <hr style="height:1px; color: #003333;">
    <IFRAME name="RMid" frameBorder="0" marginHeight="0" marginWidth="0" width="100%" height="500"
													BORDERCOLOR="#ffffFF"  src="PingShen.aspx?ProjectName=<%=CustomNameStr %>" border="0"></IFRAME>
    



</div>
    </form>
</body>
</html>