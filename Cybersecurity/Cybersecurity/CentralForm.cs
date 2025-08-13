using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cybersecurity
{
    public partial class CentralForm : Form
    {
        private Button selectVariantButton;
        private Button resultsButton;
        private Button calendarButton;
        private DataGridView dgvResults;

        // Список результатов для передачи между формами
        private List<ResultItem> currentResults = new List<ResultItem>();

        // Ссылка на текущий выбранный сценарий
        private Scenario currentScenario;

        public CentralForm()
        {
            this.Text = "CentralForm";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Заголовок
            Label titleLabel = new Label
            {
                Text = "Кибербезопасность",
                Font = new Font("Arial", 36, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 100
            };

            // Основной контейнер
            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 450));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));

            // Левая панель с кнопками
            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(20),
                AutoScroll = true
            };

            selectVariantButton = CreateButton("Выбрать вариант");
            selectVariantButton.Click += SelectVariantButton_Click;

            resultsButton = CreateButton("Результаты");
            resultsButton.Enabled = false;
            resultsButton.Click += ResultsButton_Click;

            calendarButton = CreateButton("Календарь");
            calendarButton.Enabled = false;
            calendarButton.Click += CalendarButton_Click;

            buttonPanel.Controls.Add(selectVariantButton);
            buttonPanel.Controls.Add(resultsButton);
            buttonPanel.Controls.Add(calendarButton);

            // Правая панель с таблицей
            dgvResults = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };
            InitResultsGrid();

            mainLayout.Controls.Add(buttonPanel, 0, 0);
            mainLayout.Controls.Add(dgvResults, 1, 0);

            this.Controls.Add(mainLayout);
            this.Controls.Add(titleLabel);
        }

        private Button CreateButton(string text)
        {
            return new Button
            {
                Text = text,
                Font = new Font("Arial", 20, FontStyle.Bold),
                Size = new Size(380, 100),
                BackColor = Color.LightGray,
                Margin = new Padding(20)
            };
        }

        private void InitResultsGrid()
        {
            dgvResults.Columns.Clear();

            var textColumn = new DataGridViewTextBoxColumn { Name = "Text", HeaderText = "Ответы" };
            var resourcesColumn = new DataGridViewTextBoxColumn { Name = "Resources", HeaderText = "Использованные ресурсы" };
            var durationColumn = new DataGridViewTextBoxColumn { Name = "Duration", HeaderText = "Время (ч)" };
            var startTimeColumn = new DataGridViewTextBoxColumn { Name = "StartTime", HeaderText = "Начало" };
            var endTimeColumn = new DataGridViewTextBoxColumn { Name = "EndTime", HeaderText = "Завершение" };
            var costColumn = new DataGridViewTextBoxColumn { Name = "Cost", HeaderText = "Стоимость" };
            var consequenceColumn = new DataGridViewTextBoxColumn { Name = "Consequence", HeaderText = "Последствия" };

            dgvResults.Columns.AddRange(new DataGridViewColumn[]
            {
                textColumn,
                resourcesColumn,
                durationColumn,
                startTimeColumn,
                endTimeColumn,
                costColumn,
                consequenceColumn
            });

            textColumn.FillWeight = 200;
            resourcesColumn.FillWeight = 150;
            durationColumn.FillWeight = 70;
            startTimeColumn.FillWeight = 90;
            endTimeColumn.FillWeight = 90;
            costColumn.FillWeight = 70;
            consequenceColumn.FillWeight = 100;

            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void RefreshResultsGrid()
        {
            dgvResults.Rows.Clear();
            foreach (var item in currentResults)
            {
                dgvResults.Rows.Add(
                    item.Text,
                    string.Join(", ", item.Resources),
                    item.DurationHours,
                    item.StartTime,
                    item.EndTime,
                    item.Cost,
                    item.Consequence ?? "-"
                );
            }
            resultsButton.Enabled = currentResults.Count > 0;
            calendarButton.Enabled = currentResults.Count > 0;
        }

        private void SelectVariantButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm(this);
            mainForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            mainForm.Show();
        }

        private void ResultsButton_Click(object sender, EventArgs e)
        {
            if (currentScenario == null)
            {
                MessageBox.Show("Сначала выберите вариант сценария!");
                return;
            }

            ResultForm resultForm = new ResultForm(
                currentResults,
                currentScenario.Incident,
                this,
                UpdateResults
            );
            resultForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            resultForm.Show();
        }

        private void CalendarButton_Click(object sender, EventArgs e)
        {
            if (currentResults.Count == 0)
            {
                MessageBox.Show("Нет данных для отображения в календаре.");
                return;
            }

            CalendarForm calendarForm = new CalendarForm(currentResults);
            calendarForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            calendarForm.Show();
        }

        public void UpdateResults(List<ResultItem> results)
        {
            dgvResults.Rows.Clear();
            foreach (var item in results)
            {
                dgvResults.Rows.Add(
                    item.Text,
                    string.Join(", ", item.Resources),
                    item.DurationHours,
                    item.StartTime,
                    item.EndTime,
                    item.Cost,
                    item.Consequence ?? "-"
                );
            }
            currentResults = results;
            resultsButton.Enabled = currentResults.Count > 0;
            calendarButton.Enabled = currentResults.Count > 0;
        }

        public void SetCurrentScenario(Scenario scenario)
        {
            currentScenario = scenario;
        }
    }
}
