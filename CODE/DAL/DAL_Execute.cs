using System;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Data;
using System.Reflection;
using System.Collections.Generic;
using System.IO;
using Base.DBUtil;
using Oracle.ManagedDataAccess.Client;
using DDIV2.Model;
using DDIV2.DAL;
using DDI.Common;
using System.Net;
using Model;

namespace DDIV.DAL
{
    public class DAL_Execute
    {
        public string ConnName = "OracleConnString";
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(ExecuteLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" INSERT INTO DDI_ExecuteLog (");
            strSql.Append("Id,ConfigId,IsVoluntarily,BusinessExecuteDate,OperateDateTime,OperateMan,IsMormal,BusinessEndDateTime,Status,PathName,Remark,IsDeleted)");
            strSql.Append(" VALUES (");
            strSql.Append("@Id,@ConfigId,@IsVoluntarily,@BusinessExecuteDate,@OperateDateTime,@OperateMan,@IsMormal,@BusinessEndDateTime,@Status,@PathName,@Remark,@IsDeleted)");
            SqlParameter[] parameters = {
                    new SqlParameter("@Id", System.Guid.NewGuid()),
                    new SqlParameter("@ConfigId", model.ConfigId),
                    new SqlParameter("@IsVoluntarily", model.IsVoluntarily),
                    new SqlParameter("@BusinessExecuteDate", model.BusinessExecuteDate),
                    new SqlParameter("@OperateDateTime", model.OperateDateTime),
                    new SqlParameter("@OperateMan", model.OperateMan),
                    new SqlParameter("@IsMormal", model.IsMormal),
                    new SqlParameter("@BusinessEndDateTime", model.BusinessEndDateTime),
                    new SqlParameter("@Status", model.Status),
                    new SqlParameter("@PathName",model.PathName),
                    new SqlParameter("@Remark", model.Remark),
                    new SqlParameter("@IsDeleted", false)};

