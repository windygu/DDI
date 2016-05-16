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
    public class DataGridViewDataWindowColumn:DataGridViewColumn
    {
        private string m_DisplayMember = string.Empty;
        private string m_ValueMember = string.Empty;
        private string m_KeyWords = string.Empty;
        private bool m_PopupGridAutoSize = false;
        private bool m_RowFilterVisible = false;
        private Size m_PopupDataGridViewSize = new Size(300, 150);

        private object m_dataSoruce = null;

        public DataGridViewDataWindowColumn()
            : base(new DataGridViewDataWindowCell())
        {
        }
        public override DataGridViewCell CellTemplate
        {
            get
            {
                return base.CellTemplate;
            }
            set
            {
                if (value != null && !value.GetType().IsAssignableFrom(typeof(DataGridViewDataWindowCell)))
                {
                    throw new InvalidCastException("����DataGridViewDataWindowCell");
                }
                base.CellTemplate = value;
            }
        }
        private DataGridViewDataWindowCell ComboBoxCellTemplate
        {
            get
            {
                return (DataGridViewDataWindowCell)this.CellTemplate;
            }
        }
        /// <summary>
        /// ����Դ
        /// </summary>
        public Object DataSource
        {
            get
            {
                return m_dataSoruce;

            }
            set
            {
                if (ComboBoxCellTemplate != value)
                {
             
                    m_dataSoruce = value;
                   
                }
            }
        }
        /// <summary>
        /// ��ȡɸѡ��ʾ���еĶ�Ӧ��ֵ�������á������ָ�
        /// </summary>
        public string DisplayMember
        {
            get{ return m_DisplayMember;}
            set{ m_DisplayMember = value; }
        }
         /// <summary>
        /// ��ȡɸѡ���еĶ�Ӧ��ֵ�������á������ָ�
        /// </summary>
        public string KeyWords
        {
            get { return m_KeyWords; }
            set { m_KeyWords = value; }
        }
        /// <summary>
        /// ��ȡѡ���еĶ�Ӧ��ֵ�������á������ָ�
        /// </summary>
        public string ValueMember
        {
            get { return m_ValueMember; }
            set { m_ValueMember = value; }
        }
        /// <summary>
        /// ����ѡ�񴰿��Ƿ��Զ���С��
        /// </summary>
        public bool PopupGridAutoSize
        {
            get { return m_PopupGridAutoSize; }
            set { m_PopupGridAutoSize = value; }
        }
        /// <summary>
        /// ����ѡ�񴰿��Ƿ���ʾ��ѯ�����
        /// </summary>
        public bool RowFilterVisible
        {
            get { return m_RowFilterVisible; }
            set { m_RowFilterVisible = value; }
        }
        /// <summary>
        /// ����ѡ�񴰿ڵĴ�С��
        /// </summary>
        public Size PopupDataGridViewSize
        {
            get { return m_PopupDataGridViewSize; }
            set { m_PopupDataGridViewSize = value; }
        }
    }
}
