using LogAnalysisProject.Services;
using System;
using System.Net.Mime;
using System.Windows.Forms;
using LogAnalysisResult;

namespace LogAnalysisProjectConsole
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            AnalysisService analysisService = new AnalysisService();
            var logAnalysis = analysisService.RunAnalysis();
            Application.EnableVisualStyles();
            Application.Run(new LogAnalysisForm(logAnalysis));
            Console.Read();

        }
    }
}
