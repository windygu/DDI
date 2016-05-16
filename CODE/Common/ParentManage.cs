using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DDI.Common
{
    public class ParentManage : System.Web.UI.Page
    {
        /// <summary>
		/// 构造函数
		/// </summary>
        public ParentManage()
		{
           this.Load += new EventHandler(BasePage_Load);  
		}
       
        protected void BasePage_Load(object sender, EventArgs e)
        {
            //Check();
        }  
        public void Check()
        {
            if (Session["user"] == null && Session["UserInfo"] == null)
            {
                //Page.RegisterClientScriptBlock("key", "<script type='text/javascript'>alert('您还没有登陆，请您先登录。');parent.location='/login.aspx';</script>");
                this.Response.Write("<script type='text/javascript'>alert('您还没有登陆，请您先登录。');window.top.location='/index.aspx';</script>"); 
                this.Response.End();
            }
        }

        public void CheckCookies()
        {
            if (Request.Cookies["user"] == null)
            {
                //MessageBox.ShowAndRedirect(this, "您还没有登陆，请您先登录。","/index.aspx");
                Page.RegisterClientScriptBlock("key", "<script type='text/javascript'>alert('您还没有登陆，请您先登录。');window.location='/index.aspx';</script>");
           
            }
            else
            { 
             string username = Request.Cookies["user"].Value;
             if (string.IsNullOrEmpty(username))
             {
                 //MessageBox.ShowAndRedirect(this, "您还没有登陆，请您先登录。","/index.aspx");
                 Page.RegisterClientScriptBlock("key", "<script type='text/javascript'>alert('您还没有登陆，请您先登录。');window.location='/index.aspx';</script>");
           
             }
            }
        }

    }
}
