<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="Web.WenKu.Info" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>资料显示</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <link href="/Styles/core.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
    <script src="/JS/popup_layer.js" type="text/javascript"></script>
    <script type="text/javascript">
        var pl;
        var CONFIG={
            POST_URL:"/handler/wenku.ashx",
            ID:"<%=Request["id"] %>"
        };
        $(function () {
            pl = new PopupLayer({ title: "提示", popupBlk: "#divDownloadTip", useOverlay: "true" });
            //下载
            $("#downloadTop").click(function () {
                //显示提示
                //pl.Show();
                $("#downloadButton").triggerHandler("click");
            });

            $("#downloadButton").click(function () {
                //pl.Show();
                //异步请求添加数据
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: {key:"download",usertype:"2",id:CONFIG.ID},
                    success: function (data) { 
                        //pl.PopClose();
                        if(data.flag=="1"){
                            window.open(data.url);                            
                        } else {
                            alert("下载失败！");
                        }
                    },
                    dataType:"json"
                });
            });

            //取消提示
            $("#btnCancel").click(function () {
                pl.PopClose();
            });

            //点击确认下载
            $("#btnDownload").click(function () {
                //异步请求添加数据
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: {key:"download",usertype:"2",id:CONFIG.ID},
                    success: function (data) { 
                        pl.PopClose();
                        if(data.flag=="1"){
                            window.open(data.url);                            
                        } else {
                            alert("下载失败！");
                        }
                    },
                    dataType:"json"
                });
            });

        })
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav">
            <h3>资料显示</h3>
        </div>
        <div style="width:700px;height:710px; margin:10px 20px; padding-left:10px;">
            <div>
                <div style="float:left;font-size:14pt;color:Black;margin:auto 10px;">
                    <asp:Label ID="lblCaption" runat="server"></asp:Label>
                </div>
                <div style="float:right;">
                    <a id="downloadTop" href="javascript:void(0);">下载</a>
                </div>
            </div>
            <div style="height:650px;">
                <embed style="width:100%;height:100%;" align="middle" id="flashContainer" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" name="reader" src="<%=FlashUrl %>" ></embed>
            </div>
            <br />
            <br />
            <div style="height:40px;">
                <a href="#"><img onmousemove="pointer" id="downloadButton" src="/images/download.png"/></a>
                大小：<asp:Label ID ="lblFileSize" runat ="server"></asp:Label>
            </div>
        </div>

        <!--提示信息-->
        <div id="divDownloadTip" style=" padding:10px 20px; border: 1px solid #ccc;width:300px;height:150px; background-color: white;display:none; position:absolute;">
            <table class="tabtxtlist">
                <tr>
                    <td style="text-align:right;width:50%;">当前名录币：</td>
                    <td>
                        <asp:Label ID="lblTotalNum" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">本次下载所需名录币：</td>
                    <td>
                        <asp:Label ID="lblNeedNum" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center;">                        
                        <input id="btnDownload" type="button" class="btn" value="确认下载" />
                        &nbsp;&nbsp;&nbsp;&nbsp;
                        <input id="btnCancel" type="button" class="btn" value="取消" />
                    </td>                    
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
