<%@ Page Language="C#" AutoEventWireup="true" CodeFile="staff_add.aspx.cs" Inherits="HR_staff_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>人事档案编辑</title>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312">
<link rel="stylesheet" type="text/css" href="/anywhere/theme/13/style.css">

<script language="javascript" src="/anywhere/inc/js/jquery/jquery.min.js"></script>
<script language="javascript" src="/anywhere/inc/js/module.js"></script>

<script src="/JS/DatePicker/WdatePicker.js"></script>

<script type="text/javascript" src="/anywhere/inc/xinzhuo.js"></script>
<script src="../UEditor/ueditor.config.js" type="text/javascript"></script> 
<script src="../UEditor/ueditor.all.js" type="text/javascript"></script>
<link rel="stylesheet" type="text/css" href="../UEditor/themes/default/css/ueditor.css" />

<script type="text/javascript">

 //检查员工编辑是否有重复的
 function check_no(str, user_id) {
        if (str == "")
            return;
        //_get("check_no.php", "STAFF_NO=" + str + "&USER_ID=" + user_id, show_msg);
 }

 //检查身份证号
    function checkIdcard() {
    if (document.form1.STAFF_CARD_NO.value != "") {
         var idcard = document.form1.STAFF_CARD_NO.value;
         var Errors = new Array(
       "身份证号码位数不对！",
       "身份证号码出生日期超出范围或含有非法字符！",
       "身份证号码校验错误！",
       "身份证地区错误，请重新输入！",
       "身份证号码已经存在，请重新输入！");
         var area = { 11: "北京", 12: "天津", 13: "河北", 14: "山西", 15: "内蒙古", 21: "辽宁", 22: "吉林", 23: "黑龙江", 31: "上海", 32: "江苏", 33: "浙江", 34: "安徽", 35: "福建", 36: "江西", 37: "山东", 41: "河南", 42: "湖北", 43: "湖南", 44: "广东", 45: "广西", 46: "海南", 50: "重庆", 51: "四川", 52: "贵州", 53: "云南", 54: "西藏", 61: "陕西", 62: "甘肃", 63: "青海", 64: "宁夏", 65: "新疆", 71: "台湾", 81: "香港", 82: "澳门", 91: "国外" }
         var idcard, Y, JYM;
         var S, M;
         var idcard_array = new Array();
         idcard_array = idcard.split("");
         if (area[parseInt(idcard.substr(0, 2))] == null) {
             alert(Errors[3]);
             //document.form1.STAFF_CARD_NO.focus();
             return (false);
         }

         switch (idcard.length) {
             case 15:
                 if ((parseInt(idcard.substr(6, 2)) + 1900) % 4 == 0 || ((parseInt(idcard.substr(6, 2)) + 1900) % 100 == 0 && (parseInt(idcard.substr(6, 2)) + 1900) % 4 == 0)) {
                     ereg = /^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}$/;
                 }
                 else {
                     ereg = /^[1-9][0-9]{5}[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}$/;
                 }
                 if (!ereg.test(idcard)) {
                     //document.form1.STAFF_CARD_NO.focus();
                     return (false);
                 }
                 else {
                     var birth = (parseInt(idcard.substr(6, 2)) + 1900).toString() + "-" + idcard.substr(8, 2) + "-" + idcard.substr(10, 2);
                     document.form1.STAFF_BIRTH.value = birth;
                     var myDate = new Date();
                     var month = myDate.getMonth() + 1;
                     var day = myDate.getDate();
                     var birth_day = idcard.substr(10, 2);
                     var birth_month = idcard.substr(8, 2);
                     var age = myDate.getYear() - (parseInt(idcard.substr(6, 2)) + 1900);
                     if (birth_month < month || birth_month == month && birth_day <= day) {
                         age++;
                     }
                     document.form1.STAFF_AGE.value = age - 1;
                     var sex = parseInt(idcard.substr(14, 1));
                     if (sex % 2 == 1) //男
                         document.form1.STAFF_SEX.value = "0";
                     else  //女
                         document.form1.STAFF_SEX.value = "1";
                 }
                 break;

             case 18:
                 if (parseInt(idcard.substr(6, 4)) % 4 == 0 || (parseInt(idcard.substr(6, 4)) % 100 == 0 && parseInt(idcard.substr(6, 4)) % 4 == 0)) {
                     ereg = /^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}[0-9Xx]$/; //闰年出生日期的合法性正则表达式
                 }
                 else {
                     ereg = /^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|1[0-9]|2[0-8]))[0-9]{3}[0-9Xx]$/;
                 }

                 if (ereg.test(idcard)) {
                     S = (parseInt(idcard_array[0]) + parseInt(idcard_array[10])) * 7 + (parseInt(idcard_array[1]) + parseInt(idcard_array[11])) * 9 + (parseInt(idcard_array[2]) + parseInt(idcard_array[12])) * 10 + (parseInt(idcard_array[3]) + parseInt(idcard_array[13])) * 5 + (parseInt(idcard_array[4]) + parseInt(idcard_array[14])) * 8 + (parseInt(idcard_array[5]) + parseInt(idcard_array[15])) * 4 + (parseInt(idcard_array[6]) + parseInt(idcard_array[16])) * 2 + parseInt(idcard_array[7]) * 1 + parseInt(idcard_array[8]) * 6 + parseInt(idcard_array[9]) * 3;
                     Y = S % 11;
                     M = "F";
                     JYM = "10X98765432";
                     M = JYM.substr(Y, 1);
                     if (!(M == idcard_array[17])) {
                         alert(Errors[2]);
                         var birth = idcard.substr(6, 4) + "-" + idcard.substr(10, 2) + "-" + idcard.substr(12, 2);
                         document.form1.STAFF_BIRTH.value = birth;
                         var myDate = new Date();
                         var month = myDate.getMonth() + 1;
                         var day = myDate.getDate();
                         var birth_day = idcard.substr(12, 2);
                         var birth_month = idcard.substr(10, 2);
                         var age = myDate.getFullYear() - idcard.substr(6, 4);
                         if (birth_month < month || birth_month == month && birth_day <= day) {
                             age++;
                         }
                         document.form1.STAFF_AGE.value = age - 1;
                         var sex = parseInt(idcard.substr(16, 1));
                         if (sex % 2 == 1) //男
                             document.form1.STAFF_SEX.value = "0";
                         else  //女
                             document.form1.STAFF_SEX.value = "1";
                         /*
                         document.form1.STAFF_CARD_NO.focus();
                         return (false);
                         */
                     }
                     else {
                         var birth = idcard.substr(6, 4) + "-" + idcard.substr(10, 2) + "-" + idcard.substr(12, 2);
                         document.form1.STAFF_BIRTH.value = birth;
                         var myDate = new Date();
                         var month = myDate.getMonth() + 1;
                         var day = myDate.getDate();
                         var birth_day = idcard.substr(12, 2);
                         var birth_month = idcard.substr(10, 2);
                         var age = myDate.getFullYear() - idcard.substr(6, 4);
                         if (birth_month < month || birth_month == month && birth_day <= day) {
                             age++;
                         }
                         document.form1.STAFF_AGE.value = age - 1;
                         var sex = parseInt(idcard.substr(16, 1));
                         if (sex % 2 == 1) //男
                             document.form1.STAFF_SEX.value = "0";
                         else  //女
                             document.form1.STAFF_SEX.value = "1";
                     }
                 }
                 else {
                     alert(Errors[1]);
                     //document.form1.STAFF_CARD_NO.focus();
                     return (false);
                 }
                 break;
             default:
                 alert(Errors[0]);
                 //document.form1.STAFF_CARD_NO.focus();
                 return (false);
                 break;
         }

     
	}
 }

	function checkDate() {
		 var birth = document.form1.STAFF_BIRTH.value;
		 var myDate = new Date();
		 var month = myDate.getMonth() + 1;
		 var day = myDate.getDate();
		 var birth_day = birth.substr(8, 2);
		 var birth_month = birth.substr(5, 2);
		 var age = myDate.getFullYear() - birth.substr(0, 4);
		 if (birth_month < month || birth_month == month && birth_day <= day) {
			 age++;
		 }
		 document.form1.STAFF_AGE.value = age - 1;
	}
	function get_animal_sign() {
		 var STAFF_BIRTH = document.getElementById("STAFF_BIRTH").value;
		 if (STAFF_BIRTH != "" && STAFF_BIRTH != "0000-00-00") {

			 document.getElementById("animal_id").value = getshengxiao(STAFF_BIRTH.split("-")[0]);
			 document.getElementById("sign_id").value = getxingzuo(STAFF_BIRTH.split("-")[1], STAFF_BIRTH.split("-")[2]);
			 /*jQuery.post("get_lunar.php", "STAFF_BIRTH=" + STAFF_BIRTH + "&IS_LUNAR=" + IS_LUNAR + "", function (date) {
			 if (date.length == 5) {
			 document.getElementById("animal_id").value = date.substring(0, 1);
			 document.getElementById("sign_id").value = date.substring(2, 6);
			 }
			 });*/
		 }
	 }
	 //获取工龄
    function get_job_age(str) {
        var today = new Date();
        var month = today.getMonth();
        var day = today.getDate();
        var start_day = str.substr(8, 2);
        var start_month = str.substr(5, 2);
        var age = today.getYear() - (parseInt(str.substr(0, 4)));
        if (start_month < month || start_month == month && start_day < day) {
            age++;
        }
        if (age > 0) {
            document.form1.JOB_AGE.readOnly = true;
            document.form1.JOB_AGE.className = "BigStatic";
            document.form1.JOB_AGE.value = age;
        }
        else
            document.form1.JOB_AGE.value <= 0;
    }
	//总工龄
	function get_work_age(str) {
        var today = new Date();
        var month = today.getMonth();
        var day = today.getDate();
        var start_day = str.substr(8, 2);
        var start_month = str.substr(5, 2);
        var age = today.getYear() - (parseInt(str.substr(0, 4)));
        if (start_month < month || start_month == month && start_day < day) {
            age++;
        }
        if (age > 0) {
            document.form1.WORK_AGE.readOnly = true;
            document.form1.WORK_AGE.className = "BigStatic";
            document.form1.WORK_AGE.value = age;
        }
        else
            document.form1.WORK_AGE.value <= 0;
    }
