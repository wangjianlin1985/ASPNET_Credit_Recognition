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
    ///CreditTran 的摘要说明：学分转换实体
    /// </summary>

    public class CreditTran
    {
        /*记录id*/
        private int _tranId;
        public int tranId
        {
            get { return _tranId; }
            set { _tranId = value; }
        }

        /*标题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*描述*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*证明材料*/
        private string _zmcl;
        public string zmcl
        {
            get { return _zmcl; }
            set { _zmcl = value; }
        }

        /*申请学生*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*提交时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

        /*认定状态*/
        private int _affirmStateObj;
        public int affirmStateObj
        {
            get { return _affirmStateObj; }
            set { _affirmStateObj = value; }
        }

        /*认定学分*/
        private float _projectScore;
        public float projectScore
        {
            get { return _projectScore; }
            set { _projectScore = value; }
        }

        /*认定者*/
        private string _affirmUserName;
        public string affirmUserName
        {
            get { return _affirmUserName; }
            set { _affirmUserName = value; }
        }

        /*审核状态*/
        private string _shzt;
        public string shzt
        {
            get { return _shzt; }
            set { _shzt = value; }
        }

        /*审核结果*/
        private string _shenHeResult;
        public string shenHeResult
        {
            get { return _shenHeResult; }
            set { _shenHeResult = value; }
        }

    }
}
