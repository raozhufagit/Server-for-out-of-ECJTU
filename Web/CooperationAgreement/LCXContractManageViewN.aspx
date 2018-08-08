<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LCXContractManageViewN.aspx.cs" Inherits="CooperationAgreement_LCXContractManageViewN" %>

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
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;对外合作协议管理 &gt;&gt; 查看对外合作协议信息
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
		合同编号：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblContractNo" runat="server"></asp:Label>
        
        </td></tr>
		<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		合同名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblContractName" runat="server"></asp:Label>
        
        </td></tr>
	<tr>
        <tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		合同类型：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblContractType" runat="server"></asp:Label>
        
        </td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		校内单位：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblDepartmentA" runat="server"></asp:Label>
	</td></tr>
        <tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		校外单位：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblDepartmentB" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		校内单位签署人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblSignatoryA" runat="server"></asp:Label>
	</td></tr>
        <tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		校外单位签署人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblSignatoryB" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		签署时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblSignTime" runat="server"></asp:Label>
	</td></tr>
        <tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		结束时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblEndTime" runat="server"></asp:Label>
	</td></tr>
        <tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		是否保密：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblWhetherSecrecy" runat="server"></asp:Label>
	</td></tr>
        <tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		所属项目：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblProject" runat="server"></asp:Label>
	</td></tr>
        <tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		所属协议：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblAgreement" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		合作内容：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblContractContent" runat="server"></asp:Label>
	</td></tr>
	
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		合同以及附件：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblAttchment" runat="server"></asp:Label>
	</td></tr>
</table>
      
        </div>
        </form>
    </body>
    </html>

