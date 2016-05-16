using DDIV.DAL;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDIWebApp
{
    public partial class UsersLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }




        protected void ImgSubmit_Click(object sender, EventArgs e)
        {
            string checkCode = String.Empty;
            if (Request.Cookies["checkcode"] != null)
            {
                checkCode = Request.Cookies["checkcode"].Value.ToLower();
            }
            if (!checkCode.Equals(txtcheckcode.Text.ToLower()))
            {
                showMessage("验证码输入错误！");
                return;
            }

            DataSet ds = null;
            if (string.IsNullOrEmpty(txtname.Text.Trim()))
            {
                showMessage("请填写登录名称！");
                return;
            }
            else if (string.IsNullOrEmpty(txtpwd.Text.Trim()))
            {
                showMessage("请填写登录密码！");
                return;
            }

            try
            {
                UserLogin login = new UserLogin();

                Users user = login.GetModel(txtname.Text.Trim(), txtpwd.Text.Trim());
                if (user != null && user.Id > 0)
                {
                    ArrayList userInfo = new ArrayList();
                    userInfo.Insert(0, user.Id.ToString());
                    userInfo.Insert(1, user.LoginName.ToString());
                    userInfo.Insert(2, user.LoginPwd.ToString());
                    userInfo.Insert(3, user.OrgCode.ToString());
                    userInfo.Insert(4, user.OrgName.ToString());
                    userInfo.Insert(5, user.EmpName.ToString());

                    Session["user"] = userInfo;

                    Response.Redirect("Default.html", false);


                }
                else
                    showMessage("账号或密码不正确！");
            }
            catch (Exception ex)
            {

                showMessage(ex.Message);
            }
            

        }

        /// <summary>
        /// 注册前端js提示信息，并执行显示.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void showMessage(string msg)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(ImgSubmit, ImgSubmit.GetType(), "click", "alert('" + msg + "');", true);
        }
    }
}