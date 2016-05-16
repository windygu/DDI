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
    public class DalSupAndDrugRelation
    {

        public string ConnName = "OracleConnString";
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(t.SUPCODE) FROM supdrugrelation t ");
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
            strSql.Append("   SELECT tt.USERID,tt.SUPCODE,tt.SUPNAME,tt.GOODSCODE,tt.GOODSNAME,tt.GOODSSPEC,tt.CREATEMAN,to_char(tt.CREATEDATE,'yyyy-MM-dd HH24:mi:ss') as CREATEDATE,tt.DELETEMAN,to_char(tt.DELETEDATE,'yyyy-MM-dd HH24:mi:ss') as DELETEDATE,tt.ISENABLED FROM (SELECT rank() over(order by    t.USERID,t.SUPCODE,t.GOODSCODE) AS rowno,t.USERID,t.SUPCODE,t.SUPNAME,t.GOODSCODE,t.GOODSNAME,t.GOODSSPEC,t.CREATEMAN,t.CREATEDATE,t.DELETEMAN,t.DELETEDATE,t.ISENABLED FROM supdrugrelation t  WHERE ");
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
        private int exit(string supcode, int userid,string drugcode)
        {
            string strSql = "SELECT COUNT(supcode) FROM  supdrugrelation where userid=" + userid + " and supcode='" + supcode + "' and GOODSCODE='" + drugcode + "'";
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

        public string Add(SupAndDrugRelation item)
        {
            if (this.exit(item.SupCode, item.UserId, item.GoodsCode) > 0)
            {
                return "当前供应商上已经存在该药品";
            }
            else
            {
                string datetime = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");

                string sql = "INSERT INTO supdrugrelation (USERID,SUPCODE,SUPNAME,GOODSCODE,GOODSNAME,GOODSSPEC,CREATEMAN,CREATEDATE,DELETEMAN,DELETEDATE,ISENABLED) VALUES (" + item.UserId + ",'" + item.SupCode + "','" + item.SupName + "','" + item.GoodsCode + "','" + item.GoodsName + "','" + item.GoodsSpec + "','" + item.CreateMan + "',TO_DATE('" + item.CreateDate + "','yyyy-MM-dd HH24:MI:SS'),'" + item.DeleteMan + "',TO_DATE('" + item.DeleteData + "','yyyy-MM-dd HH24:MI:SS'),'" + item.IsEnabled + "')";


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

        public string Update(SupAndDrugRelation item,string userid,string supcode,string drugcode)
        {
            string sql = "update  supdrugrelation set USERID='" + item.UserId + "',SUPCODE='" + item.SupCode + "',SUPNAME='" + item.SupName + "',GOODSCODE='" + item.GoodsCode + "',GOODSNAME='" + item.GoodsName + "',GOODSSPEC='" + item.GoodsSpec + "'where userid=" + userid + " and supcode='" + supcode + "' and GOODSCODE='" + drugcode + "'";


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

        public string delete(string supcode, int userid,string drugcode,string sienabled,string empname)
        {
            string datetime = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss");
            string sql ="";
            if (sienabled == "正常")
            {
                sql = "update  supdrugrelation set ISENABLED='" + sienabled + "',DELETEMAN='',DELETEDATE='' where userid=" + userid + " and supcode='" + supcode + "' and GOODSCODE='" + drugcode + "'";
            }
            else
            {
                sql = "update  supdrugrelation set ISENABLED='" + sienabled + "',DELETEMAN='" + empname + "',DELETEDATE=TO_DATE('" + datetime + "','yyyy-MM-dd HH24:MI:SS') where userid=" + userid + " and supcode='" + supcode + "' and GOODSCODE='" + drugcode + "'";
            }


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


        public SupAndDrugRelation GetMoudel(string userid, string supcode, string drugcode)
        {
            string sql = "select USERID,SUPCODE,SUPNAME,GOODSCODE,GOODSNAME,GOODSSPEC,CREATEMAN,CREATEDATE,DELETEMAN,DELETEDATE,ISENABLED from supdrugrelation where userid=" + userid + " and supcode='" + supcode + "' and GOODSCODE='" + drugcode + "'";

            SupAndDrugRelation model = new SupAndDrugRelation();
            using (DbHelperOra _ora = new DbHelperOra(ConnName))
            {
                DataSet ds = _ora.Query(sql);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    if (ds.Tables[0].Rows[0]["USERID"] != null && ds.Tables[0].Rows[0]["USERID"].ToString() != "")
                    {
                        model.UserId = int.Parse(ds.Tables[0].Rows[0]["USERID"].ToString());
                    }
                    if (ds.Tables[0].Rows[0]["SUPCODE"] != null && ds.Tables[0].Rows[0]["SUPCODE"].ToString() != "")
                    {
                        model.SupCode = ds.Tables[0].Rows[0]["SUPCODE"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["SUPNAME"] != null && ds.Tables[0].Rows[0]["SUPNAME"].ToString() != "")
                    {
                        model.SupName = ds.Tables[0].Rows[0]["SUPNAME"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["GOODSCODE"] != null && ds.Tables[0].Rows[0]["GOODSCODE"].ToString() != "")
                    {
                        model.GoodsCode = ds.Tables[0].Rows[0]["GOODSCODE"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["GOODSNAME"] != null && ds.Tables[0].Rows[0]["GOODSNAME"].ToString() != "")
                    {
                        model.GoodsName = ds.Tables[0].Rows[0]["GOODSNAME"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["GOODSSPEC"] != null && ds.Tables[0].Rows[0]["GOODSSPEC"].ToString() != "")
                    {
                        model.GoodsSpec = ds.Tables[0].Rows[0]["GOODSSPEC"].ToString();
                    }
                    if (ds.Tables[0].Rows[0]["ISENABLED"] != null && ds.Tables[0].Rows[0]["ISENABLED"].ToString() != "")
                    {
                        model.IsEnabled =ds.Tables[0].Rows[0]["ISENABLED"].ToString();
                    }
                }
            }

            return model;
        }


    }
}
