<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Property.ascx.cs" Inherits="Web.Personal.Controls.Property" %>
<%if(ShowLabelStyle){ %>
    <table>
        <tr>
            <%if(SourceFlag){ %>
            <td>来源：</td>
            <td style=" padding:2px 6px 0 0;">
                <asp:Label ID ="lblSource" runat="server"></asp:Label>
            </td>
            <%}if(TradeFlag){ %>
            <td>行业：</td>
            <td style=" padding:2px 6px 0 0;">
                <asp:Label ID ="lblTrade" runat="server"></asp:Label>
            </td>
            <%} if (AreaFlag)
              { %>
            <td>地区：</td>
            <td style=" padding:2px 6px 0 0;">
                <asp:Label ID ="lblArea" runat="server"></asp:Label>
            </td>
            <%} %>
        </tr>
    </table>
<%}else{ %>
    <table>
        <tr>
            <%if(SourceFlag){ %>
            <td>来源：</td>
            <td><asp:DropDownList runat="server" ID="ddlSource" CssClass="ddl1 w120" ClientIDMode="Static"></asp:DropDownList></td>
            <%}if(TradeFlag){ %>
            <td>行业：</td>
            <td><asp:DropDownList runat="server" CssClass="ddl1 w120" ID="ddlTrade"></asp:DropDownList></td>
            <%} if (AreaFlag)
              { %>
            <td>地区：</td>
            <td><asp:DropDownList runat="server" CssClass="ddl1 w120" ID="ddlArea"></asp:DropDownList></td>
            <%} %>
        </tr>
    </table>
    <script type="text/javascript">
        var Property = {
            GetSource: function () {
                /// <summary>
                /// 获取选择来源值
                /// </summary>
                if ($("#<%=ddlSource.ClientID %>").is("select")) {
                    return $("#<%=ddlSource.ClientID %>").val();
                }
                return -1;
            }
            , GetTrade: function () {
                /// <summary>
                /// 获取选择行业值
                /// </summary>
                if ($("#<%=ddlTrade.ClientID %>").is("select")) {
                    return $("#<%=ddlTrade.ClientID %>").val();
                }
                return -1;
            }
            , GetArea: function () {
                /// <summary>
                ///获取选择地区值
                /// </summary>
                if ($("#<%=ddlArea.ClientID %>").is("select")) {
                    return $("#<%=ddlArea.ClientID %>").val();
                }
                return -1;
            }
            , GetQuery: function () {
                var sourceid = this.GetSource();
                var tradeid = this.GetTrade();
                var areaid = this.GetArea();
                return "&sourceid=" + sourceid + "&tradeid=" + tradeid + "&areaid=" + areaid;
            }
        };
    </script>
<%} %>