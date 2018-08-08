<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NetEmailView.aspx.cs" Inherits="NetMail_NetEmailView" %>
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
   <script language="javascript">
          function SetCwinHeight(obj) {
              var cwin = obj;
              if (document.getElementById) {
                  if (cwin && !window.opera) {
                      if (cwin.contentDocument && cwin.contentDocument.body.offsetHeight)
                          cwin.height = cwin.contentDocument.body.offsetHeight + 20; //FF NS 
                      else if (cwin.Document && cwin.Document.body.scrollHeight)
                          cwin.height = cwin.Document.body.scrollHeight + 10; //IE 
                  }
                  else {
                      if (cwin.contentWindow.document && cwin.contentWindow.document.body.scrollHeight)
                          cwin.height = cwin.contentWindow.document.body.scrollHeight; //Opera 
                  }
              }
          } 
    </SCRIPT>  
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;Internet邮件&nbsp;>>&nbsp;查看邮件
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;"><img class="HerCss" onclick="PrintTable()" src="../images/Button/BtnPrint.jpg" />
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;</td>
            </tr>
            <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">            
        
        <tr>
            <td align="right" style="width: 170px; background-color: #D6E2F3; height: 25px;" >
                邮件主题：</td>
                <td style="background-color: #ffffff; height: 25px; padding-left:5px;" >
                    <asp:Label ID="Label1" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                发送人：</td>
            <td style="height: 25px; background-color: #ffffff; padding-left:5px;">
                <asp:Label ID="Label2" runat="server"></asp:Label>&nbsp; <a class="BlueCss" href='NetEmailAdd.aspx?Type=HuiFu&ID=<%=Request.QueryString["ID"].ToString()%>'>
                    回复</a> &nbsp; <a class="BlueCss"
                        href='NetEmailAdd.aspx?Type=ZhuanFa&ID=<%=Request.QueryString["ID"].ToString()%>'>
                       转发</a>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                接收人：</td>
            <td style="height: 25px; background-color: #ffffff; padding-left:5px;">
                <asp:Label ID="Label3" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                发送时间：</td>
            <td style="height: 25px; background-color: #ffffff; padding-left:5px;">
                <asp:Label ID="Label4" runat="server"></asp:Label></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                邮件附件：</td>
            <td style="height: 25px; background-color: #ffffff; padding-left:5px;">
                <asp:Label ID="Label5" runat="server"></asp:Label></td>
        </tr> 
        <tr>
         <td colspan="2" style="height: 100px; background-color: #ffffff; padding-left:5px;">
           <iframe src="EmlView.aspx?file=<%=file %>" frameborder="0"  scrolling="no" onload="SetCwinHeight(this);" width="100%">  
         </td>
        </tr>
        </table></div>
    </form>
</body>
</html>