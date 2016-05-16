
using DDIV.DAL;
using DDIV2.DAL;
using DDIV2.Model;
using Maticsoft.DBUtility;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using System.Windows.Forms;

namespace DDIV2.UI
{
    public partial class ExecuteOperation : Form
    {


        private ArrayList dtslist = new ArrayList();
        private List<Model.Config> listModel = new List<Config>();
        public ExecuteOperation()
        {
            InitializeComponent();

        }
        DAL.DAL_Config dalConfig = new DAL.DAL_Config();

        private void ExecuteOperation_Load(object sender, EventArgs e)
        {

            DataConfig config = new DataConfig();


            if (config.ConfigLoad() == false)
            {
                MessageBox.Show(this, "请在【配置信息】内设置【数据库连接配置】");
            }


            ControlVisible();

            this.btnStart.Visible = true;
            this.btnCancel.Visible = false;

        }
        private void ControlVisibles()
        {
            foreach (Control ctrl in this.Controls)
            {
                ctrl.Enabled = true;
            }
        }


        private void ControlVisible()
        {
            UserLogin uselogin = new UserLogin();
            string message;
            string result = uselogin.GetRegister(AppData.OrgCode.Trim(), out message);




            if (result == "1")
            {
                foreach (Control ctrl in this.Controls)
                {

                    if (ctrl is MenuStrip)
                    {
                        if (ctrl.Name == "MenuTop")
                        {
                            ctrl.Enabled = true;

                            foreach (ToolStripMenuItem item in MenuTop.Items)
                            {
                                if (item.Name == "Seting")
                                {
                                    item.Visible = true;
                                    foreach (ToolStripMenuItem dc in item.DropDownItems)
                                    {
                                        if (dc.Name == "Register")
                                            dc.Visible = true;
                                        else
                                            dc.Visible = false;
                                    }

                                }
                                else if (item.Name == "SysTSMI")
                                {
                                    if (AppData.LoginName == "hrddiadmin")
                                        item.Visible = true;
                                    else
                                        item.Visible = false;

                                }
                                else
                                    item.Visible = false;
                            }

                        }
                        else
                            ctrl.Enabled = false;
                    }
                    else
                        ctrl.Visible = false;

                }
            }
            else
            {
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is MenuStrip)
                    {
                        ctrl.Visible = true;
                        foreach (ToolStripMenuItem item in MenuTop.Items)
                        {
                            if (item.Name == "SysTSMI")
                            {
                                if (AppData.LoginName == "hrddiadmin")
                                    item.Visible = true;
                                else
                                    item.Visible = false;

                            }
                            else
                                item.Visible = true;
                        }
                    }
                    else
                        ctrl.Visible = true;
                }
            }
        }


        private DateTime olddt;
        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {

                if (CheckCB() == true)
                {

                    EventLoadData = 0;

                    ExecuteStatus = 0;

                    btnStart.Visible = false;
                    btnCancel.Visible = true;
                    olddt = DateTime.Now;
                    InvokeDGVClear();

                    if (cbtrundle.Checked == true)
                    {
                        DataLoad();
                    }
                    else if (cbThedate.Checked == true)
                    {
                        DataLoadold();
                    }

                    TimerLoadDataTick();
                    TimerLoadDataExecute();

                    DDI.Common.BusinessLog.WriteBusinessLog("开始执行作业\r\n方法：btnStart_Click 时间\r\n" + DateTime.Now.ToString(), "业务日志");
                }
            }
            catch (Exception ex)
            {

                DDI.Common.BusinessLog.WriteBusinessLog("作业执行失败\r\n方法：btnStart_Click 时间\r\n" + DateTime.Now.ToString() + "错误信息:\r\n" + ex.Message, "业务日志");
            }
        

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            EventLoadData = 3;
            ExecuteStatus = 1;
            btnCancel.Visible = false;
            btnStart.Visible = true;

            TimerLoadData.Stop();
        }


        #region 数据加载
        private static System.Timers.Timer TimerLoadData;

        public void TimerLoadDataTick()
        {
            TimerLoadData = new System.Timers.Timer(5000);
            TimerLoadData.Elapsed += new ElapsedEventHandler(OnTimedEventLoadData);
            TimerLoadData.Interval = 5000;
            TimerLoadData.Enabled = true;
            TimerLoadData.Start();

        }

        int EventLoadData;
        int dgvrowcout;
        int status = 0;
        private void OnTimedEventLoadData(object source, ElapsedEventArgs e)
        {
            if (this.dgv.Rows.Count < 1)
            {
                if (cbtrundle.Checked == true)
                {
                    DataLoad();
                }
                else if (cbThedate.Checked == true)
                {
                    DataLoadold();
                }

            }
        }

        public bool CheckCB()
        {
            bool res = true;
            if (cbtrundle.Checked == true && cbThedate.Checked == true)
            {
                MessageBox.Show("不能同时执行“既往数据”和 “当天数据”");

                res= false;
            }
            if (cbtrundle.Checked == false && cbThedate.Checked == false)
            {
                MessageBox.Show(" 请选择“既往数据”或 “当天数据”");

                res = false;
            }


            return res;
        }


        public void InvokeDGVClear()
        {
            InvokeReFreshDgv rf = new InvokeReFreshDgv(DGVClear);
            this.BeginInvoke(rf, new object[] { "0" });

        }
        public void DGVClear(string clear)
        {
            dgv.Rows.Clear();
        }




        public void DataLoad()
        {
            InvokeReFreshDgv rf = new InvokeReFreshDgv(GetConfigList);
            this.BeginInvoke(rf, new object[] { "0" });

        }
        public void DataLoadold()
        {
            InvokeReFreshDgv rf = new InvokeReFreshDgv(GetConfigList);
            this.BeginInvoke(rf, new object[] { "1" });

        }
        public void GetConfigList(string isSameDay)
        {
            try
            {
                string begtr = DateTime.Now.ToShortDateString();
                string dsstr = DateTime.Now.ToShortDateString();

                string begindt = begtr + " 00:00:00";
                string enddt = dsstr + " 23:59:59";


                DataTable dt = dalConfig.GetList(begindt, enddt, isSameDay, AppData.OrgCodeList).Tables[0];

                //dgv.DataSource = dt;
                dgvrowcout = dt.Rows.Count;
                AddDataRow(dt);



                dtslist.Clear();//清空对比数据记录
                listModel.Clear();
            }
            catch (Exception ex)
            {

                DDI.Common.BusinessLog.WriteBusinessLog("数据加载" + ex.Message, "业务日志");
            }
        }



        private string Id = string.Empty;
        private string stauts = string.Empty;
        private string ConfigType = string.Empty;
        private string FileType = string.Empty;
        private string BusinessName = string.Empty;
        private string BecomeValidateDate = string.Empty;
        private string NextVoluntarilyTime = string.Empty;
        private string PathName = string.Empty;
        private string Cycle = string.Empty;
        private string Remark = string.Empty;
        private string DateSql = string.Empty;
        private string LoseEfficacyDate = string.Empty;
        private string FileFormatName = string.Empty;
        private string VoluntarilyTime = string.Empty;
        private string IsHead = string.Empty;
        private string ServerType = string.Empty;
        private string OrgCode = string.Empty;


        public void AddDataRow(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    #region
                    if (dt.Rows[i]["编号"].ToString() != "")
                    {
                        Id = dt.Rows[i]["编号"].ToString().Trim();
                    }
                    if (dt.Rows[i]["线程状态"].ToString() != "")
                    {
                        stauts = dt.Rows[i]["线程状态"].ToString().Trim();
                    }
                    if (dt.Rows[i]["配置方式"].ToString() != "")
                    {
                        ConfigType = dt.Rows[i]["配置方式"].ToString().Trim();
                    }
                    if (dt.Rows[i]["文件格式"].ToString() != "")
                    {
                        FileType = dt.Rows[i]["文件格式"].ToString().Trim();
                    }
                    if (dt.Rows[i]["业务名称"].ToString() != "")
                    {
                        BusinessName = dt.Rows[i]["业务名称"].ToString().Trim();
                    }
                    if (dt.Rows[i]["首次执行日期"].ToString() != "")
                    {
                        BecomeValidateDate = dt.Rows[i]["首次执行日期"].ToString().Trim();
                    }
                    if (dt.Rows[i]["本次执行时间"].ToString() != "")
                    {
                        NextVoluntarilyTime = dt.Rows[i]["本次执行时间"].ToString().Trim();
                    }
                    if (dt.Rows[i]["文件路径"].ToString() != "")
                    {
                        PathName = dt.Rows[i]["文件路径"].ToString().Trim();
                    }
                    if (dt.Rows[i]["周期"].ToString() != "")
                    {
                        Cycle = dt.Rows[i]["周期"].ToString().Trim();
                    }
                    if (dt.Rows[i]["备注"].ToString() != "")
                    {
                        Remark = dt.Rows[i]["备注"].ToString().Trim();
                    }
                    if (dt.Rows[i]["数据集Sql"].ToString() != "")
                    {
                        DateSql = dt.Rows[i]["数据集Sql"].ToString().Trim();
                    }
                    if (dt.Rows[i]["失效日期"].ToString() != "")
                    {
                        LoseEfficacyDate = dt.Rows[i]["失效日期"].ToString().Trim();
                    }
                    if (dt.Rows[i]["格式化文件名称"].ToString() != "")
                    {
                        FileFormatName = dt.Rows[i]["格式化文件名称"].ToString().Trim();
                    }
                    if (dt.Rows[i]["执行时间"].ToString() != "")
                    {
                        VoluntarilyTime = dt.Rows[i]["执行时间"].ToString().Trim();
                    }
                    if (dt.Rows[i]["是否显示头部"].ToString() != "")
                    {
                        IsHead = dt.Rows[i]["是否显示头部"].ToString().Trim();
                    }
                    if (dt.Rows[i]["数据访问类型"].ToString() != "")
                    {
                        ServerType = dt.Rows[i]["数据访问类型"].ToString().Trim();
                    }
                    if (dt.Rows[i]["机构编码"].ToString() != "")
                    {
                        OrgCode = dt.Rows[i]["机构编码"].ToString().Trim();
                    }
                    #endregion

                    object[] str ={
                            Id,
                            stauts,
                            ConfigType,
                            FileType,
                            BusinessName,
                            BecomeValidateDate,
                            NextVoluntarilyTime,
                            PathName,
                            Cycle,
                            Remark,
                            DateSql,
                            LoseEfficacyDate,
                            FileFormatName,
                            VoluntarilyTime,
                            IsHead,
                            ServerType,
                            OrgCode
                            };


                    dgv.Rows.Add(str);

                }
            }

        }


        #endregion

        #region 工具条
        private void TSDataConfig_Click(object sender, EventArgs e)
        {
            DataConfig config = new DataConfig();
            config.Show();
        }
        /// <summary>
        /// 重采
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Heavy_Click(object sender, EventArgs e)
        {
            Heavy heavyfrom = new Heavy();
            heavyfrom.Show();
        }

        private void BusinessLog_Click(object sender, EventArgs e)
        {
            BusinessLog blog = new BusinessLog();
            blog.Show();
        }

        private void Register_Click(object sender, EventArgs e)
        {
            RegisterSesting from = new RegisterSesting();
            from.Show();
        }

        private void UserTSMI_Click(object sender, EventArgs e)
        {
            UsersEdit userfrom = new UsersEdit();
            userfrom.Show();
        }
        private void AuthorizeTSMI_Click(object sender, EventArgs e)
        {
            AuthorizeEdit authfrom = new AuthorizeEdit();
            authfrom.Show();
        }

        private void UserOrgtsmt_Click(object sender, EventArgs e)
        {
            OrgList authfrom = new OrgList();
            authfrom.Show();
        }
        private void fTPtsmt_Click(object sender, EventArgs e)
        {
            FtpEdit ftpEdit = new FtpEdit();
            ftpEdit.Show();
        }

        #endregion





        #region 执行数据

        DAL_Execute dal = new DAL_Execute();
        Model.Config model;

        private static System.Timers.Timer TimerExecute;

        public void TimerLoadDataExecute()
        {
            TimerExecute = new System.Timers.Timer(10000);
            TimerExecute.Elapsed += new ElapsedEventHandler(OnTimedEventExecute);
            TimerExecute.Interval = 10000;
            TimerExecute.Enabled = true;
            TimerExecute.Start();

        }
        private void OnTimedEventExecute(object source, ElapsedEventArgs e)
        {
            Execute();
        }


        int ExecuteStatus = 0;
        public void Execute()
        {
            #region   循环
            if (ExecuteStatus == 0)
            {
                if (dgv.Rows.Count > 0)
                {
                    for (int i = 0; i < dgv.Rows.Count; i++)
                    {
                        model = new Config();
                        model.Id = 0;
                        string date = dgv.Rows[i].Cells["本次执行时间"].Value.ToString().Trim();
                        int id = int.Parse(dgv.Rows[i].Cells["编号"].Value.ToString().Trim());
                        string statusrow = dgv.Rows[i].Cells["线程状态"].Value.ToString().Trim();
                        if (date != "" && !dtslist.Contains(id))
                        {
                            DateTime dt = Convert.ToDateTime(date);
                            if (DateTime.Now >= dt.AddSeconds(-10))
                            {
                                #region 组织实体对象



                                model.Id = id;
                                model.FileFormatName = dgv.Rows[i].Cells[12].Value.ToString().Trim();
                                model.DateSql = dgv.Rows[i].Cells["数据集Sql"].Value.ToString().Trim();
                                model.BecomeValidateDate = DateTime.Parse(dgv.Rows[i].Cells["首次执行日期"].Value.ToString().Trim());
                                model.BusinessName = dgv.Rows[i].Cells["业务名称"].Value.ToString().Trim();
                                model.ConfigType = Convert.ToInt32(dgv.Rows[i].Cells["配置方式"].Value.ToString().Trim() == "内置配置" ? "0" : "1");
                                model.Cycle = dgv.Rows[i].Cells["周期"].Value.ToString().Trim();
                                string type = dgv.Rows[i].Cells["文件格式"].Value.ToString().Trim();
                                int inttype = 2;
                                switch (type)
                                {
                                    case "Excel97_2003": inttype = 1; break;
                                    case "Excel2007": inttype = 2; break;
                                    case "文本文件": inttype = 3; break;
                                    case "csv": inttype = 4; break;

                                }
                                model.FileType = inttype;
                                model.LoseEfficacyDate = DateTime.Parse(dgv.Rows[i].Cells["失效日期"].Value.ToString().Trim());
                                model.NextVoluntarilyTime = DateTime.Parse(date);
                                model.PathName = dgv.Rows[i].Cells["文件路径"].Value.ToString().Trim();

                                model.IsHead = Convert.ToBoolean(dgv.Rows[i].Cells["是否显示头部"].Value.ToString().Trim());
                                model.ServerType = dgv.Rows[i].Cells["数据访问类型"].Value.ToString().Trim();

                                model.OrgCode = dgv.Rows[i].Cells["机构编码"].Value.ToString().Trim();

                                #endregion

                                listModel.Add(model);
                                dtslist.Add(model.Id);



                                break;

                            }

                        }

                    }

                    if (model.Id > 0)
                    {
                        ExecuteStatus = 1;
                        dal.ExecuteConfig(model, DateTime.Now);


                        InvokeReFreshDgv rf = new InvokeReFreshDgv(RemoveDgv);
                        this.BeginInvoke(rf, new object[] { model.Id.ToString().Trim() });



                        ExecuteStatus = 0;
                    }

                }
            }
            #endregion
        }
        public delegate void InvokeReFreshDgv(string str);
        public void RemoveDgv(string rid)
        {
            if (dgv.Rows.Count > 0)
            {
                string id = string.Empty;
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    id = dgv.Rows[i].Cells["编号"].Value.ToString().Trim();
                    if (rid == id)
                    {
                        DataGridViewRow row = dgv.Rows[i];
                        dgv.Rows.Remove(row);
                       
                    }
                    break;
                }
            }
        }
        public void RemoveAll(string count)
        {
            if (dgv.Rows.Count > 0)
            {
                string id = string.Empty;

                int counts = dgv.Rows.Count;

                for (int i = 0; i < counts; i++)
                {

                    int rowid = dgv.Rows.Count - 1;

                    DataGridViewRow row = dgv.Rows[rowid];
                    dgv.Rows.Remove(row);

                    break;
                }
            }
        }


        #endregion

        






    }
}
