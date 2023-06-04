using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class ProjectList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BinduserObj();
                BindaffirmStateObj();
                string sqlstr = " where 1=1 ";
                if (Request["title"] != null && Request["title"].ToString() != "")
                {
                    sqlstr += "  and title like '%" + Request["title"].ToString() + "%'";
                    title.Text = Request["title"].ToString();
                }
                if (Request["projectDate"] != null && Request["projectDate"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,projectDate,120) like '" + Request["projectDate"].ToString() + "%'";
                    projectDate.Text = Request["projectDate"].ToString();
                }
                if (Request["userObj"] != null && Request["userObj"].ToString() != "")
                {
                    sqlstr += "  and userObj='" + Request["userObj"].ToString() + "'";
                    userObj.SelectedValue = Request["userObj"].ToString();
                }
                if (Request["addTime"] != null && Request["addTime"].ToString() != "")
                {
                    sqlstr += "  and Convert(varchar,addTime,120) like '" + Request["addTime"].ToString() + "%'";
                    addTime.Text = Request["addTime"].ToString();
                }
                if (Request["affirmStateObj"] != null && Request["affirmStateObj"].ToString() != "0")
                {
                    sqlstr += "  and affirmStateObj=" + Request["affirmStateObj"].ToString();
                    affirmStateObj.SelectedValue = Request["affirmStateObj"].ToString();
                }
                if (Request["affirmUserName"] != null && Request["affirmUserName"].ToString() != "")
                {
                    sqlstr += "  and affirmUserName like '%" + Request["affirmUserName"].ToString() + "%'";
                    affirmUserName.Text = Request["affirmUserName"].ToString();
                }
                if (Request["shzt"] != null && Request["shzt"].ToString() != "")
                {
                    sqlstr += "  and shzt like '%" + Request["shzt"].ToString() + "%'";
                    shzt.Text = Request["shzt"].ToString();
                }
                HWhere.Value = sqlstr;
                BindData("");
            }
        }
        private void BinduserObj()
        {
            ListItem li = new ListItem("不限制", "");
            userObj.Items.Add(li);
            DataSet userObjDs = BLL.bllUserInfo.getAllUserInfo();
            for (int i = 0; i < userObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = userObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["name"].ToString(), dr["name"].ToString());
                userObj.Items.Add(li);
            }
            userObj.SelectedValue = "";
        }

        private void BindaffirmStateObj()
        {
            ListItem li = new ListItem("不限制", "0");
            affirmStateObj.Items.Add(li);
            DataSet affirmStateObjDs = BLL.bllAffirmState.getAllAffirmState();
            for (int i = 0; i < affirmStateObjDs.Tables[0].Rows.Count; i++)
            {
                DataRow dr = affirmStateObjDs.Tables[0].Rows[i];
                li = new ListItem(dr["stateName"].ToString(), dr["stateName"].ToString());
                affirmStateObj.Items.Add(li);
            }
            affirmStateObj.SelectedValue = "0";
        }

        protected void BtnProjectAdd_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ProjectRdEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllProject.DelProject(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "信息成功删除..", "ProjectRdList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "信息删除失败，请重试或联系管理人员..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "删除失败..");
                }
            }
        }

        private void BindData(string strClass)
        {
            int DataCount = 0;
            int NowPage = 1;
            int AllPage = 0;
            int PageSize = Convert.ToInt32(HPageSize.Value);
            switch (strClass)
            {
                case "next":
                    NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                    break;
                case "up":
                    NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                    break;
                case "end":
                    NowPage = Convert.ToInt32(HAllPage.Value);
                    break;
                default:
                    break;
            }
            DataTable dsLog = BLL.bllProject.GetProject(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
            if (dsLog.Rows.Count == 0 || AllPage == 1)
            {
                LBEnd.Enabled = false;
                LBHome.Enabled = false;
                LBNext.Enabled = false;
                LBUp.Enabled = false;
            }
            else if (NowPage == 1)
            {
                LBHome.Enabled = false;
                LBUp.Enabled = false;
                LBNext.Enabled = true;
                LBEnd.Enabled = true;
            }
            else if (NowPage == AllPage)
            {
                LBHome.Enabled = true;
                LBUp.Enabled = true;
                LBNext.Enabled = false;
                LBEnd.Enabled = false;
            }
            else
            {
                LBEnd.Enabled = true;
                LBHome.Enabled = true;
                LBNext.Enabled = true;
                LBUp.Enabled = true;
            }
            RpProject.DataSource = dsLog;
            RpProject.DataBind();
            PageMes.Text = string.Format("[每页<font color=green>{0}</font>条 第<font color=red>{1}</font>页／共<font color=green>{2}</font>页   共<font color=green>{3}</font>条]", PageSize, NowPage, AllPage, DataCount);
            HNowPage.Value = Convert.ToString(NowPage++);
            HAllPage.Value = AllPage.ToString();
        }

        protected void LBHome_Click(object sender, EventArgs e)
        {
            BindData("");
        }
        protected void LBUp_Click(object sender, EventArgs e)
        {
            BindData("up");
        }
        protected void LBNext_Click(object sender, EventArgs e)
        {
            BindData("next");
        }
        protected void LBEnd_Click(object sender, EventArgs e)
        {
            BindData("end");
        }
        protected void RpProject_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllProject.DelProject((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除成功...", "ProjectRdList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "信息删除失败，请重试或联系管理人员...", "ProjectRdList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "删除失败...", "ProjectRdList.aspx");
                }
            }
        }
        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        public string GetAffirmStateaffirmStateObj(string affirmStateObj)
        {
            return BLL.bllAffirmState.getSomeAffirmState(int.Parse(affirmStateObj)).stateName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProjectRdList.aspx?title=" + title.Text.Trim() + "&&projectDate=" + projectDate.Text.Trim() + "&&userObj=" + userObj.SelectedValue.Trim()+ "&&addTime=" + addTime.Text.Trim() + "&&affirmStateObj=" + affirmStateObj.SelectedValue.Trim()+ "&&affirmUserName=" + affirmUserName.Text.Trim()+ "&&shzt=" + shzt.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet projectDataSet = BLL.bllProject.GetProject(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='13'>创新创业项目记录</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>记录id</th>");
            sb.Append("<th>项目标题</th>");
            sb.Append("<th>项目图片</th>");
            sb.Append("<th>项目内容</th>");
            sb.Append("<th>项目日期</th>");
            sb.Append("<th>项目证明资料</th>");
            sb.Append("<th>项目学生</th>");
            sb.Append("<th>提交时间</th>");
            sb.Append("<th>认定状态</th>");
            sb.Append("<th>认定学分</th>");
            sb.Append("<th>认定者</th>");
            sb.Append("<th>审核状态</th>");
            sb.Append("<th>审核结果</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < projectDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = projectDataSet.Tables[0].Rows[i];
                sb.Append("<tr height='60' class=content>");
                sb.Append("<td>" + dr["projectId"].ToString() + "</td>");
                sb.Append("<td>" + dr["title"].ToString() + "</td>");
                sb.Append("<td width=80><span align='center'><img width='80' height='60' border='0' src='" + GetBaseUrl() + "/" +  dr["projectPhoto"].ToString() + "'/></span></td>");
                sb.Append("<td>" + dr["content"].ToString() + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["projectDate"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + dr["projectFile"].ToString() + "</td>");
                sb.Append("<td>" + BLL.bllUserInfo.getSomeUserInfo(dr["userObj"].ToString()).name + "</td>");
                sb.Append("<td>" + Convert.ToDateTime(dr["addTime"]).ToShortDateString() + "</td>");
                sb.Append("<td>" + BLL.bllAffirmState.getSomeAffirmState(Convert.ToInt32(dr["affirmStateObj"])).stateName + "</td>");
                sb.Append("<td>" + dr["projectScore"].ToString() + "</td>");
                sb.Append("<td>" + dr["affirmUserName"].ToString() + "</td>");
                sb.Append("<td>" + dr["shzt"].ToString() + "</td>");
                sb.Append("<td>" + dr["shenHeResult"].ToString() + "</td>");
                sb.Append("</tr>");
            } 
           sb.Append("</tbody></table>");
            string content = sb.ToString();
            string css = ".content{color:red;text-align:center;}";
            string filename = "创新创业项目记录.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
