using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Configuration;




namespace ConsoleApp19
{
    class DeserializationOffers // Класс для дессериализации XML файла.
    {
        public Offers Offers { get; set; } = null;

        public DeserializationOffers()
        {
            DesOffers();
        }

        public void DesOffers()
        {
            XmlSerializer xs = new XmlSerializer(typeof(Catalog));

            using (Stream fs = File.OpenRead(("YML.xml"))) 
            {
                Catalog catalog = (Catalog)xs.Deserialize(fs);

                Offers = catalog.Shop.Offers;
            }

        }

    }
}
