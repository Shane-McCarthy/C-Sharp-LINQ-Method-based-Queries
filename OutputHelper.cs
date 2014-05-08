using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Homework7_shane
{
    interface IOutput
    {
        void ShowOutput(DataTable dt, string tableName);
    }
    class OutputHelper : IOutput
    {
       
      
        // Iterate through DataTable rows and columns to show data.
         void IOutput.ShowOutput(DataTable dt,string tableName)
        {
            if (dt == null)
            {
                Console.WriteLine("Empty dataset: Check your SQL.");
                return;
            }
            Console.WriteLine("* Contents for "+ tableName);
               
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataColumn col in dt.Columns)
                {

                    if (col.Ordinal < dt.Columns.Count - 1)
                    {
                        Console.Write(row[col].ToString() + ", ");
                    }
                    else
                    {
                        Console.Write(row[col].ToString());
                    }
                }
                Console.WriteLine();
            }
        }

    }
}
