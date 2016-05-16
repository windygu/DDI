using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDIV2.Model
{
    [Serializable]
    public partial class ConfigFileFormatNameParm
    {
        public ConfigFileFormatNameParm()
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
        private int _ConfigId;
        /// <summary>
        /// 配置id
        /// </summary>
        public int ConfigId
        {
            set { _ConfigId = value; }
            get { return _ConfigId; }
        }
        /// <summary>
        /// 变量名称 
        /// </summary>
        private string _Name;
        public string Name
        {
            set { _Name = value; }
            get { return _Name; }
        }
        /// <summary>
        /// 变量后格式
        /// </summary>
        private string _variableType;
        public string VariableType
        {
            set { _variableType = value; }
            get { return _variableType; }
        }
        /// <summary>
        /// 数据来源
        /// </summary>
        private string _DataSource;
        public string DataSource
        {
            set { _DataSource = value; }
            get { return _DataSource; }
        }
        /// <summary>
        ///连接符 
        /// </summary> 
        private string _Connector;
        public string Connector
        {
            set { _Connector = value; }
            get { return _Connector; }
        }
       
    }
}
