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
    ///Affirm ��ժҪ˵�����϶���ʵ��
    /// </summary>

    public class Affirm
    {
        /*�϶����û���*/
        private string _affirmUserName;
        public string affirmUserName
        {
            get { return _affirmUserName; }
            set { _affirmUserName = value; }
        }

        /*��¼����*/
        private string _password;
        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        /*�϶�������*/
        private string _affirmName;
        public string affirmName
        {
            get { return _affirmName; }
            set { _affirmName = value; }
        }

        /*�϶������*/
        private string _affirmIdentify;
        public string affirmIdentify
        {
            get { return _affirmIdentify; }
            set { _affirmIdentify = value; }
        }

        /*�϶��߱�ע*/
        private string _affirmMemo;
        public string affirmMemo
        {
            get { return _affirmMemo; }
            set { _affirmMemo = value; }
        }

    }
}
