using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�϶�״̬ҵ���߼���*/
    public class bllAffirmState{
        /*����϶�״̬*/
        public static bool AddAffirmState(ENTITY.AffirmState affirmState)
        {
            return DAL.dalAffirmState.AddAffirmState(affirmState);
        }

        /*����stateId��ȡĳ���϶�״̬��¼*/
        public static ENTITY.AffirmState getSomeAffirmState(int stateId)
        {
            return DAL.dalAffirmState.getSomeAffirmState(stateId);
        }

        /*�����϶�״̬*/
        public static bool EditAffirmState(ENTITY.AffirmState affirmState)
        {
            return DAL.dalAffirmState.EditAffirmState(affirmState);
        }

        /*ɾ���϶�״̬*/
        public static bool DelAffirmState(string p)
        {
            return DAL.dalAffirmState.DelAffirmState(p);
        }

        /*��ѯ�϶�״̬*/
        public static System.Data.DataSet GetAffirmState(string strWhere)
        {
            return DAL.dalAffirmState.GetAffirmState(strWhere);
        }

        /*����������ҳ��ѯ�϶�״̬*/
        public static System.Data.DataTable GetAffirmState(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalAffirmState.GetAffirmState(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е��϶�״̬*/
        public static System.Data.DataSet getAllAffirmState()
        {
            return DAL.dalAffirmState.getAllAffirmState();
        }
    }
}
