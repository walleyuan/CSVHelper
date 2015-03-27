using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVHelper.Framework;
using System.IO;
using System.Data;

namespace CSVHelper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvReader = new CsvFileReader(@"C:\Users\ZYuan\Desktop\Ids for Non-Retail Assets.csv", ',');

            var csvTable = csvReader.ReadDataFromCSV();

            WriteYmlFile(csvTable);
        }


        private static void WriteYmlFile(DataTable csvTable)
        {

            string path = @"d:\yml.txt";

            if (!File.Exists(path))
            {
                // Create a file to write to. 
                using (StreamWriter sw = File.CreateText(path))
                {

                    foreach (DataRow row in csvTable.Rows)
                    {
                        sw.WriteLine(string.Format("{0}:", row[3]));
                        sw.WriteLine(string.Format(" address: {0}", row[10]));
                        sw.WriteLine(string.Format(" master_id: {0}", row[0]));
                        sw.WriteLine(string.Format(" lat: {0}", row[16]));
                        sw.WriteLine(string.Format(" lng: {0}", row[17]));
                        sw.WriteLine(" maps:");
                        sw.WriteLine(string.Format("    level: {0}", 0));
                        sw.WriteLine(string.Format("    file: {0}", 0));
                    }
                }
            }
        }
    }
}
