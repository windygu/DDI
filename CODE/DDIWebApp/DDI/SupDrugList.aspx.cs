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
    public partial class SupDrugList : System.Web.UI.Page
    {
        SupDrugDAl dal = new SupDrugDAl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridviewtitle();
            }
        }


        private void gridviewtitle()
        {
            DataTable tab = new DataTable();;
            tab.Columns.Add("IsEnabled");
            tab.Columns.Add("SupCode");
            tab.Columns.Add("SupName");
            tab.Columns.Add("DrugCode");
            tab.Columns.Add("OrgCode");
            tab.Columns.Add("DdiCode");
            tab.Columns.Add("CreateMan");
            tab.Columns.Add("CreateDate");
            tab.Columns.Add("FORBIDDENMAN");
            tab.Columns.Add("ForbiddenDate");

            tab.Rows.Add(tab.NewRow());

            gridview.DataSource = tab;
            gridview.DataBind();

        }

        private string SearchstrWhere()
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" 1=1  ");
            if (!string.IsNullOrEmpty(txtdrugcode.Text.Trim()))
            {
                strWhere.Append(" and t.DrugCode like '%" + txtdrugcode.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(txtsupcode.Text.Trim()))
            {
                strWhere.Append(" and t.SupCode like '%" + txtsupcode.Text.Trim() + "%'");
            }

            if (!string.IsNullOrEmpty(txtsupname.Text.Trim()))
            {
                strWhere.Append(" and t.SupName like '%" + txtsupname.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(txtddicode.Text.Trim()))
            {
                strWhere.Append(" and t.ddicode like '%" + txtddicode.Text.Trim() + "%'");
            }
            

            if (checkstatus.Checked==true)
                strWhere.Append(" and t.IsEnabled = '1'");
            else
                strWhere.Append(" and t.IsEnabled = '0'");

             ArrayList userinfo = (ArrayList)Session["user"];
             if (userinfo == null)
             {
                 string url = "window.top.location.href=\"../UsersLogin.aspx\";";
                 MessageBox.ResponseScript(this, url);
             }
             else
             {
                 strWhere.Append(" and t.orgcode = '" + userinfo[3].ToString().Trim() + "'");
             }
            return strWhere.ToString();
        }
        public void BindData()
        {
            DataSet ds = new DataSet();
            string strWhere = SearchstrWhere();
            if (strWhere != "")
            {

                AspNetPager1.RecordCount =  dal.GetCount(strWhere);
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

        public string GetStatusStr(string status)
        {
            string result = "";
            switch (status.Trim())
            {
                case "0":
                    result = "已启用";
                    break;
                case "1":
                    result = "已禁用";
                    break;
            }

            return result;
        }


        public string GetdateTimeStr(string date)
        {
            string result = "";
            if (date.Trim()=="")
            {
                    result = "";
            }
           else 
            {
                DateTime dt = Convert.ToDateTime(date.Trim());
                result = dt.ToString("yyyy-MM-dd HH:mm:ss");
            }

            return result;
        }
        

        protected void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")//禁用
            {
                int row = int.Parse(e.CommandArgument.ToString()) - 1;
                string  drugcode = gridview.DataKeys[row]["DrugCode"].ToString().Trim();
                string ddicode = gridview.DataKeys[row]["DdiCode"].ToString().Trim();
                string orgcode = gridview.DataKeys[row]["OrgCode"].ToString().Trim();
                Update("1", drugcode, ddicode,orgcode);
            }
            else if (e.CommandName == "Stars")//启用
            {
                int row = int.Parse(e.CommandArgument.ToString()) - 1;
                string drugcode = gridview.DataKeys[row]["DrugCode"].ToString().Trim();
                string ddicode = gridview.DataKeys[row]["DdiCode"].ToString().Trim();
                string orgcode = gridview.DataKeys[row]["OrgCode"].ToString().Trim();
                Update("0", drugcode, ddicode, orgcode);
            }

        }

        protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lab = (Label)e.Row.FindControl("lab_IsEnabled");
                LinkButton lbtnDele = (LinkButton)e.Row.FindControl("lbtnDele");
                LinkButton lbtnStars = (LinkButton)e.Row.FindControl("lbtnStars");

                if (lab.Text == "")
                {
                    lbtnDele.Visible = false;
                }
                else if (lab.Text == "0")//启用
                {
                    lbtnDele.Text = "禁用";
                    lbtnDele.Visible = true;

                    lbtnStars.Visible = false;
                }
                else
                {
                    lbtnStars.Text = "启用";
                    lbtnStars.Visible = true;
                    lbtnDele.Visible = false;
                }

            }
        }

        protected void AspNetPager1_PageChanging(object src, Diy.Pager.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;//当前页码
            BindData();
        }

        private void Update(string isen,string durgcode,string ddicode,string orgcode)
        {
            ArrayList userinfo = (ArrayList)Session["user"];
            if (userinfo == null)
            {
                string url = "window.SupDrugList.location.href=\"UsersLogin.aspx\";";
                MessageBox.ResponseScript(this, url);
            }
            else
            {
                
            string  man = userinfo[1].ToString().Trim();
            if (isen == "0")
            {
                int res = dal.Update(isen, durgcode, ddicode, man, orgcode);
                if (res > 0)
                {
                    BindData();
                    MessageBox.Show(this, "启用成功");
                }
                else
                    MessageBox.Show(this, "启用失败");
            }
            else if (isen == "1")
            {
                int res = dal.Update(isen, durgcode, ddicode, man, orgcode);
                if (res > 0)
                {
                    BindData();
                    MessageBox.Show(this, "禁用成功");
                }
                else
                    MessageBox.Show(this, "禁用失败"); 
            }
            }
        }

        protected void gridview_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}