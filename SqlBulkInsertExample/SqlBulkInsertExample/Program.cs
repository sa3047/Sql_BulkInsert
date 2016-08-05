using System;
using System.Configuration;

namespace SqlBulkInsertExample
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connection = ConfigurationManager.ConnectionStrings["SampleDBConn"].ConnectionString;
                InsertBulkData insertData = new InsertBulkData(connection);
                insertData.InsertData();
                Console.WriteLine("Bulk Data inserted");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
