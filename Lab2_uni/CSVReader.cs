using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2_uni
{
    class CSVReader : IStudentReader
    {
        public List<Student> LoadFromFile()
        {
            List<Student> loadedStudents = new List<Student>();

            string[] lines = null;
            try
            {
                lines = System.IO.File.ReadAllLines("StudentList.txt"); // kazda linia z pliku zostaje wczytana do tablicy string
                foreach (String line in lines)
                {
                    List<string> data = line.Split(';').ToList(); // rozdzielenie danych

                    Student student = new Student(
                        data[0], data[1], // imie - nazwisko
                        int.Parse(data[2]), int.Parse(data[3])); // id - rok
                    for (int a = 3; a < data.Count; a++) // wszystko po roku studiow jest oceną studenta
                    {
                        student.AddGrade(Double.Parse(data[a]));
                    }
                    loadedStudents.Add(student);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Nie mozna znaleźć pliku StudentList.txt");
                Console.ReadKey();
            }

            

            return loadedStudents; // zwraca liste ze studentami
        }

        //STRUKTURA PLIKU:
        //    rozszerzenie: .txt
        //    separator: ';'
        //    przykład: "Adam;Prusak;123456;2;5;5;5;5;4.5"
        //            imie-nazwisko-nr_indeksu-rok-oceny...

        public void SaveToFile(List<Student> students)
        {
            List<string> lines = new List<string>(); // jedna linia = jeden student
            foreach(Student s in students)
            {
                string line = s.firstName + ";" +
                    s.lastName + ";" +
                    s.Id + ";" +
                    s.year + ";";
                if(s.grades != null)
                {
                    line += string.Join(";", s.grades);
                }
                lines.Add(line);
            }
            System.IO.File.WriteAllLines("StudentList.txt", lines); // zapis listy z liniami do pliku
        }
    }
}
