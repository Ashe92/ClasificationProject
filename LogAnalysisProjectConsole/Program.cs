using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogAnalysisProject.Services;

namespace LogAnalysisProjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LogAnalysissService logAnalysissService = new LogAnalysissService();
            logAnalysissService.RunClassification();
            Console.Read();

        }
    }
}
