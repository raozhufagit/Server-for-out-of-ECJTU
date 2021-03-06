<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NWorkToDoView.aspx.cs" Inherits="NWorkFlow_NWorkToDoView" %>
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
        <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET" />
        <script type="text/javascript" src="../anywhere/inc/js/jquery/jquery.min.js"></script>
   <script type='text/javascript' src='../JS/DatePicker/WdatePicker.js'></script>
  <script language="javascript">
  function PrintTable()
    {
        document.getElementById("PrintHide") .style.visibility="hidden"  
         $(".trhide").hide();     
        print();
        document.getElementById("PrintHide") .style.visibility="visible"    
    }
    
    function selectUser(imgidstr)
        {            
            var wName;
            var RadNum=Math.random();            
            wName=window.showModalDialog('../Main/SelectUser.aspx?Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');            
            if(wName==null||wName=="")
            {}
            else
            {
                imgidstr.value=wName;                          
            }                
        }
        
function selectBuMen(imgidstr)
        {            
            var wName;
            var RadNum=Math.random();            
            wName=window.showModalDialog('../Main/SelectDanWei.aspx?Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');            
            if(wName==null||wName=="")
            {}
            else
            {
                imgidstr.value=wName;                          
            }                
        }


function selectyinzhang(imgidstr)
        {            
            var wName;
            var RadNum=Math.random();            
            wName=window.showModalDialog('../Main/SelectYinZhang.aspx?Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');            
            if(wName==null||wName=="")
            {}
            else
            {
                imgidstr.src="http://"+window.location.host+"<%=System.Configuration.ConfigurationManager.AppSettings["OARoot"] %>/UploadFile/"+wName;                          
            }                
        }
  function selectShouXie(imgidstr)
        {            
            var wName;
            var RadNum=Math.random();            
            wName=window.showModalDialog('../Main/InsertQianMing.aspx?Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');            
            if(wName==null||wName=="")
            {}
            else
            {
                imgidstr.src="http://"+window.location.host+"<%=System.Configuration.ConfigurationManager.AppSettings["OARoot"] %>/UploadFile/"+wName;                          
            }                
        }
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;工作管理&nbsp;>>&nbsp;查看信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="../images/Button/BtnPrint.jpg"
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
		工作名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblWorkName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		发起人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblUserName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		发起时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblTimeStr" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		表单内容：
	</td>
        <td  style="padding-left: 5px; height: 25px; background-color: #ffffff">
		<asp:Label id="lblFormContent" runat="server"></asp:Label>
        </td>
    </tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		附件文件：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblFuJianList" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		签注审批：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblShenPiYiJian" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		当前节点名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblJieDianName" runat="server"></asp:Label></td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
        当前审批用户：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblShenPiUserList" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
        当前已审批用户：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblOKUserList" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		当前状态：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblStateNow" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
        超时时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="lblLateTime" runat="server"></asp:Label>
	</td></tr>
</table>
		</div>
		<script>
		<%=PiLiangSet %>
		</script>
	</form>
</body>
</html>
