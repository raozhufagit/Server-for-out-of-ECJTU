﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OfficeaccAdd.aspx.cs" Inherits="Office_OfficeaccAdd" %>

<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
  <script language="javascript">
      function PrintTable() {
          document.getElementById("PrintHide").style.visibility = "hidden"
          print();
          document.getElementById("PrintHide").style.visibility = "visible"
      }
  </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                桌面&nbsp;>>&nbsp;办公用品&nbsp;>>&nbsp;添加入库信息
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
<table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		办公用品名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtOfficeName" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXOffice&LieName=OfficeName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtOfficeName').value=wName;}"  src="../images/Button/search.gif" />
		<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOfficeName" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		备注描述：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtMiaoShu" runat="server" Width="350px" Height="60px" TextMode="MultiLine"></asp:TextBox></td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		附件上传：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
<asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                </asp:CheckBoxList>&nbsp;<asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False"
                    ImageAlign="AbsMiddle" ImageUrl="../images/Button/DelFile.jpg" OnClick="ImageButton3_Click" />
                &nbsp; &nbsp;
                <asp:ImageButton ID="ImageButton4" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                    ImageUrl="~/images/Button/ReadFile.gif" OnClick="ImageButton4_Click" />
                &nbsp; &nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton5" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                    ImageUrl="~/images/Button/EditFile.gif" OnClick="ImageButton5_Click" /></td>
        </tr>
        <tr>
            <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                上传附件：</td>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <asp:FileUpload ID="FileUpload1" runat="server" Width="350px" />
                <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                    ImageUrl="../images/Button/UpLoad.jpg" OnClick="ImageButton2_Click" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		办公用品类别：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtTypeStr" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXOffice&LieName=TypeStr&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtTypeStr').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		办公用品编码：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtSerils" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXOffice&LieName=Serils&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtSerils').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		计量单位：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtDanWei" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXOffice&LieName=DanWei&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtDanWei').value=wName;}"  src="../images/Button/search.gif" />
	</td></tr>	
    <tr>
        <td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		    领用部门：
	    </td>
	    <td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		    <asp:TextBox id="txtAcceptDepart" runat="server" Width="350px"></asp:TextBox>
		    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectDanWei.aspx?TableName=LCXDept&LieName=BuMenName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtAcceptDepart').value=wName;}" src="../images/Button/search.gif" />
	    </td>
    </tr>
    <tr>
        <td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		    领用人：
	    </td>
	    <td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		    <asp:TextBox id="txtAcceptPeople" runat="server" Width="350px"></asp:TextBox>
		    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectUser.aspx?TableName=LCXUser&LieName=UserName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtAcceptPeople').value=wName;}" src="../images/Button/search.gif" />
	    </td>
    </tr>

	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		领用数量：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="txtAcceptNum" runat="server" Width="350px"></asp:TextBox>
		<img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXOffice&LieName=MinNum&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtMinNum').value=wName;}"  src="../images/Button/search.gif" />
	</td>
    </tr>
</table>
		</div>
	</form>
</body>
</html>

