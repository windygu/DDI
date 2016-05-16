using DDIV.DAL;
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
    public partial class UsersEdit : Form
    {
        public UsersEdit()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.txtUserNmae.Text.Length <= 0)
            {
                MessageBox.Show(this, "用户名不可以为空！");
            }
            else if (this.txtUserNmae.Text.Length >= 50)
            {
                MessageBox.Show(this, "用户名长度不可以超过50！");
            }
            else if (this.txtPwd.Text.Length <= 0)
            {
                MessageBox.Show(this, "密码不可以为空！");
            }
            else if (this.txtPwd.Text.Length >= 50)
            {
                MessageBox.Show(this, "密码长度不可以超过50！");
            }
            else if (this.txtOrgCode.Text.Length <= 0)
            {
                MessageBox.Show(this, "机构编码不可以为空！");
            }
            else if (this.txtOrgCode.Text.Length >= 50)
            {
                MessageBox.Show(this, "机构编码不可以超过50！");
            }
            else if (this.txtOrgName.Text.Length <= 0)
            {
                MessageBox.Show(this, "机构名称不可以为空！");
            }
            else if (this.txtOrgName.Text.Length >= 50)
            {
                MessageBox.Show(this, "机构名称不可以超过50！");
            }
            else
            {
                Users model = new Users();
                model.LoginName = txtUserNmae.Text.Trim();
                model.LoginPwd = txtPwd.Text.Trim();
                model.OrgCode = txtOrgCode.Text.Trim();
                model.OrgName = txtOrgName.Text.Trim();

                if (cbEnabled.Checked == true)
                    model.Enabled = "1";
                else
                    model.Enabled = "0";


                UserLogin dal = new UserLogin();

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

        }
        private void SetUpUCEmpty()
        {
            this.txtUserNmae.Text = "";
            this.txtPwd.Text = "";
            this.txtOrgCode.Text = "";
            this.txtOrgName.Text = "";
            cbEnabled.Checked = false;
        }

    }
}
