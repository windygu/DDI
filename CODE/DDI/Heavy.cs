using DDIV.DAL;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDIV2.UI
{
    public partial class Heavy : Form
    {
        public Heavy()
        {
            InitializeComponent();
        }

        private void btnSerch_Click(object sender, EventArgs e)
        {

            DAL.DAL_Config dalConfig = new DAL.DAL_Config();
            dgvcc.DataSource = null;
            DataSet ds = dalConfig.GetList(txtName.Text.Trim(), AppData.OrgCodeList);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvcc.DataSource = ds.Tables[0].DefaultView;
            }
        }

        private void btncc_Click(object sender, EventArgs e)
        {
            DAL_Execute bllel = new DAL_Execute();
            if (this.lblId.Text.Length == 0)
            {
                MessageBox.Show(this, "没有选择需要重采的数据行！");
                return;
            }
            if (this.txtywdate.Text.Length == 0)
            {
                MessageBox.Show(this, "请选择‘重采业务时间’！");
                return;
            }
            if (this.txtczdate.Text.Length == 0)
            {
                MessageBox.Show(this, "请选择‘重采操作时间’！");
                return;
            }

            DateTime ywdate = Convert.ToDateTime(txtywdate.Text.Trim());
            DateTime czdate = Convert.ToDateTime(txtczdate.Text.Trim());
            int configid = Convert.ToInt32(lblId.Text.Trim());
            bool result = bllel.ExecuteConfig(configid, ywdate, czdate);
            if (result)
                MessageBox.Show(this, "重采成功");
            else
                MessageBox.Show(this, "重采失败");
        }

        private void dgvcc_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {

                txtNewname.Text = dgvcc.Rows[e.RowIndex].Cells["业务名称"].Value.ToString().Trim();
                lblId.Text = dgvcc.Rows[e.RowIndex].Cells["编号"].Value.ToString().Trim();
            }
        }
    }
}
