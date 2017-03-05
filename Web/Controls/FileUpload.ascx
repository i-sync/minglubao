<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FileUpload.ascx.cs"
    Inherits="Web.Controls.FileUpload" %>
<!--  <%=this.ID %>控件实现开始 -->
<script type="text/javascript">

    //限制文件数
    var <%=this.ID %>_mflFileMaxCount = <%=SimUploadLimit %>;
    var <%=this.ID %>_mflFileCount = <%=mflFileCount %>;
    //限制文件类型
    var <%=this.ID %>_mflCouldUserTypes = "<%=FileExt %>";
    
    //新增文件列表
    function <%=this.ID %>_AddFile(obj) {
        var fileName = obj.value;
        
        var filePathList = $("#<%=this.ClientID %>_hdNewFileList").attr("value");
        var newFileCount = 0;
        var fileID = obj.id;
        if($("#<%=hdNewFileCount.ClientID %>").attr("value") != "")
        {
            newFileCount = parseInt($("#<%=hdNewFileCount.ClientID %>").attr("value"));
        }
        if (<%=this.ID %>_mflFileCount >= <%=this.ID %>_mflFileMaxCount) {
            window.alert("信息提示：系统设置，最多只能同时上传[" + <%=this.ID %>_mflFileMaxCount + "]个文件.");
            return;
        }
        
        if ($.trim(fileName) == "") {
            //用户没有选择文件
            return;
        }
        
        if(filePathList.indexOf(fileName) != -1)
        {
            alert("已选择这个文件!");
            var itemIndex = 0;
            var fileinput = "<input type='file' name='" + fileID + "' id='" + fileID + "' onchange='<%=this.ID %>_AddFile(this)'  class='button_common'/>";
            for (itemIndex = 0; itemIndex < $("#"+fileID).length; itemIndex++) {
                if ($("#"+fileID).eq(itemIndex).html() == fileinput) {
                    $("#"+fileID).eq(itemIndex).remove();
                }
            }
            $("#<%=this.ID %>_FileUploadList").append();
            return;
        }

        var type = fileName.substring(fileName.lastIndexOf("."));
        type = type.toLowerCase();
        var sFileName = fileName.substring(fileName.lastIndexOf("\\")+1);
        var newFileLoadTmp = "<input type='file' name='<%=this.ID %>_mflFileUpload" + (<%=this.ID %>_mflFileCount + 1) + "' id='<%=this.ID %>_mflFileUpload" + (<%=this.ID %>_mflFileCount + 1) + "' onchange='<%=this.ID %>_AddFile(this)'  class='button_common'  />"
        var newLiFile = "<li><span title='"+sFileName+"'>" +cutString(sFileName,12) + "</span>&nbsp;<img src='/images/del.jpg' onclick='<%=this.ID %>_mflRemoveFile(this)' /></li>";
        
        if ($.trim(type) == "" || $.trim(sFileName) == "") {
            //用户没有选择文件
            return;
        }
        if (<%=this.ID %>_mflCouldUserTypes.indexOf("|" + type + "") != -1) {
            ///执行js方法
            <%if(FunName!=""){ %>
                <%=FunName %>(fileName);
            <%} %>
            $(obj).css("display","none");
            $("#<%=this.ID %>_FileUploadList").append(newFileLoadTmp);
            $("#<%=this.ID %>_NewFileList").append(newLiFile);
            <%=this.ID %>_mflFileCount += 1;
            newFileCount += 1;
            $("#<%=hdNewFileCount.ClientID %>").attr("value",newFileCount);
            $("#<%=this.ID %>_FileCountMsg").html("已选文件数："+<%=this.ID %>_mflFileCount);
            filePathList = filePathList + "|" + fileName;
            $("#<%=this.ID %>_hdNewFileList").attr("value",filePathList);
        }
        else {
            window.alert("信息提示：文件类型不正确。");
            var itemIndex = 0;
            var fileinput = "<input type='file' name='" + fileID + "' id='" + fileID + "' onchange='<%=this.ID %>_AddFile(this)'  class='button_common'/>";
            for (itemIndex = 0; itemIndex < $("#"+fileID).length; itemIndex++) {
                if ($("#"+fileID).eq(itemIndex).html() == fileinput) {
                    $("#"+fileID).eq(itemIndex).remove();
                }
            }
            $("#<%=this.ID %>_FileUploadList").append();
        }
    }

    //删除新增文件列表
    function <%=this.ID %>_mflRemoveFile(obj) {
        if (confirm("信息提示：确定移除该文件？")) {
            var innerHtml = $(obj).parent().html();
            var itemIndex = 0;
            for (itemIndex = 0; itemIndex < $("#<%=this.ID %>_NewFileList li").length; itemIndex++) {
                if ($("#<%=this.ID %>_NewFileList li").eq(itemIndex).html() == innerHtml) {
                    break;
                }
            }
            var filePathList = $("#<%=this.ID %>_hdNewFileList").attr("value");
            var fileName = $("#<%=this.ID %>_FileUploadList input").eq(itemIndex).attr("value");
            var newFileCount = parseInt($("#<%=hdNewFileCount.ClientID %>").attr("value"));
            $("#<%=this.ID %>_NewFileList li").eq(itemIndex).remove();
            $("#<%=this.ID %>_FileUploadList input").eq(itemIndex).remove();
            <%=this.ID %>_mflFileCount -= 1;
            newFileCount -= 1;
            $("#<%=hdNewFileCount.ClientID %>").attr("value",newFileCount);
            $("#<%=this.ID %>_FileCountMsg").html("已选文件数：" + <%=this.ID %>_mflFileCount);
            filePathList = filePathList.replace("|" + fileName,"");
            $("#<%=this.ID %>_hdNewFileList").attr("value",filePathList);
        }
    }
    
    //删除反显文件列表

    function <%=this.ID %>_mflRemoveOldFile(obj,strfileID) {
        if (confirm("信息提示：确定移除该文件？")) {
            var innerHtml = $(obj).parent().html();
            var itemIndex = 0;
            for (itemIndex = 0; itemIndex < $("#<%=OldFileList.ClientID %> li").length; itemIndex++) {
                if ($("#<%=OldFileList.ClientID %> li").eq(itemIndex).html() == innerHtml) {
                    break;
                }
            }
            $(obj).parent().remove();
            //同步hdOldFileList中保存的数据
            var oldfilelist = eval($("#<%=hdOldFileList.ClientID %>").attr("value"));//读取旧文件列表
            var tmpoldfilelist = [];
            var tmpdelfilelist = [];
            if($("#<%=hdDelFileList.ClientID %>").attr("value") != "")
            {
                tmpdelfilelist = eval($("#<%=hdDelFileList.ClientID %>").attr("value"));//读取待删除文件列表
            }
            for(var i = 0;i < oldfilelist.length;i++)
            {
                if(oldfilelist[i].FileName == strfileID)
                {
                    //移除的项
                    tmpdelfilelist.push(oldfilelist[i]);
                }
                else
                {
                    //保留的项
                    tmpoldfilelist.push(oldfilelist[i]);
                }
            }
            if(tmpoldfilelist.length == 0)
            {
                $("#<%=hdOldFileList.ClientID %>").attr("value","");
            }
            else
            {
                $("#<%=hdOldFileList.ClientID %>").attr("value",$.toJSON(tmpoldfilelist));
            }
            $("#<%=hdDelFileList.ClientID %>").val($.toJSON(tmpdelfilelist));
            $("#<%=OldFileList.ClientID %> li").eq(itemIndex).remove();
            <%=this.ID %>_mflFileCount -= 1;
            $("#<%=this.ID %>_FileCountMsg").html("已选文件数：" + <%=this.ID %>_mflFileCount);
            //alert("ok");
        }
    }
    
    //检测是否上传文件
    function <%=this.ID %>_CheckCount()
    {
        var fileCount = <%=this.ID %>_mflFileCount;
        var IsHave = "<%=IsHave %>";
        if(fileCount == 0 && IsHave == "True")
        {
            alert("请上传附件！谢谢");
            return false;
        }
        return true;
    }
        //截取字符串并在其后加....
    function cutString(str,n){
        var result="";
        if(str.length<=n){
            result=str;
        }else{
            result=str.substring(0,n)+"...";        
        }
        return result;
    }

