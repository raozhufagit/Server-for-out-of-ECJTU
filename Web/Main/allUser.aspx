<%@ Page Language="C#" AutoEventWireup="true" CodeFile="allUser.aspx.cs" Inherits="Main_allUser" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
</head>
<body>
    <form id="form1" runat="server">
        <asp:TreeView ID="ListTreeView" runat="server" ExpandDepth="0" ForeColor="Black"
            ShowLines="True">
            <ParentNodeStyle HorizontalPadding="2px" />
            <RootNodeStyle HorizontalPadding="2px" />
            <LeafNodeStyle HorizontalPadding="2px" />
            <Nodes>    
            </Nodes>
        </asp:TreeView>
    </form>
</body>
</html>