<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TryView.aspx.cs" Inherits="Try_TryView" %>

<!DOCTYPE html>

<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
  
        <style type="text/css">
            .auto-style2 {
                height: 25px;
            }
            .auto-style3 {
                width: 50%;
                height: 25px;
            }
            .auto-style7 {
                width: 1000px;
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
            <td style="background-color: #D6E2F3; width:1000px" align="center" class="auto-style7"  >
                   填写基本信息：
                </td>
                
              </tr> 
            </table>
    <table style="width: 1000px; margin:0px auto;"  bgcolor="#999999" border="0" cellpadding="2" cellspacing="1" >
		<tr>
	 <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    用户名：
                </td>
                <td style="padding-left: 5px; height: 25px; width:100px; background-color: #ffffff">
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                   
                </td>
                

        </tr>
        <tr>
            <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    用户名：
                </td>
               <td style="padding-left: 5px; height: 25px; width:100px; background-color: #ffffff">
                   <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                   
                </td>
                
            </tr>
       <tr>
	 <td style=" background-color: #D6E2F3" align="right" class="auto-style3">
                    用户名：
                </td>
               <td style="padding-left: 5px; height: 25px; width:100px; background-color: #ffffff">
                   <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                   
                </td>
                

        </tr>
        <tr>
            <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    用户名：
                </td>
                <td style="padding-left: 5px; height: 25px; width:100px; background-color: #ffffff">
                   <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                   
                </td>
               
            </tr>
        <tr>
	 <td style=" background-color: #D6E2F3" align="right" class="auto-style3">
                    用户名：
                </td>
                <td style="padding-left: 5px; background-color: #ffffff" class="auto-style2">
                    <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                   
                </td>
               


        </tr>
        <tr>
            <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    用户名：
                </td>
                <td style="padding-left: 5px; background-color: #ffffff" class="auto-style2">
                    <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
                   
                </td>
               
            </tr>
	
</table>
          <table style="width: 1000px; margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
             <tr>
            <td style="background-color: #D6E2F3; width:1000px" align="center" class="auto-style7"  >
                    审批信息：
                </td>
                
              </tr> 
            </table>
        <table style="width: 1000px; margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            
             <tr>
            <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    填写报告：
                </td>
                <td style="padding-left: 5px; background-color: #ffffff" class="auto-style2">
                    <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
                   
                </td>
               </tr>
              <tr>
           <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    评审信息：
                </td>
                <td style="padding-left: 5px; background-color: #ffffff" class="auto-style2">
                   <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
                   
                </td>
               
                    <tr>
            <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    评审信息：
                </td>
                <td style="padding-left: 5px; background-color: #ffffff" class="auto-style2">
                    <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
                   
                </td>
               
            </tr>
            </tr>
            </table>
         <table style="width: 1000px; margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
             <tr>
            <td style="background-color: #D6E2F3; width:1000px" align="center" class="auto-style7"  >
                   填写报告：
                </td>
                
              </tr> 
            </table>
         <table style="width: 1000px; margin:0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
             <tr>
            <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    填写报告：
                </td>
                <td style="padding-left: 5px; background-color: #ffffff" class="auto-style3">
                    <asp:TextBox ID="TextBox10" runat="server"></asp:TextBox>
                   
                </td>
               </tr>
                 <tr>
            <td style="background-color: #D6E2F3" align="right" class="auto-style3">
                    填写报告：
                </td>
                <td style="padding-left: 5px; background-color: #ffffff" class="auto-style3">
                    <asp:TextBox ID="TextBox11" runat="server"></asp:TextBox>
                   
                </td>
               
            </tr>
                 <tr>
            <td style="background-color: #D6E2F3"  align="right" class="auto-style3">
                    填写报告：
                </td>
                <td style="padding-left: 5px; background-color: #ffffff" class="auto-style3">
                   <asp:TextBox ID="TextBox12" runat="server"></asp:TextBox>
                   
                </td>

            </tr>
            </table>
</div>
    </form>
</body>
</html>


