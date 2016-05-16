using DDIV.DAL;
using DDIV2.DAL;
using Model;
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
    public partial class FtpEdit : Form
    {
        public FtpEdit()
        {
            InitializeComponent();
        }
        DAL_Config dal = new DAL_Config();
        DAL_Execute executedal = new DAL_Execute();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            btnsearch();
        }
        private void btnsearch()
        {
            DataSet ds = dal.GetFtpList(this.txtbusname.Text.Trim());
            if (ds != null)
                dgvleft.DataSource = ds.Tables[0].DefaultView;

        }

        private void dgvleft_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //过滤双击列表头弹出窗体
            if (e.RowIndex != -1)
            {
                if (this.dgvleft.SelectedRows.Count > 0)
                {
                    //存在选中行
                    DataGridViewRow dgvr = this.dgvleft.SelectedRows[0];
                    dgvleft.Tag = dgvr.Index;
                    this.txtid.Text = dgvr.Cells["编号"].Value.ToString();
                    this.txbusname.Text = dgvr.Cells["业务名称"].Value.ToString();

                    FtpConfig ftpconfig = executedal.GetFtpConfigList(this.txtid.Text);
                    if (ftpconfig != null && ftpconfig.Configid > 0)
                    {
                        txtftpurl.Text = ftpconfig.FtpUrl.ToString();
                        if (ftpconfig.FileUrl != "" && ftpconfig.FileUrl != null)
                            txtfileurl.Text = ftpconfig.FileUrl.ToString();
                        else
                            txtfileurl.Text = "";
                        txtusername.Text = ftpconfig.FtpUser.ToString();
                        txtpwd.Text = ftpconfig.FtpPassWord.ToString();

                        if (ftpconfig.Enabled == "0")
                            cbEnabled.Checked = true;
                        else
                            cbEnabled.Checked = false;


                        this.btnSave.Text = "更新";
                    }
                    else
                    {
                        txtftpurl.Text = "";
                        txtfileurl.Text = "";
                        txtusername.Text = "";
                        txtpwd.Text = "";

                        cbEnabled.Checked = true;


                        this.btnSave.Text = "保存";
                    }




                }
                else
                {
                    MessageBox.Show("请选择要设置的数据！");
                }
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtftpurl.Text.Length <= 0)
            {
                MessageBox.Show(this, "Ftp上传地址不可以为空！");
            }
            else if (this.txtftpurl.Text.Length >= 100)
            {
                MessageBox.Show(this, "Ftp上传地址长度不可以超过100！");
            }
            //else if (this.txtfileurl.Text.Length <= 0)
            //{
            //    MessageBox.Show(this, "Ftp目标路径不可以为空！");
            //}
            //else if (this.txtfileurl.Text.Length >= 50)
            //{
            //    MessageBox.Show(this, "Ftp目标路径长度不可以超过50！");
            //}
            else if (this.txtusername.Text.Length <= 0)
            {
                MessageBox.Show(this, "用户名不可以为空！");
            }
            else if (this.txtusername.Text.Length >= 50)
            {
                MessageBox.Show(this, "用户名长度不可以超过50！");
            }
            else if (this.txtpwd.Text.Length <= 0)
            {
                MessageBox.Show(this, "密码不可以为空！");
            }
            else if (this.txtpwd.Text.Length >= 50)
            {
                MessageBox.Show(this, "密码长度不可以超过50！");
            }
            else
            {
                FtpConfig model = new FtpConfig();
                model.Configid = Convert.ToInt32(txtid.Text.Trim());
                model.FtpUser = this.txtusername.Text.Trim();
                model.FtpPassWord = txtpwd.Text.Trim();
                model.FtpUrl = this.txtftpurl.Text.Trim();
                model.FileUrl = this.txtfileurl.Text.Trim();

                if (cbEnabled.Checked == true)
                    model.Enabled = "0";
                else
                    model.Enabled = "1";


                DAL_FtpConfig dal = new DAL_FtpConfig();

                if (btnSave.Text == "保存")
                {
                    if (dal.Add(model) > 0)
                    {
                        SetUpUCEmpty();
                        MessageBox.Show(this, "添加成功");
                    }
                    else
                    {
                        MessageBox.Show(this, "添加失败");
                    }
                }
                else
                {
                    if (dal.Update(model) > 0)
                    {
                        MessageBox.Show(this, "更新成功");
                    }
                    else
                    {
                        MessageBox.Show(this, "更新失败");
                    }
                }
            }

        }
        private void SetUpUCEmpty()
        {
            this.txtftpurl.Text = "";
            this.txtfileurl.Text = "";
            this.txtusername.Text = "";
            this.txtpwd.Text = "";
            cbEnabled.Checked = true;
        }

        private void dgvleft_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
            }
        }




    }
}
