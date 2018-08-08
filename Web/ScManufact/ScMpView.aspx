<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScMpView.aspx.cs" Inherits="ScManufact_ScMpView" %>

<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
  <script language="javascript">
      function PrintTable() {
          document.getElementById("PrintHide").style.visibility = "hidden"
          print();
          document.getElementById("PrintHide").style.visibility = "visible"
      }
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                 桌面 &nbsp;>>&nbsp;生产进度管理 &gt;&gt; 生产进度明细信息
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
		进度名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbJd_Name" runat="server"></asp:Label>
        &nbsp;&nbsp;
        </td></tr>
 
    	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		生产日期：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbJd_Time" runat="server"></asp:Label>
	</td></tr>

	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		计划完成日期：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbJd_OverTime" runat="server"></asp:Label>
	</td></tr> 
    <tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		状态：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbJd_State" runat="server"></asp:Label>
	</td></tr> 
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		审批人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbJd_Spr" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		审批时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbJd_SpTime" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		审批意见：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbJd_SpYj" runat="server"></asp:Label>
	</td></tr> 
    	 
    	 
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		文件及附件：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbJd_Fujian" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		备注说明：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbJd_Content" runat="server"></asp:Label>
	</td></tr>
</table>
    
    </div>
    </form>
</body>
</html>