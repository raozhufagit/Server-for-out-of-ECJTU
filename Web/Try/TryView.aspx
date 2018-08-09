<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TryView.aspx.cs" Inherits="Try_TryView" %>

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
            .auto-style2 {
                height: 25px;
            }
            .auto-style3 {
                width: 100px;
                height: 25px;
            }
            .auto-style4 {
                width: 409px;
                height: 25px;
            }
        </style>
</head>
<body>
    <form id="form2" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;项目管理 &gt;&gt; 查看项目信息
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
    <table style="width: 1000px; margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
		<tr>
	 <td style="width: 100px !important; height: 25px; background-color: #D6E2F3" align="right">
                    用户名：
                </td>
                <td style="padding-left: 5px; height: 25px; width:100px; background-color: #ffffff">
                    <asp:Label ID="lblUserName" runat="server" Width="140px"></asp:Label>
                   
                </td>
                

        </tr>
        <tr>
            <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    用户名：
                </td>
               <td style="padding-left: 5px; height: 25px; width:100px; background-color: #ffffff">
                    <asp:Label ID="Label1" runat="server" Width="140px"></asp:Label>
                   
                </td>
                
            </tr>
       <tr>
	 <td style="width: 100px !important; height: 25px; background-color: #D6E2F3" align="right">
                    用户名：
                </td>
               <td style="padding-left: 5px; height: 25px; width:100px; background-color: #ffffff">
                    <asp:Label ID="Label3" runat="server" Width="140px"></asp:Label>
                   
                </td>
                

        </tr>
        <tr>
            <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    用户名：
                </td>
                <td style="padding-left: 5px; height: 25px; width:100px; background-color: #ffffff">
                    <asp:Label ID="Label5" runat="server" Width="140px"></asp:Label>
                   
                </td>
               
            </tr>
        <tr>
	 <td style="width: 100px !important;  height: 25px; background-color: #D6E2F3" align="right">
                    用户名：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="Label7" runat="server" Width="140px"></asp:Label>
                   
                </td>
               


        </tr>
        <tr>
            <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    用户名：
                </td>
                <td style="padding-left: 5px; background-color: #ffffff" class="auto-style2">
                    <asp:Label ID="Label9" runat="server" Width="140px"></asp:Label>
                   
                </td>
               
            </tr>
	
</table>
        <table style="width: 1000px; margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
             <tr>
            <td style="background-color: #D6E2F3" align="right" class="auto-style4">
                    评审信息：
                </td>
                <td style="padding-left: 5px; background-color: #ffffff" class="auto-style2">
                    <asp:Label ID="Label2" runat="server" Width="140px"></asp:Label>
                   
                </td>
               
            </tr>
            </table>
</div>
    </form>
</body>
</html>


