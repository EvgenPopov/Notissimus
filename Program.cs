using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Xml.Resolvers;
using System.Xml.Serialization;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Configuration;

namespace ConsoleApp19
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertDataTable OfferInsert = new InsertDataTable();

            OfferInsert.InsertOfferToSQL();
        }
    }

}




