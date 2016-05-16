using System;
using System.Configuration;
namespace Maticsoft.DBUtility
{

    public class PubConstant
    {
        /// <summary>
        /// 获取备份路径
        /// </summary>
        public static string BackUrl
        {
            get
            {
                string _BackUrl = ConfigurationManager.AppSettings["BackUrl"];
                return _BackUrl;
            }
        }


        /// <summary>
        /// 获取备份路径
        /// </summary>
        public static string RegisterUrl
        {
            get
            {
                string Url = ConfigurationManager.AppSettings["RegisterString"];
                string RegisterUrl = DESEncrypt.Decrypt(Url);

                return RegisterUrl;
            }
        }


        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnSqlString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnSqlString"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }
        /// <summary>
        /// 获取连接字符串
        /// </summary>
        public static string ConnSupDrugDAl
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnSupDrugDAl"];
                string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
                if (ConStringEncrypt == "true")
                {
                    _connectionString = DESEncrypt.Decrypt(_connectionString);
                }
                return _connectionString;
            }
        }
        /// <summary>
        /// 得到web.config里配置项的数据库连接字符串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConnectionString(string configName)
        {
            string connectionString = ConfigurationManager.AppSettings[configName];
            string ConStringEncrypt = ConfigurationManager.AppSettings["ConStringEncrypt"];
            if (ConStringEncrypt == "true")
            {
                connectionString = DESEncrypt.Decrypt(connectionString);
            }
            return connectionString;
        }


    }
}
