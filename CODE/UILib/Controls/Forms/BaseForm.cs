using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;

namespace ORG.UILib.Forms
{
    public partial class BaseForm : Form
    {
        #region 常用操作按钮"保存,添加,编辑,查看,删除,刷新,取消"属性
        //常用功能键组标识
        public ToolStrip tsBase = new ToolStrip();
        private bool _tsBaseVisible = false;
        /// <summary>
        /// 常用功能键菜单的可见标识
        /// </summary>
        [Category("自定义"), Browsable(true), Description("功能键“菜单”是否可见")]
        public bool tsBaseVisible
        {
            get { return _tsBaseVisible; }
            set
            {
                _tsBaseVisible = value;
                tsBase.Enabled = _tsBaseVisible;
            }
        }

        //常用功能键"查询"按钮
        public ToolStripButton tsbSearch = new ToolStripButton();
        private bool _tsbSearchEnable = false;
        /// <summary>
        /// 常用功能键菜单"查询"可用标识
        /// </summary>
        [Category("自定义"), Browsable(true), Description("功能键“查询”是否可用")]
        public bool tsbSearchEnable
        {
            get { return _tsbSearchEnable; }
            set
            {
                _tsbSearchEnable = value;
                tsbSearch.Enabled = _tsbSearchEnable;
            }
        }

        //常用功能键"查看"标识
        public ToolStripButton tsbView = new ToolStripButton();
        private bool _tsbViewEnable = false;
        /// <summary>
        /// 常用功能键菜单"查看"可用标识
        /// </summary>
        [Category("自定义"), Browsable(true), Description("功能键“查看”是否可用")]
        public bool tsbViewEnable
        {
            get { return _tsbViewEnable; }
            set
            {
                _tsbViewEnable = value;
                tsbView.Enabled = _tsbViewEnable;
            }
        }

        //常用功能键"刷新"标识
        public ToolStripButton tsbRefresh = new ToolStripButton();
        private bool _tsbRefreshEnable = false;
        /// <summary>
        /// 常用功能键菜单"刷新"可用标识
        /// </summary>
        [Category("自定义"), Browsable(true), Description("功能键“刷新”是否可用")]
        public bool tsbRefreshEnable
        {
            get { return _tsbRefreshEnable; }
            set
            {
                _tsbRefreshEnable = value;
                tsbRefresh.Enabled = _tsbRefreshEnable;
            }
        }

        //常用功能键"添加"标识
        public ToolStripButton tsbAdd = new ToolStripButton();
        private bool _tsbAddEnable = false;
        /// <summary>
        /// 常用功能键菜单"添加"可用标识
        /// </summary>
        [Category("自定义"), Browsable(true), Description("功能键“添加”是否可用")]
        public bool tsbAddEnable
        {
            get { return _tsbAddEnable; }
            set
            {
                _tsbAddEnable = value;
                tsbAdd.Enabled = _tsbAddEnable;
            }
        }

        //常用功能键"保存"标识
        public ToolStripButton tsbSave = new ToolStripButton();
        private bool _tsbSaveEnable = false;
        /// <summary>
        /// 常用功能键菜单"保存"可用标识
        /// </summary>
        [Category("自定义"), Browsable(true), Description("功能键“保存”是否可用")]                        
        public bool tsbSaveEnable
        {
            get { return _tsbSaveEnable; }
            set
            {
                _tsbSaveEnable = value;
                tsbSave.Enabled = _tsbSaveEnable;
            }
        }

        //常用功能键"更新"标识
        public ToolStripButton tsbUpdate = new ToolStripButton();
        private bool _tsbUpdateEnable = false;
        /// <summary>
        /// 常用功能键菜单"更新"可用标识
        /// </summary>
        [Category("自定义"), Browsable(true), Description("功能键“更新”是否可用")]                
        public bool tsbUpdateEnable
        {
            get { return _tsbUpdateEnable; }
            set
            {
                _tsbUpdateEnable = value;
                tsbUpdate.Enabled = _tsbUpdateEnable;
            }
        }

        //常用功能键"删除"标识
        public ToolStripButton tsbDel = new ToolStripButton();
        private bool _tsbDelEnable = false;
        /// <summary>
        /// 常用功能键菜单"删除"可用标识
        /// </summary>
        [Category("自定义"), Browsable(true), Description("功能键“删除”是否可用")]        
        public bool tsbDelEnable
        {
            get { return _tsbDelEnable; }
            set
            {
                _tsbDelEnable = value;
                tsbDel.Enabled = _tsbDelEnable;
            }
        }

