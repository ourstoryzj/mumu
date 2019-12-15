// JScript 文件

// text获取失去焦点后文本消失显示
function to_write(txt, val) {
    if (txt.value == val) {
        txt.value = "";
    }
    txt.style.color = "#333333";
    txt.style.fontWeight = "100";
}
function to_move(txt, val) {
    if (txt.value == "") {
        txt.value = val;
        txt.style.color = "#999999";
        /*txt.style.fontWeight="bold";*/
    }
}


//收藏本站
function AddFavorite(sURL, sTitle) {

    try {
        window.external.addFavorite(sURL, sTitle);
    }
    catch (e) {
        try {
            window.sidebar.addPanel(sTitle, sURL, "");
        }
        catch (e) {
            alert("加入收藏失败，请使用Ctrl+D进行添加");
        }
    }
}


//设为主页
function SetHome(obj, vrl) {
    try {
        obj.style.behavior = 'url(#default#homepage)'; obj.setHomePage(vrl);
    }
    catch (e) {
        if (window.netscape) {
            try {
                netscape.security.PrivilegeManager.enablePrivilege("UniversalXPConnect");
            }
            catch (e) {
                alert("此操作被浏览器拒绝！\n请在浏览器地址栏输入'about:config'并回车\n然后将[signed.applets.codebase_principal_support]设置为’true’");
            }
            var prefs = Components.classes['@mozilla.org/preferences-service;1'].getService(Components.interfaces.nsIPrefBranch);
            prefs.setCharPref('browser.startup.homepage', vrl);
        }
    }
}










///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/*GridView多选*/
/*页面编码规范
<asp:TemplateField HeaderText="&lt;input type='checkbox' id='chk' name='chk' onclick='checkJs(this.checked);'/&gt;">
    <ItemTemplate>
        <input type="checkbox" id="checkboxname" name="checkboxname" value='<%# DataBinder.Eval(Container.DataItem, "fx_id")%>'
            onclick='SingleCheckJs();' style="height: 12; width: 12" />
    </ItemTemplate>
    <ItemStyle Width="25" />
</asp:TemplateField>
*/

// 只有全部选中时“全选”选中
function SingleCheckJs() {
    var flag1 = false;
    var flag2 = false;

    if (document.form1.checkboxname.length) {
        for (var i = 0; i < document.form1.checkboxname.length; i++) {
            if (document.form1.checkboxname[i].checked)
                flag1 = true;
            else
                flag2 = true;
        }
    }
    else {
        if (document.form1.checkboxname.checked)
            flag1 = true;
        else
            flag2 = true;
    }
    if (flag1 == true && flag2 == false)
        document.getElementById("chk").checked = true;
    else
        document.getElementById("chk").checked = false;
}

// 判断多选是否与选中项（没有选中的返回false）

function slcNo_click() {
    if (!confirm('确定要删除么?')) {
        return false;
    }
    if (document.form1.checkboxname.length) {
        for (var i = 0; i < document.form1.checkboxname.length; i++) {
            if (document.form1.checkboxname[i].checked) {
                return true;
            }
        }
    }
    else {
        if (document.form1.checkboxname.checked) {
            return true;
        }
    }
    alert("请选择后再操作！");
    return false;
}

// 多选的全选与取消
function checkJs(boolvalue) {
    if (document.all.checkboxname.length > 1) {
        for (var i = 0; i < document.all.checkboxname.length; i++) {
            document.all.checkboxname[i].checked = boolvalue;
        }
    }
    else {
        document.all.checkboxname.checked = boolvalue;
    }
    document.all.chk.checked = boolvalue;
}
//确认是否批量操作
function to_batch_do() {
    if (confirm("确定要执行此操作么?")) {
        if (document.all.checkboxname.length > 1) {
            for (var i = 0; i < document.all.checkboxname.length; i++) {
                if (document.all.checkboxname[i].checked == true) {
                    return true;
                }
            }
        }
        alert("请选择要处理的数据");
    }
    return false;
}
///////////////////////////////////////////////////////////////////////////////////////////////////////////



