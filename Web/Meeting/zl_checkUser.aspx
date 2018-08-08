<%@ Page Language="C#" AutoEventWireup="true" CodeFile="zl_checkUser.aspx.cs" Inherits="Meeting_zl_checkUser" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
    <head>
        <title>值不能为空。<br>参数名: value</title>
        <style>
         body {font-family:"Verdana";font-weight:normal;font-size: .7em;color:black;} 
         p {font-family:"Verdana";font-weight:normal;color:black;margin-top: -5px}
         b {font-family:"Verdana";font-weight:bold;color:black;margin-top: -5px}
         H1 { font-family:"Verdana";font-weight:normal;font-size:18pt;color:red }
         H2 { font-family:"Verdana";font-weight:normal;font-size:14pt;color:maroon }
         pre {font-family:"Lucida Console";font-size: .9em}
         .marker {font-weight: bold; color: black;text-decoration: none;}
         .version {color: gray;}
         .error {margin-bottom: 10px;}
         .expandable { text-decoration:underline; font-weight:bold; color:navy; cursor:hand; }
        </style>
    </head>
 
    <body bgcolor="white">
 
            <span><H1>“/”应用程序中的服务器错误。<hr width=100% size=1 color=silver></H1>
 
            <h2> <i>值不能为空。<br>参数名: value</i> </h2></span>
 
            <font face="Arial, Helvetica, Geneva, SunSans-Regular, sans-serif ">
 
            <b> 说明: </b>执行当前 Web 请求期间，出现未处理的异常。请检查堆栈跟踪信息，以了解有关该错误以及代码中导致错误的出处的详细信息。
 
            <br><br>
 
            <b> 异常详细信息: </b>System.ArgumentNullException: 值不能为空。<br>参数名: value<br><br>
 
            <b>源错误:</b> <br><br>
 
            <table width=100% bgcolor="#ffffcc">
               <tr>
                  <td>
                      <code>
 
执行当前 Web 请求期间生成了未处理的异常。可以使用下面的异常堆栈跟踪信息确定有关异常原因和发生位置的信息。</code>
 
                  </td>
               </tr>
            </table>
 
            <br>
 
            <b>堆栈跟踪:</b> <br><br>
 
            <table width=100% bgcolor="#ffffcc">
               <tr>
                  <td>
                      <code><pre>
 
[ArgumentNullException: 值不能为空。
参数名: value]
   System.Globalization.CompareInfo.IndexOf(String source, String value, Int32 startIndex, Int32 count, CompareOptions options) +7533685
   System.Globalization.CompareInfo.IndexOf(String source, String value) +34
   System.String.IndexOf(String value) +54
   Meeting_zl_checkUser.Page_Load(Object sender, EventArgs e) +154
   System.Web.Util.CalliHelper.EventArgFunctionCaller(IntPtr fp, Object o, Object t, EventArgs e) +14
   System.Web.Util.CalliEventHandlerDelegateProxy.Callback(Object sender, EventArgs e) +35
   System.Web.UI.Control.OnLoad(EventArgs e) +99
   System.Web.UI.Control.LoadRecursive() +50
   System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint) +627
</pre></code>
 
                  </td>
               </tr>
            </table>
 
            <br>
 
            <hr width=100% size=1 color=silver>
 
            <b>版本信息:</b>&nbsp;Microsoft .NET Framework 版本:2.0.50727.3634; ASP.NET 版本:2.0.50727.3634
 
            </font>
 
    </body>
</html>
<!-- 
[ArgumentNullException]: 值不能为空。
参数名: value
   在 System.Globalization.CompareInfo.IndexOf(String source, String value, Int32 startIndex, Int32 count, CompareOptions options)
   在 System.Globalization.CompareInfo.IndexOf(String source, String value)
   在 System.String.IndexOf(String value)
   在 Meeting_zl_checkUser.Page_Load(Object sender, EventArgs e)
   在 System.Web.Util.CalliHelper.EventArgFunctionCaller(IntPtr fp, Object o, Object t, EventArgs e)
   在 System.Web.Util.CalliEventHandlerDelegateProxy.Callback(Object sender, EventArgs e)
   在 System.Web.UI.Control.OnLoad(EventArgs e)
   在 System.Web.UI.Control.LoadRecursive()
   在 System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint)
[HttpUnhandledException]: 引发类型为“System.Web.HttpUnhandledException”的异常。
   在 System.Web.UI.Page.HandleError(Exception e)
   在 System.Web.UI.Page.ProcessRequestMain(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint)
   在 System.Web.UI.Page.ProcessRequest(Boolean includeStagesBeforeAsyncPoint, Boolean includeStagesAfterAsyncPoint)
   在 System.Web.UI.Page.ProcessRequest()
   在 System.Web.UI.Page.ProcessRequestWithNoAssert(HttpContext context)
   在 System.Web.UI.Page.ProcessRequest(HttpContext context)
   在 ASP.meeting_zl_checkuser_aspx.ProcessRequest(HttpContext context) 位置 c:\WINDOWS\Microsoft.NET\Framework\v2.0.50727\Temporary ASP.NET Files\root\de4a7e66\b6440362\App_Web_wzxglrgw.5.cs:行号 0
   在 System.Web.HttpApplication.CallHandlerExecutionStep.System.Web.HttpApplication.IExecutionStep.Execute()
   在 System.Web.HttpApplication.ExecuteStep(IExecutionStep step, Boolean& completedSynchronously)
--><!-- 
此错误页可能包含敏感信息，因为 ASP.NET 通过 &lt;customErrors mode="Off"/&gt; 被配置为显示详细错误消息。请考虑在生产环境中使用 &lt;customErrors mode="On"/&gt; 或 &lt;customErrors mode="RemoteOnly"/&gt;。-->


