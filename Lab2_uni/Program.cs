using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_uni
{
    class Program
    {
        static void Main(string[] args)
        {
            Uni university = new Uni();
            university.LoadFromFile();

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Co chesz zrobić:\n1. Dodaj studenta" +
                    "\n2. Usuń studenta" +
                    "\n3. Oblicz średnią studenta" +
                    "\n4. Oblicz średnią wszystkich studentów" +
                    "\n5. Wyświetl studentów" +
                    "\n6. Zapisz do pliku" +
                    "\n7. Wyjdź" +
                    "\nTwój wybór: ");
                string input = Console.ReadLine();
                int selection = 0;
                try
                {
                    selection = int.Parse(input);
                }
                catch (Exception)
                {
                    Console.WriteLine("Zła opcja");
                    continue;
                }
                switch (selection)
                {
                    case 1:
                        dodaj(university);
                        break;
                    case 2:
                        usun(university);
                        break;
                    case 3:
                        srednia(university);
                        break;
                    case 4:
                        Console.WriteLine("Średnia wszystkich wynosi " +
                            university.getAvgGradeOfAll());
                        Console.ReadKey();
                        break;
                    case 5:
                        university.ShowAllStudents();
                        break;
                    case 6:
                        university.SaveToFile();
                        break;
                    case 7:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Zła opcja");
                        break;
                }

            }
        }

        static void dodaj(Uni u)
        {
            Console.Write("Podaj imie: ");
            string imie = Console.ReadLine();
            Console.Write("Podaj nazwisko: ");
            string nazwisko = Console.ReadLine();
            Console.Write("Podaj nr indeksu: ");
            string indeks = Console.ReadLine();
            Console.Write("Podaj rok: ");
            string rok = Console.ReadLine();

            u.AddStudent(imie, nazwisko, int.Parse(indeks), int.Parse(rok));
        }

        static void usun(Uni u)
        {
            Console.Write("Kogo usunąć: ");
            string indeks = Console.ReadLine();

            u.RemoveStudent(int.Parse(indeks));
        }

        static void srednia(Uni u)
        {
            Console.Write("Podaj nr indeksu: ");
            string indeks = Console.ReadLine();
            Console.WriteLine("Jego średnia to: " + u.GetAvgGrade(int.Parse(indeks)));
            Console.ReadKey();
        }

    }
}
