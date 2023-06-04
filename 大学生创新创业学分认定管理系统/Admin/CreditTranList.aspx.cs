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
    public partial class CreditTranList : System.Web.UI.Page
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
            ListItem li = new ListItem("������", "");
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
            ListItem li = new ListItem("������", "0");
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

        protected void BtnCreditTranAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreditTranEdit.aspx");
        }

        protected void BtnAllDel_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(HSelectID.Value.Trim()))
            {
                try
                {
                    if (BLL.bllCreditTran.DelCreditTran(HSelectID.Value.Trim()))
                    {
                        Common.ShowMessage.Show(Page, "suess", "��Ϣ�ɹ�ɾ��..", "CreditTranList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "error", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա..");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "error", "ɾ��ʧ��..");
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
            DataTable dsLog = BLL.bllCreditTran.GetCreditTran(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
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
            RpCreditTran.DataSource = dsLog;
            RpCreditTran.DataBind();
            PageMes.Text = string.Format("[ÿҳ<font color=green>{0}</font>�� ��<font color=red>{1}</font>ҳ����<font color=green>{2}</font>ҳ   ��<font color=green>{3}</font>��]", PageSize, NowPage, AllPage, DataCount);
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
        protected void RpCreditTran_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Del")
            {
                try
                {
                    if (BLL.bllCreditTran.DelCreditTran((e.CommandArgument.ToString())))
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ���ɹ�...", "CreditTranList.aspx");
                    }
                    else
                    {
                        Common.ShowMessage.Show(Page, "seuss", "��Ϣɾ��ʧ�ܣ������Ի���ϵ������Ա...", "CreditTranList.aspx");
                    }
                }
                catch
                {
                    Common.ShowMessage.Show(Page, "seuss", "ɾ��ʧ��...", "CreditTranList.aspx");
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
            Response.Redirect("CreditTranList.aspx?title=" + title.Text.Trim()  + "&&userObj=" + userObj.SelectedValue.Trim()+ "&&addTime=" + addTime.Text.Trim() + "&&affirmStateObj=" + affirmStateObj.SelectedValue.Trim()+ "&&affirmUserName=" + affirmUserName.Text.Trim()+ "&&shzt=" + shzt.Text.Trim());
        }

        protected void btnExport_Click(object sender, EventArgs e)
        {
            DataSet creditTranDataSet = BLL.bllCreditTran.GetCreditTran(HWhere.Value); 
            System.Text.StringBuilder sb = new System.Text.StringBuilder(); 
            sb.Append("<table borderColor='black' border='1' >");
            sb.Append("<thead><tr><th colSpan='10'>ѧ��ת����¼</th></tr>");
            sb.Append("<tr class='title'>");
            sb.Append("<th>��¼id</th>");
            sb.Append("<th>����</th>");
            sb.Append("<th>֤������</th>");
            sb.Append("<th>����ѧ��</th>");
            sb.Append("<th>�ύʱ��</th>");
            sb.Append("<th>�϶�״̬</th>");
            sb.Append("<th>�϶�ѧ��</th>");
            sb.Append("<th>�϶���</th>");
            sb.Append("<th>���״̬</th>");
            sb.Append("<th>��˽��</th>");
            sb.Append("</tr></thead>");
            sb.Append("<tbody>");
            for (int i = 0; i < creditTranDataSet.Tables[0].Rows.Count; i++)
            {
                DataRow dr = creditTranDataSet.Tables[0].Rows[i];
                sb.Append("<tr class=content>");
                sb.Append("<td>" + dr["tranId"].ToString() + "</td>");
                sb.Append("<td>" + dr["title"].ToString() + "</td>");
                sb.Append("<td>" + dr["zmcl"].ToString() + "</td>");
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
            string filename = "ѧ��ת����¼.xls";
            CommonTool.ExportToExcel(filename, content, css);
        }

        protected string GetBaseUrl()
        {
            return Request.Url.AbsoluteUri.Substring(0, Request.Url.AbsoluteUri.LastIndexOf("/Admin"));
        }
    }
}
