using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*学分转换业务逻辑层实现*/
    public class dalCreditTran
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加学分转换实现*/
        public static bool AddCreditTran(ENTITY.CreditTran creditTran)
        {
            string sql = "insert into CreditTran(title,content,zmcl,userObj,addTime,affirmStateObj,projectScore,affirmUserName,shzt,shenHeResult) values(@title,@content,@zmcl,@userObj,@addTime,@affirmStateObj,@projectScore,@affirmUserName,@shzt,@shenHeResult)";
            /*构建sql参数*/
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
            /*给参数赋值*/
            parm[0].Value = creditTran.title; //标题
            parm[1].Value = creditTran.content; //描述
            parm[2].Value = creditTran.zmcl; //证明材料
            parm[3].Value = creditTran.userObj; //申请学生
            parm[4].Value = creditTran.addTime; //提交时间
            parm[5].Value = creditTran.affirmStateObj; //认定状态
            parm[6].Value = creditTran.projectScore; //认定学分
            parm[7].Value = creditTran.affirmUserName; //认定者
            parm[8].Value = creditTran.shzt; //审核状态
            parm[9].Value = creditTran.shenHeResult; //审核结果

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据tranId获取某条学分转换记录*/
        public static ENTITY.CreditTran getSomeCreditTran(int tranId)
        {
            /*构建查询sql*/
            string sql = "select * from CreditTran where tranId=" + tranId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.CreditTran creditTran = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新学分转换实现*/
        public static bool EditCreditTran(ENTITY.CreditTran creditTran)
        {
            string sql = "update CreditTran set title=@title,content=@content,zmcl=@zmcl,userObj=@userObj,addTime=@addTime,affirmStateObj=@affirmStateObj,projectScore=@projectScore,affirmUserName=@affirmUserName,shzt=@shzt,shenHeResult=@shenHeResult where tranId=@tranId";
            /*构建sql参数信息*/
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
            /*为参数赋值*/
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
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除学分转换*/
        public static bool DelCreditTran(string p)
        {
            string sql = "delete from CreditTran where tranId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询学分转换*/
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

        /*查询学分转换*/
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
