using DDI.Common;
using DDIV.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDIWebApp.DDI
{
    public partial class SupUsersList : System.Web.UI.Page
    {
        DDI_Sup_Users dal = new DDI_Sup_Users();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridviewtitle();
            }
        }


        private void gridviewtitle()
        {
            DataTable tab = new DataTable(); ;
            tab.Columns.Add("IsEnabled");
            tab.Columns.Add("SupCode");
            tab.Columns.Add("SupName");
            tab.Columns.Add("CreateMan");
            tab.Columns.Add("CreateDate");

            tab.Rows.Add(tab.NewRow());

            gridview.DataSource = tab;
            gridview.DataBind();

        }

        private string SearchstrWhere()
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1  ");
            if (!string.IsNullOrEmpty(txtsupcode.Text.Trim()))
            {
                strWhere.Append(" and t.SupCode like '%" + txtsupcode.Text.Trim() + "%'");
            }

            if (!string.IsNullOrEmpty(txtsupname.Text.Trim()))
            {
                strWhere.Append(" and t.SupName like '%" + txtsupname.Text.Trim() + "%'");
            }
            if (checkstatus.Checked == true)
                strWhere.Append(" and t.IsEnabled = '禁用'");
            else
                strWhere.Append(" and t.IsEnabled = '启用'");

            ArrayList userinfo = (ArrayList)Session["user"];
            if (userinfo == null)
            {
                string url = "window.top.location.href=\"../UsersLogin.aspx\";";
                MessageBox.ResponseScript(this, url);
            }
            else
            {
                strWhere.Append(" and t.createman = '" + userinfo[0].ToString().Trim() + "'");
            }
            return strWhere.ToString();
        }
        public void BindData()
        {
            DataSet ds = new DataSet();
            string strWhere = SearchstrWhere();
            if (strWhere != "")
            {

                AspNetPager1.RecordCount = dal.GetCount(strWhere);
                int pageSize = 10;//当前页大小
                int pageIndex = AspNetPager1.CurrentPageIndex;//当前条数
                int begin = 0;
                int end = pageSize;
                if (pageIndex > 1)
                {
                    begin = (pageIndex - 1) * pageSize + 1;
                    end = pageIndex * pageSize;
                }

                ds = dal.GetList(strWhere, "", begin, end);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
                else
                    gridviewtitle();
            }
        }


        protected void btnSerch_Click(object sender, EventArgs e)
        {
            BindData();
        }

        protected void AspNetPager1_PageChanging(object src, Diy.Pager.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;//当前页码
            BindData();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtsupcode.Text.Trim()))
            {
                txtsupcode.Focus();
                MessageBox.Show(this, "供应商编码不能为空");
                return;
            }
            else if (string.IsNullOrEmpty(txtsupname.Text.Trim()))
            {
                txtsupname.Focus();
                MessageBox.Show(this, "供应商名称不能为空");
                return;
            }
            else
            {
                string isenabled = "";
                if (checkstatus.Checked == true)
                    isenabled = "禁用";
                else
                    isenabled = "启用";


                ArrayList userinfo = (ArrayList)Session["user"];
                if (userinfo == null)
                {
                    string url = "window.top.location.href=\"../UsersLogin.aspx\";";
                    MessageBox.ResponseScript(this, url);
                }
                else
                {
                    string res = dal.Add(txtsupcode.Text.Trim(), txtsupname.Text.Trim(), userinfo[0].ToString().Trim(), isenabled);
                    MessageBox.Show(this, res);
                }
            }
        }
    }
}