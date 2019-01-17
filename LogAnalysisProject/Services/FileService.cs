using LogAnalysisProject.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LogAnalysisProject.Services
{
    public class FileService
    {
        public List<Request> GetLogLines()
        {
            var fileLines = LoadLogFileLines();
            var listOfLines = LoadLinesFromFile(fileLines);

            return listOfLines;
        }

        private string[] LoadLogFileLines()
        {
            try
            {   // Read the stream to a string, and write the string to the console.
                var path = Path.GetDirectoryName(Application.ExecutablePath);
                string[] lines = File.ReadAllLines($@"{path}\\..\\..\\..\\LogAnalysisProject\Resources\log.txt");
                return lines;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }

        private List<Request> LoadLinesFromFile(string[] lines)
        {
            var listOfLines = new List<Request>();
            foreach (var line in lines)
            {
                var fromIndex = 0;
                var toIndex = line.IndexOf(" ", StringComparison.Ordinal);
                var ipString = line.Substring(fromIndex, toIndex);

                fromIndex = line.IndexOf("[", StringComparison.Ordinal) + 1;
                toIndex = line.IndexOf("]", StringComparison.Ordinal) - fromIndex;
                var dateString = line.Substring(fromIndex, toIndex).Split();
                var dateTime = dateString[0];
                var plusTime = dateString[1];

                fromIndex = line.IndexOf('"') + 1;
                toIndex = line.LastIndexOf('"') - fromIndex;
                var pageString = line.Substring(fromIndex, toIndex).Split();
                var requestType = pageString[0];
                var page = pageString[1];
                var pageVersion = pageString[2];

                fromIndex = toIndex + 2;
                toIndex = line.Length - fromIndex;
                var endOfLine = line.Substring(fromIndex, toIndex);
                var done = endOfLine.Split();
                var errCode = done[0];
                var code = done[1];
                var lineObject = new Request()
                {
                    DateTime = dateTime,
                    Ip = ipString,
                    Page = page,
                    PlusTime = plusTime,
                    RequestResponse = code,
                    RequestType = requestType,
                    PageVersion = pageVersion,
                    ErrorCode = errCode,
                };
                listOfLines.Add(lineObject);
                Console.WriteLine($"{ipString} : {dateTime} : {page} :{errCode}: {code}");
            }

            return listOfLines;
        }

        public int[,] ReadCsvFile()
        {
            try
            {   // Read the stream to a string, and write the string to the console.
                var path = Path.GetDirectoryName(Application.ExecutablePath);
                string[] lines = File.ReadAllLines($@"{path}\\..\\..\\..\\LogAnalysisProject\Resources\web-structure.csv");
                int[,] pageStruct = new int[6,6];
                for(int i=0;i< 6; i++)
                {
                    var line = lines[i];
                    var splittedLine = line.Split(';');
                    for (int j = 0; j < splittedLine.Length; j++)
                    {
                        pageStruct[i, j] = Convert.ToInt32(splittedLine[j]);
                    }
                }

                return pageStruct;
            }
            catch (Exception e)
            {
                Console.WriteLine("The file web-structure.csv could not be read:");
                Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
        }
    }
}