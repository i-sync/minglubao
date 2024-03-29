Function.prototype.binding = function() {
    if (arguments.length < 2 && typeof arguments[0] == "undefined") return this;
    var __method = this, args = jQuery.makeArray(arguments), object = args.shift();
    return function() {
        return __method.apply(object, args.concat(jQuery.makeArray(arguments)));
    }
}

var Class = function(subclass){
	subclass.setOptions = function(options){
		this.options = jQuery.extend({}, this.options,options);
		for(var key in options){
			if(/^on[A-Z][A-Za-z]*$/.test(key)){
				$(this).bind(key,options[key]);
			}
		}
	}
    var fn =  function(){
        if(subclass._init && typeof subclass._init == 'function'){
            this._init.apply(this,arguments);
        }
    }
    if(typeof subclass == 'object'){
        fn.prototype = subclass;
    }
    return fn;
}

var PopupLayer = new Class({
	options:{
        title:null,
		trigger:null,                            //触发的元素或id,必填参数
		popupBlk:null,                           //弹出内容层元素或id,必填参数
		closeBtn:null,                           //关闭弹出层的元素或id
		popupLayerClass:"popupLayer",            //弹出层容器的class名称
		eventType:"click",                       //触发事件的类型
		offsets:{                                //弹出层容器位置的调整值
			x:0,
			y:0
		},
		useFx:false,                             //是否使用特效
		useOverlay:true,                        //是否使用全局遮罩
		usePopupIframe:true,                     //是否使用容器遮罩
		isresize:true,                           //是否绑定window对象的resize事件
		onBeforeStart:function(){}            //自定义事件
	},
	_init:function(options){
		this.setOptions(options);                //载入设置
		this.isSetPosition = this.isDoPopup = this.isOverlay = true;    //定义一些开关
		this.popupLayer = $(document.createElement("div")).addClass(this.options.popupLayerClass);     //初始化最外层容器
        this.popupLayer.id="";
        //this.popupLayer
        this.title=this.options.title;
		this.popupIframe = $(document.createElement("iframe")).attr({border:0,frameborder:0});         //容器遮罩,用于屏蔽ie6下的select
		//this.trigger = $(this.options.trigger);                         //把触发元素封装成实例的一个属性，方便使用及理解
		this.popupBlk = $(this.options.popupBlk);                       //把弹出内容层元素封装成实例的一个属性
		//this.closeBtn = $(this.options.closeBtn);                       //把关闭按钮素封装成实例的一个属性
		//$(this).trigger("onBeforeStart");                               //执行自定义事件。
		this._construct() ;                                              //通过弹出内容层，构造弹出层，即为其添加外层容器及底层iframe
		//this.trigger.bind(this.options.eventType,function(){            //给触发元素绑定触发事件
//        	if(this.isSetPosition){
//				this.setPosition(this.trigger.offset().left + this.options.offsets.x, this.trigger.offset().top + this.trigger.get(0).offsetHeight + this.options.offsets.y);
//			}
			//this.options.useOverlay?this._loadOverlay():null;               //如果使用遮罩则加载遮罩元素
			//(this.isOverlay && this.options.useOverlay)?this.overlay.show():null;
//            this._loadOverlay();
//            this.overlay.show();
//            this._center();
//			this.popupLayer.show();					 
		//}.binding(this));
		//this.isresize?$(window).bind("resize",this.doresize.binding(this)):null;
		//this.options.closeBtn?this.closeBtn.bind("click",this.close.binding(this)):null;   //如果有关闭按钮，则给关闭按钮绑定关闭事件
        //$(".popuptitle .close").click(this.close.bind(this));
//         var _this=this;
//        $(".popuptitle .close").click(function(){
//            _this.close();
//            return false;
//        });
	},
	_construct:function(){                  //构造弹出层
		this.popupBlk.show();
        var ch=0;
        if(this.title!=null){
            //构造标题
            var divTitle=$(document.createElement("div")).addClass("popuptitle");
            var divTT=$(document.createElement("div")).addClass("title");
            $(divTT).html(this.title);
            var divClose=$(document.createElement("div")).addClass("close");
            $(divClose).html("");
            divTitle.append(divTT).append(divClose);
            var _this=this;
            $(divClose).click(function(){
                _this.close();
            });
            ch=35;
        }
		this.popupLayer.append(divTitle).append(this.popupBlk.css({opacity:1})).appendTo($(document.body)).css({position:"absolute",'z-index':2,width:this.popupBlk.get(0).offsetWidth,height:this.popupBlk.get(0).offsetHeight+ch,border:"1px solid #468ed0"});
		this.options.usePopupIframe?this.popupLayer.append(this.popupIframe):null;
		this.recalculatePopupIframe();
		this.popupLayer.hide();
	},
    _center:function(){
        var windowWidth = document.documentElement.clientWidth;
        var windowHeight = document.documentElement.clientHeight;
        var popupHeight = $(this.popupLayer).height();
        var popupWidth = $(this.popupLayer).width();
        var bodyheight = $("body").height();
        var yScroll;
        if (self.pageYOffset) {
            yScroll = self.pageYOffset;
        } else if (document.documentElement && document.documentElement.scrollTop) {
            yScroll = document.documentElement.scrollTop;
        } else if (document.body) {
            yScroll = document.body.scrollTop;
        }
        var top=(windowHeight / 2 - popupHeight)+yScroll;
        var left=windowWidth / 2 - popupWidth / 2;
        if(top<4){top=4;}
        if(left<0){left=0;}
        $(this.popupLayer).css({
            "position": "absolute",
            "top": top,
            "left": left
        });
    },
	_loadOverlay:function(){                //加载遮罩
		pageWidth = ($.browser.version=="6.0")?$(document).width()-21:$(document).width();
		this.overlay?this.overlay.remove():null;
		this.overlay = $(document.createElement("div"));
        this.overlay.id="overlay";
		this.overlay.css({position:"absolute","z-index":1,left:0,top:0,zoom:1,display:"none",width:pageWidth,height:$(document).height()}).appendTo($(document.body)).append("<div style='position:absolute;z-index:2;width:100%;height:100%;left:0;top:0;opacity:0.2;filter:Alpha(opacity=20);background:#faf9f9;'></div><iframe frameborder='0' src='about:blank' border='0' style='width:100%;height:100%;position:absolute;z-index:1;left:0;top:0;filter:Alpha(opacity=0);'></iframe>")
	},
	doresize:function(){
		this.overlay?this.overlay.css({width:($.browser.version=="6.0")?$(document).width()-21:$(document).width(),height:($.browser.version=="6.0")?$(document).height()-4:$(document).height()}):null;
		if(this.isSetPosition){
			this.setPosition(this.trigger.offset().left + this.options.offsets.x, this.trigger.offset().top + this.trigger.get(0).offsetHeight + this.options.offsets.y);
		}
	},
	setPosition:function(left,top){          //通过传入的参数值改变弹出层的位置
		this.popupLayer.css({left:left,top:top});
	},
	doEffects:function(way){                //做特效
		way == "open"?this.popupLayer.show("slow"):this.popupLayer.hide("slow");
		
	},
	recalculatePopupIframe:function(){     //重绘popupIframe,这个不知怎么改进，只好先用这个笨办法。
		this.popupIframe.css({position:"absolute",'z-index':-1,left:0,top:0,opacity:0,width:this.popupBlk.get(0).offsetWidth,height:this.popupBlk.get(0).offsetHeight});
	},
	close:function(){                      //关闭方法
		this.options.useOverlay?this.overlay.hide():null;
		this.options.useFx?this.doEffects("close"):this.popupLayer.hide();
	}
});﻿
PopupLayer.prototype.Show=function(){
    this._loadOverlay();
    this.overlay.show();
    this._center();
	this.popupLayer.show();
};
PopupLayer.prototype.PopClose=function(){
    this.close();
};