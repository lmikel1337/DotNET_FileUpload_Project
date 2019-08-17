using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ReadFromFile
{
    class Program
    {
        static void Main(string[] args)
        {         

            string text = ReadFromFileAsOneString();

            ParseWithSplit(text);
            Console.ReadKey();

        }

        static string ReadFromFileAsOneString()
        {

            return System.IO.File.ReadAllText(@"C:\Users\Illya SKvortsov\Desktop\One folder to rule them all\DotNET_FileUpload_Project\Test1_DotNET_FileUpload_Project - Sheet1.csv");

        }

        static void ReadFromFileLineByLine()
        {

            int counter = 0;
            
            string line = null;

            System.IO.StreamReader file = new System.IO.StreamReader(@"C:\Users\Illya SKvortsov\Desktop\One folder to rule them all\DotNET_FileUpload_Project\Test1_DotNET_FileUpload_Project - Sheet1.csv");
            while((line = file.ReadLine()) != null)
            {
                Console.WriteLine(line);
                counter++;
            }

            file.Close();
            Console.WriteLine("There were {0} lines", counter);

        }

        static void ParseWithSplit(string text) //I don't even know what                                                 
        {                                      //the hell is that monstocity below  
            string connString = "Server=tcp:dotnet-file-upload-project-server.database.windows.net,1433;Initial Catalog=database;Persist Security Info=False;User ID=dolvundur;Password=20012325rT;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
            SqlConnection conn = new SqlConnection(connString);

            try
            {
                Console.WriteLine("Connecting to the database...");
                conn.Open();

            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            string[] split = text.Split('\n');
            int splitLength = split.Length;

            int[] rowId = new int[splitLength];

            foreach(int i in rowId)
            {
                rowId[i] = 0;
            }

            Console.WriteLine("foreach loop:\n");
            foreach(var word in split)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine("split:\n{0}", split);
            string[] firstName, lastName, age;
            firstName = new string[splitLength];
            lastName = new string[splitLength];
            age = new string[splitLength];

            string cmdString;
            SqlCommand cmd;

            for (int i = 0; i < splitLength; i++)
            {

                string []secondSplit = split[i].Split(',');

                cmdString = "INSERT INTO ProcessedRow (record_id, row_id, first_name, last_name, age) VALUES (1, '" + i +"', '"+ firstName+"', '"+ lastName +"', '"+ age +"')";
                cmd = new SqlCommand(cmdString, conn);
                cmd.ExecuteNonQuery();

            }
            conn.Close();
            Console.WriteLine("Done");

        }

    }
}
