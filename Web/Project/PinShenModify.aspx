<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PinShenModify.aspx.cs" Inherits="Project_PinShenModify" %>
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
  <script type='text/javascript' src='../JS/DatePicker/WdatePicker.js'></script>
  <script language="javascript">
      
      function selectBuMen(imgidstr) {
            var wName;
            var RadNum = Math.random();
            wName = window.showModalDialog('../Main/SelectDanWei.aspx?Radstr=' + RadNum, '', 'dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');
            if (wName == null || wName == "") { }
            else {
                imgidstr.value = wName;
            }
        }
  function PrintTable()
    {
        document.getElementById("PrintHide") .style.visibility="hidden"    
        print();
        document.getElementById("PrintHide") .style.visibility="visible"    
    }
  </script>
        <style type="text/css">
            .auto-style1 {
                width: 170px;
                height: 24px;
            }
            .auto-style2 {
                height: 24px;
            }
            .auto-style3 {
                width: 35px;
                height: 31px;
            }
            .auto-style5 {
                width: 170px;
                height: 26px;
            }
            .auto-style6 {
                height: 26px;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;项目管理&nbsp;>>&nbsp;修改评审信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                        OnClick="ImageButton1_Click" />
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;</td>
            </tr>
                        <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
      <!--******************************增加页面代码********************************-->

<table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style5">
		项目名称：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style6" >
		<asp:TextBox id="txtProjectName" runat="server" Width="350px" readony="ture"></asp:TextBox>
        <asp:Label ID="Label2" runat="server" Text="*项目名称不可修改"></asp:Label>
        &nbsp;</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		项目状态：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtProjectSerils" runat="server" Width="350px"></asp:TextBox>
		&nbsp;<asp:Label ID="Label3" runat="server" Text="Label" Visible ="false"></asp:Label>
        </td></tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style1">
		评审日期：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style2" >
		<asp:TextBox id="txtPingShenTime" runat="server" Width="350px" onClick="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true})" ></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        </td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		选择要推送的校内学院：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="Push" runat="server" Width="348px" Height="66px" ></asp:TextBox>
		
	    <img style="hight:30px;" id="searchimgVisitDepartment0"  onclick="selectBuMen(Push);"
                             src="../images/Button/search.gif" class="auto-style3" />&nbsp;&nbsp; 通知发送形式： 
        <asp:CheckBox ID="CHKSMS" runat="server" Checked="True" />
        <img src="../images/TreeImages/@sms.gif" />短消息<asp:CheckBox ID="CHKRTX" runat="server" />
        <img src="../images/TreeImages/notify2.gif" />微信<asp:CheckBox ID="CHKMOB" runat="server" />
        <img src="../images/TreeImages/mobile_sms.gif" />短信息</td>
        </tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		评审结果：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtPingShenJieGuo" runat="server" Width="345px" Height="49px" ></asp:TextBox>
		
	</td>
	</tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		备注说明：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtBachInfo" runat="server" Width="350px" Height="100px" TextMode="MultiLine"></asp:TextBox>&nbsp;
	</td></tr>
</table>



</div>
    </form>
</body>
</html>