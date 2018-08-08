<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="anywhere_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%></title>
   <link rel="stylesheet" type="text/css" href="theme/13/index.css" />
<script type="text/javascript">
    var cur_login_user_id = "chr";
    var gz_postfix = ".gz";
</script>
   <script type="text/javascript" src="inc/js/jquery/jquery.min.js"></script>
   <script type="text/javascript" src="inc/js/jquery/jquery-ui.custom.min.js"></script>
   <script type="text/javascript" src="inc/js/jquery/jquery.ui.autocomplete.min.js"></script>
   <script type="text/javascript" src="inc/js/jquery/jquery.effects.bounce.min.js"></script>
   <script type="text/javascript" src="inc/js/jquery/jquery.cookie.js"></script>
   <script type="text/javascript" src="inc/js/jquery/jquery.plugins.js"></script>
   <script type="text/javascript" src="inc/jslang.js"></script><!--自定义变量做到配置文件中去-->
   <script type="text/javascript" src="inc/js/plugin.js"></script>
   <script type="text/javascript" src="inc/js/index.js"></script>
</head>


<script type="text/javascript">
OA_TIME = new Date(<%= DateTime.Now.ToString("yyyy,MM,dd,HH,mm,ss") %>);   //获取服务器日期 
var func_array=[]; 
    <% menuall(); %>
    self.moveTo(0, 0);
    self.resizeTo(screen.availWidth, screen.availHeight);
    self.focus();   

    //基础用户信息
    var loginUser = { uid: <%= LCX.Common.PublicMethod.GetSessionValue("UserID")%>, user_name: "<%= LCX.Common.PublicMethod.GetSessionValue("TrueName")%>" };
    var newSmsHtml = "<div onclick='show_sms();' title='点击查看新消息'><img src='images/sms1.gif' border='0' height='12'> 新消息</div>";
    var newSmsSoundHtml = "<object id='sms_sound' classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000' codebase='/inc/swflash.cab' width='0' height='0'><param name='movie' value='/wav/3.swf'><param name=quality value=high><embed id='sms_sound' src='/wav/3.swf' width='0' height='0' quality='autohigh' wmode='opaque' type='application/x-shockwave-flash' plugspace='http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash'></embed></object>";
    
    //var unit_name = '&nbsp;';
    //var user_total_count = "10";
    var portalArray = [];
//    portalArray["-1"] = { id: "3", src: "images/portal/2.png", url: "/general/portal/group/", title: "集团门户", closable: true };
     portalArray["0"] = { id: "5", src: "images/portal/4.png", url: "desktop.aspx", title: "个人桌面", closable: false };
