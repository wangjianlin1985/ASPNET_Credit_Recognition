using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*创新创业项目业务逻辑层*/
    public class bllProject{
        /*添加创新创业项目*/
        public static bool AddProject(ENTITY.Project project)
        {
            return DAL.dalProject.AddProject(project);
        }

        /*根据projectId获取某条创新创业项目记录*/
        public static ENTITY.Project getSomeProject(int projectId)
        {
            return DAL.dalProject.getSomeProject(projectId);
        }

        /*更新创新创业项目*/
        public static bool EditProject(ENTITY.Project project)
        {
            return DAL.dalProject.EditProject(project);
        }

        /*删除创新创业项目*/
        public static bool DelProject(string p)
        {
            return DAL.dalProject.DelProject(p);
        }

        /*查询创新创业项目*/
        public static System.Data.DataSet GetProject(string strWhere)
        {
            return DAL.dalProject.GetProject(strWhere);
        }

        /*根据条件分页查询创新创业项目*/
        public static System.Data.DataTable GetProject(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProject.GetProject(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的创新创业项目*/
        public static System.Data.DataSet getAllProject()
        {
            return DAL.dalProject.getAllProject();
        }
    }
}
