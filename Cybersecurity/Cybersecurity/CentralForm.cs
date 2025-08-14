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
        private Button tableButton;
        private DataGridView dgvCentralTable;

        private List<ResultItem> currentResults = new List<ResultItem>();
        private Scenario currentScenario;

        public CentralForm()
        {
            this.Text = "CentralForm";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label titleLabel = new Label
            {
                Text = "Кибербезопасность",
                Font = new Font("Arial", 36, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 100
            };

            selectVariantButton = CreateButton("Выбрать вариант");
            selectVariantButton.Click += SelectVariantButton_Click;

            resultsButton = CreateButton("Результаты");
            resultsButton.Enabled = false;
            resultsButton.Click += ResultsButton_Click;

            calendarButton = CreateButton("Календарь");
            calendarButton.Enabled = false;
            calendarButton.Click += CalendarButton_Click;

            tableButton = CreateButton("Таблица");
            tableButton.Enabled = false;
            tableButton.Click += TableButton_Click;

            FlowLayoutPanel buttonPanel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight,
                AutoSize = true,
                WrapContents = false,
                Padding = new Padding(0),
                Margin = new Padding(0)
            };
            buttonPanel.Controls.Add(selectVariantButton);
            buttonPanel.Controls.Add(resultsButton);
            buttonPanel.Controls.Add(calendarButton);
            buttonPanel.Controls.Add(tableButton);

            Panel buttonContainer = new Panel
            {
                Dock = DockStyle.Top,
                Height = selectVariantButton.Height + 20
            };
            buttonContainer.Controls.Add(buttonPanel);

            buttonContainer.Resize += (s, e) =>
            {
                buttonPanel.Left = (buttonContainer.Width - buttonPanel.Width) / 2;
                buttonPanel.Top = (buttonContainer.Height - buttonPanel.Height) / 2;
            };

            dgvCentralTable = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None, // фиксированная ширина
                RowHeadersVisible = false,
                Font = new Font("Arial", 12),
                SelectionMode = DataGridViewSelectionMode.CellSelect
            };

            dgvCentralTable.DefaultCellStyle.SelectionBackColor = Color.Transparent;
            dgvCentralTable.DefaultCellStyle.SelectionForeColor = Color.Black;

            InitCentralTable();

            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            mainLayout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            mainLayout.Controls.Add(buttonContainer, 0, 0);
            mainLayout.Controls.Add(dgvCentralTable, 0, 1);

            this.Controls.Add(mainLayout);
            this.Controls.Add(titleLabel);
        }

        private Button CreateButton(string text)
        {
            return new Button
            {
                Text = text,
                Font = new Font("Arial", 16, FontStyle.Bold),
                Size = new Size(180, 60),
                BackColor = Color.LightGray,
                Margin = new Padding(10)
            };
        }

        private void InitCentralTable()
        {
            dgvCentralTable.Columns.Clear();
            dgvCentralTable.Rows.Clear();

            dgvCentralTable.DefaultCellStyle.WrapMode = DataGridViewTriState.True; // перенос текста в ячейках
            dgvCentralTable.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True; // перенос текста в заголовках
            dgvCentralTable.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; // авто-высота строк
            dgvCentralTable.RowTemplate.Height = 40;

            dgvCentralTable.CurrentCell = null;
        }

        public void UpdateResults(List<ResultItem> results)
        {
            dgvCentralTable.Rows.Clear();
            dgvCentralTable.Columns.Clear();

            int columnCount = results.Count;

            // Добавляем колонки
            for (int i = 0; i < columnCount; i++)
            {
                dgvCentralTable.Columns.Add("Q" + i, results[i].TableText);
            }

            // Фиксированная ширина колонок
            int equalWidth = dgvCentralTable.Width / columnCount;
            foreach (DataGridViewColumn col in dgvCentralTable.Columns)
            {
                col.Width = equalWidth;
            }
            dgvCentralTable.ColumnHeadersHeight = 150;
            // Определяем максимальное количество вариантов ответов
            int maxOptions = 0;
            foreach (var item in results)
                if (item.AllOptions.Count > maxOptions)
                    maxOptions = item.AllOptions.Count;

            // Заполняем таблицу вариантами
            for (int rowIndex = 0; rowIndex < maxOptions; rowIndex++)
            {
                int rowNumber = dgvCentralTable.Rows.Add();
                for (int colIndex = 0; colIndex < results.Count; colIndex++)
                {
                    var item = results[colIndex];
                    if (rowIndex < item.AllOptions.Count)
                    {
                        dgvCentralTable.Rows[rowNumber].Cells[colIndex].Value = item.AllOptions[rowIndex];
                        if (rowIndex == item.SelectedOptionIndex)
                        {
                            dgvCentralTable.Rows[rowNumber].Cells[colIndex].Style.BackColor = Color.LightGreen;
                            dgvCentralTable.Rows[rowNumber].Cells[colIndex].Style.Font = new Font(dgvCentralTable.Font, FontStyle.Bold);
                        }
                    }
                }
            }

            currentResults = results;
            resultsButton.Enabled = currentResults.Count > 0;
            calendarButton.Enabled = currentResults.Count > 0;
            tableButton.Enabled = currentResults.Count > 0;

            dgvCentralTable.CurrentCell = null;
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

        private void TableButton_Click(object sender, EventArgs e)
        {
            if (currentResults.Count == 0 || currentScenario == null)
            {
                MessageBox.Show("Нет данных для отображения таблицы.");
                return;
            }

            TableForm tableForm = new TableForm(currentResults, currentScenario.Incident);
            tableForm.FormClosed += (s, args) => this.Show();
            this.Hide();
            tableForm.Show();
        }

        public void SetCurrentScenario(Scenario scenario)
        {
            currentScenario = scenario;
        }
    }
}
