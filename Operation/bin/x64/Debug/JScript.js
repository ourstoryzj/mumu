



/*页面添加getClassName方法*/
function getClassName(abc) {
    if (!document.getElementsByClassName) {
        var list = document.getElementsByTagName('*');
        var arr = [];
        for (var i = 0; i < list.length; i++) {
            if (list[i].className == Trim(abc)) {
                arr.push(list[i]);
            }
        }
        return arr;
    }
    else {
        return document.getElementsByClassName(Trim(abc));
    }
}

/*检索meta标签中name属性为abc的集合*/
function getMetaName(abc) {
    var list = document.getElementsByTagName('meta');
    var arr = [];
    for (var i = 0; i < list.length; i++) {
        if (list[i].name == Trim(abc)) {
            arr.push(list[i]);
        }
    }
    return arr;
}

/* 淘宝 根据data-spm-anchor-id属性获取页面元素方法*/
function getElementsByDataID(abc) { var list = document.getElementsByTagName('*'); var arr = []; for (var i = 0; i < list.length; i++) { if (list[i].getAttribute('data-spm-anchor-id') == Trim(abc)) { arr.push(list[i]); } } return arr; }

/*根据title属性获取页面元素方法*/
function getElementsByTitle(abc) { var list = document.getElementsByTagName('*'); var arr = []; for (var i = 0; i < list.length; i++) { if (list[i].getAttribute('title') == Trim(abc)) { arr.push(list[i]); } } return arr; }

/* 淘宝 根据data-spm属性获取页面元素方法*/
function getElementsByDataSpm(abc) { var list = document.getElementsByTagName('*'); var arr = []; for (var i = 0; i < list.length; i++) { if (list[i].getAttribute('data-spm') == Trim(abc)) { arr.push(list[i]); } } return arr; }

/* 蘑菇街 根据data-reactid属性获取页面元素方法*/
function getElementsByDataReactid(abc) {
    var list = document.getElementsByTagName('*');
    var arr = [];
    for (var i = 0; i < list.length; i++) {
        if (list[i].getAttribute('data-reactid') == Trim(abc)) {
            arr.push(list[i]);
        }
    }
    return arr;
}
/*元素模拟点击方法*/
function ElementClick(node) {
    if (document.createEvent) {
        var evt = document.createEvent('MouseEvents');
        evt.initEvent('click', true, false);
        node.dispatchEvent(evt);
    } else if (document.createEventObject) {
        node.fireEvent('onclick');
    } else if (typeof node.onclick == 'function') {
        node.onclick();
    }
}
/*去掉字符串前后所有空格*/
function Trim(str) {
    return str.replace(/(^\s*)|(\s*$)/g, "");
}



/*删除某个元素*/
function removeElement(_element) {
    var _parentElement = _element.parentNode;
    if (_parentElement) {
        _parentElement.removeChild(_element);
    }
}


/*用于ie中获取offsetTop*/
function getAbsoluteOffsetTop(obj) {
    var y = obj.offsetTop;
    while (obj = obj.offsetParent) y += obj.offsetTop;
    return y;
}
/*用于ie中获取offsetLeft*/
function getAbsoluteOffsetLeft(obj) {
    var x = obj.offsetLeft;
    while (obj = obj.offsetParent) x += obj.offsetLeft;
    return x;
}

/*当页面离开时，不提示信息*/
window.onbeforeunload = function () {
    return;
}
var elements = document.getElementsByTagName('a');
for (var i = 0; i < elements.length; i++) {
    elements[i].target = '_self';
}


/*设置所有a标签在当前页面打开*/
var elements = document.getElementsByTagName('a');
for (var i = 0; i < elements.length; i++) {
    elements[i].target = '_self';
}
function SetTargetSelfByA() {
    var elements = document.getElementsByTagName('a');
    for (var i = 0; i < elements.length; i++) {
        elements[i].target = '_self';
    }
}


/*控制select选中项*/
function jsSelectItemByValue(objSelect, objItemText) {
    for (var i = 0; i < objSelect.options.length; i++) {
        if (objSelect.options[i].value == objItemText) {
            objSelect.options[i].selected = true;
            break;
        }
    }
}

/*提取现实内容的element*/
function getElementByInnerText(abc) {
    var list = document.getElementsByTagName('*');
    var arr = [];
    for (var i = 0; i < list.length; i++) {
        if (list[i].innerText == abc) {
            //alert(list[i].innerText);
            return list[i];
            //arr.push(list[i]);
        }
    }
    return arr;
}

/*[模糊查询]提取现实内容的element*/
function getElementsByInnerText2(abc) {
    var list = document.getElementsByTagName('*');
    var arr = [];
    for (var i = 0; i < list.length; i++) {
        if (list[i].innerText.indexOf(abc) != -1) {
            //return list[i];
            arr.push(list[i]);
        }
    }
    return arr;
}
function getElementsByInnerText(abc) {
    var list = document.getElementsByTagName('*');
    var arr = [];
    for (var i = 0; i < list.length; i++) {
        if (list[i].innerText == abc) {
            //return list[i];
            arr.push(list[i]);
        }
    }
    return arr;
}






