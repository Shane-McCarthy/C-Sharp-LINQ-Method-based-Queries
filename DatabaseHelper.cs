using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Homework7_shane
{
    interface IDatabase { 

        string TableName { get; }
        void SetTableName(string tableName);
            DataTable RunSQL();
         }
    class DatabaseHelper :IDatabase
    {
        public delegate void HelperDelegate(string output);
        public event HelperDelegate BeginOutput;
        public event HelperDelegate EndOutput;
        
        private void NotifyBegin() {
            if (BeginOutput != null) {
                BeginOutput("Start DataBase Read"); 
            }
        }
        private void NotifyEnd() {
            if (EndOutput != null)
            {
                EndOutput("End DataBase Read");

            }
        }
        public string TableName { get; set;  }
        void IDatabase.SetTableName(string tableName)
        {
           TableName = tableName; 
        }
       
        DataTable IDatabase.RunSQL() {
            
            string sql = "SELECT * FROM " + TableName; 
            DataTable table = new DataTable();
            try
            {
                string connection
                = ConfigurationManager.ConnectionStrings["MyConnection"]
                                      .ConnectionString;
                SqlDataAdapter adapter = null;
                adapter = new SqlDataAdapter(sql, connection);
                NotifyBegin();
                adapter.Fill(table);

            }
            catch (Exception e)
            {
                Console.WriteLine("The SQL is either invalid or your "
                                + "connection failed.  Please check your "
                                + "App.config reference just in case: "
                                + e.Message);
            }
            NotifyEnd(); 
            return table;
        }
    }
}
