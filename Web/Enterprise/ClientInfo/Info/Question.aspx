<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="Web.Enterprise.Info.Question" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>名录调查情况列表</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="list" class="list">
        <table>
            <asp:Repeater ID="rpList" runat="server" OnItemDataBound="rpList_ItemDataBound">
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("QuestionName") %>
                        </td>
                        <td>
                            <asp:Repeater ID="rpItem" runat="server">
                                <ItemTemplate>
                                    <input type="<%#SetType(((Container.Parent.NamingContainer as RepeaterItem).DataItem as System.Data.DataRowView)["QuestionType"])%>"
                                        name="item<%#Eval("QuestionID") %>" id="rb<%#Eval("QuestionItemID") %>" value="<%#Eval("QuestionItemID") %>" <%# Enable() %>
                                        <%#Check(Eval("Flag")) %> /><label for="rb<%#Eval("QuestionItemID") %>"><%#Eval("QuestionItemName") %></label>
                                </ItemTemplate>
                            </asp:Repeater>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
        <%if (flag)
          { %>
        <%if (!hide)
          { %>
        <input type="button" value="提交" class="btn1" id="btnQSubmit" />
        <%} %>
        <script type="text/javascript">
            $(function () {
                $("#btnQSubmit").click(function () {
                    var ary = Array();
                    $("#list").find("input:checked").each(function (i) {
                        ary.push($(this).val());
                    });                    
                    var ciid =<%=Request["ciid"] %>;    
                    var data="";
                    $.post("/enterprise/Handler/CIHandler.ashx?act=subquestion",{ciid:ciid,itemids:ary.toString()},function(data){
                        if(data=="1")
                        {
                            PopTip.Show(PopTip.Type.Succ, "操作成功",false);
                        }
                        else
                        {
                            PopTip.Show(PopTip.Type.Error, "操作失败",false);
                        }
                    });
                   
                });
            });
        </script><%} %>
    </div>
    </form>
</body>
</html>
