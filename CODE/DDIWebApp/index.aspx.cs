using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDIWebApp
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("DDI/DdiConfigList.aspx", true);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("DDI/DdiConfigEdit.aspx", true);
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Redirect("DDI/DdiExecuteLogList.aspx", true);
        }
    }
}