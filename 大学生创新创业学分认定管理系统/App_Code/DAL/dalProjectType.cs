using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ŀ����ҵ���߼���ʵ��*/
    public class dalProjectType
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ŀ����ʵ��*/
        public static bool AddProjectType(ENTITY.ProjectType projectType)
        {
            string sql = "insert into ProjectType(typeName) values(@typeName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = projectType.typeName; //��������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����typeId��ȡĳ����Ŀ���ͼ�¼*/
        public static ENTITY.ProjectType getSomeProjectType(int typeId)
        {
            /*������ѯsql*/
            string sql = "select * from ProjectType where typeId=" + typeId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProjectType projectType = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                projectType = new ENTITY.ProjectType();
                projectType.typeId = Convert.ToInt32(DataRead["typeId"]);
                projectType.typeName = DataRead["typeName"].ToString();
            }
            return projectType;
        }

        /*������Ŀ����ʵ��*/
        public static bool EditProjectType(ENTITY.ProjectType projectType)
        {
            string sql = "update ProjectType set typeName=@typeName where typeId=@typeId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@typeName",SqlDbType.VarChar),
             new SqlParameter("@typeId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = projectType.typeName;
            parm[1].Value = projectType.typeId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ŀ����*/
        public static bool DelProjectType(string p)
        {
            string sql = "delete from ProjectType where typeId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ŀ����*/
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

        /*��ѯ��Ŀ����*/
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
