<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProjectList.aspx.cs" Inherits="chengxusheji.Admin.ProjectList" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>���´�ҵ��Ŀ�б�</title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
   <script src="JavaScript/Admin.js" type="text/javascript"></script>
   <script type="text/javascript" src="../js/jsdate.js"></script>
</head>
<body>
   <form id="form1" runat="server">
    <div class="div_All">
    <div class="Body_Title">���´�ҵ��Ŀ���� �������´�ҵ��Ŀ�б�</div>
     <div class="Body_Search">
        ��Ŀ����&nbsp;&nbsp;<asp:TextBox ID="title" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ��Ŀ����&nbsp;&nbsp; <asp:TextBox ID="projectDate"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        ��Ŀѧ��&nbsp;&nbsp;<asp:DropDownList ID="userObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        �ύʱ��&nbsp;&nbsp; <asp:TextBox ID="addTime"  runat="server" Width="112px" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>&nbsp;&nbsp;
        �϶�״̬&nbsp;&nbsp;<asp:DropDownList ID="affirmStateObj" runat="server"></asp:DropDownList>  &nbsp;&nbsp;
        �϶���&nbsp;&nbsp;<asp:TextBox ID="affirmUserName" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        ���״̬&nbsp;&nbsp;<asp:TextBox ID="shzt" runat="server" Width="123px"></asp:TextBox> &nbsp;&nbsp;
        <asp:Button ID="btnSearch" runat="server" Text="��ѯ" onclick="btnSearch_Click" /> 
        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" runat="server" Text="����excel" OnClick="btnExport_Click" />
    <asp:Repeater ID="RpProject" runat="server" onitemcommand="RpProject_ItemCommand">
        <HeaderTemplate>
            <table cellpadding="2" cellspacing="1" class="Admin_Table">
                <thead>
                    <tr class="Admin_Table_Title">
                        <th>ѡ��</th> 
                        <th>��¼id</th>
                        <th>��Ŀ����</th>
                        <th>��ĿͼƬ</th> 
                        <th>��Ŀ����</th>
                        <th>��Ŀ֤������</th>
                        <th>��Ŀѧ��</th>
                        <th>�ύʱ��</th>
                        <th>�϶�״̬</th>
                        <th>�϶�ѧ��</th>
                        <th>�϶���</th>
                        <th>���״̬</th>
                        <th>��˽��</th>
                        <th>����</th> 
                    </tr>
                </thead>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td align="center"><input type="checkbox" value='<%#Eval("projectId") %>' name="CheckMes" id="DelChecked"/></td>
                <td align="center"><%#Eval("projectId")%> </td>
                <td align="center"><%#Eval("title")%> </td>
                <td align="center"><img src="../<%#Eval("projectPhoto")%>" width=50 height=50 /> 
                  <td align="center"><%# Convert.ToDateTime(Eval("projectDate")).ToShortDateString() %></td>
                <td><%#Eval("projectFile").ToString() == ""?"�����ļ�":"<a href='../" + Eval("projectFile").ToString() + "' target='_blank'>" + Eval("projectFile").ToString() +  "</a>" %></td>
                  <td align="center"><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
                  <td align="center"><%# Convert.ToDateTime(Eval("addTime")).ToShortDateString() + " " + Convert.ToDateTime(Eval("addTime")).ToLongTimeString() %></td>
                  <td align="center"><%#GetAffirmStateaffirmStateObj(Eval("affirmStateObj").ToString())%></td>
                <td align="center"><%#Eval("projectScore")%> </td>
                <td align="center"><%#Eval("affirmUserName")%> </td>
                <td align="center"><%#Eval("shzt")%> </td>
                <td align="center"><%#Eval("shenHeResult")%> </td>
                <td align="center"><a href="ProjectEdit.aspx?projectId=<%#Eval("projectId") %>"><img src="Images/MillMes_ICO.gif" alt="�޸���Ϣ..." /></a><asp:ImageButton class="DelClass" ID="IBDelClass" runat="server" CommandArgument='<%#Eval("projectId")%>' CommandName="Del" ImageUrl="Images/Delete.gif"  ToolTip="ɾ������Ϣ..."/></td>
             </tr>
        </ItemTemplate>
        <FooterTemplate></table></FooterTemplate>
    </asp:Repeater>

    <div class="Body_Search">
        <div class="page_Left">
            <input id="BtnAllSelect" type="button" value="ȫѡ" />&nbsp;
            <asp:Button ID="BtnAllDel" runat="server" Text=" ɾ��ѡ�� " onclick="BtnAllDel_Click" />
        </div>
        <div class="page_Right">
        <span class="pageBtn">   <asp:Label runat="server" ID="PageMes"></asp:Label></span>
            <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn" 
                onclick="LBHome_Click">[��ҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
                onclick="LBUp_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn" 
                onclick="LBNext_Click">[��һҳ]</asp:LinkButton>
            <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn" 
                onclick="LBEnd_Click">[βҳ]</asp:LinkButton>
        </div>
    </div>
    </div>
    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
    <asp:HiddenField ID="HPageSize" runat="server" Value="5"/>
    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
    </form>
</body>
</html>
