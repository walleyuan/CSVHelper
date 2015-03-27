using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSVHelper.Framework;

namespace CSVHelper.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var csvReader = new CsvFileReader(@"C:\Users\ZYuan\Desktop\Ids for Non-Retail Assets.csv", ',');

            var csvTable = csvReader.ReadDataFromCSV();
        }
    }
}
