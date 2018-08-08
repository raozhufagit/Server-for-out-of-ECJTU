<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChuFangAdd.aspx.cs" Inherits="ChuFangFuWu_ChuFangAdd" %>

<html>
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
        .auto-style6 {
            height: 65px;
            width: 288px;
        }

        .auto-style4 {
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
            width: 210px;
        }
        .auto-style14 {
            width: 288px;
        }
        .auto-style18 {
            margin-top: 0px;
            margin-bottom: 0px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                        <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;出访信息&nbsp;>>&nbsp;添加出访信息
                    </td>
                    <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                            OnClick="ImageButton1_Click" />
                        <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;
                    </td>
                </tr>
            </table>
             <p  align="center" style="color: red; font-size: 30px">华东交通大学外联出访表单<p>
              </br>
            <table height="630"  align="center" style="border-color: rgb(255, 0, 0); border-color: rgb(255, 0, 0); font-size: 12px; border-collapse: collapse; margin-bottom: 0px;" border="1" cellspacing="0" cellpadding="0" uetable="null" data-sort="sortDisabled">
                <tbody>
                    <br>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">出访日期</td>
                        <td  style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" class="auto-style13">
                            <asp:TextBox ID="VisitDate" runat="server"  class="auto-style4" onClick="WdatePicker({startDate:'%y-%M-01 00:00:00',dateFmt:'yyyy-MM-dd',alwaysUseStartDate:true})">点击选择时间</asp:TextBox>
                            </tb>
                            &nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="VisitDate" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                        <td width="156" align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" bgcolor="#fffff1" class="auto-style3">出访时长</td>
                       <td  style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" rowspan="1" colspan="3" class="auto-style14">
                            <asp:TextBox ID="VisitLenth" runat="server" Height="31px" Width="83px"></asp:TextBox>
                            &nbsp;&nbsp;&nbsp;
                            <asp:DropDownList ID="VisitLenthDropDownList" runat="server">
                                <asp:ListItem Selected="True" Value="1">天</asp:ListItem>
                                <asp:ListItem Value="30">月</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="VisitLenth" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </br>
                    <tr>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241)" class="auto-style3">出访领队</td>
                        <td align="center" nowrap="nowrap"  style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" class="auto-style13">
                            <asp:TextBox ID="LeadPerson" runat="server"  class="auto-style4"  ></asp:TextBox>
                               &nbsp;
                               <img style="hight:30px;width:30px" id="searchimg"  onclick="selectUser(LeadPerson);"
                             src="../images/Button/search.gif" />&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="LeadPerson"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                        </td>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">随行人员</td>
                        <td  style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" rowspan="1" colspan="3" class="auto-style14">
                            <asp:TextBox ID="FlowPerson" runat="server" class="auto-style4" ></asp:TextBox>
                             <img style="hight:30px;width:30px" id="searchimg2"  onclick="selectUser(FlowPerson);"
                             src="../images/Button/search.gif" />
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FlowPerson"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                       
                        </tb>      
                     </tr>
                    <tr>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">出访单位</td>
                       <td align="center" nowrap="nowrap"  style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" class="auto-style13">
                            <asp:TextBox ID="VisitDepartment" runat="server" class="auto-style4" Width="96px"  ></asp:TextBox>
                              &nbsp;
                              <img style="hight:30px;width:30px" id="searchimgVisitDepartment"  onclick="selectBuMen(VisitDepartment);"
                             src="../images/Button/search.gif" />&nbsp;&nbsp;&nbsp; <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="VisitDepartment"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                       
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">出访目的</td>
                        <td  style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" rowspan="1" colspan="3" class="auto-style14">
                            <asp:TextBox ID="VisitGoal" runat="server" Height="61px" Width="148px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="VisitGoal" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                        </tr>
                    <tr>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">出访经费</td>
                        <td  nowrap="nowrap" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" class="auto-style13">
                            <br>
                             <asp:TextBox ID="VisitCost" runat="server" Height="31px" Width="83px"></asp:TextBox>
                            &nbsp;&nbsp;
                            <asp:DropDownList ID="VisitCostOption" runat="server">
                                <asp:ListItem Value="1">万</asp:ListItem>
                                <asp:ListItem Selected="True" Value="0.1">千</asp:ListItem>
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="VisitCost" ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                        </td>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">录入人员</td>
                        <td style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" rowspan="1" colspan="3" class="auto-style14">
                            <asp:TextBox ID="EnteringPerson" runat="server" readonly="true" class="auto-style4" ></asp:TextBox></td>
                    </tr>
                    <tr>
                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">关联战略合作协议</td>
                        <td norwap="norwap" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" class="auto-style13">
                            <asp:TextBox ID="RelationCOA" runat="server" class="auto-style4" Width="96px"  ></asp:TextBox>
                              &nbsp;
                              <img style="hight:30px;width:30px" id="searchimgRelationCOA"  onclick="selectBuMen(RelationCOA);"
                             src="../images/Button/search.gif" />
                            </td>

                        <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all; background-color: rgb(255, 255, 241);" class="auto-style3">关联合作项目<br />
                            （包括意向合作项目）</td>
                        <td norwap="norwap" class="auto-style6" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;">
                             <asp:TextBox ID="RelationCoPro" runat="server" class="auto-style4" Width="96px"  ></asp:TextBox>
                              &nbsp;
                              <img style="hight:30px;width:30px" id="searchimgRelationCoPro"  onclick="selectBuMen(RelationCoPro);"
                             src="../images/Button/search.gif" />
                        </td>
                    </tr>
                    <tr>
                        <td style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" rowspan="1" colspan="6" class="auto-style10"><span style="color: rgb(255, 0, 0);">*对于以上两项，与本次出访有关的战略合作协议或者合作项目可空缺，将来签署了相关协议或项目再补充关系</span>
                        </td>
                    </tr>
                    <td align="center" style="border-color: rgb(255, 0, 0); -ms-word-break: break-all;" bgcolor="#fffff1" class="auto-style3">其他说明</td>
                    <td style="border-color: rgb(255, 0, 0)" colspan="5" class="auto-style9">
                        &nbsp;<br>
                        <asp:TextBox ID="Otherexplain" runat="server" CssClass="auto-style18" Height="76px" Width="754px"></asp:TextBox>
                        
            </table>
                <tr>
                                 <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
          <div style="display:none;"> <asp:TextBox ID="txtGongGao" Text="admin" runat="server" onkeydown="javascript:return false;" 
                Width="349px"></asp:TextBox>
                               <img style="hight:30px;width:30px" id="searchimg3"  onclick="selectUser(txtGongGao);"
                             src="../images/Button/search.gif" /><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGongGao"
                Display="Dynamic" ErrorMessage="*必须指定审批人"></asp:RequiredFieldValidator><asp:CheckBox ID="CHKSMS" runat="server" Checked="True" /><img
                    src="../images/TreeImages/@sms.gif" />短消息<asp:CheckBox ID="CHKRTX" 
                        runat="server" /><img
                                src="../images/TreeImages/notify2.gif" />微信<asp:CheckBox ID="CHKMOB" runat="server" /><img
                        src="../images/TreeImages/mobile_sms.gif" />短信息</td></div> 
        </div>
    </form>
</body>
</html>
