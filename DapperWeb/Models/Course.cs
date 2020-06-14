using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperWeb.Models
{
    public class Course
    {
        public int CourseID { get; set; }
        public string TITLE { get; set; }
        public string STREAM { get; set; }
        public string TYPE { get; set; }

        public DateTime? STARTDATE { get; set; }
        public DateTime? ENDDATE { get; set; }


    }
}