using System;
using CsvHelper;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Third_Party_Library
{
    public class csvHandler
    {
        public static void ImplementCSVhandling()
        {
            string importFilePath = @"D:\BridgeLabz\Third_Party_Library\Third_Party_Library\Utility\Address.csv";
            string exportFilePath = @"D:\BridgeLabz\Third_Party_Library\Third_Party_Library\Utility\Export.csv";

            //reading csv file
            using (var reader=new StreamReader(importFilePath))
            using (var csv=new CsvReader(reader,CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<AddressData>().ToList();
                Console.WriteLine("Read data successfully from address csv");
                foreach(AddressData addressData in records)
                {
                    Console.WriteLine(addressData.firstname);
                    Console.WriteLine(addressData.lastname);
                    Console.WriteLine(addressData.address);
                    Console.WriteLine(addressData.city);
                    Console.WriteLine(addressData.state);
                    Console.WriteLine(addressData.code);
                        
                }
                Console.WriteLine("Reading from csv file and write to csv file");
                using(var writer=new StreamWriter(exportFilePath))
                using (var csvExport=new CsvWriter(writer,CultureInfo.InvariantCulture))
                {
                    csvExport.WriteRecords(records);
                }

            }
        }
            

    }
}
