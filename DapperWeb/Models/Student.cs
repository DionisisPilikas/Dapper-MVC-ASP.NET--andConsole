using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperWeb.Models
{
    public class Student
    {
        private int studentID;  //StudentID field in sqlDB is never going to be null
        private string firstName;
        private string lastName;
        private DateTime? dateOfBirth;
        private int? sum_TuisionFees;
        private int? avg_TotalMark;


        public int StudentID { get => studentID; set => studentID = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public DateTime? Dateofbirth { get => dateOfBirth; set => dateOfBirth = value; }
        public int? Sum_TuisionFees { get => sum_TuisionFees; set => sum_TuisionFees = value; }
        public int? Avg_TotalMark { get => avg_TotalMark; set => avg_TotalMark = value; }
        public Student() { } //needs the default constructor
        public Student(int studentID, string firstName, string lastName, DateTime? dateOfBirth, int? sum_TuisionFees, int? avg_TotalMark)
        {
            StudentID = studentID;
            FirstName = firstName;
            LastName = lastName;
            Dateofbirth = dateOfBirth;
            Sum_TuisionFees = sum_TuisionFees;
            Avg_TotalMark = avg_TotalMark;
        }
    }
}