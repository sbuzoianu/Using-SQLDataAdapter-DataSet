using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using_SQLDataAdapter_DataSet.DataAccess {
 class SqlDataAccess {
        public static string GetConnectionStrings() {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }

        public static string GetCartiPathStrings() {
            return ConfigurationManager.AppSettings["Carti"];
        }
    }
}
