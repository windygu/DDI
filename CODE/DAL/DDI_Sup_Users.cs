using Base.DBUtil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DDIV.DAL
{
    public class DDI_Sup_Users
    {

        public string ConnName = "OracleConnString";
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(t.SupCode) FROM SupUsers t ");
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
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("   SELECT tt.supcode,tt.supname,tt.isenabled,tt.createman,to_char(tt.createdate,'yyyy-MM-dd HH24:mi:ss') as createdate   FROM (SELECT ROWNUM AS rowno,t.supcode,t.supname,t.isenabled,t.createman,t.createdate FROM SupUsers t  WHERE ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(strWhere);
            }
            strSql.Append(" order by t.supcode ");


            strSql.AppendFormat(" ) tt  WHERE tt.rowno > {0} AND tt.rowno <= {1} ", startIndex, endIndex);


            using (DbHelperOra _ora = new DbHelperOra(ConnName))
            {
                return _ora.Query(strSql.ToString());
            }


        }
        public DataSet GetList(string where )
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select u.supcode,u.supname,s.supcode as status from supusers u left join supusersrelation s on u.supcode=s.supcode "+where+" order by u.supcode");
            
           
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



        public string Add(string supcode, string supname, string createman, string IsEnabled)
        {
            if (exit(supcode) > 0)
            {
                return "已经存在供应商信息，添加失败";
            }

            string datetime = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string sql = "INSERT INTO SupUsers(SupCode,SupName,IsEnabled,CreateMan,CreateDate) VALUES ('" + supcode + "','" + supname + "','" + IsEnabled + "','" + createman + "',TO_DATE('" + datetime + "','yyyy-MM-dd HH24:MI:SS'))";


            using (DbHelperOra _ora = new DbHelperOra(ConnName))
            {
                int result = _ora.ExecuteSql(sql.ToString());
                if (result > 0)
                {
                    return "添加成功";
                }
                else
                    return "添加失败";
            }

        }

    }
}