//    portalArray["1"] = { id: "1", src: "images/portal/1.png", url: "../Main/Main.aspx", title: "主界面", closable: true };
//    portalArray["1"] = { id: "6", src: "images/portal/5.png", url: "/general/portal/hrms/", title: "HRMS门户", closable: true };
//    portalArray["2"] = { id: "2", src: "images/portal/1.png", url: "/general/portal/crm/", title: "CRM门户", closable: true };
//    portalArray["3"] = { id: "4", src: "images/portal/3.png", url: "/general/mytable/intel_view/", title: "企业门户", closable: true };
//    portalArray["4"] = { id: "8", src: "images/portal/7.png", url: "/general/portal/workflow/", title: "工作流门户", closable: true };
//    portalArray["5"] = { id: "7", src: "images/portal/6.png", url: "/general/portal/info/", title: "资讯门户", closable: true };
//    portalArray["6"] = { id: "9", src: "images/portal/8.png", url: "/general/person_info/regcc/go.php", title: "企业社区", closable: true };
    var themeArray = [];
    themeArray["10"] = { src: "images/themeswitch/theme_thumb_10.jpg", title: "宁静的思考" };
    themeArray["11"] = { src: "images/themeswitch/theme_thumb_11.jpg", title: "爱心与希望" };
    themeArray["12"] = { src: "images/themeswitch/theme_thumb_12.jpg", title: "纯朴之木屋" };
    themeArray["13"] = { src: "images/themeswitch/theme_thumb_13.jpg", title: "现代或未来" };

  
    //-- 一级菜单 --
    var first_array = <%=jss.Serialize((string[])getMenuID(0,true).ToArray(typeof(string))) %>;

    //-- 二级菜单 --
    var second_array = [];
    <%
    foreach (String s in getMenuID(0,true)){ 
         Response.Write("second_array[\"m"+s+"\"]="+ jss.Serialize((string[])getMenuID(Int32.Parse(s),true).ToArray(typeof(string)))+";\n"); 
    }
    %>

    //-- 三级菜单 --
    var third_array = [];
    <%
     foreach (String s in getMenuID(0,true)){                
          foreach(String sss in getMenuID(Int32.Parse(s),true)){  
           if(getMenuID(Int32.Parse(sss),true).Count>0){      
                Response.Write("third_array[\"f"+sss+"\"]="+ jss.Serialize((string[])getMenuID(Int32.Parse(sss),true).ToArray(typeof(string)))+";\n"); 
            }
          }       
     }
    %>

    //@表示下级分类
    //-- 互联网自定义 -- 
    func_array["extWebApp"] = ["ewp345", "ewp346", "ewp347", "ewp348", "ewp349", "ewp350", "ewp351", "ewp352", "ewp353", "ewp354", "ewp355", "ewp356", "ewp357", "ewp358"];
    func_array["fewp345"] = ["百度搜索", "http://baidu.com", "ewp_baidu.png"];
    func_array["fewp346"] = ["新浪网", "http://www.sina.com.cn", "ewp_sina.png"];
    func_array["fewp347"] = ["58同城", "http://www.58.com", "ewp_58.png"];
    func_array["fewp348"] = ["天气预报", "http://xapp.baidu.com/apps/baidu-weather/app.html", "ewp_weather.png"];
    func_array["fewp349"] = ["奇艺网", "http://qiyi.com", "ewp_qiyi.png"];
    func_array["fewp350"] = ["中国政府网", "http://www.gov.cn", "ewp_gov.png"];
    func_array["fewp351"] = ["天涯社区", "http://www.tianya.cn", "ewp_tianya.png"];
    func_array["fewp352"] = ["淘宝网", "http://www.taobao.com", "ewp_taobao.png"];
    func_array["fewp353"] = ["优酷网", "http://www.youku.com", "ewp_youku.png"];
    func_array["fewp354"] = ["百度贴吧", "http://tieba.baidu.com", "ewp_bdtieba.png"];
    func_array["fewp355"] = ["新浪体育", "http://sports.sina.com.cn", "ewp_sinas.png"];
    func_array["fewp356"] = ["新浪新闻", "http://news.sina.com.cn", "ewp_sinanews.png"];
    func_array["fewp357"] = ["百度音乐", "http://music.baidu.com", "ewp_bdmp3.png"];
    func_array["fewp358"] = ["虾米音乐", "http://xiami.com", "ewp_xiami.png"];

    //-- 当前系统主题
    var ostheme = <%= LCX.Common.PublicMethod.theme()%>;
</script>
<body>

