using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*认定者业务逻辑层*/
    public class bllAffirm{

        public static bool ulogin(ref ENTITY.CusUsers userlogin)
        {
            return DAL.dalAffirm.ulogin(userlogin);
        }


        /*添加认定者*/
        public static bool AddAffirm(ENTITY.Affirm affirm)
        {
            return DAL.dalAffirm.AddAffirm(affirm);
        }

        /*根据affirmUserName获取某条认定者记录*/
        public static ENTITY.Affirm getSomeAffirm(string affirmUserName)
        {
            return DAL.dalAffirm.getSomeAffirm(affirmUserName);
        }

        /*更新认定者*/
        public static bool EditAffirm(ENTITY.Affirm affirm)
        {
            return DAL.dalAffirm.EditAffirm(affirm);
        }

        /*删除认定者*/
        public static bool DelAffirm(string p)
        {
            return DAL.dalAffirm.DelAffirm(p);
        }

        /*查询认定者*/
        public static System.Data.DataSet GetAffirm(string strWhere)
        {
            return DAL.dalAffirm.GetAffirm(strWhere);
        }

        /*根据条件分页查询认定者*/
        public static System.Data.DataTable GetAffirm(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalAffirm.GetAffirm(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的认定者*/
        public static System.Data.DataSet getAllAffirm()
        {
            return DAL.dalAffirm.getAllAffirm();
        }
    }
}
