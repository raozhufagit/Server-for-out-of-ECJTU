<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LCXEquipmentRentView.aspx.cs" Inherits="DuiWaiFuwu_LCXEquipmentRentView" %>

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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;对外服务信息&nbsp;>>&nbsp;查看设备租借信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;
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
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                   设备名称：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:label ID="lblEquipmentName" runat="server" Width="23%"></asp:label>
                    &nbsp;</td>
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    设备编号：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:label ID="lblEquipmentNo" runat="server" Width="23%"></asp:label>
                    &nbsp;</td>
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right" >
                    类型：
                </td>
                <td width="250px"  style="padding-left: 5px; background-color: #ffffff">
                   
                    
                    <asp:label ID="lblBorrowType" runat="server" Width="23%"></asp:label>
                    
                </td>
            </tr>
            <tr>
                 <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    租借单位：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:label ID="lblBorrowDept" runat="server" Width="23%"></asp:label>
                    &nbsp;</td>
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    租借人：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:label ID="lblBorrowPerson" runat="server" Width="23%"></asp:label>
                   
                   
                </td>
               <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    是否续借：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:label ID="lblWhetherContinue" runat="server" Width="23%"></asp:label>
                   
                   
                </td>
            </tr>
            <tr>
                
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    开始时间 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:label ID="lblStartTime" runat="server" Width="23%" onClick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:label>
                   
                </td>
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    结束时间 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:label ID="lblEndTime" runat="server" Width="23%" onClick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:label>
                   
                </td>
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    归还时间 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:label ID="lblReturnTime" runat="server" Width="23%" onClick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:label>
                   
                </td>
            </tr>
           <tr>
                <td style="width: 10%;  background-color: #D6E2F3" align="right">
                    归还登记：
                </td>
                <td style="padding-left: 5px;  background-color: #ffffff" colspan="5">
                    <asp:label ID="lblRestitutionReg" runat="server" Width="100%" Rows="10" TextMode="MultiLine"></asp:label>
                    <script type="text/javascript">
                       // var editor = new baidu.editor.ui.Editor({ id: 'editor', minFrameHeight: 300 }); editor.render("lblJianJie");
                    </script>
                </td>
            </tr>
            <tr>
                <td style="width: 10%;  background-color: #D6E2F3" align="right">
                    备注：
                </td>
                <td style="padding-left: 5px;  background-color: #ffffff" colspan="5">
                    <asp:label ID="lblRemarks" runat="server" Width="100%" Rows="10" TextMode="MultiLine"></asp:label>
                    <script type="text/javascript">
                       // var editor = new baidu.editor.ui.Editor({ id: 'editor', minFrameHeight: 300 }); editor.render("lblJianJie");
                    </script>
                </td>
            </tr>
             
        </table>
    </div>
    </form>
</body>
</html>

