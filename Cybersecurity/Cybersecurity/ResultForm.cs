using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cybersecurity
{
    public partial class ResultForm : Form
    {
        private Label lblProblem;
        private DataGridView dgvResults;
        private Button btnClose;
        private Form mainForm;

        public ResultForm(List<ResultItem> results, string problemDescription, Form mainForm)
        {
            this.mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));

            this.Text = "Итоговые результаты";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            InitializeComponents(problemDescription);
            InitializeGrid(results);
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

            // Заголовок с проблемой
            lblProblem = new Label
            {
                Text = "Проблема: " + problemDescription,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.DarkRed
            };

            // Таблица
            dgvResults = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            // Кнопка закрытия
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

            dgvResults.Columns.Add("Action", "Действие");
            dgvResults.Columns.Add("Resources", "Использованные ресурсы");
            dgvResults.Columns.Add("Duration", "Время на устранение (ч)");
            dgvResults.Columns.Add("StartTime", "Начало");
            dgvResults.Columns.Add("EndTime", "Завершение");
            dgvResults.Columns.Add("Cost", "Стоимость (руб)");
            dgvResults.Columns.Add("Consequence", "Последствия");

            foreach (var item in results)
            {
                dgvResults.Rows.Add(
                    item.Action,
                    string.Join(", ", item.Resources),
                    item.DurationHours.ToString(),
                    item.StartTime.ToString("g"),
                    item.EndTime.ToString("g"),
                    item.Cost.ToString(),
                    item.Consequence ?? "-"
                );
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            mainForm.Show(); // Показываем главную форму
        }
    }

    public class ResultItem
    {
        public string Action { get; set; }
        public List<string> Resources { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationHours { get; set; }
        public int Cost { get; set; }
        public string? Consequence { get; set; }
    }
}
