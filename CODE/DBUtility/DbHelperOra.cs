// ***********************************************************************
// Assembly         : Base.DBUtil
// Author           : 席
// Created          : 01-05-2015
//
// Last Modified By : 席
// Last Modified On : 01-06-2015
// ***********************************************************************
// <copyright file="DbHelperOra.cs" company="华润医药商业集团">
//     Copyright (c) 华润医药商业集团. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************
using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using Maticsoft.DBUtility;

namespace Base.DBUtil
{
    /// <summary>
    /// 数据访问基础类(基于Oracle) Copyright (C) WMS
    /// 可以用户可以修改满足自己项目的需要。
    /// </summary> 
    public class DbHelperOra : IDisposable
    {
        private OracleConnection conn;
        //数据库连接字符串 	
        private string connectionString;

        public DbHelperOra()
            : this("OracleConnString")
        {
        }
        public DbHelperOra(string connString)
        {
            string connstr = ConfigurationManager.AppSettings[connString];
            this.connectionString = DESEncrypt.Decrypt(connstr);
            //this.connectionString = ConfigurationManager.AppSettings[connString];
            conn = new OracleConnection(this.connectionString);
            if (conn.State != ConnectionState.Open)
                conn.Open();
        }

        #region  执行SQL语句
        public int GetMaxID(string FieldName, string TableName)
        {
            string strsql = "select max(" + FieldName + ")+1 from " + TableName;
            object obj = this.GetSingle(strsql);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return int.Parse(obj.ToString());
            }
        }

        public bool Exists(string strSql)
        {
            object obj = this.GetSingle(strSql);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool Exists(string strSql, OracleParameter[] cmdParms)
        {
            object obj = this.GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 执行SQL语句,返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, int Times = 30)
        {
            using (OracleCommand cmd = new OracleCommand(SQLString, this.conn))
            {
                try
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = Times;
                    int rows = cmd.ExecuteNonQuery();

                    return rows;
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException ex)
                {
                    throw ex;
                }
            }
        }


        /// <summary>
        /// 执行多条SQL语句,实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>		
        public bool ExecuteSqlTran(ArrayList SQLStringList, int Times = 30)
        {
            using (OracleTransaction trans = this.conn.BeginTransaction())
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = this.conn;
                    cmd.Transaction = trans;
                    cmd.CommandTimeout = Times;
                    try
                    {
                        for (int n = 0; n < SQLStringList.Count; n++)
                        {
                            string strsql = SQLStringList[n].ToString();
                            if (strsql.Trim().Length > 1)
                            {
                                cmd.CommandText = strsql;
                                cmd.BindByName = true;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();

                        return true;
                    }
                    catch (Oracle.ManagedDataAccess.Client.OracleException ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
            }
        }
        public bool ExecuteSqlTran(List<string> SQLStringList)
        {
            using (OracleTransaction trans = this.conn.BeginTransaction())
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = this.conn;
                    cmd.Transaction = trans;
                    cmd.CommandTimeout = 60;
                    try
                    {
                        for (int n = 0; n < SQLStringList.Count; n++)
                        {
                            string strsql = SQLStringList[n].ToString();
                            if (strsql.Trim().Length > 1)
                            {
                                cmd.CommandText = strsql;
                                cmd.BindByName = true;
                                cmd.ExecuteNonQuery();
                            }
                        }
                        trans.Commit();

                        return true;
                    }
                    catch (Oracle.ManagedDataAccess.Client.OracleException ex)
                    {
                        trans.Rollback();
                        throw ex;
                    }
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句,实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">多条SQL语句</param>
        /// <param name="OracleParameter">多条SQL语句</param>
        public bool ExecuteSqlTran(ArrayList SQLStringList, ArrayList OracleParameter)
        {
            using (OracleTransaction trans = this.conn.BeginTransaction())
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        //循环
                        for (int n = 0; n < SQLStringList.Count; n++)
                        {
                            string cmdText = SQLStringList[n].ToString();
                            OracleParameter[] cmdParms = (OracleParameter[])OracleParameter[n];
                            this.PrepareCommand(cmd, this.conn, trans, cmdText, cmdParms);

                            int val = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();

                        }
                        trans.Commit();
                        return true;
                    }
                    catch (Oracle.ManagedDataAccess.Client.OracleException ex)
                    {
                        trans.Rollback();
                        //return false;
                        throw ex;
                    }
                }
            }
        }


