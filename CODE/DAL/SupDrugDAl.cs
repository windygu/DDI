using Base.DBUtil;
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DDIV.DAL
{
    public class SupDrugDAl
    {
        public string ConnName = "OracleConnString";
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(t.orgcode) FROM Sup_Drug_Add t ");
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
            strSql.Append("   SELECT tt.supcode,tt.supname,tt.drugcode,tt.isenabled,tt.orgcode,tt.createman,to_char(tt.createdate,'yyyy-MM-dd HH24:mi:ss') as createdate ,to_char(tt.startdate,'yyyy-MM-dd HH24:mi:ss') as startdate,to_char(tt.forbiddendate,'yyyy-MM-dd HH24:mi:ss') as forbiddendate,tt.forbiddenman,tt.ddicode  FROM (SELECT rank() over(order by t.orgcode,t.ddicode,t.drugcode,t.supcode) AS rowno,t.supcode,t.supname,t.drugcode,t.isenabled,t.orgcode,t.createman,t.createdate,t.startdate,t.forbiddendate,t.forbiddenman,t.ddicode FROM Sup_Drug_Add t  WHERE ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(strWhere);
            }
            
            strSql.AppendFormat(" ) tt  WHERE tt.rowno >= {0} AND tt.rowno <= {1} ", startIndex, endIndex);


            using (DbHelperOra _ora = new DbHelperOra(ConnName))
            {
                return _ora.Query(strSql.ToString());
            }


        }


        public int exit(string drugcode,string ddicode,string orgcode)
        {
            string strSql = "SELECT COUNT(*) FROM  Sup_Drug_Add WHERE DrugCode='" + drugcode + "' and DDICODE='" + ddicode + "' AND ORGCODE='" + orgcode + "'";
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

        public string Add(string drugcode, string supcode, string supname, string createman, string orgcode, string DdiCode)
        {
            if (exit(drugcode, DdiCode, orgcode) > 0)
            {
                return "当前查询码已经存在该商品信息，添加失败";
            }

            string datetime = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string sql = "INSERT INTO Sup_Drug_Add(SupCode,SupName,DrugCode,IsEnabled,OrgCode,CreateMan,CreateDate,StartDate,ForbiddenDate,ForbiddenMan,DdiCode) VALUES ('" + supcode + "','" + supname + "','" + drugcode + "','0','" + orgcode + "','" + createman + "',TO_DATE('" + datetime + "','yyyy-MM-dd HH24:MI:SS'), TO_DATE('" + datetime + "','yyyy-MM-dd HH24:MI:SS') ,null,null,'" + DdiCode + "')";


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


        public int Update(string isenable, string drugcode, string ddicode, string man,string orgcode)
        {
            string sql = "";
            string datetime = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            if (isenable == "1")
                sql = "Update Sup_Drug_Add set IsEnabled='" + isenable + "',ForbiddenDate=TO_DATE('" + datetime + "','yyyy-MM-dd HH24:MI:SS'),ForbiddenMan='" + man + "' WHERE DrugCode='" + drugcode + "' and DDICODE='" + ddicode + "' and ORGCODE='" + orgcode + "' ";
            else
                sql = "Update Sup_Drug_Add set IsEnabled='" + isenable + "',StartDate=TO_DATE('" + datetime + "','yyyy-MM-dd HH24:MI:SS'),ForbiddenMan='" + man + "' WHERE DrugCode='" + drugcode + "' and DDICODE='" + ddicode + "' and ORGCODE='" + orgcode + "' ";


            using (DbHelperOra _ora = new DbHelperOra(ConnName))
            {
                return _ora.ExecuteSql(sql.ToString());
            }
        }

    }
}
