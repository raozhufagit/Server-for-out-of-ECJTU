<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NFormAdd.aspx.cs" Inherits="NWorkFlow_NFormAdd" %>
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
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;流程表单&nbsp;>>&nbsp;添加信息
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
		表单名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtFormName" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCX_Form&LieName=FormName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtFormName').value=wName;}"  src="../images/Button/search.gif" />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFormName" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		允许使用人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtUserListOK" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=LCXUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtUserListOK').value=wName;}" src="../images/Button/search.gif" />
        &nbsp; &nbsp; 设置为：【 <a href="javascript:void(0);" onclick="document.getElementById('txtUserListOK').value='全部'">
            <span style="color: #0000ff">全部用户</span></a> 】</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		允许使用部门：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtDepListOK" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectDanWei.aspx?TableName=LCXDept&LieName=BuMenName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtDepListOK').value=wName;}"  src="../images/Button/search.gif" />
        &nbsp; &nbsp; 设置为：【 <a href="javascript:void(0);" onclick="document.getElementById('txtDepListOK').value='全部'">
            <span style="color: #0000ff">全部部门</span></a> 】</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		允许使用角色：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtJiaoSeListOK" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXRole_Info&LieName=JiaoSeName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtJiaoSeListOK').value=wName;}"  src="../images/Button/search.gif" />
        &nbsp; &nbsp; 设置为：【 <a href="javascript:void(0);" onclick="document.getElementById('txtJiaoSeListOK').value='全部'">
            <span style="color: #0000ff">全部角色</span></a> 】</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		排序字符：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtPaiXuStr" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCX_Form&LieName=PaiXuStr&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtPaiXuStr').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		是否启用：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
        <asp:DropDownList ID="DropDownList1" runat="server" Width="350px">
            <asp:ListItem Value="是">正常启用</asp:ListItem>
            <asp:ListItem Value="否">停止使用</asp:ListItem>
        </asp:DropDownList></td></tr>
</table>
		</div>
	</form>
</body>
</html>