</script>

</head>
<body class="bodycolor" topmargin="5" onLoad="form1.USER_NAME.focus();">
<form id="form1" runat="server">
<a name="bottom"></a>
<div id="other_info" name="other_info_name"style="display: none;clear: both;position:absolute;top:60px;left:60px;right:40px;border:solid 1px black;z-index:2;">
	<iframe ID="other_info_iframe" name="iframe_staff" frameborder=0 scrolling=no src="./other_info/?USER_ID=qinlei" width="100%" height="350"></iframe>
</div> 
<table class="TableBlock" width="770" align="center">
  <tr>
    <td class="TableHeader" colspan="6">&nbsp;<img src="/anywhere/images/notify_new.gif" align="absmiddle"></img><span class="big3"> 人员档案新建</span>&nbsp;&nbsp;
        <a href="javascript:show('other_info','0');">相关信息</a>&nbsp;&nbsp;
        <a href="javascript:view_item('qinlei')">查看领用物品</a>
     </td>
     
  </tr>
  <tr>
    <td class="TableData" width="100">OA用户名：</td>
    <td class="TableData" width="180" colspan=4>
        <asp:TextBox ID="USER_NAME" class="BigStatic" runat="server"></asp:TextBox>
        <asp:TextBox ID="USER_ID" style="display:none"  runat="server"></asp:TextBox> <a href="javascript:;" class="orgAdd" onClick="SelectUser('USER_ID','USER_NAME','','1')">选择</a>
    </td>
        <td class="TableData" align="center" rowspan="5">
