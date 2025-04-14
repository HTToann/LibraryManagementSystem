<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
﻿// UI hiện đại bằng Guna.UI2 + Chart Control

using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Guna.UI2.WinForms;
using BusinessLayer;
using DTOs;
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
﻿using System.Windows.Forms;
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
﻿using System.Windows.Forms;
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535

namespace LibrarySystem
{
    public partial class StatisticsForm : Form
    {
<<<<<<< HEAD
=======
<<<<<<< HEAD
<<<<<<< HEAD
=======
<<<<<<< HEAD
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
        private StatsService _statsService = new StatsService();

        private Guna2Panel menuPanel;
        private Guna2Button btnBorrowPerMonth, btnPenaltyPerMonth, btnTop5Books, btnReturnRate, btnExportChart;
        private Chart chart1;

        public StatisticsForm()
        {
            InitializeComponent();
            InitializeUI();
            CustomizeChart();
        }

        private void InitializeUI()
        {
            this.BackColor = Color.White;
            this.Size = new Size(1000, 600);

            // Left menu
            menuPanel = new Guna2Panel
            {
                Size = new Size(200, this.Height),
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(245, 245, 255)
            };
            this.Controls.Add(menuPanel);

            Label title = new Label
            {
                Text = "📊 Library Statistics",
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.MidnightBlue,
                Location = new Point(10, 20),
                AutoSize = true
            };
            menuPanel.Controls.Add(title);

            btnBorrowPerMonth = CreateButton("BorrowPerMonth", 60, btnBorrowPerMonth_Click);
            btnPenaltyPerMonth = CreateButton("PenaltyPerMonth", 120, btnPenaltyPerMonth_Click);
            btnTop5Books = CreateButton("Top5Books", 180, btnTop5Books_Click);
            btnReturnRate = CreateButton("ReturnRate", 240, btnReturnRate_Click);
            CreateExportButton();
            // Chart
            chart1 = new Chart { Dock = DockStyle.Fill, BackColor = Color.White };
            this.Controls.Add(chart1);
            this.Controls.SetChildIndex(chart1, 0);
        }
        private void CreateExportButton()
        {
            btnExportChart = new Guna2Button
            {
                Text = "📤 Export Chart",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(180, 45),
                Location = new Point(10, 360),
                BorderRadius = 10,
                FillColor = Color.FromArgb(72, 133, 237),
                ForeColor = Color.White,
                HoverState = { FillColor = Color.FromArgb(52, 103, 207) }
            };
            btnExportChart.Click+=btnExportChart_Click;
            menuPanel.Controls.Add(btnExportChart);
        }
        private Guna2Button CreateButton(string text, int top, EventHandler clickEvent)
        {
            var btn = new Guna2Button
            {
                Text = text,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(180, 40),
                Location = new Point(10, top),
                BorderRadius = 6,
                FillColor = Color.FromArgb(100, 103, 207)
            };
            btn.Click += clickEvent;
            btn.HoverState.FillColor = Color.FromArgb(180, 210, 255);
            btn.HoverState.ForeColor = Color.Black;
            menuPanel.Controls.Add(btn);

            return btn;
        }

        private void CustomizeChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas.Clear();
            chart1.Legends.Clear();
            chart1.Titles.Clear();
        
            ChartArea area = new ChartArea("MainArea")
            {
                BackColor = Color.White
            };
            chart1.ChartAreas.Add(area);

            Legend legend = new Legend("MainLegend")
            {
                Docking = Docking.Bottom,
                Font = new Font("Segoe UI", 10),
                Alignment = StringAlignment.Center
            };
            chart1.Legends.Add(legend);
            chart1.BorderlineDashStyle = ChartDashStyle.Solid;
            chart1.BorderlineColor = Color.LightGray;
            chart1.BorderSkin.SkinStyle = BorderSkinStyle.Emboss;
            chart1.ChartAreas[0].Position = new ElementPosition(5, 5, 90, 90);
        }

        private void btnBorrowPerMonth_Click(object sender, EventArgs e)
        {
            CustomizeChart();

            Series series = new Series("Borrows")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true
            };

            var data = _statsService.GetBorrowCountPerMonth();
            foreach (var item in data)
            {
                series.Points.AddXY($"Tháng {item.Month}", item.TotalBorrows);
            }

            chart1.Series.Add(series);
            chart1.Titles.Add("📘 Tổng sách mượn theo tháng");
        }

        private void btnPenaltyPerMonth_Click(object sender, EventArgs e)
        {
            CustomizeChart();

            Series series = new Series("Penalties")
            {
                ChartType = SeriesChartType.Column,
                IsValueShownAsLabel = true,
                Color = Color.IndianRed
            };

            var data = _statsService.GetTotalPenaltyPerMonth();
            foreach (var item in data)
            {
                series.Points.AddXY($"Tháng {item.Month}", item.TotalAmount);
            }

            chart1.Series.Add(series);
            chart1.Titles.Add("💸 Tổng tiền phạt theo tháng");
        }

        private void btnTop5Books_Click(object sender, EventArgs e)
        {
            CustomizeChart();

            Series series = new Series("TopBooks")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            var data = _statsService.GetTop5BorrowedBooks();
            foreach (var item in data)
            {
                series.Points.AddXY(item.BookName, item.BorrowCount);
            }

            chart1.Series.Add(series);
            chart1.Titles.Add("🏆 Top 5 sách được mượn nhiều nhất");
        }

        private void btnReturnRate_Click(object sender, EventArgs e)
        {
            CustomizeChart();

            Series series = new Series("ReturnRate")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true
            };

            var stats = _statsService.GetReturnRate();
            series.Points.AddXY("Đúng hạn", stats.OnTimeCount);
            series.Points.AddXY("Quá hạn", stats.OverdueCount);

            chart1.Series.Add(series);
            chart1.Titles.Add("📈 Tỷ lệ sách trả đúng hạn");
        }
        private void btnExportChart_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Export Chart as Image";
                saveDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp";
                saveDialog.FileName = "Library_Chart";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    ChartImageFormat format = ChartImageFormat.Png;

                    switch (System.IO.Path.GetExtension(saveDialog.FileName).ToLower())
                    {
                        case ".jpg":
                            format = ChartImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            format = ChartImageFormat.Bmp;
                            break;
                    }

                    chart1.SaveImage(saveDialog.FileName, format);
                    MessageBox.Show("Export successful!", "Chart Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
<<<<<<< HEAD
=======
<<<<<<< HEAD
=======
=======
        public StatisticsForm()
        {
            InitializeComponent();
>>>>>>> 747003c6c0ee49c49cb277fd7729b53b13e0a33a
>>>>>>> b30819f7ac3061b7d1b3febe7dfa3e4298670cc2
=======
        public StatisticsForm()
        {
            InitializeComponent();
>>>>>>> 423147175579f23a06d331c889fa94af793ae1c4
>>>>>>> 871a8b6516b92655cf4785302f34199e02192535
        }
    }
}
