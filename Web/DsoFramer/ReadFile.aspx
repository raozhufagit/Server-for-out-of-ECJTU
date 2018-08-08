<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ReadFile.aspx.cs" Inherits="DsoFramer_ReadFile" %>
<html>
	<head>
		<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
  <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">  
  
        <meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
		
    <SCRIPT language="javascript" event="NotifyCtrlReady" for="FramerControl1">		
        function OpenHelpDoc()
        {
            document.all.FramerControl1.Open("../UploadFile/<%=Request.QueryString["FilePath"].ToString() %>", true);
        }
        OpenHelpDoc();        
    </SCRIPT>
		<script language="javascript">
		var documentopenflag=0;
        function NewDoc(filetype){
        if (filetype=='xls')
        document.all.FramerControl1.CreateNew("Excel.Sheet");
        if (filetype=='doc')
        document.all.FramerControl1.CreateNew("Word.Document");
        if (filetype=='ppt')
        document.all.FramerControl1.CreateNew("PowerPoint.Show");
        }
        function OpenDoc(){        
                document.all.FramerControl1.showdialog(1);
        }
        function OpenWebDoc(filetype){
            if (filetype=='doc')
            document.all.FramerControl1.Open("../UploadFile/633520231204062500.doc", true);//docģ��
            if (filetype=='xls')
            document.all.FramerControl1.Open("../UploadFile/633520231204062500.doc", true);//xlsģ��
        }
        function SaveToLocal(){
        alert('�������������Ե�c:\\mydoc.doc')
            document.all.FramerControl1.Save("c:\\mydoc.doc",true);
        }
        function SaveToWeb(){
            document.all.FramerControl1.HttpInit();
            
            document.all.FramerControl1.HttpAddPostString("RecordID","200601022");
            document.all.FramerControl1.HttpAddPostString("UserID","��ֳ�");
            document.all.FramerControl1.HttpAddPostCurrFile("FileData", "<%=Request.QueryString["FilePath"].ToString() %>");
            
            //alert(window.location.host);
            document.all.FramerControl1.HttpPost("http://"+window.location.host+"<%=System.Configuration.ConfigurationManager.AppSettings["OARoot"] %>/DsoFramer/SaveDoc.aspx?FilePath=<%=Request.QueryString["FilePath"].ToString() %>"); 
            alert("���ļ����޸��Ѿ�����ɹ���");
            window.close();       
        
        }
        function Track(){
            document.all.FramerControl1.SetCurrUserName("<%=LCX.Common.PublicMethod.GetSessionValue("UserName")%>");
            document.all.FramerControl1.SetTrackRevisions(1);
        }
        function UnTrack(){
            document.all.FramerControl1.SetTrackRevisions(0);            
        }
        function ShowTrack(){
            document.all.FramerControl1.ShowRevisions(1);            
        }
        function UnShowTrack(){
            document.all.FramerControl1.ShowRevisions(0);           
        }
        function print(){
            document.all.FramerControl1.PrintOut();           
         }
         function printview(){        
            document.all.FramerControl1.PrintPreview();           
         }
         function printviewexit(){        
            document.all.FramerControl1.PrintPreviewExit();           
         }
        function fileclose(){
          document.all.FramerControl1.Close();
        }
		</script>
</head>
<body>
    <form id="form1" runat="server" method="post" encType="multipart/form-data" >
    <div>    
     <table id="PrintHide" style="width: 100%" border="0" cellpadding="0" cellspacing="0">            
            <tr>
                <td valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">&nbsp;<img src="../images/BanKuaiJianTou.gif" />
                <a class="hei" href="../Main/MyDesk.aspx">����</a>&nbsp;>>&nbsp;�ļ������Ķ�</td>
                <td align="right" valign="middle" style="border-bottom: #006633 1px dashed; height: 30px;">
                    <asp:HyperLink ID="HyperLink2" runat="server" Font-Bold="False" Font-Underline="True"
                        ForeColor="Blue" NavigateUrl="../SetupFile/����OfficeDSO���.rar" Target="_blank">[�����Ķ���������ز������ѹ�󣬵��Reg.batע�ᣡ]</asp:HyperLink>
                    &nbsp;&nbsp; �����ļ����Ҽ�����Ϊ����<asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="True"
                        Font-Underline="True" ForeColor="Blue">[HyperLink1]</asp:HyperLink>&nbsp;&nbsp;<input  onclick="ShowTrack()" size="20" style="width: 85px" type="button"
                                value="��ʾ�ۼ�" />
                            <input  onclick="UnShowTrack()" size="20" style="width: 80px" type="button"
                                value="���غۼ�" />
                    &nbsp;&nbsp;</td>
            </tr>
            <tr>
            <td height="3px" colspan="2" style="background-color: #ffffff"></td>
        </tr>
        </table>
    <table style="width: 100%" bgcolor="#999999" border="0" cellpadding="2" cellspacing="1" height="100%">            
        <tr>
            <td style="padding-left: 5px; height: 25px; background-color: #ffffff">
                <object id="FramerControl1" classid="clsid:00460182-9E5E-11D5-B7C8-B8269041DD57"
                    codebase="dsoframer.ocx" height="95%" width="100%">
                    <param name="_ExtentX" value="16960">
                    <param name="_ExtentY" value="13600">
                    <param name="BorderColor" value="-2147483632">
                    <param name="BackColor" value="-2147483643">
                    <param name="ForeColor" value="-2147483640">
                    <param name="TitlebarColor" value="-2147483635">
                    <param name="TitlebarTextColor" value="-2147483634">
                    <param name="BorderStyle" value="1">
                    <param name="Titlebar" value="0">
                    <param name="Toolbars" value="1">
                    <param name="Menubar" value="1">
                </object>
                </td>
        </tr>
        </table></div>
    </form>
</body>
</html>