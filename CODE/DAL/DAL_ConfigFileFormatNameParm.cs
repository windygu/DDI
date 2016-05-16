using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace DDIV2.DAL
{
    public class DAL_ConfigFileFormatNameParm
    {
        public DataSet GetList(int configid)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * FROM DDI_ConfigFileFormatNameParm Where ConfigId=" + configid.ToString() + " order by Id ");

            return DbHelperSQL.Query(strSql.ToString());
            
        }
        
    }
}
