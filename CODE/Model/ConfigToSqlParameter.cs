using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDIV2.Model
{
    [Serializable]
    public partial class ConfigToSqlParameter
    {
        public ConfigToSqlParameter()
        { }
        private int _ParameterId;
        /// <summary>
        /// 编码
        /// </summary>
        public int ParameterId
        {
            set { _ParameterId = value; }
            get { return _ParameterId; }
        }
        private int _ConfigId;
        /// <summary>
        /// 外键
        /// </summary>
        public int ConfigId
        {
            set { _ConfigId = value; }
            get { return _ConfigId; }
        }
        private string _ParameterName;
        /// <summary>
        /// 名称
        /// </summary>
        public string ParameterName
        {
            set { _ParameterName = value; }
            get { return _ParameterName; }
        }
        private string _ParameterType;
        /// <summary>
        /// 类型
        /// </summary>
        public string ParameterType
        {
            set { _ParameterType = value; }
            get { return _ParameterType; }
        }
        private int _OrderBy;
        /// <summary>
        ///排序 
        /// </summary>
        public int OrderBy
        {
            set { _OrderBy = value; }
            get { return _OrderBy; }
        }
        /// <summary>
        ///说明
        /// </summary>
        private string _Illustrate;
        public string Illustrate
        {
            set { _Illustrate = value; }
            get { return _Illustrate; }
        }
    }
}
