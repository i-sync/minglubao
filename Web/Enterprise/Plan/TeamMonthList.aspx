<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TeamMonthList.aspx.cs" Inherits="Web.Enterprise.Plan.TeamMonthList" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>历史月份列表</title>
    <link rel="Stylesheet" type="text/css" href="../../Styles/Site.css" />
    <script type="text/javascript" src="../../JS/jquery-1.6.4.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="nav">
        <h3>
            计划完成情况</h3>
    </div>
    <div id="lookbar">
        <div class="baritem item">
            <a href="TeamDaily.aspx">今天</a>
        </div>
        <div class="baritem item">
            <a href="TeamMonth.aspx">本月</a>
        </div>
        <div class="baritem cur">
            <a href="TeamMonthList.aspx"  style="font-weight: bold; color: Red;">历史月份</a>
        </div>
    </div>
    <div id="divTab" class="barInfoList divlist" style="width: 90%; display:block; height:300px;">
    
    </div>
    </form>
</body>
</html>
