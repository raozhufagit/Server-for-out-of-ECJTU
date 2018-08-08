<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LCXEquipmentAdd.aspx.cs" Inherits="DuiWaiFuwu_LCXEquipmentAdd" %>

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
            table{margin:0 auto;}
            .auto-style1 {
                height: 45px;
                width: 11%;
            }
            .auto-style2 {
                height: 45px;
                width: 22%;
            }
            .auto-style3 {
                height: 45px;
                width: 24%;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                 <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;仪器设备&nbsp;>>&nbsp;添加信息
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
<table style="width: 80%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
	<tr>
	<td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
		设备名称：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff;" class="auto-style3" >
		<asp:TextBox id="txtEquipmentName" runat="server" Width="200px"></asp:TextBox>
        	<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXSheBei&LieName=SheBeiName&Radstr='+RadNum,'','dialogWidth:400px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtEquipmentName').value=wName;}"  src="../images/Button/search.gif" />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEquipmentName" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
        
		</td>
<td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
		设备编号：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff;" class="auto-style2" >
		<asp:TextBox id="txtEquipmentNo" runat="server" Width="200px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXSheBei&LieName=YuanBianHao&Radstr='+RadNum,'','dialogWidth:400px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtEquipmentNo').value=wName;}"  src="../images/Button/search.gif" />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEquipmentNo" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
        
	</td>
         <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		出厂编号：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style2" >
		<asp:TextBox id="txtFactoryNo" runat="server" Width="200px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXSheBei&LieName=ChuChangBianHao&Radstr='+RadNum,'','dialogWidth:400px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtFactoryNo').value=wName;}"  src="../images/Button/search.gif" />
	</td>
        
	</tr>
	
	
	<tr>
	
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		设备类别：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style2" >
		<asp:TextBox id="txtEquipmentType" runat="server" Width="200px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXSheBei&LieName=SheBeiLeiBie&Radstr='+RadNum,'','dialogWidth:400px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtEquipmentType').value=wName;}"  src="../images/Button/search.gif" />
	</td>
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		型号：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style1" >
		<asp:TextBox id="txtEquipmentModel" runat="server" Width="200px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXSheBei&LieName=XingHao&Radstr='+RadNum,'','dialogWidth:400px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtEquipmentModel').value=wName;}"  src="../images/Button/search.gif" />
	</td>
        <td style="width: 10%; height: 25px; background-color: #D6E2F3; text-align: right">
                    设备状态 ：
                </td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    
                    <asp:DropDownList ID="txtEquipStates" class="BigSelect" runat="server">
                 <asp:ListItem Value="1">闲置</asp:ListItem>
                  <asp:ListItem Value="2">正在使用</asp:ListItem>
                   <asp:ListItem Value="2">已租赁</asp:ListItem>
                 </asp:DropDownList>   
                </td> 
	</tr>
	
	<tr>
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		所在部门：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style1" >
		<asp:TextBox id="txtBelongDept" runat="server" Width="200px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectDanWei.aspx?TableName=LCXDept&LieName=BuMenName&Radstr='+RadNum,'','dialogWidth:400px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtBelongDept').value=wName;}"  src="../images/Button/search.gif" />
	</td>
	
      <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		购买价格：
	</td>
	<td style="padding-left: 5px; height: 45px; background-color: #ffffff" >
		<asp:TextBox id="txtBuyPrice" runat="server" Width="200px"></asp:TextBox>
	</td> 
      <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		购买时间：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:TextBox id="txtBuyTime" runat="server" Width="200px" onClick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
	</td> 
	</tr>
	
	<tr>
	<td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		生产厂家：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:TextBox id="txtFactoryName" runat="server" Width="200px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXEquipment&LieName=FactoryName&Radstr='+RadNum,'','dialogWidth:400px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtFactoryName').value=wName;}"  src="../images/Button/search.gif" />
	</td>
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		管理人：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:TextBox id="txtManager" runat="server" Width="200px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXEquipment&LieName=Manager&Radstr='+RadNum,'','dialogWidth:400px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtManager').value=wName;}"  src="../images/Button/search.gif" />
	</td>
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		审核人：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:TextBox id="txtChecker" runat="server" Width="200px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXEquipment&LieName=Checker&Radstr='+RadNum,'','dialogWidth:400px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtChecker').value=wName;}"  src="../images/Button/search.gif" />
	</td>
	</tr>
	
	
	
	
	
	
	
	
	<tr>
	<td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		审核日期：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:TextBox id="txtCheckTime" runat="server" Width="200px" onClick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
	</td>
        <td style="width: 10%px; height: 45px; background-color: #D6E2F3" align="right">
		存放位置：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" colspan="3" >
		<asp:TextBox id="txtStoragePosition" runat="server" Width="500px"></asp:TextBox>
	</td>
	 <tr><td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
		注意事项：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" colspan="5">
		<asp:TextBox id="txtMattersAttention" runat="server" Width="100%" TextMode="MultiLine" Rows="10" ></asp:TextBox>
		</td></tr>
     
    <tr><td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
		备注：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" colspan="5">
		<asp:TextBox id="txtRemarks" runat="server" Width="100%" TextMode="MultiLine" Rows="10" ></asp:TextBox>
		</td></tr>
</table>
		</div>
	</form>
</body>
</html>

