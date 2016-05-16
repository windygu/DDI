using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using System;

namespace ORG.UILib.Controls
{
    public partial class ContextMenuStripEx : ContextMenuStrip
    {
        /// <summary>
        /// 查看
        /// </summary>
        public ToolStripMenuItem tSMIView = new ToolStripMenuItem();
        /// <summary>
        /// 刷新
        /// </summary>
        public ToolStripMenuItem tSMIRefresh = new ToolStripMenuItem();
        /// <summary>
        /// 添加
        /// </summary>
        public ToolStripMenuItem tSMIAdd = new ToolStripMenuItem();
        /// <summary>
        /// 修改
        /// </summary>
        public ToolStripMenuItem tSMIUpdate = new ToolStripMenuItem();
        /// <summary>
        /// 删除
        /// </summary>
        public ToolStripMenuItem tSMIDel = new ToolStripMenuItem();

        //定义委托
        public delegate void tSMIViewEventHandler(object sender, EventArgs e);
        public delegate void tSMIRefreshEventHandler(object sender, EventArgs e);
        public delegate void tSMIAddEventHandler(object sender, EventArgs e);
        public delegate void tSMIUpdateEventHandler(object sender, EventArgs e);
        public delegate void tSMIDelEventHandler(object sender, EventArgs e);

        //定义事件

        [Category("Custom"), Description("自定义tSMIView事件")]
        public event tSMIViewEventHandler tSMIView_click;
        [Category("Custom"), Description("自定义tSMIRefresh事件")]
        public event tSMIRefreshEventHandler tSMIRefresh_click;
        [Category("Custom"), Description("自定义tSMIAddEvent事件")]
        public event tSMIAddEventHandler tSMIAdd_click;
        [Category("Custom"), Description("自定义tSMIUpdate事件")]
        public event tSMIUpdateEventHandler tSMIUpdate_click;
        [Category("Custom"), Description("自定义tSMIDel事件")]
        public event tSMIDelEventHandler tSMIDel_click;


        public ContextMenuStripEx()
        {
            InitializeComponent();
            InitToolStripItem();
        }

        public ContextMenuStripEx(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            InitToolStripItem();
        }

        private void InitToolStripItem()
        {
            tSMIView.Text = "查看";
            tSMIView.Visible = false;
            tSMIRefresh.Text = "刷新";
            tSMIRefresh.Visible = false;
            tSMIAdd.Text = "添加";
            tSMIAdd.Visible = false;
            tSMIUpdate.Text = "修改";
            tSMIUpdate.Visible = false;
            tSMIDel.Text = "删除";
            tSMIDel.Visible = false;
            this.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tSMIView, tSMIRefresh, tSMIAdd, tSMIUpdate, tSMIDel });

            tSMIView.Click += new EventHandler(tSMIView_Click);
            tSMIRefresh.Click += new System.EventHandler(tSMIRefresh_Click);
            tSMIAdd.Click += new System.EventHandler(tSMIAdd_Click);
            tSMIUpdate.Click += new EventHandler(tSMIUpdate_Click);
            tSMIDel.Click+=new EventHandler(tSMIDel_Click);
        }


        private void tSMIView_Click(object sender, EventArgs e)
        {
            if (tSMIView_click != null)
                tSMIView_click(sender, e);
        }

        private void tSMIRefresh_Click(object sender, EventArgs e)
        {
            if (tSMIRefresh_click != null)
                tSMIRefresh_click(sender, e);
        }

        private void tSMIAdd_Click(object sender, EventArgs e)
        {
            if (tSMIAdd_click != null)
                tSMIAdd_click(sender, e);
        }

        private void tSMIUpdate_Click(object sender, EventArgs e)
        {
            if (tSMIUpdate_click != null)
                tSMIUpdate_click(sender, e);
        }

        private void tSMIDel_Click(object sender, EventArgs e)
        {
            if (tSMIDel_click != null)
                tSMIDel_click(sender, e);
        }

    }
}
