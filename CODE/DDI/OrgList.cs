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
    public partial class OrgList : Form
    {
        public OrgList()
        {
            InitializeComponent();
        }
        private void OrgList_Load(object sender, EventArgs e)
        {
            string LoginName = AppData.LoginName;

            txtusers.Text = LoginName;

        }
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (this.txtorgcode.Text.Length <= 0)
            {
                MessageBox.Show(this, "关联机构编码不可以为空！");
            }

            UserLogin ul = new UserLogin();

            int res = ul.AddUserOrgCodeList(txtusers.Text.Trim(), txtorgcode.Text.Trim());
            if(res==-1)
            {
                 MessageBox.Show(this, "已关联当前机构编码");
            }
            else
            {
                MessageBox.Show(this, "关联添加成功");
                txtorgcode.Text="";

            }


        }

       
    }
}
