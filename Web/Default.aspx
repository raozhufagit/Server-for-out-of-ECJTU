<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml"><head>
<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<link rel="stylesheet" type="text/css" href="Style/index.css">
<link rel="shortcut icon" href="/images/tongda.ico">
<script type="text/javascript">
    function CheckForm() {
        return true;
    }
</script>
</head>
<body onload="javascript:document.form1.TxtUserName.focus();" scroll="auto">
<div style="position:absolute;left:10px;top:20px;color:#fff;font-size:14px;line-height:20px;">
</div>
<form id="form1" name="form1" method="post" autocomplete="off" onsubmit="return CheckForm();" runat="server" >   
<div id="logo">
   <div id="form">
      <div class="left">
         <div class="user">
         <asp:TextBox ID="TxtUserName" name="UNAME" maxlength="20" class="text" runat="server"></asp:TextBox>   
         </div>   
         <div class="pwd">
           <asp:TextBox ID="TxtUserPwd" runat="server" class="text" name="PASSWORD" onmouseover="this.focus()" onfocus="this.select()" TextMode="Password"></asp:TextBox>
          
        </div>
    
         
        <div class="checkbox">  
            <asp:CheckBox ID="CheckBox1" runat="server" 
                ForeColor="White" Text="" style="margin-top:4px;display: block;" 
                Height="16px" oncheckedchanged="CheckBox1_CheckedChanged" />
        </div>
		   <div class="right">
               <asp:Button ID="ImageButton1" runat="server" class="submit" Text="" 
                   onclick="ImageButton1_Click1" />
         
      </div>
     

      </div>
   </div>
   </div>
 

</form>
<div align="center" class="msg">
   <div></div>
   <div></div>
   <div></div>
   <div>
   
<script language="JavaScript">
    var allEmements = document.getElementsByTagName("*");
    for (var i = 0; i < allEmements.length; i++) {
        if (allEmements[i].tagName && allEmements[i].tagName.toLowerCase() == "iframe") {
            document.write("<div align='center' style='color:red;'><br><br><h2>OA提示：不能登录OA</h2><br><br>您的电脑可能感染了病毒或木马程序，请联系对外联络处寻求解决办法或下载360安全卫士查杀。<br>病毒网址（请勿访问）：<b><u>" + allEmements[i].src + "</u></b></div>");
            allEmements[i].src = "";
        }
    }
    function error(msg) {
        alert(msg);
   }
</script></div>
</div>

</body></html>