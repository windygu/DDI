
using Maticsoft.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DDIV.DAL
{
    public class DAL_ConfigConn
    {

        public bool TestConnectionString(string conn)
        {

            return DbHelperSQL.TestConnectionString(conn);
        }

    }
}
