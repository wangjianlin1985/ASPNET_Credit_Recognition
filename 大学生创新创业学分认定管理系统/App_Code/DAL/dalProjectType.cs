using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*项目类型业务逻辑层实现*/
    public class dalProjectType
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加项目类型实现*/
        public static bool AddProjectType(ENTITY.ProjectType projectType)
        {
            string sql = "insert into ProjectType(typeName) values(@typeName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = projectType.typeName; //类型名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据typeId获取某条项目类型记录*/
        public static ENTITY.ProjectType getSomeProjectType(int typeId)
        {
            /*构建查询sql*/
            string sql = "select * from ProjectType where typeId=" + typeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProjectType projectType = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                projectType = new ENTITY.ProjectType();
                projectType.typeId = Convert.ToInt32(DataRead["typeId"]);
                projectType.typeName = DataRead["typeName"].ToString();
            }
            return projectType;
        }

        /*更新项目类型实现*/
        public static bool EditProjectType(ENTITY.ProjectType projectType)
        {
            string sql = "update ProjectType set typeName=@typeName where typeId=@typeId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar),
             new SqlParameter("@typeId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = projectType.typeName;
            parm[1].Value = projectType.typeId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除项目类型*/
        public static bool DelProjectType(string p)
        {
            string sql = "delete from ProjectType where typeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询项目类型*/
        public static DataSet GetProjectType(string strWhere)
        {
            try
            {
                string strSql = "select * from ProjectType" + strWhere + " order by typeId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询项目类型*/
        public static System.Data.DataTable GetProjectType(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ProjectType";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "typeId", strShow, strSql, strWhere, " typeId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllProjectType()
        {
            try
            {
                string strSql = "select * from ProjectType";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
