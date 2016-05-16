using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class SupAndDrugRelation
    {
        public SupAndDrugRelation()
        { }

        private int _userid;
        public int  UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }

        private string _supcode;
        public string SupCode
        {
            set { _supcode = value; }
            get { return _supcode; }
        }
        private string _supname;
        public string SupName
        {
            set { _supname = value; }
            get { return _supname; }
        }
        private string _goodscode;
        public string GoodsCode
        {
            set { _goodscode = value; }
            get { return _goodscode; }
        }
        private string _goodsname;
        public string GoodsName
        {
            set { _goodsname = value; }
            get { return _goodsname; }
        }
        private string _goodsspec;
        public string GoodsSpec
        {
            set { _goodsspec = value; }
            get { return _goodsspec; }
        }
        private string _createman;
        public string CreateMan
        {
            set { _createman = value; }
            get { return _createman; }
        }
        private DateTime _createdate;
        public DateTime CreateDate
        {
            set { _createdate = value; }
            get { return _createdate; }
        }
        private string _daleteman;
        public string DeleteMan
        {
            set { _daleteman = value; }
            get { return _daleteman; }
        }
        private DateTime? _deletedate;
        public DateTime? DeleteData
        {
            set { _deletedate = value; }
            get { return _deletedate; }
        }
        private string _isenabled;
        public string IsEnabled
        {
            set { _isenabled = value; }
            get { return _isenabled; }
        }
    }
}
