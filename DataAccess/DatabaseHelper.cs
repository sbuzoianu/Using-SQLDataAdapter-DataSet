using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Using_SQLDataAdapter_DataSet.DataAccess {
    class DatabaseHelper {

        private static readonly string _connectionString = SqlDataAccess.GetConnectionStrings();
        private static readonly string _cartiString = SqlDataAccess.GetCartiPathStrings();
        public static DataSet booksDataSet; 

        public static void Initialisation() {
            using (SqlConnection con = new SqlConnection(_connectionString)) {
                con.Open();
                InserareCarti(con);
                booksDataSet = GetAllBooksFromDatabase(con);
            }

        }

        private static void InserareCarti(SqlConnection con) {
            string cmdText = "Insert into carti (titlu,autor,gen) values (@titlu,@autor,@gen);";

            string cmdDeleteText = "Delete from carti";

            using (SqlCommand cmd = new SqlCommand(cmdDeleteText, con)) {
                cmd.ExecuteNonQuery();
            }

            using (StreamReader reader = new StreamReader(_cartiString)) {
                while (reader.Peek() >= 0) {
                    String line = reader.ReadLine();
                    var spittedline = line.Split('*');
                    using (SqlCommand cmd = new SqlCommand(cmdText, con)) {
                        cmd.Parameters.AddWithValue("titlu", spittedline[0]);
                        cmd.Parameters.AddWithValue("autor", spittedline[1]);
                        cmd.Parameters.AddWithValue("gen", spittedline[2]);

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private static DataSet GetAllBooksFromDatabase(SqlConnection con) {
            // SQLDataAdapter este utilizat pentru a citi datele din baza de date
            // și pentru a lega acele date la DataSet.
            SqlDataAdapter da = new SqlDataAdapter("select * from carti", con);

            DataSet ds = new DataSet();
            da.Fill(ds, "carti");
            //Tables: reprezinta o colectie de table-uri continute in DataSet.
            foreach (DataRow row in ds.Tables["carti"].Rows) {
                Console.WriteLine(row["titlu"] + ",  " + row["autor"] + ",  " + row["gen"]);
                //poate fi folosit si folosind indexare 
                //Console.WriteLine(row[0] + ",  " + row[1] + ",  " + row[2]);
            }
            return ds;
        }

    }
}
