using DDI.Common;
using DDIV.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDIWebApp.DDI
{
    public partial class SupDrugEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

            }
        }

        private void setcon()
        {
            txtDrugCode.Text = "";
            txtSupCode.Text = "";
            txtSupName.Text = "";
            txtddicode.Text = "";
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDrugCode.Text.Trim()))
            {
                txtDrugCode.Focus();
                showMessage("药品编码不能为空");
            }
            else if (string.IsNullOrEmpty(txtddicode.Text.Trim()))
            {
                txtddicode.Focus();
                showMessage("查询编码不能为空");
                return;
            }
            else
            {
                SupDrugDAl dal = new SupDrugDAl();
                ArrayList userinfo = (ArrayList)Session["user"];
                if (userinfo == null)
                {
                    string url = "window.top.location.href=\"../UsersLogin.aspx\";";
                    MessageBox.ResponseScript(this, url);
                }
                else
                {
                    //if (dal.exit(txtDrugCode.Text.Trim()) > 0)
                    //{
                    //    showMessage("当前药品已存在其他供应商");
                    //}


                    string result = dal.Add(txtDrugCode.Text.Trim(), txtSupCode.Text.Trim(), txtSupName.Text.Trim(), userinfo[1].ToString().Trim(), userinfo[3].ToString().Trim(), txtddicode.Text.Trim());
                    MessageBox.Show(this, result);
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