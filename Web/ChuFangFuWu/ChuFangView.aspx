<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChuFangView.aspx.cs" Inherits="ChuFangFuWu_ChuFang_View" %>

<ht<html>
<head>
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
    <link href="../Style/Style.css" type="text/css" rel="STYLESHEET">
    <script type='text/javascript' src='../JS/DatePicker/WdatePicker.js'></script>
    <script language="javascript">
        function PrintTable() {
            document.getElementById("PrintHide").style.visibility = "hidden"
            print();
            document.getElementById("PrintHide").style.visibility = "visible"
        }
        function selectUser(imgidstr) {
            var wName;
            var RadNum = Math.random();
            wName = window.showModalDialog('../Main/SelectUser.aspx?Radstr=' + RadNum, '', 'dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');
            if (wName == null || wName == "") { }
            else {
                imgidstr.value = wName;
            }
        }

        function selectBuMen(imgidstr) {
            var wName;
            var RadNum = Math.random();
            wName = window.showModalDialog('../Main/SelectDanWei.aspx?Radstr=' + RadNum, '', 'dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');
            if (wName == null || wName == "") { }
            else {
                imgidstr.value = wName;
            }
        }


        function selectyinzhang(imgidstr) {
            var wName;
            var RadNum = Math.random();
            wName = window.showModalDialog('../Main/SelectYinZhang.aspx?Radstr=' + RadNum, '', 'dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');
            if (wName == null || wName == "") { }
            else {
                imgidstr.src = "http://" + window.location.host +"<%=System.Configuration.ConfigurationManager.AppSettings["OARoot"] %>/UploadFile/" + wName;
            }
        }
        function selectShouXie(imgidstr) {
            var wName;
            var RadNum = Math.random();
            wName = window.showModalDialog('../Main/InsertQianMing.aspx?Radstr=' + RadNum, '', 'dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');
            if (wName == null || wName == "") { }
            else {
                imgidstr.src = "http://" + window.location.host +"<%=System.Configuration.ConfigurationManager.AppSettings["OARoot"] %>/UploadFile/" + wName;
            }
        }
        function _change() {
            var text = form1.DropDownList1.value;
            if (text != "请选择") {
                document.getElementById('TextBox1').value += text + "\r\n";
            }
        }
    </script>
    <style type="text/css">
        .auto-style3 {
            height: 65px;
            width: 100px;
        }

        .select {
            position: absolute;
            width: 50px;
            height: 65px;
            padding: 0 24px 0 8px;
            color: #fff;
            font: 12px/21px arial,sans-serif;
            overflow: hidden;
            top: 97px;
            right: 674px;
        }

        #Text1 {
            height: 35px;
            width: 136px;
            margin-left: 0px;
            margin-bottom: 1px;
        }
        
        .auto-style4 {
            
            margin-left: 5px;
            height: 40px;
            width: 100px;
        }

        .auto-style9 {
            width: 500px;
            height: 100px;
            margin-bottom: 0px;
        }

        .auto-style10 {
            height: 21px;
            width: 600px;
        }
        .auto-style13 {
            height: 65px;
            width: 153px;
        }
        .auto-style14 {
            width: 52px;
        }
        .auto-style18 {
            margin-top: 0px;
            margin-bottom: 0px;
        }
        .auto-style19 {
            margin-top: 0px;
        }
        .auto-style20 {
            height: 48px;
            width: 600px;
        }
        .auto-style22 {
            height: 65px;
            width: 52px;
        }
        .auto-style23 {
            height: 90px;
            width: 100px;
        }
        .auto-style24 {
            height: 90px;
            width: 153px;
        }
        .auto-style25 {
            margin-right: 0px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                        <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;出访信息&nbsp;>>&nbsp;查看出访信息
                    </td>
                    <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                        &nbsp;
                       
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />
                    </td>
                </tr>
            </table>
            <p  align="center" style="color: red; font-size: 30px">华东交通大学外联出访表单<p>
            </br>
            <table height="630" align="center"  style="border-color: rgb(255, 0, 0); border-color: rgb(255, 0, 0); font-size: 12px; border-collapse: collapse; margin-bottom: 0px;" border="1" cellspacing="0" cellpadding="0" uetable="null" data-sort="sortDisabled">
                <tbody>
                    <br>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">出访日期</td>
                        <td  style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" class="auto-style13">
                            <asp:TextBox ID="VisitDate" runat="server"  class="auto-style4" onClick="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true})" Width="105px"></asp:TextBox>
                            </tb>
                        <td width="156" align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" bgcolor="#fffff1" class="auto-style3">出访时长</td>
                        <td nowrap="nowrap" align="center" class="auto-style22" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" colspan="3">
                            <asp:TextBox ID="VisitLenth" readonly="true" runat="server" disable=""></asp:TextBox>
                            <asp:DropDownList ID="VisitLenthDropDownList" runat="server">
                                <asp:ListItem Selected="True" Value="1">天</asp:ListItem>
                                <asp:ListItem Value="30">月</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </br>
                    <tr>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241)" class="auto-style3">出访领队</td>
                        <td align="center" nowrap="nowrap"  style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" class="auto-style13">
                            <asp:TextBox ID="LeadPerson" readonly="true" runat="server"  class="auto-style4" Width="130px"  ></asp:TextBox>
                               &nbsp;</td>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">随行人员</td>
                        <td align="center" norwap="norrap" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" rowspan="1" colspan="3" class="auto-style14">
                            <asp:TextBox ID="FlowPerson" readonly="true" runat="server" class="auto-style4" Width="147px" ></asp:TextBox>
                             &nbsp;</tb></tr>
                    <tr>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">出访单位</td>
                        <td style="border-color: rgb(255, 0, 0)" norwap="norwap" colspan="1" class="auto-style13">
                            <asp:TextBox ID="VisitDepartment" readonly="true" runat="server" class="auto-style4" Width="128px" ></asp:TextBox>
                              &nbsp;<td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">出访目的</td>
                        <td  style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" rowspan="1" colspan="3" class="auto-style14">
                            <asp:TextBox ID="VisitGoal"  readonly="true"  runat="server" Height="61px" Width="209px" CssClass="auto-style19"></asp:TextBox>
                        </tr>
                    <tr>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">出访经费</td>
                        <td  nowrap="nowrap" disable="" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" class="auto-style13">
                            <br>
                            <asp:TextBox ID="VisitCost" readonly="true" runat="server" CssClass="auto-style25"></asp:TextBox>
                            <asp:DropDownList ID="VisitCostOption" runat="server">
                                <asp:ListItem Value="1">万</asp:ListItem>
                                <asp:ListItem Selected="True" Value="0.1">千</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">录入人员</td>
                        <td style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" rowspan="1" colspan="3" class="auto-style14">
                            <asp:TextBox ID="EnteringPerson" runat="server" readonly="true" class="auto-style4" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">关联战略合作协议</td>
                        <td norwap="norwap" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" class="auto-style13">
                            <asp:TextBox ID="RelationCOA" readonly="true" runat="server"  class="auto-style4"  ></asp:TextBox>
                             &nbsp;</td>

                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">关联合作项目<br />
                            （包括意向合作项目）</td>
                        <td norwap="norwap" class="auto-style22" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;">
                            <asp:TextBox ID="RelationCoProject" readonly="true" runat="server"  class="auto-style4"  ></asp:TextBox>
                              &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" rowspan="1" colspan="6" class="auto-style10"><span style="color: rgb(255, 0, 0);">*对于以上两项，与本次出访有关的战略合作协议或者合作项目可空缺，将来签署了相关协议或项目再补充关系</span>
                        </td>
                    </tr>
                    <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" bgcolor="#fffff1" class="auto-style3">其他说明</td>
                    <td style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" colspan="5" class="auto-style9">
                        &nbsp;<br>
                        <asp:TextBox ID="Otherexplain" readonly="true" runat="server" CssClass="auto-style18" Height="76px" Width="648px"></asp:TextBox>
                    <tr>
	       <td style="width: 100px; height: 20px; background-color:#fffff1" align="right">
		       审批人员意见：
	       </td>
	     <td style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" colspan="5" class="auto-style9">
                        &nbsp;<br>

		 <asp:TextBox ID="ApprovalOpinion" readonly="true"  runat="server" CssClass="auto-style18" Height="76px" Width="500px"></asp:TextBox>
             <BR /><BR />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    
	</td></tr>
                     <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" bgcolor="#fffff1" class="auto-style3">审批人</td>
        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" colspan="5" class="auto-style9">
            &nbsp;<asp:Label ID="ApprovalPerson" runat="server" Text="Label"></asp:Label>
            <br>
            <tr>
                        <td align="center" style="border-color: rgb(255, 0, 0); font-size:30px; -ms-word-break: break-all;" rowspan="1" colspan="6" class="auto-style20"><span style="color: rgb(255, 0, 0);">出访报告填写处</span>
                            <asp:Label ID="VisitReportDate" runat="server" Text="Label"></asp:Label>
                        </td>
            <tr>
             <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" bgcolor="#fffff1" class="auto-style23">战略合作协议</td>
                <td norwap="norwap" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" class="auto-style24">
                            <asp:TextBox ID="VisitResultCOA"  runat="server"  class="auto-style4"  ></asp:TextBox>
                             <img style="hight:30px;width:30px" id="searchimgRelationCOA"  onclick="selectBuMen(VisitResultCOA);"
                             src="../images/Button/search.gif" />&nbsp;
                 <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" bgcolor="#fffff1" class="auto-style23">合作项目<br />
                            （包括意向合作项目）</td>
                     <td norwap="norwap" class="auto-style6" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;">
                            <asp:TextBox ID="VisitResultCopro" readonly="true" runat="server"  class="auto-style4"  ></asp:TextBox>
                              <img style="hight:30px;width:30px" id="searchimgRelationCoProject"  onclick="selectBuMen(VisitResultCopro);"
                             src="../images/Button/search.gif" />
                             <br>
                            <tr>
                              <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" bgcolor="#fffff1" class="auto-style3">其他</td>
                    <td style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" colspan="5" class="auto-style9">
                        &nbsp;<br>
                        <asp:TextBox ID="VisitOtherResult"  runat="server" CssClass="auto-style18" Height="76px" Width="648px" ></asp:TextBox>
                        </table>
                    <p align="center" style="font-size:20px;">如果以后有与此次出访有关的成果，可以在报告里添加</p>
              
            <tr>


        </div>
    </form>
