<%@ Page Language="C#" AutoEventWireup="true" CodeFile="staff_add.aspx.cs" Inherits="HR_staff_add" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<title>���µ����༭</title>
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

 //���Ա���༭�Ƿ����ظ���
 function check_no(str, user_id) {
        if (str == "")
            return;
        //_get("check_no.php", "STAFF_NO=" + str + "&USER_ID=" + user_id, show_msg);
 }

 //������֤��
    function checkIdcard() {
    if (document.form1.STAFF_CARD_NO.value != "") {
         var idcard = document.form1.STAFF_CARD_NO.value;
         var Errors = new Array(
       "���֤����λ�����ԣ�",
       "���֤����������ڳ�����Χ���зǷ��ַ���",
       "���֤����У�����",
       "���֤�����������������룡",
       "���֤�����Ѿ����ڣ����������룡");
         var area = { 11: "����", 12: "���", 13: "�ӱ�", 14: "ɽ��", 15: "���ɹ�", 21: "����", 22: "����", 23: "������", 31: "�Ϻ�", 32: "����", 33: "�㽭", 34: "����", 35: "����", 36: "����", 37: "ɽ��", 41: "����", 42: "����", 43: "����", 44: "�㶫", 45: "����", 46: "����", 50: "����", 51: "�Ĵ�", 52: "����", 53: "����", 54: "����", 61: "����", 62: "����", 63: "�ຣ", 64: "����", 65: "�½�", 71: "̨��", 81: "���", 82: "����", 91: "����" }
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
                     if (sex % 2 == 1) //��
                         document.form1.STAFF_SEX.value = "0";
                     else  //Ů
                         document.form1.STAFF_SEX.value = "1";
                 }
                 break;

             case 18:
                 if (parseInt(idcard.substr(6, 4)) % 4 == 0 || (parseInt(idcard.substr(6, 4)) % 100 == 0 && parseInt(idcard.substr(6, 4)) % 4 == 0)) {
                     ereg = /^[1-9][0-9]{5}19[0-9]{2}((01|03|05|07|08|10|12)(0[1-9]|[1-2][0-9]|3[0-1])|(04|06|09|11)(0[1-9]|[1-2][0-9]|30)|02(0[1-9]|[1-2][0-9]))[0-9]{3}[0-9Xx]$/; //����������ڵĺϷ���������ʽ
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
                         if (sex % 2 == 1) //��
                             document.form1.STAFF_SEX.value = "0";
                         else  //Ů
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
                         if (sex % 2 == 1) //��
                             document.form1.STAFF_SEX.value = "0";
                         else  //Ů
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
	 //��ȡ����
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
	//�ܹ���
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
    <td class="TableHeader" colspan="6">&nbsp;<img src="/anywhere/images/notify_new.gif" align="absmiddle"></img><span class="big3"> ��Ա�����½�</span>&nbsp;&nbsp;
        <a href="javascript:show('other_info','0');">�����Ϣ</a>&nbsp;&nbsp;
        <a href="javascript:view_item('qinlei')">�鿴������Ʒ</a>
     </td>
     
  </tr>
  <tr>
    <td class="TableData" width="100">OA�û�����</td>
    <td class="TableData" width="180" colspan=4>
        <asp:TextBox ID="USER_NAME" class="BigStatic" runat="server"></asp:TextBox>
        <asp:TextBox ID="USER_ID" style="display:none"  runat="server"></asp:TextBox> <a href="javascript:;" class="orgAdd" onClick="SelectUser('USER_ID','USER_NAME','','1')">ѡ��</a>
    </td>
        <td class="TableData" align="center" rowspan="5">
<img alt="Ա����Ƭ" src="/images/bk.jpg" style="width:98px; height:142px"></img> </td>
  </tr>
  <tr>
    <td class="TableData" width="100">���ţ�</td>
    <td class="TableData">
        <input type="hidden" name="DEPT_ID" value="0">
        <input type="text" name="DEPT_NAME" value="" class=BigStatic size=20 maxlength=100 readonly>
        <a href="javascript:;" class="orgAdd" onClick="SelectDeptSingle('DEPT_ID','DEPT_NAME','','0')">ѡ��</a>
    </td>
    <td class="TableData"> ��ɫ��</td>
    <td class="TableData" colspan=2 width=80%><input type="text" name="USER_JIAOSHE" value="" class=BigStatic size=20 maxlength=100 readonly> <a href="javascript:;" class="orgAdd" onClick="SelectDeptSingle('','DEPT_ID','DEPT_NAME')">ѡ��</a></td>
  </tr>
  <tr>
  	<td class="TableData" width="100">��ţ�</td>
    <td class="TableData" width="180">
            <asp:TextBox ID="STAFF_NO" class="BigInput" onBlur="check_no(this.value,'qinlei')" runat="server"></asp:TextBox>    
    </td>       
    <td class="TableData">���ţ�</td>
    <td class="TableData" colspan="2"><asp:TextBox ID="WORK_NO" class="BigInput" runat="server"></asp:TextBox> </td>
  </tr>
  <tr>
  	<td class="TableData">������</td>
    <td class="TableData">
        <asp:TextBox ID="STAFF_NAME" class="BigInput" runat="server"></asp:TextBox>    	
    </td>
    <td class="TableData">��������</td>
    <td class="TableData" colspan="2"><asp:TextBox ID="BEFORE_NAME" class="BigInput" runat="server"></asp:TextBox></td>
  </tr>
  <tr>
  <td class="TableData">Ӣ������</td>
    <td class="TableData" ><asp:TextBox ID="STAFF_E_NAME" class="BigInput" runat="server"></asp:TextBox></td>
    <td class="TableData">�Ա�</td>
    <td class="TableData" colspan="2" title="��д�����֤������ֱ������">
        <asp:DropDownList ID="STAFF_SEX" class="BigSelect" runat="server">
            <asp:ListItem Value="1">Ů</asp:ListItem>
            <asp:ListItem Value="0">��</asp:ListItem>
        </asp:DropDownList>    	
    </td>
  </tr>
  <tr>
  	<td class="TableData">���֤�ţ�</td>
    <td class="TableData" ><asp:TextBox ID="STAFF_CARD_NO" class="BigInput"  onBlur="checkIdcard()" runat="server"></asp:TextBox></td>
    <td class="TableData">�������ڣ�</td>
    <td class="TableData" colspan="2" title="��д�����֤������ֱ������">
       <asp:TextBox ID="STAFF_BIRTH" size="10" maxlength="10" class="BigInput" onBlur="checkDate()" onchange="get_animal_sign()"  onClick="WdatePicker()" runat="server"></asp:TextBox>          
    </td>
        <td class="TableData" align="center">
           <input type="file" name="ATTACHMENT" size="5" class="BigInput" title="ѡ����Ƭ"></input></td>
  </tr>
  <tr>
    <td class="TableData">���䣺</td>
    <td class="TableData" title="��д�����֤������ֱ������"><asp:TextBox ID="STAFF_AGE" size="4" runat="server"></asp:TextBox>��</td>
	<td class="TableData" width="100">���ݼ٣�</td>
    <td class="TableData" colspan="3">
     <asp:TextBox ID="LEAVE_TYPE" size="4" maxlength="5" class="BigInput" runat="server">0.0</asp:TextBox>�죬������������0�죬ʣ��0.0��    </td>
	
  </tr>
  <tr>
  	<td class="TableData">���᣺</td>
    <td class="TableData" colspan="5" nowrap>
        <asp:DropDownList ID="STAFF_NATIVE_PLACE" class="BigSelect" title="������ڡ�������Դ���á�->��HRMS�������á�ģ�����á�" runat="server">
        <asp:ListItem Value="110000">����</asp:ListItem>
        <asp:ListItem Value="120000">���</asp:ListItem>
        <asp:ListItem Value="130000">�ӱ�</asp:ListItem>
        <asp:ListItem Value="140000">ɽ��</asp:ListItem>
        <asp:ListItem Value="150000">���ɹ�</asp:ListItem>
        <asp:ListItem Value="210000">����</asp:ListItem>
        <asp:ListItem Value="220000">����</asp:ListItem>
        <asp:ListItem Value="230000">������</asp:ListItem>
        <asp:ListItem Value="310000">�Ϻ�</asp:ListItem>
        <asp:ListItem Value="320000">����</asp:ListItem>
        <asp:ListItem Value="330000">�㽭</asp:ListItem>
        <asp:ListItem Value="340000">����</asp:ListItem>
        <asp:ListItem Value="350000">����</asp:ListItem>
        <asp:ListItem Value="360000">����</asp:ListItem>
        <asp:ListItem Value="370000">ɽ��</asp:ListItem>
        <asp:ListItem Value="410000">����</asp:ListItem>
        <asp:ListItem Value="420000">����</asp:ListItem>
        <asp:ListItem Value="430000">����</asp:ListItem>
        <asp:ListItem Value="440000">�㶫</asp:ListItem>
        <asp:ListItem Value="450000">����</asp:ListItem>
        <asp:ListItem Value="460000">����</asp:ListItem>
        <asp:ListItem Value="500000">����</asp:ListItem>
        <asp:ListItem Value="510000">�Ĵ�</asp:ListItem>
        <asp:ListItem Value="520000">����</asp:ListItem>
        <asp:ListItem Value="530000">����</asp:ListItem>
        <asp:ListItem Value="540000">����</asp:ListItem>
        <asp:ListItem Value="610000">����</asp:ListItem>
        <asp:ListItem Value="620000">����</asp:ListItem>
        <asp:ListItem Value="630000">�ຣ</asp:ListItem>
        <asp:ListItem Value="640000">����</asp:ListItem>
        <asp:ListItem Value="650000">�½�</asp:ListItem>
        <asp:ListItem Value="710000">̨��</asp:ListItem>
        <asp:ListItem Value="810000">���</asp:ListItem>
        <asp:ListItem Value="820000">����</asp:ListItem>
      </asp:DropDownList>   
       
    </td>
    
  </tr>
  <tr>
  	<td class="TableData">��Ф</td>
    <td class="TableData" title="��Ф">   
	    <input type="text" value="" id="animal_id" class="BigStatic" readonly /></td>
    <td class="TableData">����</td>
    <td class="TableData" colspan="3" title="����">
	    <input type="text" value="" id="sign_id" class="BigStatic" readonly /></td>
  </tr>
  <tr>
	<td class="TableData" width="100">Ѫ��</td>
    <td class="TableData" >
        <asp:DropDownList ID="BLOOD_TYPE" class="BigSelect" runat="server">
            <asp:ListItem Value="A">A</asp:ListItem>
            <asp:ListItem Value="B">B</asp:ListItem>
            <asp:ListItem Value="O">O</asp:ListItem>
            <asp:ListItem Value="AB">AB</asp:ListItem>
            <asp:ListItem Value="����">����</asp:ListItem>
        </asp:DropDownList>    
    </td>
    <td class="TableData">���壺</td>
    <td class="TableData" colspan="3">
        <asp:DropDownList ID="STAFF_NATIONALITY" class="BigSelect" runat="server">
            <asp:ListItem Value="����">����</asp:ListItem>
            <asp:ListItem Value="����">����</asp:ListItem>
            <asp:ListItem Value="O">O</asp:ListItem>
            <asp:ListItem Value="AB">AB</asp:ListItem>
            <asp:ListItem Value="����">����</asp:ListItem>
        </asp:DropDownList> </td>
  </tr>
  <tr>
    <td class="TableData">����״����</td>
    <td class="TableData" width="180">
      <asp:DropDownList ID="STAFF_MARITAL_STATUS" class="BigSelect" runat="server">
            <asp:ListItem Value="0">δ��</asp:ListItem>
            <asp:ListItem Value="1">�ѻ�</asp:ListItem>
            <asp:ListItem Value="2">����</asp:ListItem>
            <asp:ListItem Value="3">ɥż</asp:ListItem>
        </asp:DropDownList>


    </td>
    <td class="TableData" width="100">����״����</td>
    <td class="TableData" colspan="3">
		<asp:TextBox ID="STAFF_HEALTH"  class="BigInput" runat="server"></asp:TextBox>
	</td>
  </tr>
  <tr>
  	<td class="TableData">������ò��</td>
    <td class="TableData" width="180">
        <asp:DropDownList ID="STAFF_POLITICAL_STATUS" class="BigSelect" title="������ò���ڡ�������Դ���á�->��HRMS�������á�ģ�����á�" runat="server">
            <asp:ListItem Value="1">Ⱥ��</asp:ListItem>
            <asp:ListItem Value="2">������Ա</asp:ListItem>
            <asp:ListItem Value="3">�й���Ա</asp:ListItem>
            <asp:ListItem Value="4">�й�Ԥ����Ա</asp:ListItem>
            <asp:ListItem Value="5">��������</asp:ListItem>
            <asp:ListItem Value="6">�޵�����ʿ</asp:ListItem>
        </asp:DropDownList>
    </td>
    <td class="TableData" width="100">�뵳ʱ�䣺</td>
    <td class="TableData"  colspan="3">
      <asp:TextBox ID="JOIN_PARTY_TIME" size="10" maxlength="10" class="BigInput"  onClick="WdatePicker()" runat="server"></asp:TextBox>	 
    </td>
  </tr>
  <tr>
     <td class="TableData">�������</td>
     <td class="TableData" >
		 <asp:DropDownList ID="STAFF_TYPE" class="BigSelect" title="���������ڡ�������Դ���á�->��HRMS�������á�ģ�����á�" runat="server">
            <asp:ListItem Value="01">���г���ְ��</asp:ListItem>
            <asp:ListItem Value="02">�Ⲻ����ְ��</asp:ListItem>
            <asp:ListItem Value="03">����ũ��</asp:ListItem>
            <asp:ListItem Value="04">���ũ��</asp:ListItem>
            <asp:ListItem Value="05">����ũ���Ͷ���</asp:ListItem>
            <asp:ListItem Value="06">�Ⲻũ���Ͷ���</asp:ListItem>
        </asp:DropDownList>		

     </td>
    <td class="TableData" width="100">�������ڵأ�</td>
    <td class="TableData"  width="180" colspan="3">
		<asp:TextBox ID="STAFF_DOMICILE_PLACE" size="40" class="BigInput" runat="server"></asp:TextBox>		
	</td>
  </tr>
 
  <tr>
    <td class="TableHeader" colspan="6"><b>&nbsp;ְλ�������ϵ��ʽ��</b></td>
  </tr>
   <tr>
    <td class="TableData" width="100">���֣�</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="WORK_TYPE" class="BigInput" runat="server"></asp:TextBox>			
	</td>
    <td class="TableData" width="100">��������</td>
    <td class="TableData"  width="180">
	    <asp:TextBox ID="ADMINISTRATION_LEVEL" class="BigInput" runat="server"></asp:TextBox>			
	</td>
    <td class="TableData" width="100">Ա�����ͣ�</td>
    <td class="TableData">
		<asp:DropDownList ID="STAFF_OCCUPATION" class="BigSelect" title="Ա�����Ϳ��ڡ�������Դ���á�->��HRMS�������á�ģ�����á�" runat="server">
            <asp:ListItem Value="01">��ͬ��</asp:ListItem>
            <asp:ListItem Value="02">��ʽԱ��</asp:ListItem>
            <asp:ListItem Value="03">��ʱ��</asp:ListItem>          
        </asp:DropDownList>	        
    </td>
  </tr>
  <tr>
    <td class="TableData" width="100">ְ��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="JOB_POSITION" class="BigInput" runat="server"></asp:TextBox>			
	</td>
    <td class="TableData" width="100">ְ�ƣ�</td>
    <td class="TableData"  width="180">
	
		<asp:DropDownList ID="PRESENT_POSITION" class="BigSelect" title="ְ�ƿ��ڡ�������Դ���á�->��HRMS�������á�ģ�����á�" runat="server">
            <asp:ListItem Value="08">�߼�ְ��</asp:ListItem>
            <asp:ListItem Value="02">������ʦ</asp:ListItem>
            <asp:ListItem Value="01">����ʦ</asp:ListItem>
			<asp:ListItem Value="03">�߼�����ʦ</asp:ListItem> 
			<asp:ListItem Value="04">�и߹�</asp:ListItem> 
			<asp:ListItem Value="07">ְ��</asp:ListItem> 			
        </asp:DropDownList>		
    </td>
    <td class="TableData" width="100">��ְʱ�䣺</td>
    <td class="TableData"  width="180">
	    <asp:TextBox ID="DATES_EMPLOYED" size="10" maxlength="10" onClick="WdatePicker()" onChange="get_job_age(this.value)" class="BigInput" runat="server"></asp:TextBox>	
    </td>
  </tr>
  <tr>
  	<td class="TableData" width="100">ְ�Ƽ���</td>
    <td class="TableData">	
		<asp:DropDownList ID="WORK_LEVEL" class="BigSelect" title="ְ�Ƽ�����ڡ�������Դ���á�->��HRMS�������á�ģ�����á�" runat="server">
            <asp:ListItem Value="08">����</asp:ListItem>
            <asp:ListItem Value="02">�м�</asp:ListItem>
            <asp:ListItem Value="01">����</asp:ListItem>
			<asp:ListItem Value="03">����</asp:ListItem> 					
        </asp:DropDownList>	        
    </td>
    <td class="TableData" width="100">��λ��</td>
    <td class="TableData">
		<asp:DropDownList ID="WORK_JOB" class="BigSelect" runat="server">
            <asp:ListItem Value="1">�����з�</asp:ListItem>
            <asp:ListItem Value="2">����֧��</asp:ListItem>
            <asp:ListItem Value="3">����</asp:ListItem>					
        </asp:DropDownList>	 

    </td>
    <td class="TableData" width="100">�����Ű����ͣ�</td>
    <td class="TableData">
		<asp:DropDownList ID="DUTY_TYPE" class="BigSelect" runat="server">
            <asp:ListItem Value="1">������</asp:ListItem>
            <asp:ListItem Value="2">ȫ�հ�</asp:ListItem>
            <asp:ListItem Value="3">�ְ���</asp:ListItem>					
        </asp:DropDownList>	    	
    </td>
  </tr>
  <tr>
    <td class="TableData" width="100">����λ���䣺</td>
    <td class="TableData"  width="180">		
		<asp:TextBox ID="JOB_AGE" class="BigInput" runat="server"></asp:TextBox>
	</td>
    <td class="TableData" width="100">��нʱ�䣺</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="BEGIN_SALSRY_TIME" size="10" maxlength="10" class="BigInput" onClick="WdatePicker()" runat="server"></asp:TextBox>      
    </td>
    <td class="TableData" width="100">��ְ״̬��</td>
    <td class="TableData"  width="180">
		<asp:DropDownList ID="WORK_STATUS" class="BigSelect" title="��ְ״̬���ڡ�������Դ���á�->��HRMS�������á�ģ�����á�" runat="server">
            <asp:ListItem Value="1">��ְ</asp:ListItem>
            <asp:ListItem Value="2">��ְ</asp:ListItem>
            <asp:ListItem Value="3">����</asp:ListItem>	
			<asp:ListItem Value="4">����</asp:ListItem>	
			<asp:ListItem Value="5">���</asp:ListItem>				
        </asp:DropDownList>	  
    </td>
  </tr>
  <tr>
    <td class="TableData" width="100">�ܹ��䣺</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="WORK_AGE" class="BigInput" runat="server"></asp:TextBox>
	</td>
    <td class="TableData" width="100">�μӹ���ʱ�䣺</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="JOB_BEGINNING" size="10" maxlength="10" class="BigInput" onClick="WdatePicker()" onChange="get_work_age(this.value)" runat="server"></asp:TextBox>
	</td>
    <td class="TableData" width="100">��ϵ�绰��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_PHONE" class="BigInput" runat="server"></asp:TextBox>
	</td>
  </tr>
  <tr>
  	<td class="TableData" width="100">�ֻ����룺</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_MOBILE" class="BigInput" runat="server"></asp:TextBox>
	</td>
    <td class="TableData" width="100">С��ͨ��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_LITTLE_SMART" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">MSN��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_MSN" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableData" width="100">�����ʼ���</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_EMAIL" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">��ͥ��ַ��</td>
    <td class="TableData"  width="180" colspan="3">
		<asp:TextBox ID="HOME_ADDRESS" size="50" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableData" width="100">QQ��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_QQ" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">������ϵ��ʽ��</td>
    <td class="TableData"  width="180" colspan="3">
		<asp:TextBox ID="OTHER_CONTACT" size="50" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
    <tr>
    <td class="TableData" width="100">������1��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="BANK1" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">�˻�1��</td>
    <td class="TableData"  width="180" colspan="3">
		<asp:TextBox ID="BANK_ACCOUNT1" size="50" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
    <tr>
    <td class="TableData" width="100">������2��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="BANK2" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">�˻�2��</td>
    <td class="TableData"  width="180" colspan="3">
		<asp:TextBox ID="BANK_ACCOUNT2" size="50" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableHeader" colspan="6"><b>&nbsp;����������</b></td>
  </tr>
  <tr>
    <td class="TableData" width="100">ѧ����</td>
    <td class="TableData"  width="180">
		<asp:DropDownList ID="STAFF_HIGHEST_SCHOOL" class="BigSelect" title="ѧ�����ڡ�������Դ���á�->��HRMS�������á�ģ�����á�" runat="server">
            <asp:ListItem Value="1">Сѧ</asp:ListItem>
            <asp:ListItem Value="2">����</asp:ListItem>
            <asp:ListItem Value="3">����</asp:ListItem>	
			<asp:ListItem Value="4">��ר</asp:ListItem>	
			<asp:ListItem Value="5">��ר</asp:ListItem>
			<asp:ListItem Value="6">����</asp:ListItem>
			<asp:ListItem Value="7">�о���</asp:ListItem>
			<asp:ListItem Value="8">��ʿ</asp:ListItem>
			<asp:ListItem Value="9">��ʿ��</asp:ListItem>
			<asp:ListItem Value="10">��У</asp:ListItem>		
        </asp:DropDownList>
    </td>
    <td class="TableData" width="100">ѧλ��</td>
    <td class="TableData"  width="180">
		<asp:DropDownList ID="STAFF_HIGHEST_DEGREE" class="BigSelect" title="ѧλ���ڡ�������Դ���á�->��HRMS�������á�ģ�����á�" runat="server">
            <asp:ListItem Value="1">��ʿ��</asp:ListItem>
            <asp:ListItem Value="2">��ʿ</asp:ListItem>
            <asp:ListItem Value="3">MBA</asp:ListItem>	
			<asp:ListItem Value="4">˶ʿ</asp:ListItem>	
			<asp:ListItem Value="5">˫ѧʿ</asp:ListItem>
			<asp:ListItem Value="6">ѧʿ</asp:ListItem>
			<asp:ListItem Value="7">��</asp:ListItem>					
        </asp:DropDownList>
    </td>
    <td class="TableData" width="100">��ҵʱ�䣺</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="GRADUATION_DATE" size="10" maxlength="10" class="BigInput" onClick="WdatePicker()" runat="server"></asp:TextBox>  
    </td>
  </tr>
  <tr>
    <td class="TableData" width="100">��ҵѧУ��</td>
    <td class="TableData"  width="180">	
		<asp:TextBox ID="GRADUATION_SCHOOL"  class="BigInput" runat="server"></asp:TextBox>  
    <td class="TableData" width="100">רҵ��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="STAFF_MAJOR" class="BigInput" runat="server"></asp:TextBox> 
	 </td>
    <td class="TableData" width="100">�����ˮƽ��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="COMPUTER_LEVEL" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableData" width="100">��������1��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LANGUAGE1" class="BigInput" runat="server"></asp:TextBox> 
	 </td>
    <td class="TableData" width="100">��������2��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LANGUAGE2" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">��������3��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LANGUAGE3" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableData" width="100">����ˮƽ1��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LEVEL1" class="BigInput" runat="server"></asp:TextBox> 
	 </td>
    <td class="TableData" width="100">����ˮƽ2��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LEVEL2" class="BigInput" runat="server"></asp:TextBox> 
	</td>
    <td class="TableData" width="100">����ˮƽ3��</td>
    <td class="TableData"  width="180">
		<asp:TextBox ID="FOREIGN_LEVEL3" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
    <td class="TableData" width="100">�س���</td>
    <td class="TableData"  width="180" colspan="5">
		<asp:TextBox ID="STAFF_SKILLS" size="80" class="BigInput" runat="server"></asp:TextBox> 
	</td>
  </tr>
  <tr>
  	<td class="TableHeader" colspan="3"><b>&nbsp;ְ�������</b></td>
  	<td class="TableHeader" colspan="3"><b>&nbsp;������¼��</b></td>
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
  	<td class="TableHeader" colspan="3"><b>&nbsp;�籣���������</b></td>
  	<td class="TableHeader" colspan="3"><b>&nbsp;����¼��</b></td>
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
    <td align="left" colspan="6" class="TableHeader">��ע��</td>
  </tr>
  <tr>
    <td class="TableData" colspan="6">
		<asp:TextBox ID="REMARK" Columns="95" runat="server" Rows="3" class="BigInput" TextMode="MultiLine"></asp:TextBox>	
	</td>
  </tr>
  <tr>
    <td class="TableHeader" colspan="6"><b>&nbsp;�����ĵ���</b></td>
  </tr>
  <tr>
    <td class="TableData" colspan="6"></td>
  </tr>
  <tr height="25">
    <td class="TableData">����ѡ��</td>
    <td class="TableData" colspan="5">
     
    </td>
  </tr>
  <tr>
    <td class="TableHeader" colspan="6">������</td>
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
		<asp:Button ID="Button1" runat="server" Text="����" class="BigButton" /><!--onClick="CheckForm();"-->
		<asp:Button ID="Button2" runat="server" Text="��ְ" class="BigButton" />    
    </td>
  </tr>
</table>
 
<div id="back_ground" style="display: none;position:absolute;TOP: 0px; left:0px;right:0px; z-index:1; width:100%; height:100%;background: #000; filter: alpha(opacity=50); -moz-opacity:0.5;opacity:0.5;"></div>
</form>
 
</body>
</html>
 
 
