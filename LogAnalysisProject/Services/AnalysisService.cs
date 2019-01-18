using System;
using LogAnalysisProject.Models;

namespace LogAnalysisProject.Services
{
    public class AnalysisService
    {
        private FileService _fileService;
        private FileService FileService => _fileService ?? (_fileService = new FileService());

        private LogFileService _logFileService;
        private LogFileService LogFileService => _logFileService ?? (_logFileService = new LogFileService());

        private PrinterService _printerService;
        private PrinterService PrinterService => _printerService ?? (_printerService = new PrinterService());

        private LogAnalysisService _logAnalysisService;
        private LogAnalysisService LogAnalysisService => _logAnalysisService ?? (_logAnalysisService = new LogAnalysisService());

        public LogAnalysis RunAnalysis()
        {
            var fileLines = FileService.GetLogLines();
            var users = LogFileService.CreateListOfUsers(fileLines);
            var userDataAnalysis = LogAnalysisService.CreateLogAnalysis(users);
            Console.WriteLine("Done collecting data");
            return userDataAnalysis;
        }


    }
}
