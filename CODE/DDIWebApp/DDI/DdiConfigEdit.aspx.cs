using System;
using System.Data;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;


using DDIV2.Model;
using DDI.Common;
using DDIV2.DAL;
using DDIV.DAL;
using System.Collections;
using System.Text;

namespace huaruncms.Web.DDI
{
    public partial class DdiConfigEdit : ParentManage
    {
        private static List<ConfigFileFormatNameParm> listmodelParm;
        private static List<ConfigToSqlParameter> listmodel;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                listmodelParm = new List<ConfigFileFormatNameParm>();
                listmodel = new List<ConfigToSqlParameter>();
                if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
                {
                    HiddenFieldid.Value = Request.Params["id"];
                    LoadModelToPage(Convert.ToInt32(Request.Params["id"]));
                    HiddenFieldEdit.Value = "Edit";
                }
                else
                {
                    HiddenFieldEdit.Value = "Add";
                    gridview.DataSource = null;
                    gridview.DataBind();
                }


                lblVariable.Visible = false;
            }
        }
        private void LoadModelToPage(int id)
        {
            DAL_Config bll = new DAL_Config();
            Config model = bll.GetModel(id);
            if (model != null)
            {

                DataSet ds = bll.GetSqlModel(id);
                if (ds != null)
                {
                    listmodel.Clear();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ConfigToSqlParameter cp = new ConfigToSqlParameter();
                        if (listmodel != null)
                            cp.ParameterId = listmodel.Count + 1;
                        else
                            cp.ParameterId = 1;
                        cp.ParameterName = ds.Tables[0].Rows[i]["ParameterName"].ToString();
                        cp.ParameterType = ds.Tables[0].Rows[i]["ParameterType"].ToString();
                        cp.OrderBy = Convert.ToInt32(ds.Tables[0].Rows[i]["OrderBy"].ToString());
                        cp.Illustrate = ds.Tables[0].Rows[i]["Illustrate"].ToString();
                        listmodel.Add(cp);
                    }
                    gridview.DataSource = listmodel;
                    gridview.DataBind();
                    listmodelParm.Clear();
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        //不存在添加行记录
                        ConfigFileFormatNameParm ddifilename = new ConfigFileFormatNameParm();

                        ddifilename.Name = ds.Tables[1].Rows[i]["Name"].ToString();
                        ddifilename.VariableType = ds.Tables[1].Rows[i]["VariableType"].ToString();
                        ddifilename.DataSource = ds.Tables[1].Rows[i]["DataSource"].ToString();
                        ddifilename.Connector = ds.Tables[1].Rows[i]["Connector"].ToString();

                        listmodelParm.Add(ddifilename);
                    }

                    gridviewVariable.DataSource = listmodelParm;
                    gridviewVariable.DataBind();

                }

                DropDownListType.SelectedValue = model.ConfigType.ToString();
                DropDownListFileType.SelectedValue = model.FileType.ToString();
                TextBoxBusinessName.Text = model.BusinessName;
                txtVoluntarilyTime.Text = setTimes(model.VoluntarilyTime.ToString());
                TextBoxPathName.Text = model.PathName;
                DropDownListCycle.SelectedValue = model.Cycle;
                TextBoxFileFormatName.Text = model.FileFormatName;
                TextBoxRemark.Text = model.Remark;
                TextBoxSql.Value = model.DateSql;
                TextBoxValidateDate.Text = model.BecomeValidateDate.ToString("yyyy-MM-dd");
                TextBoxLoseEfficacyDate.Text = model.LoseEfficacyDate.ToString("yyyy-MM-dd");
                cbHead.Checked = model.IsHead;
                ServerTypeddl.SelectedValue = model.ServerType;

                if (model.ManualDownload == "1")
                    cbDownload.Checked = true;
                else
                    cbDownload.Checked = false;
            }

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSaveCheckSql()== "true")
            {

                if (Validate())
                {
                    #region
                    Config model = new Config();
                    model.ConfigType = Convert.ToInt32(DropDownListType.SelectedValue);
                    model.FileType = int.Parse(DropDownListFileType.SelectedValue);
                    model.BusinessName = TextBoxBusinessName.Text.Trim();
                    model.VoluntarilyTime = Convert.ToDateTime(txtVoluntarilyTime.Text.Trim());
                    model.PathName = TextBoxPathName.Text.Trim();
                    model.Cycle = DropDownListCycle.SelectedValue;
                    model.Prefix = "";//TextBoxPrefix.Text.Trim();
                    model.FileFormatName = TextBoxFileFormatName.Text.Trim();
                    model.Suffix = "";//TextBoxSuffix.Text.Trim();
                    model.Remark = TextBoxRemark.Text.Trim();
                    model.DateSql = TextBoxSql.Value;
                    model.IsDeleted = false;
                    model.BecomeValidateDate = Convert.ToDateTime(TextBoxValidateDate.Text.Trim());
                    model.LoseEfficacyDate = Convert.ToDateTime(TextBoxLoseEfficacyDate.Text.Trim());
                    model.IsHead = this.cbHead.Checked;

                    model.ServerType = ServerTypeddl.SelectedValue.Trim();
                    string strdt = model.BecomeValidateDate.ToString("yyyy-MM-dd") + " " + model.VoluntarilyTime.ToString("HH:mm:ss");
                    model.NextVoluntarilyTime = Convert.ToDateTime(strdt);

                    if (cbDownload.Checked == true)
                        model.ManualDownload = "1";
                    else
                        model.ManualDownload = "0";



                    ArrayList userinfo = (ArrayList)Session["user"];
                    if (userinfo == null)
                    {
                        string url = "window.top.location.href=\"../UsersLogin.aspx\";";
                        MessageBox.ResponseScript(this, url);
                    }
                    else
                    {
                        model.OrgCode = userinfo[3].ToString().Trim();
                    }
                    List<ConfigFileFormatNameParm> parm = new List<ConfigFileFormatNameParm>();
                    if (gridviewVariable.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in gridviewVariable.Rows)
                        {
                            ConfigFileFormatNameParm para = new ConfigFileFormatNameParm();
                            para.Name = row.Cells[2].Text.Trim();
                            para.VariableType = row.Cells[3].Text.Trim();
                            para.DataSource = row.Cells[4].Text.Trim();
                            para.Connector = row.Cells[5].Text.Trim();

                            parm.Add(para);

                        }
                    }
                    List<ConfigToSqlParameter> paramodel = new List<ConfigToSqlParameter>();
                    if (gridview.Rows.Count > 0)
                    {
                        foreach (GridViewRow row in gridview.Rows)
                        {
                            ConfigToSqlParameter para = new ConfigToSqlParameter();
                            para.ParameterType = row.Cells[3].Text.Trim();
                            para.ParameterName = row.Cells[2].Text.Trim();
                            para.OrderBy = Convert.ToInt32(row.Cells[1].Text.Trim());
                            para.Illustrate = row.Cells[4].Text.Trim();
                            paramodel.Add(para);

                        }
                    }



                    DAL_Config bll = new DAL_Config();
                    int result = 0;
                    if (HiddenFieldEdit.Value == "Add")
                    {
                        result = bll.Add(model, paramodel, parm);
                        if (result >= 0)
                        {
                            MessageBox.Show(this, "保存成功！");
                            Response.Redirect("DdiConfigList.aspx", true);
                        }
                        else if (result == -1)
                            MessageBox.Show(this, "业务名称不能重复！");
                    }
                    else if (HiddenFieldEdit.Value == "Edit")
                    {
                        model.Id = Convert.ToInt32(HiddenFieldid.Value);
                        result = bll.Update(model, paramodel, parm);
                        if (result == 0)
                        {
                            MessageBox.Show(this, "编辑成功！");
                            Response.Redirect("DdiConfigList.aspx", true);
                        }
                        else if (result == 2)
                            MessageBox.Show(this, "业务名称不能重复");
                    }

                    #endregion
                }
            }

        }

        protected void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("DdiConfigList.aspx");
        }

        private bool Validate()
        {
            string strErr = "";
            if (this.TextBoxBusinessName.Text.Trim().Length == 0)
            {
                strErr = "业务名称不能为空！";
            }
            else if (this.txtVoluntarilyTime.Text.Trim().Length == 0)
            {
                strErr = "执行时间不能为空！";
            }
            if (this.TextBoxPathName.Text.Length == 0)
            {
                strErr = "文件目标路径不能为空！";
            }
            else
            {
                string str = this.TextBoxPathName.Text.Trim();
                string strcheck = str.Substring(TextBoxPathName.Text.Trim().Length - 1, 1);
                if (strcheck != @"\")
                {
                    strErr = @"文件目标路径必需以 \ 结尾！";
                }
            }

            if (this.TextBoxValidateDate.Text.Length == 0)
            {
                strErr = "首次执行日期不能为空！";
            }
            else
            {
                if (HiddenFieldEdit.Value == "Add")
                {
                    DateTime dt = Convert.ToDateTime(TextBoxValidateDate.Text.Trim());
                    if (dt < DateTime.Now)
                    {
                        strErr = "首次执行日期不能小于当前日期！";
                    }
                }
            }
            if (this.TextBoxLoseEfficacyDate.Text.Length == 0)
            {
                strErr = "失效日期不能为空！";
            }
            else
            {
                DateTime dt = Convert.ToDateTime(TextBoxLoseEfficacyDate.Text.Trim());
                if (dt < DateTime.Now)
                {
                    strErr = "失效日期不能小于当前日期！";
                }
            }
            if (this.TextBoxLoseEfficacyDate.Text.Length != 0 && this.TextBoxValidateDate.Text.Length != 0)
            {
                DateTime dt = Convert.ToDateTime(TextBoxValidateDate.Text.Trim());
                DateTime dt1 = Convert.ToDateTime(TextBoxLoseEfficacyDate.Text.Trim());
                if (dt >= dt1)
                {
                    strErr = "首次执行日期不能大于等于失效日期！";
                }
            }

            //if (gridviewVariable.Rows.Count <= 0)
            //{
            //    strErr = "文件名称变量不可以为空请添加！";
            //}



            if (strErr != "")
            {
                MessageBox.Show(this, strErr);
                return false;
            }
            return true;
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(TextBoxSql.Value.Trim()))
            {
                TextBoxSql.Focus();
                MessageBox.Show(this, "文件数据Sql不能为空");
                return;
            }
            else if (string.IsNullOrEmpty(TextBoxParaName.Text.Trim()))
            {
                TextBoxParaName.Focus();
                MessageBox.Show(this, "参数名称不能为空");
                return;
            }
            else if (string.IsNullOrEmpty(TextBoxParaOrderBy.Text.Trim()))
            {
                TextBoxParaOrderBy.Focus();
                MessageBox.Show(this, "参数排序号不能为空");
                return;
            }
            else if (string.IsNullOrEmpty(DropDownListIllustrate.SelectedValue))
            {
                DropDownListIllustrate.Focus();
                MessageBox.Show(this, "参数值来源不能为空");
                return;
            }
            else if (TextBoxSql.Value.Trim().IndexOf((TextBoxParaName.Text.Trim())) < 0)
            {
                TextBoxParaName.Focus();
                MessageBox.Show(this, "文件数据Sql不包含参数名称!");
                return;
            }

            if (!string.IsNullOrEmpty(TextBoxParaName.Text.Trim()))
            {
                string forematname = TextBoxParaName.Text.Trim().Substring(0, 1);
                if (forematname != "@")
                {
                    TextBoxParaName.Focus();
                    MessageBox.Show(this, "参数名称必需以 @ 开头!");
                    return;
                }
            }


            AddRow();

        }
        #region gridview
        /// <summary>
        /// 给品种明细列表添加一条行记录，如果存在给出提示是否修改记录
        /// </summary>
        /// <param name="dgvRow"></param>
        public void AddRow()
        {
            ConfigToSqlParameter cp = listmodel.Find(c => c.ParameterName == TextBoxParaName.Text.Trim());
            if (cp != null)
            {
                listmodel.Remove(cp);
                cp.ParameterName = TextBoxParaName.Text.Trim();
                cp.ParameterType = DropDownListParaType.SelectedValue;
                cp.OrderBy = Convert.ToInt32(TextBoxParaOrderBy.Text.Trim());
                cp.Illustrate = DropDownListIllustrate.SelectedValue;
                listmodel.Add(cp);

                listmodel.Sort(new CompareTeacher());
            }
            else
            {
                //不存在添加行记录
                ConfigToSqlParameter model = new ConfigToSqlParameter();
                if (listmodel != null)
                    model.ParameterId = listmodel.Count + 1;
                else
                    model.ParameterId = 1;
                model.ParameterName = TextBoxParaName.Text.Trim();
                model.ParameterType = DropDownListParaType.SelectedValue;
                model.OrderBy = Convert.ToInt32(TextBoxParaOrderBy.Text.Trim());
                model.Illustrate = DropDownListIllustrate.SelectedValue;

                listmodel.Add(model);
                listmodel.Sort(new CompareTeacher());
            }
            TextBoxParaName.Text = "";
            TextBoxParaOrderBy.Text = "";
            gridview.DataSource = listmodel;
            gridview.DataBind();

        }

        public class CompareTeacher : IComparer<ConfigToSqlParameter>
        {
            public int Compare(ConfigToSqlParameter x, ConfigToSqlParameter y)
            {
                if (x.OrderBy > y.OrderBy)
                {
                    return 1;
                }
                else if (x.OrderBy < y.OrderBy)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
        }

        protected void gridview_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Delete")
            {
                ConfigToSqlParameter cp = listmodel.Find(c => c.OrderBy == id);
                if (cp != null)
                {
                    listmodel.Remove(cp);
                    MessageBox.Show(this, "删除成功");
                }
                else
                    MessageBox.Show(this, "删除失败");

                listmodel.Sort(new CompareTeacher());
                gridview.DataSource = listmodel;
                gridview.DataBind();
            }
            else if (e.CommandName == "Update")
            {
                ConfigToSqlParameter cp = listmodel.Find(c => c.OrderBy == id);

                TextBoxParaName.Text = cp.ParameterName;
                TextBoxParaOrderBy.Text = cp.OrderBy.ToString();
                DropDownListIllustrate.SelectedValue = cp.Illustrate;
                DropDownListParaType.SelectedValue = cp.ParameterType;
                TextBoxParaName.Focus();

                listmodel.Sort(new CompareTeacher());
                gridview.DataSource = listmodel;
                gridview.DataBind();
            }
        }



        protected void gridview_RowDeleting(object sender, System.Web.UI.WebControls.GridViewDeleteEventArgs e)
        {

        }

        protected void gridview_RowUpdating(object sender, System.Web.UI.WebControls.GridViewUpdateEventArgs e)
        {

        }
        #endregion

        #region gridviewVariable

        protected void btnVariable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TextBoxFileFormatName.Text.Trim()))
            {
                TextBoxFileFormatName.Focus();
                MessageBox.Show(this, "格式化文件名称不能为空");
                return;
            }
            if (string.IsNullOrEmpty(TxtFormatVariable.Text.Trim()))
            {
                TxtFormatVariable.Focus();
                MessageBox.Show(this, "格式化文件变量名称不能为空");
                return;
            }
            else
            {
                if (!TextBoxFileFormatName.Text.Trim().Contains(TxtFormatVariable.Text.Trim()))
                {
                    TxtFormatVariable.Focus();
                    MessageBox.Show(this, "格式化文件变量名称不存在");
                    return;
                }
            }

            string varstr = TxtFormatVariable.Text.Trim();
            int leg = TxtFormatVariable.Text.Length;
            foreach (GridViewRow row in gridviewVariable.Rows)
            {
                string rowtext = row.Cells[2].Text.Trim();
                if (varstr == rowtext)
                {
                    TxtFormatVariable.Focus();
                    MessageBox.Show(this, "已包含同名的格式化文件变量名称");
                    return;
                }
                else
                {
                    int rowleg = row.Cells[2].Text.Trim().Length;
                    if (leg >= rowleg)
                    {
                        TxtFormatVariable.Focus();
                        MessageBox.Show(this, "格式化文件变量名称遵循字符串长度递减规则");
                        return;
                    }
                }
            }
            AddRowGridviewVariable();

            lblVariable.Visible = true;

        }

        public void AddRowGridviewVariable()
        {
            ConfigFileFormatNameParm parm = listmodelParm.Find(c => c.Name == TxtFormatVariable.Text.Trim());
            if (parm != null)
            {
                listmodelParm.Remove(parm);
                parm.Name = TxtFormatVariable.Text.Trim();
                parm.VariableType = DropDownListVariable.SelectedValue;
                parm.DataSource = DropDownListDataSource.SelectedValue;
                parm.Connector = DropDownListConnector.SelectedValue;
                listmodelParm.Add(parm);

            }
            else
            {
                //不存在添加行记录
                ConfigFileFormatNameParm model = new ConfigFileFormatNameParm();

                model.Name = TxtFormatVariable.Text.Trim();
                model.VariableType = DropDownListVariable.SelectedValue;
                model.DataSource = DropDownListDataSource.SelectedValue;
                model.Connector = DropDownListConnector.SelectedValue;

                listmodelParm.Add(model);
            }
            TxtFormatVariable.Text = "";
            gridviewVariable.DataSource = listmodelParm;
            gridviewVariable.DataBind();

        }



        protected void gridviewVariable_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();
            if (e.CommandName == "Delete")
            {
                ConfigFileFormatNameParm cp = listmodelParm.Find(c => c.Name == id);
                if (cp != null)
                {
                    listmodelParm.Remove(cp);
                    if (listmodelParm.Count <= 0)
                        lblVariable.Visible = false;
                    MessageBox.Show(this, "删除成功");
                }
                else
                    MessageBox.Show(this, "删除失败");


                TxtFormatVariable.Text = "";
                gridviewVariable.DataSource = listmodelParm;
                gridviewVariable.DataBind();
            }
            //else if (e.CommandName == "Update")
            //{
            //    huaruncms.Model.DdiConfigFileFormatNameParm cp = listmodelParm.Find(c => c.Name == id);
            //    TxtFormatVariable.Text = cp.Name;
            //    DropDownListVariable.SelectedValue = cp.VariableType;
            //    DropDownListDataSource.SelectedValue = cp.DataSource;
            //    DropDownListConnector.SelectedValue = cp.Connector;
            //    TxtFormatVariable.Focus();

            //    gridviewVariable.DataSource = listmodelParm;
            //    gridviewVariable.DataBind();
            //}
        }
        protected void gridviewVariable_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }

        protected void gridviewVariable_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void btnCheckout_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtVoluntarilyTime.Text.Trim()))
            {
                txtVoluntarilyTime.Focus();
                MessageBox.Show(this, "执行时间不能为空");
                return;
            }
            else if (string.IsNullOrEmpty(TextBoxValidateDate.Text.Trim()))
            {
                TextBoxValidateDate.Focus();
                MessageBox.Show(this, "首次执行日期不能为空");
                return;
            }
            else if (string.IsNullOrEmpty(TextBoxFileFormatName.Text.Trim()))
            {
                TextBoxFileFormatName.Focus();
                MessageBox.Show(this, "格式化文件名称不能为空");
                return;
            }
            //else if (gridviewVariable.Rows.Count <= 0)
            //{
            //    TxtFormatVariable.Focus();
            //    MessageBox.Show(this, "请添加格式名称变量！");
            //    return;
            //}
            else
            {
                Config model = new Config();
                string voltime = TextBoxValidateDate.Text.Trim() + " " + txtVoluntarilyTime.Text.Trim();
                model.VoluntarilyTime = Convert.ToDateTime(voltime);
                model.FileFormatName = TextBoxFileFormatName.Text.Trim();
                model.BecomeValidateDate = Convert.ToDateTime(TextBoxValidateDate.Text.Trim());
                model.NextVoluntarilyTime = DateTime.Now;


                List<ConfigFileFormatNameParm> parm = new List<ConfigFileFormatNameParm>();

                foreach (GridViewRow row in gridviewVariable.Rows)
                {
                    ConfigFileFormatNameParm para = new ConfigFileFormatNameParm();
                    para.Name = row.Cells[2].Text.Trim();
                    para.VariableType = row.Cells[3].Text.Trim();
                    para.DataSource = row.Cells[4].Text.Trim();
                    para.Connector = row.Cells[5].Text.Trim();

                    parm.Add(para);

                }
                DAL_Execute bll = new DAL_Execute();
                txtCheckFileName.Text = bll.GetFileFormatName(parm, model);
            }

        }

        #endregion
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

        protected void btnCheckSql_Click(object sender, EventArgs e)
        {
            //if (ServerTypeddl.SelectedValue == "Oracle")
            //{
            string res = CheckSql();
            MessageBox.Show(this, res);
            //}
        }

        private string CheckSql()
        {
            string res = "";
            DAL_Config bll = new DAL_Config();

            if (this.TextBoxSql.Value.Length == 0)
            {
                return "[文件数据Sql]不能为空！";
            }
            string sql = TextBoxSql.Value.Trim();
            List<ConfigToSqlParameter> paramodel = new List<ConfigToSqlParameter>();
            if (gridview.Rows.Count > 0)
            {
                foreach (GridViewRow row in gridview.Rows)
                {
                    ConfigToSqlParameter para = new ConfigToSqlParameter();
                    para.ParameterType = row.Cells[3].Text.Trim();
                    para.ParameterName = row.Cells[2].Text.Trim();
                    para.OrderBy = Convert.ToInt32(row.Cells[1].Text.Trim());
                    para.Illustrate = row.Cells[4].Text.Trim();
                    paramodel.Add(para);

                }
            }

            ArrayList userinfo = (ArrayList)Session["user"];
            if (userinfo == null)
            {
                string url = "window.top.location.href=\"../UsersLogin.aspx\";";
                MessageBox.ResponseScript(this, url);
            }
            else
            {
                string result = "";
                try
                {

                    DataSet ds = bll.CheckConfigSql(sql, paramodel, ServerTypeddl.SelectedValue.ToString(), userinfo[3].ToString().ToLower().Trim(), out result);

                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                StreamExport(ds.Tables[0], null, "测试文件", this);
                            }
                            //else
                            //{
                            //    res = "ex";
                            //    MessageBox.Show(this, "不存在条件内的数据！");
                            //}
                        }
                        else
                        {
                            res = "ex";
                            MessageBox.Show(this, "查询语句错误请确认后再次操作:" + result);
                        }
                    }


                }
                catch (Exception ex)
                {
                    res = "ex";
                    MessageBox.Show(this, result + ":  " + ex.Message.ToString());
                }



            }

            return res;
        }

        private string btnSaveCheckSql()
        {
            string res = "";
            DAL_Config bll = new DAL_Config();

            if (this.TextBoxSql.Value.Length == 0)
            {
                MessageBox.Show(this, "[文件数据Sql]不能为空！");
                res = "false";
                return res;
            }
            string sql = TextBoxSql.Value.Trim();
            List<ConfigToSqlParameter> paramodel = new List<ConfigToSqlParameter>();
            if (gridview.Rows.Count > 0)
            {
                foreach (GridViewRow row in gridview.Rows)
                {
                    ConfigToSqlParameter para = new ConfigToSqlParameter();
                    para.ParameterType = row.Cells[3].Text.Trim();
                    para.ParameterName = row.Cells[2].Text.Trim();
                    para.OrderBy = Convert.ToInt32(row.Cells[1].Text.Trim());
                    para.Illustrate = row.Cells[4].Text.Trim();
                    paramodel.Add(para);

                }
            }

            ArrayList userinfo = (ArrayList)Session["user"];
            if (userinfo == null)
            {
                string url = "window.top.location.href=\"../UsersLogin.aspx\";";
                MessageBox.ResponseScript(this, url);
            }
            else
            {
                string result = "";
                try
                {

                    DataSet ds = bll.CheckConfigSql(sql, paramodel, ServerTypeddl.SelectedValue.ToString(), userinfo[3].ToString().ToLower().Trim(), out result);

                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            res = "true";
                        }
                        else
                        {
                            res = "false";
                            MessageBox.Show(this, "查询语句错误请确认后再次操作:" + result);
                        }
                    }
                }
                catch (Exception ex)
                {
                    res = "false";
                    MessageBox.Show(this, result + ":  " + ex.Message.ToString());
                }

            }

            return res;
        }


        public bool StreamExport(DataTable dt, string[] columns, string fileName, System.Web.UI.Page pages)
        {
            if (dt.Rows.Count > 65535) //总行数大于Excel的行数 
            {
                throw new Exception("预导出的数据总行数大于excel的行数");
            }
            if (string.IsNullOrEmpty(fileName)) return false;

            StringBuilder content = new StringBuilder();
            StringBuilder strtitle = new StringBuilder();
            content.Append("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://www.w3.org/TR/REC-html40'>");
            content.Append("<head><title></title><meta http-equiv='Content-Type' content=\"text/html; charset=utf-8\">");
            //注意：[if gte mso 9]到[endif]之间的代码，用于显示Excel的网格线，若不想显示Excel的网格线，可以去掉此代码
            //content.Append("<!--[if gte mso 9]>");
            //content.Append("<xml>");
            //content.Append(" <x:ExcelWorkbook>");
            //content.Append("  <x:ExcelWorksheets>");
            //content.Append("   <x:ExcelWorksheet>");
            //content.Append("    <x:Name>Sheet1</x:Name>");
            //content.Append("    <x:WorksheetOptions>");
            //content.Append("      <x:Print>");
            //content.Append("       <x:ValidPrinterInfo />");
            //content.Append("      </x:Print>");
            //content.Append("    </x:WorksheetOptions>");
            //content.Append("   </x:ExcelWorksheet>");
            //content.Append("  </x:ExcelWorksheets>");
            //content.Append("</x:ExcelWorkbook>");
            //content.Append("</xml>");
            //content.Append("<![endif]-->");
            content.Append("</head><body><table style='border-collapse:collapse;table-layout:fixed;'><tr>");

            if (columns != null)
            {
                for (int i = 0; i < columns.Length; i++)
                {
                    if (columns[i] != null && columns[i] != "")
                    {
                        content.Append("<td><b>" + columns[i] + "</b></td>");
                    }
                    else
                    {
                        content.Append("<td><b>" + dt.Columns[i].ColumnName + "</b></td>");
                    }
                }
            }
            else
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    content.Append("<td><b>" + dt.Columns[j].ColumnName + "</b></td>");
                }
            }
            content.Append("</tr>\n");

            for (int j = 0; j < dt.Rows.Count; j++)
            {
                content.Append("<tr>");
                for (int k = 0; k < dt.Columns.Count; k++)
                {
                    object obj = dt.Rows[j][k];
                    Type type = obj.GetType();
                    if (type.Name == "Int32" || type.Name == "Single" || type.Name == "Double" || type.Name == "Decimal")
                    {
                        double d = obj == DBNull.Value ? 0.0d : Convert.ToDouble(obj);
                        if (type.Name == "Int32" || (d - Math.Truncate(d) == 0))
                            content.AppendFormat("<td style='vnd.ms-excel.numberformat:#,##0'>{0}</td>", obj);
                        else
                            content.AppendFormat("<td style='vnd.ms-excel.numberformat:#,##0.00'>{0}</td>", obj);
                    }
                    else
                        content.AppendFormat("<td style='vnd.ms-excel.numberformat:@'>{0}</td>", obj);
                }
                content.Append("</tr>\n");
            }
            content.Append("</table></body></html>");
            content.Replace("&nbsp;", "");

            pages.Response.Clear();
            pages.Response.Buffer = false;
            pages.Response.ContentType = "application/ms-excel";  //"application/ms-excel";
            fileName = System.Web.HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8);
            pages.Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName + ".xls");
            pages.Response.Write(content.ToString());
            pages.Response.End();  //注意，若使用此代码结束响应可能会出现“由于代码已经过优化或者本机框架位于调用堆栈之上,无法计算表达式的值。”的异常。
            //HttpContext.Current.ApplicationInstance.CompleteRequest(); //用此行代码代替上一行代码，则不会出现上面所说的异常。
            return true;
        }
    }
}