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
        public static string UpdateAllInformationById { get { return _configuration["UpdateAllInformationById"]; } }
        public static string DeleteInformationById { get { return _configuration["DeleteInformationById"]; } }
        public static string GetDeleteAllInformation { get { return _configuration["GetDeleteAllInformation"]; } }
        public static string DeleteAllInActiveInformation { get { return _configuration["DeleteAllInActiveInformation"]; } }
        public static string ReadInformationById { get { return _configuration["ReadInformationById"]; } }
        public static string UpdateOneInformationById { get { return _configuration["UpdateOneInformationById"]; } }

    }
}