        /// 常用功能键"导出"标识
        public ToolStripButton tsbExport = new ToolStripButton();
        private bool _tsbExportEnable = false;
        /// <summary>
        /// 常用功能键菜单“导出”可用标识
        /// </summary>
        [Category("自定义"), Browsable(true), Description("功能键“导出”是否可用")]
        public bool tsbExportEnable
        {
            get { return _tsbExportEnable; }
            set {
                _tsbExportEnable = value;
                tsbExport.Enabled = _tsbExportEnable;
            }
        }

        /// 常用功能键"取消"标识
        public ToolStripButton tsbCancel = new ToolStripButton();
        private bool _tsbCancelEnable = false;
        /// <summary>
        /// 常用功能键菜单“取消”可用标识
        /// </summary>
        [Category("自定义"), Browsable(true), Description("功能键“取消”是否可用")]
        public bool tsbCancelEnable
        {
            get { return _tsbCancelEnable; }
            set
            {
                _tsbCancelEnable = value;
                tsbCancel.Enabled = _tsbCancelEnable;
            }
        }

        #endregion

        #region fr报表的功能键"查询组,查询,编辑,预览,打印"可用性属性操作
        //FR报表菜单组标识
        public ToolStrip tsFR = new ToolStrip();
        private bool _tsFRVisible = false;
        /// <summary>
        /// FR报表菜单的可见标识
        /// </summary>
        public bool tsFRVisible 
        {
            get{return _tsFRVisible;}
            set{ 
                    _tsFRVisible=value;
                    tsFR.Enabled = _tsFRVisible; 
            }
        }

        //查询按钮
        public ToolStripButton tsbFRSearch = new ToolStripButton();
        private bool _tsbFRSearchEnable = false;
        /// <summary>
        /// FR报表菜单"查询"可用标识
        /// </summary>
        public bool tsbFRSearchEnable
        {
            get { return _tsbFRSearchEnable; }
            set
            {
                _tsbFRSearchEnable = value;
                tsbFRSearch.Enabled = _tsbFRSearchEnable;
            }
        }

        //编辑可用
        public ToolStripButton tsbFREdit = new ToolStripButton();
        private bool _tsbFREditEnable = false;
        /// <summary>
        /// FR报表菜单"编辑"可见标识
        /// </summary>
        public bool tsbFREditEnable
        {
            get { return _tsbFREditEnable; }
            set
            {
                _tsbFREditEnable = value;
                tsbFREdit.Enabled = _tsbFREditEnable;
            }
        }
        
        //预览可用
        public ToolStripButton tsbFRPreview = new ToolStripButton();
        private bool _tsbFRPreviewEnable = false;
        /// <summary>
        /// FR报表菜单"预览"可用标识
        /// </summary>
        public bool tsbFRPreviewEnable
        {
            get { return _tsbFRPreviewEnable; }
            set
            {
                _tsbFRPreviewEnable = value;
                tsbFRPreview.Enabled = _tsbFRPreviewEnable;
            }
        }

        //打印可用
        public ToolStripButton tsbFRPrint = new ToolStripButton();
        private bool _tsbFRPrintEnable = false;
        /// <summary>
        /// FR报表菜单"打印"可用标识
        /// </summary>
        public bool tsbFRPrintEnable
        {
            get { return _tsbFRPrintEnable; }
            set
            {
                _tsbFRPrintEnable = value;
                tsbFRPrint.Enabled = _tsbFRPrintEnable;
            }
        }
        #endregion

        //定义委托
        public delegate void tSMIViewEventHandler(object sender, EventArgs e);
        public delegate void tSMIRefreshEventHandler(object sender, EventArgs e);
        public delegate void tSMIAddEventHandler(object sender, EventArgs e);
        public delegate void tSMISaveEventHandler(object sender, EventArgs e);
        public delegate void tSMIUpdateEventHandler(object sender, EventArgs e);
        public delegate void tSMIDelEventHandler(object sender, EventArgs e);
        public delegate void tSMISearchEventHandler(object sender, EventArgs e);
        public delegate void tSMIExportEventHandler(object sender, EventArgs e);
        public delegate void tSMICancelEventHandler(object sender, EventArgs e);
        //fr报表委托
        public delegate void tSMIFRSearchEventHandler(object sender, EventArgs e);
        public delegate void tSMIFREditEventHandler(object sender, EventArgs e);
        public delegate void tSMIFRPreviewEventHandler(object sender, EventArgs e);
        public delegate void tSMIFRPrintEventHandler(object sender, EventArgs e);

