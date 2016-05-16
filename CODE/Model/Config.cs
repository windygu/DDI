using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDIV2.Model
{
    [Serializable]
    public partial class Config
    {
        public Config()
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
        private int _configType;
        /// <summary>
        /// 配置方式  0 内置配置 1 自定义配置
        /// </summary>
        public int ConfigType
        {
            set { _configType = value; }
            get { return _configType; }
        }
        private string _businessName;
        /// <summary>
        /// 业务名称 
        /// </summary>
        public string BusinessName
        {
            set { _businessName = value; }
            get { return _businessName; }
        }
        private DateTime _voluntarilyTime;
        /// <summary>
        ///执行时间 
        /// </summary>
        public DateTime VoluntarilyTime
        {
            set { _voluntarilyTime = value; }
            get { return _voluntarilyTime; }
        }
        private DateTime _NextVoluntarilyTime;
        /// <summary>
        ///下次执行时间 
        /// </summary>
        public DateTime NextVoluntarilyTime
        {
            set { _NextVoluntarilyTime = value; }
            get { return _NextVoluntarilyTime; }
        }
        private string _PathName;
        /// <summary>
        ///文件路径 
        /// </summary>
        public string PathName
        {
            set { _PathName = value; }
            get { return _PathName; }
        }
        private string _Cycle;
        /// <summary>
        ///周期
        /// </summary>
        public string Cycle
        {
            set { _Cycle = value; }
            get { return _Cycle; }
        }
        private string _Prefix;
        /// <summary>
        ///前缀
        /// </summary>
        public string Prefix
        {
            set { _Prefix = value; }
            get { return _Prefix; }
        }
        private string _Suffix;
        /// <summary>
        ///后缀
        /// </summary>
        public string Suffix
        {
            set { _Suffix = value; }
            get { return _Suffix; }
        }
        private string _Remark;
        /// <summary>
        ///备注
        /// </summary>
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }
        private string _DateSql;
        /// <summary>
        ///数据集Sql
        /// </summary>
        public string DateSql
        {
            set { _DateSql = value; }
            get { return _DateSql; }
        }
        private bool _isDeleted;
        /// <summary>
        ///是否删除
        /// </summary>
        public bool IsDeleted
        {
            set { _isDeleted = value; }
            get { return _isDeleted; }
        }
        private DateTime _BecomeValidateDate;
        /// <summary>
        ///首次执行日期
        /// </summary>
        public DateTime BecomeValidateDate
        {
            set { _BecomeValidateDate = value; }
            get { return _BecomeValidateDate; }
        }
        private DateTime _LoseEfficacyDate;
        /// <summary>
        ///失效日期
        /// </summary>
        public DateTime LoseEfficacyDate
        {
            set { _LoseEfficacyDate = value; }
            get { return _LoseEfficacyDate; }
        }

        /// <summary>
        ///生成文件格式  
        /// </summary> 
        private int _FileType;
        public int FileType
        {
            set { _FileType = value; }
            get { return _FileType; }
        }
        /// <summary>
        ///格式化文件名称 
        /// </summary> 
        private string _FileFormatName;
        public string FileFormatName
        {
            set { _FileFormatName = value; }
            get { return _FileFormatName; }
        }
        /// <summary>
        ///是否显示列头 
        /// </summary> 
        private bool _IsHead;
        public bool IsHead
        {
            set { _IsHead = value; }
            get { return _IsHead; }
        }

        private string _serverType;
        public string ServerType
        {
            set { _serverType = value; }
            get { return _serverType; }
        }
        private string _orgCode;
        public string OrgCode
        {
            set { _orgCode = value; }
            get { return _orgCode; }
        }
        
        private string _manualdownload;
        /// <summary>
        /// 是否手动下载 0 否 1 是
        /// </summary>
        public string ManualDownload
        {
            set { _manualdownload = value; }
            get { return _manualdownload; }
        }
    }
}
