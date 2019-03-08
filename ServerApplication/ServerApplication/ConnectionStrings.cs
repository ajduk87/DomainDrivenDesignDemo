using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication
{
    public class ConnectionStrings
    {
        private static string pathForDatabase = "C:\\DomainDrivenDesignDemo\\InfrastructureLayer\\Database\\Storages.accdb";

        public static string conn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + pathForDatabase;
    }
}
