using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;
using DDIV2.DAL;
using DDI.Common;
using System.Collections;
namespace DDIWebApp.DDI
{
    public partial class DdiConfigList : System.Web.UI.Page
    {
        DAL_Config bll = new DAL_Config();
        protected void Page_Load(object sender, EventArgs e)
        {
            string struri = Request.Url.AbsoluteUri;//完整的URL
            if (!Page.IsPostBack)
            {
                gridviewtitle();
            }
        }
        private void SetWhere()
        {
            ArrayList setwhere = new ArrayList();
            setwhere.Insert(0, TextBoxBusinessName.Text.ToString().Trim());
            setwhere.Insert(1, DropDownListFileType.SelectedValue.ToString().Trim());
            setwhere.Insert(2, DropDownListCycle.SelectedValue.ToString().Trim());

            Session["DdiConfigListSetWhere"] = setwhere;
        }
        private void GetWhere()
        {
            ArrayList setwhere = (ArrayList)Session["DdiConfigListSetWhere"];
            TextBoxBusinessName.Text = setwhere[0].ToString().Trim();
            DropDownListFileType.SelectedValue = setwhere[1].ToString().Trim();
            DropDownListCycle.SelectedValue = setwhere[2].ToString().Trim();

        }

        private void gridviewtitle()
        {
            DataTable tab = new DataTable();
            tab.Columns.Add("id");
            tab.Columns.Add("BusinessName");
            tab.Columns.Add("VoluntarilyTime");
            tab.Columns.Add("PathName");
            tab.Columns.Add("Cycle");
            tab.Columns.Add("BecomeValidateDate");
            tab.Columns.Add("LoseEfficacyDate");
            tab.Columns.Add("FileType");
            tab.Columns.Add("FileFormatName");
            tab.Columns.Add("ManualDownload");
            tab.Rows.Add(tab.NewRow());

            gridview.DataSource = tab;
            gridview.DataBind();

        }

        private string SearchstrWhere()
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" IsDeleted=0 ");
            if (!string.IsNullOrEmpty(TextBoxBusinessName.Text.Trim()))
            {
                strWhere.Append(" and BusinessName like '%" + TextBoxBusinessName.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(DropDownListFileType.SelectedValue))
            {
                strWhere.Append(" and FileType = " + DropDownListFileType.SelectedValue + "");
            }

            if (!string.IsNullOrEmpty(DropDownListCycle.SelectedValue))
            {
                strWhere.Append(" and Cycle = '" + DropDownListCycle.SelectedValue + "'");
            }


            ArrayList userinfo = (ArrayList)Session["user"];
            if (userinfo == null)
            {
                string url = "window.top.location.href=\"../UsersLogin.aspx\";";
                MessageBox.ResponseScript(this, url);
            }
            else
                strWhere.Append(" and OrgCode = '" + userinfo[3].ToString().Trim() + "'");

            return strWhere.ToString();
        }

        public void BindData()
        {


            DataSet ds = new DataSet();
            string strWhere = SearchstrWhere();
            if (strWhere != "")
            {

                AspNetPager1.RecordCount = bll.GetCount(strWhere);
                int pageSize = 10;//当前页大小
                int pageIndex = AspNetPager1.CurrentPageIndex;//当前条数


                ds = bll.GetList(pageSize, pageIndex, strWhere);
                if (ds.Tables[0].Rows.Count < 1)
                {
                    gridviewtitle();
                    MessageBox.Show(this, "没有数据！");

                }
                else
                {
                    gridview.DataSource = ds;
                    gridview.DataBind();
                }
            }
        }
        protected void btnSerch_Click(object sender, EventArgs e)
        {
            BindData();
            //SetWhere();
        }
        private string GetSelIDlist()
        {
            string idlist = "";
            bool BxsChkd = false;
            for (int i = 0; i < gridview.Rows.Count; i++)
            {
                CheckBox ChkBxItem = (CheckBox)gridview.Rows[i].FindControl("DeleteThis");
                if (ChkBxItem != null && ChkBxItem.Checked)
                {
                    BxsChkd = true;
                    if (gridview.DataKeys[i].Value != null)
                    {
                        idlist += gridview.DataKeys[i].Value.ToString() + ",";
                    }
                }
            }
            if (BxsChkd)
            {
                idlist = idlist.Substring(0, idlist.LastIndexOf(","));
            }
            return idlist;
        }

        protected void AspNetPager1_PageChanging(object src, Diy.Pager.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;//当前页码
            BindData();
        }

        protected void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {
                bll.Delete(id);
                BindData();
                MessageBox.Show(this, "删除成功");
            }

        }
        public string SubStr(string str)
        {

            string str1 = "";
            if (str != "")
            {
                if (str == "1")
                    str1 = "Excel97_2003";
                else if (str == "2")
                    str1 = "Excel2007";
                else if (str == "3")
                    str1 = "文本文件";
                else if (str == "4")
                    str1 = "csv";
            }
            return str1;
        }

        protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                #region
                HiddenField hforderno = (HiddenField)e.Row.FindControl("hfid");

                CheckBox cbItem = (CheckBox)e.Row.FindControl("DeleteThis");
                Panel opendialog = (Panel)e.Row.FindControl("panel");
                Panel opendialog1 = (Panel)e.Row.FindControl("panel1");
                HiddenField ManualDownload = (HiddenField)e.Row.FindControl("ManualDownload");
                if (hforderno.Value.Trim() == "")
                {
                    cbItem.Visible = false;
                    opendialog.Visible = false;
                    opendialog1.Visible = false;
                }
                if (ManualDownload.Value.Trim() == "1")
                {

                    opendialog1.Visible = false;
                }

                #endregion
            }
        }

        protected void gridview_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        public string setTimes(string strdate)
        {
            string result = "";
            if (strdate != "")
            {
                string str = Convert.ToDateTime(strdate).ToString("yyyy-MM-dd HH:mm:ss");
                result = str.Substring(11, 8);
            }
            return result;
        }
    }
}