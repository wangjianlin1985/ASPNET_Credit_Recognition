<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="Project_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>创新创业项目查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form1" runat="server">
	<div class="col-md-9 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="../index.aspx">首页</a></li>
  			<li><a href="frontList.aspx">创新创业项目信息列表</a></li>
  			<li class="active">查询结果显示</li>
  			<a class="pull-right" href="frontAdd.aspx" style="display:none;">添加创新创业项目</a>
		</ul>
		<div class="row">
			<asp:Repeater ID="RpProject" runat="server">
			<ItemTemplate>
			<div class="col-md-3 bottom15" <%#(((Container.ItemIndex+0)%4==0)?"style='clear:left;'":"") %>>
			  <a href="frontshow.aspx?projectId=<%#Eval("projectId")%>"><img class="img-responsive" src="../<%#Eval("projectPhoto")%>" /></a>
			     <div class="showFields">
			     	<div class="field">
	            		记录id: <%#Eval("projectId")%>
			     	</div>
			     	<div class="field">
	            		项目标题: <%#Eval("title")%>
			     	</div>
			     	<div class="field">
	            		项目内容: <%#Eval("content")%>
			     	</div>
			     	<div class="field">
	            		项目日期: <%#Eval("projectDate")%>
			     	</div>
			     	<div class="field">
	            		项目证明资料:<%#Eval("projectFile").ToString() == ""?"暂无文件":"<a href='../" + Eval("projectFile").ToString() + "' target='_blank'>" + Eval("projectFile").ToString() +  "</a>" %>
			     	</div>
			     	<div class="field">
	            		项目学生:<%#GetUserInfouserObj(Eval("userObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		提交时间: <%#Eval("addTime")%>
			     	</div>
			     	<div class="field">
	            		认定状态:<%#GetAffirmStateaffirmStateObj(Eval("affirmStateObj").ToString())%>
			     	</div>
			     	<div class="field">
	            		认定学分: <%#Eval("projectScore")%>
			     	</div>
			     	<div class="field">
	            		认定者: <%#Eval("affirmUserName")%>
			     	</div>
			     	<div class="field">
	            		审核状态: <%#Eval("shzt")%>
			     	</div>
			     	<div class="field">
	            		审核结果: <%#Eval("shenHeResult")%>
			     	</div>
			        <a class="btn btn-primary top5" href="frontShow.aspx?projectId=<%#Eval("projectId")%>">详情</a>
			        <a class="btn btn-primary top5" onclick="projectEdit('<%#Eval("projectId")%>');" style="display:none;">修改</a>
			        <a class="btn btn-primary top5" onclick="projectDelete('<%#Eval("projectId")%>');" style="display:none;">删除</a>
			     </div>
			</div>
			</ItemTemplate>
			</asp:Repeater>

			<div class="row">
				<div class="col-md-12">
					<nav class="pull-left">
						<ul class="pagination">
 						        <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
 						            onclick="LBHome_Click">[首页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
 						            onclick="LBUp_Click">[上一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
 						            onclick="LBNext_Click">[下一页]</asp:LinkButton>
 						        <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
 						            onclick="LBEnd_Click">[尾页]</asp:LinkButton>
 						        <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
 						        <asp:HiddenField ID="HWhere" runat="server" Value=""/>
 						        <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
 						        <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
 						        <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						</ul>
					</nav>
					<div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
				</div>
			</div>
		</div>
	</div>

	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>创新创业项目查询</h1>
		</div>
			<div class="form-group">
				<label for="title">项目标题:</label>
				<asp:TextBox ID="title" runat="server"  CssClass="form-control" placeholder="请输入项目标题"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="projectDate">项目日期:</label>
				<asp:TextBox ID="projectDate"  runat="server" CssClass="form-control" placeholder="请选择项目日期" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="userObj_user_name">项目学生：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择项目学生"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="addTime">提交时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择提交时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="affirmStateObj_stateId">认定状态：</label>
                <asp:DropDownList ID="affirmStateObj" runat="server"  CssClass="form-control" placeholder="请选择认定状态"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="affirmUserName">认定者:</label>
				<asp:TextBox ID="affirmUserName" runat="server"  CssClass="form-control" placeholder="请输入认定者"></asp:TextBox>
			</div>
			<div class="form-group">
				<label for="shzt">审核状态:</label>
				<asp:TextBox ID="shzt" runat="server"  CssClass="form-control" placeholder="请输入审核状态"></asp:TextBox>
			</div>
        <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>
  </form>
</div>
<div id="projectEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;创新创业项目信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="projectEditForm" id="projectEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="project_projectId_edit" class="col-md-3 text-right">记录id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="project_projectId_edit" name="project.projectId" class="form-control" placeholder="请输入记录id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="project_title_edit" class="col-md-3 text-right">项目标题:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="project_title_edit" name="project.title" class="form-control" placeholder="请输入项目标题">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="project_projectPhoto_edit" class="col-md-3 text-right">项目图片:</label>
		  	 <div class="col-md-9">
			    <img  class="img-responsive" id="project_projectPhotoImg" border="0px"/><br/>
			    <input type="hidden" id="project_projectPhoto" name="project.projectPhoto"/>
			    <input id="projectPhotoFile" name="projectPhotoFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="project_content_edit" class="col-md-3 text-right">项目内容:</label>
		  	 <div class="col-md-9">
			    <textarea id="project_content_edit" name="project.content" rows="8" class="form-control" placeholder="请输入项目内容"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="project_projectDate_edit" class="col-md-3 text-right">项目日期:</label>
		  	 <div class="col-md-9">
                <div class="input-group date project_projectDate_edit col-md-12" data-link-field="project_projectDate_edit" data-link-format="yyyy-mm-dd">
                    <input class="form-control" id="project_projectDate_edit" name="project.projectDate" size="16" type="text" value="" placeholder="请选择项目日期" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="project_projectFile_edit" class="col-md-3 text-right">项目证明资料:</label>
		  	 <div class="col-md-9">
			    <a id="project_projectFileA" target="_blank"></a><br/>
			    <input type="hidden" id="project_projectFile" name="project.projectFile"/>
			    <input id="projectFileFile" name="projectFileFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="project_userObj_user_name_edit" class="col-md-3 text-right">项目学生:</label>
		  	 <div class="col-md-9">
			    <select id="project_userObj_user_name_edit" name="project.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="project_addTime_edit" class="col-md-3 text-right">提交时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date project_addTime_edit col-md-12" data-link-field="project_addTime_edit">
                    <input class="form-control" id="project_addTime_edit" name="project.addTime" size="16" type="text" value="" placeholder="请选择提交时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="project_affirmStateObj_stateId_edit" class="col-md-3 text-right">认定状态:</label>
		  	 <div class="col-md-9">
			    <select id="project_affirmStateObj_stateId_edit" name="project.affirmStateObj.stateId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="project_projectScore_edit" class="col-md-3 text-right">认定学分:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="project_projectScore_edit" name="project.projectScore" class="form-control" placeholder="请输入认定学分">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="project_affirmUserName_edit" class="col-md-3 text-right">认定者:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="project_affirmUserName_edit" name="project.affirmUserName" class="form-control" placeholder="请输入认定者">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="project_shzt_edit" class="col-md-3 text-right">审核状态:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="project_shzt_edit" name="project.shzt" class="form-control" placeholder="请输入审核状态">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="project_shenHeResult_edit" class="col-md-3 text-right">审核结果:</label>
		  	 <div class="col-md-9">
			    <textarea id="project_shenHeResult_edit" name="project.shenHeResult" rows="8" class="form-control" placeholder="请输入审核结果"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#projectEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxProjectModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改创新创业项目界面并初始化数据*/
function projectEdit(projectId) {
	$.ajax({
		url :  basePath + "Project/ProjectController.aspx?action=getProject&projectId=" + projectId,
		type : "get",
		dataType: "json",
		success : function (project, response, status) {
			if (project) {
				$("#project_projectId_edit").val(project.projectId);
				$("#project_title_edit").val(project.title);
				$("#project_projectPhoto").val(project.projectPhoto);
				$("#project_projectPhotoImg").attr("src", basePath +　project.projectPhoto);
				$("#project_content_edit").val(project.content);
				$("#project_projectDate_edit").val(project.projectDate);
				$("#project_projectFile").val(project.projectFile);
				$("#project_projectFileA").text(project.projectFile);
				$("#project_projectFileA").attr("href", basePath +　project.projectFile);
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#project_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#project_userObj_user_name_edit").html(html);
		        		$("#project_userObj_user_name_edit").val(project.userObjPri);
					}
				});
				$("#project_addTime_edit").val(project.addTime);
				$.ajax({
					url: basePath + "AffirmState/AffirmStateController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(affirmStates,response,status) { 
						$("#project_affirmStateObj_stateId_edit").empty();
						var html="";
		        		$(affirmStates).each(function(i,affirmState){
		        			html += "<option value='" + affirmState.stateId + "'>" + affirmState.stateName + "</option>";
		        		});
		        		$("#project_affirmStateObj_stateId_edit").html(html);
		        		$("#project_affirmStateObj_stateId_edit").val(project.affirmStateObjPri);
					}
				});
				$("#project_projectScore_edit").val(project.projectScore);
				$("#project_affirmUserName_edit").val(project.affirmUserName);
				$("#project_shzt_edit").val(project.shzt);
				$("#project_shenHeResult_edit").val(project.shenHeResult);
				$('#projectEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除创新创业项目信息*/
function projectDelete(projectId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "Project/ProjectController.aspx?action=delete",
			data : {
				projectId : projectId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
                    $("#btnSearch").click();
					//location.href= basePath + "Project/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交创新创业项目信息表单给服务器端修改*/
function ajaxProjectModify() {
	$.ajax({
		url :  basePath + "Project/ProjectController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#projectEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

    /*项目日期组件*/
    $('.project_projectDate_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd',
    	minView: 2,
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
    /*提交时间组件*/
    $('.project_addTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

