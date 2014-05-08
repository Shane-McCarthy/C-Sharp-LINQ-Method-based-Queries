using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace Homework7_shane
{
    class Program
    {
        public static void OnBeginOutput(string output) {

            Console.WriteLine(output); 
        }
      

        public static void Main()
        {
              string[] MyArray = new string[] { "Product", "Manufacturer" };
              for (int i = 0; i< MyArray.Length; i++) {
            

            DatabaseHelper dataB = new DatabaseHelper();
            dataB.BeginOutput += OnBeginOutput;
            dataB.EndOutput += OnBeginOutput;
            
            IDatabase setDatabase = (IDatabase)dataB;
            setDatabase.SetTableName(MyArray[i]);
            DataTable dt = setDatabase.RunSQL();
            Console.WriteLine();
            
           OutputHelper Mytable = new OutputHelper();
           IOutput myOutput = (IOutput)Mytable;
           myOutput.ShowOutput(dt, MyArray[i]);
           Console.WriteLine();
             //ShowOutput(dt);
              }
            Console.ReadLine();
        }
    }
}
