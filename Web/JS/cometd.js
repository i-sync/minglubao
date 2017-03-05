/*cometd.js*/
(function (a) {
    if (typeof dojo !== "undefined") {
        dojo.provide("org.cometd")
    } else {
        window.org = this.org || {};
        org.cometd = {}
    }
    org.cometd.JSON = {};
    org.cometd.AJAX = {};
    org.cometd.JSON.toJSON = org.cometd.JSON.fromJSON = org.cometd.AJAX.send = function (b) {
        throw "Abstract"
    };
    org.cometd.Cometd = function (T) {
        var ad = T || "default";
        var at;
        var ae;
        var D;
        var ab;
        var N;
        var Y;
        var b = false;
        var u;
        var C = "disconnected";
        var ah = 0;
        var Z = null;
        var V = 0;
        var ac = [];
        var c = {};
        var S = 0;
        var X = null;
        var M = [];
        var G = {};
        var h;
        var B = false;
        function J() {
            return ad
        }
        function W(aA, aF, aE) {
            var az = aF || {};
            for (var aC = 2; aC < arguments.length; ++aC) {
                var aB = arguments[aC];
                if (aB === undefined || aB === null) {
                    continue
                }
                for (var aD in aB) {
                    var aG = aB[aD];
                    if (aG === aF) {
                        continue
                    }
                    if (aG === undefined) {
                        continue
                    }
                    if (aA && typeof aG === "object" && aG !== null) {
                        az[aD] = W(aA, az[aD], aG)
                    } else {
                        az[aD] = aG
                    }
                }
            }
            return az
        }
        function O(aA, aB) {
            for (var az = 0; az < aB.length; ++az) {
                if (aA == aB[az]) {
                    return az
                }
            }
            return -1
        }
        function H(aA, az) {
            if (window.console) {
                window.console[aA].apply(window.console, az)
            }
        }
        function e() {
            H("warn", arguments)
        }
        this._warn = e;
        function n() {
            if (at != "warn") {
                H("info", arguments)
            }
        }
        this._info = n;
        function ay() {
            if (at == "debug") {
                H("debug", arguments)
            }
        }
        this._debug = ay;
        function k() {
            return W({},
			new org.cometd.Transport("long-polling"), new org.cometd.LongPollingTransport())
        }
        function z() {
            return W({},
			new org.cometd.Transport("callback-polling"), new org.cometd.CallbackPollingTransport(ad))
        }
        function an(aA) {
            var az = aA.supportedConnectionTypes;
            if (b) {
                if (O("callback-polling", az) >= 0) {
                    return u
                }
            } else {
                if (O("long-polling", az) >= 0) {
                    return u
                }
                if (O("callback-polling", az) >= 0) {
                    return z()
                }
            }
            return null
        }
        function aw(aA) {
            ay("Configuring cometd object with", aA);
            if (typeof aA === "string") {
                aA = {
                    url: aA
                }
            }
            if (!aA) {
                aA = {}
            }
            ae = aA.url;
            if (!ae) {
                throw "Missing required configuration parameter 'url' specifying the comet server URL"
            }
            D = aA.maxConnections || 2;
            ab = aA.backoffIncrement || 1000;
            N = aA.maxBackoff || 60000;
            at = aA.logLevel || "info";
            Y = aA.reverseIncomingExtensions !== false;
            var az = /(^https?:)?(\/\/(([^:\/\?#]+)(:(\d+))?))?([^\?#]*)/.exec(ae);
            if (az[3]) {
                b = az[3] != window.location.host;
                b = true;
            }
            if (b) {
                u = z();
            } else {
                u = k();
            }
            ay("Initial transport is", u)
        }
        function t() {
            for (var aB in c) {
                var aC = c[aB];
                for (var az = 0; az < aC.length; ++az) {
                    var aA = aC[az];
                    if (aA && aA.subscription) {
                        delete aC[az];
                        ay("Removed subscription", aA, "for channel", aB)
                    }
                }
            }
        }
        function ax(az) {
            ay("Status", C, "->", az);
            C = az
        }
        function aj() {
            return C == "disconnecting" || C == "disconnected"
        }
        function f() {
            return ++ah
        }
        function aq(aA, aC, aB) {
            try {
                return aC(aB)
            } catch (az) {
                ay("Exception during execution of extension", aA, az);
                return aB
            }
        }
        function y(aC) {
            for (var aB = 0; aB < M.length; ++aB) {
                if (aC === undefined || aC === null) {
                    break
                }
                var aA = Y ? M.length - 1 - aB : aB;
                var aE = M[aA];
                var aD = aE.extension.incoming;
                if (aD && typeof aD === "function") {
                    var az = aq(aE.name, aD, aC);
                    aC = az === undefined ? aC : az
                }
            }
            return aC
        }
        function d(aB) {
            for (var aA = 0; aA < M.length; ++aA) {
                if (aB === undefined || aB === null) {
                    break
                }
                var aD = M[aA];
                var aC = aD.extension.outgoing;
                if (aC && typeof aC === "function") {
                    var az = aq(aD.name, aC, aB);
                    aB = az === undefined ? aB : az
                }
            }
            return aB
        }
        function P(az) {
            if (az === undefined) {
                return []
            }
            if (az instanceof Array) {
                return az
            }
            if (az instanceof String || typeof az == "string") {
                return org.cometd.JSON.fromJSON(az)
            }
            if (az instanceof Object) {
                return [az]
            }
            throw "Conversion Error " + az + ", typeof " + (typeof az)
        }
        function ao(aD, aC) {
            var aE = c[aD];
            if (aE && aE.length > 0) {
                for (var aA = 0; aA < aE.length; ++aA) {
                    var aB = aE[aA];
                    if (aB) {
                        try {
                            aB.callback.call(aB.scope, aC)
                        } catch (az) {
                            e("Exception during notification", aB, aC, az)
                        }
                    }
                }
            }
        }
        function ar(aD, aC) {
            ao(aD, aC);
            var aE = aD.split("/");
            var aB = aE.length - 1;
            for (var aA = aB; aA > 0; --aA) {
                var az = aE.slice(0, aA).join("/") + "/*";
                if (aA == aB) {
                    ao(az, aC)
                }
                az += "*";
                ao(az, aC)
            }
        }
        function j(aA, az) {
            return setTimeout(function () {
                try {
                    aA()
                } catch (aB) {
                    ay("Exception invoking timed function", aA, aB)
                }
            },
			az)
        }
        function s() {
            if (X !== null) {
                clearTimeout(X)
            }
            X = null
        }
        function v(az) {
            s();
            var aA = S;
            if (G.interval && G.interval > 0) {
                aA += G.interval
            }
            X = j(az, aA)
        }
        var am;
        var x;
        function I(aD, az) {
            for (var aB = 0; aB < aD.length; ++aB) {
                var aC = aD[aB];
                if (!aC.id) {
                    aC.id = f()
                }
                if (Z) {
                    aC.clientId = Z
                }
                aC = d(aC);
                if (aC !== undefined && aC !== null) {
                    aD[aB] = aC
                } else {
                    aD.splice(aB--, 1)
                }
            }
            if (aD.length === 0) {
                return
            }
            var aA = this;
            var aE = {
                url: ae,
                messages: aD,
                timeout: G.timeout + 5000,
                onSuccess: function (aH, aG) {
                    try {
                        am.call(aA, aH, aG, az)
                    } catch (aF) {
                        ay("Exception during handling of response", aF)
                    }
                },
                onFailure: function (aH, aI, aG) {
                    try {
                        x.call(aA, aH, aD, aI, aG, az)
                    } catch (aF) {
                        ay("Exception during handling of failure", aF)
                    }
                }
            };
            ay("Send", aE);
            u.send(aE, az)
        }
        function U(az) {
            if (V > 0) {
                ac.push(az)
            } else {
                I([az], false)
            }
        }
        function aa() {
            S = 0
        }
        function af() {
            if (S < N) {
                S += ab
            }
        }
        function L() {
            ++V
        }
        function F(az) {
            --V;
            if (V < 0) {
                V = 0
            }
            if (az && V === 0 && !aj()) {
                var aA = ac;
                ac = [];
                if (aA.length > 0) {
                    I(aA, false)
                }
            }
        }
        function q() {
            var az = {
                channel: "/meta/connect",
                connectionType: u.getType()
            };
            ax("connecting");
            ay("Connect sent", az);
            I([az], true);
            ax("connected")
        }
        function w() {
            ax("connecting");
            v(function () {
                q()
            })
        }
        this.reconnect = function () {
            aa();
            w()
        };
        function r(aB) {
            Z = null;
            t();
            V = 0;
            L();
            h = W(true, {},
			aB);
            var az = {
                version: "1.0",
                minimumVersion: "0.9",
                channel: "/meta/handshake",
                supportedConnectionTypes: b ? ["callback-polling"] : ["long-polling", "callback-polling"]
            };
            var aA = W({},
			aB, az);
            ax("handshaking");
            ay("Handshake sent", aA);
            I([aA], false)
        }
        function au() {
            ax("handshaking");
            v(function () {
                r(h)
            })
        }
        function Q(aB) {
            if (aB.successful) {
                Z = aB.clientId;
                var aA = an(aB);
                if (aA === null) {
                    throw "Could not agree on transport with server"
                } else {
                    if (u.getType() != aA.getType()) {
                        ay("Transport", u, "->", aA);
                        u = aA
                    }
                }
                aB.reestablish = B;
                B = true;
                ar("/meta/handshake", aB);
                var aC = G.reconnect ? G.reconnect : "retry";
                switch (aC) {
                    case "retry":
                        w();
                        break;
                    default:
                        break
                }
            } else {
                var az = !aj() && G.reconnect != "none";
                if (!az) {
                    ax("disconnected")
                }
                ar("/meta/handshake", aB);
                ar("/meta/unsuccessful", aB);
                if (az) {
                    af();
                    au()
                }
            }
        }
        function A(aC, aB) {
            var aA = {
                successful: false,
                failure: true,
                channel: "/meta/handshake",
                request: aB,
                xhr: aC,
                advice: {
                    action: "retry",
                    interval: S
                }
            };
            var az = !aj() && G.reconnect != "none";
            if (!az) {
                ax("disconnected")
            }
            ar("/meta/handshake", aA);
            ar("/meta/unsuccessful", aA);
            if (az) {
                af();
                au()
            }
        }
        function ak(az) {
            var aA = aj() ? "none" : (G.reconnect ? G.reconnect : "retry");
            if (!aj()) {
                ax(aA == "retry" ? "connecting" : "disconnecting")
            }
            if (az.successful) {
                F(true);
                ar("/meta/connect", az);
                switch (aA) {
                    case "retry":
                        aa();
                        w();
                        break;
                    default:
                        aa();
                        ax("disconnected");
                        break
                }
            } else {
                switch (aA) {
                    case "retry":
                        af();
                        ar("/meta/connect", az);
                        ar("/meta/unsuccessful", az);
                        w();
                        break;
                    case "handshake":
                        F(false);
                        aa();
                        ar("/meta/connect", az);
                        ar("/meta/unsuccessful", az);
                        au();
                        break;
                    case "none":
                        aa();
                        ax("disconnected");
                        ar("/meta/connect", az);
                        ar("/meta/unsuccessful", az);
                        break
                }
            }
        }
        function K(aC, aA) {
            var az = {
                successful: false,
                failure: true,
                channel: "/meta/connect",
                request: aA,
                xhr: aC,
                advice: {
                    action: "retry",
                    interval: S
                }
            };
            ar("/meta/connect", az);
            ar("/meta/unsuccessful", az);
            if (!aj()) {
                var aB = G.reconnect ? G.reconnect : "retry";
                switch (aB) {
                    case "retry":
                        af();
                        w();
                        break;
                    case "handshake":
                        aa();
                        au();
                        break;
                    case "none":
                        aa();
                        break;
                    default:
                        ay("Unrecognized action", aB);
                        break
                }
            }
        }
        function o(az) {
            s();
            if (az) {
                u.abort()
            }
            Z = null;
            ax("disconnected");
            V = 0;
            ac = [];
            aa()
        }
        function ap(az) {
            if (az.successful) {
                o(false);
                ar("/meta/disconnect", az)
            } else {
                o(true);
                ar("/meta/disconnect", az);
                ar("/meta/usuccessful", az)
            }
        }
        function l(aB, aA) {
            o(true);
            var az = {
                successful: false,
                failure: true,
                channel: "/meta/disconnect",
                request: aA,
                xhr: aB,
                advice: {
                    action: "none",
                    interval: 0
                }
            };
            ar("/meta/disconnect", az);
            ar("/meta/unsuccessful", az)
        }
        function av(az) {
            if (az.successful) {
                ar("/meta/subscribe", az)
            } else {
                ar("/meta/subscribe", az);
                ar("/meta/unsuccessful", az)
            }
        }
        function p(aB, aA) {
            var az = {
                successful: false,
                failure: true,
                channel: "/meta/subscribe",
                request: aA,
                xhr: aB,
                advice: {
                    action: "none",
                    interval: 0
                }
            };
            ar("/meta/subscribe", az);
            ar("/meta/unsuccessful", az)
        }
        function g(az) {
            if (az.successful) {
                ar("/meta/unsubscribe", az)
            } else {
                ar("/meta/unsubscribe", az);
                ar("/meta/unsuccessful", az)
            }
        }
        function m(aB, aA) {
            var az = {
                successful: false,
                failure: true,
                channel: "/meta/unsubscribe",
                request: aA,
                xhr: aB,
                advice: {
                    action: "none",
                    interval: 0
                }
            };
            ar("/meta/unsubscribe", az);
            ar("/meta/unsuccessful", az)
        }
        function E(az) {
            if (az.successful === undefined) {
                if (az.data) {
                    ar(az.channel, az)
                } else {
                    ay("Unknown message", az)
                }
            } else {
                if (az.successful) {
                    ar("/meta/publish", az)
                } else {
                    ar("/meta/publish", az);
                    ar("/meta/unsuccessful", az)
                }
            }
        }
        function R(aB, aA) {
            var az = {
                successful: false,
                failure: true,
                channel: aA.channel,
                request: aA,
                xhr: aB,
                advice: {
                    action: "none",
                    interval: 0
                }
            };
            ar("/meta/publish", az);
            ar("/meta/unsuccessful", az)
        }
        function ai(aA) {
            if (aA.advice) {
                G = aA.advice
            }
            var az = aA.channel;
            switch (az) {
                case "/meta/handshake":
                    Q(aA);
                    break;
                case "/meta/connect":
                    ak(aA);
                    break;
                case "/meta/disconnect":
                    ap(aA);
                    break;
                case "/meta/subscribe":
                    av(aA);
                    break;
                case "/meta/unsubscribe":
                    g(aA);
                    break;
                default:
                    E(aA);
                    break
            }
        }
        this.receive = ai;
        am = function am(aE, aA, az) {
            var aD = P(aA);
            ay("Received", aD);
            u.complete(aE, true, az);
            for (var aB = 0; aB < aD.length; ++aB) {
                var aC = aD[aB];
                aC = y(aC);
                if (aC === undefined || aC === null) {
                    continue
                }
                ai(aC)
            }
        };
        x = function x(aA, aB, aE, az, aC) {
            var aG = aA.xhr;
            ay("Failed", aB);
            u.complete(aA, false, aC);
            for (var aD = 0; aD < aB.length; ++aD) {
                var aH = aB[aD];
                var aF = aH.channel;
                switch (aF) {
                    case "/meta/handshake":
                        A(aG, aH);
                        break;
                    case "/meta/connect":
                        K(aG, aH);
                        break;
                    case "/meta/disconnect":
                        l(aG, aH);
                        break;
                    case "/meta/subscribe":
                        p(aG, aH);
                        break;
                    case "/meta/unsubscribe":
                        m(aG, aH);
                        break;
                    default:
                        R(aG, aH);
                        break
                }
            }
        };
        function i(aA) {
            var aB = c[aA];
            if (aB) {
                for (var az = 0; az < aB.length; ++az) {
                    if (aB[az]) {
                        return true
                    }
                }
            }
            return false
        }
        function al(aE, aG, aF, aB) {
            var aD = aG;
            var az = aF;
            if (typeof aG === "function") {
                aD = undefined;
                az = aG
            } else {
                if (typeof aF === "string") {
                    if (!aG) {
                        throw "Invalid scope " + aG
                    }
                    az = aG[aF];
                    if (!az) {
                        throw "Invalid callback " + aF + " for scope " + aG
                    }
                }
            }
            ay("Listener scope", aD, "and callback", az);
            var aH = {
                scope: aD,
                callback: az,
                subscription: aB === true
            };
            var aA = c[aE];
            if (!aA) {
                aA = [];
                c[aE] = aA
            }
            var aC = aA.push(aH) - 1;
            ay("Added listener", aH, "for channel", aE, "having id =", aC);
            return [aE, aC]
        }
        function ag(az) {
            var aA = c[az[0]];
            if (aA) {
                delete aA[az[1]];
                ay("Removed listener", az)
            }
        }
        this.configure = function (az) {
            aw(az)
        };
        this.init = function (aA, az) {
            aw(aA);
            r(az)
        };
        this.handshake = function (az) {
            B = false;
            r(az)
        };
        this.disconnect = function (aB) {
            if (!u) {
                return
            }
            var az = {
                channel: "/meta/disconnect"
            };
            var aA = W({},
			aB, az);
            ax("disconnecting");
            I([aA], false)
        };
        this.startBatch = function () {
            L()
        };
        this.endBatch = function () {
            F(true)
        };
        this.addListener = function (aA, az, aB) {
            return al(aA, az, aB, false)
        };
        this.removeListener = function (az) {
            ag(az)
        };
        this.clearListeners = function () {
            c = {}
        };
        this.subscribe = function (aD, aA, aG, aF) {

            if (typeof aA === "function") {
                aF = aG;
                aG = aA;
                aA = undefined
            }
            var aE = !i(aD);
            var aC = al(aD, aA, aG, true);
            if (aE) {
                var az = {
                    channel: "/meta/subscribe",
                    subscription: aD
                };
                var aB = W({},
				aF, az);
                U(aB)
            }
            return aC
        };
        this.unsubscribe = function (aD, aA) {
            this.removeListener(aD);
            var aC = aD[0];
            if (!i(aC)) {
                var az = {
                    channel: "/meta/unsubscribe",
                    subscription: aC
                };
                var aB = W({},
				aA, az);
                U(aB)
            }
        };
        this.clearSubscriptions = function () {
            t()
        };
        this.publish = function (aC, aB, aD) {
            var az = {
                channel: aC,
                data: aB,
                id: f()
            };
            var aA = jQuery.extend({},
			aD, az);
            U(aA);
            return az.id
        };
        this.getStatus = function () {
            return C
        };
        this.setBackoffIncrement = function (az) {
            ab = az
        };
        this.getBackoffIncrement = function () {
            return ab
        };
        this.getBackoffPeriod = function () {
            return S
        };
        this.setLogLevel = function (az) {
            at = az
        };
        this.registerExtension = function (az, aD) {
            var aB = false;
            for (var aA = 0; aA < M.length; ++aA) {
                var aC = M[aA];
                if (aC.name == az) {
                    aB = true;
                    break
                }
            }
            if (!aB) {
                M.push({
                    name: az,
                    extension: aD
                });
                ay("Registered extension", az);
                if (typeof aD.registered === "function") {
                    aD.registered.call(aD, az, this)
                }
                return true
            } else {
                n("Could not register extension with name", az, "since another extension with the same name already exists");
                return false
            }
        };
        this.unregisterExtension = function (aA) {
            var az = false;
            for (var aB = 0; aB < M.length; ++aB) {
                var aD = M[aB];
                if (aD.name == aA) {
                    M.splice(aB, 1);
                    az = true;
                    ay("Unregistered extension", aA);
                    var aC = aD.extension;
                    if (typeof aC.unregistered === "function") {
                        aC.unregistered.call(aC)
                    }
                    break
                }
            }
            return az
        };
        this.getExtension = function (az) {
            for (var aA = 0; aA < M.length; ++aA) {
                var aB = M[aA];
                if (aB.name == az) {
                    return aB.extension
                }
            }
            return null
        };
        this.getName = function () {
            return ad
        };
        org.cometd.Transport = function (aF) {
            var aD = 0;
            var aE = null;
            var az = [];
            var aG = [];
            function aH(aI, aL) {
                if (aE !== null) {
                    throw "Concurrent longpoll requests not allowed, request " + aE.id + " not yet completed"
                }
                var aK = ++aD;
                var aJ = {
                    id: aK
                };
                aI._send(aL, aJ);
                aE = aJ
            }
            function aC(aI, aL) {
                var aK = ++aD;
                var aJ = {
                    id: aK
                };
                if (az.length < D - 1) {
                    aI._send(aL, aJ);
                    az.push(aJ)
                } else {
                    aG.push([aL, aJ])
                }
            }
            function aB(aI) {
                var aJ = aI.id;
                if (aE !== aI) {
                    throw "Comet request mismatch, completing request " + aJ
                }
                aE = null
            }
            function aA(aI, aK, aM) {
                var aJ = O(aK, az);
                if (aJ >= 0) {
                    az.splice(aJ, 1)
                }
                if (aG.length > 0) {
                    var aL = aG.shift();
                    if (aM) {
                        aC(aI, aL[0])
                    } else {
                        setTimeout(function () {
                            aL[0].onFailure(aL[1], "error")
                        },
						0)
                    }
                }
            }
            this._send = function (aJ, aI) {
                throw "Abstract"
            };
            this.getType = function () {
                return aF
            };
            this.send = function (aJ, aI) {
                if (aI) {
                    aH(this, aJ)
                } else {
                    aC(this, aJ)
                }
            };
            this.complete = function (aJ, aK, aI) {
                if (aI) {
                    aB(aJ)
                } else {
                    aA(this, aJ, aK)
                }
            };
            this.abort = function () {
                for (var aI = 0; aI < az.length; ++aI) {
                    var aJ = az[aI];
                    ay("Aborting request", aJ);
                    if (aJ.xhr) {
                        aJ.xhr.abort()
                    }
                }
                if (aE) {
                    ay("Aborting request", aE);
                    if (aE.xhr) {
                        aE.xhr.abort()
                    }
                }
                aE = null;
                az = [];
                aG = []
            }
        };
        org.cometd.LongPollingTransport = function () {
            this._send = function (aA, az) {
                az.xhr = org.cometd.AJAX.send({
                    name: ad,
                    transport: this,
                    url: aA.url,
                    headers: {
                        Connection: "Keep-Alive"
                    },
                    body: org.cometd.JSON.toJSON(aA.messages),
                    onSuccess: function (aB) {
                        aA.onSuccess(az, aB)
                    },
                    onError: function (aC, aB) {
                        aA.onFailure(az, aC, aB)
                    }
                })
            }
        };
        org.cometd.CallbackPollingTransport = function (aA) {
            var az = 2000;
            this._send = function (aE, aD) {
                var aC = org.cometd.JSON.toJSON(aE.messages);
                var aF = aE.url.length + encodeURI(aC).length;
                if (aF > az) {
                    var aB = aE.messages.length > 1 ? "Too many bayeux messages in the same batch resulting in message too big (" + aF + " bytes, max is " + az + ") for transport " + this.getType() : "Bayeux message too big (" + aF + " bytes, max is " + az + ") for transport " + this.getType();
                    j(function () {
                        aE.onFailure(aD, "error", aB)
                    },
					0)
                } else {
                    org.cometd.AJAX.send({
                        name: aA,
                        transport: this,
                        url: aE.url,
                        headers: {
                            Connection: "Keep-Alive"
                        },
                        body: aC,
                        timeout: typeof aE.timeout !== "undefined" ? aE.timeout : null,
                        onSuccess: function (aG) {
                            aE.onSuccess(aD, aG)
                        },
                        onError: function (aH, aG) {
                            aE.onFailure(aD, aH, aG)
                        }
                    })
                }
            }
        }
    }
})(jQuery);
/*jquery.cometd.js*/
(function (b) {
    org.cometd.JSON.toJSON = JSON.stringify;
    org.cometd.JSON.fromJSON = JSON.parse;
    org.cometd.script = {
        counter: 0,
        create: function (k) {
            var i = window,
			l;
            if (k.name) {
                var j = document.getElementById("cometd_" + k.name);
                if (j && j.contentWindow && j.contentWindow.document) {
                    l = j.contentWindow.document;
                    i = j.contentWindow.window
                }
            }
            var e = this.counter++;
            var g = "_callback" + e;
            this[g] = org.cometd.script.bind(k.onSuccess, l, e);
            var d = k.url;
            if (k.body) {
                if (d.indexOf("?") == -1) {
                    d = d + "?message=" + encodeURIComponent(k.body)
                } else {
                    d = d + "&message=" + encodeURIComponent(k.body)
                }
            }
            var m = l ? "parent.org.cometd.script." : "org.cometd.script.";
            if (d.indexOf("callback=?") > -1) {
                d = d.replace("callback=?", "callback=" + m + g)
            } else {
                d = d + "&jsonp=" + m + g
            }
            var c = "cometd" + e;
            if (!l) {
                l = document
            }
            var h = l.createElement("script");
            h.type = "text/javascript";
            h.src = d;
            h.id = c;
            h.charset = "utf-8";
            if (k.onError) {
                if (h.attachEvent) { } else {
                    h.addEventListener("error", (function (f) {
                        return function (n) {
                            org.cometd.script.remove(e, l);
                            f()
                        }
                    })(k.onError), false)
                }
            }
            if (k.timeout && k.timeout > 0) {
                window.setTimeout(function () {
                    if (org.cometd.script[g]) {
                        org.cometd.script.remove(e, l);
                        k.onError()
                    }
                },
				k.timeout)
            }
            l.getElementsByTagName("head")[0].appendChild(h);
            return e
        },
        get: function (d) {
            try {
                var c = this.create(d);
            } catch (f) { }
        },
        remove: function (g, f) {
            var f = f || document;
            try {
                var c = f.getElementById("cometd" + g);
                c.parentNode.removeChild(c, true);
                delete this["_callback" + g]
            } catch (d) { }
        },
        bind: function (c, d, e) {
            return function (f) {
                c(org.cometd.JSON.fromJSON(org.cometd.JSON.toJSON(f)));
                org.cometd.script.remove(e, d)
            }
        }
    };
    org.cometd.AJAX.send = function (d) {
        var c = d.transport.getType();

        if (c == "long-polling") {
            return b.ajax({
                url: d.url,
                type: "POST",
                contentType: "text/json;charset=UTF-8",
                data: d.body,
                beforeSend: function (e) {
                    a(e, d.headers);
                    return true;
                },
                success: d.onSuccess,
                error: function (g, f, e) {
                    d.onError(f, e)
                }
            })
        } else {
            if (c == "callback-polling") {
                org.cometd.script.get(d);
            } else {
                throw "Unsupported transport " + c
            }
        }
    };
    function a(d, c) {
        if (c) {
            for (var e in c) {
                if (e.toLowerCase() === "content-type") {
                    continue
                }
                d.setRequestHeader(e, c[e])
            }
        }
    }
})(jQuery);