//previewImg 图片预览方法
//参数说明：
//div_id:图片容器元素ID
//img_id:原始图片ID
//img_id2:设置预览图片ID,ID随意设置,不同即可
//w:图片最大宽度
//h:图片最大高度
//e:事件源
function previewImg(div_id, img_id, img_id2, w, h, e) {
    if (!window.File && !window.FileList && !window.FileReader && !window.Blob) {
        alert("您的浏览器不支持图片预览");
        return;
    }
    document.getElementById(img_id).style.display = "none";
    e = e || window.event;
    var files = e.target.files;  //FileList Objects
    var ireg = /image\/.*/i,
            p = document.getElementById(div_id);
    for (var i = 0, f; f = files[i]; i++) {

        if (!f.type.match(ireg)) {
            //设置错误信息
            alert(f.name + '不是图片文件');
            continue;
        }
        var reader = new FileReader();
        reader.onload = (function (file) {
            return function (e) {
                var temp_img2 = document.getElementById(img_id2);
                if (temp_img2 != null) {
                    $('#' + img_id2).remove();
                }
                var temp_img3 = document.getElementById(img_id2);
                var span = document.createElement('span');
                span.innerHTML = '<img id="' + img_id2 + '" src="' + this.result + '" alt="' + file.name + '" />';
                p.insertBefore(span, null);
                setImgSize(img_id2, w, h);
            };
        })(f);
        //读取文件内容
        reader.readAsDataURL(f);
    }
}
//setImgSize 图片自适应图片宽度和高度
//参数说明：
//img_id:图片ID
//w:图片最大宽度
//h:图片最大高度
function setImgSize(img_id, w, h) {
    w = w - 10;
    h = h - 10;
    var temp_img = document.getElementById(img_id);
    var ww = temp_img.offsetWidth;
    var hh = temp_img.offsetHeight;
    if (ww / hh >= w / h) {
        if (ww > w) {
            temp_img.width = w;
            temp_img.height = (hh * w) / ww;
        } else {
            temp_img.width = ww;
            temp_img.height = hh;
        }
        temp_img.alt = "点击查看详细信息...";
    }
    else {
        if (hh > h) {
            temp_img.height = h;
            temp_img.width = (ww * h) / hh;
        } else {
            temp_img.width = ww;
            temp_img.height = hh;
        }
        temp_img.alt = "点击查看详细信息...";
    }
}




//为TextBox指定回车时执行的LinkButton按钮事件

// Sunny D.D at 2010-8-10

// sunny19788989@gmail.com

function enterPressExecuteLinkButtonAction(textBoxID, buttonID) {

    if (event.keyCode == 13) {

        var func = new Function(document.getElementById(buttonID).href.slice(11));

        func();

        event.returnValue = false;

    }

}

//为TextBox指定回车时执行的Button按钮事件

// Sunny D.D at 2010-8-10

// sunny19788989@gmail.com

function enterPressExecuteButtonAction(textBoxID, buttonID) {

    if (event.keyCode == 13) {

        var func = document.getElementById(buttonID).click;

        func();

        event.returnValue = false;

    }

}




//获取Cookie name为Cookie的名称
/*
function getCookie(name) 
{
var bikky = document.cookie;
name += "=";
var i = 0; 
while (i < bikky.length) 
{
var offset = i + name.length;
if (bikky.substring(i, offset) == name) 
{ 
var endstr = bikky.indexOf(";", offset); 
if (endstr == -1) endstr = bikky.length;
return unescape(bikky.substring(offset, endstr)); 
}
i = bikky.indexOf(" ", i) + 1; 
if (i == 0) break; 
}
return null; 
}

function GetCookie(name)
//获得Cookie的原始值
{
var arg = name + "=";
var alen = arg.length;
var clen = documents.cookie.length;
var i = 0;
while (i < clen)
{
var j = i + alen;
if (documents.cookie.substring(i, j) == arg)
return GetCookieVal (j);
i = documents.cookie.indexOf(" ", i) + 1;
if (i == 0) break;
}
return null;
}

function GetCookieVal(offset)
//获得Cookie解码后的值
{
var endstr = documents.cookie.indexOf (";", offset);
if (endstr == -1)
endstr = documents.cookie.length;
return unescape(documents.cookie.substring(offset, endstr));
}
function SetCookie(name, value)
//设定Cookie值
{
var expdate = new Date();
var argv = SetCookie.arguments;
var argc = SetCookie.arguments.length;
var expires = (argc > 2) ? argv[2] : null;
var path = (argc > 3) ? argv[3] : null;
var domain = (argc > 4) ? argv[4] : null;
var secure = (argc > 5) ? argv[5] : false;
if(expires!=null) expdate.setTime(expdate.getTime() + ( expires * 1000 ));
documents.cookie = name + "=" + escape (value) +((expires == null) ? "" : ("; expires="+ expdate.toGMTString()))
+((path == null) ? "" : ("; path=" + path)) +((domain == null) ? "" : ("; domain=" + domain))
+((secure == true) ? "; secure" : "");
}
function DelCookie(name)
//删除Cookie
{
var exp = new Date();
exp.setTime (exp.getTime() - 1);
var cval = GetCookie (name);
documents.cookie = name + "=" + cval + "; expires="+ exp.toGMTString();
}
*/








