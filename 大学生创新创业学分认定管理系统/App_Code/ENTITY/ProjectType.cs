using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///ProjectType ��ժҪ˵������Ŀ����ʵ��
    /// </summary>

    public class ProjectType
    {
        /*����id*/
        private int _typeId;
        public int typeId
        {
            get { return _typeId; }
            set { _typeId = value; }
        }

        /*��������*/
        private string _typeName;
        public string typeName
        {
            get { return _typeName; }
            set { _typeName = value; }
        }

    }
}
