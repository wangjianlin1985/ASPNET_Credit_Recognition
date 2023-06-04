using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*学分转换业务逻辑层*/
    public class bllCreditTran{
        /*添加学分转换*/
        public static bool AddCreditTran(ENTITY.CreditTran creditTran)
        {
            return DAL.dalCreditTran.AddCreditTran(creditTran);
        }

        /*根据tranId获取某条学分转换记录*/
        public static ENTITY.CreditTran getSomeCreditTran(int tranId)
        {
            return DAL.dalCreditTran.getSomeCreditTran(tranId);
        }

        /*更新学分转换*/
        public static bool EditCreditTran(ENTITY.CreditTran creditTran)
        {
            return DAL.dalCreditTran.EditCreditTran(creditTran);
        }

        /*删除学分转换*/
        public static bool DelCreditTran(string p)
        {
            return DAL.dalCreditTran.DelCreditTran(p);
        }

        /*查询学分转换*/
        public static System.Data.DataSet GetCreditTran(string strWhere)
        {
            return DAL.dalCreditTran.GetCreditTran(strWhere);
        }

        /*根据条件分页查询学分转换*/
        public static System.Data.DataTable GetCreditTran(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCreditTran.GetCreditTran(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的学分转换*/
        public static System.Data.DataSet getAllCreditTran()
        {
            return DAL.dalCreditTran.getAllCreditTran();
        }
    }
}
