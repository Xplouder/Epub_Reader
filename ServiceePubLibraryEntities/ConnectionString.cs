using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceePubLibraryEntities
{
    public static class ConnectionString
    {
        private const string cs = @"data source=(localdb)\ProjectsV12;initial catalog=db_service_epub_library;integrated security=True;multipleactiveresultsets=True";

        public static string GetCs()
        {
            return cs;
        }
    }
}
