using DDI.Common;
using DDIV.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DDIWebApp.DDI
{
    public partial class SupAndDrugRelationEdit : System.Web.UI.Page
    {
        DalSupAndDrugRelation dal = new DalSupAndDrugRelation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.Params["userid"] != null && Request.Params["userid"].Trim() != "")
                {
                    hfEdit.Value = "Edit";
                    hfoldsupcod.Value = Request.Params["supcode"];
                    hfolddurgcode.Value = Request.Params["durgcode"];
                    hfoldUserid.Value = Request.Params["userid"];
                    Update();
                }
            }
        }

        private void setcon()
        {
            txtDrugCode.Text = "";
            txtSupCode.Text = "";
            txtSupName.Text = "";
            txtDrugName.Text = "";
            txtSpec.Text = "";
            checkstatus.Checked = false;
        }

        private void Update()
        {
            Model.SupAndDrugRelation sadr = dal.GetMoudel(hfoldUserid.Value.ToString(),hfoldsupcod.Value.ToString(),hfolddurgcode.Value.ToString());
            if (sadr != null)
            {
                txtDrugCode.Text = sadr.GoodsCode;
                txtDrugName.Text = sadr.GoodsName;
                txtSpec.Text = sadr.GoodsSpec;
                txtSupCode.Text = sadr.SupCode;
                txtSupName.Text = sadr.SupName;
                if (sadr.IsEnabled =="已删除")
                    checkstatus.Checked = true;
                else if (sadr.IsEnabled == "正常")
                    checkstatus.Checked = false;
            }


        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDrugCode.Text.Trim()))
            {
                txtDrugCode.Focus();
                showMessage("药品编码不能为空");
            }
            else if (string.IsNullOrEmpty(txtSupCode.Text.Trim()))
            {
                txtSupCode.Focus();
                showMessage("供应商编码不能为空");
                return;
            }
            else if (string.IsNullOrEmpty(txtSupName.Text.Trim()))
            {
                txtSupName.Focus();
                showMessage("供应商名称不能为空");
                return;
            }
            else if (string.IsNullOrEmpty(txtDrugName.Text.Trim()))
            {
                txtDrugName.Focus();
                showMessage("药品名称不能为空");
                return;
            }
            else if (string.IsNullOrEmpty(txtSpec.Text.Trim()))
            {
                txtSpec.Focus();
                showMessage("药品规格不能为空");
                return;
            }
            else
            {
                
                ArrayList userinfo = (ArrayList)Session["user"];
                if (userinfo == null)
                {
                    string url = "window.top.location.href=\"../UsersLogin.aspx\";";
                    MessageBox.ResponseScript(this, url);
                }
                else
                {
                    Model.SupAndDrugRelation item = new Model.SupAndDrugRelation();
                    item.SupCode = txtSupCode.Text.Trim();
                    item.SupName = txtSupName.Text.Trim();
                    item.GoodsCode = txtDrugCode.Text.Trim();
                    item.GoodsName = txtDrugName.Text.Trim();
                    item.GoodsSpec = txtSpec.Text.Trim();
                    if (checkstatus.Checked == true)
                        item.IsEnabled = "已禁用";
                    else
                        item.IsEnabled = "已启用";

                    item.CreateMan = userinfo[5].ToString();
                    item.CreateDate = DateTime.Now;
                    item.DeleteMan = "";
                    item.UserId = int.Parse(userinfo[0].ToString().Trim());

                    if (hfEdit.Value == "Edit")
                    {
                        string result = dal.Update(item,hfoldUserid.Value, hfoldsupcod.Value, hfolddurgcode.Value);
                        MessageBox.Show(this, result);
                    }
                    else
                    {
                        string result = dal.Add(item);
                        MessageBox.Show(this, result);
                    }
                    setcon();
                }

            }
        }

        /// <summary>
        /// 注册前端js提示信息，并执行显示.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        public void showMessage(string msg)
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(btnSave, btnSave.GetType(), "click", "alert('" + msg + "');", true);
        }
    }
}