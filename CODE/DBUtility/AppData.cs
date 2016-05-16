using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace Maticsoft.DBUtility
{
    public abstract class AppData
    {
        public AppData()
       { }

       public static string USER_ID
       {
           set { AppDomain.CurrentDomain.SetData("USER_ID", value); }
           get { return AppDomain.CurrentDomain.GetData("USER_ID") == null ? "" : AppDomain.CurrentDomain.GetData("USER_ID").ToString(); }
       }

       public static string LoginName
       {
           set { AppDomain.CurrentDomain.SetData("LoginName", value); }
           get { return AppDomain.CurrentDomain.GetData("LoginName") == null ? "" : AppDomain.CurrentDomain.GetData("LoginName").ToString(); }
       }
       public static string LoginPwd
       {
           set { AppDomain.CurrentDomain.SetData("LoginPwd", value); }
           get { return AppDomain.CurrentDomain.GetData("LoginPwd") == null ? "" : AppDomain.CurrentDomain.GetData("LoginPwd").ToString(); }
       }
       public static string OrgCode
       {
           set { AppDomain.CurrentDomain.SetData("OrgCode", value); }
           get { return AppDomain.CurrentDomain.GetData("OrgCode") == null ? "" : AppDomain.CurrentDomain.GetData("OrgCode").ToString(); }
       }
       public static string OrgCodeList
       {
           set { AppDomain.CurrentDomain.SetData("OrgCodeList", value); }
           get { return AppDomain.CurrentDomain.GetData("OrgCodeList") == null ? "" : AppDomain.CurrentDomain.GetData("OrgCodeList").ToString(); }
       }
       public static string OrgName
       {
           set { AppDomain.CurrentDomain.SetData("OrgName", value); }
           get { return AppDomain.CurrentDomain.GetData("OrgName") == null ? "" : AppDomain.CurrentDomain.GetData("OrgName").ToString(); }
       }
    }
}
