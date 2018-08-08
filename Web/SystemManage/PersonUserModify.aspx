<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PersonUserModify.aspx.cs" Inherits="SystemManage_PersonUserModify" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
                    <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;个人基本信息&nbsp;>>&nbsp;查看信息
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    
                    
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td height="3px" colspan="2" style="background-color: #ffffff">
                </td>
            </tr>
        </table>
        <table style="width: 1000px" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
            <tr>
                <td style="width: 100px !important; height: 45px; background-color: #D6E2F3" align="right">
                    用户名：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtUserName" runat="server" Width="140px"></asp:TextBox>
                   
                </td>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    工号：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtSerils" runat="server" Width="145px"></asp:TextBox>
                    
                </td>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right" rowspan="3">
                    头像：
                </td>
                <td width="200px" rowspan="3" style="padding-left: 5px; background-color: #ffffff">
                   
                    <div class="myimage">
                    
                    <asp:FileUpload ID="FileUpload2" runat="server" Width="200px" />
                    </div>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    真实姓名：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtTrueName" runat="server" Width="140px"></asp:TextBox>
                   
                </td>
                 <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    性别：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtSex" runat="server" Width="140px"></asp:TextBox>
                   
                </td>
                
               
            </tr>
            <tr>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    政治面貌 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtZhengZhiMianMao" runat="server" Width="145px"></asp:TextBox>
                    
                </td>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    出生日期 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtBirthDay" runat="server" Width="145px" DataFormatString="{0:yyyy-MM-dd}"></asp:TextBox>
                   
                </td>
                
            </tr>
             <tr>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    民族 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtMingZu" runat="server" Width="145px"></asp:TextBox>
                    
                </td>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    籍贯 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtJiGuan" runat="server" Width="145px" ></asp:TextBox>
                   
                </td>
                 <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    婚姻 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtHunYing" runat="server" Width="145px" ></asp:TextBox>
                   
                </td>
                
            </tr>
            <tr>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    所在部门：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtDepartment" runat="server" Width="145px"></asp:TextBox>
                    
                    
                </td>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3; text-align: right">
                    职位 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtZhiWei" runat="server" Width="120px"></asp:TextBox>
                    
                </td>
               
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    职称 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtZhiCheng" runat="server" Width="145px"></asp:TextBox>
                   
                </td>
            </tr>
                     
            <tr>
                
             <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    学历 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtXueLi" runat="server" Width="145px"></asp:TextBox>
                   
                </td>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    毕业院校 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtBiYeYuanXiao" runat="server" Width="145px"></asp:TextBox>
                   
                </td>
            
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    所学专业 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtZhuanYe" runat="server" Width="120px"></asp:TextBox>
                   
                </td>
            </tr>   
            <tr>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    电子邮件 ：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff">
                    <asp:TextBox ID="txtEmailStr" runat="server" Width="145px"></asp:TextBox>
                   
                </td>
            
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    角色：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" >
                    <asp:TextBox id="txtJiaoSe" runat="server" Width="145px" ></asp:TextBox>
                </td>
            
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    在岗状态：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" >
                    <asp:TextBox ID="txtZaiGang" runat="server" ></asp:TextBox>
                   
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 45px; background-color: #D6E2F3" align="right">
                    简介：
                </td>
                <td style="padding-left: 5px; height: 45px; background-color: #ffffff" colspan="5">
                    <asp:TextBox ID="txtBackInfo" runat="server" Width="100%" Rows="20" TextMode="MultiLine"></asp:TextBox>
                    
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
            <tr>
                <td style="padding-left: 390px; height: 45px; background-color: #ffffff" colspan="6">
		 
          &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" onmouseover="this.className='bbk button small-longg-btn'" onmouseout="this.className='bbk button small-long-btn'"  class="bbk button small-long-btn" onclick="subPass" Text="保存" />
   &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" onmouseover="this.className='bbk button small-yelloww-btn'" onmouseout="this.className='bbk button small-yellow-btn'"  class="bbk button small-yellow-btn" onclick="subReturn" Text="返回" />
 
                    
	</td>
                </tr>
        </table>
    </div>
    </form>
</body>
</html>

