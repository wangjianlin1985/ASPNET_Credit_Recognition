using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ŀ����ҵ���߼���*/
    public class bllProjectType{
        /*�����Ŀ����*/
        public static bool AddProjectType(ENTITY.ProjectType projectType)
        {
            return DAL.dalProjectType.AddProjectType(projectType);
        }

        /*����typeId��ȡĳ����Ŀ���ͼ�¼*/
        public static ENTITY.ProjectType getSomeProjectType(int typeId)
        {
            return DAL.dalProjectType.getSomeProjectType(typeId);
        }

        /*������Ŀ����*/
        public static bool EditProjectType(ENTITY.ProjectType projectType)
        {
            return DAL.dalProjectType.EditProjectType(projectType);
        }

        /*ɾ����Ŀ����*/
        public static bool DelProjectType(string p)
        {
            return DAL.dalProjectType.DelProjectType(p);
        }

        /*��ѯ��Ŀ����*/
        public static System.Data.DataSet GetProjectType(string strWhere)
        {
            return DAL.dalProjectType.GetProjectType(strWhere);
        }

        /*����������ҳ��ѯ��Ŀ����*/
        public static System.Data.DataTable GetProjectType(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProjectType.GetProjectType(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ŀ����*/
        public static System.Data.DataSet getAllProjectType()
        {
            return DAL.dalProjectType.getAllProjectType();
        }
    }
}
