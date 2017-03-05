<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ManualList.aspx.cs" Inherits="Web.Enterprise.Allot.ManualList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>查询待分配名录结果</title>
</head>
<body>
    <div style="width: 98%; margin: 10px auto 0 auto;" id="list">
        <table class="tablist" cellpadding="1" cellspacing="1">
            <tr>
                <th class="num">
                    <input type="checkbox" name="cbAll" id="cbAll" value="-1" />
                </th>
                <th>
                    名录名称
                </th>
                <%if (TradeFlag)
                  { %><th>
                      行业
                  </th>
                <%} if (SourceFlag)
                  { %><th>
                      来源
                  </th>
                <%} if (AreaFlag)
                  { %><th>
                      地区
                  </th>
                <%} %>
                <th>
                    入库时间
                </th>
            </tr>
            <asp:Repeater runat="server" ID="rpList">
                <ItemTemplate>
                    <tr class="c">
                        <td>
                            <input type="checkbox" name="cbClient" value="<%#Eval("ClientInfoID") %>" />
                        </td>
                        <td>
                            <a href="../clientinfo/info.aspx?ciid=<%#Eval("ClientInfoID") %>" title="<%#Eval("ClientName") %>">
                                <%#Eval("ClientName") %></a>
                        </td>
                        <%if (TradeFlag)
                          { %><td>
                              <%#Eval("TradeName") %>
                          </td>
                        <%} if (SourceFlag)
                          { %><td>
                              <%#Eval("SourceName") %>
                          </td>
                        <%} if (AreaFlag)
                          { %><td>
                              <%#Eval("AreaName") %>
                          </td>
                        <%} %>
                        <td>
                            <%#Eval("AddDate", "{0:yyyy-MM-dd HH:mm:ss}")%>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <mlb:AspNetPager runat="server" ID="pageList1" CssClass="paginator" CurrentPageButtonClass="cpb"
            PageIndexBoxClass="textbox_page1" SubmitButtonClass="btn_go" SubmitButtonText=""
            TextBeforePageIndexBox="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;第&nbsp;"
            AlwaysShow="true" FirstPageText="首页" LastPageText="尾页" NextPageText="下一页" PageSize="1"
            PrevPageText="上一页" ShowCustomInfoSection="Left" CustomInfoTextAlign="Center"
            LayoutType="Table" ShowPageIndex="false" ShowBoxThreshold="3" UrlPaging="true" />
    </div>
</body>
</html>
