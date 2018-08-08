<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TechnologyPurchaseView.aspx.cs" Inherits="TechnologyPurchase_TechnologyPurchaseView" %>
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
            </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;技术求购管理&nbsp;>>&nbsp;添加技术求购信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
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
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		技术名称：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label id="TechnologyName" runat="server" Width="241px"></asp:label>
        </td></tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		技术类型：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label ID="TechnologyType" runat="server" CssClass="auto-style1" Height="35px" Width="241px">           
        </asp:label>
		
	</td>
       
        </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		发布技术求购单位：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label id="PubCompany" runat="server" ReadOnly="false" Width="241px"></asp:label>
		&nbsp;</td>
        </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		技术要求：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label ID="RequiredProfession" runat="server" CssClass="auto-style1" Height="35px" Width="241px">
        </asp:label></td>
        
          </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		单位联系人姓名：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label id="ContactPerson" runat="server" ReadOnly="false" Width="241px"></asp:label>
		&nbsp;</td>
          </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		单位负责人电话：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label id="ContactTel" runat="server" ReadOnly="false" Width="241px"></asp:label>
		&nbsp;</td>
          </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		单位联系人电子邮箱：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label id="ContactEmail" runat="server" ReadOnly="false" Width="241px"></asp:label>
		&nbsp;</td>
       </tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		求购技术的具体说明：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		
        <asp:label id="TechnologyDetail" runat="server" ReadOnly="false" Width="241px" ></asp:label>
	</td>
         </tr>
	<tr>
	<td style="background-color: #D6E2F3" align="right" class="auto-style2">
		选择校内学院推送：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style3" >
		<asp:label id="Push" runat="server" Width="241px"></asp:label>
		&nbsp;</td> 
	</tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		技术求购开始时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:label id="BeginTime" runat="server" Width="241px" ></asp:label>
        </td></tr>
	<tr>
	<td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
		技术求购结束信息：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:label id="EndTime" runat="server" Width="241px" ></asp:label>
        &nbsp;</td>
	
	
	<tr>
        <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
		合同以及附件：</td>
        <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
            <asp:Label ID="Attachment" runat="server" ></asp:Label>
            </td>
    
</table>

        <hr style="height:1px; color: #003333;">
    &nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="../Project/PingShen.aspx?ProjectName=<%=CustomNameStr %>">评审信息</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="../Project/ProjectJinDu.aspx?ProjectName=<%=CustomNameStr %>">项目进度</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="../Project/ShouKuan.aspx?ProjectName=<%=CustomNameStr %>">收款信息</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="../Project/ShiShiRiZhi.aspx?ProjectName=<%=CustomNameStr %>">实施日志</a>&nbsp;&nbsp;
    <img src="../images/TreeImages/hrms.gif" /><a target="RMid" href="../Project/LiRuiGuanLi.aspx?ProjectName=<%=CustomNameStr %>">项目利润</a>&nbsp;&nbsp;
    
    <hr style="height:1px; color: #003333;">
    <IFRAME name="RMid" frameBorder="0" marginHeight="0" marginWidth="0" width="100%" height="500"
													BORDERCOLOR="#ffffFF"  src="../Project/PingShen.aspx?ProjectName=<%=CustomNameStr %>" border="0"></IFRAME>

</div>
    </form>
</body>
</html>