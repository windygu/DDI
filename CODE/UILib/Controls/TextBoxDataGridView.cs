using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace ORG.UILib.Controls
{
    public partial class TextBoxDataGridView :  TextBoxEx
    {
        //public delegate void TestEventHandler(object sender, EventArgs e);

        //[Category("Custom"), Description("自定义Test事件")]
        //public event TestEventHandler Test_click;

        //public void Test_click(object sender, EventArgs e)
        //{
        //    if (Test_click != null)
        //        Test_click(sender, e);
        //}

        private DataSet dsParam;
        /// <summary>
        /// 绑定的DataGridViewEx返回值
        /// </summary>
        [Category("Custom"), Browsable(true), Description("设置要绑定的查询条件DataSet")]
        public DataSet DsParam
        {
            set { this.dsParam = value; }
            get { return dsParam; }
        }

        private DataSet dsList = null;
        /// <summary>
        /// 绑定的DataGridViewEx的数据源
        /// </summary>
        [Category("Custom"), Browsable(true), Description("绑定的DataGridViewEx的数据源")]
        public DataSet DsList
        {
            set { this.dsList = value; }
            get { return dsList; }
        }

        private Form frm = null;

        private DataGridViewEx dgvList = null;
        /// <summary>
        /// DataGridViewEx控件
        /// </summary>
        [Category("Custom"), Browsable(true), Description("绑定的DataGridViewEx")]
        public DataGridViewEx DgvList
        {
            get { return dgvList; }
        }

        public TextBoxDataGridView()
        {
            InitializeComponent();

            InitDataGridView();
        }

        public TextBoxDataGridView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            InitDataGridView();
        }

        /// <summary>
        /// 创建DataGridView
        /// </summary>
        private void InitDataGridView()
        {
            this.dgvList = new DataGridViewEx();

            DgvList.Hide();

            DgvList.AllowUserToAddRows = false;
            DgvList.AllowUserToDeleteRows = false;
            DgvList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            DgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            DgvList.BackgroundColor = System.Drawing.SystemColors.Window;
            DgvList.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            DgvList.RowHeadersVisible = false;
            DgvList.EditMode = DataGridViewEditMode.EditProgrammatically;
            DgvList.BringToFront();
            ((System.ComponentModel.ISupportInitialize)(DgvList)).EndInit();
            DgvList.KeyDown += new KeyEventHandler(dgvList_KeyDown);
            DgvList.CellDoubleClick += new DataGridViewCellEventHandler(dgvList_CellDoubleClick);

            DgvList.KeyDown += new KeyEventHandler(dgvList_KeyDown);
            DgvList.CellDoubleClick += new DataGridViewCellEventHandler(dgvList_CellDoubleClick);
        }

        /// <summary>
        /// 设置DataGridView位置以及父窗体相应事件
        /// </summary>
        /// <param name="wValue"></param>
        /// <param name="hValue"></param>
        private void BindDataGridView()
        {
            Control frmControl = this.frm;

            Control parentControl = this.Parent;

            parentControl.MouseClick += new MouseEventHandler(parentControl_MouseClick);

            if (this.Parent.Name != this.frm.Name)
            {
                frmControl.KeyDown += new KeyEventHandler(parentControl_KeyDown);
            }
            else
            {
                parentControl.KeyDown += new KeyEventHandler(parentControl_KeyDown);
            }

            this.frm.Controls.Add(DgvList);
            this.frm.Controls.SetChildIndex(DgvList, 0);
        }

        /// <summary>
        /// DataGridView双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DgvList.SelectedCells.Count != 0)
            {
                foreach (Control ctl in this.Parent.Controls)
                {
                    ControlGetValue(ctl);
                }

                DgvList.Hide();
            }
        }

        /// <summary>
        /// DataGridView回车事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && this.Focus())
            {
                foreach (Control ctl in this.Parent.Controls)
                {
                    ControlGetValue(ctl);
                }

                DgvList.Hide();
            }
        }

        /// <summary>
        /// 给对应的控件赋值
        /// </summary>
        /// <param name="ctls"></param>
        private void ControlGetValue(Control ctls)
        {
            int CIndex = DgvList.CurrentRow.Index;

            if (ctls.HasChildren)
            {
                foreach (Control ctl in ctls.Controls)
                {
                    ControlGetValue(ctl);
                }
            }
            else
            {
                if (ctls is TextBoxEx || ctls is LabelEx)
                {
                    if (ctls.Tag != null)
                    {
                        for (int i = 0; i < DsParam.Tables[0].Rows.Count; i++)
                        {
                            if (DsParam.Tables[0].Rows[i]["paramName"].ToString().Trim() == ctls.Tag.ToString())
                            {
                                ctls.Text = DgvList[ctls.Tag.ToString(), CIndex].Value.ToString().Trim();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 离开DataGridView以外按鼠标左右键DataGridView隐藏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void parentControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right || e.Button == MouseButtons.Left)
            {
                DgvList.Hide();
            }
        }

        /// <summary>
        /// 按下键选择DataGridView中的数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void parentControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (DgvList.Visible == true && e.KeyCode == Keys.Down)
            {
                if (DgvList.Rows.Count > 0)
                {
                    DgvList.Focus();
                    DgvList.Rows[0].Selected = true;
                }
            }
        }

        /// <summary>
        /// Form窗体Enter键切换文本框
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void parentControl_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    if (e.KeyChar == (char)13)
        //    {
        //        this.frm.SelectNextControl(this.frm.ActiveControl, true, true, true, true);
        //    }
        //}

        int DgvX, DgvY;

        public void dgvShow(int wValue, int hValue)
        {
            this.frm = FindForm();

            DgvX = 0;
            DgvY = 0;
            //如果没绑数据则不显示
            if (DsList != null)
            {
                DgvList.TabIndex = this.TabIndex;

                DgvList.Size = new System.Drawing.Size(wValue, hValue);

                controlParent(this);

                DgvList.Location = new Point(DgvX, DgvY + this.Height);

                DgvList.Parent =this.Parent;

                DgvList.DataSource = null;

                DgvList.DataSource = DsList.Tables[0].DefaultView;

                int widths = 0;

                for (int i = 0; i < DgvList.Columns.Count; i++)
                {
                    DgvList.AutoResizeColumn(i, DataGridViewAutoSizeColumnMode.AllCells); // 自动调整列宽 
                    widths += DgvList.Columns[i].Width; // 计算调整列后单元列的宽度和 
                }

                if (widths >= DgvList.Size.Width) // 如果调整列的宽度大于设定列宽 
                    DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells; // 调整列的模式 自动
                else
                    DgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // 如果小于 则填充 

                Cursor.Current = Cursors.Default;

                DgvList.Show();

                BindDataGridView();
            }
        }

        /// <summary>
        /// 判断控件的父容器，取Location值
        /// </summary>
        /// <param name="con"></param>
        private void controlParent(Control con)
        {
            if (con != null && con.Name != this.frm.Name)
            {
                DgvX += con.Location.X;
                DgvY += con.Location.Y;

                controlParent(con.Parent);
            }
        }
    }
}
