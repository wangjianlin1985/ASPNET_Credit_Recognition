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
    ///Affirm 的摘要说明：认定者实体
    /// </summary>

    public class Affirm
    {
        /*认定者用户名*/
        private string _affirmUserName;
        public string affirmUserName
        {
            get { return _affirmUserName; }
            set { _affirmUserName = value; }
        }

        /*登录密码*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*认定者名称*/
        private string _affirmName;
        public string affirmName
        {
            get { return _affirmName; }
            set { _affirmName = value; }
        }

        /*认定者身份*/
        private string _affirmIdentify;
        public string affirmIdentify
        {
            get { return _affirmIdentify; }
            set { _affirmIdentify = value; }
        }

        /*认定者备注*/
        private string _affirmMemo;
        public string affirmMemo
        {
            get { return _affirmMemo; }
            set { _affirmMemo = value; }
        }

    }
}
