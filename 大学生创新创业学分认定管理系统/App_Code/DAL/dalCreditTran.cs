using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*ѧ��ת��ҵ���߼���ʵ��*/
    public class dalCreditTran
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*���ѧ��ת��ʵ��*/
        public static bool AddCreditTran(ENTITY.CreditTran creditTran)
        {
            string sql = "insert into CreditTran(title,content,zmcl,userObj,addTime,affirmStateObj,projectScore,affirmUserName,shzt,shenHeResult) values(@title,@content,@zmcl,@userObj,@addTime,@affirmStateObj,@projectScore,@affirmUserName,@shzt,@shenHeResult)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@zmcl",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@affirmStateObj",SqlDbType.Int),
             new SqlParameter("@projectScore",SqlDbType.Float),
             new SqlParameter("@affirmUserName",SqlDbType.VarChar),
             new SqlParameter("@shzt",SqlDbType.VarChar),
             new SqlParameter("@shenHeResult",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = creditTran.title; //����
            parm[1].Value = creditTran.content; //����
            parm[2].Value = creditTran.zmcl; //֤������
            parm[3].Value = creditTran.userObj; //����ѧ��
            parm[4].Value = creditTran.addTime; //�ύʱ��
            parm[5].Value = creditTran.affirmStateObj; //�϶�״̬
            parm[6].Value = creditTran.projectScore; //�϶�ѧ��
            parm[7].Value = creditTran.affirmUserName; //�϶���
            parm[8].Value = creditTran.shzt; //���״̬
            parm[9].Value = creditTran.shenHeResult; //��˽��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����tranId��ȡĳ��ѧ��ת����¼*/
        public static ENTITY.CreditTran getSomeCreditTran(int tranId)
        {
            /*������ѯsql*/
            string sql = "select * from CreditTran where tranId=" + tranId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CreditTran creditTran = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                creditTran = new ENTITY.CreditTran();
                creditTran.tranId = Convert.ToInt32(DataRead["tranId"]);
                creditTran.title = DataRead["title"].ToString();
                creditTran.content = DataRead["content"].ToString();
                creditTran.zmcl = DataRead["zmcl"].ToString();
                creditTran.userObj = DataRead["userObj"].ToString();
                creditTran.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
                creditTran.affirmStateObj = Convert.ToInt32(DataRead["affirmStateObj"]);
                creditTran.projectScore = float.Parse(DataRead["projectScore"].ToString());
                creditTran.affirmUserName = DataRead["affirmUserName"].ToString();
                creditTran.shzt = DataRead["shzt"].ToString();
                creditTran.shenHeResult = DataRead["shenHeResult"].ToString();
            }
            return creditTran;
        }

        /*����ѧ��ת��ʵ��*/
        public static bool EditCreditTran(ENTITY.CreditTran creditTran)
        {
            string sql = "update CreditTran set title=@title,content=@content,zmcl=@zmcl,userObj=@userObj,addTime=@addTime,affirmStateObj=@affirmStateObj,projectScore=@projectScore,affirmUserName=@affirmUserName,shzt=@shzt,shenHeResult=@shenHeResult where tranId=@tranId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@zmcl",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@affirmStateObj",SqlDbType.Int),
             new SqlParameter("@projectScore",SqlDbType.Float),
             new SqlParameter("@affirmUserName",SqlDbType.VarChar),
             new SqlParameter("@shzt",SqlDbType.VarChar),
             new SqlParameter("@shenHeResult",SqlDbType.VarChar),
             new SqlParameter("@tranId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = creditTran.title;
            parm[1].Value = creditTran.content;
            parm[2].Value = creditTran.zmcl;
            parm[3].Value = creditTran.userObj;
            parm[4].Value = creditTran.addTime;
            parm[5].Value = creditTran.affirmStateObj;
            parm[6].Value = creditTran.projectScore;
            parm[7].Value = creditTran.affirmUserName;
            parm[8].Value = creditTran.shzt;
            parm[9].Value = creditTran.shenHeResult;
            parm[10].Value = creditTran.tranId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ��ѧ��ת��*/
        public static bool DelCreditTran(string p)
        {
            string sql = "delete from CreditTran where tranId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯѧ��ת��*/
        public static DataSet GetCreditTran(string strWhere)
        {
            try
            {
                string strSql = "select * from CreditTran" + strWhere + " order by tranId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯѧ��ת��*/
        public static System.Data.DataTable GetCreditTran(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from CreditTran";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "tranId", strShow, strSql, strWhere, " tranId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllCreditTran()
        {
            try
            {
                string strSql = "select * from CreditTran";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
