using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DDIV.DAL
{
    public class DDIMenu
    {

        public DataSet GetList(string type, string level, string userid)
        {
            string sql = "";
            if (type == "All")
            {
                sql = "SELECT * FROM dbo.DDI_Menu";
            }
            else if (type == "User")
            {
                sql = "SELECT u.UserId,M.MenuId,m.MenuName,m.menuaction,m.Menulevel,m.OrgCode,m.Parent,m.Type FROM DDI_UserMenu u LEFT JOIN dbo.DDI_Menu m ON u.menuid=m.MenuId WHERE u.UserId='" + userid + "'";
            }
            else if (type == "Top")
            {
                sql = "SELECT u.UserId,M.MenuId,m.MenuName,m.menuaction,m.Menulevel,m.OrgCode,m.Parent,m.Type FROM DDI_UserMenu u LEFT JOIN dbo.DDI_Menu m ON u.menuid=m.MenuId  where m.Type='Top' and u.UserId='" + userid + "'";
            }
            else if (type == "Left")
            {
                sql = "SELECT u.UserId,M.MenuId,m.MenuName,m.menuaction,m.Menulevel,m.OrgCode,m.Parent,m.Type FROM DDI_UserMenu u LEFT JOIN dbo.DDI_Menu m ON u.menuid=m.MenuId  where Type='Left' and  u.UserId='" + userid + "'";
            }

            return DbHelperSQL.Query(sql);
        }

        public string GetEmpFunctionStr(string userid)
        {
            string str = "";
            string sql = "SELECT u.UserId,M.MenuId,m.MenuName,m.menuaction,m.Menulevel,m.OrgCode,m.Parent,m.Type FROM DDI_UserMenu u LEFT JOIN dbo.DDI_Menu m ON u.menuid=m.MenuId WHERE u.UserId='" + userid + "'";
            DataSet ds = DbHelperSQL.Query(sql);
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    str += dr["MenuId"].ToString().Trim() + ",";
                }
            }



            return str;
        }

        public int SetUserMenulist(List<string> list, int userid)
        {
            int res = 0;
            List<string> sqllist = new List<string>();
            string sqldelete = "delete from DDI_UserMenu where UserId=" + userid;

            sqllist.Add(sqldelete);


            if (list.Count > 0)
            {
                foreach (string item in list)
                {
                    string sqlintter = "INSERT INTO DDI_UserMenu(UserId,MenuId) VALUES(" + userid + ",'" + item.Trim() + "')";

                    sqllist.Add(sqlintter);
                }
            }

            if (sqllist.Count > 0)
                res = DbHelperSQL.ExecuteSqlTran(sqllist);


            return res;
        }


    }
}
