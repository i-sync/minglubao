<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Region.ascx.cs" Inherits="WebAdmin.Controls.Region" %>

<script type="text/javascript">
    //把字符串转换为json对象
    function parseObj(strData) {
        return (new Function("return " + strData))();
    }
    $(function () {
        var str = $("#<%=hfData.ClientID %>").val();
        var array = parseObj(str);

        $("#ddlP").change(function () {
            var id = $(this).val();
            var op = "";
            for (var i = 0; i < array.length; i++) {
                if (array[i].pid == id)
                    op += "<option value=\"" + array[i].id + "\">" + array[i].name + "</option>";
            }
            $("#ddlC").empty();
            $("#ddlC").append(op);
            $("#<%=hfValue.ClientID %>").val($("#ddlC").val());
        });

        $("#ddlC").change(function () {
            $("#<%=hfValue.ClientID %>").val($(this).val());
        });

        //反显
        var id = $("#<%=hfValue.ClientID %>").val();
        for (var i = 0; i < array.length; i++) {
            if (array[i].id == id || id==0) {
                $("#ddlP").val(array[i].pid);
                $("#ddlP").triggerHandler("change");
                $("#ddlC").val(id);
                break;
            }
        }

    });
</script>
<div>
    <asp:HiddenField ID="hfData" runat="server" />
    <asp:HiddenField ID="hfValue"  Value="110100" runat="server" />
    <select id="ddlP"  class="ddl1" style="width:100px;">
        <asp:Repeater ID="rpList" runat="server">
            <ItemTemplate>
                <option value="<%#Eval("RegionID") %>" <%#Eval("Selected") %> ><%#Eval("RegionName") %></option>
            </ItemTemplate>
        </asp:Repeater>
    </select>
    <select id="ddlC"  class="ddl1" style="width:120px;">
        <asp:Repeater ID="rpSecond" runat="server">
            <ItemTemplate>
                <option value="<%#Eval("RegionID") %>" <%#Eval("Selected") %> ><%#Eval("RegionName") %></option>
            </ItemTemplate>
        </asp:Repeater>
    </select>
</div>