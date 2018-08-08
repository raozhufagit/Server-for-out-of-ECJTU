<%@ Page Language="C#" AutoEventWireup="true" CodeFile="meet.aspx.cs" Inherits="Meeting_meet" %>



<html xmlns="http://www.w3.org/1999/xhtml" >
<head><title>
	视频会议
</title>
 
    <script src="Scripts/AC_RunActiveContent.js" type="text/javascript"></script>
    
</head>
<body style="margin-left:0;margin-top:0;margin-right:0;margin-bottom:0">
    <form id="form1" runat="server">
    <% if (Session["connStr"] != null)
       {
          %>
    <table   style= "width:100%;   height:100%;   "> <tr> <td> 
 
 
    <script type="text/javascript">
        AC_FL_RunContent('codebase', 'http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=9,0,9,0', 'width', '100%', 'height', '100%', 'src', '<%=Session["connStr"]%>', 'quality', 'high', 'pluginspage', 'http://www.macromedia.com/go/getflashplayer', 'movie', '<%=Session["connStr"]%>', 'allowfullscreen', 'true'); //end AC code
    </script>
    
    <noscript>
	    <object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=10,0,0,0" width="100%" height="100%" id="preloader" align="middle">
	    <param name="allowScriptAccess" value="sameDomain" />
	    <param name="allowFullScreen" value="true" />
	    <param name="movie" value="preloader.swf?userName=张三&password=&mediaServer=rtmp://localhost&role=2&roomID=9&scriptType=aspx" />
	    <param name="quality" value="high" />
	    <param name="bgcolor" value="#ffffff" />	
	    <embed src="preloader.swf?userName=张三&password=&mediaServer=rtmp://localhost&role=2&roomID=9&scriptType=aspx" quality="high" bgcolor="#ffffff" width="100%" height="100%" name="preloader" align="middle" allowScriptAccess="sameDomain" allowFullScreen="true" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />
	    </object>
    </noscript>
    
    </td> </tr> </table> 
    <%}
       else
       { %>
       <script type="text/javascript">
           alert("登录失败,可能原因是登录超时,请您重新登录试试!");
           window.close();
</script>
       <%} %>
    </form>
</body>
</html>