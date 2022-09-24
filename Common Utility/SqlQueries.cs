using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudApplicationwithMySql.Common_Utility
{
    public class SqlQueries
    {
        public static IConfiguration _configuration = new ConfigurationBuilder().AddXmlFile("SqlQueries.xml", true, true).Build();

        public static string AddInformation { get { return _configuration["AddInformation"]; } }
        public static string ReadAllInformation { get { return _configuration["ReadAllInformation"]; } }

    }
}
