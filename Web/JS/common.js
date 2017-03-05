/**
* 使用jQuery 版本:1.6.4
*
* Copyright 2011 qipengfei [ qipengfei87@163.com ] 
* 
*/
(function (jQuery) {
    $.extend({
        IsNullOrEmpty: function (str) {
            //判断str是否为空
            if ($.trim(str).length == 0) {
                return true;
            }
            return false;
        },
        IsEmail: function (str) {
            //判断是否为邮箱格式
            var result = str.match(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/);
            if (result == null) return false;
            return true;
        },
        IsTel: function (str) {
            //匹配国内电话号码(0511-4405222 或 021-87888822)
            //var result = str.match(/\d{3}-\d{8}|\d{4}-\d{7}/);
            var result = str.match(/^(0[0-9]{2,3}\-)?([2-9][0-9]{6,7})+(\-[0-9]{1,4})?$/);
            if (result == null) return false;
            return true;
        },
        IsMobile: function (str) {
            //判断是否为手机号码
            var result = str.match(/^1(3|5|8)+\d{9}$/);
            if (result == null) return false;
            return true;
        },
        IsNumber: function (str) {
            //判断是否是一个数字--(数字包含小数)--
            return !isNaN(str);
        },
        IsInt: function (str) {
            //判断是否为整数
            var result = str.match(/^\d+$/);
            if (result == null) return false;
            return true;
        },
        IsFloat: function (str) {
            if (str == "")
                return false;
            //判断是否为浮点数
            var result = str.match(/^[+|-]?\d*\.?\d*$/);
            if (result == null) return false;
            return true;
        },
        IsDate: function (str) {
            //判断输入是否是有效的长日期格式 - "YYYY-MM-DD" || "YYYY/MM/DD"
            var result = str.match(/^(\d{4})(-|\/)(\d{1,2})\2(\d{1,2})$/);
            if (result == null) return false;
            var d = new Date(result[1], result[3] - 1, result[4]);
            return (d.getFullYear() == result[1] && (d.getMonth() + 1) == result[3] && d.getDate() == result[4]);
        },
        CompareDate: function (start, end) {
            //比较两个日期的大小
            if (start < end) {
                return true;
            }
            return false;
        },
        CheckAllOperate: function (cbAll, cbItem) {
            /// <summary>
            /// 绑定全选与取消全选
            /// </summary>
            //----全选项
            $("" + cbAll + "").live("click", function () {
                var checked = $(this).is(":checked");
                $(cbItem).each(function () {
                    $(this).attr("checked", checked);
                });
            });
            //----普通选项
            $("" + cbItem + "").live("click", function () {
                var objList = $(cbItem);
                $(cbAll).attr("checked", ($(objList).length == $(objList).filter(":checked").length));
            });
        },
        GetQueryString: function (name) {
            /// <summary>
            /// 获取URL中参数值
            /// </summary>
            var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)");
            var r = window.location.search.substr(1).match(reg);
            if (r != null) return unescape(r[2]); return null;
        },
        Hover: function (selector) {
            ///<summary>
            ///hover样式
            ///</summary>
            $(selector).live("mouseover", function () {
                $(this).addClass("over");
            }).live("mouseout", function () {
                $(this).removeClass("over");
            });
        },
        TransferCharForXML: function (str) {
            var res = str.replace(
		        /&|\x3E|\x3C|\x5E|\x22|\x27|[\x00-\x1F]|\t/g,
		        function (s) {
		            var ascii = s.charCodeAt(0)
		            return "&#" + ascii.toString(10) + ";";
		        }
	        );
            return res;
        }
    });
})($);
//--------------自写义属性------------
String.prototype.format = function () {
    var args = arguments;
    return this.replace(/\{(\d+)\}/g, function (m, i) { return args[i]; });
};
function JS_cruel_search(data, key)       /*JS暴虐查找*/
{
    re = new RegExp(key, [""])
    return (data.toString().replace(re, "┢").replace(/[^,┢]/g, "")).indexOf("┢");
};
Array.prototype.del = function (item) {
    var i = JS_cruel_search(this, item);
    if (i >-1) {
        this.splice(i, 1);
    }
};
/// <summary>
/// 打开指定大小位置的模式对话框
/// </summary>
/// <param name="webFormUrl">连接地址</param>
/// <param name="width">宽</param>
/// <param name="height">高</param>
/// <param name="top">距离上位置</param>
/// <param name="left">距离左位置</param>
function ShowModalDialogWindow(webFormUrl, width, height, top, left) {
    var features = "dialogWidth:" + width.toString() + "px"
        + ";dialogHeight:" + height.toString() + "px"
        + ";dialogLeft:" + left.toString() + "px"
        + ";dialogTop:" + top.toString() + "px"
        + ";center:yes;help=no;resizable:no;status:no;scroll=yes";
    return ShowModalDialogWindow1(webFormUrl, features);
}
function ShowModalDialogWindow1(webFormUrl, features) {
    return window.showModalDialog(webFormUrl, 'window', features);
}
function URLPlusRandom(url) {
    ///<summary>
    ///给url增加随机数
    ///</summary>
    //去#号之后 及之前的参数
    if (url.indexOf("#") > 0) {
        url = url.replace(/\#\w*/g, "");
    }

    if (url.indexOf("t=") > -1) {
        url = url.replace(/(\?|\#)t=0\.\w*/g, "");
    }
    //判断?是否存在
    if (url.indexOf("?") > -1) {//存在
        url = url + "&t=" + Math.random();
    } else {//不存在
        url = url + "?t=" + Math.random();
    }
    return url;
}
function reload() {
    ///<summary>
    ///重新加载页面
    ///</summary>
    location.href = URLPlusRandom(location.href);
}
