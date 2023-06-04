using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*认定者业务逻辑层实现*/
    public class dalAffirm
    {
        /*待执行的sql语句*/
        public static string sql = "";


        public static bool ulogin(global::ENTITY.CusUsers userlogin)
        {
            string sql = @"select affirmUserName from Affirm where affirmUserName =@affirmUserName and password =@password";
            SqlParameter[] para = new SqlParameter[] { 
             new SqlParameter("@affirmUserName",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar)
           };
            para[0].Value = userlogin.Customername;
            para[1].Value = userlogin.customerpwd; 
            return (DBHelp.ExecuteScalar(sql, para) != null) ? true : false;
        }



        /*添加认定者实现*/
        public static bool AddAffirm(ENTITY.Affirm affirm)
        {
            string sql = "insert into Affirm(affirmUserName,password,affirmName,affirmIdentify,affirmMemo) values(@affirmUserName,@password,@affirmName,@affirmIdentify,@affirmMemo)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@affirmUserName",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@affirmName",SqlDbType.VarChar),
             new SqlParameter("@affirmIdentify",SqlDbType.VarChar),
             new SqlParameter("@affirmMemo",SqlDbType.VarChar)
            };
            /*给参数赋值*/
            parm[0].Value = affirm.affirmUserName; //认定者用户名
            parm[1].Value = affirm.password; //登录密码
            parm[2].Value = affirm.affirmName; //认定者名称
            parm[3].Value = affirm.affirmIdentify; //认定者身份
            parm[4].Value = affirm.affirmMemo; //认定者备注

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据affirmUserName获取某条认定者记录*/
        public static ENTITY.Affirm getSomeAffirm(string affirmUserName)
        {
            /*构建查询sql*/
            string sql = "select * from Affirm where affirmUserName='" + affirmUserName + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Affirm affirm = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                affirm = new ENTITY.Affirm();
                affirm.affirmUserName = DataRead["affirmUserName"].ToString();
                affirm.password = DataRead["password"].ToString();
                affirm.affirmName = DataRead["affirmName"].ToString();
                affirm.affirmIdentify = DataRead["affirmIdentify"].ToString();
                affirm.affirmMemo = DataRead["affirmMemo"].ToString();
            }
            return affirm;
        }

        /*更新认定者实现*/
        public static bool EditAffirm(ENTITY.Affirm affirm)
        {
            string sql = "update Affirm set password=@password,affirmName=@affirmName,affirmIdentify=@affirmIdentify,affirmMemo=@affirmMemo where affirmUserName=@affirmUserName";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@affirmName",SqlDbType.VarChar),
             new SqlParameter("@affirmIdentify",SqlDbType.VarChar),
             new SqlParameter("@affirmMemo",SqlDbType.VarChar),
             new SqlParameter("@affirmUserName",SqlDbType.VarChar)
            };
            /*为参数赋值*/
            parm[0].Value = affirm.password;
            parm[1].Value = affirm.affirmName;
            parm[2].Value = affirm.affirmIdentify;
            parm[3].Value = affirm.affirmMemo;
            parm[4].Value = affirm.affirmUserName;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除认定者*/
        public static bool DelAffirm(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from Affirm where affirmUserName in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询认定者*/
        public static DataSet GetAffirm(string strWhere)
        {
            try
            {
                string strSql = "select * from Affirm" + strWhere + " order by affirmUserName asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询认定者*/
        public static System.Data.DataTable GetAffirm(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Affirm";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "affirmUserName", strShow, strSql, strWhere, " affirmUserName asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllAffirm()
        {
            try
            {
                string strSql = "select * from Affirm";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
