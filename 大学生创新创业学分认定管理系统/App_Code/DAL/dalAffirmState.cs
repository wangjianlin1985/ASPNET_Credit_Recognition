using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�϶�״̬ҵ���߼���ʵ��*/
    public class dalAffirmState
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*����϶�״̬ʵ��*/
        public static bool AddAffirmState(ENTITY.AffirmState affirmState)
        {
            string sql = "insert into AffirmState(stateName) values(@stateName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = affirmState.stateName; //״̬����

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����stateId��ȡĳ���϶�״̬��¼*/
        public static ENTITY.AffirmState getSomeAffirmState(int stateId)
        {
            /*������ѯsql*/
            string sql = "select * from AffirmState where stateId=" + stateId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.AffirmState affirmState = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                affirmState = new ENTITY.AffirmState();
                affirmState.stateId = Convert.ToInt32(DataRead["stateId"]);
                affirmState.stateName = DataRead["stateName"].ToString();
            }
            return affirmState;
        }

        /*�����϶�״̬ʵ��*/
        public static bool EditAffirmState(ENTITY.AffirmState affirmState)
        {
            string sql = "update AffirmState set stateName=@stateName where stateId=@stateId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@stateName",SqlDbType.VarChar),
             new SqlParameter("@stateId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = affirmState.stateName;
            parm[1].Value = affirmState.stateId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���϶�״̬*/
        public static bool DelAffirmState(string p)
        {
            string sql = "delete from AffirmState where stateId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�϶�״̬*/
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

        /*��ѯ�϶�״̬*/
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
