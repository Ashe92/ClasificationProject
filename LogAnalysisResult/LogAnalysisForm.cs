using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogAnalysisProject.Models;

namespace LogAnalysisResult
{
    public partial class LogAnalysisForm : Form
    {
        private LogAnalysis LogAnalysis;
        public LogAnalysisForm(LogAnalysis logAnalysis)
        {
            InitializeComponent();
            LogAnalysis = logAnalysis;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            //load data 
            LoadChartSessionHour();
            LoadChartSessionTotalMinutes();
            LoadChartSessionTotalRequests();
        }

        private void LoadChartSessionTotalRequests()
        {
            //todo
            //uxSessionTotalRequests
            var x = 1;
            LogAnalysis.AllSessions.ForEach(s =>
            {
                uxSessionTotalRequests.Series["Series1"].Points.AddXY(x, s.NumberOfRequests);
                uxSessionTotalMinutes.Series["Series1"].Points.AddXY(x, s.SessionLengthInMinutes);
                uxSessionHour.Series["Series1"].Points.AddXY(x, s.StartDateTime.Hour);
                x++;
            });
        }

        private void LoadChartSessionTotalMinutes()
        {
            //todo
            //uxSessionTotalMinutes
        }

        private void LoadChartSessionHour()
        {
            //todo
            //uxSessionHour
        }
    }
}
