<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LCXScientificResearchAdd.aspx.cs" Inherits="DuiWaiFuwu_LCXScientificResearchAdd" %>

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
        <table style="width: 1100px" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td style="width: 100px !important; height: 45px; background-color: #D6E2F3" align="right">
                    科研名称：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtScientificName" runat="server" Width="145px"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtScientificName"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    编号：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtScientificNo" runat="server" Width="145px"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtScientificNo"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right" >
                    类型：
                </td>
                <td width="250px"  style="padding-left: 5px; background-color: #ffffff">
                   
                    
                    <asp:TextBox ID="txtScientificType" runat="server" Width="145px"></asp:TextBox>
                    
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtScientificType"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                    
                </td>
            </tr>
            <tr>
                 <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    主持人：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtHostPerson" runat="server" Width="145px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXUser&LieName=TrueName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtHostPerson').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtHostPerson"
                        ErrorMessage="*该项不可以为空"  ></asp:RequiredFieldValidator>
                </td>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    参与人：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtParticipants" runat="server" Width="145px"></asp:TextBox>
                   <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXUser&LieName=TrueName&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtParticipants').value=wName;}"
                        src="../images/Button/search.gif" />
                   
                </td>
               <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    研究方向：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtScientificDir" runat="server" Width="145px"></asp:TextBox>
                   <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXScientificResearch&LieName=ScientificDir&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtScientificDir').value=wName;}"
                        src="../images/Button/search.gif" />
                   
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    研究状态 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtScientificStates" runat="server" Width="145px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXScientificResearch&LieName=ScientificStates&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtScientificStates').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    开始时间 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtStartTime" runat="server" Width="145px" onClick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                   
                </td>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    结束时间 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtEndTime" runat="server" Width="145px" onClick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                   
                </td>
            </tr>
           <tr>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    应用方向 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" colspan="5">
                    <asp:TextBox ID="txtApplicationDir" runat="server" Width="100%" Rows="5" TextMode="MultiLine"></asp:TextBox>
                    
                </td>
                
            </tr>
            <tr>
                <td style="width: 100px;  background-color: #D6E2F3" align="right">
                    研究成果：
                </td>
                <td style="padding-left: 5px;  background-color: #ffffff" colspan="5">
                    <asp:TextBox ID="txtResearchFind" runat="server" Width="100%" Rows="10" TextMode="MultiLine"></asp:TextBox>
                    <script type="text/javascript">
                       // var editor = new baidu.editor.ui.Editor({ id: 'editor', minFrameHeight: 300 }); editor.render("txtJianJie");
                    </script>
                </td>
            </tr>
            <tr>
                <td style="width: 100px;  background-color: #D6E2F3" align="right">
                    备注：
                </td>
                <td style="padding-left: 5px;  background-color: #ffffff" colspan="5">
                    <asp:TextBox ID="txtRemarks" runat="server" Width="100%" Rows="10" TextMode="MultiLine"></asp:TextBox>
                    <script type="text/javascript">
                       // var editor = new baidu.editor.ui.Editor({ id: 'editor', minFrameHeight: 300 }); editor.render("txtJianJie");
                    </script>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    附件文件：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" colspan="5">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                    &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False"
                        ImageAlign="AbsMiddle" ImageUrl="../images/Button/DelFile.jpg" OnClick="ImageButton3_Click" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 45px; background-color: #D6E2F3">
                    上传附件：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" colspan="5">
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
