using DDIV.DAL;
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
    public partial class AuthorizeEdit : Form
    {
        public AuthorizeEdit()
        {
            InitializeComponent();
        }
        UserLogin dal = new UserLogin();

        public string SetSearchList()
        {
            string search = "";
            if (txtOrgCode.Text.Trim() != "")
            {
                search = " where OrgCode='" + txtOrgCode.Text.Trim() + "'";
            }

            return search;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataListLoad();
        }

        private void DataListLoad()
        {
            DataSet ds = dal.GetRegisterList(SetSearchList());
            if (ds != null)
            {
                dgvlist.DataSource = ds.Tables[0];
            }
            ;
        }

        private void dgvlist_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                foreach (DataGridViewRow dgvr in dgvlist.Rows)
                {
                    int index = dgvr.Index;
                    if(index==e.RowIndex)
                        dgvlist.Rows[e.RowIndex].Selected = true;
                    else
                        dgvlist.Rows[e.RowIndex].Selected = false;
                }
            }
        }

        private void btnAuthorize_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "您确定授权于当前所选机构吗？", "提示信息",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DataGridViewRow dgvr = this.dgvlist.SelectedRows[0];

                string register = dgvr.Cells["序列号"].Value.ToString().Trim();
                string status = dgvr.Cells["状态"].Value.ToString().Trim();

                if (status == "0")
                {
                    int ds = dal.SetAuthorize(register, "1");
                    if (ds > 0)
                    {
                        MessageBox.Show("授权成功");
                    }
                    else
                    {
                        MessageBox.Show("授权失败");
                    }
                }
                else
                {
                    MessageBox.Show("当前选择的数据已经授权启用");
                }
            }
        }

        private void btnForbidden_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "您确定禁用当前所选机构吗？", "提示信息",
                                                   MessageBoxButtons.YesNo,
                                                   MessageBoxIcon.Question) == DialogResult.Yes)
            {

                DataGridViewRow dgvr = this.dgvlist.SelectedRows[0];

                string register = dgvr.Cells["序列号"].Value.ToString().Trim();
                string status = dgvr.Cells["状态"].Value.ToString().Trim();

                if (status == "1")
                {
                    int ds = dal.SetAuthorize(register, "0");
                    if (ds > 0)
                    {
                        MessageBox.Show("禁用成功");
                    }
                    else
                    {
                        MessageBox.Show("禁用失败");
                    }
                }
                else
                {
                    MessageBox.Show("当前选择的数据已经禁用");
                }
            }
        }



    }
}
