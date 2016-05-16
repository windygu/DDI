using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections.Generic;
using DDIV.DAL;
using DDI.Common;

namespace Web.Main
{
    public partial class top : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindMenu();
            }

        }

        /// <summary>
        /// 绑定一级菜单
        /// </summary>
        private void BindMenu()
        {
            ArrayList userinfo = (ArrayList)Session["user"];
            lbl_org.Text = userinfo[4].ToString().Trim();
            lbl_name.Text = "用户:" + userinfo[1].ToString().Trim();

            DDIMenu ml = new DDIMenu();

            DataSet ds = ml.GetList("Top","",userinfo[0].ToString().Trim());
            if (ds != null)
            {
                RPT_TopMenu.DataSource = ds.Tables[0];
                RPT_TopMenu.DataBind();
            }

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            string url = "window.top.location.href=\"UsersLogin.aspx\";";

            MessageBox.ResponseScript(this, url);
        }
    }
}
