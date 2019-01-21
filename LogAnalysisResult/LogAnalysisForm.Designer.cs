namespace LogAnalysisResult
{
    partial class LogAnalysisForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.uxTabs = new System.Windows.Forms.TabControl();
            this.uxTabHour = new System.Windows.Forms.TabPage();
            this.uxTabTotalMinutes = new System.Windows.Forms.TabPage();
            this.uxTabTotalRequests = new System.Windows.Forms.TabPage();
            this.uxSessionHour = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.uxSessionTotalMinutes = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.uxSessionTotalRequests = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.uxTabs.SuspendLayout();
            this.uxTabHour.SuspendLayout();
            this.uxTabTotalMinutes.SuspendLayout();
            this.uxTabTotalRequests.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxSessionHour)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxSessionTotalMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxSessionTotalRequests)).BeginInit();
            this.SuspendLayout();
            // 
            // uxTabs
            // 
            this.uxTabs.Controls.Add(this.uxTabHour);
            this.uxTabs.Controls.Add(this.uxTabTotalMinutes);
            this.uxTabs.Controls.Add(this.uxTabTotalRequests);
            this.uxTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uxTabs.Location = new System.Drawing.Point(0, 0);
            this.uxTabs.Name = "uxTabs";
            this.uxTabs.SelectedIndex = 0;
            this.uxTabs.Size = new System.Drawing.Size(1099, 505);
            this.uxTabs.TabIndex = 3;
            // 
            // uxTabHour
            // 
            this.uxTabHour.Controls.Add(this.uxSessionHour);
            this.uxTabHour.Location = new System.Drawing.Point(4, 22);
            this.uxTabHour.Name = "uxTabHour";
            this.uxTabHour.Padding = new System.Windows.Forms.Padding(3);
            this.uxTabHour.Size = new System.Drawing.Size(1091, 479);
            this.uxTabHour.TabIndex = 0;
            this.uxTabHour.Text = "Godzina rozpoczęcia sesji";
            this.uxTabHour.UseVisualStyleBackColor = true;
            // 
            // uxTabTotalMinutes
            // 
            this.uxTabTotalMinutes.Controls.Add(this.uxSessionTotalMinutes);
            this.uxTabTotalMinutes.Location = new System.Drawing.Point(4, 22);
            this.uxTabTotalMinutes.Name = "uxTabTotalMinutes";
            this.uxTabTotalMinutes.Padding = new System.Windows.Forms.Padding(3);
            this.uxTabTotalMinutes.Size = new System.Drawing.Size(1091, 479);
            this.uxTabTotalMinutes.TabIndex = 1;
            this.uxTabTotalMinutes.Text = "Czas sesji[min]";
            this.uxTabTotalMinutes.UseVisualStyleBackColor = true;
            // 
            // uxTabTotalRequests
            // 
            this.uxTabTotalRequests.Controls.Add(this.uxSessionTotalRequests);
            this.uxTabTotalRequests.Location = new System.Drawing.Point(4, 22);
            this.uxTabTotalRequests.Name = "uxTabTotalRequests";
            this.uxTabTotalRequests.Padding = new System.Windows.Forms.Padding(3);
            this.uxTabTotalRequests.Size = new System.Drawing.Size(1091, 479);
            this.uxTabTotalRequests.TabIndex = 2;
            this.uxTabTotalRequests.Text = "Ilośc żądań";
            this.uxTabTotalRequests.UseVisualStyleBackColor = true;
            // 
            // uxSessionHour
            // 
            chartArea1.Name = "ChartArea1";
            this.uxSessionHour.ChartAreas.Add(chartArea1);
            this.uxSessionHour.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.uxSessionHour.Legends.Add(legend1);
            this.uxSessionHour.Location = new System.Drawing.Point(3, 3);
            this.uxSessionHour.Name = "uxSessionHour";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.uxSessionHour.Series.Add(series1);
            this.uxSessionHour.Size = new System.Drawing.Size(1085, 473);
            this.uxSessionHour.TabIndex = 0;
            this.uxSessionHour.Text = "chart1";
            // 
            // uxSessionTotalMinutes
            // 
            chartArea2.Name = "ChartArea1";
            this.uxSessionTotalMinutes.ChartAreas.Add(chartArea2);
            this.uxSessionTotalMinutes.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.uxSessionTotalMinutes.Legends.Add(legend2);
            this.uxSessionTotalMinutes.Location = new System.Drawing.Point(3, 3);
            this.uxSessionTotalMinutes.Name = "uxSessionTotalMinutes";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.uxSessionTotalMinutes.Series.Add(series2);
            this.uxSessionTotalMinutes.Size = new System.Drawing.Size(1085, 473);
            this.uxSessionTotalMinutes.TabIndex = 0;
            this.uxSessionTotalMinutes.Text = "chart2";
            // 
            // uxSessionTotalRequests
            // 
            chartArea3.Name = "ChartArea1";
            this.uxSessionTotalRequests.ChartAreas.Add(chartArea3);
            this.uxSessionTotalRequests.Dock = System.Windows.Forms.DockStyle.Fill;
            legend3.Name = "Legend1";
            this.uxSessionTotalRequests.Legends.Add(legend3);
            this.uxSessionTotalRequests.Location = new System.Drawing.Point(3, 3);
            this.uxSessionTotalRequests.Name = "uxSessionTotalRequests";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.uxSessionTotalRequests.Series.Add(series3);
            this.uxSessionTotalRequests.Size = new System.Drawing.Size(1085, 473);
            this.uxSessionTotalRequests.TabIndex = 0;
            this.uxSessionTotalRequests.Text = "Ilość ządań dla sesji";
            // 
            // LogAnalysisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 505);
            this.Controls.Add(this.uxTabs);
            this.Name = "LogAnalysisForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.uxTabs.ResumeLayout(false);
            this.uxTabHour.ResumeLayout(false);
            this.uxTabTotalMinutes.ResumeLayout(false);
            this.uxTabTotalRequests.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxSessionHour)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxSessionTotalMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxSessionTotalRequests)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl uxTabs;
        private System.Windows.Forms.TabPage uxTabHour;
        private System.Windows.Forms.DataVisualization.Charting.Chart uxSessionHour;
        private System.Windows.Forms.TabPage uxTabTotalMinutes;
        private System.Windows.Forms.DataVisualization.Charting.Chart uxSessionTotalMinutes;
        private System.Windows.Forms.TabPage uxTabTotalRequests;
        private System.Windows.Forms.DataVisualization.Charting.Chart uxSessionTotalRequests;
    }
}

