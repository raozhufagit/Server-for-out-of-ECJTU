<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LCXEquipmentRepairAdd.aspx.cs" Inherits="DuiWaiFuwu_LCXEquipmentRepairAdd" %>

<!DOCTYPE html>

<html>
<head>
    <title>
        <%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
    <link href="../Style/Style.css" type="text/css" rel="STYLESHEET">
    <script src="../UEditor/ueditor.config.js" type="text/javascript"></script>
    <script src="../UEditor/ueditor.all.js" type="text/javascript"></script>
    <script language="javascript" src="../JS/DatePicker/WdatePicker.js" type="text/javascript"></script>
    <link rel="stylesheet" type="text/css" href="../UEditor/themes/default/css/ueditor.css" />
    <script language="javascript">
        function PrintTable() {
            document.getElementById("PrintHide").style.visibility = "hidden"
            print();
            document.getElementById("PrintHide").style.visibility = "visible"
        }
    </script>
    <style type="text/css">
    table{margin:0 auto;}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0" margin-left="0 !important">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../images/BanKuaiJianTou.gif" />
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;对外服务信息&nbsp;>>&nbsp;添加科研信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Button/Submit.jpg"
                        OnClick="ImageButton1_Click" />
                    <img src="../images/Button/JianGe.jpg" />&nbsp;
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;
                </td>
            </tr>
            <tr>
                <td height="3px" colspan="2" style="background-color: #ffffff">
                </td>
            </tr>
        </table>
        <table style="width: 80%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td style="width: 10% !important; height: 45px; background-color: #D6E2F3" align="right">
                   设备名称：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtEquipmentName" runat="server" Width="50%"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXEquipment&LieName=EquipmentName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtEquipmentName').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEquipmentName"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    设备编号：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtEquipmentNo" runat="server" Width="50%"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXEquipment&LieName=EquipmentNo&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtEquipmentNo').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEquipmentNo"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right" >
                    维修单位：
                </td>
                <td width="250px"  style="padding-left: 5px; background-color: #ffffff">
                   
                    
                    <asp:TextBox ID="txtRepairDept" runat="server" Width="50%"></asp:TextBox>
                    
                </td>
            </tr>
            
            <tr>
                
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    维修时间 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtRepairTime" runat="server" Width="50%" onClick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                </td>
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    维修花费 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtRepairCost" runat="server" Width="50%" ></asp:TextBox>
                   
                </td>
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    核查人 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtChecker" runat="server" Width="50%" ></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtChecker"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
           
            <tr>
                <td style="width: 10%;  background-color: #D6E2F3" align="right">
                    备注：
                </td>
                <td style="padding-left: 5px;  background-color: #ffffff" colspan="5">
                    <asp:TextBox ID="txtRemarks" runat="server" Width="100%" Rows="10" TextMode="MultiLine"></asp:TextBox>
                    <script type="text/javascript">
                       // var editor = new baidu.editor.ui.Editor({ id: 'editor', minFrameHeight: 300 }); editor.render("txtJianJie");
                    </script>
                </td>
            </tr>
            
        </table>
    </div>
    </form>
</body>
</html>
