<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NWorkToDo.aspx.cs" Inherits="NWorkFlow_NWorkToDo" %>
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
</head>
<SCRIPT LANGUAGE="JavaScript">
		  		  var a;    
          function CheckValuePiece(){
           if(document.getElementById("form1").GoPage.value == "")
            {
              alert("请输入跳转的页码！");
              document.getElementById("form1").GoPage.focus();
              return false; 
            }
           return true;
           }
           function CheckAll(){            
            if(a==1)
            {
            for(var i=0;i<document.getElementById("form1").elements.length;i++)
               {                
                  var e = form1.elements[i];
                  e.checked =false;                  
               }
               a=0;
           }       
           else
           {
                for(var i=0;i<document.getElementById("form1").elements.length;i++)
               {                
                  var e = form1.elements[i];
                  e.checked =true;                  
               }
               a=1;
           }     
         }
           function CheckDel(){
             var number=0;
             for(var i=0;i<document.getElementById("form1").elements.length;i++)
               {
                  var e = form1.elements[i];
                  if (e.Name != "CheckBoxAll")
                  {
                    if(e.checked==true)
                    {
                        number=number+1;
                    }
                  }
               }
               if(number==0)
                {
                  alert("请选择需要删除的项！");
                  return false;
                }
               if (window.confirm("你确认删除吗？"))
				{
				  return true;
				}
				else
				{
				  return false;
				}
             } 
             
             function CheckModify(){
             var Modifynumber=0;
             for(var i=0;i<document.getElementById("form1").elements.length;i++)
               {
                  var e = form1.elements[i];
                  if (e.Name != "CheckBoxAll")
                  {
                    if(e.checked==true)
                    {
                        Modifynumber=Modifynumber+1;
                    }
                  }
               }
               if(Modifynumber==0)
                {
                  alert("请至少选择一项！");
                  return false;
                }
                if(Modifynumber>1)
                {
                  alert("只允许选择一项！");
                  return false;
                }
               
				  return true;							
             }
             
             
             
		</SCRIPT>  
<body>
    <form id="form1" runat="server">
    <div>    
     <table style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px; ">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">桌面</a>&nbsp;>>&nbsp;工作管理&nbsp;>>&nbsp;我的工作
                </td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
					查询：<asp:DropDownList ID="DropDownList2" runat="server">
					<asp:ListItem Value="WorkName">工作名称</asp:ListItem>					
					<asp:ListItem Value="JieDianName">当前节点名称</asp:ListItem>
					<asp:ListItem Value="ShenPiUserList">当前审批用户</asp:ListItem>
					<asp:ListItem Value="OKUserList">当前已审批用户</asp:ListItem>
					<asp:ListItem Value="StateNow">当前状态</asp:ListItem>
					</asp:DropDownList><asp:TextBox ID="TextBox3" runat="server" Width="80px"></asp:TextBox><img class="HerCss"
					onclick="var wName;var RadNum=Math.random();wName=window.showModalDialog('../Main/SelectCondition.aspx?TableName=LCX_WorkToDo&LieName='+document.getElementById('DropDownList2').value+'&Radstr='+RadNum,'','dialogWidth:350px;DialogHeight=400px;status:no;help:no;resizable:yes;');if(wName==null){}else{document.getElementById('TextBox3').value=wName;}"
					src="../images/Button/search.gif" /><asp:ImageButton ID="ImageButton4" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/BtnSerch.jpg"
					OnClick="ImageButton4_Click" /><asp:ImageButton ID="ImageButton6" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/ResultSerch.jpg" OnClick="ImageButton6_Click" />&nbsp; &nbsp;<asp:ImageButton ID="ImageButton3" runat="server" ImageAlign="AbsMiddle" ImageUrl="../images/Button/BtnDel.jpg"
                        OnClick="ImageButton3_Click" OnClientClick="javascript:return CheckDel();" />
                    &nbsp;&nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="../images/Button/BtnReport.jpg" ImageAlign="AbsMiddle" OnClick="ImageButton2_Click" />&nbsp;&nbsp;</td>
            </tr>
        </table>
        
    </div>
        <table style="width: 100%">
            <tr>
            <td ><asp:GridView ID="GVData" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False"
                    BackColor="#DDDDDD" BorderStyle="None" BorderWidth="1px" CellPadding="5"  CellSpacing="1"
        GridLines="None" style="line-height:22px;"  OnRowDataBound="GVData_RowDataBound" PageSize="15"
                    Width="100%">
                    <RowStyle BackColor="#ffffff" ForeColor="Black"  HorizontalAlign="Center" />
                    <PagerSettings Mode="NumericFirstLast" Visible="False" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:Label ID="LabVisible" runat="server" Text='<%#DataBinder.Eval(Container.DataItem, "ID")%>'
                                    Visible="False"></asp:Label><asp:CheckBox ID="CheckSelect" runat="server" />
                            </ItemTemplate>
                            <HeaderStyle Width="20px" />
                            <HeaderTemplate>
                                <input id="CheckBoxAll" onclick="CheckAll()"  type="checkbox" />
                            </HeaderTemplate>
                        </asp:TemplateField>
					<asp:TemplateField HeaderText="工作名称"> <ItemTemplate> <asp:HyperLink ID="HyperLink1" runat="server" Font-Underline="True" NavigateUrl='<%# "NWorkToDoView.aspx?ID="+ DataBinder.Eval(Container.DataItem, "ID")%>'><%# DataBinder.Eval(Container.DataItem, "WorkName")%></asp:HyperLink> </ItemTemplate>   <ItemStyle HorizontalAlign="Left" />  </asp:TemplateField> 
					
					
					<asp:BoundField DataField="TimeStr" HeaderText="发起时间" ></asp:BoundField> 
					<asp:TemplateField HeaderText="节点名称">
                            <ItemTemplate>                                
                            <%# LCX.DBUtility.DbHelperSQL.GetSHSL("select top 1 WorkFlowName from LCX_WorkFlow where ID=" + DataBinder.Eval(Container.DataItem, "WorkFlowID").ToString())%>--[<asp:HyperLink ID="HyperLink11" runat="server" Font-Underline="True" Target="_blank" NavigateUrl='<%# "NWorkFlowReView.aspx?WorkFlowID="+ DataBinder.Eval(Container.DataItem, "WorkFlowID")+"&FormID="+ DataBinder.Eval(Container.DataItem, "FormID") %>' ForeColor="Blue" ToolTip="点击查看流程图示"><%# DataBinder.Eval(Container.DataItem, "JieDianName")%></asp:HyperLink>]
                            </ItemTemplate>                            
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
					
					<asp:BoundField DataField="ShenPiUserList" HeaderText="审批用户" ></asp:BoundField>     
					<asp:BoundField DataField="OKUserList" HeaderText="已审批用户" ></asp:BoundField>     					
					<asp:BoundField DataField="LateTime" HeaderText="超时时间" ></asp:BoundField>     
					<asp:BoundField DataField="StateNow" HeaderText="当前状态" ></asp:BoundField>     
