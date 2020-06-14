using DapperWeb.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dapper;

namespace DapperWeb.Controllers
{
    public class CoursesController : Controller
    {
        static string connectionString = ConfigurationManager.ConnectionStrings["DapperSample"].ConnectionString;
        // GET: Courses
        public ActionResult Allcourses()
        {
            using (SqlConnection dbcon = new SqlConnection(connectionString))
            {
                dbcon.Open();
                var courses = new List<Course>();

                courses.AddRange(dbcon.Query<Course>("select * from course"));

                return View(courses);
            }

 
        }
    }
}