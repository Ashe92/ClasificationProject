using LogAnalysisProject.Services;
using System;

namespace LogAnalysisProjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            AnalysisService analysisService = new AnalysisService();
            analysisService.RunAnalysis();
            
            Console.Read();

        }
    }
}
