using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���´�ҵ��Ŀҵ���߼���*/
    public class bllProject{
        /*��Ӵ��´�ҵ��Ŀ*/
        public static bool AddProject(ENTITY.Project project)
        {
            return DAL.dalProject.AddProject(project);
        }

        /*����projectId��ȡĳ�����´�ҵ��Ŀ��¼*/
        public static ENTITY.Project getSomeProject(int projectId)
        {
            return DAL.dalProject.getSomeProject(projectId);
        }

        /*���´��´�ҵ��Ŀ*/
        public static bool EditProject(ENTITY.Project project)
        {
            return DAL.dalProject.EditProject(project);
        }

        /*ɾ�����´�ҵ��Ŀ*/
        public static bool DelProject(string p)
        {
            return DAL.dalProject.DelProject(p);
        }

        /*��ѯ���´�ҵ��Ŀ*/
        public static System.Data.DataSet GetProject(string strWhere)
        {
            return DAL.dalProject.GetProject(strWhere);
        }

        /*����������ҳ��ѯ���´�ҵ��Ŀ*/
        public static System.Data.DataTable GetProject(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProject.GetProject(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĴ��´�ҵ��Ŀ*/
        public static System.Data.DataSet getAllProject()
        {
            return DAL.dalProject.getAllProject();
        }
    }
}
