//取生肖, 参数必须是四位的年    
function getshengxiao(yyyy){ 
    //by Go_Rush(阿舜) from http://ashun.cnblogs.com/ 
    
    var arr=['猴','鸡','狗','猪','鼠','牛','虎','兔','龙','蛇','马','羊']; 
    return /^\d{4}$/.test(yyyy)?arr[yyyy%12]:null 
} 

// 取星座, 参数分别是 月份和日期 
function getxingzuo(month,day){    
    //by Go_Rush(阿舜) from http://ashun.cnblogs.com/ 
        
    var d=new Date(1999,month-1,day,0,0,0); 
    var arr=[]; 
    arr.push(["魔羯座",new Date(1999, 0, 1,0,0,0)]) 
    arr.push(["水瓶座",new Date(1999, 0,20,0,0,0)]) 
    arr.push(["双鱼座",new Date(1999, 1,19,0,0,0)]) 
    arr.push(["牡羊座",new Date(1999, 2,21,0,0,0)]) 
    arr.push(["金牛座",new Date(1999, 3,21,0,0,0)]) 
    arr.push(["双子座",new Date(1999, 4,21,0,0,0)]) 
    arr.push(["巨蟹座",new Date(1999, 5,22,0,0,0)])    
    arr.push(["狮子座",new Date(1999, 6,23,0,0,0)]) 
    arr.push(["处女座",new Date(1999, 7,23,0,0,0)]) 
    arr.push(["天秤座",new Date(1999, 8,23,0,0,0)]) 
    arr.push(["天蝎座",new Date(1999, 9,23,0,0,0)]) 
    arr.push(["射手座",new Date(1999,10,22,0,0,0)]) 
    arr.push(["魔羯座",new Date(1999,11,22,0,0,0)])        
    for(var i=arr.length-1;i>=0;i--){ 
        if (d>=arr[i][1]) return arr[i][0];    
    } 
} 

/**//* 
魔羯座(12/22 - 1/19)、水瓶座(1/20 - 2/18)、双鱼座(2/19 - 3/20)、牡羊座(3/21 - 4/20)、金牛座(4/21 - 5/20)、 
双子座(5/21 - 6/21)、巨蟹座(6/22 - 7/22)、狮子座(7/23 - 8/22)、处女座(8/23 - 9/22)、天秤座(9/23 - 10/22)、 
天蝎座(10/23 - 11/21)、射手座(11/22 - 12/21)    
*/ 