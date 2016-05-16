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
    public class DataGridViewDataWindowCell:DataGridViewTextBoxCell
    {
        

        public override void InitializeEditingControl(int rowIndex, object
              initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue,
                dataGridViewCellStyle);
            DataGridViewDataWindowEditingControl dataWindowControl =
                DataGridView.EditingControl as DataGridViewDataWindowEditingControl;

            DataGridViewDataWindowColumn dataWindowColumn=(DataGridViewDataWindowColumn)OwningColumn;
            //是否自动适应大小
            dataWindowControl.PopupGridAutoSize = dataWindowColumn.PopupGridAutoSize;
            //指定大小，要求PopupGridAutoSize=false
            dataWindowControl.PopupDataGridViewSize = dataWindowColumn.PopupDataGridViewSize;
            //指定数据源
            dataWindowControl.DataSource = dataWindowColumn.DataSource;
            //是否显示过滤框
            dataWindowControl.RowFilterVisible = dataWindowColumn.RowFilterVisible;
            //获取筛选列的值，多个列用“，”隔开
            dataWindowControl.sDisplayMember = dataWindowColumn.DisplayMember;
            //获取用于筛选的列，多个列用“，”隔开
            dataWindowControl.sKeyWords = dataWindowColumn.KeyWords;
            //获取列的值，多个列用“，”隔开
            dataWindowControl.sValueMember = dataWindowColumn.ValueMember;


            dataWindowControl.Text = (string)this.Value;
        }
        [Browsable(false)]
        public override Type EditType
        {
            get
            {
                return typeof(DataGridViewDataWindowEditingControl);
            }
        }
       
        public override Type ValueType
        {
            get
            {
                return typeof(string);
            }
        }
        private DataGridViewDataWindowEditingControl EditingDataWindow
        {
            get
            {
                DataGridViewDataWindowEditingControl dataWindowControl =
                    DataGridView.EditingControl as DataGridViewDataWindowEditingControl;

                return dataWindowControl;
            }
        }
    }
}
