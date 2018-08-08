<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZhuanjiaPersonAdd.aspx.cs" Inherits="DuiWaiFuwu_ZhuanjiaPersonAdd" %>

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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;个人信息管理&nbsp;>>&nbsp;添加信息
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
                <td style="width: 100px !important; height: 25px; background-color: #D6E2F3" align="right">
                    姓名：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtXingMing" runat="server" Width="140px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ZhuanJia&LieName=XingMing&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtXingMing').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtXingMing"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    工号：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtGongHao" runat="server" Width="145px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ZhuanJia&LieName=GongHao&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtGongHao').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtGongHao"
                        ErrorMessage="*该项不可以为空"></asp:RequiredFieldValidator>
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right" rowspan="3">
                    头像：
                </td>
                <td width="250px" rowspan="3" style="padding-left: 5px; background-color: #ffffff">
                   
                    
                    <asp:FileUpload ID="FileUpload2" runat="server" Width="200px" />
                    
                </td>
            </tr>
            <tr>
                 <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    性别：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtXingBie" runat="server" Width="140px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ZhuanJia&LieName=XingBie&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtXingBie').value=wName;}"
                        src="../images/Button/search.gif" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtXingBie"
                        ErrorMessage="*该项不可以为空"  ></asp:RequiredFieldValidator>
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    民族：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtNation" runat="server" Width="140px"></asp:TextBox>
                   <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ZhuanJia&LieName=Nation&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtNation').value=wName;}"
                        src="../images/Button/search.gif" />
                   
                </td>
               
            </tr>
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    政治面貌 ：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtPolitical" runat="server" Width="145px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ZhuanJia&LieName=Political&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtPolitical').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    出生日期 ：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtChuShengRiQi" runat="server" Width="145px" onClick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                   
                </td>
                
            </tr>
            
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    所在部门：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtBuMen" runat="server" Width="145px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ZhuanJia&LieName=BuMen&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtBuMen').value=wName;}"
                        src="../images/Button/search.gif" />
                    
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    学历 ：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtXueLi" runat="server" Width="145px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=ZhuanJia&LieName=XueLi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtXueLi').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3; text-align: right">
                    学位 ：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtXueWei" runat="server" Width="120px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXVip&LieName=XueLi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtXueWei').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>
                     
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    学科 ：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtXueKe" runat="server" Width="145px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXVip&LieName=XueLi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtXueKe').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    研究领域 ：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtYanJiuLingYu" runat="server" Width="145px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXVip&LieName=XueLi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtYanJiuLingYu').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    职务 ：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtZhiWu" runat="server" Width="120px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXVip&LieName=XueLi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZhiWu').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            </tr>   
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    职称 ：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:TextBox ID="txtZhiCheng" runat="server" Width="145px"></asp:TextBox>
                    <img class="HerCss" onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCXVip&LieName=XueLi&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('txtZhiCheng').value=wName;}"
                        src="../images/Button/search.gif" />
                </td>
            
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    录入时间：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff"  colspan="3">
                    <asp:TextBox id="txtTimeStr" runat="server" Width="145px"  onClick="WdatePicker({el:this,dateFmt:'yyyy-MM-dd'})"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    研究成果：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff" colspan="5">
                    <asp:TextBox ID="txtResearchFind" runat="server" Width="100%" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    <script type="text/javascript">
                       // var editor = new baidu.editor.ui.Editor({ id: 'editor', minFrameHeight: 300 }); editor.render("txtJianJie");
                    </script>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    简介：
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff" colspan="5">
                    <asp:TextBox ID="txtJianJie" runat="server" Width="100%" Rows="10" TextMode="MultiLine"></asp:TextBox>
                    <script type="text/javascript">
                       // var editor = new baidu.editor.ui.Editor({ id: 'editor', minFrameHeight: 300 }); editor.render("txtJianJie");
                    </script>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 35px; background-color: #D6E2F3" align="right">
                    附件文件：
                </td>
                <td style="padding-left: 5px; height: 35px; background-color: #ffffff" colspan="5">
                    <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatColumns="4" RepeatDirection="Horizontal">
                    </asp:CheckBoxList>
                    &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" CausesValidation="False"
                        ImageAlign="AbsMiddle" ImageUrl="../images/Button/DelFile.jpg" OnClick="ImageButton3_Click" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 35px; background-color: #D6E2F3">
                    上传附件：
                </td>
                <td style="padding-left: 5px; height: 35px; background-color: #ffffff" colspan="5">
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
