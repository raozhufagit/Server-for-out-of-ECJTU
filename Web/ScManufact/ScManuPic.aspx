<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScManuPic.aspx.cs" Inherits="ScManufact_ScManuPic" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <meta http-equiv='content-Type' content='text/html; charset=gb2312'>
<script type='text/javascript' src='dhtmlx3/jquery-1.8.2.js'></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <script src='dhtmlx3/dhtmlxGantt/codebase/dhtmlxcommon.js'></script>
        <script type='text/javascript' src='dhtmlx3/dhtmlxToolbar/codebase/dhtmlxtoolbar.js'></script>
        <link rel='stylesheet' type='text/css' href='dhtmlx3/dhtmlxToolbar/codebase/skins/dhtmlxtoolbar_dhx_skyblue.css'></link>
        <link rel='STYLESHEET' type='text/css' href='dhtmlx3/dhtmlxGantt/codebase/dhtmlxgantt.css'>
        <script src='dhtmlx3/dhtmlxGantt/codebase/dhtmlxgantt.js'></script>
        <script src='dhtmlx3/dhtmlxGantt/codebase/lang/zh.js'></script>
        <script type="text/javascript" language="javascript" src="../JS/calendar.js"></script>
<div>

<div id="toolbarPro"></div>
<div id="toolbarTask"></div>
</div>
<div style="position:relative" id="GanttDiv"></div>


    </div>
    </form>
</body>
</html>
<script type="text/javascript" language="JavaScript">
    $(document).ready(function () {

        $("body").css("overflow", "hidden");
        $("#GanttDiv").css("width", (document.documentElement.clientWidth - 0) + "px");
        $("#GanttDiv").css("height", (document.documentElement.clientHeight - 30) + "px");

        // Create Gantt control
        var ganttChartControl = new GanttChart();
        // Setup paths and behavior
        ganttChartControl.setImagePath("dhtmlx3/dhtmlxGantt/codebase/imgs/");
        ganttChartControl.setEditable(false);
        ganttChartControl.showTreePanel(true);
        ganttChartControl.showContextMenu(false);
        ganttChartControl.showDescTask(true, 'n,s-f');
        ganttChartControl.showDescProject(true, 'n,s-f');
        ganttChartControl.useShortMonthNames(true);
        ganttChartControl.showNewProject(false);


        ganttChartControl.setMenuTaskCode("111111111");
        ganttChartControl.setMenuProjectCode("111111");
        ganttChartControl.setSelHandler(sel_fn);
        var sel_fn = function () {
            alert(ganttChartControl.selTask.TaskInfo.Id);
        };

        ganttChartControl.setSavePath("saveXML.aspx");
        // Build control on the page
        ganttChartControl.create("GanttDiv");
        ganttChartControl.loadData("xml/<%=jd_pic2() %>", true, true);
        //toggleAllTask
        for (var i = 0; i < ganttChartControl.arrProjects.length; i++) {
            ganttChartControl.arrProjects[i].toggleAllTask();
        }

        var lang = ganttChartControl.ChartLang;
        var toolbar = new dhtmlXToolbarObject("toolbarPro");
        toolbar.setIconsPath("dhtmlx3/dhtmlxToolbar/samples/common/imgs/");
        
        
        toolbar.addButton("rename", 0, "返回进度列表", "debug.gif", "debug_dis.gif");
        toolbar.addSeparator("sep0", 5);
        toolbar.addText("infos", 12, "[蓝色]表示现在进度状态 [绿色]表示提前完成 [红色]表示已经延期");
        toolbar.attachEvent("onClick", function (id) {
            if (id == "rename") {
                history.go(-1);
            }
        });
    }); 


</script>