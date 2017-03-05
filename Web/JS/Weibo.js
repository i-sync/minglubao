(function ($) {
    var nTextarea = $("#txtWeiboContent"),
        sSubmitBtn = $("#btnPublish"),
        aFace = $("#weibo_kind .face");

    var inputTimer = null;
    var inputTextNum = CONSTANT.INPUT_TEXT_NUM_1;
    function checkInputing() {
        inputTimer = setInterval(checkContent, 100)
    }
    function checkContent() {
        if (!nTextarea) {
            return false
        }
        var _content = $.trim($(nTextarea).val()),
            content = _content == CONSTANT.NORMAL_DEFAULT_VALUE ? "" : _content,
            len = _content.length,
            num = inputTextNum - len;
        var color = num < 0 ? "style='color:#f00;'" : "",
        str = num < 0 ? '当前已经超出<em class="pips-lim" ' + color + ">" + -num + "</em>字" : '请文明发言，还可以输入<em class="pips-lim" ' + color + ">" + num + "</em>字";
        $("#contenttextnum").html(str);
        if (len > inputTextNum || (content.length <= 0)) {
            $(sSubmitBtn).addClass("disable");
        } else {
            $(sSubmitBtn).removeClass("disable");
        }
    }
    //----表情
    function FaceShow() {//显示表情
        var weiboface = $("#weibo_layer");
        if ($(weiboface).length == 0) {
            var str = ['<div class="weibo_layer" id="weibo_layer"><div class="bg"><table cellpadding="0" cellspacing="0" border="0">', '<tr><td>', '<div class="content">', '<a title="关闭" href="javascript:void(0);" class="weibo_close"></a>', '<div><div class="layer_faces clearfix"><div class="tab W_textb"></div><div><div class="detail">', '<ul class="faces_list clearfix">', '<li action-data="[织]"><img src="/images/common/face/normal/zz2_thumb.gif" alt="织" title="织"></li><li action-data="[神马]"><img src="/images/common/face/normal/horse2_thumb.gif" alt="神马" title="神马"></li><li action-data="[浮云]"><img src="/images/common/face/normal/fuyun_thumb.gif" alt="浮云" title="浮云"></li><li action-data="[给力]"><img src="/images/common/face/normal/geili_thumb.gif" alt="给力" title="给力"></li><li action-data="[围观]"><img src="/images/common/face/normal/wg_thumb.gif" alt="围观" title="围观"></li><li action-data="[威武]"><img src="/images/common/face/normal/vw_thumb.gif" alt="威武" title="威武"></li><li action-data="[熊猫]"><img src="/images/common/face/normal/panda_thumb.gif" alt="熊猫" title="熊猫"></li><li action-data="[兔子]"><img src="/images/common/face/normal/rabbit_thumb.gif" alt="兔子" title="兔子"></li><li action-data="[奥特曼]"><img src="/images/common/face/normal/otm_thumb.gif" alt="奥特曼" title="奥特曼"></li><li action-data="[囧]"><img src="/images/common/face/normal/j_thumb.gif" alt="囧" title="囧"></li><li action-data="[互粉]"><img src="/images/common/face/normal/hufen_thumb.gif" alt="互粉" title="互粉"></li><li action-data="[礼物]"><img src="/images/common/face/normal/liwu_thumb.gif" alt="礼物" title="礼物"></li><li action-data="[呵呵]"><img src="/images/common/face/normal/smilea_thumb.gif" alt="呵呵" title="呵呵"></li><li action-data="[嘻嘻]"><img src="/images/common/face/normal/tootha_thumb.gif" alt="嘻嘻" title="嘻嘻"></li><li action-data="[哈哈]"><img src="/images/common/face/normal/laugh.gif" alt="哈哈" title="哈哈"></li><li action-data="[可爱]"><img src="/images/common/face/normal/tza_thumb.gif" alt="可爱" title="可爱"></li><li action-data="[可怜]"><img src="/images/common/face/normal/kl_thumb.gif" alt="可怜" title="可怜"></li><li action-data="[挖鼻屎]"><img src="/images/common/face/normal/kbsa_thumb.gif" alt="挖鼻屎" title="挖鼻屎"></li><li action-data="[吃惊]"><img src="/images/common/face/normal/cj_thumb.gif" alt="吃惊" title="吃惊"></li><li action-data="[害羞]"><img src="/images/common/face/normal/shamea_thumb.gif" alt="害羞" title="害羞"></li><li action-data="[挤眼]"><img src="/images/common/face/normal/zy_thumb.gif" alt="挤眼" title="挤眼"></li><li action-data="[闭嘴]"><img src="/images/common/face/normal/bz_thumb.gif" alt="闭嘴" title="闭嘴"></li><li action-data="[鄙视]"><img src="/images/common/face/normal/bs2_thumb.gif" alt="鄙视" title="鄙视"></li><li action-data="[爱你]"><img src="/images/common/face/normal/lovea_thumb.gif" alt="爱你" title="爱你"></li><li action-data="[泪]"><img src="/images/common/face/normal/sada_thumb.gif" alt="泪" title="泪"></li><li action-data="[偷笑]"><img src="/images/common/face/normal/heia_thumb.gif" alt="偷笑" title="偷笑"></li><li action-data="[亲亲]"><img src="/images/common/face/normal/qq_thumb.gif" alt="亲亲" title="亲亲"></li><li action-data="[生病]"><img src="/images/common/face/normal/sb_thumb.gif" alt="生病" title="生病"></li><li action-data="[太开心]"><img src="/images/common/face/normal/mb_thumb.gif" alt="太开心" title="太开心"></li><li action-data="[懒得理你]"><img src="/images/common/face/normal/ldln_thumb.gif" alt="懒得理你" title="懒得理你"></li><li action-data="[右哼哼]"><img src="/images/common/face/normal/yhh_thumb.gif" alt="右哼哼" title="右哼哼"></li><li action-data="[左哼哼]"><img src="/images/common/face/normal/zhh_thumb.gif" alt="左哼哼" title="左哼哼"></li><li action-data="[嘘]"><img src="/images/common/face/normal/x_thumb.gif" alt="嘘" title="嘘"></li><li action-data="[衰]"><img src="/images/common/face/normal/cry.gif" alt="衰" title="衰"></li><li action-data="[委屈]"><img src="/images/common/face/normal/wq_thumb.gif" alt="委屈" title="委屈"></li><li action-data="[吐]"><img src="/images/common/face/normal/t_thumb.gif" alt="吐" title="吐"></li><li action-data="[打哈气]"><img src="/images/common/face/normal/k_thumb.gif" alt="打哈气" title="打哈气"></li><li action-data="[抱抱]"><img src="/images/common/face/normal/bba_thumb.gif" alt="抱抱" title="抱抱"></li><li action-data="[怒]"><img src="/images/common/face/normal/angrya_thumb.gif" alt="怒" title="怒"></li><li action-data="[疑问]"><img src="/images/common/face/normal/yw_thumb.gif" alt="疑问" title="疑问"></li><li action-data="[馋嘴]"><img src="/images/common/face/normal/cza_thumb.gif" alt="馋嘴" title="馋嘴"></li><li action-data="[拜拜]"><img src="/images/common/face/normal/88_thumb.gif" alt="拜拜" title="拜拜"></li><li action-data="[思考]"><img src="/images/common/face/normal/sk_thumb.gif" alt="思考" title="思考"></li><li action-data="[汗]"><img src="/images/common/face/normal/sweata_thumb.gif" alt="汗" title="汗"></li><li action-data="[困]"><img src="/images/common/face/normal/sleepya_thumb.gif" alt="困" title="困"></li><li action-data="[睡觉]"><img src="/images/common/face/normal/sleepa_thumb.gif" alt="睡觉" title="睡觉"></li><li action-data="[钱]"><img src="/images/common/face/normal/money_thumb.gif" alt="钱" title="钱"></li><li action-data="[失望]"><img src="/images/common/face/normal/sw_thumb.gif" alt="失望" title="失望"></li><li action-data="[酷]"><img src="/images/common/face/normal/cool_thumb.gif" alt="酷" title="酷"></li><li action-data="[花心]"><img src="/images/common/face/normal/hsa_thumb.gif" alt="花心" title="花心"></li><li action-data="[哼]"><img src="/images/common/face/normal/hatea_thumb.gif" alt="哼" title="哼"></li><li action-data="[鼓掌]"><img src="/images/common/face/normal/gza_thumb.gif" alt="鼓掌" title="鼓掌"></li><li action-data="[晕]"><img src="/images/common/face/normal/dizzya_thumb.gif" alt="晕" title="晕"></li><li action-data="[悲伤]"><img src="/images/common/face/normal/bs_thumb.gif" alt="悲伤" title="悲伤"></li><li action-data="[抓狂]"><img src="/images/common/face/normal/crazya_thumb.gif" alt="抓狂" title="抓狂"></li><li action-data="[黑线]"><img src="/images/common/face/normal/h_thumb.gif" alt="黑线" title="黑线"></li><li action-data="[阴险]"><img src="/images/common/face/normal/yx_thumb.gif" alt="阴险" title="阴险"></li><li action-data="[怒骂]"><img src="/images/common/face/normal/nm_thumb.gif" alt="怒骂" title="怒骂"></li><li action-data="[心]"><img src="/images/common/face/normal/hearta_thumb.gif" alt="心" title="心"></li><li action-data="[伤心]"><img src="/images/common/face/normal/unheart.gif" alt="伤心" title="伤心"></li><li action-data="[猪头]"><img src="/images/common/face/normal/pig.gif" alt="猪头" title="猪头"></li><li action-data="[ok]"><img src="/images/common/face/normal/ok_thumb.gif" alt="ok" title="ok"></li><li action-data="[耶]"><img src="/images/common/face/normal/ye_thumb.gif" alt="耶" title="耶"></li><li action-data="[good]"><img src="/images/common/face/normal/good_thumb.gif" alt="good" title="good"></li><li action-data="[不要]"><img src="/images/common/face/normal/no_thumb.gif" alt="不要" title="不要"></li><li action-data="[赞]"><img src="/images/common/face/normal/z2_thumb.gif" alt="赞" title="赞"></li><li action-data="[来]"><img src="/images/common/face/normal/come_thumb.gif" alt="来" title="来"></li><li action-data="[弱]"><img src="/images/common/face/normal/sad_thumb.gif" alt="弱" title="弱"></li><li action-data="[蜡烛]"><img src="/images/common/face/normal/lazu_thumb.gif" alt="蜡烛" title="蜡烛"></li><li action-data="[钟]"><img src="/images/common/face/normal/clock_thumb.gif" alt="钟" title="钟"></li><li action-data="[蛋糕]"><img src="/images/common/face/normal/cake.gif" alt="蛋糕" title="蛋糕"></li><li action-data="[话筒]"><img src="/images/common/face/normal/m_thumb.gif" alt="话筒" title="话筒"></li>', '</ul>', '</div></div></div></div></div>', '</td></tr></table>', '<div node-type="arrow" class="arrow arrow_t"></div>', '</div></div>'].join("");
            $(str).appendTo("body");
        }
        else {
            $(weiboface).toggle();
        }
        if ($(weiboface).is(":hidden")) {
            ClearFaceEvents();
        }
        else {
            AddFaceEvents();
        }
    }

    function AddFaceEvents() {
        //点击关闭
        $("#weibo_layer .bg .content .weibo_close").bind("click", function (e) {
            CloseFace();
        });
        //点击表情
        $("#weibo_layer .faces_list li").bind("click", function (e) {
            var data = $(this).attr("action-data");
            $(nTextarea).val($(nTextarea).val() + data);
            CloseFace();
            return false;
        });
    }
    function CloseFace() {
        $("#weibo_layer").hide();
        ClearFaceEvents();
    }
    function ClearFaceEvents() {
        //清除表情事件
        $("#weibo_layer .bg .content .weibo_close").unbind("click");
        $("#weibo_layer .faces_list li").unbind("click");
    }
    function addNTEvents() {
        $(nTextarea).live("focus", function (e) {
            checkInputing();
        }).live("blur", function (e) {
            clearInterval(inputTimer);
            inputTimer = null
        });
        $(nTextarea).focus();

        $(aFace).live("click", function (e) {

            FaceShow();
        })
    }
    function addEvents() {
        addNTEvents();
    }
    function init() {
        addEvents()
    }
    init()
})(jQuery);