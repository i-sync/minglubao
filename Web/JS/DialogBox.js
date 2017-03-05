var ClassDB = function (subclass) {
    subclass.setOptions = function (options) {
        this.options = jQuery.extend({}, this.options, options);
        for (var key in options) {
            if (/^on[A-Z][A-Za-z]*$/.test(key)) {
                $(this).bind(key, options[key]);
            }
        }
    }
    var fn = function () {
        if (subclass._init && typeof subclass._init == 'function') {
            this._init.apply(this, arguments);
        }
    }
    if (typeof subclass == 'object') {
        fn.prototype = subclass;
    }
    return fn;
};

var DialogBox = new ClassDB({
    options: {
        id: null,
        title: null,
        content: null
    },
    _init: function (options) {
        this.options.id = options.id;
        this.options.title = options.title;

    },
    _create: function () {
        var divdb = document.createElement("div");
        divdb.class = "dialogBox";
//        var divtitle = document.createElement("div");
//        divtitle.class = "dialogBox-hd";
//        divdb.appendChild(divtitle);
//        var h3title = document.createElement("h3");
//        h3title.class = "dialogBox-hd-title";
//        h3title.innerHTML = this.options.title;
//        var spanclose = document.createAttribute("span");
//        spanclose.class = "dialogBox-hd-ext";
//        divtitle.appendChild(h3title);
//        divtitle.appendChild(spanclose);
//        var divk = document.createElement("div");
//        divk.class = "dialogBox-bd";
//        divdb.appendChild(divk);
//        var divtxt = document.createElement("div");
//        divtxt.class = "dialogBox-simpleText";
//        divtxt.innerHTML = this.options.content;
        //        divk.appendChild(divtxt);
        alert(divdb);
        $(divdb).prependTo("#" + this.options.id);
        $(divdb).show();
        $(divdb).slideDown();

    }
});
DialogBox.prototype.NewBox = function (title, html) {
    this.options.title = title ? this : this.options.title;
    this.options.content = html;
    this._create();
};