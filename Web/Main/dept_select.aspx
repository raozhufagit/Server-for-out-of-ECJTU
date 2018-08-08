<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dept_select.aspx.cs" Inherits="Main_dept_select" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>ѡ����</title>
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
				autoParam:["id", "name"], //��׼����
				otherParam:{"t":"0"},
				dataFilter: filter
			},
			callback: {
			    onCheck :onCheck,
				//beforeCheck: beforeCheck,  //�ڵ��checkboxʱ�¼�
				//beforeClick: beforeClick,  //�ڵ������ʱ
				beforeAsync: beforeAsync,  //���첽����ʱ
				onAsyncError: onAsyncError, //�첽���ط�������ʱ
				onAsyncSuccess: onAsyncSuccess //�첽���سɹ�ʱ
			}
		};
        //����
		function filter(treeId, parentNode, childNodes) {
			var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
			if (!childNodes) return null;
			for (var i=0, l=childNodes.length; i<l; i++) {
				childNodes[i].name = childNodes[i].name.replace(/\.n/g, '.');
				//��ʼ���б�ʱѡ��ֵ
				if((to_id_field.value+",").indexOf(childNodes[i].id+",") != -1){
				  treeObj.checkNode(childNodes[i], true, true); //ѡ��
				}
				
			}
			return childNodes;
		}
		//���checkboxʱ����
		function onCheck(event, treeId, treeNode) { 
				var treeObj = $.fn.zTree.getZTreeObj("treeDemo");				
				if(treeNode.checked){
					if(single_select){
						//clear_item();
						//treeObj.checkAllNodes(false);				
						//treeObj.checkNode(treeNode, false, true);
						add_item(treeNode.id, treeNode.name);
					}else{
						add_item(treeNode.id, treeNode.name); //checkboxѡ��ִ��
					}
				}else{
					remove_item(treeNode.id, treeNode.name);  //�˴β���Ϊȡ������
				}	
		}
		
		//�ڹ�ѡcheck֮ǰ����
		function beforeCheck(treeId, treeNode) {		    
			if(treeNode.checked){
				remove_item(treeNode.id, treeNode.name);  //�˴β���Ϊȡ������
			}else{
				add_item(treeNode.id, treeNode.name); //checkboxѡ��ִ��
			}	 
		}
		
		function beforeClick(treeId, treeNode) {		    
			var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
			if (!treeNode.isParent) {
			    treeObj.checkNode(treeNode, true, true) //�Զ�ѡ�е�ǰ�ڵ�  alert("��ѡ�񸸽ڵ�");
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
		//TREE�������ʱ
		function onAsyncSuccess(event, treeId, treeNode, msg) {
			var treeObj = $.fn.zTree.getZTreeObj("treeDemo");
			var nodes = treeObj.getNodes();			
			 for (var i=0, l=nodes.length; i<l; i++) {
				if((nodes[i].name.indexOf("�㽭��00��")) != -1){				
				 treeObj.checkNode(nodes[i], true, true);
				}else{
				 // alert(nodes[i].name);
				}
			}			
		}
				
		$(document).ready(function(){
			$.fn.zTree.init($("#treeDemo"), setting);
			var zTree = $.fn.zTree.getZTreeObj("treeDemo"),	
			py = 0? "p":"",//������
			sy = 0? "s":"", //������
			pn = 0? "p":"", //������
			sn = 0? "s":"", //������
			type = { "Y":py + sy, "N":pn + sn};
			zTree.setting.check.chkboxType = type;   //�����Ƿ�ݼ�ѡ��
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
   <input type="button" class="BigButtonA" value="ȷ��" onclick="close_window();">&nbsp;&nbsp;
   <input type="button" class="BigButtonA" value="���" onclick="clear_item();">&nbsp;&nbsp;
</div>
</form>
</body>
</html>

