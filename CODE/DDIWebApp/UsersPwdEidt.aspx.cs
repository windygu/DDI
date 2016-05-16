using DDI.Common;
using DDIV.DAL;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDIWebApp
{
    public partial class UsersPwdEidt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ArrayList userinfo = (ArrayList)Session["user"];
                if (userinfo == null)
                {
                    string url = "window.top.location.href=\"UsersLogin.aspx\";";
                    MessageBox.ResponseScript(this, url);
                }
                else
                {
                    txtloginname.Text = userinfo[1].ToString().Trim();
                    txtloginname.ReadOnly = true;
                }

            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtloginpwd.Text.Trim()))
            {
                txtloginpwd.Focus();
                showMessage("原密码不能为空");
            }
            else if (string.IsNullOrEmpty(txtnewpwd.Text.Trim()))
            {
                txtnewpwd.Focus();
                showMessage("新密码不能为空");
                return;
            }
            else if (string.IsNullOrEmpty(txtnewpwd1.Text.Trim()))
            {
                txtnewpwd1.Focus();
                showMessage("确认密码不能为空");
                return;
            }
            else  
            {
                if (txtnewpwd.Text.Trim() == txtnewpwd1.Text.Trim())
                {
                    UserLogin login = new UserLogin();
                    ArrayList userinfo = (ArrayList)Session["user"];


                    string orgcode = userinfo[3].ToString().Trim();
                    Users user = login.GetModel(txtloginname.Text.Trim(), txtloginpwd.Text.Trim());
                    if (user == null)
                    {
                        showMessage("原始密码错误");
                    }
                    else
                    {
                        int result = login.UpdatePwd(txtloginname.Text.Trim(), txtnewpwd.Text.Trim(), orgcode);
                        if (result > 0)
                        {
                            showMessage("密码修改成功");
                            string url = "window.top.location.href=\"UsersLogin.aspx\";";
                            MessageBox.ResponseScript(this, url);
                        }
                        else
                            showMessage("密码修改失败");
                    }

                }
                else
                {
                    showMessage("新密码两次输入不一致！");
                }
            }
        }

        /// <summary>
        /// 注册前端js提示信息，并执行显示.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void showMessage(string msg)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "click", "alert('" + msg + "');", true);
        }
    }

}
