using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Design;

namespace ORG.UILib.Controls
{
    public class DataWindow : ComboBox
    {
        #region 成员变量
        private const int WM_LBUTTONDOWN = 0x201, WM_LBUTTONDBLCLK = 0x203;
        ToolStripControlHost dataGridViewHost;
        ToolStripControlHost textBoxHost;
        ToolStripDropDown dropDown;
        TextBox textBox = new TextBox();

        private string m_sKeyWords = "";
        private string m_sDisplayMember = "";
        private string m_sValueMember = "";
        private string m_sDisplayField = "";
        private string m_Separator = "|";
        private string m_NullValue = "";


        private bool m_blDropShow = false;
        private bool m_blPopupAutoSize = false;
        private Size m_PopupDataGridViewSize = new Size(300, 150);
        private int m_SelectedIndex=-1;
        public event EventHandler AfterSelector;
        
        #endregion
        #region 构造函数
        public DataWindow()
        {
            DrawDataGridView();
        }
        #endregion
        #region 属性
        [Description("空值时的默认值"), Browsable(true), Category("N8")]
        public string NullValue
        {
            set
            {
                m_NullValue = value;
            }
            get
            {
                return m_NullValue;
            }
        }
        [Description("查询关键字"), Browsable(true), Category("N8")]
        public string sKeyWords
        {
            get
            {
                return m_sKeyWords;
            }
            set
            {
                m_sKeyWords = value;
            }
        }
        [Description("文本框显示字段用逗号分割！"), Browsable(true), Category("N8")]
        public string sDisplayMember
        {
            set
            {
                m_sDisplayMember = value;
               
            }
            get
            {
                return m_sDisplayMember;
            }
        }
        [Description("是否显示条件输入窗口！"), Browsable(true), Category("N8")]
        public bool RowFilterVisible
        {
            set
            {
                dropDown.Items[0].Visible = value;
            }
            get
            {
                return dropDown.Items[0].Visible;
            }
        }
        [Description("取值字段"), Browsable(true), Category("N8")]
        public string sValueMember
        {
            set
            {
                m_sValueMember = value;
            }
            get
            {
                return m_sValueMember;
            }
        }
        public DataView DataView
        {
            get
            {
                DataTable dataTable = GetDataTableFromDataSource();
                if (dataTable == null)
                {
                    return null;
                }
                return dataTable.DefaultView;
            }
        }
        [Description("设置DataGridView属性"), Browsable(true), Category("N8")]
        public DataGridView DataGridView
        {
            get
            {
                return dataGridViewHost.Control as DataGridView;
            }
        }
        public TextBox TextBox
        {
            get
            {
                return textBoxHost.Control as TextBox;
            }
        }
        [Description("下拉表格显示列，空为显示所有列！"), Browsable(true), Category("N8")]
        public string sDisplayField
        {
            set
            {
                m_sDisplayField = value;
            }
            get
            {
                return m_sDisplayField;
            }
        }
        [Description("数据源"), Browsable(true), Category("N8")]
        public new Object DataSource
        {
            set
            {
                if (m_sDisplayField != String.Empty)
                {
                   DataGridView.Columns.Clear();
                   DataGridView.AutoGenerateColumns=false;
                    string[] sDisplayFields = m_sDisplayField.Split(',');
                    foreach (string sDisplay in sDisplayFields)
                    {
                        DataGridViewTextBoxColumn dgvCell = new DataGridViewTextBoxColumn();
                        dgvCell.Name = sDisplay;
                        dgvCell.DataPropertyName = sDisplay;
                        DataGridView.Columns.Add(dgvCell);
                    }
                }
                 DataGridView.DataSource = value;
            }
            get
            {
                return DataGridView.DataSource;
            }
        }

