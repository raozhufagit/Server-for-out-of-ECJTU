<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dept_select.aspx.cs" Inherits="Main_dept_select" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>选择部门</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<link rel="stylesheet" type="text/css" href="/anywhere/theme/13/org_select.css" />

<link rel="stylesheet" href="/JS/ztree/css/zTreeStyle/zTreeStyle.css" type="text/css">
<script type="text/javascript" src="/JS/ztree/js/jquery-1.4.4.min.js"></script>
<script type="text/javascript" src="/JS/ztree/js/jquery.ztree.core-3.5.js"></script>
<script type="text/javascript" src="/JS/ztree/js/jquery.ztree.excheck-3.5.js"></script>
<script language="javascript" src="/anywhere/inc/js/module.js"></script>

<SCRIPT type="text/javascript">	
	var parent_window = jQuery.browser.msie ? parent.dialogArguments.document : parent.opener.document;
	var to_id_field = parent_window.form1.<%=Request.QueryString["TO_ID"]%>;
	var to_name_field = parent_window.form1.<%=Request.QueryString["TO_NAME"]%>;
	
		if(getQueryString("M") ==0){
		   single_select=true;
		}	
		var setting = {			
			view: {selectedMulti: false},
			check: {enable: true,autoCheckTrigger: false},
			async: {
				enable: true,
				url:"/Main/dtpUser.aspx",
				autoParam:["id", "name"], //标准参数
				otherParam:{"t":"0"},
				dataFilter: filter
			},
			callback: {
			    onCheck :onCheck,
				//beforeCheck: beforeCheck,  //在点击checkbox时事件
				//beforeClick: beforeClick,  //在点击标题时
				beforeAsync: beforeAsync,  //在异步加载时
				onAsyncError: onAsyncError, //异步加载发生错误时
				onAsyncSuccess: onAsyncSuccess //异步加载成功时
			}
		};
        //过滤
		function filter(treeId, parentNode, childNodes) {
			var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
			if (!childNodes) return null;
			for (var i=0, l=childNodes.length; i<l; i++) {
				childNodes[i].name = childNodes[i].name.replace(/\.n/g, '.');
				//初始化列表时选中值
				if((to_id_field.value+",").indexOf(childNodes[i].id+",") != -1){
				  treeObj.checkNode(childNodes[i], true, true); //选中
				}
				
			}
			return childNodes;
		}
		//点击checkbox时发生
		function onCheck(event, treeId, treeNode) { 
				var treeObj = $.fn.zTree.getZTreeObj("treeDemo");				
				if(treeNode.checked){
					if(single_select){
						//clear_item();
						//treeObj.checkAllNodes(false);				
						//treeObj.checkNode(treeNode, false, true);
						add_item(treeNode.id, treeNode.name);
					}else{
						add_item(treeNode.id, treeNode.name); //checkbox选中执行
					}
				}else{
					remove_item(treeNode.id, treeNode.name);  //此次操作为取消操作
				}	
		}
		
		//在勾选check之前发生
		function beforeCheck(treeId, treeNode) {		    
			if(treeNode.checked){
				remove_item(treeNode.id, treeNode.name);  //此次操作为取消操作
			}else{
				add_item(treeNode.id, treeNode.name); //checkbox选中执行
			}	 
		}
		
		function beforeClick(treeId, treeNode) {		    
			var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
			if (!treeNode.isParent) {
			    treeObj.checkNode(treeNode, true, true) //自动选中当前节点  alert("请选择父节点");
				return false;
			} else {
				return true;
			}
			 add_item(this.getAttribute("item_id"), this.getAttribute("item_name"));
		}
		
		var log, className = "dark";
		function beforeAsync(treeId, treeNode) {
			className = (className === "dark" ? "":"dark");			
			return true;
		}
		
		function onAsyncError(event, treeId, treeNode, XMLHttpRequest, textStatus, errorThrown) {}
		//TREE加载完成时
		function onAsyncSuccess(event, treeId, treeNode, msg) {
			var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
			var nodes = treeObj.getNodes();			
			 for (var i=0, l=nodes.length; i<l; i++) {
				if((nodes[i].name.indexOf("浙江环00日")) != -1){				
				 treeObj.checkNode(nodes[i], true, true);
				}else{
				 // alert(nodes[i].name);
				}
			}			
		}
				
		$(document).ready(function(){
			$.fn.zTree.init($("#treeDemo"), setting);
			var zTree = $.fn.zTree.getZTreeObj("treeDemo"),	
			py = 0? "p":"",//父关联
			sy = 0? "s":"", //关联子
			pn = 0? "p":"", //关联父
			sn = 0? "s":"", //关联子
			type = { "Y":py + sy, "N":pn + sn};
			zTree.setting.check.chkboxType = type;   //配置是否递级选择
		});
			
	</SCRIPT>
</head>
<body> 
<form id="form1" runat="server">
<div class="main-block" id="block_dept" style="display:block;top:0px;">
   <div class="right single" id="dept_item">
		<div class="block-right" id="dept_item_0">			
				<ul id="treeDemo" class="ztree"></ul>
		</div>   
</div>
</div>
<div id="south">
   <input type="button" class="BigButtonA" value="确定" onclick="close_window();">&nbsp;&nbsp;
   <input type="button" class="BigButtonA" value="清除" onclick="clear_item();">&nbsp;&nbsp;
</div>
</form>
</body>
</html>

