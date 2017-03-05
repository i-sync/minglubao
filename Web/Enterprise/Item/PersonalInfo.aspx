<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PersonalInfo.aspx.cs" Inherits="Web.Enterprise.Item.PersonalInfo" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>个人基本信息</title>
    <link href="/Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="/JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="/JS/common.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="nav">
            <h3 style="margin:10px 20px;display:inline;">个人基本信息</h3>
            <a href="javascript:void(0);" onclick="history.go(-1);">返回</a>
        </div>

        <!--个人基本信息-->
        <div class="divlist">
            <div>
                <h4>个人信息</h4>
            </div>
            <div id="Base_Info">
                <table cellpadding="1" cellspacing="1" class="baseinfo" >
                    <tr>
                        <td class="name">姓名</td>
                        <td>
                            <asp:Label ID="lblBName" runat="server"></asp:Label>
                        </td>
                        <td class="name">性别</td>
                        <td>
                            <asp:Label ID ="lblBSex" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>                    
                        <td class="name">婚姻状况</td>
                        <td>
                            <asp:Label ID ="lblBMarital" runat="server"></asp:Label>
                        </td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td class="name">出生日期</td>
                        <td>
                            <asp:Label ID="lblBBirthday" runat="server"></asp:Label>
                        </td>
                        <td class="name">工作年限</td>
                        <td>
                            <asp:Label ID ="lblBWorkYear" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">居住地</td>
                        <td>
                            <asp:Label ID="lblBCity" runat="server"></asp:Label>
                        </td>
                        <td class="name">户口</td>
                        <td>
                            <asp:Label ID ="lblBHuKou" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">邮箱</td>
                        <td>
                            <asp:Label ID="lblBEmail" runat="server"></asp:Label>
                        </td>
                        <td class="name">手机号码</td>
                        <td>
                            <asp:Label ID ="lblBMobile" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">电话号码</td>
                        <td>
                            <asp:Label ID="lblBTel" runat="server"></asp:Label>
                        </td>
                        <td class="name">传真号码</td>
                        <td>
                            <asp:Label ID ="lblBFax" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="name">详细地址</td>
                        <td colspan="3">
                            <asp:Label ID ="lblBAddress" runat="server"></asp:Label>
                        </td>
                    </tr>   
                    <tr>
                        <td class="name">关键字</td>
                        <td colspan="3">
                            <asp:Label ID="lblBKeyword" runat="server"></asp:Label>
                        </td>
                    </tr>             
                </table>
            </div>
        </div>

        <!--工作经验-->
        <div class="divlist">
            <div>
                <h4>工作经验</h4>
            </div>
            <div id="WorkList">
                <asp:Repeater ID="rpList" runat="server">
                    <ItemTemplate>
                        <div id="<%#Eval("JobExperienceID") %>" style="width:60%;">                            
                            <table class="baseinfo"  cellpadding="1" cellspacing="1">
                                <tr>
                                    <td class="name">时间</td>
                                    <td colspan="3">
                                        <span><%#Eval("StartDate","{0:yyyy-MM-dd}") %></span>
                                        到
                                        <span><%#string.IsNullOrEmpty(Eval("EndDate").ToString())?"至今":Eval("EndDate","{0:yyyy-MM-dd}") %></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="name">
                                        公司名称
                                    </td>
                                    <td >
                                        <span><%#Eval("CompanyName") %></span>
                                    </td>
                                    <td class="name">
                                        规模
                                    </td>
                                    <td>
                                        <span><%#MLMGC.COMP.EnumUtil.GetName<MLMGC.DataEntity.Personal.EnumScale>(Eval("Scale"))%></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="name">
                                        部门
                                    </td>
                                    <td>
                                        <span><%#Eval("Departments") %></span>
                                    </td>
                                    <td class="name">
                                        职位
                                    </td>
                                    <td>
                                        <span><%#Eval("Position") %></span>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="name">
                                        工作描述
                                    </td>
                                    <td colspan="3">
                                        <span><%#Eval("JobDescription") %></span>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>                    
        </div>

    </form>
</body>
</html>
