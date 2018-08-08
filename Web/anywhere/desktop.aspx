<%@ Page Language="C#" AutoEventWireup="true" CodeFile="desktop.aspx.cs" Inherits="anywhere_desktop" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<meta http-equiv="X-UA-Compatible" content="IE=EmulateIE7" /> 
<title>个人桌面</title>
<link rel="stylesheet" type="text/css" href="theme/13/style.css" />
<link rel="stylesheet" type="text/css" href="theme/13/portal_index.css" />
<script type="text/javascript" src="inc/jslang.js"></script>
<script type="text/javascript" src="inc/js/jquery/jquery.min.js"></script>
<script type="text/javascript" src="inc/js/jquery/jquery.plugins.js"></script>
<script type="text/javascript" src="inc/js/jquery/jquery-ui.custom.min.js"></script>
<script type="text/javascript" src="inc/js/jquery/jquery.ui.draggable.min.js"></script>
<script type="text/javascript" src="inc/js/jquery/jquery.ui.sortable.min.js"></script>
<script type="text/javascript" src="inc/js/jquery/jquery.ux.borderlayout.js"></script>
<script type="text/javascript" src="inc/js/jquery/jquery.ui.droppable.min.js"></script>
<script type="text/javascript" src="inc/js/jquery/jquery.ux.slidebox.js"></script>
<script type="text/javascript" src="inc/js/jquery/jquery.ux.simulatemouse.js"></script>
<script type="text/javascript" src="inc/js/portal_index.js"></script>
<script type="text/javascript">    
   
    var moduleIdStr = '';
    //屏幕显示的菜单项下面的参数为
    var funcIdStr = '<%=LCX.Common.PublicMethod.desktop() %>';
    var ostheme = top.ostheme;
    //-- 可用菜单 --
    var fmenu = typeof (first_array) == 'object' ? first_array : top.first_array;
    var smenu = typeof (second_array) == 'object' ? second_array : top.second_array;
    var tmenu = typeof (third_array) == 'object' ? third_array : top.third_array;
    var funcarray = typeof (func_array) == 'object' ? func_array : top.func_array;
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>

   <div id="control"> 
      <table align="center">
         <tr>
            <td class="control-l"></td>
            <td class="control-c"></td>
            <td class="control-r"><a id="openAppBox" title="打开应用盒子" href="javascript: void(0)" class="cfg"></a> </td>
         </tr>
      </table>
   </div>
      
	<div class="slidebox">
	 	<div id="trash"></div>
	 	
	  	<div id="container"></div>
 
	</div>
	<div id="overlay"></div>
	<div class="background"></div>        
    </div>
 </form>
</body>
</html>