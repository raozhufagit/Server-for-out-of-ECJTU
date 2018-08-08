<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ZhuanjiaView.aspx.cs" Inherits="DuiWaiFuwu_ZhuanjiaView" %>
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
                    <a class="hei" href="../Main/MyDesk.aspx">����</a>&nbsp;>>&nbsp;ר����Ϣ&nbsp;>>&nbsp;�鿴��Ϣ
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    
                    
                    <img class="HerCss" onclick="javascript:window.history.go(-1)" src="../images/Button/BtnExit.jpg" />&nbsp;
                </td>
            </tr>
            <tr>
                <td height="3px" colspan="2" style="background-color: #ffffff">
                </td>
            </tr>
        </table>
        <table style="width: 1000px" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td style="width: 100px !important; height: 25px; background-color: #D6E2F3" align="right">
                    ������
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblXingMing" runat="server" Width="140px"></asp:Label>
                   
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    ���ţ�
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblGongHao" runat="server" Width="145px"></asp:Label>
                    
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right" rowspan="3">
                    ͷ��
                </td>
                <td width="200px" rowspan="3" style="padding-left: 5px; background-color: #ffffff">
                   
                    <div class="myimage">
                    <asp:Image ID="Image1" runat="server" style="margin-left:50px; width:100px !important; height:100px !important; border-radius:100px !important; -webkit-border-radius:100px !important;-moz-border-radius:100px !important;" />
                    </div>
                </td>
            </tr>
            <tr>
                 <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    �Ա�
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblXingBie" runat="server" Width="140px"></asp:Label>
                   
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    ���壺
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblNation" runat="server" Width="140px"></asp:Label>
                   
                </td>
               
            </tr>
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    ������ò ��
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblPolitical" runat="server" Width="145px"></asp:Label>
                    
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    �������� ��
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblChuShengRiQi" runat="server" Width="145px" DataFormatString="{0:yyyy-MM-dd}"></asp:Label>
                   
                </td>
                
            </tr>
            
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    ���ڲ��ţ�
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblBuMen" runat="server" Width="145px"></asp:Label>
                    
                    
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    ѧ�� ��
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblXueLi" runat="server" Width="145px"></asp:Label>
                   
                </td>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3; text-align: right">
                    ѧλ ��
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblXueWei" runat="server" Width="120px"></asp:Label>
                    
                </td>
            </tr>
                     
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    ѧ�� ��
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblXueKe" runat="server" Width="145px"></asp:Label>
                   
                </td>
            
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    �о����� ��
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblYanJiuLingYu" runat="server" Width="145px"></asp:Label>
                   
                </td>
            
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    ְ�� ��
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblZhiWu" runat="server" Width="120px"></asp:Label>
                   
                </td>
            </tr>   
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    ְ�� ��
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                    <asp:Label ID="lblZhiCheng" runat="server" Width="145px"></asp:Label>
                   
                </td>
            
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    ¼��ʱ�䣺
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff"  colspan="3">
                    <asp:Label id="lblTimeStr" runat="server" Width="145px" DataFormatString="{0:yyyy-MM-dd}" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    �о��ɹ���
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff" colspan="5">
                    <asp:Label ID="lblResearchFind" runat="server" Width="100%" Rows="6" TextMode="MultiLine"></asp:Label>
                   
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 25px; background-color: #D6E2F3" align="right">
                    ��飺
                </td>
                <td style="padding-left: 5px; height: 25px; background-color: #ffffff" colspan="5">
                    <asp:Label ID="lblJianJie" runat="server" Width="100%" Rows="10" TextMode="MultiLine"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 35px; background-color: #D6E2F3" align="right">
                    �����ļ���
                </td>
                <td style="padding-left: 5px; height: 35px; background-color: #ffffff" colspan="5">
                   <asp:Label id="lblFuJianStr" runat="server"></asp:Label>
                </td>
            </tr>
           
        </table>
    </div>
    </form>
</body>
</html>
