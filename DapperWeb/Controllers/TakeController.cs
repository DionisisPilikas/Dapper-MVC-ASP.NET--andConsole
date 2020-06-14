
using DapperWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Mvc;
using Dapper;

namespace DapperWeb.Controllers
{
    public class TakeController : Controller
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DapperSample"].ConnectionString;

        // GET: Students
        public ActionResult Students()
        {
            using (SqlConnection dbcon = new SqlConnection(connectionString))
            {
                dbcon.Open();
                var students = new List<Student>();

                students.AddRange(dbcon.Query<Student>("select * from student"));

                return View(students);
            }
        }

        public ActionResult Trainers()
        {
            using (SqlConnection dbcon = new SqlConnection(connectionString))
            {
                dbcon.Open();

                var trainers = dbcon.Query("select * from trainer");

                return View(trainers);
            }
        }

        public ActionResult Courses()
        {
            using (SqlConnection dbcon = new SqlConnection(connectionString))
            {
                dbcon.Open();
                var courses = dbcon.Query("select * from course");
                return View(courses);

            }

               
        }
    }
}