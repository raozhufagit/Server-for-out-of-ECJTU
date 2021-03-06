﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SystemUserView.aspx.cs" Inherits="SystemManage_SystemUserView" %>
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
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;系统管理&nbsp;>>&nbsp;查看用户信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img id="IMG1" class="HerCss" onclick="PrintTable()" src="../images/Button/BtnPrint.jpg" />
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;</td>
            </tr>
            <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
        <tr>
            <td align="center" colspan="2" style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <strong>用户信息</strong></td>
        </tr>
        
        <tr>
            <td align="right" style="width: 170px; background-color: #D6E2F3; height: 25px;" >
                用户名：</td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;" >
                    <asp:Label ID="Label1" runat="server"></asp:Label>
                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; [<asp:HyperLink ID="HyperLink1" runat="server"
                        Font-Underline="True" ForeColor="Red" NavigateUrl="../LanEmail/LanEmailAdd.aspx">给其发送内部邮件</asp:HyperLink>]</td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                用户密码：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label2" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                真实姓名：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label3" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                用户编号：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label4" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                所属部门：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label5" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                所属角色：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label6" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                职位：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label7" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                在岗状态：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label8" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                Email地址：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label9" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                是否允许登陆：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label10" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                性别：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label11" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                备注信息：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label12" runat="server"></asp:Label></td>
        </tr>
        </table>
        <table id="TabHide" style="width: 100%; visibility:hidden;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">  
        <tr>
            <td align="center" colspan="2" style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <strong>人事信息</strong></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                出生日期：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label13" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                民族：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label14" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                身份证号：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label15" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                婚姻状况：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label16" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                政治面貌：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label17" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                籍贯：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label18" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                户口所在地：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label19" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                学历：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label20" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                职称：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label21" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                毕业院校：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label22" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                专业：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label23" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                参加工作时间：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label24" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                加入本单位时间：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label25" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                手机号码：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label26" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                家庭详细住址：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label27" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                岗位变动情况：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label28" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                教育背景：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label29" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                工作简历：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label30" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                社会关系：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label31" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                奖惩记录：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label32" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                职务情况：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label33" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                培训记录：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label34" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                担保记录：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label35" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                劳动合同签订情况：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label36" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                社保缴纳情况：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label37" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                体检记录：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label38" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                备 注：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label39" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                附件：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:Label ID="Label40" runat="server"></asp:Label></td>
        </tr>
        </table></div>
    </form>
</body>
</html>