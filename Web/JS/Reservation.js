var Reservation = {
    Load: function () {
        var str = '<div id="divlogKuang">';
        str += '</div>';
        str += ' <div class="dialogBox" id="dialogBox2011">';
        str += ' <div class="dialogBox-hd">';
        str += '   <h3 class="dialogBox-hd-title">';
        str += '     预约客户提醒</h3>';
        str += '  <span class="dialogBox-hd-ext"></span>';
        str += ' </div>';
        str += ' <div class="dialogBox-bd">';
        str += '    <div class="dialogBox-simpleText">';
        str += '        <p>';
        str += '            预约客户：<a href="#" target="main">红手网络</a></p>';
        str += '        <p>';
        str += '            提醒时间：<span class="date"></span>，提前：<span class="minute"></span>分钟</p>';
        str += '    </div>';
        str += ' </div>';
        str += ' </div>';
        $(document.body).append(str);
    },
    Init: function () {
        //--定时取最新数据
        $("#divlogKuang .dialogBox-hd-ext,#divlogKuang a").live("click", function () {
            var obj = $(this).parents(".dialogBox");
            $(obj).slideUp(function () {
                $(obj).remove();
            });
        });
        setTimeout(Reservation.Reservation, 6000);
    },
    Reservation: function () {
        var nid = $("#divlogKuang").data("nid");
        nid = (nid == undefined) ? "" : nid;
        var data = "act=reservation&ids=" + nid + "&t=" + Math.random();
        $.get("/enterprise/handler/ep.ashx", data, function (data) {
            if (data.length < 1) {
                setTimeout(Reservation.Reservation, 60000);
                return false;
            }
            var aryIds = Array();
            for (var i = 0; i < data.length; i++) {
                aryIds.push(data[i].nid);
                var dialogBox2011 = $("#dialogBox2011").clone();
                $(dialogBox2011).find("a").attr("href", "/enterprise/clientinfo/track.aspx?s=reservation&ciid=" + data[i].id);
                $(dialogBox2011).find("a").html(data[i].name);
                $(dialogBox2011).find(".date").html(data[i].date);
                $(dialogBox2011).find(".minute").html(data[i].minute);
                $(dialogBox2011).removeAttr("id").prependTo("#divlogKuang");
                $(dialogBox2011).slideDown();
            }
            var nid = $("#divlogKuang").data("nid");
            if (nid == undefined) {
                nid = aryIds;
            }
            else {
                nid = nid + "," + aryIds;
            }
            $("#divlogKuang").data("nid", nid);
            setTimeout(Reservation.Reservation, 60000);
        }, "json");
    }
};
Reservation.Load();
Reservation.Init();