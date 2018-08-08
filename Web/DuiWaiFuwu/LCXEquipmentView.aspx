<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LCXEquipmentView.aspx.cs" Inherits="DuiWaiFuwu_LCXEquipmentView" %>

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
        <style type="text/css">
            table{margin:0 auto;}
            .auto-style1 {
                height: 45px;
                width: 11%;
            }
            .auto-style2 {
                height: 45px;
                width: 22%;
            }
            .auto-style3 {
                height: 45px;
                width: 24%;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                 <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;仪器设备&nbsp;>>&nbsp;添加信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;</td>
            </tr>
            <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
<table style="width: 80%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
	<tr>
	<td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
		设备名称：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff;" class="auto-style3" >
		<asp:label id="lblEquipmentName" runat="server" Width="150px"></asp:label>
        	&nbsp;</td>
<td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
		设备编号：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff;" class="auto-style2" >
		<asp:label id="lblEquipmentNo" runat="server" Width="150px"></asp:label>
		&nbsp;</td>
         <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		出厂编号：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style2" >
		<asp:label id="lblFactoryNo" runat="server" Width="150px"></asp:label>
		&nbsp;</td>
        
	</tr>
	
	
	<tr>
	
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		设备类别：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style2" >
		<asp:label id="lblEquipmentType" runat="server" Width="150px"></asp:label>
		&nbsp;</td>
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		型号：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style1" >
		<asp:label id="lblEquipmentModel" runat="server" Width="150px"></asp:label>
		&nbsp;</td>
        <td style="width: 10%; height: 25px; background-color: #D6E2F3; text-align: right">
                    设备状态 ：
                </td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:label id="lblEquipStates" runat="server" Width="150px"></asp:label>
                   
                </td> 
	</tr>
	
	<tr>
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		所在部门：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style1" >
		<asp:label id="lblBelongDept" runat="server" Width="150px"></asp:label>
		&nbsp;</td>
	
      <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		购买价格：
	</td>
	<td style="padding-left: 5px; height: 45px; background-color: #ffffff" >
		<asp:label id="lblBuyPrice" runat="server" Width="150px"></asp:label>
	</td> 
      <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		购买时间：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label id="lblBuyTime" runat="server" Width="150px" DataFormatString="{0:yyyy-mm-dd}"></asp:label>
	</td> 
	</tr>
	
	<tr>
	<td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		生产厂家：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label id="lblFactoryName" runat="server" Width="150px"></asp:label>
		&nbsp;</td>
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		管理人：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label id="lblManager" runat="server" Width="150px"></asp:label>
		&nbsp;</td>
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		审核人：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label id="lblChecker" runat="server" Width="150px"></asp:label>
		&nbsp;</td>
	</tr>
	
	
	
	
	
	
	
	
	<tr>
	<td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		审核日期：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label id="lblCheckTime" runat="server" Width="150px" DataFormatString="{0:yyyy-mm-dd}"></asp:label>
	</td>
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		存放位置：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" colspan="3" >
		<asp:label id="lblStoragePosition" runat="server" Width="500px"></asp:label>
	</td>
	 <tr><td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
		注意事项：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" colspan="5">
		<asp:label id="lblMattersAttention" runat="server" Width="100%" TextMode="MultiLine" Rows="10" ></asp:label>
		</td></tr>
     
    <tr><td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
		备注：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" colspan="5">
		<asp:label id="lblRemarks" runat="server" Width="100%" TextMode="MultiLine" Rows="10" ></asp:label>
		</td></tr>


  
    
</table>
      
<hr style="height:1px; color: #003333;">
    &nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="LCXEquipmentRent.aspx?EquipmentNo=<%=EquipmentNoStr%>">租借记录</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="LCXEquipmentRepair.aspx?EquipmentNo=<%=EquipmentNoStr%>">维修记录</a>&nbsp;&nbsp;
    
   
    <hr style="height:1px; color: #003333;">
    <IFRAME name="RMid" frameBorder="0" marginHeight="0" marginWidth="0" width="100%" height="500"
													BORDERCOLOR="#ffffFF"  src="LCXEquipmentRent.aspx?EquipmentNo=<%=EquipmentNoStr%>" border="0"></IFRAME>
    


		</div>
	</form>
</body>
</html>

