<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScDetail11.aspx.cs" Inherits="ScManufact_ScDetail11" %>


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
                 桌面 &nbsp;>>&nbsp;生产管理 &gt;&gt; 生产明细单信息技术审核
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
		生产明细单名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbPc_Name" runat="server"></asp:Label>
        &nbsp;&nbsp;
        </td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		文件版本号：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbPc_Vesion" runat="server"></asp:Label>
	</td></tr>
    	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		明细单制单人员：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbPc_UserName" runat="server"></asp:Label>
	</td></tr>

	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		制单日期：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbPc_Timer" runat="server"></asp:Label>
	</td></tr> 
    <tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		状态：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbPc_State" runat="server"></asp:Label>
	</td></tr> 
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		文件及附件：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbPc_Wenjian" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		备注说明：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lbPc_mark" runat="server"></asp:Label>
	</td></tr>
    <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            通知人员选择：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:TextBox ID="txtGongGao" runat="server" onkeydown="javascript:return false;" 
                Width="349px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGongGao"
                Display="Dynamic" ErrorMessage="*必须指定审批人"></asp:RequiredFieldValidator><img class="HerCss" id="searchimg" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=LCXUser&LieName=UserName&Condition='+document.getElementById('txtGongGao').value+'&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtGongGao').value=wName;}"
                src="../images/Button/search.gif" /><asp:CheckBox ID="CHKSMS" runat="server" Checked="True" /><img
                    src="../images/TreeImages/@sms.gif" />短消息<asp:CheckBox ID="CHKRTX" 
                        runat="server" /><img
                                src="../images/TreeImages/notify2.gif" />微信<asp:CheckBox ID="CHKMOB" runat="server" /><img
                        src="../images/TreeImages/mobile_sms.gif" />短信息</td>
    </tr>
 	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		我的意见：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		  <asp:TextBox ID="txtPc_Jsyj" runat="server" Height="100px" TextMode="MultiLine" Width="400px"></asp:TextBox><BR /><BR />
          &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" onmouseover="this.className='bbk button small-longg-btn'" onmouseout="this.className='bbk button small-long-btn'"  class="bbk button small-long-btn" onclick="subPass" Text="同意审批" />
          &nbsp;&nbsp;
          <asp:Button ID="Button2" runat="server" onmouseover="this.className='bbk button small-yelloww-btn'" onmouseout="this.className='bbk button small-yellow-btn'"  class="bbk button small-yellow-btn" onclick="subRefuse" Text="拒绝审批" />
          
	</td></tr>
</table>
    
    </div>
    </form>
</body>
</html>
