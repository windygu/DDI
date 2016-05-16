
using System.Data;
using System.Text;
using Maticsoft.DBUtility;

namespace DDIV2.DAL
{
    public class DAL_ConfigToSqlParameter
    {
        public DataSet GetList(int configid)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select * FROM DDI_ConfigToSqlParameter Where ConfigId=" + configid.ToString() + "");

            return DbHelperSQL.Query(strSql.ToString());
        }
    }
}
