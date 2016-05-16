using DDI.Common;
using DDIV.DAL;
using Model;
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
    public partial class SupUsersRelationList : System.Web.UI.Page
    {
        UserLogin ul = new UserLogin();
        DalSupUsersRelation surdal = new DalSupUsersRelation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // TVList.Attributes.Add("onclick", "postBackByObject()");//添加点击事件  

                IninData();

            }
        }





        #region  左侧用户
        private void IninData()
        {
            gridviewtitle();
            gridview1title();
        }
        private string SearchstrWhere()
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" where Enabled=1 ");
            if (!string.IsNullOrEmpty(txtloginname.Text.Trim()))
            {
                strWhere.Append(" and LoginName like '%" + txtloginname.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(txtorgcode.Text.Trim()))
            {
                strWhere.Append(" and OrgCode like '%" + txtorgcode.Text.Trim() + "%'");
            }
            
            return strWhere.ToString();
        }
        public void BindData()
        {
            DataSet ds = new DataSet();
            string strWhere = SearchstrWhere();
            if (strWhere != "")
            {

                ds = ul.GetUsersList(strWhere);
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
        private void gridviewtitle()
        {
            DataTable tab = new DataTable();
            tab.Columns.Add("Id");
            tab.Columns.Add("LoginName");
            tab.Columns.Add("OrgCode");
            tab.Columns.Add("OrgName");
            tab.Rows.Add(tab.NewRow());

            gridview.DataSource = tab;
            gridview.DataBind();

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
                LinkButton lbtnUpdate = (LinkButton)e.Row.FindControl("lbtnUpdate");
                Label lblid = (Label)e.Row.FindControl("lblid");
                if (lblid.Text == "")
                {
                    lbtnUpdate.Visible = false;
                }
                else
                {
                    lbtnUpdate.Visible = true;
                }

            }

        }
        protected void gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "LBEdit")
            {
                int row = int.Parse(e.CommandArgument.ToString()) - 1;

                string id = this.gridview.DataKeys[row]["Id"].ToString().Trim();
                hfuserid.Value = id;
                BindData(id);
            }
        }



        #endregion





        #region  菜单加载
        DDI_Sup_Users supuser = new DDI_Sup_Users();
        private void gridview1title()
        {
            DataTable tab = new DataTable();
            tab.Columns.Add("supcode");
            tab.Columns.Add("supname");
            tab.Columns.Add("status");
            tab.Rows.Add(tab.NewRow());

            gridview1.DataSource = tab;
            gridview1.DataBind();

        }

        DataSet dsold = new DataSet();



        private string SearchWhere(string userid)
        {
            StringBuilder strWhere = new StringBuilder();
            strWhere.Append(" where u.CREATEMAN='" + userid + "' ");
            if (!string.IsNullOrEmpty(txtsupcode.Text.Trim()))
            {
                strWhere.Append(" and u.supcode like '%" + txtsupcode.Text.Trim() + "%'");
            }
            if (!string.IsNullOrEmpty(txtsupname.Text.Trim()))
            {
                strWhere.Append(" and u.supname like '%" + txtsupname.Text.Trim() + "%'");
            }

            strWhere.Append(" and rownum <=10 ");

            return strWhere.ToString();
        }

        public void BindData(string userid)
        {
            DataSet ds = new DataSet();


            string where = SearchWhere(userid);

            ds = supuser.GetList(where);


            if (ds.Tables[0].Rows.Count < 1)
            {
                gridview1title();
                MessageBox.Show(this, "没有数据！");

            }
            else
            {
                gridview1.DataSource = ds;
                gridview1.DataBind();
            }



        }

        protected void btnRightSerch_Click(object sender, EventArgs e)
        {
            string userid = hfuserid.Value;
            if (userid.Length <= 0)
            {
                MessageBox.Show(this, "请选择左侧用户数据库行,并点击【绑定供应商】！");
            }
            else
            {
                BindData(userid);
            }
        }

        protected void gridview1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //如果是绑定数据行
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                LinkButton lbtnEdit = (LinkButton)e.Row.FindControl("lbtnEdit");
                Label lblstatus = (Label)e.Row.FindControl("lblstatus");
                Label lblsupcode = (Label)e.Row.FindControl("lblsupcode");
                if (lblstatus.Text == "")
                {
                    lbtnEdit.Text = "绑定";
                }
                else
                {
                    lbtnEdit.Text = "解除绑定";
                }

                if (lblsupcode.Text == "")
                    lbtnEdit.Visible = false;
                else
                    lbtnEdit.Visible = true;
            }
        }

        protected void gridview1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {
                int row = int.Parse(e.CommandArgument.ToString()) - 1;

                string supcode = this.gridview1.DataKeys[row]["supcode"].ToString().Trim();
                string supname = this.gridview1.DataKeys[row]["supname"].ToString().Trim();
                string status = this.gridview1.DataKeys[row]["status"].ToString().Trim();
                string userid = hfuserid.Value;
                if (status == "")
                {
                    //绑定
                    Add(userid, supcode, supname);
                }
                else
                {
                    delete(userid, supcode);
                }


                
                    BindData(userid);
                
            }
        }


        public void Add(string userid, string supcode, string supname)
        {
            ArrayList userinfo = (ArrayList)Session["user"];
            SupUsersRelation model = new SupUsersRelation();
            model.SUPCODE = supcode;
            model.SUPNAEM = supname;
            model.USERID = Convert.ToInt32(userid);
            model.CREATEMAN = userinfo[0].ToString().Trim();
            model.CREATEDATE = DateTime.Now;

            string res = surdal.Add(model);

            MessageBox.Show(this, res);


        }
        public void delete(string userid, string supcode)
        {
            string res = surdal.delete(supcode, Convert.ToInt32(userid));

            MessageBox.Show(this, res);


        }
        #endregion

        











    }
}