        //定义事件
        [Category("Custom"), Description("自定义tSMISearch（查询）事件")]
        public event tSMISearchEventHandler tSMISearch_click;
        [Category("Custom"), Description("自定义tSMIView（查看）事件")]
        public event tSMIViewEventHandler tSMIView_click;
        [Category("Custom"), Description("自定义tSMIRefresh（刷新）事件")]
        public event tSMIRefreshEventHandler tSMIRefresh_click;
        [Category("Custom"), Description("自定义tSMIAddEvent（添加）事件")]
        public event tSMIAddEventHandler tSMIAdd_click;
        [Category("Custom"), Description("自定义tSMISaveEvent（保存）事件")]
        public event tSMISaveEventHandler tSMISave_click;
        [Category("Custom"), Description("自定义tSMIUpdate（更新）事件")]
        public event tSMIUpdateEventHandler tSMIUpdate_click;
        [Category("Custom"), Description("自定义tSMIDel（删除）事件")]
        public event tSMIDelEventHandler tSMIDel_click;
        [Category("Custom"), Description("自定义tSMIExport（导出）事件")]
        public event tSMIExportEventHandler tSMIExport_click;
        [Category("Custom"), Description("自定义tSMICancel（取消）事件")]
        public event tSMICancelEventHandler tSMICancel_click;
        //fr报表定义事件
        [Category("FRCustom"), Description("自定义tSMIFRSearchEvent事件")]
        public event tSMIFRSearchEventHandler tSMIFRSearch_click;
        [Category("FRCustom"), Description("自定义tSMIFREdit事件")]
        public event tSMIFREditEventHandler tSMIFREdit_click;
        [Category("FRCustom"), Description("自定义tSMIFRPreview事件")]
        public event tSMIFRPreviewEventHandler tSMIFRPreview_click;
        [Category("FRCustom"), Description("自定义tSMIFRPrint事件")]
        public event tSMIFRPrintEventHandler tSMIFRPrint_click;

        #region 常用普通功能"保存,添加,编辑,查看,删除,刷新,取消"事件实现
        //查询
        public void tSMISearch_Click(object sender, EventArgs e)
        {
            if (tSMISearch_click != null)
                tSMISearch_click(sender, e);
        }
        //查看
        public void tSMIView_Click(object sender, EventArgs e)
        {
            if (tSMIView_click != null)
                tSMIView_click(sender, e);
        }
        //刷新
        public void tSMIRefresh_Click(object sender, EventArgs e)
        {
            if (tSMIRefresh_click != null)
                tSMIRefresh_click(sender, e);
        }
        //添加
        public  void tSMIAdd_Click(object sender, EventArgs e)
        {
            if (tSMIAdd_click != null)
                tSMIAdd_click(sender, e);
        }
        //保存
        public void tSMISave_Click(object sender, EventArgs e)
        {
            if (tSMISave_click != null)
                tSMISave_click(sender, e);
        }
        //编辑
        public void tSMIUpdate_Click(object sender, EventArgs e)
        {
            if (tSMIUpdate_click != null)
                tSMIUpdate_click(sender, e);
        }
        //删除
        public void tSMIDel_Click(object sender, EventArgs e)
        {
            if (tSMIDel_click != null)
                tSMIDel_click(sender, e);
        }
        //导出
        public void tSMIExport_Click(object sender, EventArgs e)
        {
            if (tSMIExport_click != null)
                tSMIExport_click(sender, e);
        }
        //取消
        public void tSMICancel_Click(object sender, EventArgs e)
        {
            if (tSMICancel_click != null)
                tSMICancel_click(sender, e);
        }
        # endregion

        #region fr报表功能"查询,模版编辑,预览,打印"实现

        //查询功能
        public void tSMIFRSearch_Click(object sender, EventArgs e)
        {
            if (tSMIFRSearch_click != null)
                tSMIFRSearch_click(sender, e);
        }
        //编辑功能
        public void tSMIFREdit_Click(object sender, EventArgs e)
        {
            if (tSMIFREdit_click != null)
                tSMIFREdit_click(sender, e);
        }
        //预览功能
        public void tSMIFRPreview_Click(object sender, EventArgs e)
        {
            if (tSMIFRPreview_click != null)
                tSMIFRPreview_click(sender, e);
        }
        //打印功能
        public void tSMIFRPrint_Click(object sender, EventArgs e)
        {
            if (tSMIFRPrint_click != null)
                tSMIFRPrint_click(sender, e);
        }

        #endregion


        protected override void OnShown(EventArgs e)
        {
            setFocus(this);
        }


        private void setFocus(Control ctr)
        {
            foreach (Control ctrl in ctr.Controls)
            {
                string str = ctrl.Name;
                if ((ctrl is TextBox || ctrl is DateTimePicker) && ctrl.Enabled && ctrl.TabIndex == 0 && ctrl.Visible)
                {
                    int aa = ctrl.TabIndex;
                    ctrl.Focus();
                }
                else
                {
                    setFocus(ctrl);
                }
            }
        }
    }
}
