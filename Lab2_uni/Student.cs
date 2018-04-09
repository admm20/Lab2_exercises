using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_uni
{
    class Student
    {
        public int Id { get; set; } // nr indeksu
        public int year { get; set; }
        public String firstName { get; set; } // imie
        public String lastName { get; set; }
        public List<double> grades { get; set; } // oceny
        

        public void AddGrade(double grade)
        {
            grades.Add(grade);
        }

        public Student(String firstName, String lastName, int Id, int year)
        {
            grades = new List<double>();
            this.firstName = firstName;
            this.lastName = lastName;
            this.Id = Id;
            this.year = year;
        }

        public String GetStudentInfo()
        {
            String retVal = (firstName + " " + lastName + " " + Id + " " + year + " ") + (" Oceny: " + String.Join(", ", grades));
            return retVal;
        }



    }
}
