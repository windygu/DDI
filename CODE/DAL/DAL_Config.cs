using Base.DBUtil;
using DDIV2.Model;
using Maticsoft.DBUtility;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DDIV2.DAL
{
    public class DAL_Config
    {



        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(Config model, List<ConfigToSqlParameter> para, List<ConfigFileFormatNameParm> parm)
        {

            List<String> list = new List<String>();
            StringBuilder strSql = new StringBuilder();
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int),
                    new SqlParameter("@ConfigType", SqlDbType.Int),
                    new SqlParameter("@FileType", SqlDbType.Int),
                    new SqlParameter("@BusinessName", SqlDbType.NVarChar,100),
                    new SqlParameter("@VoluntarilyTime", SqlDbType.DateTime),
                    new SqlParameter("@NextVoluntarilyTime", SqlDbType.DateTime),
                    new SqlParameter("@PathName", SqlDbType.NVarChar,200),
                    new SqlParameter("@Cycle", SqlDbType.NVarChar,50),
                    new SqlParameter("@Prefix", SqlDbType.NVarChar,50),
                    new SqlParameter("@Variable", SqlDbType.NVarChar,20),
                    new SqlParameter("@Suffix", SqlDbType.NVarChar,20),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,100),
                    new SqlParameter("@DateSql", SqlDbType.Text,-1),
                    new SqlParameter("@IsDeleted", SqlDbType.Bit),
                    new SqlParameter("@BecomeValidateDate", SqlDbType.DateTime),
                    new SqlParameter("@LoseEfficacyDate", SqlDbType.DateTime),
                    new SqlParameter("@FileFormatName", SqlDbType.NVarChar,100),
                    new SqlParameter("@IsHead", SqlDbType.Bit),
                    new SqlParameter("@ServerType", SqlDbType.NVarChar,20),
                    new SqlParameter("@OrgCode", SqlDbType.NVarChar,20),
                    new SqlParameter("@ManualDownload", SqlDbType.NVarChar,10),
                    new SqlParameter("@rowid", SqlDbType.Int)
                    };

            parameters[0].Value = -1;
            parameters[1].Value = model.ConfigType;
            parameters[2].Value = model.FileType;
            parameters[3].Value = model.BusinessName;
            parameters[4].Value = model.VoluntarilyTime;
            parameters[5].Value = model.NextVoluntarilyTime;
            parameters[6].Value = model.PathName;
            parameters[7].Value = model.Cycle;
            parameters[8].Value = model.Prefix;
            parameters[9].Value = "";
            parameters[10].Value = model.Suffix;
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.DateSql;
            parameters[13].Value = model.IsDeleted;
            parameters[14].Value = model.BecomeValidateDate;
            parameters[15].Value = model.LoseEfficacyDate;
            parameters[16].Value = model.FileFormatName;
            parameters[17].Value = model.IsHead;
            parameters[18].Value = model.ServerType;
            parameters[19].Value = model.OrgCode;
            parameters[20].Value = model.ManualDownload;
            parameters[21].Direction = ParameterDirection.Output;

            int rowreturn = DbHelperSQL.RunProcedure("DDI_Config_ADD", parameters, out rowsAffected, 60);
            int id = Convert.ToInt32(parameters[21].Value);
            if (rowreturn == 0 && id > 0)
            {
                if (parm.Count > 0)
                {
                    foreach (ConfigFileFormatNameParm temp in parm)
                    {
                        strSql.Clear();
                        strSql.Append(" INSERT INTO DDI_ConfigFileFormatNameParm (ConfigId,Name,VariableType,DataSource,Connector)");
                        strSql.Append(" VALUES (" + id.ToString() + ",'" + temp.Name.Trim() + "', '" + temp.VariableType.Trim() + "','" + temp.DataSource + "', '" + temp.Connector + "')");
                        list.Add(strSql.ToString());
                    }
                }
                if (para.Count > 0)
                {
                    foreach (ConfigToSqlParameter cspara in para)
                    {
                        strSql.Clear();
                        strSql.Append(" INSERT INTO DDI_ConfigToSqlParameter(ConfigId,ParameterName,ParameterType,OrderBy,Illustrate)");
                        strSql.Append(" VALUES (" + id.ToString() + ",'" + cspara.ParameterName.Trim() + "', '" + cspara.ParameterType.Trim() + "'," + cspara.OrderBy + ", '" + cspara.Illustrate.Trim() + "')");
                        list.Add(strSql.ToString());
                    }
                }
                object obj = DbHelperSQL.ExecuteSqlTran(list);
                if (obj == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(obj);
                }

            }
            else
                return -1;

        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Update(Config model, List<ConfigToSqlParameter> para, List<ConfigFileFormatNameParm> parm)
        {
            List<String> list = new List<String>();
            StringBuilder strSql = new StringBuilder();
            int result = 0;
            int rowsAffected = 0;
            SqlParameter[] parameters = {
                    new SqlParameter("@id", SqlDbType.Int),
                    new SqlParameter("@ConfigType", SqlDbType.Int),
                    new SqlParameter("@FileType", SqlDbType.Int),
                    new SqlParameter("@BusinessName", SqlDbType.NVarChar,100),
                    new SqlParameter("@VoluntarilyTime", SqlDbType.DateTime),
                    new SqlParameter("@NextVoluntarilyTime", SqlDbType.DateTime),
                    new SqlParameter("@PathName", SqlDbType.NVarChar,200),
                    new SqlParameter("@Cycle", SqlDbType.NVarChar,50),
                    new SqlParameter("@Prefix", SqlDbType.NVarChar,50),
                    new SqlParameter("@Variable", SqlDbType.NVarChar,20),
                    new SqlParameter("@Suffix", SqlDbType.NVarChar,20),
                    new SqlParameter("@Remark", SqlDbType.NVarChar,100),
                    new SqlParameter("@DateSql", SqlDbType.NVarChar,-1),
                    new SqlParameter("@IsDeleted", SqlDbType.Bit),
                    new SqlParameter("@BecomeValidateDate", SqlDbType.DateTime),
                    new SqlParameter("@LoseEfficacyDate", SqlDbType.DateTime),
                    new SqlParameter("@FileFormatName", SqlDbType.NVarChar,100),
                    new SqlParameter("@IsHead", SqlDbType.Bit),
                    new SqlParameter("@ServerType", SqlDbType.NVarChar,20),
                    new SqlParameter("@OrgCode", SqlDbType.NVarChar,20),
                    new SqlParameter("@ManualDownload", SqlDbType.NVarChar,10),
                    new SqlParameter("@rowid", SqlDbType.Int)
                    };

            parameters[0].Value = model.Id;
            parameters[1].Value = model.ConfigType;
            parameters[2].Value = model.FileType;
            parameters[3].Value = model.BusinessName;
            parameters[4].Value = model.VoluntarilyTime;
            parameters[5].Value = model.NextVoluntarilyTime;
            parameters[6].Value = model.PathName;
            parameters[7].Value = model.Cycle;
            parameters[8].Value = model.Prefix;
            parameters[9].Value = "";
            parameters[10].Value = model.Suffix;
            parameters[11].Value = model.Remark;
            parameters[12].Value = model.DateSql;
            parameters[13].Value = model.IsDeleted;
            parameters[14].Value = model.BecomeValidateDate;
            parameters[15].Value = model.LoseEfficacyDate;
            parameters[16].Value = model.FileFormatName;
            parameters[17].Value = model.IsHead;
            parameters[18].Value = model.ServerType;
            parameters[19].Value = model.OrgCode;
            parameters[20].Value = model.ManualDownload;
            parameters[21].Direction = ParameterDirection.Output;

            int rowreturn = DbHelperSQL.RunProcedure("DDI_Config_ADD", parameters, out rowsAffected, 60);
            int rowid = Convert.ToInt32(parameters[21].Value.ToString());
            if (rowreturn == 0 && rowid == 1)
            {
                strSql.Clear();
                strSql.Append(" DELETE FROM DDI_ConfigFileFormatNameParm  WHERE ConfigId=" + model.Id + "");
                list.Add(strSql.ToString());

                if (parm.Count > 0)
                {
                    foreach (ConfigFileFormatNameParm temp in parm)
                    {
                        strSql.Clear();
                        strSql.Append(" INSERT INTO DDI_ConfigFileFormatNameParm (ConfigId,Name,VariableType,DataSource,Connector)");
                        strSql.Append(" VALUES (" + model.Id + ",'" + temp.Name.Trim() + "', '" + temp.VariableType.Trim() + "','" + temp.DataSource + "', '" + temp.Connector + "')");
                        list.Add(strSql.ToString());
                    }

                }


                strSql.Clear();
                strSql.Append("  DELETE FROM DDI_ConfigToSqlParameter  WHERE ConfigId=" + model.Id + "");
                list.Add(strSql.ToString());

                if (para.Count > 0)
                {
                    foreach (ConfigToSqlParameter cspara in para)
                    {
                        strSql.Clear();
                        strSql.Append(" INSERT INTO DDI_ConfigToSqlParameter(ConfigId,ParameterName,ParameterType,OrderBy,Illustrate)");
                        strSql.Append(" VALUES (" + model.Id + ",'" + cspara.ParameterName + "', '" + cspara.ParameterType + "'," + cspara.OrderBy + ", '" + cspara.Illustrate + "')");
                        list.Add(strSql.ToString());
                    }

                }

                int rows = DbHelperSQL.ExecuteSqlTran(list);
                if (rows < 0)
                    result = 1;
            }
            else
            {
                result = 2;
            }



            return result;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int configId)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("update DDI_Config set");
            strSql.Append(" IsDeleted=@IsDeleted ");
            strSql.Append(" where Id=@ConfigId");
            SqlParameter[] parameters = {
					new SqlParameter("@IsDeleted", SqlDbType.Bit),
					new SqlParameter("@ConfigId", SqlDbType.Int,4)
};
            parameters[0].Value = true;
            parameters[1].Value = configId;

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
            strSql.Append("update DDI_Config set");
            strSql.Append(" IsDeleted=@IsDeleted ");
            strSql.Append(" where Id in (" + idlist + ")  ");
            SqlParameter[] parameters = {
					new SqlParameter("@IsDeleted", SqlDbType.Bit)};
            parameters[0].Value = true;

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
            strSql.Append("select count(*) FROM DDI_Config ");
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
        /// 获取记录总数Para
        /// </summary>
        public int GetParaCount(int configid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM DDI_ConfigToSqlParameter where ConfigId=" + configid + " ");

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
        /// 获取记录总数Parm
        /// </summary>
        public int GetParmCount(int configid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM DDI_ConfigFileFormatNameParm where ConfigId=" + configid + " ");

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
        public DataSet GetSqlModel(int id)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from dbo.DDI_ConfigToSqlParameter where ConfigId='" + id + "' order by OrderBy");
            strSql.Append("    select * from dbo.DDI_ConfigFileFormatNameParm where ConfigId='" + id + "'");


            return DbHelperSQL.Query(strSql.ToString());

        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Config GetModel(int id)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 * from DDI_Config ");
            strSql.Append(" where Id=@id");
            SqlParameter[] parameters = {
					new SqlParameter("@id", SqlDbType.Int,4)
			};
            parameters[0].Value = id;

            Config model = new Config();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["Id"] != null && ds.Tables[0].Rows[0]["Id"].ToString() != "")
                {
                    model.Id = int.Parse(ds.Tables[0].Rows[0]["Id"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ConfigType"] != null && ds.Tables[0].Rows[0]["ConfigType"].ToString() != "")
                {
                    model.ConfigType = int.Parse(ds.Tables[0].Rows[0]["ConfigType"].ToString());
                }
                if (ds.Tables[0].Rows[0]["FileType"] != null && ds.Tables[0].Rows[0]["FileType"].ToString() != "")
                {
                    model.FileType = int.Parse(ds.Tables[0].Rows[0]["FileType"].ToString().Trim());
                }
                if (ds.Tables[0].Rows[0]["BusinessName"] != null && ds.Tables[0].Rows[0]["BusinessName"].ToString() != "")
                {
                    model.BusinessName = ds.Tables[0].Rows[0]["BusinessName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["VoluntarilyTime"] != null && ds.Tables[0].Rows[0]["VoluntarilyTime"].ToString() != "")
                {
                    model.VoluntarilyTime = DateTime.Parse(ds.Tables[0].Rows[0]["VoluntarilyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["NextVoluntarilyTime"] != null && ds.Tables[0].Rows[0]["NextVoluntarilyTime"].ToString() != "")
                {
                    model.NextVoluntarilyTime = DateTime.Parse(ds.Tables[0].Rows[0]["NextVoluntarilyTime"].ToString());
                }
                if (ds.Tables[0].Rows[0]["PathName"] != null && ds.Tables[0].Rows[0]["PathName"].ToString() != "")
                {
                    model.PathName = ds.Tables[0].Rows[0]["PathName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Cycle"] != null && ds.Tables[0].Rows[0]["Cycle"].ToString() != "")
                {
                    model.Cycle = ds.Tables[0].Rows[0]["Cycle"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Prefix"] != null && ds.Tables[0].Rows[0]["Prefix"].ToString() != "")
                {
                    model.Prefix = ds.Tables[0].Rows[0]["Prefix"].ToString();
                }
                if (ds.Tables[0].Rows[0]["FileFormatName"] != null && ds.Tables[0].Rows[0]["FileFormatName"].ToString() != "")
                {
                    model.FileFormatName = ds.Tables[0].Rows[0]["FileFormatName"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Suffix"] != null && ds.Tables[0].Rows[0]["Suffix"].ToString() != "")
                {
                    model.Suffix = ds.Tables[0].Rows[0]["Suffix"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
                }
                if (ds.Tables[0].Rows[0]["DateSql"] != null && ds.Tables[0].Rows[0]["DateSql"].ToString() != "")
                {
                    model.DateSql = ds.Tables[0].Rows[0]["DateSql"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsDeleted"] != null && ds.Tables[0].Rows[0]["IsDeleted"].ToString() != "")
                {
                    model.IsDeleted = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsDeleted"].ToString());
                }
                if (ds.Tables[0].Rows[0]["BecomeValidateDate"] != null && ds.Tables[0].Rows[0]["BecomeValidateDate"].ToString() != "")
                {
                    model.BecomeValidateDate = DateTime.Parse(ds.Tables[0].Rows[0]["BecomeValidateDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["LoseEfficacyDate"] != null && ds.Tables[0].Rows[0]["LoseEfficacyDate"].ToString() != "")
                {
                    model.LoseEfficacyDate = DateTime.Parse(ds.Tables[0].Rows[0]["LoseEfficacyDate"].ToString());
                }
                if (ds.Tables[0].Rows[0]["IsHead"] != null && ds.Tables[0].Rows[0]["IsHead"].ToString() != "")
                {
                    model.IsHead = Convert.ToBoolean(ds.Tables[0].Rows[0]["IsHead"].ToString());
                }
                if (ds.Tables[0].Rows[0]["ServerType"] != null && ds.Tables[0].Rows[0]["ServerType"].ToString() != "")
                {
                    model.ServerType = ds.Tables[0].Rows[0]["ServerType"].ToString();
                }
                if (ds.Tables[0].Rows[0]["OrgCode"] != null && ds.Tables[0].Rows[0]["OrgCode"].ToString() != "")
                {
                    model.OrgCode = ds.Tables[0].Rows[0]["OrgCode"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ManualDownload"] != null && ds.Tables[0].Rows[0]["ManualDownload"].ToString() != "")
                {
                    model.ManualDownload = ds.Tables[0].Rows[0]["ManualDownload"].ToString();
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
                strSql.Append("order by T.Id desc");
            }
            strSql.Append(")AS Row, T.*  from DDI_Config T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
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
            parameters[0].Value = "DDI_Config";
            parameters[1].Value = "Id";
            parameters[2].Value = PageSize;
            parameters[3].Value = PageIndex;
            parameters[4].Value = 0;
            parameters[5].Value = 0;
            parameters[6].Value = strWhere;
            return DbHelperSQL.RunProcedure("UP_GetRecordByPage", parameters, "ds");
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="begindate">开始时间</param>
        /// <param name="enddate">截止时间</param>
        /// <param name="isSameDay">是否为当天 0否 1是</param>
        /// <returns></returns>
        public DataSet GetList(string begindate, string enddate, string isSameDay, string orgcode)
        {
            try
            {


                StringBuilder strSql = new StringBuilder();
                if (isSameDay == "1")
                {
                    strSql.Append(@"SELECT   Id as '编号','列队执行中' as '线程状态', CASE ConfigType WHEN '0' THEN '内置配置' ELSE '自定义配置' END  AS '配置方式',
 CASE FileType 
   WHEN '1' THEN 'Excel97_2003' 
   WHEN '2' THEN 'Excel2007' 
   WHEN '3' THEN '文本文件' 
   WHEN '4' THEN 'csv' END AS '文件格式', 
 BusinessName AS '业务名称', BecomeValidateDate AS '首次执行日期', NextVoluntarilyTime AS '本次执行时间', PathName AS '文件路径', Cycle AS '周期', Remark AS '备注', DateSql AS '数据集Sql', LoseEfficacyDate AS '失效日期', FileFormatName AS '格式化文件名称',VoluntarilyTime AS '执行时间',IsHead '是否显示头部',ServerType '数据访问类型',OrgCode '机构编码'  FROM   DDI_Config where IsDeleted=0 and ManualDownload='0' and NextVoluntarilyTime>='" + begindate + "' and NextVoluntarilyTime<='" + enddate + "' and LoseEfficacyDate>'" + enddate + "' and OrgCode in (" + orgcode + ") order by NextVoluntarilyTime");
                }
                else if (isSameDay == "0")
                {
                    strSql.Append(@"SELECT   Id as '编号','列队执行中' as '线程状态', CASE ConfigType WHEN '0' THEN '内置配置' ELSE '自定义配置' END  AS '配置方式',
 CASE FileType 
   WHEN '1' THEN 'Excel97_2003' 
   WHEN '2' THEN 'Excel2007' 
   WHEN '3' THEN '文本文件' 
   WHEN '4' THEN 'csv' END AS '文件格式', 
 BusinessName AS '业务名称', BecomeValidateDate AS '首次执行日期', NextVoluntarilyTime AS '本次执行时间', PathName AS '文件路径', Cycle AS '周期', Remark AS '备注', DateSql AS '数据集Sql', LoseEfficacyDate AS '失效日期', FileFormatName AS '格式化文件名称',VoluntarilyTime AS '执行时间',IsHead '是否显示头部',ServerType '数据访问类型',OrgCode '机构编码'  FROM   DDI_Config where IsDeleted=0 and ManualDownload='0' and NextVoluntarilyTime<'" + begindate + "' and LoseEfficacyDate>'" + enddate + "' and OrgCode in (" + orgcode + ") order by NextVoluntarilyTime");
                }

                return DbHelperSQL.Query(strSql.ToString());
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// ftp 左侧配置列表
        /// </summary>
        /// <param name="busname"></param>
        /// <returns></returns>
        public DataSet GetFtpList(string busname)
        {
            StringBuilder strSql = new StringBuilder();
            if (busname != "")
            {
                strSql.Append(@"SELECT   Id as '编号',BusinessName AS '业务名称', LoseEfficacyDate AS '失效日期',OrgCode '机构编码'  FROM   DDI_Config where IsDeleted=0 and BusinessName like '%" + busname + "%' order by BusinessName");
            }
            else
            {
                strSql.Append(@"SELECT   Id as '编号',BusinessName AS '业务名称', LoseEfficacyDate AS '失效日期',OrgCode '机构编码'  FROM   DDI_Config where IsDeleted=0    order by BusinessName");
            }

            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 加载数据
        /// </summary>
        /// <param name="begindate">开始时间</param>
        /// <param name="enddate">截止时间</param>
        /// <param name="isSameDay">是否为当天 0否 1是</param>
        /// <returns></returns>
        public DataSet GetList(string bname, string orgcode)
        {
            StringBuilder strSql = new StringBuilder();

            if (bname == "")
            {
                strSql.Append("SELECT top 10  Id as '编号', CASE ConfigType WHEN '0' THEN '内置配置' ELSE '自定义配置' END  AS '配置方式', CASE FileType WHEN '1' THEN 'Excel97_2003' WHEN '2' THEN 'Excel2007' ELSE '文本文件' END AS '文件格式', BusinessName AS '业务名称', BecomeValidateDate AS '首次执行日期', NextVoluntarilyTime AS '本次执行时间', PathName AS '文件路径', Cycle AS '周期', Remark AS '备注', DateSql AS '数据集Sql', LoseEfficacyDate AS '失效日期', FileFormatName AS '格式化文件名称',VoluntarilyTime AS '执行时间',OrgCode '机构编码'  FROM   DDI_Config where IsDeleted=0  and OrgCode in (" + orgcode + ") order by Id");
            }
            else
            {
                strSql.Append("SELECT   Id as '编号', CASE ConfigType WHEN '0' THEN '内置配置' ELSE '自定义配置' END  AS '配置方式', CASE FileType WHEN '1' THEN 'Excel97_2003' WHEN '2' THEN 'Excel2007' ELSE '文本文件' END AS '文件格式', BusinessName AS '业务名称', BecomeValidateDate AS '首次执行日期', NextVoluntarilyTime AS '本次执行时间', PathName AS '文件路径', Cycle AS '周期', Remark AS '备注', DateSql AS '数据集Sql', LoseEfficacyDate AS '失效日期', FileFormatName AS '格式化文件名称',VoluntarilyTime AS '执行时间',OrgCode '机构编码'   FROM   DDI_Config where IsDeleted=0 and BusinessName LIKE '%" + bname + "%' and OrgCode in (" + orgcode + ") order by Id");
            }
            return DbHelperSQL.Query(strSql.ToString());

        }
        public List<string> GetAllList()
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT PathName FROM   DDI_Config where IsDeleted=0 and PathName<>''");
            List<string> listurl = new List<string>();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    listurl.Add(ds.Tables[0].Rows[i]["PathName"].ToString());
                }
            }
            return listurl;
        }

        public string ConnName = "OracleConnString";
        public DataSet CheckConfigSql(string sql, List<ConfigToSqlParameter> para, string serverType, string userorgcode, out string result)
        {
             result = "语法验证通过,数据验证请下载文件。";
            string sqlText = "";
            DateTime dt = DateTime.Now.AddDays(-1);
            int i = 0;
            if (sql != "")
            {
                #region
                if (serverType == "sql")
                {
                    if (para.Count > 0)
                    {
                        foreach (ConfigToSqlParameter item in para)
                        {
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
                }
                else
                {
                    if (para.Count > 0)
                    {
                        foreach (ConfigToSqlParameter item in para)
                        {

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
                }
                #endregion
            }
            DataSet ExcelDs = new DataSet();

            try
            {
                if (serverType == "sql")
                {
                    ExcelDs = DbHelperSQL.SqlQuery(sql.ToString());
                }
                else if (serverType == "oracle")
                {
                    string sql1 = sql.ToLower();
                    if (sql1.Contains("ddicode"))
                    {
                        using (DbHelperOra _ora = new DbHelperOra(ConnName))
                        {
                            ExcelDs = _ora.Query(sql.ToString());
                        }
                    }
                    else
                    {
                        result = "Query 语句必须包含 DDI查询码！";
                    }
                }

            }
            catch (Exception ex)
            {
                result = "Query 语句存在语法错误:"+ex.Message.ToString();
            }






            return ExcelDs;
        }


    }
}
