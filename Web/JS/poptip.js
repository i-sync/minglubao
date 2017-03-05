
var PopTip = {
    Type: {
        Succ: 1,
        Error: 2,
        Tips: 3
    },
    bgstatus: Number,
    centerPop: function (filed) {
        var windowWidth = document.documentElement.clientWidth;
        var windowHeight = document.documentElement.clientHeight;
        var popupHeight = $(filed).height();
        var popupWidth = $(filed).width();
        var bodyheight = $("body").height();
        var yScroll;
        if (self.pageYOffset) {
            yScroll = self.pageYOffset;
        } else if (document.documentElement && document.documentElement.scrollTop) {
            yScroll = document.documentElement.scrollTop;
        } else if (document.body) {
            yScroll = document.body.scrollTop;
        }

        $(filed).css({
            "position": "absolute",
            "top": (windowHeight / 2 - popupHeight / 2) + (yScroll),
            "left": windowWidth / 2 - popupWidth / 2
        });

        if (bodyheight < windowHeight) {
            $("#backgroundPopup").css({
                "height": windowHeight
            });
        } else {
            $("#backgroundPopup").css({
                "height": bodyheight
            });
        }
    },
    loadPop: function (filed) {
        if (this.bgstatus == 0) {
            $("#backgroundPopup").css({ "opacity": "0.6" }).show();
            $(filed).show();
            this.bgstatus = 1;
        }
    },
    disablePop: function (filed) {
        if (this.bgstatus == 1) {
            $('#backgroundPopup').hide();
            this.bgstatus = 0;
        }
        $(filed).hide();
    },
    CG: function () {
        $("#q_Msgbox").attr("isshow", "false");
        $("#q_Msgbox").remove();
    },
    Reload: function () {
        var url = location.href;
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
        location.href = url;
    },
    Jump: function (url) {
        location.href = url;
    },
    Show: function (type, msg, parameter) {
        if (type < 1 || type > 3) { return false; }
        var divTip;
        var b = $("#q_Msgbox").attr("isshow");
        if (b == "true") { return; }
        var showSecond = 1000;
        divTip = '<div id="q_Msgbox" class="qz_msgbox_layer_wrap" isshow="true"><span class="qz_msgbox_layer">';
        if (type == 1) {//成功
            divTip += '<span class="gtl_ico_succ"></span>';
        } else if (type == 2) {
            divTip += '<span class="gtl_ico_fail"></span>';
            showSecond = 2000;
        } else if (type == 3) {
            divTip += '<span class="gtl_ico_hits"></span>';
            showSecond = 2000;
        }
        divTip += msg;
        divTip += '<span class="gtl_end"></span></span></div>';
        $(document.body).append(divTip);
        PopTip.centerPop("#q_Msgbox");

        if (typeof (parameter) === "boolean") {
            if (parameter == true) {
                setTimeout(PopTip.Reload, 400);
            } else {
                setTimeout(PopTip.CG, showSecond);
            }
        }
        else if (typeof (parameter) === "string" && parameter.length > 0) {
            setTimeout(function () { PopTip.Jump(parameter); }, 400);
        }
        else {
            setTimeout(PopTip.CG, showSecond);
        }
    }
};