</script>
<style type="text/css">
    #<%=this.ID %>_FileList ol{ margin:0; padding:0;}
    #<%=this.ID %>_FileList ol li{ margin:0; padding:0;}
</style>
<div id="<%=this.ID %>">
    <div id="<%=this.ID %>_FileUploadList" title="文件类型：<%=FileExt.Replace("|","| ") %>"
        class="btn3 upload_bg" style="cursor: pointer">
        <asp:FileUpload ID="mflFileUpload" runat="server" CssClass="button_common"/></div>
</div>
<div id="<%=this.ID %>_FileList">
    <input id="hdNewFileList" type="hidden" runat="server" />
    <input id="hdOldFileList" type="hidden" runat="server" />
    <input id="hdDelFileList" type="hidden" runat="server" />
    <ol id="OldFileList" runat="server">
    </ol>
    <ol id="<%=this.ID %>_NewFileList">
    </ol>
</div>
<div>
    <asp:Button ID="btnUpload" runat="server" Text="批量上传" Visible="False" OnClick="btnUpload_Click" />
    <span id="<%=this.ID %>_FileCountMsg" style="display: none;">已选文件数：<%=mflFileCount%></span>
    <input id="hdNewFileCount" type="hidden" runat="server" />
    <p>
        <span id="TipContent" runat="server"></span>
    </p>
</div>
<!--  <%=this.ID %>控件实现结束 -->