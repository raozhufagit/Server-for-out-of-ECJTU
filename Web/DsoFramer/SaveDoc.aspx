﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SaveDoc.aspx.cs" Inherits="DsoFramer_SaveDoc" %>
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
</head>
<body>
    <form id="Form1" method="post" runat="server" encType="multipart/form-data">
        <%--<input type=text name="FilePath" value=<%=Request.QueryString["FilePath"].ToString()%>>--%>
    </form>
</body>
</html>