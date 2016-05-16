using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Data;
using DDIV.DAL;
using System.Collections;
using DDI.Common;
using System.IO;

namespace DDIWebApp.DDI
{
    public partial class DdiExecuteLogList : System.Web.UI.Page
    {
        DAL_Execute bll = new DAL_Execute();
        string backurl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                gridviewtitle();

            }
            //backurl=GetUrl();
        }
        private void gridviewtitle()
        {
            DataTable tab = new DataTable();
            tab.Columns.Add("id");
            tab.Columns.Add("ConfigId");
            tab.Columns.Add("Status");
            tab.Columns.Add("BusinessName");
            tab.Columns.Add("PathName");
            tab.Columns.Add("BusinessExecuteDate");
            tab.Columns.Add("IsVoluntarily");
            tab.Columns.Add("IsMormal");
            tab.Columns.Add("OperateDateTime");
            tab.Columns.Add("OperateMan");
            tab.Columns.Add("BusinessEndDateTime");
            tab.Columns.Add("BackUrl");

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
            if (!string.IsNullOrEmpty(DropDownListIsVoluntarily.SelectedValue))
            {
                strWhere.Append(" and IsVoluntarily = '" + DropDownListIsVoluntarily.SelectedValue + "'");
            }
            if (!string.IsNullOrEmpty(DropDownListStatus.SelectedValue))
            {
                strWhere.Append(" and Status = '" + DropDownListStatus.SelectedValue + "'");
            }

            if (!string.IsNullOrEmpty(DropDownListIsMormal.SelectedValue))
            {
                if (DropDownListIsMormal.SelectedValue == "True")
                    strWhere.Append(" and IsMormal = 1 ");
                else
                    strWhere.Append(" and IsMormal = 0 ");
            }

            ArrayList userinfo = (ArrayList)Session["user"];
            if (userinfo == null)
            {
                string url = "window.top.location.href=\"UsersLogin.aspx\";";
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
                int begin = 0;
                int end = pageSize;
                if (pageIndex > 1)
                {
                    begin = (pageIndex - 1) * pageSize + 1;
                    end = pageIndex * pageSize;
                }

                ds = bll.GetList(strWhere, "", begin, end);
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

        protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton LBUrl = (LinkButton)e.Row.FindControl("LBUrl");
                Label lab = (Label)e.Row.FindControl("lab_Statusint");
                LinkButton lbtnDele = (LinkButton)e.Row.FindControl("lbtnDele");
                //HiddenField hfPathName = (HiddenField)e.Row.FindControl("hfPathName");
                if (lab.Text == "")
                {
                    lbtnDele.Visible = false;
                    LBUrl.Visible = false;
                }
                else
                {
                    if (lab.Text.Trim() == "1" || lab.Text.Trim() == "3")
                        lbtnDele.Text = "";
                    else
                        lbtnDele.Text = "手动生成文件";

                    // LBUrl.Text = backurl;
                }

            }
        }
        protected string GetUrl()
        {
            string backadd = bll.GetBackUrl();
            string backurl = backadd.Substring(0, backadd.Length - 2);
            return backurl;
        }
        protected void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Manual")
            {
                int row = int.Parse(e.CommandArgument.ToString()) - 1;
                Guid id = Guid.Parse(gridview.DataKeys[row]["id"].ToString().Trim());
                int configdi = int.Parse(gridview.DataKeys[row]["ConfigId"].ToString());
                ExportDataSetToExcel(configdi, id);
            }
        }
        protected void AspNetPager1_PageChanging(object src, Diy.Pager.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;//当前页码
            BindData();
        }
        private void ExportDataSetToExcel(int configdi, Guid id)
        {
            if (bll.ExecuteConfig(configdi, id))
            {
                BindData();
                MsgBox("成功");
             
            }
            else
                MsgBox("失败");
        }


       

        public string GetStatusStr(string status)
        {
            string result = "";
            switch (status.Trim())
            {
                case "1":
                    result = "自动执行正常";
                    break;
                case "2":
                    result = "自动执行异常";
                    break;
                case "3":
                    result = "手动执行正常";
                    break;
                case "4":
                    result = "手动执行异常";
                    break;
            }

            return result;
        }

        private void MsgBox(string sMessage)
        {
            string msg = "<script language=\"javascript\">";
            msg += "alert('" + sMessage + "');";
            msg += "</script>";
            Response.Write(msg);
        }
    }
}