///////////////   拼多多客服系统   ///////////////////////////////////////////////////////////////////////////////
/*
//成功案例
function simulateClick() {
    //点击位置为屏幕中间
    //var sx= window.innerWidth/2,sy= window.innerHeight/2,cx= sx,cy=sy;
    var eventDown = document.createEvent("MouseEvents");
    eventDown.initMouseEvent("mousedown", true, true, window, 0,
        0, 0, 0, 0, false, false, false, false, 0, null);
    var eventUp = document.createEvent("MouseEvents");
    eventUp.initMouseEvent("mouseup", true, true, window, 0,
        0, 0, 0, 0, false, false, false, false, 0, null);
    document.getElementsByClassName('chat-item-box transition')[0].dispatchEvent(eventDown);
    document.getElementsByClassName('chat-item-box transition')[0].dispatchEvent(eventUp);
}
*/
/*
//测试简单方法--成功
var event1 = document.createEvent("MouseEvents");
event1.initEvent('mousedown', true, false);
var event2 = document.createEvent("MouseEvents");
event2.initEvent('mouseup', true, false);
document.getElementsByClassName('chat-item-box transition')[0].dispatchEvent(event1);
document.getElementsByClassName('chat-item-box transition')[0].dispatchEvent(event2);
*/

/*元素模拟点击（鼠标按下，起来）方法*/
function ElementClickPDD(node) {
    if (document.createEvent) {
        var event1 = document.createEvent("MouseEvents");
        event1.initEvent('mousedown', true, false);
        var event2 = document.createEvent("MouseEvents");
        event2.initEvent('mouseup', true, false);
        node.dispatchEvent(event1);
        node.dispatchEvent(event2);
    } else if (document.createEventObject) {
        node.fireEvent('onclick');
    } else if (typeof node.onclick == 'function') {
        node.onclick();
    }
}



//模拟键盘输入--失败

/*
function fireKeyEvent(el, evtType, keyCode) {
    var doc = el.ownerDocument,
		win = doc.defaultView || doc.parentWindow,
		evtObj;
    if (doc.createEvent) {
        if (win.KeyEvent) {
            evtObj = doc.createEvent('KeyEvents');
            evtObj.initKeyEvent(evtType, true, true, win, false, false, false, false, keyCode, 0);
        }
        else {
            evtObj = doc.createEvent('UIEvents');
            Object.defineProperty(evtObj, 'keyCode', {
                get: function () { return this.keyCodeVal; }
            });
            Object.defineProperty(evtObj, 'which', {
                get: function () { return this.keyCodeVal; }
            });
            evtObj.initUIEvent(evtType, true, true, win, 1);
            evtObj.keyCodeVal = keyCode;
            if (evtObj.keyCode !== keyCode) {
                console.log("keyCode " + evtObj.keyCode + " 和 (" + evtObj.which + ") 不匹配");
            }
        }
        el.dispatchEvent(evtObj);
    }
    else if (doc.createEventObject) {
        evtObj = doc.createEventObject();
        evtObj.keyCode = keyCode;
        el.fireEvent('on' + evtType, evtObj);
    }
}


function fireKeyEvent(evtType, keyCode) {
    var el = document.getElementById('replyTextarea');
    var evtObj;
    if (document.createEvent) {
        if (window.KeyEvent) {//firefox 浏览器下模拟事件
            evtObj = document.createEvent('KeyEvents');
            evtObj.initKeyEvent(evtType, true, true, window, true, false, false, false, keyCode, 0);
        } else {//chrome 浏览器下模拟事件
            evtObj = document.createEvent('UIEvents');
            evtObj.initUIEvent(evtType, true, true, window, 1);

            delete evtObj.keyCode;
            if (typeof evtObj.keyCode === "undefined") {//为了模拟keycode
                Object.defineProperty(evtObj, "keyCode", { value: keyCode });
            } else {
                evtObj.key = String.fromCharCode(keyCode);
            }

            if (typeof evtObj.ctrlKey === 'undefined') {//为了模拟ctrl键
                Object.defineProperty(evtObj, "ctrlKey", { value: true });
            } else {
                evtObj.ctrlKey = true;
            }
        }
        el.dispatchEvent(evtObj);

    } else if (document.createEventObject) {//IE 浏览器下模拟事件
        evtObj = document.createEventObject();
        evtObj.keyCode = keyCode
        el.fireEvent('on' + evtType, evtObj);
    }
}

var testPassword = "181818";
var tp;
var cCode;
var testss = document.getElementById("input_txt_50531_740884");
for (var i = 0; i < testPassword.length; i++) {
    cCode = testPassword.charCodeAt(i);
    fireKeyEvent(testss, "keydown", cCode);
    fireKeyEvent(testss, "keypress", cCode);
    fireKeyEvent(testss, "keyup", cCode);
}


*/

//根据分析页面，总结出可能是用js 复制粘贴到输入框
function Copy() {
    var content = document.getElementById('test');
    content.select();
    document.execCommand('Copy');
    alert('复制成功');
}

function Paste() {
    var content = document.getElementById('test');
    content.select();
    document.execCommand('Paste');
}


///////////////   拼多多客服系统   ///////////////////////////////////////////////////////////////////////////////


