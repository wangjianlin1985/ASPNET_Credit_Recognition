using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*创新创业项目业务逻辑层实现*/
    public class dalProject
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加创新创业项目实现*/
        public static bool AddProject(ENTITY.Project project)
        {
            string sql = "insert into Project(title,projectPhoto,content,projectDate,projectFile,userObj,addTime,affirmStateObj,projectScore,affirmUserName,shzt,shenHeResult) values(@title,@projectPhoto,@content,@projectDate,@projectFile,@userObj,@addTime,@affirmStateObj,@projectScore,@affirmUserName,@shzt,@shenHeResult)";
            /*构建sql参数*/
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
            /*给参数赋值*/
            parm[0].Value = project.title; //项目标题
            parm[1].Value = project.projectPhoto; //项目图片
            parm[2].Value = project.content; //项目内容
            parm[3].Value = project.projectDate; //项目日期
            parm[4].Value = project.projectFile; //项目证明资料
            parm[5].Value = project.userObj; //项目学生
            parm[6].Value = project.addTime; //提交时间
            parm[7].Value = project.affirmStateObj; //认定状态
            parm[8].Value = project.projectScore; //认定学分
            parm[9].Value = project.affirmUserName; //认定者
            parm[10].Value = project.shzt; //审核状态
            parm[11].Value = project.shenHeResult; //审核结果

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据projectId获取某条创新创业项目记录*/
        public static ENTITY.Project getSomeProject(int projectId)
        {
            /*构建查询sql*/
            string sql = "select * from Project where projectId=" + projectId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Project project = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新创新创业项目实现*/
        public static bool EditProject(ENTITY.Project project)
        {
            string sql = "update Project set title=@title,projectPhoto=@projectPhoto,content=@content,projectDate=@projectDate,projectFile=@projectFile,userObj=@userObj,addTime=@addTime,affirmStateObj=@affirmStateObj,projectScore=@projectScore,affirmUserName=@affirmUserName,shzt=@shzt,shenHeResult=@shenHeResult where projectId=@projectId";
            /*构建sql参数信息*/
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
            /*为参数赋值*/
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
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除创新创业项目*/
        public static bool DelProject(string p)
        {
            string sql = "delete from Project where projectId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询创新创业项目*/
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

        /*查询创新创业项目*/
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
