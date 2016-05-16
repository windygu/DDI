using Base.DBUtil;
using Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DDIV.DAL
{
    public class DalSupUsersRelation
    {

        public string ConnName = "OracleConnString";
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(t.SUPCODE) FROM SupUsersRelation t ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            using (DbHelperOra _ora = new DbHelperOra(ConnName))
            {
                object obj = _ora.GetSingle(strSql.ToString());
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }


            // object obj = DbHelperSQL.GetSupSingle(strSql.ToString());

        }

        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" SELECT ROWNUM AS rowno,t.USERID,t.SUPCODE,t.SUPNAEM,t.CREATEMAN,t.CREATEDATE FROM SupUsersRelation t  WHERE  ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(strWhere);
            }
            strSql.Append("  order by t.SUPCODE ");


            using (DbHelperOra _ora = new DbHelperOra(ConnName))
            {
                return _ora.Query(strSql.ToString());
            }


        }
        public DataSet GetUserSupUsersRelationList(string userid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT ROWNUM AS rowno,t.USERID,t.SUPCODE,t.SUPNAEM  FROM SupUsersRelation t  WHERE t.USERID=" + userid);

            using (DbHelperOra _ora = new DbHelperOra(ConnName))
            {
                return _ora.Query(strSql.ToString());
            }
        }
        public int exit(string SupCode)
        {
            string strSql = "SELECT COUNT(SupCode) FROM  SupUsers WHERE SupCode='" + SupCode + "'";
            using (DbHelperOra _ora = new DbHelperOra(ConnName))
            {
                object obj = _ora.GetSingle(strSql.ToString());
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }
            }

        }

        public string Add(List<SupUsersRelation> list, int userid)
        {
            string datetime = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            List<string> sqllist = new List<string>();
            foreach (SupUsersRelation item in list)
            {
                string sql = "INSERT INTO SUPUSERSRELATION (USERID,SUPCODE,SUPNAEM,CREATEMAN,CREATEDATE) VALUES (" + item.USERID + ",'" + item.SUPCODE + "','" + item.SUPNAEM + "','" + item.CREATEMAN + "',TO_DATE('" + datetime + "','yyyy-MM-dd HH24:MI:SS'))";

                sqllist.Add(sql);
            }
            if (sqllist.Count > 0)
            {
                using (DbHelperOra _ora = new DbHelperOra(ConnName))
                {
                    bool result = _ora.ExecuteSqlTran(sqllist);
                    if (result == true)
                    {
                        return "添加成功";
                    }
                    else
                        return "添加失败";
                }
            }
            else
                return "没有选择供应商信息";

        }
        public string Add(SupUsersRelation item)
        {
            string datetime = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");

            string sql = "INSERT INTO SUPUSERSRELATION (USERID,SUPCODE,SUPNAEM,CREATEMAN,CREATEDATE) VALUES (" + item.USERID + ",'" + item.SUPCODE + "','" + item.SUPNAEM + "','" + item.CREATEMAN + "',TO_DATE('" + datetime + "','yyyy-MM-dd HH24:MI:SS'))";



            using (DbHelperOra _ora = new DbHelperOra(ConnName))
            {
                int result = _ora.ExecuteSql(sql);
                if (result > 0)
                {
                    return "操作成功";
                }
                else
                    return "操作失败";
            }


        }
        public string delete(string supcode, int userid)
        {
            string datetime = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");

            string sql = "delete from  SUPUSERSRELATION where userid="+userid+" and supcode='" + supcode + "'";



            using (DbHelperOra _ora = new DbHelperOra(ConnName))
            {
                int result = _ora.ExecuteSql(sql);
                if (result > 0)
                {
                    return "操作成功";
                }
                else
                    return "操作失败";
            }


        }

    }
}
