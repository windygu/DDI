using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Text;
using DDIV.DAL;
using DDI.Common;

namespace Web.Main
{
    public partial class left : Page
    {
        public DataTable dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["menuid"] != null)
                {
                    string menuid = Request["menuid"].ToString().Trim();
                    BindMenu(menuid);
                }
            }
        }
        /// <summary>
        /// 绑定二级菜单
        /// </summary>
        /// <param name="menuid"></param>
        private void BindMenu(string menuid)
        {
            try
            {
                DDIMenu ml = new DDIMenu();
                ArrayList userinfo = (ArrayList)Session["user"];
                if (userinfo == null)
                {
                    string url = "window.top.location.href=\"UsersLogin.aspx\";";
                    MessageBox.ResponseScript(this, url);
                }
                else
                {
                    DataSet ds = ml.GetList("Left", "", userinfo[0].ToString().Trim());

                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        dt = ds.Tables[0];
                        RPT_Menu.DataSource = GetLeftMenuList(dt, menuid);
                        RPT_Menu.DataBind();
                    }
                }
            }
            catch( Exception e)
            { 
            
            }
        }
        /// <summary>
        /// 绑定三级菜单
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RPT_Menu_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater rep = e.Item.FindControl("RPT_ChildMenu") as Repeater;//找到里层的repeater对象

                DataRowView dr = (DataRowView)e.Item.DataItem;//找到分类Repeater关联的数据项 
                string pid = dr["MenuId"].ToString().Trim(); //获取填充子类的id 
                rep.DataSource = GetLeftMenuList(dt, pid);
                rep.DataBind();
            }
        }


        public DataTable GetLeftMenuList(DataTable dt, string parentid)
        {
            DataTable result = dt.Clone();
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["Parent"].ToString().Trim() == parentid)
                {
                    result.ImportRow(dr);
                }
            }
            return result;
        }

    }
}