//js 容错
/*
function killErrors() {

return true;

}
window.onerror = killErrors;
*/




//间歇滚动特效 obj:id,lh:行高
function startmarquee(obj, lh, speed, delay) {
    var p = false;
    var t;
    var o = document.getElementById(obj);
    o.innerHTML += o.innerHTML;
    o.style.marginTop = 0;
    o.onmouseover = function () { p = true; }
    o.onmouseout = function () { p = false; }
    function start() {
        t = setInterval(scrolling, speed);
        if (!p) o.style.marginTop = parseInt(o.style.marginTop) - 1 + "px";
    }
    function scrolling() {
        if (parseInt(o.style.marginTop) % lh != 0) {
            o.style.marginTop = parseInt(o.style.marginTop) - 1 + "px";
            if (Math.abs(parseInt(o.style.marginTop)) >= o.scrollHeight / 2) o.style.marginTop = 0;
        }
        else {
            clearInterval(t);
            setTimeout(start, delay);
        }
    }
    setTimeout(start, delay);
}










//回车事件 onkeydown事件
function enter(id) {
    if (event.which || event.keyCode) {
        if ((event.which == 13) || (event.keyCode == 13)) {

            document.getElementById(id).click();

        }
    }
}







//过滤html标签
function CleanWord(html) {
    html = REReplaceNocase(html, '<o:p>\s*<\/o:p>', '', 'all');
    html = REReplaceNocase(html, '<o:p>.*?<\/o:p>', ' ', 'all');
    html = REReplaceNocase(html, '\s*mso-[^:]+:[^;"]+;?', '', 'all');
    html = REReplaceNocase(html, '\s*MARGIN: 0cm 0cm 0pt\s*;', '', 'all');
    html = REReplaceNocase(html, '\s*MARGIN: 0cm 0cm 0pt\s*"', '\"', 'all');
    html = REReplaceNocase(html, '\s*TEXT-INDENT: 0cm\s*;', '', 'all');
    html = REReplaceNocase(html, '\s*TEXT-INDENT: 0cm\s*"', '\"', 'all');
    html = REReplaceNocase(html, '\s*TEXT-ALIGN: [^\s;]+;?"', '\"', 'all');
    html = REReplaceNocase(html, '\s*PAGE-BREAK-BEFORE: [^\s;]+;?"', '\"', 'all');
    html = REReplaceNocase(html, '\s*FONT-VARIANT: [^\s;]+;?"', '\"', 'all');
    html = REReplaceNocase(html, '\s*tab-stops:[^;"]*;?', '', 'all');
    html = REReplaceNocase(html, '\s*tab-stops:[^"]*', '', 'all');
    html = REReplaceNocase(html, '\s*face="[^"]*"', '', 'all');
    html = REReplaceNocase(html, '\s*face=[^ >]*', '', 'all');
    html = REReplaceNocase(html, '\s*FONT-FAMILY:[^;"]*;?', '', 'all');
    html = REReplaceNocase(html, '<(\w[^>]*) class=([^ |>]*)([^>]*)', '<\1', 'all');
    html = REReplaceNocase(html, '<(\w[^>]*) style="([^\"]*)"([^>]*)', '<\1', 'all');
    html = REReplaceNocase(html, '\s*style="\s*"', '', 'all');
    html = REReplaceNocase(html, '<SPAN\s*[^>]*>\s* \s*<\/SPAN>', ' ', 'all');
    html = REReplaceNocase(html, '<SPAN\s*[^>]*><\/SPAN>', '', 'all');
    html = REReplaceNocase(html, '<(\w[^>]*) lang=([^ |>]*)([^>]*)', '<\1', 'all');
    html = REReplaceNocase(html, '<SPAN\s*>(.*?)<\/SPAN>', '\1', 'all');
    html = REReplaceNocase(html, '<FONT\s*>(.*?)<\/FONT>', '\1', 'all');
    html = REReplaceNocase(html, '<\\?\?xml[^>]*>', '', 'all');
    html = REReplaceNocase(html, '<\/?\w+:[^>]*>', '', 'all');
    html = REReplaceNocase(html, '<H\d>\s*<\/H\d>', '', 'all');
    html = REReplaceNocase(html, '<H1([^>]*)>', '<div\1><b><font size="6">', 'all');
    html = REReplaceNocase(html, '<H2([^>]*)>', '<div\1><b><font size="5">', 'all');
    html = REReplaceNocase(html, '<H3([^>]*)>', '<div\1><b><font size="4">', 'all');
    html = REReplaceNocase(html, '<H4([^>]*)>', '<div\1><b><font size="3">', 'all');
    html = REReplaceNocase(html, '<H5([^>]*)>', '<div\1><b><font size="2">', 'all');
    html = REReplaceNocase(html, '<H6([^>]*)>', '<div\1><b><font size="1">', 'all');
    html = REReplaceNocase(html, '<\/H\d>', '</font></b></div>', 'all');
    html = REReplaceNocase(html, '<(U|I|STRIKE)> <\/\1>', ' ', 'all');
    html = REReplaceNocase(html, '<([^\s>]+)[^>]*>\s*<\/\1>', '', 'all');
    html = REReplaceNocase(html, '<([^\s>]+)[^>]*>\s*<\/\1>', '', 'all');
    html = REReplaceNocase(html, '<([^\s>]+)[^>]*>\s*<\/\1>', '', 'all');
    html = REReplaceNocase(html, '(<P)([^>]*>.*?)(<\/P>)', '<div\2</div>', 'all');
    return html;
}






