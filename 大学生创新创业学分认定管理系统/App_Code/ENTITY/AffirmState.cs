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
    ///AffirmState 的摘要说明：认定状态实体
    /// </summary>

    public class AffirmState
    {
        /*状态id*/
        private int _stateId;
        public int stateId
        {
            get { return _stateId; }
            set { _stateId = value; }
        }

        /*状态名称*/
        private string _stateName;
        public string stateName
        {
            get { return _stateName; }
            set { _stateName = value; }
        }

    }
}