            object obj = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(ExecuteLog model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("UPDATE DDI_ExecuteLog set ");
            strSql.Append(" ConfigId=@ConfigId,");
            strSql.Append("IsVoluntarily=@IsVoluntarily,");
            strSql.Append("BusinessExecuteDate=@BusinessExecuteDate,");
            strSql.Append("OperateDateTime=@OperateDateTime,");
            strSql.Append("OperateMan=@OperateMan,");
            strSql.Append("IsMormal=@IsMormal,");
            strSql.Append("BusinessEndDateTime=@BusinessEndDateTime,");
            strSql.Append("Status=@Status,");
            strSql.Append("PathName=@PathName,");
            strSql.Append("Remark=@Remark ");
            strSql.Append(" WHERE Id=@Id");
            SqlParameter[] parameters = {
				   new SqlParameter("@Id", System.Guid.NewGuid()),
                    new SqlParameter("@ConfigId", model.ConfigId),
                    new SqlParameter("@IsVoluntarily", model.IsVoluntarily),
                    new SqlParameter("@BusinessExecuteDate", model.BusinessExecuteDate),
                    new SqlParameter("@OperateDateTime", model.OperateDateTime),
                    new SqlParameter("@OperateMan", model.OperateMan),
                    new SqlParameter("@IsMormal", model.IsMormal),
                    new SqlParameter("@BusinessEndDateTime", model.BusinessEndDateTime),
                    new SqlParameter("@Status", model.Status),
                    new SqlParameter("@PathName",model.PathName),
                    new SqlParameter("@Remark", model.Remark),
                    new SqlParameter("@Id","'"+model.Id+"'")};



            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(Guid Id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DDI_ExecuteLog set");
            strSql.Append(" IsDeleted=@IsDeleted ");
            strSql.Append(" where Id=@Id");
            SqlParameter[] parameters = {
					new SqlParameter("@IsDeleted", true),
					new SqlParameter("@ConfigId", "'"+Id+"'")};

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 批量删除数据
        /// </summary>
        public bool DeleteList(string idlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DDI_ExecuteLog set");
            strSql.Append(" IsDeleted=@IsDeleted ");
            strSql.Append(" where Id in (" + idlist + ")  ");
            SqlParameter[] parameters = {
					new SqlParameter("@IsDeleted", true)};

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(*) FROM DDI_ExecuteLog ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public ExecuteLog GetModel(Guid id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  *  from DDI_ExecuteLog ");
            strSql.Append(" where Id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = "'" + id + "'";

            ExecuteLog model = new ExecuteLog();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);

            if (ds.Tables[0].Rows.Count == 1)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                foreach (DataColumn dc in ds.Tables[0].Columns)
                {
                    string columnName = dc.ColumnName.Trim();
                    PropertyInfo propertyInfo = model.GetType().GetProperty(columnName);
                    if (propertyInfo != null && dr[columnName] != DBNull.Value)
                        propertyInfo.SetValue(model, dr[columnName].ToString(), null);
                }
                return model;
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetList(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.OperateDateTime desc");
            }
            strSql.Append(")AS Row, T.*  from DDI_ExecuteLog T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString(), 60000);
        }
        public DataSet GetList(int PageSize, int PageIndex, string strWhere)
        {
            SqlParameter[] parameters = {
                    new SqlParameter("@tblName", SqlDbType.VarChar, 255),
                    new SqlParameter("@fldName", SqlDbType.VarChar, 255),
                    new SqlParameter("@PageSize", SqlDbType.Int),
                    new SqlParameter("@PageIndex", SqlDbType.Int),
                    new SqlParameter("@IsReCount", SqlDbType.Bit),
                    new SqlParameter("@OrderType", SqlDbType.Bit),
                    new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
                    };
            parameters[0].Value = "DDI_ExecuteLog";
            parameters[1].Value = "OperateDateTime";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
        }

        #region 生成文件名称
        public string GetFileFormatName(List<ConfigFileFormatNameParm> listparm, Config configModel)
        {
            string resultname = "";
            if (listparm != null && !string.IsNullOrEmpty(configModel.FileFormatName))
            {
                #region 页面测试生成部分
                resultname = GetFileFormatDateTimeStr(listparm, configModel);
                #endregion
            }
            else
            {
                #region 自动执行生成部分

                if (configModel != null)
                {
                    DAL_ConfigFileFormatNameParm ffnp = new DAL_ConfigFileFormatNameParm();
                    DataSet ds = ffnp.GetList(configModel.Id);
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        List<ConfigFileFormatNameParm> listffnp = GetModelToDataSet(ds);


                        if (listffnp.Count > 0)
                            resultname = GetFileFormatDateTimeStr(listffnp, configModel);
                        else
                            resultname = configModel.FileFormatName;

                    }
                    else
                        resultname = configModel.FileFormatName;
                }
                #endregion
            }
            return resultname;
        }

        public string GetFileNamesuffix(string excelname, string suffix)
        {
            if (excelname != "")
            {
                if (suffix == "1")
                    excelname += ".xls";
                if (suffix == "2")
                    excelname += ".xlsx";
                if (suffix == "3")
                    excelname += ".txt";
                if (suffix == "4")
                    excelname += ".csv";
            }

            return excelname;
        }

        private string GetFileFormatDateTimeStr(List<ConfigFileFormatNameParm> listparm, Config configModel)
        {
            string str = "";
            string resulet = "";
            if (!string.IsNullOrEmpty(configModel.FileFormatName) && listparm.Count > 0)
            {
                str = configModel.FileFormatName;
                int i = 0;
                foreach (ConfigFileFormatNameParm parm in listparm)
                {
                    DateTime dt = DateTime.Now;
                    if (parm.DataSource == "yw")
                    {
                        dt = configModel.NextVoluntarilyTime;
                    }

                    string newstr = GetDateTimeStr(parm.VariableType, dt, parm.Connector.ToString());
                    if (i == 0)
                        resulet = str.Replace(parm.Name, newstr);
                    else
                    {
                        str = resulet;
                        resulet = str.Replace(parm.Name, newstr);
                    }
                    i++;
                }

            }
            else
            {
                resulet = configModel.FileFormatName;
            }
            return resulet;
        }
        private string GetDateTimeStr(string dttype, DateTime dt, string Connector)
        {
            string result = "";
            DateTime dtnew = dt;


            if (Connector == "Upday")
            {
                dtnew = dt.AddDays(-1);
            }
            if (Connector == "UpMonday")
            {
                dtnew = GetDateTimeToMonday(dt).AddDays(-7);
            }
            if (Connector == "UpSunday")
            {
                dtnew = GetDateTimeToMonday(dt).AddDays(-1);
            }
            if (Connector == "UpMonthOne")
            {
                dtnew = (dt.AddDays(1 - dt.Day)).AddMonths(-1);
            }
            if (Connector == "UpMonthLast")
            {
                dtnew = dt.AddDays(0 - dt.Day);
            }

            string thisdt = DateTime.Now.ToString("yyyyMMddHHmmss");
            if (dtnew != null)
                thisdt = dtnew.ToString("yyyyMMddHHmmss");


            if (dttype == "YYYY")
                result = thisdt.Substring(0, 4);
            else if (dttype == "YYYYWEEK")
                result = GetWeekOfYear(dt);
            else if (dttype == "YYYYUPWEEK")
                result = GetUPWeekOfYear(dt);
            else if (dttype == "YYYYMM")
                result = thisdt.Substring(0, 6);
            else if (dttype == "YYYYMMDD")
                result = thisdt.Substring(0, 8);
            else if (dttype == "YYYYMMDDHH")
                result = thisdt.Substring(0, 10);
            else if (dttype == "YYYYMMDDHHMM")
                result = thisdt.Substring(0, 12);
            else if (dttype == "YYYYMMDDHHMMSS")
                result = thisdt.Substring(0, 14);

            return result;
        }

        private DateTime GetDateTimeToMonday(DateTime dt)
        {
            DateTime dtMonday = dt.AddDays(1 - Convert.ToInt32(dt.DayOfWeek.ToString("d")));

            return dtMonday;
        }



        private string GetWeekOfYear(DateTime dt)
        {
            string result = "";
            int year = dt.Year;
            //一.找到第一周的最后一天（先获取1月1日是星期几，从而得知第一周周末是几）
            int firstWeekend = 7 - Convert.ToInt32(DateTime.Parse(year + "-1-1").DayOfWeek);

            //二.获取今天是一年当中的第几天
            int currentDay = dt.DayOfYear;

            //三.（今天 减去 第一周周末）/7 等于 距第一周有多少周 再加上第一周的1 就是今天是今年的第几周了
            //    刚好考虑了惟一的特殊情况就是，今天刚好在第一周内，那么距第一周就是0 再加上第一周的1 最后还是1
            int week = Convert.ToInt32(Math.Ceiling((currentDay - firstWeekend) / 7.0)) + 1;
            if (week < 10)
            {
                result = year.ToString() + "0" + week.ToString();
            }
            else
            {
                result = year.ToString() + week.ToString();
            }

            return result;
        }
        private string GetUPWeekOfYear(DateTime dt)
        {
            string result = "";
            int year = dt.Year;
            //一.找到第一周的最后一天（先获取1月1日是星期几，从而得知第一周周末是几）
            int firstWeekend = 7 - Convert.ToInt32(DateTime.Parse(year + "-1-1").DayOfWeek);

            //二.获取今天是一年当中的第几天
            int currentDay = dt.DayOfYear;

            //三.（今天 减去 第一周周末）/7 等于 距第一周有多少周 再加上第一周的1 就是今天是今年的第几周了
            //    刚好考虑了惟一的特殊情况就是，今天刚好在第一周内，那么距第一周就是0 再加上第一周的1 最后还是1
            int week = Convert.ToInt32(Math.Ceiling((currentDay - firstWeekend) / 7.0));

            if (week < 10)
            {
                result = year.ToString() + "0" + week.ToString();
            }
            else
            {
                result = year.ToString() + week.ToString();
            }

            return result;
        }
        #endregion


        #region 执行配置生成文件

        public bool ExecuteConfig(int configid, Guid ecid)
        {
            bool result = false;
            DAL_Config configdal = new DAL_Config();
            Config configmodel = configdal.GetModel(configid);
            if (configmodel != null)
            {
                string sql = configmodel.DateSql.ToString();
                //获取sql参数列表
                DAL_ConfigToSqlParameter sqldal = new DAL_ConfigToSqlParameter();
                DataSet sqlds = sqldal.GetList(configmodel.Id);
                if (sqlds != null && sqlds.Tables[0].Rows.Count > 0)//sql 存在参数
                {
                    List<ConfigToSqlParameter> sqlmodel = new List<ConfigToSqlParameter>();
                    sqlmodel = GetSqlModelToDataSet(sqlds);
                    string sqlText = "";
                    int i = 0;
                    DateTime dt = DateTime.Now;
                    foreach (ConfigToSqlParameter item in sqlmodel)
                    {
                        if (item.Illustrate == "yw")
                            dt = configmodel.NextVoluntarilyTime;
                        if (i == 0)
                        {
                            sqlText = sql.Replace(item.ParameterName, "'" + dt.ToString() + "'");
                        }
                        else
                        {
                            sql = sqlText;
                            sqlText = sql.Replace(item.ParameterName, "'" + dt.ToString() + "'");
                        }
                    }

                    DataSet ExcelDs = new DataSet();
                    try
                    {
                        if (configmodel.ServerType == "sql")
                        {
                            ExcelDs = DbHelperSQL.SqlQuery(sqlText.ToString());

                        }
                        else if (configmodel.ServerType == "oracle")
                        {

                            using (DbHelperOra _ora = new DbHelperOra(ConnName))
                            {
                                ExcelDs = _ora.Query(sqlText.ToString());
                            }
                        }


                        string excelname = GetFileFormatName(null, configmodel);

                        result = NPOIExtExcelHelper.SaveExportData(ExcelDs, excelname, excelname, configmodel.FileType, configmodel.PathName, configmodel.IsHead);
                    }
                    catch (Exception ex)
                    {
                        BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：业务执行失败\r\n明细信息：\r\n" + ex.Message, "ExecuteConfig-Sql");
                    }


                    if (result)
                    {
                        //更改执行日志
                        List<string> strsql = new List<string>();
                        StringBuilder strSql1 = new StringBuilder();
                        strSql1.Append(" UPDATE DDI_ExecuteLog SET Status='3',OperateDateTime='" + DateTime.Now.ToString() + "',IsMormal=1 WHERE Id='" + ecid.ToString() + "'");
                        strsql.Add(strSql1.ToString());
                        DbHelperSQL.ExecuteSqlTran(strsql);
                    }


                }
                else //sql 不存在参数
                {
                    #region
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(sql);
                    DataSet ExcelDs = new DataSet();

                    try
                    {
                        if (configmodel.ServerType == "sql")
                        {
                            ExcelDs = DbHelperSQL.SqlQuery(strSql.ToString());

                        }
                        else if (configmodel.ServerType == "oracle")
                        {

                            using (DbHelperOra _ora = new DbHelperOra(ConnName))
                            {
                                ExcelDs = _ora.Query(strSql.ToString());
                            }
                        }





                        string excelname = GetFileFormatName(null, configmodel);

                        result = NPOIExtExcelHelper.SaveExportData(ExcelDs, excelname, excelname, configmodel.FileType, configmodel.PathName, configmodel.IsHead);
                    }
                    catch (Exception ex)
                    {
                        BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：业务执行失败\r\n明细信息：\r\n" + ex.Message, "ExecuteConfig-Sql2");
                    }
                    if (result)
                    {
                        //更改执行日志
                        List<string> strsql = new List<string>();
                        StringBuilder strSql1 = new StringBuilder();
                        strSql1.Append(" UPDATE DDI_ExecuteLog SET Status='3',OperateDateTime='" + DateTime.Now.ToString() + "',IsMormal=1 WHERE Id='" + ecid.ToString() + "'");
                        strsql.Add(strSql1.ToString());
                        DbHelperSQL.ExecuteSqlTran(strsql);
                    }
                    #endregion
                }
            }

            return result;
        }
        /// <summary>
        /// 服务端重采
        /// </summary>
        /// <param name="configid"></param>
        /// <param name="yw"></param>
        /// <param name="cz"></param>
        /// <returns></returns>
        public bool ExecuteConfig(int configid, DateTime yw, DateTime cz)
        {
            bool result = false;
            DAL_Config configdal = new DAL_Config();
            Config configmodel = configdal.GetModel(configid);


            Random rad = new Random();//实例化随机数产生器rad；
            int value = rad.Next(10, 59);//用rad生成大于等于10，小于等于59的随机数；



            string ywdatestr = yw.ToString("yyyy-MM-dd") + " 00:00:" + value.ToString();
            DateTime  dtyw = Convert.ToDateTime(ywdatestr);
            string czdatestr = cz.ToString("yyyy-MM-dd") + " 00:00:" + value.ToString();
            DateTime  dtcz = Convert.ToDateTime(czdatestr);


            if (configmodel != null)
            {
                string sql = configmodel.DateSql.ToString();
                //获取sql参数列表
                DAL_ConfigToSqlParameter sqldal = new DAL_ConfigToSqlParameter();
                DataSet sqlds = sqldal.GetList(configmodel.Id);
                if (sqlds != null && sqlds.Tables[0].Rows.Count > 0)//sql 存在参数
                {
                    #region
                    List<ConfigToSqlParameter> sqlmodel = new List<ConfigToSqlParameter>();
                    sqlmodel = GetSqlModelToDataSet(sqlds);
                    string sqlText = "";
                    int i = 0;
                    DateTime dt = DateTime.Now;
                    if (configmodel.ServerType == "sql")
                    {
                        foreach (ConfigToSqlParameter item in sqlmodel)
                        {
                            if (item.Illustrate == "yw")
                                dt = dtyw;
                            else
                                dt = dtcz;
                            if (i == 0)
                            {
                                sqlText = sql.Replace(item.ParameterName, "'" + dt.ToString() + "'");
                            }
                            else
                            {
                                sql = sqlText;
                                sqlText = sql.Replace(item.ParameterName, "'" + dt.ToString() + "'");
                            }
                        }

                    }
                    else
                    {
                        foreach (ConfigToSqlParameter item in sqlmodel)
                        {
                            if (item.Illustrate == "yw")
                                dt = dtyw;
                            else
                                dt = dtcz;

                            string dtstr = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            string values = "to_date('" + dtstr + "','yyyy-mm-dd hh24:mi:ss')";

                            if (i == 0)
                            {
                                sqlText = sql.Replace(item.ParameterName, values);
                            }
                            else
                            {
                                sql = sqlText;
                                sqlText = sql.Replace(item.ParameterName, values);

                            }
                        }
                    }
                    DataSet ExcelDs = new DataSet();
                    try
                    {
                        if (configmodel.ServerType == "sql")
                        {
                            ExcelDs = DbHelperSQL.SqlQuery(sqlText.ToString());

                        }
                        else if (configmodel.ServerType == "oracle")
                        {

                            using (DbHelperOra _ora = new DbHelperOra(ConnName))
                            {
                                ExcelDs = _ora.Query(sqlText.ToString());
                            }
                        }

                        string excelname = GetFileFormatName(configmodel, dtyw, dtcz);

                        result = NPOIExtExcelHelper.SaveExportData(ExcelDs, excelname, excelname, configmodel.FileType, configmodel.PathName, configmodel.IsHead);
                        if (result == true)
                        {

                            BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：重采业务执行成功\r\n", "ExecuteConfig-Sql -681");
                            FtpConfig ftpconfigmodel = GetFtpConfigList(configmodel.Id.ToString());
                            if (ftpconfigmodel.Configid > 0)
                            {
                                string filename = GetFileNamesuffix(excelname, configmodel.FileType.ToString());
                                string thisfileurl = configmodel.PathName + filename;
                                UploadFile(ftpconfigmodel.FtpUrl, ftpconfigmodel.FileUrl, filename, ftpconfigmodel.FtpUser, ftpconfigmodel.FtpPassWord, thisfileurl);
                            }
                        }
                        else
                        {
                            BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：重采业务执行失败\r\n明细信息：\r\n服务端重采未生成文件", "ExecuteConfig-Sql -681");
                        }
                    }
                    catch (Exception ex)
                    {
                        BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：业务执行失败\r\n明细信息：\r\n" + ex.Message, "ExecuteConfig-Sql");
                    }

                    #endregion

                }
                else //sql 不存在参数
                {
                    #region
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(sql);
                    DataSet ExcelDs = new DataSet();

                    try
                    {
                        if (configmodel.ServerType == "sql")
                        {
                            ExcelDs = DbHelperSQL.SqlQuery(strSql.ToString());

                        }
                        else if (configmodel.ServerType == "oracle")
                        {

                            using (DbHelperOra _ora = new DbHelperOra(ConnName))
                            {
                                ExcelDs = _ora.Query(strSql.ToString());
                            }
                        }




                        string excelname = GetFileFormatName(configmodel, dtyw, dtcz);

                        result = NPOIExtExcelHelper.SaveExportData(ExcelDs, excelname, excelname, configmodel.FileType, configmodel.PathName, configmodel.IsHead);

                        if (result == true)
                        {

                            BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：重采业务执行成功\r\n", "ExecuteConfig-Sql2 -727");
                            FtpConfig ftpconfigmodel = GetFtpConfigList(configmodel.Id.ToString());
                            if (ftpconfigmodel.Configid > 0)
                            {
                                string filename = GetFileNamesuffix(excelname, configmodel.FileType.ToString());
                                string thisfileurl = configmodel.PathName + filename;
                                UploadFile(ftpconfigmodel.FtpUrl, ftpconfigmodel.FileUrl, filename, ftpconfigmodel.FtpUser, ftpconfigmodel.FtpPassWord, thisfileurl);
                            }
                        }
                        else
                        {
                            BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：重采业务执行失败\r\n明细信息：\r\n服务端重采未生成文件", "ExecuteConfig-Sql2 -727");
                        }
                    }
                    catch (Exception ex)
                    {
                        BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：重采业务执行失败\r\n明细信息：\r\n" + ex.Message, "ExecuteConfig-Sql2");
                    }

                    #endregion
                }
            }

            return result;
        }
        /// <summary>
        /// 服务端自动执行
        /// </summary>
        /// <param name="configmodel"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string ExecuteConfig(Config configmodel, DateTime dt)
        {
            string excelname = "";
            if (configmodel != null)
            {

                DateTime nextVoluntarilyTime = NextVoluntarilyTime(configmodel);
                //更新配置文件的下次執行時間
                string stringupdate = " UPDATE DDI_Config SET NextVoluntarilyTime = '" + nextVoluntarilyTime.ToString() + "'  WHERE Id=" + configmodel.Id.ToString();
                DbHelperSQL.ExecuteSql(stringupdate);
                BusinessLog.WriteBusinessLog("" + configmodel.BusinessName + "：业务执行成功\r\n下次执行时间：" + nextVoluntarilyTime.ToString(), "更新NextVoluntarilyTime");



                string sql = configmodel.DateSql.ToString();
                //获取sql参数列表
                DAL_ConfigToSqlParameter sqldal = new DAL_ConfigToSqlParameter();
                DataSet sqlds = sqldal.GetList(configmodel.Id);
                if (sqlds != null && sqlds.Tables[0].Rows.Count > 0)//sql 存在参数
                {
                    DataSet ExcelDs = new DataSet();

                    #region sql
                    List<ConfigToSqlParameter> sqlmodel = new List<ConfigToSqlParameter>();
                    sqlmodel = GetSqlModelToDataSet(sqlds);
                    string sqlText = "";
                    int i = 0;
                    List<OracleParameter> lispara = new List<OracleParameter>();
                    if (configmodel.ServerType == "sql")
                    {
                        foreach (ConfigToSqlParameter item in sqlmodel)
                        {
                            if (item.Illustrate == "yw")
                            {
                                dt = Convert.ToDateTime(configmodel.NextVoluntarilyTime.ToShortDateString() + " 00:00:00");
                            }
                            if (i == 0)
                            {
                                sqlText = sql.Replace(item.ParameterName, "'" + dt.ToString() + "'");
                            }
                            else
                            {
                                sql = sqlText;
                                sqlText = sql.Replace(item.ParameterName, "'" + dt.ToString() + "'");
                            }
                        }
                    }
                    else if (configmodel.ServerType == "oracle")
                    {

                        foreach (ConfigToSqlParameter item in sqlmodel)
                        {
                            if (item.Illustrate == "yw")
                            {
                                dt = Convert.ToDateTime(configmodel.NextVoluntarilyTime.ToShortDateString() + " 00:00:00");
                            }

                            string dtstr = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            string values = "to_date('" + dtstr + "','yyyy-mm-dd hh24:mi:ss')";

                            if (i == 0)
                            {
                                sqlText = sql.Replace(item.ParameterName, values);
                            }
                            else
                            {
                                sql = sqlText;
                                sqlText = sql.Replace(item.ParameterName, values);
                            }
                        }


                    }

                    try
                    {
                        if (configmodel.ServerType == "sql")
                        {
                            ExcelDs = DbHelperSQL.SqlQuery(sqlText);
                        }
                        else if (configmodel.ServerType == "oracle")
                        {
                            using (DbHelperOra _ora = new DbHelperOra(ConnName))
                            {
                                ExcelDs = _ora.Query(sqlText.ToString());
                            }
                        }

                        excelname = GetFileFormatName(null, configmodel);


                        NPOIExtExcelHelper.SaveExportData(ExcelDs, excelname, excelname, configmodel.FileType, configmodel.PathName, configmodel.IsHead);


                        FtpConfig ftpconfigmodel = GetFtpConfigList(configmodel.Id.ToString());
                        if (ftpconfigmodel.Configid > 0)
                        {
                            string filename = GetFileNamesuffix(excelname, configmodel.FileType.ToString());
                            string thisfileurl = configmodel.PathName + filename;
                            UploadFile(ftpconfigmodel.FtpUrl, ftpconfigmodel.FileUrl, filename, ftpconfigmodel.FtpUser, ftpconfigmodel.FtpPassWord, thisfileurl);
                        }
                        else
                        {

                            ExecuteDdiConfig(configmodel, dt, "0", excelname);
                        }
                    }
                    catch (Exception ex)
                    {
                        //string updatesql = "UPDATE dbo.DDI_Config SET IsDeleted=1  WHERE Id=" + configmodel.Id.ToString();
                        //DbHelperSQL.ExecuteSql(updatesql);
                        BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：业务执行失败\r\n原因：" + ex.Message, "有sql参数执行");
                    }
                    #endregion



                }
                else //sql 不存在参数
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(sql);
                    DataSet ExcelDs = new DataSet();

                    try
                    {
                        if (configmodel.ServerType == "sql")
                        {
                            ExcelDs = DbHelperSQL.SqlQuery(strSql.ToString());

                        }
                        else if (configmodel.ServerType == "oracle")
                        {

                            using (DbHelperOra _ora = new DbHelperOra(ConnName))
                            {
                                ExcelDs = _ora.Query(strSql.ToString());
                            }
                        }


                        excelname = GetFileFormatName(null, configmodel);


                        NPOIExtExcelHelper.SaveExportData(ExcelDs, excelname, excelname, configmodel.FileType, configmodel.PathName, configmodel.IsHead);


                        FtpConfig ftpconfigmodel = GetFtpConfigList(configmodel.Id.ToString());
                        if (ftpconfigmodel.Configid > 0)
                        {
                            string filename = GetFileNamesuffix(excelname, configmodel.FileType.ToString());
                            string thisfileurl = configmodel.PathName + filename;
                            UploadFile(ftpconfigmodel.FtpUrl, ftpconfigmodel.FileUrl, filename, ftpconfigmodel.FtpUser, ftpconfigmodel.FtpPassWord, thisfileurl);
                        }
                        else
                        {
                            ExecuteDdiConfig(configmodel, dt, "0", excelname);
                        }

                    }
                    catch (Exception ex)
                    {
                        //StringBuilder strSqlerror = new StringBuilder();
                        //string id = System.Guid.NewGuid().ToString();
                        //strSqlerror.Clear();
                        //strSqlerror.Append(" INSERT INTO DDI_ExecuteLog (Id,ConfigId,BusinessName,IsVoluntarily,BusinessExecuteDate,OperateDateTime,OperateMan,IsMormal,BusinessEndDateTime,[Status],PathName,Remark,IsDeleted,BackUrl,OrgCode) VALUES ('" + id + "'," + configmodel.Id.ToString().Trim() + " ,'" + configmodel.BusinessName + "','是','" + configmodel.NextVoluntarilyTime.ToString() + "' ,'" + DateTime.Now.ToString() + "','自动','1','" + configmodel.NextVoluntarilyTime.ToString() + "','2','" + configmodel.PathName + "','自动运行生成',0,'','" + configmodel.OrgCode + "')");



                        //string updatesql = "UPDATE dbo.DDI_Config SET IsDeleted=1  WHERE Id=" + configmodel.Id.ToString();
                        //DbHelperSQL.ExecuteSql(updatesql);
                        BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：业务执行失败\r\n原因：\r\n" + ex.Message, "无sql参数执行");
                    }

                }
            }

            return excelname;
        }


        public string CopyDirectory(string DirectoryPath, string filenam)//复制文件夹         
        {
            #region
            string path = DirectoryPath.Substring(0, DirectoryPath.Length - 1);

            string backadd = GetBackUrl();
            string backurl = backadd.Substring(0, backadd.Length - 2);

            if (!Directory.Exists(backurl))
            {
                Directory.CreateDirectory(backurl);
            }
            string oleurl = path + "\\" + filenam;
            string newurl = backurl + "\\" + filenam;
            File.Copy(oleurl, newurl, true);
            return backurl;
            #endregion
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="configmodel"></param>
        /// <param name="dt"></param>
        /// <param name="IsCopy">是否自动备份 1 备份 0 不备份</param>
        /// <returns></returns>
        public bool ExecuteDdiConfig(Config configmodel, DateTime dt, string IsCopy, string excelname)
        {
            bool result = false;
            string newurl = "";
            if (configmodel != null)
            {
                string status = "1";
                string IsMormal = "0";
                List<string> lsitSql = new List<string>();
                if (IsCopy == "0")
                {
                    #region 备份数据
                    try
                    {
                        if (excelname != "")
                        {
                            status = "1";
                            IsMormal = "1";

                            if (configmodel.FileType == 1)
                                excelname += ".xls";
                            if (configmodel.FileType == 2)
                                excelname += ".xlsx";
                            if (configmodel.FileType == 3)
                                excelname += ".txt";
                            if (configmodel.FileType == 4)
                                excelname += ".csv";

                            newurl = CopyDirectory(configmodel.PathName, excelname);

                            BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：业务执行成功\r\n文件备份成功\r\n明细信息：\r\n", "备份");
                        }
                        else
                        {
                            status = "2";
                        }


                    }
                    catch (Exception ex)
                    {
                        BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：业务执行失败\r\n文件备份失败\r\n明细信息：\r\n" + ex.Message, "备份");
                        status = "2";
                    }
                    #endregion
                }

                ////執行日誌
                //StringBuilder strSql = new StringBuilder();
                //string id = System.Guid.NewGuid().ToString();
                //strSql.Append(" INSERT INTO DDI_ExecuteLog (Id,ConfigId,BusinessName,IsVoluntarily,BusinessExecuteDate,OperateDateTime,OperateMan,IsMormal,BusinessEndDateTime,[Status],PathName,Remark,IsDeleted,BackUrl,OrgCode) VALUES ('" + id + "'," + configmodel.Id.ToString().Trim() + " ,'" + configmodel.BusinessName + "','是','" + configmodel.NextVoluntarilyTime.ToString() + "' ,'" + DateTime.Now.ToString() + "','自动','" + IsMormal + "','" + configmodel.NextVoluntarilyTime.ToString() + "','" + status + "','" + configmodel.PathName + "','自动运行生成',0,'" + newurl + "','" + configmodel.OrgCode + "')");
                ////計算下一次執行時間
                //lsitSql.Add(strSql.ToString());
                //strSql.Clear();
                //DateTime nextVoluntarilyTime = NextVoluntarilyTime(configmodel);
                ////更新配置文件的下次執行時間
                //strSql.Append(" UPDATE DDI_Config SET NextVoluntarilyTime = '" + nextVoluntarilyTime.ToString() + "' WHERE Id=" + configmodel.Id.ToString() + "");
                //lsitSql.Add(strSql.ToString());
                //if (DateTime.Now >= nextVoluntarilyTime)
                //{
                //    result = true;
                //}

                //object obj = DbHelperSQL.ExecuteSqlTran(lsitSql);
                //BusinessLog.WriteBusinessLog("" + configmodel.BusinessName + "：业务执行成功\r\n下次执行时间：" + nextVoluntarilyTime.ToString(), "更新NextVoluntarilyTime");




            }
            return result;
        }

        private DateTime NextVoluntarilyTime(Config configmodel)
        {
            DateTime dt = configmodel.NextVoluntarilyTime;
            DateTime dts = new DateTime();
            if (configmodel.Cycle == "日")
                dts = dt.AddDays(1);
            else if (configmodel.Cycle == "周")
                dts = dt.AddDays(7);
            else if (configmodel.Cycle == "月")
                dts = dt.AddMonths(1);
            else if (configmodel.Cycle == "季度")
                dts = dt.AddMonths(3);
            else if (configmodel.Cycle == "半年")
                dts = dt.AddMonths(6);
            else if (configmodel.Cycle == "年")
                dts = dt.AddYears(1);

            if (dts >= configmodel.LoseEfficacyDate)
                dts = configmodel.LoseEfficacyDate;

            return dts;
        }

        /// <summary>
        /// 重采  
        /// </summary>
        /// <param name="configid">配置id</param>
        /// <param name="ywdate">业务时间</param>
        /// <param name="czdate">操作时间</param>
        /// <returns></returns>
        public bool ExecuteConfig(int configid, DateTime ywdate, DateTime czdate, out string pathname)
        {
            bool result = false;
            DAL_Config configdal = new DAL_Config();

            Random rad = new Random();//实例化随机数产生器rad；

            int value = rad.Next(10, 59);//用rad生成大于等于10，小于等于59的随机数；




            Config configmodel = configdal.GetModel(configid);

            string ywdatestr = ywdate.ToString("yyyy-MM-dd") + "  00:00:" + value.ToString();// +configmodel.NextVoluntarilyTime.ToShortTimeString();
            DateTime  yw = Convert.ToDateTime(ywdatestr);
            string czdatestr = czdate.ToString("yyyy-MM-dd") + " 00:00:" + value.ToString();// +configmodel.NextVoluntarilyTime.ToShortTimeString();
            DateTime  cz = Convert.ToDateTime(czdatestr);


            pathname = "";
            if (configmodel != null)
            {
                string sql = configmodel.DateSql.ToString();
                DAL_ConfigToSqlParameter sqldal = new DAL_ConfigToSqlParameter();
                DataSet sqlds = sqldal.GetList(configmodel.Id);


                List<OracleParameter> lispara = new List<OracleParameter>();

                if (sqlds != null && sqlds.Tables[0].Rows.Count > 0)//sql 存在参数
                {
                    List<ConfigToSqlParameter> sqlmodel = new List<ConfigToSqlParameter>();
                    sqlmodel = GetSqlModelToDataSet(sqlds);
                    string sqlText = "";
                    int i = 0;
                    DateTime dt = DateTime.Now;


                    if (configmodel.ServerType == "sql")
                    {
                        foreach (ConfigToSqlParameter item in sqlmodel)
                        {
                            if (item.Illustrate == "yw")
                                dt = yw;
                            else
                                dt = cz;


                            if (i == 0)
                            {
                                sqlText = sql.Replace(item.ParameterName, "'" + dt.ToString() + "'");
                                sql = sqlText;
                            }
                            else
                            {
                                sqlText = sql.Replace(item.ParameterName, "'" + dt.ToString() + "'");
                                sql = sqlText;
                            }
                        }
                    }
                    else if (configmodel.ServerType == "oracle")
                    {

                        foreach (ConfigToSqlParameter item in sqlmodel)
                        {
                            if (item.Illustrate == "yw")
                                dt = yw;
                            else
                                dt = cz;

                            string dtstr = dt.ToString("yyyy-MM-dd HH:mm:ss");
                            string values = "to_date('" + dtstr + "','yyyy-mm-dd hh24:mi:ss')";

                            if (i == 0)
                            {
                                sqlText = sql.Replace(item.ParameterName, values);
                                sql = sqlText;
                            }
                            else
                            {
                                sqlText = sql.Replace(item.ParameterName, values);
                                sql = sqlText;
                            }
                        }


                    }




                    DataSet ExcelDs = new DataSet();
                    try
                    {
                        if (configmodel.ServerType == "sql")
                        {
                            ExcelDs = DbHelperSQL.SqlQuery(sql.ToString());
                        }
                        else if (configmodel.ServerType == "oracle")
                        {
                            using (DbHelperOra _ora = new DbHelperOra(ConnName))
                            {
                                ExcelDs = _ora.Query(sql.ToString());
                            }
                        }

                        if (ExcelDs.Tables[0].Rows.Count < 1)
                        {
                            BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：重采执行失败\r\n明细信息：\r\nSql语句执行返回空值", "重采");
                        }
                        string excelname = GetFileFormatName(configmodel, yw, cz);

                        pathname = configmodel.PathName + excelname + GetFiletType(configmodel.FileType);
                        bool res = NPOIExtExcelHelper.SaveExportData(ExcelDs, excelname, excelname, configmodel.FileType, configmodel.PathName, configmodel.IsHead);
                        if (res)
                        {
                            BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：重采执行成功\r\n", "重采");
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }


                    }
                    catch (Exception ex)
                    {
                        BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：重采执行失败\r\n明细信息：\r\n" + ex.Message, "重采");
                    }
                }
                else //sql 不存在参数
                {
                    StringBuilder strSql = new StringBuilder();
                    DataSet ExcelDs = new DataSet();

                    strSql.Append(sql);
                    try
                    {

                        if (configmodel.ServerType == "sql")
                        {
                            ExcelDs = DbHelperSQL.SqlQuery(strSql.ToString());
                        }
                        else if (configmodel.ServerType == "oracle")
                        {
                            using (DbHelperOra _ora = new DbHelperOra(ConnName))
                            {
                                ExcelDs = _ora.Query(strSql.ToString());
                            }
                        }

                        string excelname = GetFileFormatName(configmodel, yw, cz);
                        pathname = configmodel.PathName + excelname + GetFiletType(configmodel.FileType);
                        bool res = NPOIExtExcelHelper.SaveExportData(ExcelDs, excelname, excelname, configmodel.FileType, configmodel.PathName, configmodel.IsHead);
                        if (res)
                        {
                            BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：重采执行成功\r\n", "重采");
                            result = true;
                        }
                        else
                        {
                            result = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：业务执行失败\r\n原因：\r\n" + ex.Message, "重采");
                    }

                }
            }
            return result;
        }
        public string GetFiletType(int filetype)
        {
            string hz = "";
            switch (filetype)
            {
                case 1:
                    hz = ".xls";
                    break;
                case 2:
                    hz = ".xlsx";
                    break;
                case 3:
                    hz = ".txt";
                    break;
                case 4:
                    hz = ".csv";
                    break;
            }

            return hz;
        }

        public DataSet FileDownloadList(int configid, string supcode, string begindate, string enddate, out string pathname)
        {
            DAL_Config configdal = new DAL_Config();
            Config configmodel = configdal.GetModel(configid);
            DateTime dt = DateTime.Now;
            DataSet ExcelDs = new DataSet();

            if (configmodel != null)
            {
                string sql = configmodel.DateSql.ToString();
                string sqlText = "";
                if (configmodel.ServerType == "sql")
                {
                    sqlText = sql.Replace("@SupCode", "'" + supcode + "'");
                    sql = sqlText;
                    sqlText = sql.Replace("@BegionDate", "'" + begindate + "'");
                    sql = sqlText;
                    sqlText = sql.Replace("@EndDate", "'" + enddate + "'");
                    sql = sqlText;

                }
                else if (configmodel.ServerType == "oracle")
                {
                    string beginvalues = "to_date('" + begindate + "','yyyy-mm-dd hh24:mi:ss')";
                    string endvalues = "to_date('" + enddate + "','yyyy-mm-dd hh24:mi:ss')";

                    sqlText = sql.Replace("@SupCode", "'" + supcode + "'");
                    sql = sqlText;

                    sqlText = sql.Replace("@BegionDate", beginvalues);
                    sql = sqlText;

                    sqlText = sql.Replace("@EndDate", endvalues);
                    sql = sqlText;

                }


                try
                {
                    if (configmodel.ServerType == "sql")
                    {
                        ExcelDs = DbHelperSQL.SqlQuery(sql.ToString());
                    }
                    else if (configmodel.ServerType == "oracle")
                    {
                        using (DbHelperOra _ora = new DbHelperOra(ConnName))
                        {
                            ExcelDs = _ora.Query(sql.ToString());
                        }
                    }

                    if (ExcelDs.Tables[0].Rows.Count < 1)
                    {
                        BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：文件下载失败\r\n明细信息：\r\nSql语句执行返回空值", "文件下载");
                    }

                }
                catch (Exception ex)
                {
                    BusinessLog.WriteBusinessLog(configmodel.BusinessName + "：文件下载失败\r\n明细信息：\r\n" + ex.Message, "文件下载");
                }
            }

            pathname = GetFileFormatName(configmodel, dt, dt);

            return ExcelDs;


        }




        public string GetFileFormatName(Config configModel, DateTime ywdate, DateTime czdate)
        {
            string result = "";
            DAL_ConfigFileFormatNameParm ffnp = new DAL_ConfigFileFormatNameParm();
            DataSet ds = ffnp.GetList(configModel.Id);
            if (ds != null)
            {
                List<ConfigFileFormatNameParm> listffnp = GetModelToDataSet(ds);

                if (listffnp == null)
                    result = configModel.FileFormatName;
                else if (listffnp.Count > 0)
                    result = GetFileFormatDateTimeStr(listffnp, configModel, ywdate, czdate);
            }
            return result;
        }
        private string GetFileFormatDateTimeStr(List<ConfigFileFormatNameParm> listparm, Config configModel, DateTime ywdate, DateTime czdate)
        {
            string str = "";
            string resulet = "";
            if (!string.IsNullOrEmpty(configModel.FileFormatName) && listparm.Count > 0)
            {
                str = configModel.FileFormatName;
                int i = 0;
                foreach (ConfigFileFormatNameParm parm in listparm)
                {
                    DateTime dt = czdate;
                    if (parm.DataSource == "yw")
                    {
                        dt = ywdate;
                    }

                    string newstr = GetDateTimeStr(parm.VariableType, dt, parm.Connector.ToString());
                    if (i == 0)
                        resulet = str.Replace(parm.Name, newstr);
                    else
                    {
                        str = resulet;
                        resulet = str.Replace(parm.Name, newstr);
                    }
                    i++;
                }

            }
            return resulet;
        }
        #endregion

        #region 转换
        /// <summary>
        /// 得到一个对象实体 DdiConfigFileFormatNameParm
        /// </summary>
        public List<ConfigToSqlParameter> GetSqlModelToDataSet(DataSet ds)
        {
            List<ConfigToSqlParameter> listffnp = new List<ConfigToSqlParameter>();
            ConfigToSqlParameter model = new ConfigToSqlParameter();
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    if (ds.Tables[0].Rows[i]["ParameterId"] != null && ds.Tables[0].Rows[i]["ParameterId"].ToString() != "")
                    {
                        model.ParameterId = int.Parse(ds.Tables[0].Rows[i]["ParameterId"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["ConfigId"] != null && ds.Tables[0].Rows[i]["ConfigId"].ToString() != "")
                    {
                        model.ConfigId = int.Parse(ds.Tables[0].Rows[i]["ConfigId"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["ParameterName"] != null && ds.Tables[0].Rows[i]["ParameterName"].ToString() != "")
                    {
                        model.ParameterName = ds.Tables[0].Rows[i]["ParameterName"].ToString().Trim();
                    }
                    if (ds.Tables[0].Rows[i]["ParameterType"] != null && ds.Tables[0].Rows[i]["ParameterType"].ToString() != "")
                    {
                        model.ParameterType = ds.Tables[0].Rows[i]["ParameterType"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["OrderBy"] != null && ds.Tables[0].Rows[i]["OrderBy"].ToString() != "")
                    {
                        model.OrderBy = int.Parse(ds.Tables[0].Rows[i]["OrderBy"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Illustrate"] != null && ds.Tables[0].Rows[i]["Illustrate"].ToString() != "")
                    {
                        model.Illustrate = ds.Tables[0].Rows[i]["Illustrate"].ToString();
                    }
                    listffnp.Add(model);

                }
                return listffnp;
            }
            else
            {
                return null;
            }
        }
        public List<ConfigFileFormatNameParm> GetModelToDataSet(DataSet ds)
        {
            List<ConfigFileFormatNameParm> listffnp = new List<ConfigFileFormatNameParm>();

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ConfigFileFormatNameParm model = new ConfigFileFormatNameParm();
                    if (ds.Tables[0].Rows[i]["Id"] != null && ds.Tables[0].Rows[i]["Id"].ToString() != "")
                    {
                        model.Id = int.Parse(ds.Tables[0].Rows[i]["Id"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["ConfigId"] != null && ds.Tables[0].Rows[i]["ConfigId"].ToString() != "")
                    {
                        model.ConfigId = int.Parse(ds.Tables[0].Rows[i]["ConfigId"].ToString());
                    }
                    if (ds.Tables[0].Rows[i]["Name"] != null && ds.Tables[0].Rows[i]["Name"].ToString() != "")
                    {
                        model.Name = ds.Tables[0].Rows[i]["Name"].ToString().Trim();
                    }
                    if (ds.Tables[0].Rows[i]["VariableType"] != null && ds.Tables[0].Rows[i]["VariableType"].ToString() != "")
                    {
                        model.VariableType = ds.Tables[0].Rows[i]["VariableType"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["DataSource"] != null && ds.Tables[0].Rows[i]["DataSource"].ToString() != "")
                    {
                        model.DataSource = ds.Tables[0].Rows[i]["DataSource"].ToString();
                    }
                    if (ds.Tables[0].Rows[i]["Connector"] != null && ds.Tables[0].Rows[i]["Connector"].ToString() != "")
                    {
                        model.Connector = ds.Tables[0].Rows[i]["Connector"].ToString();
                    }
                    listffnp.Add(model);

                }
                return listffnp;
            }
            else
            {
                return null;
            }
        }

        #endregion

        public string GetBackUrl()
        {

            return PubConstant.BackUrl;
        }


        /// <summary>
        /// 组建参数用
        /// </summary>
        /// <param name="name"></param>
        /// <param name="oracleType"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public OracleParameter BuildOracleParameter(string name, OracleDbType oracleType, ParameterDirection direction, int size, object value)
        {
            OracleParameter paramerer = new OracleParameter(name, value);
            paramerer.ParameterName = name;
            paramerer.OracleDbType = oracleType;
            paramerer.Direction = direction;
            if (size > 0)
            {
                paramerer.Size = size;
            }

            return paramerer;
        }




        #region  FTP 文件上传


        public FtpConfig GetFtpConfigList(string configid)
        {
            string sql = "SELECT Configid,FtpUser,FtpPassWord,FtpUrl,FileUrl,Enabled FROM DDI_FtpConfig WHERE  Enabled ='0' and Configid=" + configid;

            FtpConfig model = new FtpConfig();
            DataSet ds = DbHelperSQL.Query(sql);
            #region
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Configid"] != null && ds.Tables[0].Rows[0]["Configid"].ToString() != "")
                {
                    model.Configid = int.Parse(ds.Tables[0].Rows[0]["Configid"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FtpUser"] != null && ds.Tables[0].Rows[0]["FtpUser"].ToString() != "")
                {
                    model.FtpUser = ds.Tables[0].Rows[0]["FtpUser"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FtpPassWord"] != null && ds.Tables[0].Rows[0]["FtpPassWord"].ToString() != "")
                {
                    model.FtpPassWord = ds.Tables[0].Rows[0]["FtpPassWord"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FtpUrl"] != null && ds.Tables[0].Rows[0]["FtpUrl"].ToString() != "")
                {
                    model.FtpUrl = ds.Tables[0].Rows[0]["FtpUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FileUrl"] != null && ds.Tables[0].Rows[0]["FileUrl"].ToString() != "")
                {
                    model.FileUrl = ds.Tables[0].Rows[0]["FileUrl"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Enabled"] != null && ds.Tables[0].Rows[0]["Enabled"].ToString() != "")
                {
                    model.Enabled = ds.Tables[0].Rows[0]["Enabled"].ToString();
                }
            }
            #endregion



            return model;
        }

        /// <summary>
        /// Ftp 文件上传
        /// </summary>
        /// <param name="ds">数据</param>
        /// <param name="ftpurl">ftp站点地址</param>
        /// <param name="fileurl">站点内路径</param>
        /// <param name="filename">文件名称包含后缀</param>
        /// <param name="username">用户名称</param>
        /// <param name="password">密码</param>
        public static void UploadFile(string ftpurl, string fileurl, string filename, string username, string password,string thisfileUrl)
        {
            try
            {

                string target;


                WebClient request = new WebClient();

                request.UploadDataCompleted += new UploadDataCompletedEventHandler(request_UploadDataCompleted);


                request.Credentials = new NetworkCredential(username, password);

                FileStream myStream = new FileStream(thisfileUrl, FileMode.Open, FileAccess.Read);

                byte[] dataByte = new byte[myStream.Length];
                myStream.Read(dataByte, 0, dataByte.Length);        //写到2进制数组中
                myStream.Close();
                string url = "";
                if (fileurl == "")
                    url = "ftp://" + ftpurl + "/" + filename;
                else
                    url = "ftp://" + ftpurl + "/" + fileurl + "/" + filename;

                Uri uri = new Uri(url);
                request.UploadDataAsync(uri, "STOR", dataByte, dataByte);


            }
            catch (Exception ex)
            {
                string BusinessName = "";
                BusinessLog.WriteBusinessLog("业务执行失败\r\n原因：\r\n" + ex.Message, "Ftp文件传输");
            }
        }
        static void request_UploadDataCompleted(object sender, UploadDataCompletedEventArgs e)
        {
            //接收UploadDataAsync传递过来的用户定义对象
            byte[] dataByte = (byte[])e.UserState;

            //AsyncCompletedEventArgs.Error属性,获取一个值，该值指示异步操作期间发生的错误
            if (e.Error == null)
            {
                DDI.Common.BusinessLog.WriteBusinessLog("作业执行\r\n方法：request_UploadDataCompleted 时间\r\n" + DateTime.Now.ToString() + "信息:\r\n 文件长传成功", "FTP上传日志");
            }
            else
            {
                DDI.Common.BusinessLog.WriteBusinessLog("作业执行失败\r\n方法：request_UploadDataCompleted 时间\r\n" + DateTime.Now.ToString() + "错误信息:\r\n" + e.Error, "FTP上传错误日志");
            }
        }

        #endregion




    }
}
