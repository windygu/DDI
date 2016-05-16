using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace ORG.UILib.Controls
{
    public partial class TextBoxDplDgv : TextBoxEx
    {
        //DGV定位
        private int DgvX = 0;
        private int DgvY = 0;

        private string thisText = string.Empty;

        public TextBoxDplDgv()
        {
            InitializeComponent();
        }

        public TextBoxDplDgv(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            this.BackColor = System.Drawing.Color.FromArgb(255, 235, 205);
            Init();
        }




        #region 属性

        private string _visibleindexs = "";
        /// <summary>
        /// 不需显示的索引,以“,”格开如“0,1”
        /// </summary>
        [Category("Custom"), Browsable(true), Description("不需显示的索引,以“,”格开如“0,1”")]
        public string VisibleIndexs
        {
            set { this._visibleindexs = value; }
            get { return this._visibleindexs; }
        }

        private bool _visibleSource = true;
        /// <summary>
        /// 是否显示数据集列表
        /// </summary>
        [Category("Custom"), Browsable(true), Description("是否显示数据集列表")]
        public bool VisibleSource
        {
            set { this._visibleSource = value; }
            get { return this._visibleSource; }
        }

        private int wValue = 300;
        /// <summary>
        /// DataGridViewEx的宽度
        /// </summary>
        [Category("Custom"), Browsable(true), Description("DataGridViewEx的宽度")]
        public int WValue
        {
            set { this.wValue = value; }
            get { return wValue; }
        }

        private int hValue = 200;
        /// <summary>
        /// DataGridViewEx的宽度
        /// </summary>
        [Category("Custom"), Browsable(true), Description("DataGridViewEx的高度")]
        public int HValue
        {
            set { this.hValue = value; }
            get { return hValue; }
        }

        private DataTable _DgvDataSource = null;
        /// <summary>
        /// 绑定的DataGridViewEx的数据源
        /// </summary>
        [Category("Custom"), Browsable(true), Description("绑定的DataGridViewEx的数据源")]
        public DataTable DgvDataSource
        {
            set { this._DgvDataSource = value; }
            get { return _DgvDataSource; }
        }

        private string _DgvDataSourceWhere = null;
        /// <summary>
        /// 绑定的DataGridViewEx的数据源
        /// @keyword为输入内容占位符," filedname like '%keyword%' "
        /// </summary>
        [Category("Custom"), Browsable(true), Description("绑定的DataGridViewEx的数据的查询，@keyword为输入内容占位符,filedname like '%keyword%' ")]
        public string DgvDataSourceWhere
        {
            set { this._DgvDataSourceWhere = value; }
            get
            {
                if (DgvDataSourceWhereField != null && DgvDataSourceWhereField != "")
                {
                    DgvDataSourceWhereField = DgvDataSourceWhereField.Replace('，', ',');
                    DgvDataSourceWhere = string.Empty;
                    foreach (string str in DgvDataSourceWhereField.Split(','))
                    {
                        _DgvDataSourceWhere += " " + str + " like '%@keyword%' or ";
                    }
                    _DgvDataSourceWhere = _DgvDataSourceWhere.Trim().TrimEnd('r').TrimEnd('o');
                }
                return _DgvDataSourceWhere;
            }
        }

        private string _DgvDataSourceWhereField = null;
        /// <summary>
        /// 绑定的DataGridViewEx的数据源查询字段,设置此值则不用设置DgvDataSourceWhere,以“,”分隔
        /// </summary>
        [Category("Custom"), Browsable(true), Description("绑定的DataGridViewEx的数据的查询字段,设置此值则不用设置DgvDataSourceWhere,以“,”分隔")]
        public string DgvDataSourceWhereField
        {
            set { this._DgvDataSourceWhereField = value; }
            get { return _DgvDataSourceWhereField; }
        }

        private string _DisplayMember = "";
        /// <summary>
        /// 获取或设置TextBox.Text要显示的属性
        /// </summary>
        [Category("Custom"), Browsable(true), Description("获取或设置TextBox.Text要显示的属性")]
        public string DisplayMember
        {
            set { this._DisplayMember = value; }
            get { return _DisplayMember; }
        }

        private string _ValueMember = "";
        /// <summary>
        /// 获取或设置TextBox.Tag要显示的属性
        /// </summary>
        [Category("Custom"), Browsable(true), Description("获取或设置TextBox.Tag要显示的属性")]
        public string ValueMember
        {
            set { this._ValueMember = value; }
            get { return _ValueMember; }
        }

        private DataGridViewEx _DgvEx = null;

        [Category("Custom"), Browsable(true), Description("获取绑定的DataGridViewEx")]
        public DataGridViewEx DgvEx
        {
            get { return _DgvEx; }
        }

        private Form dgvForm = null;

        [Category("Custom"), Browsable(true), Description("获取当前Form")]
        public Form DgvForm
        {
            get { return dgvForm; }
        }

        private DataGridViewRow dataGridViewRow = null;
        /// <summary>
        /// 获取Dgv选中后返回值
        /// </summary>
        [Category("Custom"), Browsable(true), Description("获取Dgv选中后返回值")]
        public DataGridViewRow DgvRow
        {
            get { return dataGridViewRow; }
        }

        private bool _checkInfo = false;
        /// <summary>
        /// 验证输入内容是否存在
        /// </summary>
        [Category("Custom"), Browsable(true), Description("验证输入内容是否存在")]
        public bool CheckInfo
        {
            get
            {
                if (this.Text.Trim().Length > 0)
                {
                    string strWhere = DgvDataSourceWhere.Replace("@keyword", this.Text.Trim());
                    strWhere = strWhere.Replace("like", "=").Replace("%", "");
                    DataRow[] drs = ((DataTable)DgvDataSource).Select(strWhere);
                    if (drs.Length <= 0)
                    {
                        _checkInfo = false;
                    }
                    else
                    {
                        _checkInfo = true;
                    }
                }
                else
                {
                    _checkInfo = true;
                }

                return _checkInfo;
            }
        }


        private bool _selectNextControlFlag = true;

        /// <summary>
        /// 选中完成后是否跳转到下一个控件
        /// </summary>
        [Category("Custom"), Browsable(true), Description("选中完成后是否跳转到下一个控件")]
        public bool SelectNextControlFlag
        {
            set { this._selectNextControlFlag = value; }
            get { return _selectNextControlFlag; }

        }

        private string _otherText;
        /// <summary>
        /// 获取设置其他自定义内容
        /// </summary>
        [Category("Custom"), Browsable(true), Description("获取设置其他自定义内容")]
        public string OtherText
        {
            get { return _otherText; }
            set { _otherText = value; }

        }


        private int _showRowCount = 50;
        /// <summary>
        /// 检索结果显示条数，默认50行记录
        /// </summary>
        [Category("Custom"), Browsable(true), Description("检索结果显示条数，默认50行记录")]
        public int ShowRowCount
        {
            get { return _showRowCount; }
            set { _showRowCount = value; }
        }
        #endregion

        public delegate void DataBindsEventHandler(object sender, EventArgs e);
        /// <summary>
        /// 自定义TextBoxDplDgv_DataBinds事件
        /// </summary>
        [Category("Custom"), Description("自定义TextBoxDplDgv_DataBinds事件")]
        public event DataBindsEventHandler txtdgv_dataBinds;

        public delegate void TextBoxDplDgv_SelectedEventHandler(object sender, EventArgs e);
        /// <summary>
        /// 内容选中赋值完成后事件
        /// </summary>
        [Category("Custom"), Description("自定义TextBoxDplDgv_Selected事件")]
        public event TextBoxDplDgv_SelectedEventHandler textBoxDplDgv_Selected;

        /// <summary>
        /// 初始化
        /// </summary>
        internal void Init()
        {
            this._DgvEx = new DataGridViewEx();
            DgvEx.Hide();
            DgvEx.AllowUserToAddRows = false;
            DgvEx.AllowUserToDeleteRows = false;
            DgvEx.ColumnVisibleEnableSave = false;
            DgvEx.ColumnWidthSave = false;
            DgvEx.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            DgvEx.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            DgvEx.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;

            DgvEx.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            DgvEx.BackgroundColor = System.Drawing.SystemColors.Window;
            DgvEx.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            DgvEx.RowHeadersVisible = false;
            DgvEx.EditMode = DataGridViewEditMode.EditProgrammatically;
            //行字体颜色
            System.Windows.Forms.DataGridViewCellStyle DGVCSRows = new System.Windows.Forms.DataGridViewCellStyle();
            DGVCSRows.Font = new System.Drawing.Font("宋体", 10F);
            DGVCSRows.ForeColor = Color.FromArgb(51, 51, 51);
            DgvEx.RowsDefaultCellStyle = DGVCSRows;
            this.BringToFront();
            ((System.ComponentModel.ISupportInitialize)(DgvEx)).EndInit();

            this.Click += new EventHandler(TextBoxDplDgv_Click);
            this.KeyDown += new KeyEventHandler(TextBoxDplDgv_KeyDown);



            this.Enter += new EventHandler(TextBoxDplDgv_Enter);
            this.Leave += new EventHandler(TextBoxDplDgv_Leave);
            this.PreviewKeyDown += new PreviewKeyDownEventHandler(TextBoxDplDgv_PreviewKeyDown);

            DgvEx.KeyDown += new KeyEventHandler(DgvEx_KeyDown);
            DgvEx.CellDoubleClick += new DataGridViewCellEventHandler(DgvEx_CellDoubleClick);

            DgvEx.LostFocus += new EventHandler(DgvEx_LostFocus);

            DgvEx.CellFormatting += new DataGridViewCellFormattingEventHandler(DgvEx_CellFormatting);

        }

        private void DgvEx_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is string)
                e.Value = e.Value.ToString().Trim();
        }


        /// <summary>
        /// tab按下验证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TextBoxDplDgv_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Tab)
            {
                DgvEx.Hide();
                if (this.Text.Trim().Length > 0)
                {
                    string strWhere = DgvDataSourceWhere.Replace("@keyword", this.Text.Trim());
                    strWhere = strWhere.Replace("like", "=").Replace("%", "");
                    DataRow[] drs = ((DataTable)DgvDataSource).Select(strWhere);
                    if (drs.Length <= 0)
                    {
                        MessageBox.Show("输入不正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                        this.SelectAll();

                    }
                }
            }
        }

        /// <summary>
        /// 绑定到当前窗体加载控件事件
        /// </summary>
        internal void BindTextBoxDplDgvToForm()
        {
            Control parentControl = this.Parent;

            DgvForm.MouseClick += new MouseEventHandler(parentControl_MouseClick);
            DgvForm.KeyDown += new KeyEventHandler(parentControl_KeyDown);

            parentControl.MouseClick += new MouseEventHandler(parentControl_MouseClick);
            parentControl.KeyDown += new KeyEventHandler(parentControl_KeyDown);

            DgvForm.Controls.Add(DgvEx);
            DgvForm.Controls.SetChildIndex(DgvEx, 0);
        }

        /// <summary>
        /// parentControl按下键选择DataGridView中的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void parentControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (DgvEx == null)
                return;

            if (DgvEx.Visible == true && e.KeyCode == Keys.Down)
            {
                if (DgvEx.Rows.Count > 0)
                {
                    DgvEx.Focus();
                    DgvEx.Rows[0].Selected = true;
                }
            }

            if (e.KeyCode == Keys.Escape)
            {
                DgvEx.Hide();
            }
        }

        /// <summary>
        /// parentControl离开DataGridView以外按鼠标左右键DataGridView隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void parentControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                DgvEx.Hide();
            }
        }

        /// <summary>
        /// DataGridView双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void DgvEx_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvEx.CurrentRow.Index >= 0)
            {
                //双击默认跳到下一个
                SelectNextControlFlag = true;
                TextBoxBindValue();
            }
        }

        /// <summary>
        /// DataGridView回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void DgvEx_KeyDown(object sender, KeyEventArgs e)
        {
            if (DgvEx.Rows.Count > 0 && DgvEx.CurrentRow.Index >= 0)
            {
                if (e.KeyCode == Keys.Enter && DgvEx.Focus())
                {
                    TextBoxBindValue();
                }
            }
        }

        #region 赋值
        /// <summary>
        /// 给TextBox赋值
        /// </summary>
        internal void TextBoxBindValue()
        {
            this.dataGridViewRow = DgvEx.CurrentRow;
            if (!string.IsNullOrEmpty(DisplayMember) && !string.IsNullOrEmpty(ValueMember))
            {
                this.Tag = DgvEx.CurrentRow.Cells[ValueMember].Value.ToString().Trim();
                this.Text = DgvEx.CurrentRow.Cells[DisplayMember].Value.ToString().Trim();
            }
            else
            {
                foreach (Control ctl in DgvForm.Controls)
                {
                    ControlSetValue(ctl);
                }
                //DgvEx.Hide();
                this.Text = thisText;
            }
            DgvEx.Hide();
            this.Focus();
            if (textBoxDplDgv_Selected != null)
            {
                textBoxDplDgv_Selected(this, new EventArgs());
            }
            if (SelectNextControlFlag)
            {
                this.Parent.SelectNextControl(this, true, true, true, true);
            }
        }

        /// <summary>
        /// 给对应的控件负值
        /// </summary>
        /// <param name="ctls"></param>
        internal void ControlSetValue(Control ctls)
        {
            if (ctls.HasChildren)
            {
                foreach (Control ctl in ctls.Controls)
                {
                    ControlSetValue(ctl);
                }
            }
            else
            {
                if (ctls is TextBoxEx || ctls is LabelEx || ctls is TextBoxDplDgv || ctls is DateTimePickerEx)
                {
                    if (ctls.Tag != null)
                    {
                        for (int i = 0; i < DgvRow.Cells.Count; i++)
                        {
                            if (DgvEx.Columns[i].Name.ToString() == ctls.Tag.ToString())
                            {
                                if (ctls.Tag.ToString() == this.Tag.ToString())
                                {
                                    thisText = DgvRow.Cells[i].Value == null ? "" : DgvRow.Cells[i].Value.ToString().Trim();
                                }
                                else
                                {
                                    ctls.Text = DgvRow.Cells[i].Value == null ? "" : DgvRow.Cells[i].Value.ToString().Trim();
                                }
                                break;
                            }
                        }
                    }
                }
            }
        }
        #endregion


        #region 清空
        /// <summary>
        /// 清空TextBox赋值
        /// </summary>
        internal void TextBoxClearValue()
        {
            this.dataGridViewRow = DgvEx.CurrentRow;
            if (!string.IsNullOrEmpty(DisplayMember) && !string.IsNullOrEmpty(ValueMember))
            {
                this.Tag = "";
            }
            else
            {
                if (DgvForm != null)
                {
                    foreach (Control ctl in DgvForm.Controls)
                    {
                        ControlClearValue(ctl);
                    }
                }
                //DgvEx.Hide();
            }
            DgvEx.Hide();
            //this.Parent.SelectNextControl(this, true, true, true, true);
        }

        /// <summary>
        /// 清空对应的控件负值
        /// </summary>
        /// <param name="ctls"></param>
        internal void ControlClearValue(Control ctls)
        {
            if (ctls.HasChildren)
            {
                foreach (Control ctl in ctls.Controls)
                {
                    ControlClearValue(ctl);
                }
            }
            else
            {
                if (ctls is TextBoxEx || ctls is LabelEx || ctls is TextBoxDplDgv || ctls is DateTimePickerEx)
                {
                    if (ctls.Tag != null)
                    {
                        if (DgvRow != null)
                        {
                            for (int i = 0; i < DgvRow.Cells.Count; i++)
                            {
                                if (DgvEx.Columns[i].Name.ToString() == ctls.Tag.ToString() && ctls.Tag.ToString() != this.Tag.ToString())
                                {
                                    ctls.Text = "";
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }
        #endregion

        /// <summary>
        /// TextBoxDplDgv 点击 绑定DataGridViewEx显示事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        internal void TextBoxDplDgv_Click(object sender, EventArgs e)
        {
            DgvExShow(sender, e);
        }

        internal void TextBoxDplDgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                DgvEx.Focus();
                //DgvExShow();
            }
            if (e.KeyCode == Keys.Enter)
            {
                if (DgvEx.Visible)
                {
                    DgvEx.Focus();
                    if (DgvEx.Rows.Count > 0 && DgvEx.CurrentRow.Index >= 0)
                    {
                        TextBoxBindValue();

                    }
                }
                else
                {
                    if (this.SelectNextControlFlag)
                    {
                        this.Parent.SelectNextControl(this, true, true, true, true);
                    }
                }
            }

        }

        internal void TextBoxDplDgv_Enter(object sender, EventArgs e)
        {
            if (VisibleSource)
                this.TextChanged += new EventHandler(TextBoxDplDgv_TextChanged);
        }

        private void TxtExistDt()
        {
            if (!this.Focused && !DgvEx.Focused)
            {
                DgvEx.Hide();
                if (this.Text.Trim().Length > 0 && thisText.Length > 0)
                {
                    string strWhere = DgvDataSourceWhere.Replace("@keyword", thisText);
                    strWhere = strWhere.Replace("like", "=").Replace("%", "");
                    DataRow[] drs = ((DataTable)DgvDataSource).Select(strWhere);
                    if (drs.Length <= 0)
                    {
                        MessageBox.Show("输入不正确！", "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Focus();
                        this.SelectAll();

                    }
                }

            }
        }

        internal void TextBoxDplDgv_Leave(object sender, EventArgs e)
        {
            this.TextChanged -= new EventHandler(TextBoxDplDgv_TextChanged);
            TxtExistDt();

        }

        internal void DgvEx_LostFocus(object sender, EventArgs e)
        {
            TxtExistDt();
        }

        internal void TextBoxDplDgv_TextChanged(object sender, EventArgs e)
        {
            TextBoxClearValue();
            DgvExShow(sender, e);
        }

        /// <summary>
        /// 绑定显示
        /// </summary>
        internal void DgvExShow(object sender, EventArgs e)
        {

            //如果没绑数据则不显示
            if (DgvDataSource == null)
            {
                if (txtdgv_dataBinds != null)
                {
                    txtdgv_dataBinds(sender, e);
                }
                else
                {
                    return;
                }
            }
            try
            {
                if (DgvDataSource == null) return;

                this.dgvForm = this.FindForm();
                DgvForm.KeyPreview = true;

                DataTable dt = new DataTable();
                dt = ((DataTable)DgvDataSource).Clone();

                ////添加对文本框为焦点时过滤%  pwg 20140506
                string txtwhere = "";
                if (this.Text.Trim().Contains("%"))
                {
                    int indesif = this.Text.Trim().IndexOf("%");
                    int length = this.Text.Trim().Length;
                    if (indesif != 0 && length > 1 && indesif + 1 < length)
                        txtwhere = this.Text.Trim().Replace("%", "");
                }
                else
                    txtwhere = this.Text.Trim();

                string strWhere = DgvDataSourceWhere.Replace("@keyword", txtwhere);

                DataRow[] drs = ((DataTable)DgvDataSource).Select(strWhere);

                int row = 0;
                foreach (DataRow dr in drs)
                {
                    row++;
                    if (row == ShowRowCount) break;
                    dt.ImportRow(dr);
                }

                DgvEx.TabIndex = this.TabIndex;

                DgvX = 0;
                DgvY = 0;
                controlParent(this);

                //DgvX = this.Location.X;
                //DgvY=this.Location.Y;
                DgvEx.Location = new Point(DgvX, DgvY + this.Height);

                //DgvEx.Location = this.FindForm().PointToClient(this.PointToScreen(new Point(-2, this.Height)));

                Size size = DgvForm.Size;
                if (wValue >= (size.Width - DgvX))
                {
                    wValue = (size.Width - DgvX) - 15;
                }
                if (hValue >= (size.Height - (DgvY + this.Height)))
                {
                    hValue = (size.Height - (DgvY + this.Height)) - 15;
                }

                DgvEx.Size = new System.Drawing.Size(WValue, HValue);

                DgvEx.Parent = this.Parent;

                DgvEx.BringToFront();

                DgvEx.DataSource = null;

                DgvEx.DataSource = dt;

                string[] indexs = VisibleIndexs.Split(',');
                foreach (string index in indexs)
                {
                    int a;
                    if (int.TryParse(index, out a))
                    {
                        DgvEx.Columns[a].Visible = false;
                    }
                }

                float widths = 0;

                DgvEx.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


                for (int i = 0; i < DgvEx.Columns.Count; i++)
                {
                    if (DgvEx.Columns[i].Visible)
                    {
                        widths += DgvEx.Columns[i].GetPreferredWidth(DataGridViewAutoSizeColumnMode.AllCells, true); // 计算调整列后单元列的宽度和 
                    }
                }

                if (widths >= DgvEx.Size.Width - 7) // 如果调整列的宽度大于设定列宽 
                    DgvEx.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells; // 调整列的模式 自动
                //else
                //    DgvEx.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // 如果小于 则填充 



                Cursor.Current = Cursors.Default;

                DgvEx.Show();
                this.Focus();
                BindTextBoxDplDgvToForm();
            }
            catch (Exception ex)
            {
                //throw new Exception(ex.Message);
                MessageBox.Show(ex.Message);
            }

        }




        /// <summary>
        /// 判断控件的父容器，取Location值
        /// </summary>
        /// <param name="con"></param>
        private void controlParent(Control con)
        {
            if (con != null && con.Name != DgvForm.Name)
            {
                DgvX += con.Location.X;
                DgvY += con.Location.Y;

                controlParent(con.Parent);
            }
        }

    }
}
