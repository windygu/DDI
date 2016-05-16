using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DDIV.DAL;
using DDI.Common;
using System.IO;
using System.Text;

namespace DDIWebApp.DDI
{
    public partial class HeavyMiningExecuteConfig : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                string id = Request.Params["id"];
                hfid.Value = id;

            }
        }

        private void InitData()
        {

        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            DateTime dt = Convert.ToDateTime(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd") + " 00:00:00");
        
            if (hfid.Value == "")
            {
                MessageBox.ShowAndRedirect(this, "选择需要重采的数据行", "DdiConfigList.aspx");
                return;
            }
            if (this.txtywdate.Text.Length == 0)
            {
                MessageBox.Show(this, "请选择‘重采业务时间’！");
                return;
            }
            else
            {
                if (Convert.ToDateTime(txtywdate.Text.Trim()) >= dt)
                {
                    MessageBox.Show(this, "重采业务时间不能大于等于今天");
                    return;
                }
            }
            if (this.txtczdate.Text.Length == 0)
            {
                MessageBox.Show(this, "请选择‘重采操作时间’！");
                return;
            }
            else
            {
                if (Convert.ToDateTime(txtywdate.Text.Trim()) >= dt)
                {
                    MessageBox.Show(this, "重采操作时间不能大于等于今天");
                    return;
                }
            }


            DAL_Execute bllel = new DAL_Execute();

            DateTime ywdate = Convert.ToDateTime(txtywdate.Text.Trim());
            DateTime czdate = Convert.ToDateTime(txtczdate.Text.Trim());
            int configid = Convert.ToInt32(hfid.Value.Trim());
            bool CbisDownload = this.CbisDownload.Checked;

            string pathname = "";

            bool result = bllel.ExecuteConfig(configid, ywdate, czdate, out pathname);
            if (result)
            {
                MessageBox.ShowAndRedirect(this, "重采成功", "DdiConfigList.aspx");
                if (this.CbisDownload.Checked == true && pathname != "")
                {
                    FileDownLoad(pathname);
                }
            }
            else
                MessageBox.Show(this, "重采失败");
        }
        private void FileDownLoad(string path)
        {
            string sFilePath = path;
            string filename = System.IO.Path.GetFileName(sFilePath);
            if (sFilePath.Length <= 0)
            {
                MessageBox.Show(this, "模版文件不存在，请与管理员联系！" + sFilePath);

            }
            else
            {
                Response.Clear();
                Response.ClearHeaders();
                Response.Buffer = false;
                Response.ContentType = "application/octet-stream";
                //Response.ContentEncoding=System.Text.Encoding.GetEncoding("utf-8");
                Response.AddHeader("Content-Disposition", "attachment; filename=" + System.Web.HttpUtility.UrlEncode(filename, Encoding.UTF8));
                Response.WriteFile(sFilePath);
                Response.Flush();
                Response.End();
            }
        }
        protected void btnc_Click(object sender, EventArgs e)
        {

            MessageBox.ShowAndRedirect(this, "取消", "DdiConfigList.aspx");
        }
    }
}