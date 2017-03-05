<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Modify.aspx.cs" Inherits="Web.Personal.Modify" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改资料</title>
    <link href="../JS/My97DatePicker/skin/WdatePicker.css" rel="stylesheet" type="text/css" />
    <script src="../JS/jquery-1.6.4.js" type="text/javascript"></script>
    <script src="../JS/common.js" type="text/javascript"></script>
    <script src="../JS/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        var CONFIG = {
            POST_URL: "/personal/handler/info.ashx"
        };
        $(function () {
            //-------------基本验证-----------------
            //验证姓名
            $("#txtBName").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    $("#TipsBName").show();
                }
                else {
                    $("#TipsBName").hide();
                }
            });

            //验证出生日期
            $("#txtBBirthday").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    $("#TipsBBirthday").show();
                }
                else {
                    $("#TipsBBirthday").hide();
                }
            });
            $("#txtBCity").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    $("#TipsBCity").show();
                }
                else {
                    $("#TipsBCity").hide();
                }
            });
            $("#txtBHuKou").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    $("#TipsBHuKou").show();
                }
                else {
                    $("#TipsBHuKou").hide();
                }
            });
            $("#txtBEmail").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    $("#TipsBEmail").show();
                }
                else if (!$.IsEmail(v)) {
                    $("#TipsBEmail").html("请输入正确的邮箱");
                    $("#TipsBEmail").show();
                }
                else {
                    $("#TipsBEmail").hide();
                }
            });
            $("#txtBMobile").blur(function () {
                var v = $.trim($(this).val());
                if ($.IsNullOrEmpty(v)) {
                    $("#TipsBMobile").show();
                }
                else if (!$.IsMobile(v)) {
                    $("#TipsBMobile").html("请输入正确的手机号码");
                    $("#TipsBMobile").show();
                }
                else {
                    $("#TipsBMobile").hide();
                }
            });
            $("#txtBTel").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && !$.IsTel(v)) {
                    $("#TipsBTel").show();
                }
                else {
                    $("#TipsBTel").hide();
                }
            });
            $("#txtBFax").blur(function () {
                var v = $.trim($(this).val());
                if (v.length > 0 && !$.IsTel(v)) {
                    $("#TipsBFax").show();
                }
                else {
                    $("#TipsBFax").hide();
                }
            });

            //-----------------个人信息JS块-------------------
            //切换个人信息（显示、编辑）
            $("#baseSwitch").click(function () {
                var type = $(this).attr("T");
                if (type == "info") {//如果为显示改为编辑，反之易然
                    $(this).attr("T", "edit");
                    $(this).html("取消");
                    $("#Base_Info").hide();
                    $("#Base_Edit").show();
                } else if (type == "edit") {
                    $(this).attr("T", "info");
                    $(this).html("修改");
                    $("#Base_Info").show();
                    $("#Base_Edit").hide();
                }
            });

            //取消编辑
            $("#btnBCancel").click(function () {
                $("#baseSwitch").trigger("click");
            });

            //点击保存个人基本信息
            $("#btnBSaveBase").click(function () {
                $("#Base_Edit :text").trigger("blur");
                if ($("#Base_Edit .error").filter(":visible").length > 0)
                    return false;
                //获取界面数据
                var name = $.trim($("#txtBName").val());
                var gender = $(":radio[name='rdBGender']").filter(":checked").val();
                var marital = $(":radio[name='rdBMarital']").filter(":checked").val();
                var birthday = $("#txtBBirthday").val();
                var workyear = $("#ddlWorkYear").val();
                //居住地 户口所在地
                var email = $.trim($("#txtBEmail").val());
                var mobile = $.trim($("#txtBMobile").val());
                var tel = $.trim($("#txtBTel").val());
                var fax = $.trim($("#txtBFax").val());
                var keyword = $.trim($("#txtBKeyword").val());
                var address = $.trim($("#txtBAddress").val());

                //异步请求，保存数据
                $.ajax({
                    type: "POST",
                    url: CONFIG.POST_URL,
                    data: { key: "updatebase", name: name, gender: gender, marital: marital, birthday: birthday, workyear: workyear, email: email, mobile: mobile, tel: tel, fax: fax, keyword: keyword, address: address },
                    success: function (data) {
                        if (data == "1") {
                            //保存成功 修改Info资料
                            $("#lblBName").html(name);
                            $("#lblBSex").html($(":radio[name='rdBGender']").filter(":checked").next().html());
                            $("#lblBMarital").html($(":radio[name='rdBMarital']").filter(":checked").next().html());
                            $("#lblBBirthday").html(birthday);
                            $("#lblBWorkYear").html($("#ddlWorkYear option").filter(":selected").html());

                            $("#lblBEmail").html(email);
                            $("#lblBMobile").html(mobile);
                            $("#lblBTel").html(tel);
                            $("#lblBFax").html(fax);
                            $("#lblBKeyword").html(keyword);
                            $("#lblBAddress").html(address);
                            //切换
                            $("#baseSwitch").trigger("click");
                        } else {
                            alert("保存失败");
                        }
                    },
                    dataType: "text"
                });
            });
            //-----------------------------------------------


            //------------------工作经验模块-----------------
            $("#btnAddWork").click(function () {
                var div = $("#Template_Edit").clone();
                div.removeAttr("id");
                div.attr("type", "add");
                div.show();
                $("#WorkList").append(div);
            });
            //----------------------------------------------
        });

        //保存工作经验按钮处理事件
        function UpdateWork(sender) {
            var div = $(sender).parent().parent();
            div.find(":text").trigger("blur");
            if (div.find(".error").filter(":visible").length > 0) {
                return false;
            }
            var type = div.attr("type");
            var jobid = div.attr("id");
            var startdate = div.find("#txtStartDate").val();
            var enddate = div.find("#txtEndDate").val();
            var companyname = div.find("#txtCompanyName").val();
            var scale = div.find("#ddlScale").val();
            var departments = div.find("#txtDepartments").val();
            var position = div.find("#txtPosition").val();
            var description = div.find("#txtJobDescription").val();
                        
            //异步请求保存数据
            $.ajax({
                type: "POST",
                url:CONFIG.POST_URL,
                data: { key: "updatejob",jobid:jobid,type:type,startdate: startdate, enddate: enddate, companyname: companyname, scale: scale, departments: departments, position: position, description: description },
                success: function (data) {
                    if (parseInt(data)>0) {
                        //复制显示模板，用来显示信息
                        var info = $("#Template_Info").clone();
                        info.attr("id",data);
                        div.after(info); //把Info添加到Edit后面

                        info.find("#lblStartDate").html(startdate);
                        info.find("#lblEndDate").html(enddate == "" ? "至今" : enddate);
                        info.find("#lblCompanyName").html(companyname);
                        info.find("#lblScale").html(div.find("#ddlScale option").filter(":selected").html());
                        info.find("#lblDepartments").html(departments);
                        info.find("#lblPosition").html(position);
                        info.find("#lblDescription").html(description);

                        info.show();//显示Info
                        div.remove(); //把Edit删除
                    }
                    else {
                        alert("添加失败");
                    }
                },
                dataType: "text"
            });
        }

        //显示修改div
        function ShowUpdate(sender) {
            var div = $(sender).parent().parent();
            //获取jobid
            var jobid = div.attr("id");
            //异步请求获取工作经验的详细信息
            $.ajax({
                type: "POST",
                url: CONFIG.POST_URL,
                data: { key: "getjob", jobid: jobid },
                success: function (data) {
                    if (data != null) {
                        //得到详细信息后，复制编辑模板
                        var edit = $("#Template_Edit").clone();
                        //绑定数据
                        edit.attr("id", jobid);
                        edit.attr("type", "update");
                        div.after(edit);

                        edit.find("#txtStartDate").val(data.startdate);
                        edit.find("#txtEndDate").val(data.enddate == "" ? "" : data.enddate);
                        edit.find("#txtCompanyName").val(data.companyname);
                        edit.find("#ddlScale").val(data.scale);
                        edit.find("#txtDepartments").val(data.departments);
                        edit.find("#txtPosition").val(data.position);
                        edit.find("#txtJobDescription").val(data.description);

                        edit.show();
                        div.remove();
                    }
                },
                dataType: "json"
            });
        }

        //删除工作信息详情
        function DeleteWork(sender) {
            var div = $(sender).parent().parent();
            var type = div.attr("type");
            if (type == "add"){  //如果是添加直接删除DIV
                div.remove();            
            }
            else {
                if (confirm("确认要删除吗？")) { //确认要删除
                    //获取id
                    var jobid = div.attr("id");
                    //异步删除
                    $.ajax({
                        type: "POST",
                        url: CONFIG.POST_URL,
                        data: {key:"deletejob",jobid:jobid},
                        success: function (data) {
                            if (data == "1")//删除成功
                            {
                                //移除div
                                div.remove();
                            }
                            else {
                                alert("删除失败！");
                            }
                        },
                        dataType: "text"
                    })
                }
            }
        }

        //-------------------工作经验的表单验证---------------------
        //日期
        function StartDateValidation(sender) {
            var v = $.trim($(sender).val());
            //查找表格
            var table = $(sender).parents("table");
            var tip = table.find("#TipsStartDate");
            if ($.IsNullOrEmpty(v)) {
                tip.show();
            }
            else {
                tip.hide();
            }
        }
        //公司名称
        function CompanyNameValidation(sender) {
            var v = $.trim($(sender).val());
            //查找表格
            var table = $(sender).parents("table");
            var tip = table.find("#TipsCompanyName");
            if ($.IsNullOrEmpty(v)) {
                tip.show();
            }
            else {
                tip.hide();
            }
        }
        //部门
        function DepartmentsValidation(sender) {
            var v = $.trim($(sender).val());
            //查找表格
            var table = $(sender).parents("table");
            var tip = table.find("#TipsDepartments");
            if ($.IsNullOrEmpty(v)) {
                tip.show();
            }
            else {
                tip.hide();
            }
        }
        //职位
        function PositionValidation(sender) {
            var v = $.trim($(sender).val());
            //查找表格
            var table = $(sender).parents("table");
            var tip = table.find("#TipsPosition");
            if ($.IsNullOrEmpty(v)) {
                tip.show();
            }
            else {
                tip.hide();
            }
        }
        //工作描述
        function DescriptionValidation(sender) {
            var v = $.trim($(sender).val());
            //查找表格
            var table = $(sender).parents("table");
            var tip = table.find("#TipsDescription");
            if ($.IsNullOrEmpty(v)) {
                tip.show();
            }
            else {
                tip.hide();
            }
        }
        //---------------------------------------------------------

    </script>
    <link href="../Styles/Site.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="nav">
        <h3>修改资料</h3>
    </div>
    <!--个人基本信息-->
    <div class="divlist">
        <div>
            <h4 style="float:left;">个人信息</h4>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <a id="baseSwitch" T="info" href="javascript:void(0);">修改</a>
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
        <div id ="Base_Edit" style="display:none">
            <table class="baseedit">
                <tr>
                    <td></td>
                    <td colspan="3">
                        <span id="TipsBName" class="error" style ="display:none;">请输入姓名</span>
                    </td>
                </tr>    
                <tr>
                    <td class="name" style="width:100px;">姓名</td>
                    <td>
                        <asp:TextBox ID ="txtBName" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                    <td class="name">性别</td>
                    <td>
                        <asp:RadioButtonList ID ="rdBGender" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="男" Value ="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="女" Value ="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>                    
                    <td class="name">婚姻状况</td>
                    <td>
                        <asp:RadioButtonList ID ="rdBMarital" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow">
                            <asp:ListItem Text="未婚" Value ="0" Selected="True"></asp:ListItem>
                            <asp:ListItem Text="已婚" Value ="1"></asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td colspan="2"></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <span id="TipsBBirthday" CssClass="txt" class="error" style="display:none;">请输入出生日期</span>
                    </td>
                </tr>
                <tr>
                    <td class="name">出生日期</td>
                    <td>
                        <asp:TextBox ID="txtBBirthday" runat="server" CssClass ="txt Wdate" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'})" ></asp:TextBox>
                    </td>
                    <td class="name">工作年限</td>
                    <td>
                        <asp:DropDownList ID ="ddlWorkYear" CssClass="ddl" runat="server"></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <span id="TipsBCity" class="error" style="display:none;">请选择居住城市</span>
                    </td>
                    <td></td>
                    <td>
                        <span id="TipsBHuKou" class="error" style="display:none;">请选择户口所在地</span>
                    </td>
                </tr>
                <tr>
                    <td class="name">居住地</td>
                    <td>
                        <asp:TextBox ID ="txtBCity" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                    <td class="name">户口</td>
                    <td>
                        <asp:TextBox ID ="txtBHuKou" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <span id="TipsBEmail" class="error" style="display:none;">请输入邮箱</span>
                    </td>
                    <td></td>
                    <td>
                        <span id="TipsBMobile" class="error" style="display:none;">请输入手机号码</span>
                    </td>
                </tr>
                <tr>
                    <td class="name">邮箱</td>
                    <td>
                        <asp:TextBox ID="txtBEmail" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                    <td class="name">手机号码</td>
                    <td>
                        <asp:TextBox ID ="txtBMobile" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <span id="TipsBTel" class="error" style="display:none;">请输入正确的电话号码</span>
                    </td>
                    <td></td>
                    <td>
                        <span id="TipsBFax" class="error" style="display:none;">请输入正确的传真号码</span>
                    </td>
                </tr>
                <tr>
                    <td class="name">电话号码</td>
                    <td>
                        <asp:TextBox ID="txtBTel" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                    <td class="name">传真号码</td>
                    <td>
                        <asp:TextBox ID="txtBFax" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="name">详细地址</td>
                    <td colspan="3">
                        <asp:TextBox ID="txtBAddress" CssClass="txt" runat="server"></asp:TextBox>
                    </td>
                </tr>  
                <tr>
                    <td valign="top" class="name">关键字</td>
                    <td colspan="2">
                        <asp:TextBox ID="txtBKeyword" TextMode="MultiLine" Rows="3" Columns="35" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <span>请输入代表你个人的关键词，限10个，用空格隔开。如行业、特长、业绩等，每词不超过6个汉字(12个英文字母)。</span>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <input type="button" class="btn" id="btnBSaveBase" value="保存" />
                        <input type="button" class="btn" id="btnBCancel" value="取消" />
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
                        <div style="float:right;">
                            <input type="button" onclick="ShowUpdate(this);" class="btn1" value="修改" />
                        </div>
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
        <input id="btnAddWork" type="button" class="btn1" value="添加" />
    </div>

    <!--工作信息显示、编辑模板-->
    <div id="Template_Info" style="display:none;width:60%">
        <div style="float:right;">
            <input type="button" class="btn1" onclick="ShowUpdate(this);" value="修改" />
        </div>
        <table class="baseinfo" cellpadding="1" cellspacing="1">
            <tr>
                <td class="name">时间</td>
                <td colspan="3">
                    <span id="lblStartDate"></span>
                    到
                    <span id="lblEndDate"></span>
                </td>
            </tr>
            <tr>
                <td class="name">
                    公司名称
                </td>
                <td >
                    <span id="lblCompanyName"></span>
                </td>
                <td class="name">
                    规模
                </td>
                <td>
                    <span id="lblScale"></span>
                </td>
            </tr>
            <tr>
                <td class="name">
                    部门
                </td>
                <td>
                    <span id="lblDepartments"></span>
                </td>
                <td class="name">
                    职位
                </td>
                <td>
                    <span id="lblPosition"></span>
                </td>
            </tr>
            <tr>
                <td class="name">
                    工作描述
                </td>
                <td colspan="3">
                    <span id="lblDescription"></span>
                </td>
            </tr>
        </table>
    </div>
    <div id="Template_Edit" style="display:none; width:60%;">
        <div style="float:right;">
            <a href="javascript:void(0)" onclick="DeleteWork(this);">删除</a>
            <input type="button" class="btn1" onclick="UpdateWork(this);" value="保存" />
        </div>
        <table class="baseedit">
            <tr>
                <td></td>
                <td>
                    <span id="TipsStartDate" class="error" style="display:none;">请输入起始日期</span>
                </td>
            </tr>
            <tr>
                <td class="name">时间</td>
                <td colspan="3">
                    <input id="txtStartDate" type="text" class="Wdate txt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" onblur="StartDateValidation(this);" />
                    到
                    <input id="txtEndDate" type="text" class="Wdate txt" onfocus="WdatePicker({dateFmt:'yyyy-MM-dd'});" />
                    &nbsp;&nbsp;(后一项不填表示至今)
                </td>
            </tr>

            <tr>
                <td></td>
                <td colspan="3">
                    <span id="TipsCompanyName" class="error" style="display:none;">请输入公司名称</span>
                </td>
            </tr>
            <tr>
                <td class="name">
                    公司名称
                </td>
                <td >
                    <input id="txtCompanyName" class="txt" onblur="CompanyNameValidation(this);" type="text" />
                </td>
                <td class="name">
                    规模
                </td>
                <td>
                    <asp:DropDownList ID ="ddlScale" class="ddl" runat="server"></asp:DropDownList>
                </td>
            </tr>

            <tr>                
                <td></td>
                <td>
                    <span id="TipsDepartments" class="error" style="display:none;">请输入部门名称</span>
                </td>                
                <td></td>
                <td>
                    <span id="TipsPosition" class="error" style="display:none;">请输入职位</span>
                </td>
            </tr>
            <tr>
                <td class="name">
                    部门
                </td>
                <td>
                    <input id="txtDepartments" type="text" class="txt" onblur="DepartmentsValidation(this);" />
                </td>
                <td class="name">
                    职位
                </td>
                <td>
                    <input id="txtPosition" type="text" class="txt" onblur="PositionValidation(this);" />
                </td>
            </tr>

            <tr>                
                <td></td>
                <td colspan="3">
                    <span id="TipsDescription" class="error"style="display:none;">请输入工作描述</span>
                </td>
            </tr>
            <tr>
                <td class="name" valign="top">
                    工作描述
                </td>
                <td colspan ="3">
                    <textarea id ="txtJobDescription" onblur="DescriptionValidation(this);" rows="3" cols="60"></textarea>
                </td>
            </tr>
        </table>
    </div>
    </form>
    
</body>
</html>
