<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="CreditTran_frontList" %>
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
<title>学分转换查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#creditTranListPanel" aria-controls="creditTranListPanel" role="tab" data-toggle="tab">学分转换列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加学分转换</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="creditTranListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>标题</td><td>证明材料</td><td>申请学生</td><td>提交时间</td><td>认定状态</td><td>认定学分</td><td>认定者</td><td>审核状态</td><td>审核结果</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpCreditTran" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td> 
 											<td><%#Eval("title")%></td>
 											<td><%#Eval("zmcl").ToString() == ""?"暂无文件":"<a href='../" + Eval("zmcl").ToString() + "' target='_blank'>" + Eval("zmcl").ToString() +  "</a>" %></td>
 											<td><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
 											<td><%#Eval("addTime")%></td>
 											<td><%#GetAffirmStateaffirmStateObj(Eval("affirmStateObj").ToString())%></td>
 											<td><%#Eval("projectScore")%></td>
 											<td><%#Eval("affirmUserName")%></td>
 											<td><%#Eval("shzt")%></td>
 											<td><%#Eval("shenHeResult")%></td>
 											<td>
 												<a href="frontshow.aspx?tranId=<%#Eval("tranId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="creditTranEdit('<%#Eval("tranId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="creditTranDelete('<%#Eval("tranId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

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
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>学分转换查询</h1>
		</div>
			<div class="form-group">
				<label for="title">标题:</label>
				<asp:TextBox ID="title" runat="server"  CssClass="form-control" placeholder="请输入标题"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="userObj_tranId">申请学生：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择申请学生"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="addTime">提交时间:</label>
				<asp:TextBox ID="addTime"  runat="server" CssClass="form-control" placeholder="请选择提交时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <div class="form-group">
            	<label for="affirmStateObj_tranId">认定状态：</label>
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
            <input type=hidden name=currentPage value="" />
            <asp:Button ID="btnSearch" CssClass="btn btn-primary" runat="server" Text="查询" onclick="btnSearch_Click" />
	</div>

	</div>
 </form>
</div> 
<div id="creditTranEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;学分转换信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="creditTranEditForm" id="creditTranEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="creditTran_tranId_edit" class="col-md-3 text-right">记录id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="creditTran_tranId_edit" name="creditTran.tranId" class="form-control" placeholder="请输入记录id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="creditTran_title_edit" class="col-md-3 text-right">标题:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="creditTran_title_edit" name="creditTran.title" class="form-control" placeholder="请输入标题">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="creditTran_content_edit" class="col-md-3 text-right">描述:</label>
		  	 <div class="col-md-9">
			    <textarea id="creditTran_content_edit" name="creditTran.content" rows="8" class="form-control" placeholder="请输入描述"></textarea>
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="creditTran_zmcl_edit" class="col-md-3 text-right">证明材料:</label>
		  	 <div class="col-md-9">
			    <a id="creditTran_zmclA" target="_blank"></a><br/>
			    <input type="hidden" id="creditTran_zmcl" name="creditTran.zmcl"/>
			    <input id="zmclFile" name="zmclFile" type="file" size="50" />
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="creditTran_userObj_user_name_edit" class="col-md-3 text-right">申请学生:</label>
		  	 <div class="col-md-9">
			    <select id="creditTran_userObj_user_name_edit" name="creditTran.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="creditTran_addTime_edit" class="col-md-3 text-right">提交时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date creditTran_addTime_edit col-md-12" data-link-field="creditTran_addTime_edit">
                    <input class="form-control" id="creditTran_addTime_edit" name="creditTran.addTime" size="16" type="text" value="" placeholder="请选择提交时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="creditTran_affirmStateObj_stateId_edit" class="col-md-3 text-right">认定状态:</label>
		  	 <div class="col-md-9">
			    <select id="creditTran_affirmStateObj_stateId_edit" name="creditTran.affirmStateObj.stateId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="creditTran_projectScore_edit" class="col-md-3 text-right">认定学分:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="creditTran_projectScore_edit" name="creditTran.projectScore" class="form-control" placeholder="请输入认定学分">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="creditTran_affirmUserName_edit" class="col-md-3 text-right">认定者:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="creditTran_affirmUserName_edit" name="creditTran.affirmUserName" class="form-control" placeholder="请输入认定者">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="creditTran_shzt_edit" class="col-md-3 text-right">审核状态:</label>
		  	 <div class="col-md-9">
			    <input type="text" id="creditTran_shzt_edit" name="creditTran.shzt" class="form-control" placeholder="请输入审核状态">
			 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="creditTran_shenHeResult_edit" class="col-md-3 text-right">审核结果:</label>
		  	 <div class="col-md-9">
			    <textarea id="creditTran_shenHeResult_edit" name="creditTran.shenHeResult" rows="8" class="form-control" placeholder="请输入审核结果"></textarea>
			 </div>
		  </div>
		</form> 
	    <style>#creditTranEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxCreditTranModify();">提交</button>
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
/*弹出修改学分转换界面并初始化数据*/
function creditTranEdit(tranId) {
	$.ajax({
		url :  basePath + "CreditTran/CreditTranController.aspx?action=getCreditTran&tranId=" + tranId,
		type : "get",
		dataType: "json",
		success : function (creditTran, response, status) {
			if (creditTran) {
				$("#creditTran_tranId_edit").val(creditTran.tranId);
				$("#creditTran_title_edit").val(creditTran.title);
				$("#creditTran_content_edit").val(creditTran.content);
				$("#creditTran_zmcl").val(creditTran.zmcl);
				$("#creditTran_zmclA").text(creditTran.zmcl);
				$("#creditTran_zmclA").attr("href", basePath +　creditTran.zmcl);
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#creditTran_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#creditTran_userObj_user_name_edit").html(html);
		        		$("#creditTran_userObj_user_name_edit").val(creditTran.userObjPri);
					}
				});
				$("#creditTran_addTime_edit").val(creditTran.addTime);
				$.ajax({
					url: basePath + "AffirmState/AffirmStateController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(affirmStates,response,status) { 
						$("#creditTran_affirmStateObj_stateId_edit").empty();
						var html="";
		        		$(affirmStates).each(function(i,affirmState){
		        			html += "<option value='" + affirmState.stateId + "'>" + affirmState.stateName + "</option>";
		        		});
		        		$("#creditTran_affirmStateObj_stateId_edit").html(html);
		        		$("#creditTran_affirmStateObj_stateId_edit").val(creditTran.affirmStateObjPri);
					}
				});
				$("#creditTran_projectScore_edit").val(creditTran.projectScore);
				$("#creditTran_affirmUserName_edit").val(creditTran.affirmUserName);
				$("#creditTran_shzt_edit").val(creditTran.shzt);
				$("#creditTran_shenHeResult_edit").val(creditTran.shenHeResult);
				$('#creditTranEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除学分转换信息*/
function creditTranDelete(tranId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "CreditTran/CreditTranController.aspx?action=delete",
			data : {
				tranId : tranId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "CreditTran/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交学分转换信息表单给服务器端修改*/
function ajaxCreditTranModify() {
	$.ajax({
		url :  basePath + "CreditTran/CreditTranController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#creditTranEditForm")[0]),
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

    /*提交时间组件*/
    $('.creditTran_addTime_edit').datetimepicker({
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

