using DDIV.DAL;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDIV2.UI
{
    public partial class RegisterSesting : Form
    {

        public RegisterSesting()
        {
            InitializeComponent();
        }


        private Configuration config;
        private void RegisterSesting_Load(object sender, EventArgs e)
        {
            txtCode.Text = AppData.OrgCode;
            txtName.Text = AppData.OrgName;
            txtCode.Enabled = false;
            txtName.Enabled = false;


            GetConfigRegister();

            if (txtregister.Text.Length > 0)
            {
                MessageBox.Show(this, "机构已经注册序列！");
                btnRegister.Visible = false;
            }

        }
        private void btnRegister_Click(object sender, EventArgs e)
        {

            if (this.txtCode.Text.Length == 0)
            {
                MessageBox.Show(this, "机构编码不可以为空！");
            }
            else if (this.txtName.Text.Length == 0)
            {
                MessageBox.Show(this, "机构机构名称不可以为空");
            }
            else if (this.textBoxEx3.Text.Length == 0)
            {
                MessageBox.Show(this, "描述不可以为空");
            }
            else
            {
                UserLogin dal = new UserLogin();
                string result = dal.Register(textBoxEx3.Text.Trim(), txtCode.Text.Trim(), txtName.Text.Trim());
                if (result != "")
                {
                    txtregister.Text = result;
                    SetConfigRegister(result);
                    MessageBox.Show(this, "注册成功,等待管理员审核");
                }
                else
                    MessageBox.Show(this, "注册失败");
            }

        }

        private void SetConfigRegister(string register)
        {
            config.AppSettings.Settings.Remove("SerialMumber");


            config.AppSettings.Settings.Add("SerialMumber", register);

            //保存配置文件
            config.Save(ConfigurationSaveMode.Modified);

            // 强制重新载入配置文件的ConnectionStrings配置节
            ConfigurationManager.RefreshSection("appSettings");
            //修改配置直接生效； 
            int len = config.AppSettings.Settings.AllKeys.Length;
            for (int i = 0; i < len; i++)
            {
                string temp = config.AppSettings.Settings.AllKeys[i];
                ConfigurationManager.AppSettings[temp] = config.AppSettings.Settings[temp].Value;
            }
        }

        private void GetConfigRegister()
        {

            string path = Application.StartupPath + "\\DDI.exe";

            config = ConfigurationManager.OpenExeConfiguration(path);
            string ConnectionString = string.Empty;

            int len = config.AppSettings.Settings.AllKeys.Length;
            string connvalue = "";
            for (int i = 0; i < len; i++)
            {
                string temp = config.AppSettings.Settings.AllKeys[i];
                if (temp == "SerialMumber")
                {
                    connvalue = ConfigurationManager.AppSettings[temp];
                    break;
                }
            }
            if (connvalue != "")
            {

                txtregister.Text = connvalue;
            }
        }
    }
}
