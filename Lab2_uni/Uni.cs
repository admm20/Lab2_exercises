using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_uni
{
    class Uni
    {
        List<Student> students; // lista studentów - lepiej zrobić mapę
        List<double> possibleGrades; // lista możliwych ocen

        public Uni()
        {
            students = new List<Student>();
            possibleGrades = new List<double>();

            double[] grades = { 2, 3, 3.5, 4, 4.5, 5 };
            possibleGrades.AddRange(grades);
        }

        public void AddStudent(string firstName, string lastName, int Id, int year)
        {
            Student newStudent = new Student(firstName, lastName, Id, year);

            Console.WriteLine("Prosze podać oceny oddzielone przecinkiem (np. '4.5,5,5'): ");


            string input = Console.ReadLine();

            List<String> sGrades = input.Split(',').ToList();
            List<double> grades = new List<double>();

            bool caughtException = false;

            foreach(String g in sGrades)
            {
                double singleGrade = 0.0;
                try
                {
                   singleGrade = Double.Parse(g, CultureInfo.InvariantCulture);
                }
                catch
                {
                    Console.WriteLine("Podano nieprawidłowe liczby. Student nie zostanie dodany");
                    caughtException = true;
                    break;
                }

                if (possibleGrades.Contains(singleGrade))
                {
                    newStudent.AddGrade(singleGrade);
                }
                else
                {
                    Console.WriteLine("Nie dodano oceny " + singleGrade);
                }
            }
            
            if(!caughtException)
                students.Add(newStudent);
        }

        public void RemoveStudent(int Id)
        {
            // usuwanie wszystkich studentów z listy o podanym numerze indeksu
            foreach(Student s in students)
            {
                if(s.Id == Id)
                {
                    students.Remove(s);
                    break;
                }
            }
        }

        public double GetAvgGrade(int Id)
        {
            foreach(Student s in students)
            {
                if(s.Id == Id)
                {
                    double avgGrade = s.grades.Average();
                    return avgGrade;
                }
            }

            return 0.0;
        }

        public void ShowAllStudents()
        {
            foreach(Student s in students)
            {
                Console.WriteLine(s.GetStudentInfo());
            }
            Console.WriteLine("Kliknij przycisk by wyjść");
            Console.ReadKey();
        }

        public double getAvgGradeOfAll()
        {
            int count = 0;
            double sum = 0;
            foreach(Student s in students)
            {
                count++;
                sum += s.grades.Average();
            }
            return (sum / count);
        }

        public void SaveToFile()
        {
            IStudentReader r = new CSVReader();
            r.SaveToFile(students);
        }

        public void LoadFromFile()
        {
            IStudentReader r = new CSVReader();
            students = r.LoadFromFile();
        }
        


    }
}
