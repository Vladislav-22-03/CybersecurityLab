using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Cybersecurity
{
    public partial class ResultForm : Form
    {
        private Label lblProblem;
        private DataGridView dgvResults;
        private Button btnClose;
        private Form mainForm;
        private Action<List<ResultItem>> updateCallback;
        private List<ResultItem> results;

        public ResultForm(List<ResultItem> results, string problemDescription, Form mainForm, Action<List<ResultItem>> updateCallback)
        {
            this.mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));
            this.updateCallback = updateCallback ?? throw new ArgumentNullException(nameof(updateCallback));
            this.results = new List<ResultItem>(results);

            this.Text = "Итоговые результаты";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            InitializeComponents(problemDescription);
            InitializeGrid(this.results);
        }

        private void InitializeComponents(string problemDescription)
        {
            var layout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 3,
                ColumnCount = 1,
                Padding = new Padding(20),
            };

            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 80));

            lblProblem = new Label
            {
                Text = "Проблема: " + problemDescription,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.DarkRed
            };

            dgvResults = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            btnClose = new Button
            {
                Text = "Закрыть и вернуться",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Height = 60,
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray
            };
            btnClose.Click += BtnClose_Click;

            layout.Controls.Add(lblProblem, 0, 0);
            layout.Controls.Add(dgvResults, 0, 1);
            layout.Controls.Add(btnClose, 0, 2);

            this.Controls.Add(layout);
        }

        private void InitializeGrid(List<ResultItem> results)
        {
            dgvResults.Columns.Clear();

            dgvResults.Columns.Add("Text", "Ответы");
            dgvResults.Columns.Add("Resources", "Использованные ресурсы");
            dgvResults.Columns.Add("Duration", "Время на устранение (ч)");
            dgvResults.Columns.Add("StartTime", "Начало");
            dgvResults.Columns.Add("EndTime", "Завершение");
            dgvResults.Columns.Add("Cost", "Стоимость (руб)");
            dgvResults.Columns.Add("Consequence", "Последствия");

            foreach (var item in results)
            {
                string cleanText = Regex.Replace(item.Text, @"\s*\(.*?\)", "").Trim();

                dgvResults.Rows.Add(
                    cleanText,
                    string.Join(", ", item.Resources),
                    item.DurationHours,
                    item.StartTime.ToString("g"),
                    item.EndTime.ToString("g"),
                    item.Cost,
                    item.Consequence ?? "-"
                );
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            // Передаем результаты обратно в CentralForm
            updateCallback(results);
            this.Close();
            mainForm.Show();
        }
    }

    public class ResultItem
    {
        public string Text { get; set; }
        public List<string> Resources { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationHours { get; set; }
        public int Cost { get; set; }
        public string? Consequence { get; set; }

        public ResultItem()
        {
            Resources = new List<string>();
        }
    }
}
