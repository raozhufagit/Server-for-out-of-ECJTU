<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PrintWork.aspx.cs" Inherits="NWorkFlow_PrintWork" %>

<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
         <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
         <script type="text/javascript" src="../anywhere/inc/js/jquery/jquery.min.js"></script>
<style>
    .DivSelect
    {
         position: relative;
         background-color: transparent;
         width:   140px;
         height: 17px;
         overflow: hidden; /*隐藏了小三角，因为宽度为110px,而select宽度为130px*/
         border-width:0px;
         border-top-style: none; 
         border-right-style: none; 
         border-left-style: none; 
         border-bottom-style: none;
    }
    /*设置Select样式*/
    .SelectList
    {
         position: relative;
         background-color: transparent;
         TOP:    -2px;
         left:-2px;
         border-width: 0px;
         border-top-style: none; 
         border-right-style: none; 
         border-left-style: none; 
         border-bottom-style: none;
         width:160px;
         display:block;
         height: 18px;
         overflow:hidden;
    }
</style>

  <script language="javascript">
  function Load_Do()
  {
     for(var i=1;i<document.getElementById("form1").elements.length;i++) { 
        var e = form1.elements[i];
    //      //获取当前元素的Name值(name)
    //      var namestr=e.name;
    //      //alert(namestr);
     //   e.readOnly = "true"; //设置所有文本框不可输入
    //      //e.className="PrintCSS";
      }
  }
  
  function selectUser(imgidstr) {
  }
  function selectBuMen(imgidstr) {
  }
  function selectyinzhang(imgidstr) {
  }
  function selectShouXie(imgidstr) {
  }
  function PrintTable() {




      document.getElementById("PrintHide").style.visibility = "hidden";
      
      //$("select").css("border:0px solid #ccc;-webkit-appearance: none;");
      $(".trhide").hide();             
        print();
        document.getElementById("PrintHide") .style.visibility="visible";
    }
 
  </script>
</head>
<body >
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                桌面&nbsp;>>&nbsp;审批流程&nbsp;>>&nbsp;打印工作表单
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <img id="IMG1" class="HerCss" onclick="PrintTable()" src="../images/Button/BtnPrint.jpg"></img>&nbsp;
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg"></img>&nbsp;</td>
            </tr>
        </table>
        
        <table style="width: 100%" border="0" cellpadding="2" cellspacing="1">        
        <tr>
            <td colspan="2" style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <div style="clear:both"></div>
            <div style="display:block">
                <asp:Label ID="Label3" runat="server"></asp:Label></td>
            </div>
             <div style="clear:both"></div>
        </tr>
         <tr>
                <td colspan="2" style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="Label1" runat="server" ></asp:Label></td>
            </tr>
        </table> 
        
        </div>
    </form>
</body>
</html>