        [Description("下拉表格尺寸是否为自动"), Browsable(true), Category("N8")]
        public bool PopupGridAutoSize
        {
            set
            {
                m_blPopupAutoSize = value;
            }
            get
            {
                return m_blPopupAutoSize;
            }
        }
        [Description("下拉表格大小"), Browsable(true), Category("N8")]
        public Size PopupDataGridViewSize
        {
            set
            {
                m_PopupDataGridViewSize = value;
            }
            get
            {
                return m_PopupDataGridViewSize;
            }
        }
        [Description("分割符号"), Browsable(true), Category("N8")]
        public string SeparatorChar
        {
            set
            {
                m_Separator = value;
            }
            get
            {
                return m_Separator;
            }
        }
        [Browsable(false), Bindable(true)]
        public string Value
        {
            get
            {
                if (Text == String.Empty)
                {
                    m_SelectedIndex = -1;
                }
                if (!String.IsNullOrEmpty(m_sValueMember))
                {
                    if (DataView == null)
                    {
                        return Text;
                    }
                    if (m_SelectedIndex > -1)
                    {
                        object obj = DataView[m_SelectedIndex][m_sValueMember];
                        return obj.ToString();
                    }
                    else
                    {
                        return m_NullValue;
                    }
                }
                else
                {
                    return Text;
                }
            }
            set
            {
                int i = 0;
                if (m_sValueMember == String.Empty)
                {
                    Text = value;
                }
                else
                {
                    Text = "";
                    if (DataView != null)
                    {
                        DataView.RowFilter = "";
                        foreach (DataRowView dataRowView in DataView)
                        {
                            if (dataRowView[m_sValueMember].ToString() == value)
                            {
                                m_SelectedIndex = i;
                                string[] sDisplayList = m_sDisplayMember.Split(',');
                                foreach (string sDisplay in sDisplayList)
                                {
                                    if (DataGridView.Columns.Contains(sDisplay))
                                    {
                                        object obj = DataView[m_SelectedIndex][sDisplay];
                                        Text += obj.ToString() + m_Separator;
                                    }
                                }
                                Text = Text.TrimEnd('|');
                                break;
                            }
                            i++;
                        }
                    }
                }

            }
        }
        #endregion
        #region 方法
        #region 绘制DataGridView以及下拉DataGridView
        private void DrawDataGridView()
        {
            DataGridView dataGridView = new DataGridView();
            dataGridView.BackgroundColor = SystemColors.Control;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.ReadOnly = true;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.RowHeadersVisible = false;

            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.DoubleClick += new EventHandler(dataGridView_DoubleClick);
            dataGridView.KeyDown += new KeyEventHandler(dataGridView_KeyDown);

            //设置DataGridView的数据源
            Form frmDataSource = new Form();
            frmDataSource.Controls.Add(dataGridView);
            frmDataSource.SuspendLayout();
            //dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;

            dataGridViewHost = new ToolStripControlHost(dataGridView);
            dataGridViewHost.AutoSize =  m_blPopupAutoSize;

            //TextBox textBox = new TextBox();
            textBox.TextChanged+=new EventHandler(textBox_TextChanged);
            textBox.KeyDown+=new KeyEventHandler(textBox_KeyDown);
            textBoxHost = new ToolStripControlHost(textBox);
            textBoxHost.AutoSize =false ;

            dropDown = new ToolStripDropDown();
            dropDown.Width = this.Width;
            dropDown.Items.Add(textBoxHost);
            dropDown.Items.Add(dataGridViewHost);
           
        }
        #endregion
        public string GetDataProperty(string sColumn)
        {
            string sValue = "";
            if (DataView != null)
            {
                if (DataGridView.Columns.Contains(sColumn))
                {
                    sValue = DataView[m_SelectedIndex][sColumn].ToString();
                }
            }
            return sValue;
        }
        public void dataGridView_DoubleClick(object sender, EventArgs e)
        {

            PopupGridView(e);
        }
        /// <summary>
        /// 弹出下拉表格并触发选择后事件
        /// </summary>
        /// <param name="e"></param>
        private void PopupGridView(EventArgs e)
        {
            if (DataGridView.SelectedRows.Count > 0)
            {
                DataGridViewRow dgvRow = DataGridView.CurrentRow;
                m_SelectedIndex = DataGridView.CurrentRow.Index;
                if (m_sDisplayMember != String.Empty)
                {
                    Text = "";
                    string[] sDisplayList = m_sDisplayMember.Split(',');
                    foreach (string sDisplay in sDisplayList)
                    {
                        if (DataGridView.Columns.Contains(sDisplay))
                        {
                            Text += dgvRow.Cells[sDisplay].Value.ToString() + m_Separator;
                        }
                    }
                    Text = Text.TrimEnd('|');
                }
                else
                {
                    Text = dgvRow.Cells[0].Value.ToString();
                }
                if (AfterSelector != null)
                {
                    AfterSelector(this,e);
                }
            }
            dropDown.Close();
            m_blDropShow=false;
           
        }
        private DataTable GetDataTableFromDataSource()
        {
            object dataSource = DataGridView.DataSource;
            return GetDataTableFromDataSource(dataSource);
        }
        /// <summary>
        /// 从DataGridView 获取数据表
        /// </summary>
        /// <returns></returns>
        private DataTable GetDataTableFromDataSource(object dataSource)
        {
            if (dataSource is DataTable)
            {
                return (DataTable)dataSource;
            }
            else if (dataSource is DataView)
            {
                return ((DataView)dataSource).Table;
            }
            else if (dataSource is BindingSource)
            {
                object bind = ((BindingSource)dataSource).DataSource;
                if (bind is DataTable)
                {
                    return (DataTable)bind;
                }
                else
                {
                    return ((DataView)bind).Table;
                }
            }
            else
            {
                return null;
            }
        }
        private void ShowDropDown()
        {
            if (dropDown != null)
            {
                if (DataView != null)
                {
                    DataView.RowFilter = "";
                    TextBox.Text = "";
                    textBoxHost.Width = 200; 
                    dataGridViewHost.AutoSize = m_blPopupAutoSize;
                   
                    //dataGridViewHost.Size = new Size(DropDownWidth - 2, DropDownHeight); 
                    dataGridViewHost.Size = m_PopupDataGridViewSize;
                    dropDown.Show(this, 0, this.Height);
                    //如果支持筛选，筛选框自动选中
                    if(RowFilterVisible)
                    {
                        textBox.Focus();
                    }
                }
               
            }
        }
        private void dataGridView_KeyDown(object sender,KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                PopupGridView(e);
            }
        }
        #region 重写方法
     
