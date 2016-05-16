using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SupUsersRelation
    {
        public SupUsersRelation()
        { }
        private int _userid;
        public int USERID
        {
            set { _userid = value; }
            get { return _userid; }
        }


        private string _supcode;
        public string SUPCODE
        {
            set { _supcode = value; }
            get { return _supcode; }
        }

        private string _supname;
        public string SUPNAEM
        {
            set { _supname = value; }
            get { return _supname; }
        }

        private string _createman;
        public string CREATEMAN
        {
            set { _createman = value; }
            get { return _createman; }
        }

        private DateTime _createdate;
        public DateTime CREATEDATE
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
    }
}
