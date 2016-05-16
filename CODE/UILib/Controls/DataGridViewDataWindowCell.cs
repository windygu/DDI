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
            //�Ƿ��Զ���Ӧ��С
            dataWindowControl.PopupGridAutoSize = dataWindowColumn.PopupGridAutoSize;
            //ָ����С��Ҫ��PopupGridAutoSize=false
            dataWindowControl.PopupDataGridViewSize = dataWindowColumn.PopupDataGridViewSize;
            //ָ������Դ
            dataWindowControl.DataSource = dataWindowColumn.DataSource;
            //�Ƿ���ʾ���˿�
            dataWindowControl.RowFilterVisible = dataWindowColumn.RowFilterVisible;
            //��ȡɸѡ�е�ֵ��������á���������
            dataWindowControl.sDisplayMember = dataWindowColumn.DisplayMember;
            //��ȡ����ɸѡ���У�������á���������
            dataWindowControl.sKeyWords = dataWindowColumn.KeyWords;
            //��ȡ�е�ֵ��������á���������
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
