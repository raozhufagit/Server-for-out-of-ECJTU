<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LCXContractImpleAdd.aspx.cs" Inherits="CooperationAgreement_LCXContractImpleAdd" %>

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
        .auto-style2 {
            width: 170px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    &nbsp;<img src="../images/BanKuaiJianTou.gif" />
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;战略合作协议管理&nbsp;>>&nbsp;添加战略合作协议
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
        <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
                    合同名称：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtContractName" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXCooperation&LieName=Title&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtStrategicagreeName').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtContractName"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
                    阶段名称：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtPhaseName" runat="server" Width="350px"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPhaseName"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
                    开始时间 ：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <!--<input id="txtSignTime" Width="350px" onclick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd HH:mm:ss'})" type="text">-->
                    <asp:TextBox ID="txtStartTime" runat="server" Width="350px" onfocus="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                    
                   
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
                    结束时间 ：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <!--<input id="txtSignTime" Width="350px" onclick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd HH:mm:ss'})" type="text">-->
                    <asp:TextBox ID="txtEndTime" runat="server" Width="350px" onfocus="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                    
                   
                </td>
            </tr>
            <tr>
                <td style="background-color: #D6E2F3" align="right" class="auto-style2">
                    完成度：
                </td>
                <td style="padding-left: 5px; background-color: #ffffff">
                    <asp:TextBox ID="txtCompletionDegree" runat="server" Width="350px"></asp:TextBox>
                    
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
                   主持人：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtChargePerson" runat="server" Width="350px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXUser&LieName=TrueName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtChargePerson').value=wName;}"
                        src="../images/Button/search.gif" />
                   
                </td>
            </tr>
             <tr>
                <td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
                   备注：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <div style="width:80% !important;float:left;">
                    <asp:TextBox ID="txtRemarks" runat="server"  Width="100%" Rows="10" TextMode="MultiLine" ></asp:TextBox>
                   <script type="text/javascript">
                        var editor=UE.getEditor('txtContent')
                       // var editor = new baidu.editor.ui.Editor({ id: 'editor', minFrameHeight: 300}); editor.render("txtContent");
                    </script>
                        </div>
                </td>
            </tr>
            <tr>
                <td style="width: 170px; height: 25px; background-color: #D6E2F3" align="right">
                    附件文件：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                    &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False"
                        ImageAlign="AbsMiddle" ImageUrl="../images/Button/DelFile.jpg" OnClick="ImageButton3_Click" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 170px; height: 25px; background-color: #D6E2F3">
                    上传附件：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:FileUpload ID="FileUpload1" runat="server" Width="350px" />
                    <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" ImageAlign="AbsMiddle"
                        ImageUrl="../images/Button/UpLoad.jpg" OnClick="ImageButton2_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
