using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���´�ҵ��Ŀҵ���߼���ʵ��*/
    public class dalProject
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӵ��´�ҵ��Ŀʵ��*/
        public static bool AddProject(ENTITY.Project project)
        {
            string sql = "insert into Project(title,projectPhoto,content,projectDate,projectFile,userObj,addTime,affirmStateObj,projectScore,affirmUserName,shzt,shenHeResult) values(@title,@projectPhoto,@content,@projectDate,@projectFile,@userObj,@addTime,@affirmStateObj,@projectScore,@affirmUserName,@shzt,@shenHeResult)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@projectPhoto",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@projectDate",SqlDbType.DateTime),
             new SqlParameter("@projectFile",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@affirmStateObj",SqlDbType.Int),
             new SqlParameter("@projectScore",SqlDbType.Float),
             new SqlParameter("@affirmUserName",SqlDbType.VarChar),
             new SqlParameter("@shzt",SqlDbType.VarChar),
             new SqlParameter("@shenHeResult",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = project.title; //��Ŀ����
            parm[1].Value = project.projectPhoto; //��ĿͼƬ
            parm[2].Value = project.content; //��Ŀ����
            parm[3].Value = project.projectDate; //��Ŀ����
            parm[4].Value = project.projectFile; //��Ŀ֤������
            parm[5].Value = project.userObj; //��Ŀѧ��
            parm[6].Value = project.addTime; //�ύʱ��
            parm[7].Value = project.affirmStateObj; //�϶�״̬
            parm[8].Value = project.projectScore; //�϶�ѧ��
            parm[9].Value = project.affirmUserName; //�϶���
            parm[10].Value = project.shzt; //���״̬
            parm[11].Value = project.shenHeResult; //��˽��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����projectId��ȡĳ�����´�ҵ��Ŀ��¼*/
        public static ENTITY.Project getSomeProject(int projectId)
        {
            /*������ѯsql*/
            string sql = "select * from Project where projectId=" + projectId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Project project = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                project = new ENTITY.Project();
                project.projectId = Convert.ToInt32(DataRead["projectId"]);
                project.title = DataRead["title"].ToString();
                project.projectPhoto = DataRead["projectPhoto"].ToString();
                project.content = DataRead["content"].ToString();
                project.projectDate = Convert.ToDateTime(DataRead["projectDate"].ToString());
                project.projectFile = DataRead["projectFile"].ToString();
                project.userObj = DataRead["userObj"].ToString();
                project.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
                project.affirmStateObj = Convert.ToInt32(DataRead["affirmStateObj"]);
                project.projectScore = float.Parse(DataRead["projectScore"].ToString());
                project.affirmUserName = DataRead["affirmUserName"].ToString();
                project.shzt = DataRead["shzt"].ToString();
                project.shenHeResult = DataRead["shenHeResult"].ToString();
            }
            return project;
        }

        /*���´��´�ҵ��Ŀʵ��*/
        public static bool EditProject(ENTITY.Project project)
        {
            string sql = "update Project set title=@title,projectPhoto=@projectPhoto,content=@content,projectDate=@projectDate,projectFile=@projectFile,userObj=@userObj,addTime=@addTime,affirmStateObj=@affirmStateObj,projectScore=@projectScore,affirmUserName=@affirmUserName,shzt=@shzt,shenHeResult=@shenHeResult where projectId=@projectId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@projectPhoto",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@projectDate",SqlDbType.DateTime),
             new SqlParameter("@projectFile",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@affirmStateObj",SqlDbType.Int),
             new SqlParameter("@projectScore",SqlDbType.Float),
             new SqlParameter("@affirmUserName",SqlDbType.VarChar),
             new SqlParameter("@shzt",SqlDbType.VarChar),
             new SqlParameter("@shenHeResult",SqlDbType.VarChar),
             new SqlParameter("@projectId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = project.title;
            parm[1].Value = project.projectPhoto;
            parm[2].Value = project.content;
            parm[3].Value = project.projectDate;
            parm[4].Value = project.projectFile;
            parm[5].Value = project.userObj;
            parm[6].Value = project.addTime;
            parm[7].Value = project.affirmStateObj;
            parm[8].Value = project.projectScore;
            parm[9].Value = project.affirmUserName;
            parm[10].Value = project.shzt;
            parm[11].Value = project.shenHeResult;
            parm[12].Value = project.projectId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����´�ҵ��Ŀ*/
        public static bool DelProject(string p)
        {
            string sql = "delete from Project where projectId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���´�ҵ��Ŀ*/
        public static DataSet GetProject(string strWhere)
        {
            try
            {
                string strSql = "select * from Project" + strWhere + " order by projectId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ���´�ҵ��Ŀ*/
        public static System.Data.DataTable GetProject(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Project";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "projectId", strShow, strSql, strWhere, " projectId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllProject()
        {
            try
            {
                string strSql = "select * from Project";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