//简介内容超出部分文字隐藏省略的特效(可显示)
function show_text(id, num) {
    var o = document.getElementById(id);
    var s = o.innerHTML;
    var p = document.createElement("span");
    var n = document.createElement("a");
    p.innerHTML = s.substring(0, num);
    n.innerHTML = s.length > num ? "..." : "";
    n.href = "###";
    n.onclick = function () {
        if (n.innerHTML == "...") {
            n.innerHTML = " &nbsp;&nbsp;-";
            p.innerHTML = s;
        } else {
            n.innerHTML = "...";
            p.innerHTML = s.substring(0, num);
        }
    }
    o.innerHTML = "";
    o.appendChild(p);
    o.appendChild(n);
}



//计算字符串长度,中文为2

function len(s) {
    var l = 0;
    var a = s.split("");
    for (var i = 0; i < a.length; i++) {
        if (a[i].charCodeAt(0) < 299) {
            l++;
        } else {
            l += 2;
        }
    }
    return l;
}

//text选中
function txt_select(txt) {
    txt.select();
}



/*
判断是否是Email
*/
function isEmail(str) {
    var reg = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/;
    return reg.test(str);
}

/*
判断是否是手机号码
*/
function isPhone(str) {
    var reg = /^1[3|5][0-9]\d{4,8}$/;
    return reg.test(str);
}

/*
判断是否为中文
*/
//function isChinese(str){ 
//    var badChar ="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"; 
//    badChar += " "+"　";//半角与全角空格 
//    badChar += "`~!@#$%^&()-_=+]\\|:;\"\\'<,>?/";//不包含*或.的英文符号 
//    if(""==str){ 
//        return false; 
//    } 
//    for(var i=0 ; i < str.length ; i++)
//    {
//        var c = str.charAt(i);//字符串str中的字符 
//        if(badChar.indexOf(c) > -1){ 
//            return false; 
//    }  
//    return true; 
//} 

function ischinese(s) {
    var ret = true;
    for (var i = 0; i < s.length; i++)
        ret = ret && (s.charCodeAt(i) >= 10000);
    return ret;
}

/*
判断是否有中文
*/
function hasChinese(str) {
    var badChar = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
    badChar += " " + "　"; //半角与全角空格 
    badChar += "`~!@#$%^&()-_=+]\\|:;\"\\'<,>?/"; //不包含*或.的英文符号 
    if ("" == str) {
        return false;
    }
    for (var i = 0; i < str.length; i++) {
        var c = str.charAt(i); //字符串str中的字符 
        var index = badChar.indexOf(c);
        if (!index == -1) {
            return true;
        }
    }
    return false;
}



/*
返回,或前进
*/
function go(num) {
    history.go(num);
}

/*
页面跳转
*/
function pageto(url) {
    if (url == "") {
        window.location.href = window.location.href;
    }
    else {
        window.location.href = url;
    }
}


/*
判断是否是日期 验证时间格式  YYYY-MM-DD/YYYY,MM,DD   
*/
function isDate(date) {
    var regu = "^[0-9]{4}-([0-1]?)[0-9]{1}-([0-3]?)[0-9]{1}$";
    var re = new RegExp(regu);
    if (date.search(re) != -1)
        return true;
    else
        return false;
}   