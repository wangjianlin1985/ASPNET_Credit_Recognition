<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Affirm_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
        <!--
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;用户管理</div>
        <div class="MenuNote" style="display:none;" id="UserInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="UserInfoEdit.aspx" target="main">添加用户</a></li>
                <li><a href="UserInfoList.aspx" target="main">用户查询</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;认定者管理</div>
        <div class="MenuNote" style="display:none;" id="AffirmDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="AffirmEdit.aspx" target="main">添加认定者</a></li>
                <li><a href="AffirmList.aspx" target="main">认定者查询</a></li> 
            </ul>
        </div>
       

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;项目类型管理</div>
        <div class="MenuNote" style="display:none;" id="ProjectTypeDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="ProjectTypeEdit.aspx" target="main">添加项目类型</a></li>
                <li><a href="ProjectTypeList.aspx" target="main">项目类型查询</a></li> 
            </ul>
        </div>

         -->

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;创新创业项目管理</div>
        <div class="MenuNote" style="display:none;" id="ProjectDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <!--<li><a href="ProjectEdit.aspx" target="main">添加创新创业项目</a></li>-->
                <li><a href="ProjectRdList.aspx" target="main">创新创业项目认定</a></li> 
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;学分转换管理</div>
        <div class="MenuNote" style="display:none;" id="CreditTranDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <!--<li><a href="CreditTranEdit.aspx" target="main">添加学分转换</a></li>-->
                <li><a href="CreditTranRdList.aspx" target="main">学分转换认定</a></li> 
            </ul>
        </div>
        
        <!--
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;认定状态管理</div>
        <div class="MenuNote" style="display:none;" id="AffirmStateDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="AffirmStateEdit.aspx" target="main">添加认定状态</a></li>
                <li><a href="AffirmStateList.aspx" target="main">认定状态查询</a></li> 
            </ul>
        </div>
        -->

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;留言管理</div>
        <div class="MenuNote" style="display:none;" id="LeavewordDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="LeavewordEdit.aspx" target="main">添加留言</a></li>
                <li><a href="LeavewordList.aspx" target="main">留言查询</a></li> 
            </ul>
        </div>

        <!--
        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;新闻公告管理</div>
        <div class="MenuNote" style="display:none;" id="NoticeDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="NoticeEdit.aspx" target="main">添加新闻公告</a></li>
                <li><a href="NoticeList.aspx" target="main">新闻公告查询</a></li> 
            </ul>
        </div>

 

         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;客户信息管理</div>
        <div class="MenuNote" style="display:none;" id="Div2" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
          
                <li><a href="M_CusList.aspx" target="main">客户信息列表</a></li>  
            </ul>
        </div>
        -->

       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
                <li><a href="AffirmSelfEdit.aspx" target="main">修改个人信息</a></li>          
            </ul>
        </div>
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
