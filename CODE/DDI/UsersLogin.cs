using DDIV.DAL;
using Maticsoft.DBUtility;
using Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DDIV2.UI
{
    public partial class UsersLogin : Form
    {
        public UsersLogin()
        {
            InitializeComponent();
        }

        private void UsersLogin_Load(object sender, EventArgs e)
        {
            Bitmap img = (Bitmap)this.BackgroundImage;
            GraphicsPath grapth = GetNoneTransparentRegion(img, 100);
            this.Region = new Region(grapth);


        }
        public static GraphicsPath GetNoneTransparentRegion(Bitmap img, byte alpha)
        {
            int height = img.Height;
            int width = img.Width;

            int xStart, xEnd;
            GraphicsPath grpPath = new GraphicsPath();
            for (int y = 0; y < height; y++)
            {
                //逐行扫描；
                for (int x = 0; x < width; x++)
                {
                    //略过连续透明的部分；
                    while (x < width && img.GetPixel(x, y).A <= alpha)
                    {
                        x++;
                    }
                    //不透明部分；
                    xStart = x;
                    while (x < width && img.GetPixel(x, y).A > alpha)
                    {
                        x++;
                    }
                    xEnd = x;
                    if (img.GetPixel(x - 1, y).A > alpha)
                    {
                        grpPath.AddRectangle(new Rectangle(xStart, y, xEnd - xStart, 1));
                    }
                }
            }
            return grpPath;
        }





        private void btnlogin_Click(object sender, EventArgs e)
        {
            CheckLogin();

            this.DialogResult = DialogResult.OK;
        }

        public void CheckLogin()
        {
            if (this.txtloginname.Text.Length == 0)
            {
                MessageBox.Show(this, "账号不可以为空！");

            }
            else if (this.txtpwd.Text.Length == 0)
            {
                MessageBox.Show(this, "密码不可以为空！");

            }
            else
            {
                UserLogin login = new UserLogin();

                Users user = login.GetModel(txtloginname.Text.Trim(), txtpwd.Text.Trim());
                if (user != null && user.Id > 0)
                {
                    AppData.USER_ID = user.Id.ToString();
                    AppData.LoginName = user.LoginName.ToString();
                    AppData.LoginPwd = user.LoginPwd.ToString();
                    AppData.OrgName = user.OrgName.ToString();
                    txtorgname.Text = user.OrgName.ToString();

                    AppData.OrgCode = user.OrgCode.ToString();


                    DataSet ds = login.GetUserOrgCodeList(AppData.LoginName.ToString().Trim());
                    string strorgcode = "";
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (strorgcode == "")
                                strorgcode = "'" + ds.Tables[0].Rows[i]["orgcode"].ToString() + "'";
                            else
                                strorgcode += ",'" + ds.Tables[0].Rows[i]["orgcode"].ToString() + "'";
                        }
                    }
                    if (strorgcode != "")
                        AppData.OrgCodeList = strorgcode + ",'" + user.OrgCode.ToString() + "'";
                    else
                        AppData.OrgCodeList = "'" + user.OrgCode.ToString() + "'";





                    
                    btnlogin.Visible = true;
                }
                else
                    MessageBox.Show(this, "账号或密码不正确！");
            }
        }

        private void PIC_Close_Click(object sender, EventArgs e)
        {
            this.Close();

            Application.Exit(null);
        }

        private void txtpwd_Leave(object sender, EventArgs e)
        {
            CheckLogin();
        }

        private void UsersLogin_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)13)
            {
                this.SelectNextControl(this.ActiveControl, true, true, true, true);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DataConfig config = new DataConfig();
            config.Show();
        }
    }
}