        private string  GetRowFilterString(string sText)
        {
            string sFilter = "";
            if (m_sDisplayMember == String.Empty || m_sDisplayMember == null)
            {
                m_sDisplayMember = DataView.Table.Columns[0].ColumnName;
            }
            if (m_sKeyWords == String.Empty)
            {
                m_sKeyWords = m_sDisplayMember;
            }
            string[] sColumns = m_sKeyWords.Split(',');
            foreach (string sColumn in sColumns)
            {
                sFilter += sColumn + " like " + "'%" + sText + "%'"+" or ";
            }
            sFilter=sFilter.Trim().TrimEnd("or".ToCharArray());
            return sFilter;
        }
        private void textBox_TextChanged(object sender,System.EventArgs e)
        {
            DataView.RowFilter = GetRowFilterString(TextBox.Text);
        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                PopupGridView(e);
            }
            else if (e.KeyData == Keys.Up||e.KeyData == Keys.Down)
            {
                dataGridViewHost.Focus();
            }
        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);
            if (e.KeyData == Keys.Enter)
            {
                DataView.RowFilter = GetRowFilterString(Text);
                PopupGridView(null);
            }
            else if (e.KeyData == Keys.Space)
            {
                ShowDropDown();
            }
        }
        /*protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!m_blDropShow)
            {
                ShowDropDown();
            }
        }*/
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK || m.Msg == WM_LBUTTONDOWN)
            {
                if (m_blDropShow)
                {
                    m_blDropShow = false;
                }
                else
                {
                    m_blDropShow = true;
                }
                if (m_blDropShow)
                {
                    ShowDropDown();
                }
                else
                {
                    dropDown.Close();
                }
                return;
            }
            base.WndProc(ref m);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (dropDown != null)
                {
                    dropDown.Dispose();
                    dropDown = null;
                }
            }
            base.Dispose(disposing);
        }
        #endregion
        #endregion
    }
}
