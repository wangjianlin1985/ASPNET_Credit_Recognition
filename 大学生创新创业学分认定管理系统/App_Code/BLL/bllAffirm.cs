using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�϶���ҵ���߼���*/
    public class bllAffirm{

        public static bool ulogin(ref ENTITY.CusUsers userlogin)
        {
            return DAL.dalAffirm.ulogin(userlogin);
        }


        /*����϶���*/
        public static bool AddAffirm(ENTITY.Affirm affirm)
        {
            return DAL.dalAffirm.AddAffirm(affirm);
        }

        /*����affirmUserName��ȡĳ���϶��߼�¼*/
        public static ENTITY.Affirm getSomeAffirm(string affirmUserName)
        {
            return DAL.dalAffirm.getSomeAffirm(affirmUserName);
        }

        /*�����϶���*/
        public static bool EditAffirm(ENTITY.Affirm affirm)
        {
            return DAL.dalAffirm.EditAffirm(affirm);
        }

        /*ɾ���϶���*/
        public static bool DelAffirm(string p)
        {
            return DAL.dalAffirm.DelAffirm(p);
        }

        /*��ѯ�϶���*/
        public static System.Data.DataSet GetAffirm(string strWhere)
        {
            return DAL.dalAffirm.GetAffirm(strWhere);
        }

        /*����������ҳ��ѯ�϶���*/
        public static System.Data.DataTable GetAffirm(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalAffirm.GetAffirm(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��϶���*/
        public static System.Data.DataSet getAllAffirm()
        {
            return DAL.dalAffirm.getAllAffirm();
        }
    }
}
