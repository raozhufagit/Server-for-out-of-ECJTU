<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr_select.aspx.cs" Inherits="Main_usr_select" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>选择人员</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<link rel="stylesheet" type="text/css" href="/anywhere/theme/13/org_select.css" />
</head>
<style>
   html{_padding-top:30px;}
</style>
<script src="/anywhere/inc/js/ispirit.js"></script>
<link rel="stylesheet" href="/JS/ztree/css/zTreeStyle/zTreeStyle.css" type="text/css">
<script type="text/javascript" src="/JS/ztree/js/jquery-1.4.4.min.js"></script>
<script type="text/javascript" src="/JS/ztree/js/jquery.ztree.core-3.5.js"></script>
<script type="text/javascript" src="/JS/ztree/js/jquery.ztree.excheck-3.5.js"></script>
<script language="javascript" src="/anywhere/inc/js/module.js"></script>

<script Language="JavaScript">
    var  query_string ="BB=1";
    var parent_window = jQuery.browser.msie ? parent.dialogArguments.document : parent.opener.document;
    var to_id_field = parent_window.form1.<%=Request.QueryString["TO_ID"]%>;
	var to_name_field = parent_window.form1.<%=Request.QueryString["TO_NAME"]%>; 
    if(getQueryString("M") ==0){  //判断是否为多选
		   single_select=true;
	}	
  
    var action_children_prefix = "children_";

    //jQuery.noConflict();

    var setting = {
        view: { selectedMulti: false },
        check: { enable: true, autoCheckTrigger: false },
        async: {
            enable: true,
            url: "/Main/dtpUser.aspx",
            autoParam: ["id", "name"], //标准参数
            otherParam: { "t": "0" }//,
           // dataFilter: filter
        },
        callback: {
            onCheck: onCheck,
                //beforeCheck: beforeCheck,  //在点击checkbox时事件
             beforeClick: beforeClick,  //在点击标题时
            //beforeAsync: beforeAsync,  //在异步加载时
            //onAsyncError: onAsyncError, //异步加载发生错误时
            //onAsyncSuccess: onAsyncSuccess //异步加载成功时
        }
    };
    function onCheck(event, treeId, treeNode) {         
            nodes_click(treeNode);
	}
    
    function beforeClick(treeId, treeNode) {         
            node_click(treeNode);
	}

    (function ($) {
        $(document).ready(function ($) {            
            $.fn.zTree.init($("#treeDemo"), setting);     
            load_init();
            initSelected();
            //默认加载部门的人员选中状态
        });
    })(jQuery);
</script>
<body>
 <form id="form1" runat="server">
    <div id="north">
       <div id="navMenu" style="width:auto;">
          <a href="#" title="已选人员" block="selected" hidefocus="hidefocus"><span>已选</span></a>
          <a href="#" title="按部门选择" block="dept" hidefocus="hidefocus" class="active"><span>部门</span></a>
          <a href="#" title="按角色选择" block="priv" hidefocus="hidefocus"><span>角色</span></a>      
          <a href="#" title="从在线人员选择" block="online" hidefocus="hidefocus"><span>在线</span></a>
          <a href="#" block="query" hidefocus="hidefocus" style="display:none;"><span>搜索</span></a>
       </div>
       <div id="navRight" style="float:right;">
          <div class="search">
             <div class="search-body">
                <div class="search-input"><input id="keyword" type="text" value=""></div>
                <div id="search_clear" class="search-clear" style="display:none;"></div>
             </div>
          </div>
       </div>
    </div>
    <div class="main-block" id="block_selected">
       <div class="right single" id="selected_item">
          <div class="block-right" id="selected_item_0">
             <div class="block-right-header" title="已选人员">已选人员</div>
         </div>
       </div>
    </div>
    <div class="main-block" id="block_dept" style="display:block;">
       <div class="left moduleContainer" id="dept_menu">
            <div id="tree">
            <ul id="treeDemo" class="ztree"></ul>
            </div>  
       </div>
        <div class="right" id="dept_item">
            <div class="block-right" id="dept_item_1">
                
            </div>
        </div>
    </div>
    <div class="main-block" id="block_priv">
       <div class="left" id="priv_menu"></div>
       <div class="right" id="bypriv_item"></div>
    </div>
    <div class="main-block" id="block_online">
       <div class="right single" id="online_item"></div>
    </div>
    <div class="main-block" id="block_query">
       <div class="right single" id="query_item"></div>
    </div>
    <div id="south">
       <input type="button" class="BigButtonA" value="确定" onclick="close_window();">&nbsp;&nbsp;
    </div>
</form>
</body>
</html>