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
    public partial class UserMenu : System.Web.UI.Page
    {
        UserLogin ul = new UserLogin();
        DDIMenu ml = new DDIMenu();
        public DataTable dt;
        public DataTable dtfunc;
        public string authstr;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                TVList.Attributes.Add("onclick", "postBackByObject()");//添加点击事件  

                IninData();

            }
        }


        private void IninData()
        {

            gridviewtitle();


        }

        #region  菜单加载
        public void LoadBindData()
        {
            DataSet ds = ml.GetList("All", "", "");
            if (ds != null)
            {
                dt = ds.Tables[0];

            }
        }

       
        private void UserMenuBindData(string userid)
        {
            LoadBindData();
            authstr = ml.GetEmpFunctionStr(userid);
            Session["userid"] = userid;

            CreateTree(0, null, this.TVList);

        }


        //protected void RPT_Menu_First_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Repeater rep = e.Item.FindControl("RPT_Menu_Second") as Repeater;//找到里层的repeater对象

        //        DataRowView dr = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
        //        string menuid = dr["MenuId"].ToString().Trim(); //获取填充子类的id 

        //        rep.DataSource = GetMenuParentList(dt, menuid);
        //        rep.DataBind();
        //    }

        //}
        //protected void RPT_Menu_Second_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    {
        //        Repeater rep = e.Item.FindControl("RPT_Menu_Three") as Repeater;//找到里层的repeater对象
        //        DataRowView dr = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
        //        string menuid = dr["MenuId"].ToString().Trim(); //获取填充子类的id 

        //        rep.DataSource = GetMenuParentList(dt, menuid);
        //        rep.DataBind();
        //    }
        //}
        //private DataTable GetMenuList(DataTable dt, string level)
        //{
        //    DataTable result = dt.Clone();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (dr["Menulevel"].ToString().Trim() == level)
        //        {
        //            result.ImportRow(dr);
        //        }
        //    }
        //    return result;
        //}
        //public DataTable GetMenuParentList(DataTable dt, string parent)
        //{
        //    DataTable result = dt.Clone();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        if (dr["Parent"].ToString().Trim() == parent)
        //        {
        //            result.ImportRow(dr);
        //        }
        //    }
        //    return result;
        //}

        /// <summary>
        /// 设置菜单选中
        /// </summary>
        /// <param name="menuId"></param>
        /// <returns></returns>
        public string CheckedMenu(string menuId)
        {
            string str = menuId.Trim() + ",";
            if ((authstr + ",").IndexOf(str) > -1)
            {
                return "checked";
            }
            else
            {
                return "";
            }
        }

        DataView dv;
        public void CreateTree(int parentID, TreeNode node, TreeView treeView)
        {
            dv = new DataView(dt);


            foreach (DataRowView row in dv)
            {
                if (int.Parse(row["Parent"].ToString().Trim()) == parentID)
                {
                    TreeNode childNode = new TreeNode();
                    string id = row["MenuId"].ToString().Trim();
                    childNode.Text = row["MenuName"].ToString();
                    childNode.Value = id;
                    childNode.ShowCheckBox = true;

                    if ((authstr + ",").IndexOf(id + ",") > -1)
                    {

                        childNode.Checked = true;
                    }
                    else
                    {
                        childNode.Checked = false;
                    }

                    if (node == null)
                        TVList.Nodes.Add(childNode);
                    else
                        node.ChildNodes.Add(childNode);

                    CreateTree(int.Parse(id), childNode, treeView);
                }
            }

        }

        protected void TVList_TreeNodeCheckChanged(object sender, TreeNodeEventArgs e)
        {
            SetChildChecked(e.Node);
            TreeNode parentNode = e.Node.Parent;
            int checkcount = 0;
            if (parentNode != null)
            {
                foreach (TreeNode node in parentNode.ChildNodes)
                {
                    if (node.Checked == true)
                        checkcount++;
                }

                if (checkcount > 0)
                    e.Node.Parent.Checked = true;
                else
                    e.Node.Parent.Checked = false;
            
            }
        }

        private void SetNodecCheck()
        { 
            
        }


        private void SetChildChecked(TreeNode parentNode)
        {
            foreach (TreeNode node in parentNode.ChildNodes)
            {
                node.Checked = parentNode.Checked;

                if (node.ChildNodes.Count > 0)
                {
                    SetChildChecked(node);
                }
                
            }
        }



        protected void TVList_SelectedNodeChanged(object sender, EventArgs e)
        {
            TreeNode node = TVList.SelectedNode;
            if (node != null && node.Parent != null) //选中节点不为空,非父节点。  
            {
                //添加或移除项  
            }
            else    //点击的是复选框  
            {
                if (node.ChildNodes.Count > 0)   //选中的是父节点的框  
                {
                    SetChildChecked(node);    //复选框事件  
                }
                else        //选中的是子节点  
                {
                    //添加或移除项  
                }
            }

        }
        List<string> list = new List<string>();
        private void GetTreeView(TreeNodeCollection tc)
        {

           
            foreach (TreeNode TNode in tc)//循环遍历所有节点包括父节点
            {
                
                    if (TNode.Checked == true)
                    {
                        list.Add(TNode.Value.Trim());
                    }


                    GetTreeView(TNode.ChildNodes);//递归遍历
            }

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            GetTreeView(this.TVList.Nodes);
            int Id = Convert.ToInt32(Session["userid"]);

            int res = ml.SetUserMenulist(list, Id);
            if (res > 0)
            {
                MessageBox.Show(this, "授权成功");
            }
            else
                MessageBox.Show(this, "授权成功");
        }


        #endregion


        #region  左侧用户

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
                //string id = e.CommandSource.ToString().Trim(); ;

                string id = this.gridview.DataKeys[row]["Id"].ToString().Trim();

                this.TVList.Nodes.Clear();
                UserMenuBindData(id);



            }
        }



        #endregion

        






    }
}