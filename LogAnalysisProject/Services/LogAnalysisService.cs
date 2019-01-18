using System;

namespace LogAnalysisProject.Services
{
    public class LogAnalysisService
    {
        private FileService _fileService;
        private FileService FileService => _fileService ?? (_fileService = new FileService());

        private LogFileService _logFileService;
        private LogFileService LogFileService => _logFileService ?? (_logFileService = new LogFileService());

        private PrinterService _printerService;
        private PrinterService PrinterService => _printerService ?? (_printerService = new PrinterService());

        private AnalysisService _analysisService;
        private AnalysisService AnalysisService => _analysisService ?? (_analysisService = new AnalysisService());

        public void RunClassification()
        {
            var fileLines = FileService.GetLogLines();
            var users = LogFileService.CreateListOfUsers(fileLines);
            var userDataAnalysis = AnalysisService.CreateLogAnalysis(users);
            Console.WriteLine("Done collecting data");
            PrinterService.PrintData(userDataAnalysis);
            Console.WriteLine("Done");
        }

        
    }
}
