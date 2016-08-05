using System;
using System.Data;
using System.Data.SqlClient;

namespace SqlBulkInsertExample
{
    /// <summary>
    /// Inserts bulk data into database table
    /// </summary>
    public class InsertBulkData
    {
        private string _connection;

        public string Connection
        {
            get { return _connection; }
            set { _connection = value; }
        }

        /// <summary>
        /// Initializes the connection string
        /// </summary>
        public InsertBulkData(string connection)
        {
            this._connection = connection;
        }

        /// <summary>
        /// Inserts bulk data into table
        /// </summary>
        public void InsertData()
        {
            if (string.IsNullOrEmpty(_connection) || string.IsNullOrWhiteSpace(_connection)) throw new ArgumentNullException("Connection string is blank.");
            // Create a table with some rows. 
            DataTable newDeparts = CreateTableData();

            using (SqlBulkCopy bulkCopy = new SqlBulkCopy(_connection))
            {
                bulkCopy.DestinationTableName = "dbo.Departments";

                try
                {
                    // Write from the source to the destination.
                    bulkCopy.WriteToServer(newDeparts);
                }
                catch (Exception ex)
                {
                    //Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }

        /// <summary>
        /// Creates the data for bulk insert
        /// </summary>
        /// <returns></returns>
        private DataTable CreateTableData()
        {
            DataTable newDeparts = new DataTable("Departments");


            // Add three column objects to the table.
            DataColumn id = new DataColumn();
            id.DataType = System.Type.GetType("System.Int32");
            id.ColumnName = "ID";
            id.AutoIncrement = true;
            newDeparts.Columns.Add(id);

            DataColumn departmentName = new DataColumn() { DataType = Type.GetType("System.String"), ColumnName = "Name" };
            newDeparts.Columns.Add(departmentName);

            DataColumn departmentLocation = new DataColumn() { DataType = Type.GetType("System.String"), ColumnName = "Location" };
            newDeparts.Columns.Add(departmentLocation);

            // Add some new rows to the collection. 
            DataRow row = newDeparts.NewRow();
            row["Name"] = "Finance";
            row["Location"] = "Washington";

            newDeparts.Rows.Add(row);
            row = newDeparts.NewRow();
            row["Name"] = "Distribution";
            row["Location"] = "California";

            newDeparts.Rows.Add(row);
            row = newDeparts.NewRow();
            row["Name"] = "Marketing";
            row["Location"] = "Texas";
            newDeparts.Rows.Add(row);

            newDeparts.AcceptChanges();

            // Return the new DataTable. 
            return newDeparts;
        }


    }
}
