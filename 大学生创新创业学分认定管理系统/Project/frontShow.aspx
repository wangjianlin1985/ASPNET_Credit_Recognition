<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontShow.aspx.cs" Inherits="Project_frontShow" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
    ENTITY.Project project = BLL.bllProject.getSomeProject(int.Parse(Request.QueryString["projectId"]));
%>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
  <TITLE>查看创新创业项目详情</TITLE>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/animate.css" rel="stylesheet"> 
</head>
<body style="margin-top:70px;"> 
<uc:header ID="header" runat="server" />
<div class="container">
	<ul class="breadcrumb">
  		<li><a href="<%=basePath %>index.aspx">首页</a></li>
  		<li><a href="<%=basePath %>Project/frontList.aspx">创新创业项目信息</a></li>
  		<li class="active">详情查看</li>
	</ul>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">记录id:</div>
		<div class="col-md-10 col-xs-6"><%=project.projectId%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">项目标题:</div>
		<div class="col-md-10 col-xs-6"><%=project.title%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">项目图片:</div>
		<div class="col-md-10 col-xs-6"><img class="img-responsive" src="<%=basePath %><%=project.projectPhoto %>"  border="0px"/></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">项目内容:</div>
		<div class="col-md-10 col-xs-6"><%=project.content%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">项目日期:</div>
		<div class="col-md-10 col-xs-6"><%=project.projectDate%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">项目证明资料:</div>
		<div class="col-md-10 col-xs-6"><a href="<%=basePath%><%=project.projectFile %>" target="_blank"><%=project.projectFile%></a></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">项目学生:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllUserInfo.getSomeUserInfo(project.userObj).name %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">提交时间:</div>
		<div class="col-md-10 col-xs-6"><%=project.addTime%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">认定状态:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllAffirmState.getSomeAffirmState(project.affirmStateObj).stateName %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">认定学分:</div>
		<div class="col-md-10 col-xs-6"><%=project.projectScore%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">认定者:</div>
		<div class="col-md-10 col-xs-6"><%=project.affirmUserName%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">审核状态:</div>
		<div class="col-md-10 col-xs-6"><%=project.shzt%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">审核结果:</div>
		<div class="col-md-10 col-xs-6"><%=project.shenHeResult%></div>
	</div>
	<div class="row bottom15">
		<div class="col-md-2 col-xs-4"></div>
		<div class="col-md-6 col-xs-6">
			<button onclick="history.back();" class="btn btn-primary">返回</button>
		</div>
	</div>
</div> 
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script>
var basePath = "<%=basePath%>";
$(function(){
        /*小屏幕导航点击关闭菜单*/
        $('.navbar-collapse a').click(function(){
            $('.navbar-collapse').collapse('hide');
        });
        new WOW().init();
 })
 </script> 
</body>
</html>

