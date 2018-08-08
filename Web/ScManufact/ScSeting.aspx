<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScSeting.aspx.cs" Inherits="ScManufact_ScSeting" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                 桌面 &nbsp;>>&nbsp;生产系统设置 
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/Submit.jpg" OnClick="ImageButton1_Click" />
                    <img alt ="提交参数" src="../images/Button/JianGe.jpg" />&nbsp;
                      </td>
            </tr>
            <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">  
     <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            订单审核人员选择：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:TextBox ID="txtdd_User" runat="server" onkeydown="javascript:return false;" 
                Width="349px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtdd_User"
                Display="Dynamic" ErrorMessage="*订单审核人"></asp:RequiredFieldValidator><img class="HerCss"  onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=LCXUser&LieName=UserName&Condition='+document.getElementById('txtdd_User').value+'&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtdd_User').value=wName;}"
                src="../images/Button/search.gif" /></td>
    </tr>
     <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            生产单制单人选择：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:TextBox ID="txtsc_User" runat="server" onkeydown="javascript:return false;" 
                Width="349px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtsc_User"
                Display="Dynamic" ErrorMessage="*生产单制单人"></asp:RequiredFieldValidator><img class="HerCss"  onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=LCXUser&LieName=UserName&Condition='+document.getElementById('txtsc_User').value+'&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtsc_User').value=wName;}"
                src="../images/Button/search.gif" /></td>
    </tr> 
         <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            生产单技术审核选择：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:TextBox ID="txtsc_JUser" runat="server" onkeydown="javascript:return false;" 
                Width="349px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtsc_JUser"
                Display="Dynamic" ErrorMessage="*生产单技术审核人"></asp:RequiredFieldValidator><img class="HerCss" id="Img2" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=LCXUser&LieName=UserName&Condition='+document.getElementById('txtsc_JUser').value+'&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtsc_JUser').value=wName;}"
                src="../images/Button/search.gif" /></td>
    </tr>
         <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            生产单审核人选择：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:TextBox ID="txtsc_SUser" runat="server" onkeydown="javascript:return false;" 
                Width="349px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtsc_SUser"
                Display="Dynamic" ErrorMessage="*必须生产单审核人"></asp:RequiredFieldValidator><img class="HerCss" id="Img3" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=LCXUser&LieName=UserName&Condition='+document.getElementById('txtsc_SUser').value+'&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtsc_SUser').value=wName;}"
                src="../images/Button/search.gif" /></td>
    </tr>
         <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            生产进度制定人员：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:TextBox ID="txtjd_User" runat="server" onkeydown="javascript:return false;" 
                Width="349px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtjd_User"
                Display="Dynamic" ErrorMessage="*必须指定生产进度制定人员"></asp:RequiredFieldValidator><img class="HerCss" id="Img4" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=LCXUser&LieName=UserName&Condition='+document.getElementById('txtjd_User').value+'&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtjd_User').value=wName;}"
                src="../images/Button/search.gif" /></td>
    </tr>
         <tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
            进度审核人员选择：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:TextBox ID="txtjd_SUser" runat="server" onkeydown="javascript:return false;" 
                Width="349px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtjd_SUser"
                Display="Dynamic" ErrorMessage="*进度审核人员选择"></asp:RequiredFieldValidator><img class="HerCss" id="Img5" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=LCXUser&LieName=UserName&Condition='+document.getElementById('txtjd_SUser').value+'&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtjd_SUser').value=wName;}"
                src="../images/Button/search.gif" /></td>
    </tr> 
        </table></div>
    </form>
</body>
</html>