</Columns>
                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                     <PagerStyle BackColor="#ffffff"  HorizontalAlign="left" />
                     <HeaderStyle BackColor="#efefef" Font-Bold="True" Font-Size="14px" />
                     <AlternatingRowStyle BackColor="#f7fafe" />
                <EmptyDataTemplate>
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td align="center" style="border-right: black 1px; border-top: black 1px;
                                border-left: black 1px; border-bottom: black 1px; background-color: whitesmoke;">
                                该列表中暂时无数据！</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                </asp:GridView>
                </td>
        </tr>
        <tr>
            <td style="border-top: #000000 1px solid;border-bottom: #000000 1px solid">
                <asp:ImageButton ID="BtnFirst" runat="server" CommandName="First" ImageUrl="../images/Button/First.jpg"
                    OnClick="PagerButtonClick" />
                <asp:ImageButton ID="BtnPre" runat="server" CommandName="Pre" ImageUrl="../images/Button/Pre.jpg"
                    OnClick="PagerButtonClick" />
                <asp:ImageButton ID="BtnNext" runat="server" CommandName="Next" ImageUrl="../images/Button/Next.jpg"
                    OnClick="PagerButtonClick" />
                <asp:ImageButton ID="BtnLast" runat="server" CommandName="Last" ImageUrl="../images/Button/Last.jpg"
                    OnClick="PagerButtonClick" />
                &nbsp;第<asp:Label ID="LabCurrentPage" runat="server" Text="Label"></asp:Label>页&nbsp; 共<asp:Label
                    ID="LabPageSum" runat="server" Text="Label"></asp:Label>页&nbsp;
                <asp:TextBox ID="TxtPageSize" runat="server" CssClass="TextBoxCssUnder2" Height="20px"
                    Width="35px">15</asp:TextBox>
                行每页 &nbsp; 转到第<asp:TextBox ID="GoPage" runat="server" CssClass="TextBoxCssUnder2"
                    Height="20px" Width="33px"></asp:TextBox>
                页&nbsp;
                <asp:ImageButton ID="ButtonGo" runat="server" OnClientClick="javascript:return CheckValuePiece();"  ImageUrl="../images/Button/Jump.jpg" OnClick="ButtonGo_Click" />
                <span style="color: darkgray">*只能删除状态为"已被驳回"的工作，删除其他请联系管理员。</span></td>
        </tr>
        </table>
    </form>
</body>
</html>
