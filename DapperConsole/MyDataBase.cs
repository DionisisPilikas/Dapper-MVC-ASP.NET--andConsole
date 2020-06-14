using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace DapperConsole
{
    public class MyDataBase
    {
        private string _connectionString;

        public MyDataBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Student> GetStudents(string query)
        {
            List<Student> students = null;
            try
            {
                using (SqlConnection dbcon = new SqlConnection(_connectionString))
                {
                    dbcon.Open();

                    students = new List<Student>();

                    students.AddRange(dbcon.Query<Student>(query)); //'oti query exei na kanei me Student, to trexei h methodos ayth!
                }
            }
            catch (DbException)
            {
                Console.WriteLine("Could not get customers list");
                students = null;
            }
            return students;
        }

    }
}
