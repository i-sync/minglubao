var YindaoTip = {
    obj: null,  //操作对象div
    overlay: null,
    index: 0,   //当前提示信息的索引
    Tips: [{ id: "1", tips: "团队模型设置（）", top: "140px", left: "12px" },    //所有提示数据
            {id: "2", tips: "团队规模设置：修改团队的上级", top: "162px", left: "10px" },
            { id: "3", tips: "用户列表（添加、修改、删除用户）", top: "184px", left: "10px" },
            { id: "4", tips: "企业信息（修改企业）", top: "196px", left: "10px" },

            { id: "5", tips: "管理设置（设置名录所属状态和属性）", top: "110px", left: "10px" },
            { id: "6", tips: "项目资料（设置企业的基本资料信息）", top: "137px", left: "10px" },
            { id: "7", tips: "名录分配", top: "166px", left: "10px" },
            { id: "8", tips: "名录查询", top: "193px", left: "10px" },
            { id: "9", tips: "业务进度", top: "397px", left: "10px" },

            { id: "10", tips: "项目资料", top: "110px", left: "10px" },
            { id: "11", tips: "名录分配", top: "137px", left: "10px" },
            { id: "12", tips: "名录查询", top: "166px", left: "10px" },
            { id: "13", tips: "业务进度", top: "371px", left: "10px" },

            { id: "14", tips: "项目资料", top: "110px", left: "10px" },
            { id: "15", tips: "个人计划", top: "137px", left: "10px" },
            { id: "16", tips: "名录管理", top: "166px", left: "10px" }
            ],
    KID: [{ kid: "1", ids: ["1", "2", "3", "4"] },  //不同角色对应的所有提示编号
             {kid: "2", ids: ["5", "6", "7", "8", "9"] },
             { kid: "3", ids: ["10", "11", "12", "13"] },
             { kid: "4", ids: ["10", "11", "12", "13"] },
             { kid: "5", ids: ["14", "15", "16"] }
             ],
    Temp: [],   //临时数据存储对应角色的所有提示信息
    Init: function (selector, kid) { //初始化数据信息
        this.obj = selector;
        var v = [];  //某角色的提示编号
        $.each(this.KID, function (i, data) {       //循环遍历查找角色提示编号
            if (data.kid == kid) {
                v = data.ids;
            }
        });
        if (v.length == 0)
            return;
        var _this = this;
        $.each(v, function (i) {    //某角色所有提示数据
            $.each(_this.Tips, function (j, data) {
                if (v[i] == data.id) {
                    _this.Temp[i] = data;
                    return false;
                }
            });
        });
        //第一条提示信息
        var first = this.Temp[0];
        //-----------显示弹出层上的基本数据信息-----------
        this.obj.find("#spanIndex").html(this.index + 1);
        this.obj.find("#spanTotal").html(this.Temp.length);
        this.obj.find("#divContent").html(first.tips);
        //-----------弹出层的位置-------------
        this.obj.css({ "top": first.top, "left": first.left });

        //添加关闭、我知道了，开始使用、下一个事件
        this.obj.find(".close").bind("click", function () {
            _this.Close();
        });
        this.obj.find("#aNext").bind("click", function () {
            _this.Next();
        });

        this.obj.show();
        this.loadOverlay();
    },
    Next: function () {  //下一个
        this.index++;
        return this.Show(this.index);
    },
    Show: function (index) {  //显示
        if (this.Temp.length == 0)
            return;
        var _this = this;
        if (index === this.Temp.length - 1) {   //如果当前提示为最后一条提示，则把“下一个”改为“关闭”，并绑定关闭事件
            $(_this.obj.find("#aNext")).html("关闭").unbind("click").removeAttr("id").bind("click", function () {
                _this.Close();
            });
        }
        var v = this.Temp[index]; //获取当前提示对象信息
        //-----------显示弹出层上的基本数据信息-----------
        this.obj.find("#spanIndex").html(index + 1);
        this.obj.find("#divContent").html(v.tips);
        //-----------弹出层的位置-------------
        this.obj.css({ "top": v.top, "left": v.left });
    },
    loadOverlay: function () {                //加载遮罩
        var pageWidth = ($.browser.version == "6.0") ? $(document).width() - 21 : $(document).width();
        this.overlay ? this.overlay.remove() : null;
        this.overlay = $(document.createElement("div"));
        this.overlay.id = "overlay";
        this.overlay.css({ position: "absolute", "z-index": 1, left: 0, top: 0, zoom: 1, display: "block", width: pageWidth, height: $(document).height() }).appendTo($(document.body)).append("<div style='position:absolute;z-index:2;width:100%;height:100%;left:0;top:0;opacity:0.2;filter:Alpha(opacity=20);background:#343030;'></div><iframe frameborder='0' src='about:blank' border='0' style='width:100%;height:100%;position:absolute;z-index:1;left:0;top:0;filter:Alpha(opacity=0);'></iframe>")
    },
    Close: function () {  //关闭
        this.obj.remove();
        this.overlay.remove();
    }
};

