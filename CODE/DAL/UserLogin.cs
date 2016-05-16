using Maticsoft.DBUtility;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Management;
using System.Text;

namespace DDIV.DAL
{
    public class UserLogin
    {
        public Users GetModel(string loginname, string loginpwd)
        {

            Users model = new Users();
            try
            {
                string sql = "select Id,LoginName,LoginPwd,OrgCode,OrgName,Enabled,EmpName from DDI_Users where Enabled='1' and LoginName='" + loginname + "' and LoginPwd='" + loginpwd + "'";

                DataSet ds = DbHelperSQL.Query(sql);



                #region
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["Id"] != null && ds.Tables[0].Rows[0]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["LoginName"] != null && ds.Tables[0].Rows[0]["LoginName"].ToString() != "")
                    {
                        model.LoginName = ds.Tables[0].Rows[0]["LoginName"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["LoginPwd"] != null && ds.Tables[0].Rows[0]["LoginPwd"].ToString() != "")
                    {
                        model.LoginPwd = ds.Tables[0].Rows[0]["LoginPwd"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["OrgCode"] != null && ds.Tables[0].Rows[0]["OrgCode"].ToString() != "")
                    {
                        model.OrgCode = ds.Tables[0].Rows[0]["OrgCode"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["OrgName"] != null && ds.Tables[0].Rows[0]["OrgName"].ToString() != "")
                    {
                        model.OrgName = ds.Tables[0].Rows[0]["OrgName"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["Enabled"] != null && ds.Tables[0].Rows[0]["Enabled"].ToString() != "")
                    {
                        model.Enabled = ds.Tables[0].Rows[0]["Enabled"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["EmpName"] != null && ds.Tables[0].Rows[0]["EmpName"].ToString() != "")
                    {
                        model.EmpName = ds.Tables[0].Rows[0]["EmpName"].ToString();
                    }
                }
                #endregion

                return model;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public int Add(Users model)
        {
            int resust = 0;
            int id = DbHelperSQL.GetMaxID("Id", "DDI_Users");

            StringBuilder strSql = new StringBuilder();

            strSql.Append(" INSERT INTO DDI_Users (Id,LoginName,LoginPwd,OrgCode,OrgName,Enabled)  VALUES (" + id.ToString() + ",'" + model.LoginName.Trim() + "', '" + model.LoginPwd.Trim() + "','" + model.OrgCode + "', '" + model.OrgName + "','" + model.Enabled + "')");

            resust = DbHelperSQL.ExecuteSql(strSql.ToString());


            return resust;
        }


        public int UpdatePwd(string name, string newpwd, string orgcode)
        {
            string sql = "update DDI_Users set LoginPwd='" + newpwd + "' where LoginName='" + name + "' and  OrgCode='" + orgcode + "'";

            return DbHelperSQL.ExecuteSql(sql);

        }






        private string GetNetCardMacAddress()
        {
            ManagementClass mc;
            ManagementObjectCollection moc;
            mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            moc = mc.GetInstances();
            string str = "";
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                    str = mo["MacAddress"].ToString();
            }
            return str;
        }
        public string Register(string Userinfo, string orgcode, string orgname)
        {
            string result = "";
            string register = Guid.NewGuid().ToString();
            string mac = GetNetCardMacAddress();
            string RegisterDate = DateTime.Now.ToString();
            string ValidityDate = DateTime.Now.AddYears(1).ToString();

            string sql = "INSERT INTO DDI_Register(Register,Mac,RegisterDate,ValidityDate,IsEnabled,Userinfo,OrgCode,OrgName) VALUES('" + register + "','" + mac + "','" + RegisterDate + "','" + ValidityDate + "','0','" + Userinfo + "','" + orgcode + "','" + orgname + "')";

            int row = DbHelperSQL.ExecuteRegister(sql);
            if (row > 0)
                result = register;


            return result;
        }
        public string GetRegister(string orgcode, out string message)
        {
            string result = "1";
            string mes = "";
            string mac = GetNetCardMacAddress();
            DateTime date = DateTime.Now;

            string sql = "select * from  DDI_Register WHERE IsEnabled=1 AND OrgCode='" + orgcode + "' and Mac='" + mac + "'";



            DataSet ds = DbHelperSQL.Register(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Register"] != null && ds.Tables[0].Rows[0]["Register"].ToString() != "")
                {
                    result = ds.Tables[0].Rows[0]["Register"].ToString();
                    mes = "序列号生效";
                }

                if (ds.Tables[0].Rows[0]["ValidityDate"] != null && ds.Tables[0].Rows[0]["ValidityDate"].ToString() != "")
                {
                    DateTime dt = Convert.ToDateTime(ds.Tables[0].Rows[0]["ValidityDate"].ToString());
                    if (date > dt)
                    {
                        result = "0";
                        mes = "当前序号已经过期,请联系管理员";
                    }

                }


            }
            else
            {
                mes = "当前所属机构未注册序列号,或管理员未进行授权";
                result = "0";
            }

            message = mes;

            return result;
        }

        public DataSet GetRegisterList(string strwhere)
        {
            string sql = "SELECT Register 序列号,Mac 注册地址,RegisterDate 注册时间,ValidityDate 有效期,IsEnabled 状态,Userinfo 描述,OrgCode 机构编码,OrgName 机构名称 FROM DDI_Register  " + strwhere;

            return DbHelperSQL.QueryRegister(sql);
        }

        public int SetAuthorize(string register, string isenabled)
        {
            int result = 0;
            string sql = "update DDI_Register set IsEnabled='" + isenabled + "'   where Register='" + register + "'";

            int row = DbHelperSQL.ExecuteRegister(sql);
            if (row > 0)
                result = 1;
            else
                result = 0;

            return result;
        }


        public bool CheckedUserOrgCodeList(string username, string orgcode)
        {
            string sql = "select count(*) from  UserOrgCodeList where loginname='" + username + "' and orgcode='" + orgcode + "'";

            object obj = DbHelperSQL.GetSingle(sql);
            if (obj == null)
            {
                return true;
            }
            else
            {
                if (Convert.ToInt32(obj) > 0)
                    return false;
                else
                    return true;
            }


        }
        public int AddUserOrgCodeList(string username, string orgcode)
        {
            if (CheckedUserOrgCodeList(username, orgcode))
            {
                int resust = 0;

                StringBuilder strSql = new StringBuilder();

                strSql.Append(" INSERT INTO UserOrgCodeList([loginname],[orgcode]) VALUES ('" + username + "','" + orgcode + "')");

                resust = DbHelperSQL.ExecuteSql(strSql.ToString());


                return resust;
            }
            else
                return -1;
        }

        public DataSet GetUserOrgCodeList(string username)
        {
            string sql = "select orgcode from  UserOrgCodeList where loginname='" + username + "'";

            return DbHelperSQL.Query(sql);


        }


        public DataSet GetUsersList(string where)
        {
            string sql = "SELECT top 10 Id,LoginName,OrgCode, OrgName FROM dbo.DDI_Users " + where + "";

            return DbHelperSQL.Query(sql);
        }

    }
}
