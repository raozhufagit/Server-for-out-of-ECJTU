<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LCXInnovationPlatModify.aspx.cs" Inherits="DuiWaiFuwu_LCXInnovationPlatModify" %>

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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;对外服务信息&nbsp;>>&nbsp;修改创新平台信息
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
                   平台名称：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" >
                    <asp:TextBox ID="txtPlatFormName" runat="server" Width="50%"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPlatFormName"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    负责人：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" >
                    <asp:TextBox ID="txtManager" runat="server" Width="50%" ></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXUser&LieName=TrueName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtManager').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtManager"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
                
            </tr>
            <tr>
                 <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    教师团队：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" colspan="3">
                    <asp:TextBox ID="txtTeacherGroup" runat="server" Width="100%" TextMode="MultiLine" Rows="5"></asp:TextBox>
                   
                    
                </td>
                
            </tr>
            <tr>
                
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    研究成果 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" colspan="3">
                   <asp:TextBox ID="txtResearchFind" runat="server" Width="100%" TextMode="MultiLine" Rows="10"></asp:TextBox>
                   
                </td>
                
            </tr>
            <tr>
                
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    团队介绍 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" colspan="3">
                   <asp:TextBox ID="txtTeamIntr" runat="server" Width="100%" TextMode="MultiLine" Rows="10"></asp:TextBox>
                   
                </td>
                
            </tr>
            <tr>
                
                <td style="width: 10%; height: 45px; background-color: #D6E2F3" align="right">
                    对外服务内容 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" colspan="3">
                   <asp:TextBox ID="txtServiceContent" runat="server" Width="100%" TextMode="MultiLine" Rows="10"></asp:TextBox>
                   
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