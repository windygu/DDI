
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
    public partial class DataConfig : Form
    {
        public DataConfig()
        {
            InitializeComponent();
        }


        private Configuration configlest;

        List<DDI.Common.MyItem> Configlist = new List<DDI.Common.MyItem>();
        private void DataConfig_Load(object sender, EventArgs e)
        {
            
            List<DDI.Common.MyItem> list = new List<DDI.Common.MyItem>();
            list.Add(new DDI.Common.MyItem("SQL Server 数据引擎", "SQL Server 数据引擎"));
            list.Add(new DDI.Common.MyItem("Oracle 基本连接引擎", "SQL Server 数据引擎"));

            ddlType.DataSource = list;
            ddlType.DisplayMember = "Name";
            ddlType.ValueMember = "Value";



            lblTest.Text = "";



            string path = Application.StartupPath + "\\DDI.exe";

            configlest = ConfigurationManager.OpenExeConfiguration(path);
            int len = configlest.AppSettings.Settings.AllKeys.Length;
            for (int i = 0; i < len; i++)
            {
                string temp = configlest.AppSettings.Settings.AllKeys[i];
                string value = ConfigurationManager.AppSettings[temp];
                Configlist.Add(new DDI.Common.MyItem(temp, value));
            }



        }




        public bool ConfigLoad()
        {

            string path = Application.StartupPath + "\\DDI.exe";

            configlest = ConfigurationManager.OpenExeConfiguration(path);
            string ConnectionString = string.Empty;

            int len = configlest.AppSettings.Settings.AllKeys.Length;
            string connvalue = "";
            for (int i = 0; i < len; i++)
            {
                string temp = configlest.AppSettings.Settings.AllKeys[i];
                if (temp == "ConnectionString")
                {
                    connvalue = ConfigurationManager.AppSettings[temp];
                    break;
                }
            }
            if (connvalue != "")
            {

                string conn = DESEncrypt.Decrypt(connvalue);
                txtConnection.Text = connvalue;
                return true;
            }
            else
                return false;
        }


        private string SetConn()
        {
            string result = "";
            if (txtConnection.Text.Length <= 0)
            {
                MessageBox.Show(this, "服务器名称不可以为空");
            }
            else if (this.txtuname.Text.Length <= 0)
            {
                MessageBox.Show(this, "用户名不可以为空");
            }
            else if (this.txtpwd.Text.Length <= 0)
            {
                MessageBox.Show(this, "密码不可以为空");
            }
            else
            {
                if (ddlType.SelectedValue.ToString() == "SQL Server 数据引擎")
                {
                    if (this.txtdatabase.Text.Length < 1)
                    {
                        MessageBox.Show(this, "数据库名称不可以为空");
                    }
                    else
                    {
                        StringBuilder strSql = new StringBuilder();
                        strSql.Append("server=" + txtConnection.Text.Trim() + ";");
                        strSql.Append(" uid=" + txtuname.Text.Trim() + ";");
                        strSql.Append(" pwd=" + txtpwd.Text.Trim() + ";");
                        strSql.Append(" database=" + txtdatabase.Text.Trim() + ";");

                        result = strSql.ToString();
                    }
                }
                else if (ddlType.SelectedValue.ToString() == "Oracle 基本连接引擎")
                {

                    StringBuilder strSql = new StringBuilder();
                    strSql.Append("Data Source=" + txtConnection.Text.Trim() + ";");
                    strSql.Append(" User Id=" + txtuname.Text.Trim() + ";");
                    strSql.Append(" Password=" + txtpwd.Text.Trim() + ";");

                    result = strSql.ToString();

                }
            }
            return result;
        }

        private void BtnTest_Click(object sender, EventArgs e)
        {
            try
            {
                string ConnectionString = SetConn();

                DAL_ConfigConn conn = new DAL_ConfigConn();
                bool result = conn.TestConnectionString(ConnectionString);
                if (result)
                    lblTest.Text = "连接成功";
                else
                {
                    lblTest.Text = "连接失败";
                    if (ddlType.SelectedValue.ToString() == "Oracle 基本连接引擎")
                    {
                        lblTest.Text = "连接失败，【服务器名称】格式为：IP:端口/实例";
                    }
                }

            }
            catch (Exception ex)
            {
                lblTest.Text = ex.Message.ToString();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Configlist.Count > 0)
                {
                    configlest.AppSettings.Settings.Clear();
                    foreach (DDI.Common.MyItem item in Configlist)
                    {
                        if (item.Name == "ConnectionString")
                        {
                            string conn = DESEncrypt.Encrypt(SetConn());
                            configlest.AppSettings.Settings.Add(item.Name, conn);
                        }
                        else
                        {
                            configlest.AppSettings.Settings.Add(item.Name, item.Value);
                        }
                    }
                
                }
                //保存配置文件
                configlest.Save(ConfigurationSaveMode.Modified);

                ConfigurationManager.RefreshSection("appSettings");
                int len = configlest.AppSettings.Settings.AllKeys.Length;
                for (int i = 0; i < len; i++)
                {
                    string temp = configlest.AppSettings.Settings.AllKeys[i];
                    ConfigurationManager.AppSettings[temp] = configlest.AppSettings.Settings[temp].Value;
                }

                MessageBox.Show("保存成功", "系统提示！", MessageBoxButtons.OK, MessageBoxIcon.Information);



                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


    }
}
