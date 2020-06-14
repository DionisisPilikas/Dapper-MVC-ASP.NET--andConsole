using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperConsole
{
    class Program
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DapperSample"].ConnectionString;
        static MyDataBase db = new MyDataBase(connectionString);

        static void PrintStudents()
        {
            var Allstudents = db.GetStudents("select * from student");
            if (Allstudents == null)
            {
                Console.WriteLine("DB problem");
                return;
            }

            foreach (var s in Allstudents)
            {
                Console.WriteLine($"StudentID: {s.StudentID}, FirstName: {s.FirstName}, LastName: {s.LastName},dateOfBirth: {s.Dateofbirth}, TuisionFees: {s.Sum_TuisionFees},TotalMark: {s.Avg_TotalMark}");
            }
        }

        static void GetTrainers()
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                try
                {
                    dbcon.Open();
                    var trainers = dbcon.Query("select * from trainer");
                    PrintTrainers(trainers);
                }
                catch (System.Data.Common.DbException dbe)
                {
                    Console.WriteLine(dbe);
                }
            }
        }
        private static void PrintTrainers(IEnumerable<dynamic> allTrainers)
        {
            foreach (var t in allTrainers)
            {
                Console.WriteLine($"TrainerId: {t.TrainerID,-3} Firstname: {t.FIRSTNAME,-15} " +
                    $"lastname: {t.LASTNAME,-15} subject: {t.SUBJECTOFTRAINER,-8}");
            }
        }

        //incert To student
        static void InsertToStudentTable() //insert
        {
            SqlConnection dbcon = new SqlConnection(connectionString);
            using (dbcon)
            {
                dbcon.Open();   //h Execute einaisan thn ExecuteNonQuery()
                string query = "insert into STUDENT VALUES(@FIRSTNAME, @LASTNAME, @DATEOFBIRTH, @SUM_TUITIONFEES,@AVG_TOTALMARK)";
                var affectedRows = dbcon.Execute(query,
                    new
                    {    //Anonymous type object ektos an eixa ena object me ta pedia ayta...
                        firstName = "Albi ",
                        lastName = "Alikai",
                        dateOfBirth = Convert.ToDateTime("23-03-1983"),
                        sum_tuitionfees = 2500,
                        avg_totalmark = 85
                    });

                Console.WriteLine($"{affectedRows} Affected Rows");

            }
        }


        static void Main(string[] args)
        {
            //PrintStudents();
            Console.WriteLine();

            //GetTrainers();
            InsertToStudentTable();

            Console.ReadKey();
        }
    }
}
