using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
     public  class FtpConfig
    {
         public FtpConfig()
        { }
        private int _configid;
        /// <summary>
        /// 编码
        /// </summary>
        public int Configid
        {
            set { _configid = value; }
            get { return _configid; }
        }

        private string _ftpuser;
        /// <summary>
        /// 用户登录名
        /// </summary>
        public string FtpUser
        {
            set { _ftpuser = value; }
            get { return _ftpuser; }
        }
        private string _ftpPassWord;
        /// <summary>
        /// 用户登密码
        /// </summary>
        public string FtpPassWord
        {
            set { _ftpPassWord = value; }
            get { return _ftpPassWord; }
        }


        private string _ftpurl;
        public string FtpUrl
        {
            set { _ftpurl = value; }
            get { return _ftpurl; }
        }

        private string _fileurl;
        public string FileUrl
        {
            set { _fileurl = value; }
            get { return _fileurl; }
        }

        private string _enabled;
        public string Enabled
        {
            set { _enabled = value; }
            get { return _enabled; }
        }
      



    }
}