        /// <summary>
        /// 执行一条计算查询结果语句,返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString)
        {
            using (OracleCommand cmd = new OracleCommand(SQLString, this.conn))
            {
                try
                {
                    object obj = cmd.ExecuteScalar();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException ex)
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// 执行查询语句,返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string SQLString)
        {
            DataSet ds = new DataSet();
            try
            {
                OracleDataAdapter command = new OracleDataAdapter(SQLString, this.conn);

                command.Fill(ds, "ds");
            }
            catch (Oracle.ManagedDataAccess.Client.OracleException ex)
            {
                throw new Exception(ex.Message);
            }
            return ds;

        }


        #endregion

        #region 执行带参数的SQL语句

        /// <summary>
        /// 执行SQL语句,返回影响的记录数
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public int ExecuteSql(string SQLString, OracleParameter[] cmdParms)
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    this.PrepareCommand(cmd, this.conn, null, SQLString, cmdParms);
                    int rows = cmd.ExecuteNonQuery();

                    cmd.Parameters.Clear();
                    return rows;
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException E)
                {
                    throw new Exception(E.Message);
                }
            }

        }
        /// <summary>
        /// 执行SQL语句,返回执行结果,解决insert,update,delete的执行时无反应的问题
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns>影响的记录数</returns>
        public bool ExecuteSqlTran(string SQLString, OracleParameter[] cmdParms)
        {
            using (OracleTransaction trans = this.conn.BeginTransaction())
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    try
                    {
                        this.PrepareCommand(cmd, this.conn, trans, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();


                        cmd.Parameters.Clear();
                        trans.Commit();
                        return true;
                    }
                    catch (Oracle.ManagedDataAccess.Client.OracleException E)
                    {
                        trans.Rollback();
                        //return false;
                        throw new Exception(E.Message);
                    }
                }
            }
        }

        /// <summary>
        /// 执行多条SQL语句,实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句,value是该语句的OracleParameter[]）</param>
        public bool ExecuteSqlTran(Hashtable SQLStringList)
        {
            using (OracleTransaction trans = this.conn.BeginTransaction())
            {
                OracleCommand cmd = new OracleCommand();
                try
                {
                    //循环
                    foreach (DictionaryEntry myDE in SQLStringList)
                    {
                        string cmdText = myDE.Key.ToString();
                        OracleParameter[] cmdParms = (OracleParameter[])myDE.Value;
                        this.PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();

                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }
        /// <summary>
        /// 执行多条SQL语句,实现数据库事务。
        /// </summary>
        /// <param name="SQLStringList">SQL语句的哈希表（key为sql语句,value是该语句的OracleParameter[]）</param>
        public bool ExecuteSqlTran(List<string> SQLStringList, List<OracleParameter[]> Parms)
        {
            using (OracleTransaction trans = this.conn.BeginTransaction())
            {
                OracleCommand cmd = new OracleCommand();
                try
                {
                    //循环
                    for (int i = 0; i < SQLStringList.Count; i++)
                    {
                        string cmdText = SQLStringList[i].ToString();
                        OracleParameter[] cmdParms = Parms[i];
                        this.PrepareCommand(cmd, conn, trans, cmdText, cmdParms);
                        int val = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }
                    trans.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw ex;
                }
            }
        }


        /// <summary>
        /// 执行一条计算查询结果语句,返回查询结果（object）。
        /// </summary>
        /// <param name="SQLString">计算查询结果语句</param>
        /// <returns>查询结果（object）</returns>
        public object GetSingle(string SQLString, OracleParameter[] cmdParms)
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                try
                {
                    this.PrepareCommand(cmd, this.conn, null, SQLString, cmdParms);
                    object obj = cmd.ExecuteScalar();
                    cmd.Parameters.Clear();
                    if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                    {
                        return null;
                    }
                    else
                    {
                        return obj;
                    }
                }
                catch (Oracle.ManagedDataAccess.Client.OracleException e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        /// <summary>
        /// 执行查询语句,返回DataSet
        /// </summary>
        /// <param name="SQLString">查询语句</param>
        /// <returns>DataSet</returns>
        public DataSet Query(string SQLString, OracleParameter[] cmdParms)
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                this.PrepareCommand(cmd, this.conn, null, SQLString, cmdParms);
                using (OracleDataAdapter da = new OracleDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (Oracle.ManagedDataAccess.Client.OracleException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }


        private void PrepareCommand(OracleCommand cmd, OracleConnection conn, OracleTransaction trans, string cmdText, OracleParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            cmd.BindByName = true;

            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {
                foreach (OracleParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
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

        #endregion

        /// <summary>
        /// 释放资源
        /// </summary>
        private void close()
        {
            if (conn != null)
            {
                conn.Dispose();
                conn = null;
            }

        }

        ~DbHelperOra()
        {
            close();
        }

        public void Dispose()
        {
            close();
        }
    }
}
