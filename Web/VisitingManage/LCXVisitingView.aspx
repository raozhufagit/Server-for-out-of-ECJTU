<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LCXVisitingView.aspx.cs" Inherits="VisitingManage_LCXVisitingView" %>

<!DOCTYPE html>

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
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;来访信息管理 &gt;&gt; 查看来访信息
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
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
        <tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		来访标题：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblVisitTitle" runat="server"></asp:Label>
       </td></tr>
		<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		来访单位：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblInVisitUnit" runat="server"></asp:Label>
       </td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		校内单位：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblInVisitGroup" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		来访目的：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblVisitPurpose" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		接待人员：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblReceptionist" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		工作报告：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblWorkReport" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		工作进度：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblWorkProgress" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		来访时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblVisitTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		合同以及附件：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblAttchment" runat="server"></asp:Label>
	</td></tr>
</table>
<hr style="height:1px; color: #003333;">
    &nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="../Project/ProjectManageN.aspx?OutVisiting=<%=OutVisitStr%>">签署项目</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="../CooperationAgreement/LCXCoopAgreementNA.aspx?OutVisiting=<%=OutVisitStr%>&DepartmentB=<%=InVisitUnit %>">签署战略协议</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="../CooperationAgreement/LCXForeignCooperationNA.aspx?OutVisiting=<%=OutVisitStr%>&DepartmentB=<%=InVisitUnit %>">签署合作协议</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="../CooperationAgreement/LCXContractManageNA.aspx?OutVisiting=<%=OutVisitStr%>&DepartmentB=<%=InVisitUnit %>">签署合同</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="LCXAccomRegistration.aspx?OutVisiting=<%=OutVisitStr%>">住宿登记</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="LCXDiningRegistration.aspx?OutVisiting=<%=OutVisitStr%>">用餐登记</a>&nbsp;&nbsp;
    <hr style="height:1px; color: #003333;">
    <IFRAME name="RMid" frameBorder="0" marginHeight="0" marginWidth="0" width="100%" height="500"
													BORDERCOLOR="#ffffFF"  src="../Project/ProjectManageN.aspx?OutVisiting=<%=OutVisitStr %>" border="0"></IFRAME>
    



</div>
    </form>
</body>
</html>
