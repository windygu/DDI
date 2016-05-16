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
    public class DAL_FtpConfig
    {

        public int Add(FtpConfig model)
        {
            int resust = 0;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(" INSERT INTO DDI_FtpConfig (Configid,FtpUser,FtpPassWord,FtpUrl,FileUrl,Enabled)  VALUES (" + model.Configid + ",'" + model.FtpUser.Trim() + "', '" + model.FtpPassWord.Trim() + "','" + model.FtpUrl + "', '" + model.FileUrl + "','" + model.Enabled + "')");

            resust = DbHelperSQL.ExecuteSql(strSql.ToString());


            return resust;
        }
        public int Update(FtpConfig model)
        {
            int resust = 0;

            StringBuilder strSql = new StringBuilder();

            strSql.Append(" update  DDI_FtpConfig SET FtpUser='" + model.FtpUser + "',FtpPassWord='" + model.FtpPassWord + "',FtpUrl='" + model.FtpUrl + "',FileUrl='" + model.FileUrl + "',Enabled='" + model.Enabled + "'  where Configid=" + model.Configid);

            resust = DbHelperSQL.ExecuteSql(strSql.ToString());


            return resust;
        }






    }
}
