using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*ѧ��ת��ҵ���߼���*/
    public class bllCreditTran{
        /*���ѧ��ת��*/
        public static bool AddCreditTran(ENTITY.CreditTran creditTran)
        {
            return DAL.dalCreditTran.AddCreditTran(creditTran);
        }

        /*����tranId��ȡĳ��ѧ��ת����¼*/
        public static ENTITY.CreditTran getSomeCreditTran(int tranId)
        {
            return DAL.dalCreditTran.getSomeCreditTran(tranId);
        }

        /*����ѧ��ת��*/
        public static bool EditCreditTran(ENTITY.CreditTran creditTran)
        {
            return DAL.dalCreditTran.EditCreditTran(creditTran);
        }

        /*ɾ��ѧ��ת��*/
        public static bool DelCreditTran(string p)
        {
            return DAL.dalCreditTran.DelCreditTran(p);
        }

        /*��ѯѧ��ת��*/
        public static System.Data.DataSet GetCreditTran(string strWhere)
        {
            return DAL.dalCreditTran.GetCreditTran(strWhere);
        }

        /*����������ҳ��ѯѧ��ת��*/
        public static System.Data.DataTable GetCreditTran(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalCreditTran.GetCreditTran(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�ѧ��ת��*/
        public static System.Data.DataSet getAllCreditTran()
        {
            return DAL.dalCreditTran.getAllCreditTran();
        }
    }
}
