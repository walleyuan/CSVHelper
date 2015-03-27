using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace CSVHelper.Framework
{

    public class CsvFileReader
    {
        private char Delimiter { get; set; }
        private string CSVFile { get; set; }


        public CsvFileReader(string csvFile, char delimiter)
        {

            Delimiter = delimiter;
            CSVFile = csvFile;
        }


        public DataTable ReadDataFromCSV()
        {

            using (var textReader = new StreamReader(CSVFile))
            {
                var csvTable = new DataTable();

                string line = textReader.ReadLine();

                string[] columns = line.Split(Delimiter);

                foreach (var column in columns)
                {
                    csvTable.Columns.Add(new DataColumn
                    {
                        ColumnName = column
                    });
                }

                line = textReader.ReadLine();

                while (line != null)
                {
                    DataRow newRow = csvTable.NewRow();
                    
                    var quote = 0;
                    var columnContent = string.Empty;
                    var columnIndex = 0;
                                       
                    
                    foreach (var c in line.ToCharArray())
                    {
                        switch (c)
                        {
                            case '\"':

                                quote++;
                                
                                break;

                            case ',':
                                if (quote == 1)
                                {
                                    columnContent += c;
                                }
                                else
                                {
                                    newRow[columnIndex] = columnContent;
                                    columnContent = string.Empty;
                                    columnIndex++;
                                    quote = 0;
                                }
                                break;

                            default:
                                columnContent += c;
                                break;
                        }
                    }

                    //add value to last column
                    newRow[columnIndex] = columnContent;
                    
                    csvTable.Rows.Add(newRow);
                    line = textReader.ReadLine();
                }

                return csvTable;
            }
        }
    }
}

