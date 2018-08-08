<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BookJieHuanAdd.aspx.cs" Inherits="Office_BookJieHuanAdd" %>
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
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;图书管理&nbsp;>>&nbsp;添加借书登记
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                        OnClick="ImageButton1_Click" />
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;</td>
            </tr>
            <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
<table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		图书名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtBookName" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXBook&LieName=BookName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtBookName').value=wName;}"  src="../images/Button/search.gif" />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtBookName" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
	</td></tr>
    <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            借书日期：
        </td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:TextBox ID="txtJieShuDate" runat="server" Width="350px"></asp:TextBox>
            <img class="HerCss" onclick="var dataString = showModalDialog('../JS/calendar.htm', 'yyyy-mm-dd' ,'dialogWidth:286px;dialogHeight:221px;status:no;help:no;');if(dataString==null){}else{document.getElementById('txtJieShuDate').value=dataString;}"
                src="../images/Button/search.gif" /></td>
    </tr>
    <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            归还日期：
        </td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:TextBox ID="txtGuiHuanDate" runat="server" Width="350px"></asp:TextBox>
            <img class="HerCss" onclick="var dataString = showModalDialog('../JS/calendar.htm', 'yyyy-mm-dd' ,'dialogWidth:286px;dialogHeight:221px;status:no;help:no;');if(dataString==null){}else{document.getElementById('txtGuiHuanDate').value=dataString;}"
                src="../images/Button/search.gif" /></td>
    </tr>
    <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            借还状态：
        </td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:TextBox ID="txtJieHuanState" runat="server" Width="350px"></asp:TextBox>
            <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXBookBorrow&LieName=JieHuanState&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJieHuanState').value=wName;}"
                src="../images/Button/search.gif" /></td>
    </tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		备注说明：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtBackInfo" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox>
	</td></tr>
    <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            借书人：
        </td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:TextBox ID="txtUserName" runat="server" Width="350px"></asp:TextBox>
            <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=LCXUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtUserName').value=wName;}"
                src="../images/Button/search.gif" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtUserName"
                ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator></td>
    </tr>
</table>
		</div>
	</form>
</body>
</html>
