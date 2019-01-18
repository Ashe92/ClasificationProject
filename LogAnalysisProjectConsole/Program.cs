using LogAnalysisProject.Services;
using System;

namespace LogAnalysisProjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            LogAnalysisService logAnalysisService = new LogAnalysisService();
            logAnalysisService.RunClassification();
            
            Console.Read();

        }
    }
}
