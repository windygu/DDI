namespace DDIV2.UI
{
    partial class ExecuteOperation
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExecuteOperation));
            this.btnStart = new ORG.UILib.Controls.ButtonEx(this.components);
            this.dgv = new ORG.UILib.Controls.DataGridViewEx(this.components);
            this.编号 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.线程状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.配置方式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.文件格式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.业务名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.首次执行日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.本次执行时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.文件路径 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.周期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.备注 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数据集Sql = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.失效日期 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.格式化文件名称 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.执行时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.是否显示头部 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.数据访问类型 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.机构编码 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MenuTop = new System.Windows.Forms.MenuStrip();
            this.Seting = new System.Windows.Forms.ToolStripMenuItem();
            this.TSDataConfig = new System.Windows.Forms.ToolStripMenuItem();
            this.Register = new System.Windows.Forms.ToolStripMenuItem();
            this.fTPtsmt = new System.Windows.Forms.ToolStripMenuItem();
            this.UserOrgtsmt = new System.Windows.Forms.ToolStripMenuItem();
            this.文件管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Heavy = new System.Windows.Forms.ToolStripMenuItem();
            this.BusinessLog = new System.Windows.Forms.ToolStripMenuItem();
            this.UserTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.SysTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.AuthorizeTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpExec = new System.Windows.Forms.TabPage();
            this.cbThedate = new ORG.UILib.Controls.CheckBoxEx(this.components);
            this.cbtrundle = new ORG.UILib.Controls.CheckBoxEx(this.components);
            this.btnCancel = new ORG.UILib.Controls.ButtonEx(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.MenuTop.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpExec.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.Linen;
            this.btnStart.Location = new System.Drawing.Point(59, 15);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 25);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "启 动";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnDisplayIndexSave = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.编号,
            this.线程状态,
            this.配置方式,
            this.文件格式,
            this.业务名称,
            this.首次执行日期,
            this.本次执行时间,
            this.文件路径,
            this.周期,
            this.备注,
            this.数据集Sql,
            this.失效日期,
            this.格式化文件名称,
            this.执行时间,
            this.是否显示头部,
            this.数据访问类型,
            this.机构编码});
            this.dgv.ColumnVisibleEnableSave = true;
            this.dgv.ColumnWidthSave = true;
            this.dgv.Location = new System.Drawing.Point(-4, 48);
            this.dgv.MyForm = this;
            this.dgv.Name = "dgv";
            this.dgv.ShowdgvTotalRow = false;
            this.dgv.ShowTotal = 0;
            this.dgv.Size = new System.Drawing.Size(1052, 447);
            this.dgv.SumColumnList = new string[] {
        ""};
            this.dgv.SumField = "";
            this.dgv.TabIndex = 3;
            this.dgv.UserName = "SystemUserName";
            // 
            // 编号
            // 
            this.编号.HeaderText = "编号";
            this.编号.Name = "编号";
            // 
            // 线程状态
            // 
            this.线程状态.HeaderText = "线程状态";
            this.线程状态.Name = "线程状态";
            // 
            // 配置方式
            // 
            this.配置方式.HeaderText = "配置方式";
            this.配置方式.Name = "配置方式";
            // 
            // 文件格式
            // 
            this.文件格式.HeaderText = "文件格式";
            this.文件格式.Name = "文件格式";
            // 
            // 业务名称
            // 
            this.业务名称.HeaderText = "业务名称";
            this.业务名称.Name = "业务名称";
            // 
            // 首次执行日期
            // 
            this.首次执行日期.HeaderText = "首次执行日期";
            this.首次执行日期.Name = "首次执行日期";
            // 
            // 本次执行时间
            // 
            this.本次执行时间.HeaderText = "本次执行时间";
            this.本次执行时间.Name = "本次执行时间";
            // 
            // 文件路径
            // 
            this.文件路径.HeaderText = "文件路径";
            this.文件路径.Name = "文件路径";
            // 
            // 周期
            // 
            this.周期.HeaderText = "周期";
            this.周期.Name = "周期";
            // 
            // 备注
            // 
            this.备注.HeaderText = "备注";
            this.备注.Name = "备注";
            // 
            // 数据集Sql
            // 
            this.数据集Sql.HeaderText = "数据集Sql";
            this.数据集Sql.Name = "数据集Sql";
            // 
            // 失效日期
            // 
            this.失效日期.HeaderText = "失效日期";
            this.失效日期.Name = "失效日期";
            // 
            // 格式化文件名称
            // 
            this.格式化文件名称.HeaderText = "格式化文件名称";
            this.格式化文件名称.Name = "格式化文件名称";
            // 
            // 执行时间
            // 
            this.执行时间.HeaderText = "执行时间";
            this.执行时间.Name = "执行时间";
            // 
            // 是否显示头部
            // 
            this.是否显示头部.HeaderText = "是否显示头部";
            this.是否显示头部.Name = "是否显示头部";
            // 
            // 数据访问类型
            // 
            this.数据访问类型.HeaderText = "数据访问类型";
            this.数据访问类型.Name = "数据访问类型";
            // 
            // 机构编码
            // 
            this.机构编码.HeaderText = "机构编码";
            this.机构编码.Name = "机构编码";
            // 
            // MenuTop
            // 
            this.MenuTop.BackColor = System.Drawing.Color.Wheat;
            this.MenuTop.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.MenuTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Seting,
            this.文件管理ToolStripMenuItem,
            this.SysTSMI});
            this.MenuTop.Location = new System.Drawing.Point(0, 0);
            this.MenuTop.Name = "MenuTop";
            this.MenuTop.Size = new System.Drawing.Size(1052, 29);
            this.MenuTop.TabIndex = 4;
            this.MenuTop.Text = "menuStrip2";
            // 
            // Seting
            // 
            this.Seting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSDataConfig,
            this.Register,
            this.fTPtsmt,
            this.UserOrgtsmt});
            this.Seting.Name = "Seting";
            this.Seting.Size = new System.Drawing.Size(86, 25);
            this.Seting.Text = "配置信息";
            // 
            // TSDataConfig
            // 
            this.TSDataConfig.Name = "TSDataConfig";
            this.TSDataConfig.Size = new System.Drawing.Size(192, 26);
            this.TSDataConfig.Text = "数据库连接配置";
            this.TSDataConfig.Click += new System.EventHandler(this.TSDataConfig_Click);
            // 
            // Register
            // 
            this.Register.Name = "Register";
            this.Register.Size = new System.Drawing.Size(192, 26);
            this.Register.Text = "产品序列号登记";
            this.Register.Click += new System.EventHandler(this.Register_Click);
            // 
            // fTPtsmt
            // 
            this.fTPtsmt.Name = "fTPtsmt";
            this.fTPtsmt.Size = new System.Drawing.Size(192, 26);
            this.fTPtsmt.Text = "FTP信息配置";
            this.fTPtsmt.Click += new System.EventHandler(this.fTPtsmt_Click);
            // 
            // UserOrgtsmt
            // 
            this.UserOrgtsmt.Name = "UserOrgtsmt";
            this.UserOrgtsmt.Size = new System.Drawing.Size(192, 26);
            this.UserOrgtsmt.Text = "用户关联机构";
            this.UserOrgtsmt.Click += new System.EventHandler(this.UserOrgtsmt_Click);
            // 
            // 文件管理ToolStripMenuItem
            // 
            this.文件管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Heavy,
            this.BusinessLog,
            this.UserTSMI});
            this.文件管理ToolStripMenuItem.Name = "文件管理ToolStripMenuItem";
            this.文件管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 25);
            this.文件管理ToolStripMenuItem.Text = "业务管理";
            // 
            // Heavy
            // 
            this.Heavy.Name = "Heavy";
            this.Heavy.Size = new System.Drawing.Size(152, 26);
            this.Heavy.Text = "重 采";
            this.Heavy.Click += new System.EventHandler(this.Heavy_Click);
            // 
            // BusinessLog
            // 
            this.BusinessLog.Name = "BusinessLog";
            this.BusinessLog.Size = new System.Drawing.Size(152, 26);
            this.BusinessLog.Text = "业务日志";
            this.BusinessLog.Click += new System.EventHandler(this.BusinessLog_Click);
            // 
            // UserTSMI
            // 
            this.UserTSMI.Name = "UserTSMI";
            this.UserTSMI.Size = new System.Drawing.Size(152, 26);
            this.UserTSMI.Text = "添加用户";
            this.UserTSMI.Click += new System.EventHandler(this.UserTSMI_Click);
            // 
            // SysTSMI
            // 
            this.SysTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AuthorizeTSMI});
            this.SysTSMI.Name = "SysTSMI";
            this.SysTSMI.Size = new System.Drawing.Size(86, 25);
            this.SysTSMI.Text = "系统管理";
            // 
            // AuthorizeTSMI
            // 
            this.AuthorizeTSMI.Name = "AuthorizeTSMI";
            this.AuthorizeTSMI.Size = new System.Drawing.Size(152, 26);
            this.AuthorizeTSMI.Text = "授权管理";
            this.AuthorizeTSMI.Click += new System.EventHandler(this.AuthorizeTSMI_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpExec);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1052, 517);
            this.tabControl1.TabIndex = 5;
            // 
            // tpExec
            // 
            this.tpExec.BackColor = System.Drawing.Color.Wheat;
            this.tpExec.Controls.Add(this.cbThedate);
            this.tpExec.Controls.Add(this.cbtrundle);
            this.tpExec.Controls.Add(this.btnCancel);
            this.tpExec.Controls.Add(this.dgv);
            this.tpExec.Controls.Add(this.btnStart);
            this.tpExec.Location = new System.Drawing.Point(4, 22);
            this.tpExec.Name = "tpExec";
            this.tpExec.Padding = new System.Windows.Forms.Padding(3);
            this.tpExec.Size = new System.Drawing.Size(1044, 491);
            this.tpExec.TabIndex = 0;
            this.tpExec.Text = "执行文件生成";
            // 
            // cbThedate
            // 
            this.cbThedate.AutoSize = true;
            this.cbThedate.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbThedate.Location = new System.Drawing.Point(283, 18);
            this.cbThedate.Name = "cbThedate";
            this.cbThedate.Size = new System.Drawing.Size(110, 18);
            this.cbThedate.TabIndex = 6;
            this.cbThedate.Text = "执行当天数据";
            this.cbThedate.UseVisualStyleBackColor = true;
            // 
            // cbtrundle
            // 
            this.cbtrundle.AutoSize = true;
            this.cbtrundle.Font = new System.Drawing.Font("宋体", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbtrundle.Location = new System.Drawing.Point(155, 18);
            this.cbtrundle.Name = "cbtrundle";
            this.cbtrundle.Size = new System.Drawing.Size(110, 18);
            this.cbtrundle.TabIndex = 5;
            this.cbtrundle.Text = "执行既往数据";
            this.cbtrundle.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancel.Location = new System.Drawing.Point(59, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "停 止";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ExecuteOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1052, 546);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.MenuTop);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ExecuteOperation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DDI数据中心";
            this.Load += new System.EventHandler(this.ExecuteOperation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.MenuTop.ResumeLayout(false);
            this.MenuTop.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tpExec.ResumeLayout(false);
            this.tpExec.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ORG.UILib.Controls.DataGridViewEx dgv;
        private ORG.UILib.Controls.ButtonEx btnStart;
        private System.Windows.Forms.MenuStrip MenuTop;
        private System.Windows.Forms.ToolStripMenuItem Seting;
        private System.Windows.Forms.ToolStripMenuItem TSDataConfig;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpExec;
        private ORG.UILib.Controls.CheckBoxEx cbtrundle;
        private ORG.UILib.Controls.ButtonEx btnCancel;
        private System.Windows.Forms.ToolStripMenuItem 文件管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Heavy;
        private System.Windows.Forms.ToolStripMenuItem BusinessLog;
        private System.Windows.Forms.ToolStripMenuItem Register;
        private System.Windows.Forms.ToolStripMenuItem fTPtsmt;
        private System.Windows.Forms.ToolStripMenuItem SysTSMI;
        private System.Windows.Forms.ToolStripMenuItem UserTSMI;
        private System.Windows.Forms.ToolStripMenuItem AuthorizeTSMI;
        private System.Windows.Forms.ToolStripMenuItem UserOrgtsmt;
        private System.Windows.Forms.DataGridViewTextBoxColumn 编号;
        private System.Windows.Forms.DataGridViewTextBoxColumn 线程状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配置方式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 文件格式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 业务名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 首次执行日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 本次执行时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 文件路径;
        private System.Windows.Forms.DataGridViewTextBoxColumn 周期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 备注;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数据集Sql;
        private System.Windows.Forms.DataGridViewTextBoxColumn 失效日期;
        private System.Windows.Forms.DataGridViewTextBoxColumn 格式化文件名称;
        private System.Windows.Forms.DataGridViewTextBoxColumn 执行时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 是否显示头部;
        private System.Windows.Forms.DataGridViewTextBoxColumn 数据访问类型;
        private System.Windows.Forms.DataGridViewTextBoxColumn 机构编码;
        private ORG.UILib.Controls.CheckBoxEx cbThedate;
    }
}