</body>
</html>
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
            .auto-style2 {
                width: 300px;
                height: 25px;
                background-color: #D6E2F3;
            }
        </style>
</head>
<body>
    <form id="form2" runat="server">
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;项目管理 &gt;&gt; 查看项目信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <img class="HerCss" onclick="PrintTable()" src="../images/Button/BtnPrint.jpg" />
                    &nbsp;<img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;</td>
            </tr>
            <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
    <table style="width: 600px;  margin:0px auto;"   bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
		<tr>
	<td class="auto-style2" align="right">
		项目名称：
	</td>

	<td style="padding-left: 5px;  background-color: #ffffff;"  >
		<asp:Label id="ProjectName" runat="server"></asp:Label>
        &nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" ForeColor="Blue"
            NavigateUrl="TuXingJinDu.aspx?ProjectName=0">图形化进度显示</asp:HyperLink></td></tr>
	<tr>
	<td class="auto-style2" align="right">
		项目状态：
	</td>
	<td style="padding-left: 5px; background-color: #ffffff" class="auto-style2" >
		<asp:Label id="ProjectSerils" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		甲方客户单位：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="SuoShuKeHu" runat="server"></asp:Label>
	</td>
        </tr>
	<tr>
	<td class="auto-style2" align="right">
		甲方项目负责人姓名：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="ContactPerson" runat="server"></asp:Label>
	</td>
        </tr>
	<tr>
	<td class="auto-style2" align="right">
		甲方项目负责人电话：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="ContactTel" runat="server"></asp:Label>
	</td>
        </tr>
	<tr>
	<td class="auto-style2" align="right">
		甲方项目负责人电子邮箱：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="ContactEmail" runat="server"></asp:Label>
	</td>
        </tr>
	<tr>
	<td class="auto-style2" align="right">
		项目合作方式及内容：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="XiangMuDaXiao" runat="server"></asp:Label>
	</td>
        </tr>
	<tr>
	<td class="auto-style2" align="right">
		校内学院推送：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="Push" runat="server"></asp:Label>
	</td>
	</tr>
	<tr>
	<td class="auto-style2" align="right">
		预计成交日期：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="YuJiChengJiaoRiQi" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		提醒日期：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="TiXingDate" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		校内负责人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="FuZeRen" runat="server" Text="暂无"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		项目金额：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="XiangMuJinE" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		项目配合人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="PeiHeRenList" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		发布人：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="UserName" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		更新时间：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="TimeStr" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		合同以及附件：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="HeTongAndFuJian" runat="server"></asp:Label>
	</td></tr>
	<tr>
	<td class="auto-style2" align="right">
		验收方式及其他说明：
	</td>
	<td style="padding-left: 5px; height: 25px; background-color: #ffffff" >
		<asp:Label id="BackInfo" runat="server"></asp:Label>
	</td></tr>
</table>
</div>
    </form>
</body>
</html>