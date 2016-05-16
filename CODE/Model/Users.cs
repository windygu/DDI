using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
     public  class Users
    {
        public Users()
        { }
        private int _id;
        /// <summary>
        /// 编码
        /// </summary>
        public int Id
        {
            set { _id = value; }
            get { return _id; }
        }

        private string _loginname;
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string LoginName
        {
            set { _loginname = value; }
            get { return _loginname; }
        }
        private string _loginpwg;
        /// <summary>
        /// 用户登密码
        /// </summary>
        public string LoginPwd
        {
            set { _loginpwg = value; }
            get { return _loginpwg; }
        }


        private string _orgcode;
        public string OrgCode
        {
            set { _orgcode = value; }
            get { return _orgcode; }
        }

        private string _orgname;
        public string OrgName
        {
            set { _orgname = value; }
            get { return _orgname; }
        }

        private string _enabled;
        public string Enabled
        {
            set { _enabled = value; }
            get { return _enabled; }
        }
        private string _empname;
        public string EmpName
        {
            set { _empname = value; }
            get { return _empname; }
        }



    }
}
