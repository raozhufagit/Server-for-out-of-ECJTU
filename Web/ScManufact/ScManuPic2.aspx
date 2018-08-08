<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ScManuPic2.aspx.cs" Inherits="ScManufact_ScManuPic2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta http-equiv='content-Type' content='text/html; charset=utf-8'>
    <LINK href="../Style/Style.css" type="text/css" rel="STYLESHEET">
    <script type='text/javascript' src='dhtmlx3/jquery-1.8.2.js'></script>
    <script src='dhtmlx3/dhtmlxGantt/codebase/dhtmlxcommon.js'></script>
    <script type='text/javascript' src='dhtmlx3/dhtmlxToolbar/codebase/dhtmlxtoolbar.js'></script>
    <link rel='stylesheet' type='text/css' href='dhtmlx3/dhtmlxToolbar/codebase/skins/dhtmlxtoolbar_dhx_skyblue.css'> 
    <link rel='STYLESHEET' type='text/css' href='dhtmlx3/dhtmlxGantt/codebase/dhtmlxgantt.css'>
    <script src='dhtmlx3/dhtmlxGantt/codebase/dhtmlxgantt.js'></script>
    <script src='dhtmlx3/dhtmlxGantt/codebase/lang/zh.js'></script>
    <script type='text/javascript' src='../JS/DatePicker/WdatePicker.js'></script>
    <style>
        .left{width:160px; float:left; overflow:hidden}
        .right{width:500px; float:left; overflow:hidden}
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div> 
            <div style="margin-top:2px">
                <div class="left">&nbsp; 
                    <asp:Button ID="Button2" runat="server" Text="返回"  
                        onmouseover="this.className='bbk button small-longg-btn'" 
                        onmouseout="this.className='bbk button small-long-btn'"  
                        class="bbk button small-long-btn" onclick="Button2_Click" />&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="提交审核" 
                        onmouseover="this.className='bbk button small-longg-btn'" 
                        onmouseout="this.className='bbk button small-long-btn'"  
                        class="bbk button small-long-btn" onclick="Button1_Click"/>
                   
                 </div>
                <div class="right" id="toolbarObj"></div>
            </div>
        
            
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
        $("#calendarid").live("click", function () {
            WdatePicker(); //日历选择
        });
        $("body").css("overflow", "hidden");
        $("#GanttDiv").css("width", (document.documentElement.clientWidth - 10) + "px");
        $("#GanttDiv").css("height", (document.documentElement.clientHeight - 50) + "px");

        // Create Gantt control
        var ganttChartControl = new GanttChart();
        // Setup paths and behavior
        ganttChartControl.setImagePath("dhtmlx3/dhtmlxGantt/codebase/imgs/");
        ganttChartControl.setEditable(true);
        ganttChartControl.showTreePanel(true);
        ganttChartControl.showContextMenu(true);
        ganttChartControl.showDescTask(true, 'n,s-f');
        ganttChartControl.showDescProject(true, 'n,s-f');
        ganttChartControl.useShortMonthNames(true);
        ganttChartControl.showNewProject(true);




        //show or hidden code menu items
        //1 or 0
        /*
        1.Task:Rename
        2.Task:Delete
        3.Task:set StartDate
        4.Task:set Duration
        5.Task:set Percent
        6.Task:set PredecessorTask
        7.Task:add SuccessorTask
        8.Task:add childTask
        9.Task:set PlanDuration
        1.Project:Rename
        2.Project:Delete
        3.Project:set Percent
        4.Project:Add Task
        5.Project:Add Project
        6.Project:set PlanDuration
        */
        ganttChartControl.setMenuTaskCode("111111111");
        ganttChartControl.setMenuProjectCode("111111");


        //Task onclick function
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

        var toolbarP = new dhtmlXToolbarObject("toolbarObj");
        toolbarP.setIconsPath("dhtmlx3/dhtmlxToolbar/samples/common/imgs/");
        toolbarP.addText("info", 0, lang.pManager);
        toolbarP.addSeparator("sep0", 1);
        toolbarP.addButton("save", 3, lang.buttonSave, "save.png", "save_dis.png");
        toolbarP.addButton("syn", 4, lang.buttonSync, "syn.png", "sun_dis.png"); // 异步获取
        toolbarP.addButton("per", 6, lang.pPercent, "percent.png", "percent_dis.png");
        toolbarP.addButton("child", 7, lang.pTask, "next.gif", "next_dis.gif");






        toolbarP.attachEvent("onClick", function (id) {
            if (id == "save") {
                ganttChartControl.saveData("<%=jd_pic2() %>");
            }

            if (id == "syn") {
                var h = ((ganttChartControl.arrProjects[0].getFinishDate() - ganttChartControl.Project[0].StartDate) / (24 * 60 * 60 * 1000) + 1) * ganttChartControl.hoursInDay;
                ganttChartControl.loadData("xml/<%=jd_pic2() %>", true, true);
                /*
                $.get
                (
               "xml//
                //{ t: "syn_planH", file: "xml/46a3b8e8a662a798bf15787065f65284.xml", p_planH: h },
                //function (data) {
                //alert(data);
                //if (data == "") {
                //alert("sync ok!");
                //window.location.reload();
               // }
                //}
               // )
                */
            }

            if (!ganttChartControl.selProject) return false;

            if (id == "child") {
                ganttChartControl.contextMenu.arrTabs[9].object = ganttChartControl.selProject;
                ganttChartControl.contextMenu.arrTabs[9].show();
            }
            if (id == "per") {
                ganttChartControl.contextMenu.arrTabs[8].object = ganttChartControl.selProject;
                ganttChartControl.contextMenu.arrTabs[8].show();
            }

        });

        var toolbar = new dhtmlXToolbarObject("toolbarPro");
        toolbar.setIconsPath("dhtmlx3/dhtmlxToolbar/samples/common/imgs/");
        toolbar.addText("info", 0, lang.tManager);
        toolbar.addSeparator("sep0", 5);
        toolbar.addButton("rename", 10, lang.tRename, "debug.gif", "debug_dis.gif");
        toolbar.addButton("delete", 15, lang.tDelete, "delete.png", "delete.png");
        toolbar.addButton("startdate", 20, lang.tStartDate, "time.png", "time_dis.png");
        toolbar.addButton("alarm", 30, lang.tAlarm, "alarm.png", "alarm_dis.png");
        toolbar.addButton("dur", 30, lang.tDuration, "dur.png", "dur_dis.png");
        toolbar.addButton("pre", 40, lang.tPredecessorTask, "pre.gif", "pre_dis.gif");
        toolbar.addButton("next", 45, lang.labAdd + lang.tSuccessorTask, "next.gif", "next_dis.gif");
        toolbar.addButton("child", 50, lang.labAdd + lang.tChildTask, "new.gif", "new_dis.gif");
        toolbar.addButton("planH", 55, lang.tPlanH, "durplan.png", "durplan_dis.png");
        toolbar.addButton("per", 35, lang.tPercent, "percent.png", "percent_dis.png");
        toolbar.addButton("finishdate", 60, lang.tEndDate, "time.png", "time_dis.png");

        toolbar.attachEvent("onClick", function (id) {
            if (id == "back") {
                window.open("project.php", "_self");
            }
            if (!ganttChartControl.selTask) return false;

            if (id == "rename") {
                ganttChartControl.contextMenu.arrTabs[0].object = ganttChartControl.selTask;
                ganttChartControl.contextMenu.arrTabs[0].show();
            }

            if (id == "delete") {
                ganttChartControl.contextMenu.arrTabs[1].object = ganttChartControl.selTask;
                ganttChartControl.contextMenu.arrTabs[1].show();
            }
            if (id == "startdate") {
                ganttChartControl.contextMenu.arrTabs[2].object = ganttChartControl.selTask;
                ganttChartControl.contextMenu.arrTabs[2].show();
            }
            if (id == "finishdate") {
                ganttChartControl.contextMenu.arrTabs[15].object = ganttChartControl.selTask;
                ganttChartControl.contextMenu.arrTabs[15].show();
            }
            if (id == "alarm") {
                ganttChartControl.contextMenu.arrTabs[16].object = ganttChartControl.selTask;
                ganttChartControl.contextMenu.arrTabs[16].show();
            }

            if (id == "dur") {
                ganttChartControl.contextMenu.arrTabs[3].object = ganttChartControl.selTask;
                ganttChartControl.contextMenu.arrTabs[3].show();
            }
            if (id == "per") {
                ganttChartControl.contextMenu.arrTabs[4].object = ganttChartControl.selTask;
                ganttChartControl.contextMenu.arrTabs[4].show();
            }
            if (id == "pre") {
                ganttChartControl.contextMenu.arrTabs[5].object = ganttChartControl.selTask;
                ganttChartControl.contextMenu.arrTabs[5].show();
            }
            if (id == "next") {
                ganttChartControl.contextMenu.arrTabs[10].object = ganttChartControl.selTask;
                ganttChartControl.contextMenu.arrTabs[10].show();
            }
            if (id == "child") {
                ganttChartControl.contextMenu.arrTabs[11].object = ganttChartControl.selTask;
                ganttChartControl.contextMenu.arrTabs[11].show();
            }
            if (id == "planH") {
                ganttChartControl.contextMenu.arrTabs[13].object = ganttChartControl.selTask;
                ganttChartControl.contextMenu.arrTabs[13].show();
            }
        });
    }); 


</script>