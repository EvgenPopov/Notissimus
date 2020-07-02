using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace ConsoleApp19
{
    public static class Convert //статический класс, для того чтобы конвентировать List<Offer> в DataTable для дальнейшей передачи в качестве параметра хранимой процедуре.

    {
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));

            DataTable table = new DataTable();

            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
            
                table.Rows.Add(row);
            }
            return table;
        }
    }



}

