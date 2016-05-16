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
    public partial class SupAndDrugRelation : System.Web.UI.Page
    {
        DalSupAndDrugRelation dal = new DalSupAndDrugRelation();
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
            tab.Columns.Add("USERID");
            tab.Columns.Add("SUPCODE");
            tab.Columns.Add("SUPNAME");
            tab.Columns.Add("GOODSCODE");
            tab.Columns.Add("GOODSNAME");
            tab.Columns.Add("GOODSSPEC");
            tab.Columns.Add("CREATEMAN");
            tab.Columns.Add("CREATEDATE");
            tab.Columns.Add("DELETEMAN");
            tab.Columns.Add("DELETEDATE");
            tab.Columns.Add("ISENABLED");

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
                strWhere.Append(" and t.SUPCODE like '%" + txtsupcode.Text.Trim() + "%'");
            }

            if (!string.IsNullOrEmpty(txtsupname.Text.Trim()))
            {
                strWhere.Append(" and t.SUPNAME like '%" + txtsupname.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(txtgoodcode.Text.Trim()))
            {
                strWhere.Append(" and t.GOODSCODE like '%" + txtgoodcode.Text.Trim() + "%'");
            }

            if (checkstatus.Checked == true)
                strWhere.Append(" and t.IsEnabled = '已禁用'");
            else
                strWhere.Append(" and t.IsEnabled = '已启用'");

            ArrayList userinfo = (ArrayList)Session["user"];
            if (userinfo == null)
            {
                string url = "window.top.location.href=\"../UsersLogin.aspx\";";
                MessageBox.ResponseScript(this, url);
            }
            else
            {
                strWhere.Append(" and t.createman = '" + userinfo[5].ToString().Trim() + "'");
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
            Response.Redirect("SupAndDrugRelationEdit.aspx", false);
        }

        protected void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ISENABLED")//禁用
            {
                int row = int.Parse(e.CommandArgument.ToString()) - 1;
                int userid = int.Parse(gridview.DataKeys[row]["USERID"].ToString().Trim());
                string supcode = gridview.DataKeys[row]["SUPCODE"].ToString().Trim();
                string durgcode = gridview.DataKeys[row]["GOODSCODE"].ToString().Trim();
                string ISENABLED = gridview.DataKeys[row]["ISENABLED"].ToString().Trim();
                string enabled = "";
                if (ISENABLED == "已启用")
                    enabled = "已禁用";
                else
                    enabled = "已启用";

                ArrayList userinfo = (ArrayList)Session["user"];
                if (userinfo == null)
                {
                    string url = "window.top.location.href=\"../UsersLogin.aspx\";";
                    MessageBox.ResponseScript(this, url);
                }
                else
                {

                    string empanem = userinfo[5].ToString().Trim();

                    string res = dal.delete(supcode, userid, durgcode, enabled, empanem);

                    BindData();
                    MessageBox.Show(this, res);
                }
            }
        }

        protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region
                Label lab_IsEnabled = (Label)e.Row.FindControl("lab_IsEnabled");
                LinkButton lbtnDele = (LinkButton)e.Row.FindControl("lbtnDele");
                Panel panel = (Panel)e.Row.FindControl("panel");

                Panel opendialog = (Panel)e.Row.FindControl("panel");
                if (lab_IsEnabled.Text == "")
                {
                    lbtnDele.Visible = false;
                    panel.Visible = false;

                }
                if (lab_IsEnabled.Text == "已启用")
                {
                    lbtnDele.Visible = true;
                    lbtnDele.Text = "禁用";
                }
                else if (lab_IsEnabled.Text == "已禁用")
                {
                    lbtnDele.Visible = true;
                    lbtnDele.Text = "启用";
                }

                #endregion
            }
        }
    }
}