using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDIV2.Model
{
    [Serializable]
    public partial class ExecuteLog
    {
        public ExecuteLog()
        { }

        #region ExecuteLog
        private Guid _id;
        /// <summary>
        /// 编码 主键
        /// </summary>
        public Guid Id
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
        private string _BusinessName;
        /// <summary>
        /// 业务
        /// </summary>
        public string BusinessName
        {
            set { _BusinessName = value; }
            get { return _BusinessName; }
        }
        private string _IsVoluntarily;
        /// <summary>
        /// 是否自动 
        /// </summary>
        public string IsVoluntarily
        {
            set { _IsVoluntarily = value; }
            get { return _IsVoluntarily; }
        }
        private DateTime _BusinessExecuteDate;
        /// <summary>
        /// 业务时间
        /// </summary>
        public DateTime BusinessExecuteDate
        {
            set { _BusinessExecuteDate = value; }
            get { return _BusinessExecuteDate; }
        }
        private DateTime _OperateDateTime;
        /// <summary>
        ///操作时间 
        /// </summary>
        public DateTime OperateDateTime
        {
            set { _OperateDateTime = value; }
            get { return _OperateDateTime; }
        }
        private string _OperateMan;
        /// <summary>
        ///操作人 
        /// </summary>
        public string OperateMan
        {
            set { _OperateMan = value; }
            get { return _OperateMan; }
        }
        private bool _IsMormal;
        /// <summary>
        ///操作是否正常 
        /// </summary>
        public bool IsMormal
        {
            set { _IsMormal = value; }
            get { return _IsMormal; }
        }
        private string _BusinessEndDateTime;
        /// <summary>
        ///业务数据截止时间
        /// </summary>
        public string BusinessEndDateTime
        {
            set { _BusinessEndDateTime = value; }
            get { return _BusinessEndDateTime; }
        }
        private string _Status;
        /// <summary>
        ///状态  1 自动执行正常 2 自动执行不正常 3 手动执行正常 4 手动执行不正常
        /// </summary>
        public string Status
        {
            set { _Status = value; }
            get { return _Status; }
        }
        /// <summary>
        ///文件完整路径 
        /// </summary>
        public string _PathName;
        public string PathName
        {
            set { _PathName = value; }
            get { return _PathName; }
        }

        /// <summary>
        ///备注
        /// </summary>
        private string _Remark;
        public string Remark
        {
            set { _Remark = value; }
            get { return _Remark; }
        }
        /// <summary>
        ///是否删除
        /// </summary>
        private bool _IsDeleted;
        public bool IsDeleted
        {
            set { _IsDeleted = value; }
            get { return _IsDeleted; }
        }
        /// <summary>
        ///备份路径
        /// </summary>
        private string _BackUrl;
        public string BackUrl
        {
            set { _BackUrl = value; }
            get { return _BackUrl; }
        }
        #endregion


    }
}
