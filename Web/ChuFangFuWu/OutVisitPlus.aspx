<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OutVisitPlus.aspx.cs" Inherits="ChuFangFuWu_OutVisitPlus" %>

<!DOCTYPE html>

<html>
<head>
    <title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
    <link href="../Style/Style.css" type="text/css" rel="STYLESHEET">

    <style type="text/css">
        
         .TextBoxCss {
           
            width: 100%;
            height: 100%;
        }
          .TextBoxLongCss {
            width: 100%;
            height: 100%;
        }
           .ShowContent {
               
               background-color: #D6E2F3;
               width:200px;
               height:50px;
        }
            .ShowNone {
              
               background-color: #ffffff;
               width:300px;
               height:50px;
                
        }
             .ShowLongContent {
               
               background-color: #D6E2F3;
               width:200px;
               height:100px;
        }
            .ShowLongNone {
              
               background-color: #ffffff;
               width:800px;
               height:100px;
                
        }
            .LittleTiltle{
              background-color: #ffffff;
              width: 1000px;
              height: 60px;
              font-family: 宋体;
              font-size:30px;
            }
        </style>
</head>
<body>
    <form id="form2" runat="server">
        <div>
            <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                        <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;出访管理 &gt;&gt;出访信息
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
            <table style="width: 1000px; margin: 0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
                <tr>
                    <td  align="center" class="LittleTiltle"  >华东交通大学外联出访表单</td>

                </tr>
            </table>
            <table style="width: 1000px; margin: 0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
                <tr>
                    <td  align="center" class="LittleTiltle"  >出访基本信息</td>

                </tr>
            </table>
            <!--这是一段注释。注释不会在浏览器中显示。
         <table class="TiltleTable" border="0" cellpadding="2" cellspacing="1">  -->
            <table style="width: 1000px; margin: 0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
                <tr>
                    <td class="ShowContent" align="center">出访日期：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss"  ID="TextBox1"  runat="server"></asp:TextBox>

                    </td>
                    <td class="ShowContent"  align="center">出访时长：
                    </td>
                    <td class="ShowNone" >
                        <asp:TextBox class="TextBoxCss" ID="TextBox13" runat="server"></asp:TextBox>

                    </td>


                </tr>
                <tr>
                    <td class="ShowContent" align="center">出访领队：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox2" runat="server"></asp:TextBox>

                    </td>

                    <td class="ShowContent" align="center">随行人员：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox14" runat="server"></asp:TextBox>

                    </td>

                </tr>
                <tr>
                    <td class="ShowContent" align="center" >出访单位：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox3" runat="server"></asp:TextBox>

                    </td>

                     <td class="ShowContent" align="center" >出访经费：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox15" runat="server"></asp:TextBox>

                    </td>


                </tr>
                <tr>
                    <td class="ShowContent" align="center">关联战略合作协议：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox4" runat="server"></asp:TextBox>

                    </td>
                    <td class="ShowContent" style="word-break : break-all;" align="center">关联合作项目：<br />
                        （包含意向合作项目）
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox16" runat="server"></asp:TextBox>

                    </td>

                </tr>
               
            </table>
            <table style="width: 1000px; margin: 0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
                <tr>
                   
                    <td class="ShowLongContent" align="center">出访目的：
                    </td>
                    <td class="ShowLongNone" align="center">
                        <asp:TextBox class="TextBoxLongCss" ID="TextBox5" runat="server"></asp:TextBox>

                    </td>

                </tr>
                 <tr>
                   
                    <td class="ShowLongContent" align="center">其他说明：
                    </td>
                    <td class="ShowLongNone" align="center">
                        <asp:TextBox class="TextBoxLongCss" ID="TextBox6" runat="server"></asp:TextBox>

                    </td>

                </tr>
            </table>
            <table style="width: 1000px; margin: 0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
                <tr>
                    <td  align="center" class="LittleTiltle"  >审批信息</td>

                </tr>
            </table>

            <table style="width: 1000px; margin: 0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">

                <tr>
                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox7" runat="server"></asp:TextBox>

                    </td>
                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox8" runat="server"></asp:TextBox>

                    </td>

                </tr>
                <tr>
                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center" >
                        <asp:TextBox class="TextBoxCss" ID="TextBox9" runat="server"></asp:TextBox>

                    </td>

                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center" >
                        <asp:TextBox class="TextBoxCss" ID="TextBox19" runat="server"></asp:TextBox>

                    </td>



                </tr>
                <tr>
                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox20" runat="server"></asp:TextBox>

                    </td>

                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox21" runat="server"></asp:TextBox>

                    </td>

                </tr>
                </tr>
            </table>
            <table style="width: 1000px; margin: 0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
                <tr>
                    <td  align="center" class="LittleTiltle"  >出访报告</td>

                </tr>
            </table>
            <table style="width: 1000px; margin: 0px auto;" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1">
                <tr>
                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox10" runat="server"></asp:TextBox>

                    </td>
                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox11" runat="server"></asp:TextBox>

                    </td>

                </tr>
                <tr>
                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center" >
                        <asp:TextBox class="TextBoxCss" ID="TextBox12" runat="server"></asp:TextBox>

                    </td>

                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center" >
                        <asp:TextBox class="TextBoxCss" ID="TextBox22" runat="server"></asp:TextBox>

                    </td>



                </tr>
                <tr>
                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox23" runat="server"></asp:TextBox>

                    </td>

                    <td class="ShowContent" align="center">用户名：
                    </td>
                    <td class="ShowNone" align="center">
                        <asp:TextBox class="TextBoxCss" ID="TextBox24" runat="server"></asp:TextBox>

                    </td>

                </tr>

            </table>
        </div>
    </form>
</body>
</html>

