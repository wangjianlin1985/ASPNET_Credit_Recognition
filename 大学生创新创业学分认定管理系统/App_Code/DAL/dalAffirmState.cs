using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*认定状态业务逻辑层实现*/
    public class dalAffirmState
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加认定状态实现*/
        public static bool AddAffirmState(ENTITY.AffirmState affirmState)
        {
            string sql = "insert into AffirmState(stateName) values(@stateName)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = affirmState.stateName; //状态名称

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据stateId获取某条认定状态记录*/
        public static ENTITY.AffirmState getSomeAffirmState(int stateId)
        {
            /*构建查询sql*/
            string sql = "select * from AffirmState where stateId=" + stateId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.AffirmState affirmState = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                affirmState = new ENTITY.AffirmState();
                affirmState.stateId = Convert.ToInt32(DataRead["stateId"]);
                affirmState.stateName = DataRead["stateName"].ToString();
            }
            return affirmState;
        }

        /*更新认定状态实现*/
        public static bool EditAffirmState(ENTITY.AffirmState affirmState)
        {
            string sql = "update AffirmState set stateName=@stateName where stateId=@stateId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar),
             new SqlParameter("@stateId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = affirmState.stateName;
            parm[1].Value = affirmState.stateId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除认定状态*/
        public static bool DelAffirmState(string p)
        {
            string sql = "delete from AffirmState where stateId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询认定状态*/
        public static DataSet GetAffirmState(string strWhere)
        {
            try
            {
                string strSql = "select * from AffirmState" + strWhere + " order by stateId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询认定状态*/
        public static System.Data.DataTable GetAffirmState(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from AffirmState";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "stateId", strShow, strSql, strWhere, " stateId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllAffirmState()
        {
            try
            {
                string strSql = "select * from AffirmState";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
