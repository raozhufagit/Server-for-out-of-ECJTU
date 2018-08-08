<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScModify.aspx.cs" Inherits="ScManufact_ScModify" %>

<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
         <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
         <script type='text/javascript' src='../JS/DatePicker/WdatePicker.js'></script>
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
                 桌面&nbsp;>>&nbsp;生产管理&nbsp;>>&nbsp;修改订单信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                        OnClick="ImageButton1_Click" style="height: 17px" />
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;</td>
            </tr>
                        <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
     <!--******************************增加页面代码********************************-->

<table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		订单名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtSc_Name" runat="server" Width="350px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtSc_Name"
            ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator></td></tr> 
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		所属客户：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtSc_Custmoer" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXCustomInfo&LieName=CustomName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtSuoShuKeHu').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		交货日期：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtSc_Jtime" runat="server" Width="350px" onClick="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd HH:mm:ss',alwaysUseStartDate:true})"></asp:TextBox>
        <img class="HerCss" onclick="var dataString = showModalDialog('../JS/calendar.htm', 'yyyy-mm-dd' ,'dialogWidth:286px;dialogHeight:221px;status:no;help:no;');if(dataString==null){}else{document.getElementById('txtSc_Jtime').value=dataString;}" src="../images/Button/search.gif" /></td>
     </tr>
	
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
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
		合同以及附件：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
            </asp:CheckBoxList>&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False"
                ImageAlign="AbsMiddle" ImageUrl="../images/Button/DelFile.jpg" OnClick="ImageButton3_Click" />
            &nbsp; &nbsp;
            <asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                ImageUrl="~/images/Button/ReadFile.gif" OnClick="ImageButton4_Click" />
            &nbsp; &nbsp;&nbsp;
            <asp:ImageButton ID="ImageButton5" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                ImageUrl="~/images/Button/EditFile.gif" OnClick="ImageButton5_Click" /></td>
    </tr>
    <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            上传附件：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:FileUpload ID="FileUpload1" runat="server" Width="350px" />
            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                ImageUrl="../images/Button/UpLoad.jpg" OnClick="ImageButton2_Click" /></td>
    </tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		备注说明：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtMark" runat="server" Width="350px" Height="90px" 
            TextMode="MultiLine"></asp:TextBox>&nbsp;
	</td></tr>
</table>

</div>
    </form>
</body>
</html>