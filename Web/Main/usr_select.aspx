<%@ Page Language="C#" AutoEventWireup="true" CodeFile="usr_select.aspx.cs" Inherits="Main_usr_select" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>ѡ����Ա</title>
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
    if(getQueryString("M") ==0){  //�ж��Ƿ�Ϊ��ѡ
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
            autoParam: ["id", "name"], //��׼����
            otherParam: { "t": "0" }//,
           // dataFilter: filter
        },
        callback: {
            onCheck: onCheck,
                //beforeCheck: beforeCheck,  //�ڵ��checkboxʱ�¼�
             beforeClick: beforeClick,  //�ڵ������ʱ
            //beforeAsync: beforeAsync,  //���첽����ʱ
            //onAsyncError: onAsyncError, //�첽���ط�������ʱ
            //onAsyncSuccess: onAsyncSuccess //�첽���سɹ�ʱ
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
            //Ĭ�ϼ��ز��ŵ���Աѡ��״̬
        });
    })(jQuery);
</script>
<body>
 <form id="form1" runat="server">
    <div id="north">
       <div id="navMenu" style="width:auto;">
          <a href="#" title="��ѡ��Ա" block="selected" hidefocus="hidefocus"><span>��ѡ</span></a>
          <a href="#" title="������ѡ��" block="dept" hidefocus="hidefocus" class="active"><span>����</span></a>
          <a href="#" title="����ɫѡ��" block="priv" hidefocus="hidefocus"><span>��ɫ</span></a>      
          <a href="#" title="��������Աѡ��" block="online" hidefocus="hidefocus"><span>����</span></a>
          <a href="#" block="query" hidefocus="hidefocus" style="display:none;"><span>����</span></a>
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
             <div class="block-right-header" title="��ѡ��Ա">��ѡ��Ա</div>
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
       <input type="button" class="BigButtonA" value="ȷ��" onclick="close_window();">&nbsp;&nbsp;
    </div>
</form>
</body>
</html>