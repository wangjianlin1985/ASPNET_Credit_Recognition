using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*认定状态业务逻辑层*/
    public class bllAffirmState{
        /*添加认定状态*/
        public static bool AddAffirmState(ENTITY.AffirmState affirmState)
        {
            return DAL.dalAffirmState.AddAffirmState(affirmState);
        }

        /*根据stateId获取某条认定状态记录*/
        public static ENTITY.AffirmState getSomeAffirmState(int stateId)
        {
            return DAL.dalAffirmState.getSomeAffirmState(stateId);
        }

        /*更新认定状态*/
        public static bool EditAffirmState(ENTITY.AffirmState affirmState)
        {
            return DAL.dalAffirmState.EditAffirmState(affirmState);
        }

        /*删除认定状态*/
        public static bool DelAffirmState(string p)
        {
            return DAL.dalAffirmState.DelAffirmState(p);
        }

        /*查询认定状态*/
        public static System.Data.DataSet GetAffirmState(string strWhere)
        {
            return DAL.dalAffirmState.GetAffirmState(strWhere);
        }

        /*根据条件分页查询认定状态*/
        public static System.Data.DataTable GetAffirmState(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalAffirmState.GetAffirmState(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的认定状态*/
        public static System.Data.DataSet getAllAffirmState()
        {
            return DAL.dalAffirmState.getAllAffirmState();
        }
    }
}
