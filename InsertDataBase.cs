using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    class InsertDataTable
    {
        public string ConnString { get; private set; }
        public DeserializationOffers Desoffers { get; private set; }
        public SqlConnection SqlConn { get; private set; }
        public SqlConnectionStringBuilder Connstring { get; private set; }
        public DataTable OffersDataTable { get; private set; }

        public InsertDataTable()
        {
            ConnString = ConfigurationManager.AppSettings["cnStr"]; // получаем строку подключения из app.config

            Desoffers = new DeserializationOffers(); // дессериализуем XML

            OffersDataTable = Convert.ToDataTable<Offer>(Desoffers.Offers.Offer); // конвентируем Offers в DataTable для передачи таблицы в качестве аргумента в хранимую процедуру.

        }

        public void InsertOfferToSQL() 
        {
            using (SqlConn = new SqlConnection(ConnString))
            {
                using (SqlCommand cmd = new SqlCommand("ImportOfferse", SqlConn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@OffersTable", OffersDataTable);
                    SqlConn.Open();
                    cmd.ExecuteNonQuery();
                    SqlConn.Close();

                }
            }

        }

    }
}