<style>
.vmPanel{padding-left:9px;margin: 10px 0;background: url("images/voicemsg/sound_bg.png") no-repeat left top;height:38px;line-height:38px;cursor:pointer;}
.vmContent {background:url("images/voicemsg/sound_bg.png") no-repeat right -38px;font-size:12px; font-weight:bold; color:#668A0D; text-align:right;padding-right: 10px;} 
.vmContent .icoVoice, .vmContent .icoVoicePlaying, .vmContent .icoVoiceDown {float:left;width:32px;height:32px;margin-top:4px;display: inline;}
.vmContent .icoVoice{background: url("images/voicemsg/icon_sound.png") no-repeat 0 3px;}
.vmContent .icoVoiceDown{background: url("images/voicemsg/icon_download.png") no-repeat -32px 0;} 
.vmContent .icoVoicePlaying{background: url("images/voicemsg/you_voice_play.gif") no-repeat 0 4px;}
.vmPanel.vmYou{background-position:left top;}
.vmPanel.vmYou .vmContent{background-position:right -38px;}

.vmPanel.vmMe{background-position:left -76px;}
.vmPanel.vmMe .vmContent{background-position:right -114px;color:#9e9e9e;}
.vmPanel.vmMe .vmContent .icoVoice{background: url("images/voicemsg/icon_sound.png") no-repeat -31px 3px;}
.vmPanel.vmMe .vmContent .icoVoiceDown{background: url("images/voicemsg/icon_download.png") no-repeat 0 0;}
.vmPanel.vmMe .vmContent .icoVoicePlaying{background: url("images/voicemsg/me_voice_play.gif") no-repeat 0 5px;}
    .auto-style1 {
        width: 396px;
    }
    .auto-style2 {
        margin-left: 166px;
    }
    .auto-style3 {
        width: 87px;
        margin-left: 39px;
    }
    .auto-style4 {
        margin-left: 31px;
    }
</style>
<script src="inc/js/ispirit.js"></script>
<script type="text/javascript">
    (function ($) {
        var voiceMsg = {
            "init": function () {
                $(".vmPanel[action-type='play']").live("click", function () {
                    $(this).toggle(
        function () { voiceMsg.play($(this)); },
        function () { voiceMsg.stop(); }
      ).trigger('click');
                });

                $(".vmPanel[action-type='download']").live("click", function () { voiceMsg.download($(this)); });
            },
            "play": function (handler) {
                var voice_data = handler.attr("action-data");
                this.stop();
                handler.find("[un='voiceStatus']").attr("class", "icoVoicePlaying");
                if (typeof (window.external.PlayVoiceMsg) == "undefined") {

                } else {
                    window.external.PlayVoiceMsg(voice_data);
                }
            },
            "stop": function () {
                if (typeof (window.external.StopVoiceMsg) == "undefined") {
                } else {
                    window.external.StopVoiceMsg("");
                }
                StopVoiceMsg();
            },
            "download": function (handler) {
                var voice_data = handler.attr("action-data-url");
                window.open(voice_data);
            }
        }

        $(function () { replaceVMDom(); voiceMsg.init(); });

    })(jQuery);

    function replaceVMDom() {
        if (2 < 3) {
            //默认是下载不需要替换
        } else {
            if (3 < 2) {
                var vm = jQuery(".vmPanel");
                vm.before("<span style='color:red'>系统提示：客户端版本过低，请升级客户端</span>");
                vm.remove();
            } else {

                //有通过后台传值判断精灵的部分不替换
                if (jQuery(".vmPanel").size() > 0) {
                    var defaultaction = jQuery(".vmPanel").eq(0).attr("action-type");

                } else {
                    return;
                }

                jQuery(".vmPanel").each(function () {
                    jQuery(this).attr("action-type", "play");
                    jQuery(this).attr("title", "点击播放");
                    jQuery(this).find("[un='voiceStatus']").attr("class", "icoVoice");
                });
            }
        }
    }

    function StopVoiceMsg() {
        jQuery("[un='voiceStatus']").attr("class", "icoVoice");
    }

    top.StopVoiceMsg = StopVoiceMsg;

</script>
<form id="form2" runat="server">
 <div>
   <div id="loading" class="loading" style="width:100%;height:100%;margin-top:100px;padding-top:100px;text-align:center;color:#1547b8;font-size:32px;font-family:微软雅黑,宋体;"></div>
   <div id="north">
      <div id="north_left">
         <table><tr><td><img src="theme/10/product.png" align="absmiddle" class="auto-style1"></td></tr></table>
      </div>
      <div id="north_right" class="auto-style2">
         <div id="datetime" class="auto-style4"><div id="time_area"></div><div id="date" title="">年</div> <div id="mdate" title="农历 ">农历</div></div>
         <div id="weather" class="auto-style3"><span class="city" title="点击更改城市" onclick="$('area_select').style.display='block';$('weather').style.display='none';">城市</span> <img src="images/weather/1.gif" align="absMiddle"/>  <span class="weather">天气</span><span class="temperature" title="风向">温度</span></div>
         <!-- 天气预报 -->
         <div id="area_select">
           <div>
              <select style=" width:80px;" id="w_province" onChange="InitCity(this.value);"></select>
              <select style=" width:80px;"  id="w_city" onChange="InitCounty(this.value);"></select>
              <select id="w_county">
                <option value="270105"></option>
              </select>
           </div>
           <div>
              <input type="button" value="确定" class="SmallButton" onClick="GetWeather('1');">
              <input type="button" value="取消" class="SmallButton" onClick="$('area_select').style.display='none';$('weather').style.display='block';">
           </div>
         </div>
      </div>
   </div>
   <div id="taskbar">
      <div id="taskbar_left">
         <a href="javascript:;" id="start_menu" hidefocus="hidefocus"></a>
      </div>
      <div id="taskbar_center">
         <div id="tabs_left_scroll"></div>
         <div id="tabs_container"></div>
         <div id="tabs_right_scroll"></div>
      </div>
      <div id="taskbar_right">
         <a id="theme" href="javascript:;" hidefocus="hidefocus" title="更换皮肤"></a>
         <a id="logout" href="###" hidefocus="hidefocus" title="注销登录"></a>
         <a id="hide_topbar" href="javascript:;" hidefocus="hidefocus" title="隐藏/显示顶部"></a>
   <div id="funcbar">
      <div id="funcbar_left"></div>
      <div id="funcbar_right">
         <div class="search">
            <div class="search-body">
               <div class="search-input"><input id="keyword" type="text" value=""></div>
               <div id="search_clear" class="search-clear" style="display:none;" onClick="document.getElementById('keyword').value = '';this.style.display = 'none';"></div>
            </div>
         </div>
      </div>
   </div>
      </div>
   </div>
   <div id="center">
      <!-- 任务中心 -->
      <div id="task_center_panel" class="over-mask-layer"></div>
      
      <!-- 门户切换 -->
      <div id="portal_panel" class="over-mask-layer"></div>
      
      <!-- 主题切换 -->
      <div id="theme_panel" class="over-mask-layer"></div>
      
      <div id="overlay_panel"></div>
   </div>
   <!--底部状态栏-->
   <div id="south">
      <table>
         <tr>
            <td class="left"><div id="online_link" onClick="ViewOnlineUser()" title="共 0 人，0 人在线">在线<span id="user_count">0</span>人</div></td>
            <td class="left"><div id="new_sms"></div><span id="new_sms_sound" style="width:1px;height:1px;"></span></td>
            <td class="center">
            	<div id="status_text"><%=System.Configuration.ConfigurationManager.AppSettings["SYSTitle"]%><br>对标找差距，转变谋发展<br><br></div>
            </td> 
            <td style="cursor:hand;" class="right">
            </td>
            <td class="right">
            	<a id="nocbox" class="ipanel_tab" href="javascript:;" panel="noc_panel" title="事务提醒" hidefocus="hidefocus"></a>
					
               <a id="org" class="ipanel_tab" href="javascript:;" panel="org_panel" title="组织" hidefocus="hidefocus"></a>
            </td>
         </tr>
      </table>
   </div>

   <!-- 导航菜单 -->
   <div id="start_menu_panel">
      <div class="panel-head"></div>
      <!-- 登录用户信息 -->
      <div class="panel-user">
         <div class="avatar">
            <asp:Image ID="sex" runat="server" align="absmiddle" />
            <div class="status_icon status_icon_<%=zaiGang%>"></div>
            <div id="on_status">
               <a href="javascript:;" status="1" class="on_status_1" hidefocus="hidefocus">在岗</a>
               <a href="javascript:;" status="2" class="on_status_2" hidefocus="hidefocus">出差</a>
               <a href="javascript:;" status="3" class="on_status_3" hidefocus="hidefocus">休假</a>
            </div>
         </div>
         <div class="name" title="部门：<%= LCX.Common.PublicMethod.GetSessionValue("Department")%>  角色：<%= LCX.Common.PublicMethod.GetSessionValue("JiaoSe")%> "><%= LCX.Common.PublicMethod.GetSessionValue("TrueName")%></div>
         <div class="tools">
            <a class="logout" href="###" onClick="logout();" hidefocus="hidefocus" title="注销"></a>
            <a class="exit" href="###" onClick="exit();" hidefocus="hidefocus" title="退出"></a>
         </div>
      </div>
      <div class="panel-menu">
         <!-- 一级菜单 -->
         <div id="first_panel">
            <div class="scroll-up"></div>
            <ul id="first_menu"></ul>
            <div class="scroll-down"></div>
         </div>
         <!-- 二级级菜单 -->
         <div id="second_panel">
            <div class="second-panel-head"></div>
            <div class="second-panel-menu"><ul id="second_menu"></ul></div>
            <div class="second-panel-foot"></div>
         </div>
      </div>
      <div class="panel-foot"></div>
   </div>
   <div id="overlay_startmenu"></div>

   <!-- 事务提醒 -->
   <div id="new_sms_mask"></div>
   <div id="new_sms_panel">
      <div class="button">
         <a class="btn-white-big" href="javascript:;" onClick="ViewNewSms();" hidefocus="hidefocus">打开</a>&nbsp;&nbsp;
         <a class="btn-white-big" href="javascript:;" onClick="CloseRemind();" hidefocus="hidefocus">关闭</a>
      </div>
   </div>
   


   <!-- 事务提醒 -->
   <div id="new_noc_panel">
   	<div id="new_noc_title">
   			<span class="noc_iterm_num">共&nbsp;<span></span>&nbsp;条提醒</span>
   			<span class="noc_iterm_close"></span>
           <%-- <span class="noc_iterm_history"><a id="check_remind_histroy" href="javascript:;" hidefocus="hidefocus">查看历史记录</a></span>--%>
   	</div> 
   	<div id="nocbox_tips"></div>
   	<div id="new_noc_list"></div>
   	<div class="button">
         <a id="ViewAllNoc" class="btn-white-big" href="javascript:;" hidefocus="hidefocus">全部已阅</a>
        <%-- <a id="ViewDetail" class="btn-white-big" href="javascript:;" hidefocus="hidefocus">全部详情</a>--%>
         <a id="CloseBtn" class="btn-white-big" href="javascript:;" hidefocus="hidefocus">关闭</a>
      </div>					
   </div>
   
   <!-- 短信箱 -->
   <div id="smsbox_panel" class="dialog" >
      <div class="head">
         <div class="head-left"></div>
         <div class="head-center">
            <div class="head-title">微讯盒子</div>
            <div class="head-close"></div>
         </div>
         <div class="head-right"></div>
      </div>
      <div class="center">
         <div class="center-left">
            <div id="smsbox_op_all">
               <a href="javascript:;" id="smsbox_read_all" hidefocus="hidefocus">全部已阅</a>
            </div>
            <div id="smsbox_scroll_up"></div>
            <div id="smsbox_list">
               <div id="smsbox_list_container" class="list-container"></div>
            </div>
            <div id="smsbox_scroll_down"></div>
         </div>
         <div class="center-right">
            <div class="center-toolbar">
               <a href="javascript:;" id="smsbox_toolbar_read" hidefocus="hidefocus" title="已阅以下微讯">已阅</a>
               <a href="javascript:;" id="smsbox_toolbar_delete" hidefocus="hidefocus" title="删除以下微讯">删除</a>
            </div>
            <div id="smsbox_msg_container" class="center-chat"></div>
            <div class="rapid-reply">
            	 <select id="smsbox_rapid_reply" class="SmallInput" title="请到系统管理->系统代码->微讯快捷回复 进行设置">
            	 	<option value="">快捷回复</option>
            	 	            	 </select>
            </div>
            <div class="center-reply">
               <textarea id="smsbox_textarea"></textarea>
               <a id="smsbox_send_msg" href="javascript:;" hidefocus="hidefocus">发送</a>
            </div>
         </div>
         <div id="smsbox_tips" class="center-tips"></div>
         <div id="no_sms">
            <div class="no-msg" title="暂无新微讯">
               <div class="close-tips">本窗口 <span id="smsbox_close_countdown">3</span> 秒后自动关闭</div>
               <a class="btn-white-big" href="javascript:;" onClick="send_msg('', '');jQuery('#smsbox').click();" hidefocus="hidefocus">发微讯</a>&nbsp;&nbsp;
               <a class="btn-white-big" href="javascript:;" onClick="jQuery('#smsbox').click();" hidefocus="hidefocus">关闭</a>
            </div>
         </div>
      </div>
      <div class="foot">
         <div class="foot-left"></div>
         <div class="foot-center"></div>
         <div class="foot-right"></div>
      </div>
      <div class="corner"></div>
   </div>

   <!-- 组织机构 -->
   <div id="org_panel" class="ipanel"></div>
   <!-- 紧急通知开始-->
     <!-- 紧急通知结束-->
   <div id="overlay"></div>
   <div style="display:none;">
   </div>

 </div>
</form>
</body>
</html>