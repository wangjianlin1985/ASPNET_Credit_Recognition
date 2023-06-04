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
    ///CreditTran ��ժҪ˵����ѧ��ת��ʵ��
    /// </summary>

    public class CreditTran
    {
        /*��¼id*/
        private int _tranId;
        public int tranId
        {
            get { return _tranId; }
            set { _tranId = value; }
        }

        /*����*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*����*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*֤������*/
        private string _zmcl;
        public string zmcl
        {
            get { return _zmcl; }
            set { _zmcl = value; }
        }

        /*����ѧ��*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*�ύʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

        /*�϶�״̬*/
        private int _affirmStateObj;
        public int affirmStateObj
        {
            get { return _affirmStateObj; }
            set { _affirmStateObj = value; }
        }

        /*�϶�ѧ��*/
        private float _projectScore;
        public float projectScore
        {
            get { return _projectScore; }
            set { _projectScore = value; }
        }

        /*�϶���*/
        private string _affirmUserName;
        public string affirmUserName
        {
            get { return _affirmUserName; }
            set { _affirmUserName = value; }
        }

        /*���״̬*/
        private string _shzt;
        public string shzt
        {
            get { return _shzt; }
            set { _shzt = value; }
        }

        /*��˽��*/
        private string _shenHeResult;
        public string shenHeResult
        {
            get { return _shenHeResult; }
            set { _shenHeResult = value; }
        }

    }
}
