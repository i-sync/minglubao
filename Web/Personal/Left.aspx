<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="Web.Personal.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/index.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function () {            
            //点击菜单
            $(".title").click(function () {
                var pObj = $(this).parent();
                if ($(pObj).is("div")) {
                    if ($(pObj).attr("class") == "item") {
                        $(pObj).attr("class", "curitem");
                    }
                    else {
                        $(pObj).attr("class", "item");
                    }
                }
            });
            $("a").click(function () {
                if ($(this).attr("class") == "current") {
                    return true;
                }
                $(".curent").removeClass("curent");
                $(this).addClass("curent");
            });

            //退出时清空cookie
            $("#logout").click(function () {
                $.cookie("autologin", null, { path: '/' });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="menu fl" style="border-right:1px solid #ccc;overflow: hidden;">
                <div class="list_xiugaimima">
                    <div class="guanliyuan fl">
                        <asp:Image ID="imgAvatar" style="width:30px;height:30px;" runat="server" />
                    </div>
                    <div class="guanliyuan_denglu fl">
                        <div class="guanliyuan_denglushang" style=" overflow:hidden; width:100px;">
                            <asp:Literal runat="server" ID="ltName" Text="123" />
                        </div>
                        <div class="guanliyuan_dengluxia">
                            <a href="UpdatePassword.aspx" target="main">[修改密码]</a>&nbsp;<a href="Logout.aspx" id="logout"
                                target="_parent">[退出]</a>
                        </div>
                    </div>
                </div>
                <div class="menulist">
                    <div class="curitem" type="data">
                        <div class="title">
                            <a href="#">期初设置</a></div>
                        <div>
                            <ul>
                                <li><a href="Config/Property.aspx" target="main">分类设置</a></li>
                                <li><a href="Config/MailConfig.aspx" target="main">邮箱设置</a></li>
                                <li><a href="Material/TalkList.aspx" target="main">话术设置</a></li>
                                <li><a href="Config/StateWish.aspx" target="main">意向进展</a></li>
                                <li><a href="Config/StateNotTraded.aspx" target="main">失败原因</a></li>
                                <li><a href="Config/StateScrap.aspx" target="main">报废理由</a></li>
                                <li><a href="Modify.aspx" target="main">修改资料</a></li>
                                <li><a href="Avatar/Avatar.aspx" target="main">设置头像</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="curitem" type="index">
                        <div class="title">
                            <a href="javascript:void(0);">名录管理</a></div>
                        <div>
                            <ul>
                                <li><a href="clientInfoAdd.aspx" target="main">名录录入</a></li>
                                <li><a href="data/ImportingStep1.aspx" target="main">名录导入</a></li>
                                <li><a href="latence.aspx" target="main">潜在客户</a></li>
                                <li><a href="wish.aspx" target="main">意向客户</a></li>
                                <li><a href="traded.aspx" target="main">成交客户</a></li>
                                <li><a href="nottraded.aspx" target="main">失败客户</a></li>
                                <li><a href="scrap.aspx" target="main">报废客户</a></li>
                                <li><a href="search.aspx" target="main">名录查询</a></li>
                                <li><a href="data/export.aspx" target="main">名录导出</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="curitem" type="index">
                        <div class="title">
                            <a href="javascript:void(0);">找资料</a></div>
                        <div>
                            <ul>
                                <li><a href="/WenKu/List.aspx" target="main">资料检索</a></li>
                                <li><a href="WenKu/Add.aspx" target="main">上传资料</a></li>
                                <li><a href="WenKu/List.aspx" target="main">我的资料</a></li>
                            </ul>
                        </div>
                    </div>
                    <div class="curitem" type="index">
                        <div class="title">
                            <a href="javascript:void(0);">找项目</a></div>
                        <div>
                            <ul>
                                <li><a href="Item/ItemList.aspx" target="main">项目检索</a></li>
                                <li><a href="Item/applylist.aspx" target="main">申请列表</a></li>
                            </ul>
                        </div>
                    </div>

                    <%if (EnterpriseID > 0 && IsOpen)
                      { %>
                    <div class="curitem" type="index">
                        <div class="title">
                            <a href="javascript:void(0);">项目名录</a>
                        </div>
                        <div>
                            <ul>                                
                                <li><a href="Item/ClientInfoAdd.aspx" target="main">名录录入</a></li>
                                <li><a href="Item/Search.aspx" target="main">名录检索</a></li>
                                <li><a href="Item/Latence.aspx" target="main">潜在名录</a></li>
                                <li><a href="Item/Wish.aspx" target="main">意向名录</a></li>
                                <li><a href="Item/Traded.aspx" target="main">成交名录</a></li>
                                <li><a href="Item/NotTraded.aspx" target="main">失败名录</a></li>
                                <li><a href="Item/Scrap.aspx" target="main">报废名录</a></li>
                                <li><a href="Item/Share.aspx" target="main">共享池</a></li>
                                <li><a href="Item/DataImport.aspx" target="main">数据导入</a></li>
                            </ul>
                        </div>
                    </div>
                    <%} %>
                </div>
            </div>
    </form>
</body>
</html>
