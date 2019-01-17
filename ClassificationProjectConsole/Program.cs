using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassificationProject.Services;

namespace ClassificationProjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassificationService classificationService = new ClassificationService();
            classificationService.RunClassification();
            Console.Read();

        }
    }
}
