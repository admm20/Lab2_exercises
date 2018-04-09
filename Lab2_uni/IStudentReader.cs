using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_uni
{
    interface IStudentReader
    {
        List<Student> LoadFromFile();
        void SaveToFile(List<Student> students);
    }
}
