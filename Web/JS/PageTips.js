//此文件必须引用jQuery类库和jQuery.cookie
var pagetips = {
    CONFIG: {
        id: null,
        cookieName: 'pagetipsshowtype',
        hasData: false,
        isGetData: false,
        isShow: true,
        POST_URL: "/enterprise/handler/tips.ashx",
        menuID: null
    },
    //获取调用JS链接所带的参数
    getMeunID: function (str, paraname) {
        var sValue = str.match(new RegExp("[?&]" + paraname + "=([^&]*)(&?)", "i"));
        if (sValue ? sValue[1] : sValue == null)
            return sValue ? sValue[1] : sValue;
    },
    //设置Cookie
    setCookie: function (str) {
        $.cookie(pagetips.CONFIG.cookieName, str, { path: "/" });
    },
    showTipsInfo: function () {
        ///显示提示信息
        if (this.CONFIG.isGetData == false) {
            var info = "";
            //请求数据提示数据
            $.ajax({
                async: false,
                type: "POST",
                url: pagetips.CONFIG.POST_URL,
                data: { key: "Tip", menuid: pagetips.CONFIG.menuID },
                success: function (result) {
                    //如何没有返回数据，把isShow=false;
                    if (result.length === 0) {
                        pagetips.CONFIG.isShow = false;
                    }
                    else {
                        $.each(result, function (i) {
                            info += "<li>" + result[i] + "</li>";
                        });
                        pagetips.CONFIG.hasData = true;
                    }
                    pagetips.CONFIG.isGetData = true;
                },
                dataType: "json"
            });
            $("#" + pagetips.CONFIG.id + " ul").html(info);
        }
        //判断是否显示
        if (pagetips.CONFIG.hasData)
            $("#" + pagetips.CONFIG.id + " .divTips").show();
    },
    init: function () {
        //获取<script >中的src属性值 获取调用JS链接所带的参数
        var s = document.getElementById("pagetipsjs").src; // 获取script的scr
        var r = pagetips.getMeunID(s, "menuid");
        pagetips.CONFIG.menuID = r;

        this.CONFIG.id = "pagetips" + parseInt(Math.random() * 1000, 10);
        var str="";
        str = '<div id="' + this.CONFIG.id + '" style="position: absolute; right: 15px; top: 55px;">';
        str += '<div class="divTips" style="float: left;display:none;">';
        str += '<div style="border: 1px solid #949695; float: left; background-color:#f2fbff;">';
        str += ' <div style="padding: 5px; float: left; font-size: 12px; line-height: 140%; width:500px;" class="redtip">';
        str += '<ul></ul>';
        str += ' </div>';
        str += ' <div style="float: left; font-size: 10px; padding: 4px;"> <a href="javascript:void(0);" style="text-decoration:none;" class="ptdel">X</a></div>';
        str += ' </div>';
        str += ' <div style="float: left; background:url(/images/tipinfobg.jpg) no-repeat; width:9px; height:13px; display:block; margin:10px -7px 0 -1px;"></div>';
        str += ' <i style="clear:both;"></i>';
        str += '</div>';
        str += '<div style="float: left;text-align:right; width:55px;"><div id="divPerson"><img src="/images/tipPerson.png" class="imgPerson" /></div>';
        str += '</div>';
        str += ' <i style="clear: both;"></i>';
        str += '</div>';
        $(document.body).append(str);

        //------------提示信息的显示与隐藏-------------                               
        $("#" + this.CONFIG.id + " div a.ptdel").click(function () {
            $("#" + pagetips.CONFIG.id + " .divTips").hide();
            pagetips.setCookie("0");
        });
        $("#" + this.CONFIG.id + " div .imgPerson").click(function () {
            var type;
            var divT = $("#" + pagetips.CONFIG.id + " .divTips");
            var flag = divT.css("display");
            if (flag == "block") {
                divT.hide();
                type = "0";
            }
            else {
                pagetips.showTipsInfo();
                type = "1";
            }
            pagetips.setCookie(type);
        });

        var isshow = $.cookie(pagetips.CONFIG.cookieName);
        if (isshow != null && isshow == "0") {
            $("#" + this.CONFIG.id + " .divTips").hide();
        }
        else {
            pagetips.showTipsInfo();
        }

    }
};
    pagetips.init();