<img alt="员工照片" src="/images/bk.jpg" style="width:98px; height:142px"></img> </td>
  </tr>
  <tr>
    <td class="TableData" width="100">部门：</td>
    <td class="TableData">
        <input type="hidden" name="DEPT_ID" value="0">
        <input type="text" name="DEPT_NAME" value="" class=BigStatic size=20 maxlength=100 readonly>
        <a href="javascript:;" class="orgAdd" onClick="SelectDeptSingle('DEPT_ID','DEPT_NAME','','0')">选择</a>
    </td>
    <td class="TableData"> 角色：</td>
    <td class="TableData" colspan=2 width=80%><input type="text" name="USER_JIAOSHE" value="" class=BigStatic size=20 maxlength=100 readonly> <a href="javascript:;" class="orgAdd" onClick="SelectDeptSingle('','DEPT_ID','DEPT_NAME')">选择</a></td>
  </tr>
  <tr>
  	<td class="TableData" width="100">编号：</td>
    <td class="TableData" width="180">
            <asp:TextBox ID="STAFF_NO" class="BigInput" onBlur="check_no(this.value,'qinlei')" runat="server"></asp:TextBox>    
    </td>       
    <td class="TableData">工号：</td>
    <td class="TableData" colspan="2"><asp:TextBox ID="WORK_NO" class="BigInput" runat="server"></asp:TextBox> </td>
  </tr>
  <tr>
  	<td class="TableData">姓名：</td>
    <td class="TableData">
        <asp:TextBox ID="STAFF_NAME" class="BigInput" runat="server"></asp:TextBox>    	
    </td>
    <td class="TableData">曾用名：</td>
    <td class="TableData" colspan="2"><asp:TextBox ID="BEFORE_NAME" class="BigInput" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
  <td class="TableData">英文名：</td>
    <td class="TableData" ><asp:TextBox ID="STAFF_E_NAME" class="BigInput" runat="server"></asp:TextBox></td>
    <td class="TableData">性别：</td>
    <td class="TableData" colspan="2" title="填写完身份证号码后可直接生成">
        <asp:DropDownList ID="STAFF_SEX" class="BigSelect" runat="server">
            <asp:ListItem Value="1">女</asp:ListItem>
            <asp:ListItem Value="0">男</asp:ListItem>
        </asp:DropDownList>    	
    </td>
  </tr>
  <tr>
  	<td class="TableData">身份证号：</td>
    <td class="TableData" ><asp:TextBox ID="STAFF_CARD_NO" class="BigInput"  onBlur="checkIdcard()" runat="server"></asp:TextBox></td>
    <td class="TableData">出生日期：</td>
    <td class="TableData" colspan="2" title="填写完身份证号码后可直接生成">
       <asp:TextBox ID="STAFF_BIRTH" size="10" maxlength="10" class="BigInput" onBlur="checkDate()" onchange="get_animal_sign()"  onClick="WdatePicker()" runat="server"></asp:TextBox>          
    </td>
        <td class="TableData" align="center">
           <input type="file" name="ATTACHMENT" size="5" class="BigInput" title="选择照片"></input></td>
  </tr>
  <tr>
    <td class="TableData">年龄：</td>
    <td class="TableData" title="填写完身份证号码后可直接生成"><asp:TextBox ID="STAFF_AGE" size="4" runat="server"></asp:TextBox>岁</td>
	<td class="TableData" width="100">年休假：</td>
    <td class="TableData" colspan="3">
     <asp:TextBox ID="LEAVE_TYPE" size="4" maxlength="5" class="BigInput" runat="server">0.0</asp:TextBox>天，本年度已休年假0天，剩余0.0天    </td>
	
  </tr>
  <tr>
  	<td class="TableData">籍贯：</td>
    <td class="TableData" colspan="5" nowrap>
        <asp:DropDownList ID="STAFF_NATIVE_PLACE" class="BigSelect" title="籍贯可在“人力资源设置”->“HRMS代码设置”模块设置。" runat="server">
        <asp:ListItem Value="110000">北京</asp:ListItem>
        <asp:ListItem Value="120000">天津</asp:ListItem>
        <asp:ListItem Value="130000">河北</asp:ListItem>
        <asp:ListItem Value="140000">山西</asp:ListItem>
        <asp:ListItem Value="150000">内蒙古</asp:ListItem>
        <asp:ListItem Value="210000">辽宁</asp:ListItem>
        <asp:ListItem Value="220000">吉林</asp:ListItem>
        <asp:ListItem Value="230000">黑龙江</asp:ListItem>
        <asp:ListItem Value="310000">上海</asp:ListItem>
        <asp:ListItem Value="320000">江苏</asp:ListItem>
        <asp:ListItem Value="330000">浙江</asp:ListItem>
        <asp:ListItem Value="340000">安徽</asp:ListItem>
        <asp:ListItem Value="350000">福建</asp:ListItem>
        <asp:ListItem Value="360000">江西</asp:ListItem>
        <asp:ListItem Value="370000">山东</asp:ListItem>
        <asp:ListItem Value="410000">河南</asp:ListItem>
        <asp:ListItem Value="420000">湖北</asp:ListItem>
        <asp:ListItem Value="430000">湖南</asp:ListItem>
        <asp:ListItem Value="440000">广东</asp:ListItem>
        <asp:ListItem Value="450000">广西</asp:ListItem>
        <asp:ListItem Value="460000">海南</asp:ListItem>
        <asp:ListItem Value="500000">重庆</asp:ListItem>
        <asp:ListItem Value="510000">四川</asp:ListItem>
        <asp:ListItem Value="520000">贵州</asp:ListItem>
        <asp:ListItem Value="530000">云南</asp:ListItem>
        <asp:ListItem Value="540000">西藏</asp:ListItem>
        <asp:ListItem Value="610000">陕西</asp:ListItem>
        <asp:ListItem Value="620000">甘肃</asp:ListItem>
        <asp:ListItem Value="630000">青海</asp:ListItem>
        <asp:ListItem Value="640000">宁夏</asp:ListItem>
        <asp:ListItem Value="650000">新疆</asp:ListItem>
        <asp:ListItem Value="710000">台湾</asp:ListItem>
        <asp:ListItem Value="810000">香港</asp:ListItem>
        <asp:ListItem Value="820000">澳门</asp:ListItem>
      </asp:DropDownList>   
       
    </td>
    
  </tr>
  <tr>
  	<td class="TableData">生肖</td>
    <td class="TableData" title="生肖">   
	    <input type="text" value="" id="animal_id" class="BigStatic" readonly /></td>
    <td class="TableData">星座</td>
    <td class="TableData" colspan="3" title="星座">
	    <input type="text" value="" id="sign_id" class="BigStatic" readonly /></td>
  </tr>
  <tr>
	<td class="TableData" width="100">血型</td>
    <td class="TableData" >
        <asp:DropDownList ID="BLOOD_TYPE" class="BigSelect" runat="server">
            <asp:ListItem Value="A">A</asp:ListItem>
            <asp:ListItem Value="B">B</asp:ListItem>
            <asp:ListItem Value="O">O</asp:ListItem>
            <asp:ListItem Value="AB">AB</asp:ListItem>
            <asp:ListItem Value="其它">其它</asp:ListItem>
        </asp:DropDownList>    
    </td>
    <td class="TableData">民族：</td>
    <td class="TableData" colspan="3">
        <asp:DropDownList ID="STAFF_NATIONALITY" class="BigSelect" runat="server">
            <asp:ListItem Value="汉族">汉族</asp:ListItem>
            <asp:ListItem Value="苗族">苗族</asp:ListItem>
            <asp:ListItem Value="O">O</asp:ListItem>
            <asp:ListItem Value="AB">AB</asp:ListItem>
            <asp:ListItem Value="其它">其它</asp:ListItem>
        </asp:DropDownList> </td>
  </tr>
  <tr>
    <td class="TableData">婚姻状况：</td>
    <td class="TableData" width="180">
      <asp:DropDownList ID="STAFF_MARITAL_STATUS" class="BigSelect" runat="server">
            <asp:ListItem Value="0">未婚</asp:ListItem>
            <asp:ListItem Value="1">已婚</asp:ListItem>
            <asp:ListItem Value="2">离异</asp:ListItem>
            <asp:ListItem Value="3">丧偶</asp:ListItem>
        </asp:DropDownList>


    </td>
    <td class="TableData" width="100">健康状况：</td>
    <td class="TableData" colspan="3">
		<asp:TextBox ID="STAFF_HEALTH"  class="BigInput" runat="server"></asp:TextBox>
	</td>
  </tr>
  <tr>
  	<td class="TableData">政治面貌：</td>
    <td class="TableData" width="180">
        <asp:DropDownList ID="STAFF_POLITICAL_STATUS" class="BigSelect" title="政治面貌可在“人力资源设置”->“HRMS代码设置”模块设置。" runat="server">
            <asp:ListItem Value="1">群众</asp:ListItem>
            <asp:ListItem Value="2">共青团员</asp:ListItem>
            <asp:ListItem Value="3">中共党员</asp:ListItem>
            <asp:ListItem Value="4">中共预备党员</asp:ListItem>
            <asp:ListItem Value="5">民主党派</asp:ListItem>
            <asp:ListItem Value="6">无党派人士</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td class="TableData" width="100">入党时间：</td>
    <td class="TableData"  colspan="3">
      <asp:TextBox ID="JOIN_PARTY_TIME" size="10" maxlength="10" class="BigInput"  onClick="WdatePicker()" runat="server"></asp:TextBox>	 
    </td>
  </tr>
  <tr>
     <td class="TableData">户口类别：</td>
     <td class="TableData" >
		 <asp:DropDownList ID="STAFF_TYPE" class="BigSelect" title="户口类别可在“人力资源设置”->“HRMS代码设置”模块设置。" runat="server">
            <asp:ListItem Value="01">本市城镇职工</asp:ListItem>
            <asp:ListItem Value="02">外埠城镇职工</asp:ListItem>
            <asp:ListItem Value="03">本市农民工</asp:ListItem>
            <asp:ListItem Value="04">外地农民工</asp:ListItem>
            <asp:ListItem Value="05">本市农村劳动力</asp:ListItem>
            <asp:ListItem Value="06">外埠农村劳动力</asp:ListItem>
        </asp:DropDownList>		

     </td>
    <td class="TableData" width="100">户口所在地：</td>
    <td class="TableData"  width="180" colspan="3">
		<asp:TextBox ID="STAFF_DOMICILE_PLACE" size="40" class="BigInput" runat="server"></asp:TextBox>		
	</td>
  </tr>
 
  <tr>
    <td class="TableHeader" colspan="6"><b>&nbsp;职位情况及联系方式：</b></td>
  </tr>
   <tr>
    <td class="TableData" width="100">工种：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="WORK_TYPE" class="BigInput" runat="server"></asp:TextBox>			
	</td>
    <td class="TableData" width="100">行政级别：</td>
    <td class="TableData"  width="180">
	    <asp:TextBox ID="ADMINISTRATION_LEVEL" class="BigInput" runat="server"></asp:TextBox>			
	</td>
    <td class="TableData" width="100">员工类型：</td>
    <td class="TableData">
		<asp:DropDownList ID="STAFF_OCCUPATION" class="BigSelect" title="员工类型可在“人力资源设置”->“HRMS代码设置”模块设置。" runat="server">
            <asp:ListItem Value="01">合同工</asp:ListItem>
            <asp:ListItem Value="02">正式员工</asp:ListItem>
            <asp:ListItem Value="03">临时工</asp:ListItem>          
        </asp:DropDownList>	        
    </td>
  </tr>
  <tr>
    <td class="TableData" width="100">职务：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="JOB_POSITION" class="BigInput" runat="server"></asp:TextBox>			
	</td>
    <td class="TableData" width="100">职称：</td>
    <td class="TableData"  width="180">
	
		<asp:DropDownList ID="PRESENT_POSITION" class="BigSelect" title="职称可在“人力资源设置”->“HRMS代码设置”模块设置。" runat="server">
            <asp:ListItem Value="08">高级职称</asp:ListItem>
            <asp:ListItem Value="02">助理工程师</asp:ListItem>
            <asp:ListItem Value="01">工程师</asp:ListItem>
			<asp:ListItem Value="03">高级工程师</asp:ListItem> 
			<asp:ListItem Value="04">研高工</asp:ListItem> 
			<asp:ListItem Value="07">职称</asp:ListItem> 			
        </asp:DropDownList>		
    </td>
    <td class="TableData" width="100">入职时间：</td>
    <td class="TableData"  width="180">
	    <asp:TextBox ID="DATES_EMPLOYED" size="10" maxlength="10" onClick="WdatePicker()" onChange="get_job_age(this.value)" class="BigInput" runat="server"></asp:TextBox>	
    </td>
  </tr>
  <tr>
  	<td class="TableData" width="100">职称级别：</td>
    <td class="TableData">	
		<asp:DropDownList ID="WORK_LEVEL" class="BigSelect" title="职称级别可在“人力资源设置”->“HRMS代码设置”模块设置。" runat="server">
            <asp:ListItem Value="08">初级</asp:ListItem>
            <asp:ListItem Value="02">中级</asp:ListItem>
            <asp:ListItem Value="01">副高</asp:ListItem>
			<asp:ListItem Value="03">正高</asp:ListItem> 					
        </asp:DropDownList>	        
    </td>
    <td class="TableData" width="100">岗位：</td>
    <td class="TableData">
		<asp:DropDownList ID="WORK_JOB" class="BigSelect" runat="server">
            <asp:ListItem Value="1">技术研发</asp:ListItem>
            <asp:ListItem Value="2">技术支持</asp:ListItem>
            <asp:ListItem Value="3">销售</asp:ListItem>					
        </asp:DropDownList>	 

    </td>
    <td class="TableData" width="100">考勤排班类型：</td>
    <td class="TableData">
		<asp:DropDownList ID="DUTY_TYPE" class="BigSelect" runat="server">
            <asp:ListItem Value="1">正常班</asp:ListItem>
            <asp:ListItem Value="2">全日班</asp:ListItem>
            <asp:ListItem Value="3">轮班制</asp:ListItem>					
        </asp:DropDownList>	    	
    </td>
  </tr>
  <tr>
    <td class="TableData" width="100">本单位工龄：</td>
    <td class="TableData"  width="180">		
		<asp:TextBox ID="JOB_AGE" class="BigInput" runat="server"></asp:TextBox>
	</td>
    <td class="TableData" width="100">起薪时间：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="BEGIN_SALSRY_TIME" size="10" maxlength="10" class="BigInput" onClick="WdatePicker()" runat="server"></asp:TextBox>      
    </td>
    <td class="TableData" width="100">在职状态：</td>
    <td class="TableData"  width="180">
		<asp:DropDownList ID="WORK_STATUS" class="BigSelect" title="在职状态可在“人力资源设置”->“HRMS代码设置”模块设置。" runat="server">
            <asp:ListItem Value="1">在职</asp:ListItem>
            <asp:ListItem Value="2">辞职</asp:ListItem>
            <asp:ListItem Value="3">离休</asp:ListItem>	
			<asp:ListItem Value="4">退休</asp:ListItem>	
			<asp:ListItem Value="5">借调</asp:ListItem>				
        </asp:DropDownList>	  
    </td>
  </tr>
  <tr>
    <td class="TableData" width="100">总工龄：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="WORK_AGE" class="BigInput" runat="server"></asp:TextBox>
	</td>
    <td class="TableData" width="100">参加工作时间：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="JOB_BEGINNING" size="10" maxlength="10" class="BigInput" onClick="WdatePicker()" onChange="get_work_age(this.value)" runat="server"></asp:TextBox>
	</td>
    <td class="TableData" width="100">联系电话：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_PHONE" class="BigInput" runat="server"></asp:TextBox>
	</td>
  </tr>
  <tr>
  	<td class="TableData" width="100">手机号码：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_MOBILE" class="BigInput" runat="server"></asp:TextBox>
	</td>
    <td class="TableData" width="100">小灵通：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_LITTLE_SMART" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">MSN：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_MSN" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableData" width="100">电子邮件：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_EMAIL" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">家庭地址：</td>
    <td class="TableData"  width="180" colspan="3">
		<asp:TextBox ID="HOME_ADDRESS" size="50" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableData" width="100">QQ：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_QQ" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">其他联系方式：</td>
    <td class="TableData"  width="180" colspan="3">
		<asp:TextBox ID="OTHER_CONTACT" size="50" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
    <tr>
    <td class="TableData" width="100">开户行1：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="BANK1" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">账户1：</td>
    <td class="TableData"  width="180" colspan="3">
		<asp:TextBox ID="BANK_ACCOUNT1" size="50" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
    <tr>
    <td class="TableData" width="100">开户行2：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="BANK2" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">账户2：</td>
    <td class="TableData"  width="180" colspan="3">
		<asp:TextBox ID="BANK_ACCOUNT2" size="50" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableHeader" colspan="6"><b>&nbsp;教育背景：</b></td>
  </tr>
  <tr>
    <td class="TableData" width="100">学历：</td>
    <td class="TableData"  width="180">
		<asp:DropDownList ID="STAFF_HIGHEST_SCHOOL" class="BigSelect" title="学历可在“人力资源设置”->“HRMS代码设置”模块设置。" runat="server">
            <asp:ListItem Value="1">小学</asp:ListItem>
            <asp:ListItem Value="2">初中</asp:ListItem>
            <asp:ListItem Value="3">高中</asp:ListItem>	
			<asp:ListItem Value="4">中专</asp:ListItem>	
			<asp:ListItem Value="5">大专</asp:ListItem>
			<asp:ListItem Value="6">本科</asp:ListItem>
			<asp:ListItem Value="7">研究生</asp:ListItem>
			<asp:ListItem Value="8">博士</asp:ListItem>
			<asp:ListItem Value="9">博士后</asp:ListItem>
			<asp:ListItem Value="10">技校</asp:ListItem>		
        </asp:DropDownList>
    </td>
    <td class="TableData" width="100">学位：</td>
    <td class="TableData"  width="180">
		<asp:DropDownList ID="STAFF_HIGHEST_DEGREE" class="BigSelect" title="学位可在“人力资源设置”->“HRMS代码设置”模块设置。" runat="server">
            <asp:ListItem Value="1">博士后</asp:ListItem>
            <asp:ListItem Value="2">博士</asp:ListItem>
            <asp:ListItem Value="3">MBA</asp:ListItem>	
			<asp:ListItem Value="4">硕士</asp:ListItem>	
			<asp:ListItem Value="5">双学士</asp:ListItem>
			<asp:ListItem Value="6">学士</asp:ListItem>
			<asp:ListItem Value="7">无</asp:ListItem>					
        </asp:DropDownList>
    </td>
    <td class="TableData" width="100">毕业时间：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="GRADUATION_DATE" size="10" maxlength="10" class="BigInput" onClick="WdatePicker()" runat="server"></asp:TextBox>  
    </td>
  </tr>
  <tr>
    <td class="TableData" width="100">毕业学校：</td>
    <td class="TableData"  width="180">	
		<asp:TextBox ID="GRADUATION_SCHOOL"  class="BigInput" runat="server"></asp:TextBox>  
    <td class="TableData" width="100">专业：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_MAJOR" class="BigInput" runat="server"></asp:TextBox> 
	 </td>
    <td class="TableData" width="100">计算机水平：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="COMPUTER_LEVEL" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableData" width="100">外语语种1：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LANGUAGE1" class="BigInput" runat="server"></asp:TextBox> 
	 </td>
    <td class="TableData" width="100">外语语种2：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LANGUAGE2" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">外语语种3：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LANGUAGE3" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableData" width="100">外语水平1：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LEVEL1" class="BigInput" runat="server"></asp:TextBox> 
	 </td>
    <td class="TableData" width="100">外语水平2：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LEVEL2" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">外语水平3：</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LEVEL3" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableData" width="100">特长：</td>
    <td class="TableData"  width="180" colspan="5">
		<asp:TextBox ID="STAFF_SKILLS" size="80" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
  	<td class="TableHeader" colspan="3"><b>&nbsp;职务情况：</b></td>
  	<td class="TableHeader" colspan="3"><b>&nbsp;担保记录：</b></td>
  </tr>
  <tr>
    <td class="TableData" colspan="3">
		<asp:TextBox ID="CERTIFICATE" Columns="45" runat="server" Rows="3" class="BigInput" TextMode="MultiLine"></asp:TextBox>	
	</td>
    <td class="TableData" colspan="3">		
		<asp:TextBox ID="SURETY"  Columns="45" runat="server" Rows="3" class="BigInput" TextMode="MultiLine"></asp:TextBox>
     </td>
  </tr>
  <tr>
  	<td class="TableHeader" colspan="3"><b>&nbsp;社保缴纳情况：</b></td>
  	<td class="TableHeader" colspan="3"><b>&nbsp;体检记录：</b></td>
  </tr>
  <tr>
    <td class="TableData" colspan="3">
		<asp:TextBox ID="INSURE" Columns="45" runat="server" Rows="3" class="BigInput" TextMode="MultiLine"></asp:TextBox>	
	</td>
    <td class="TableData" colspan="3">
		<asp:TextBox ID="BODY_EXAMIM" Columns="45" runat="server" Rows="3" class="BigInput" TextMode="MultiLine"></asp:TextBox>		
	</td>
  </tr>
  <tr>
    <td colspan="6">
    </td>
  </tr>
  <tr>
    <td align="left" colspan="6" class="TableHeader">备注：</td>
  </tr>
  <tr>
    <td class="TableData" colspan="6">
		<asp:TextBox ID="REMARK" Columns="95" runat="server" Rows="3" class="BigInput" TextMode="MultiLine"></asp:TextBox>	
	</td>
  </tr>
  <tr>
    <td class="TableHeader" colspan="6"><b>&nbsp;附件文档：</b></td>
  </tr>
  <tr>
    <td class="TableData" colspan="6"></td>
  </tr>
  <tr height="25">
    <td class="TableData">附件选择：</td>
    <td class="TableData" colspan="5">
     
    </td>
  </tr>
  <tr>
    <td class="TableHeader" colspan="6">简历：</td>
  </tr>
  <tr>
    <td class="TableData" colspan="6">
      <div style="width:100%">
      <asp:TextBox ID="RESUME" runat="server" Width="100%" Rows="10" TextMode="MultiLine"></asp:TextBox>
      <script type="text/javascript">
          var editor = new baidu.editor.ui.Editor({ id: 'editor', minFrameHeight: 300 }); editor.render("RESUME");
      </script>
      </div>
    </td>
  </tr>
  <tr align="center" class="TableControl">
    <td colspan=6 nowrap>
		<asp:Button ID="Button1" runat="server" Text="保存" class="BigButton" /><!--onClick="CheckForm();"-->
		<asp:Button ID="Button2" runat="server" Text="复职" class="BigButton" />    
    </td>
  </tr>
</table>
 
<div id="back_ground" style="display: none;position:absolute;TOP: 0px; left:0px;right:0px; z-index:1; width:100%; height:100%;background: #000; filter: alpha(opacity=50); -moz-opacity:0.5;opacity:0.5;"></div>
</form>
 
</body>
</html>
 
 
