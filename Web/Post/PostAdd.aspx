<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PostAdd.aspx.cs" Inherits="Post_PostAdd" %>
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
                margin-bottom: 0px;
            }
            .auto-style2 {
                width: 170px;
                height: 25px;
            }
            .auto-style3 {
                height: 25px;
            }
            .auto-style4 {
                width: 24px;
                margin-top: 1px;
            }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;挂职管理&nbsp;>>&nbsp;添加挂职信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                        OnClick="ImageButton1_Click" />
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="Back_Click" src="../images/Button/BtnExit.jpg" />&nbsp;</td>
            </tr>
                        <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
     <!--******************************增加页面代码********************************-->

<table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		挂职岗位名称：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="PostJobName" runat="server" Width="241px"></asp:TextBox>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="PostJobName"
            ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator></td></tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		挂职岗位类型：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:DropDownList ID="PostJobType" runat="server" CssClass="auto-style1" Height="35px" Width="241px">
            <asp:ListItem>行政岗位挂职</asp:ListItem>
            <asp:ListItem>专技岗位挂职</asp:ListItem>
            <asp:ListItem>其他</asp:ListItem>
        </asp:DropDownList>
		
	</td>
       
        </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		挂职单位：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:TextBox id="PubCompany" runat="server" ReadOnly="false" Width="241px"></asp:TextBox>
		&nbsp;</td>
        </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		挂职岗位专业要求：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:DropDownList ID="RequiredProfession" runat="server" CssClass="auto-style1" Height="35px" Width="241px">
            <asp:ListItem>不限</asp:ListItem>
            <asp:ListItem>工科</asp:ListItem>
            <asp:ListItem>理科</asp:ListItem>
        </asp:DropDownList></td>
        </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		挂职岗位所需人数：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:TextBox id="RequiredAmount" runat="server" ReadOnly="false" Width="241px"></asp:TextBox>
		&nbsp;</td>

          </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		单位联系人姓名：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:TextBox id="ContactPerson" runat="server" ReadOnly="false" Width="241px"></asp:TextBox>
		&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ContactPerson"
            ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator></td>
          </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		单位负责人电话：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:TextBox id="ContactTel" runat="server" ReadOnly="false" Width="241px"></asp:TextBox>
		&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ContactTel"
            ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator></td>
          </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		单位联系人电子邮箱：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:TextBox id="ContactEmail" runat="server" ReadOnly="false" Width="241px"></asp:TextBox>
		&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ContactEmail"
            ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator></td>
       </tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		挂职岗位的要求及其他信息：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="PostDetail" runat="server" Width="245px" Height="90px" TextMode="MultiLine"></asp:TextBox>&nbsp;
	    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="PostDetail"
            ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
	</td>
         </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		选择校内学院推送：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:TextBox id="Push" runat="server" Width="241px"></asp:TextBox>
		&nbsp;<img style="hight:30px;" id="searchimgVisitDepartment0"  onclick="selectBuMen(Push);"
                             src="../images/Button/search.gif" class="auto-style4" /></td> 
	</tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		开始挂职时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="BeginTime" runat="server" Width="241px" onClick="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true})" >点击选择时间</asp:TextBox>
        </td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		结束挂职信息：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:TextBox id="EndTime" runat="server" Width="241px"  onClick="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true})" >点击选择时间</asp:TextBox>
        &nbsp;</td>
	
	
	<tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
		合同以及附件：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
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
        <td align="right" style="background-color: #D6E2F3" class="auto-style2">
            上传附件：</td>
        <td style="padding-left: 5px; background-color: #ffffff" class="auto-style3">
            <asp:FileUpload ID="FileUpload1" runat="server" Width="246px" CssClass="auto-style1" />
            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                ImageUrl="../images/Button/UpLoad.jpg" OnClick="ImageButton2_Click" Height="16px" Width="44px" /></td>
    </tr>
</table>

</div>
    </form>
</body>
</html>