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
        private FlowLayoutPanel pnlResults;
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
            PopulateResults();
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

            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 60));

            lblProblem = new Label
            {
                Text = "Проблема: " + problemDescription,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                ForeColor = Color.DarkRed
            };

            pnlResults = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                Padding = new Padding(5)
            };

            btnClose = new Button
            {
                Text = "Сохранить и вернуться",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Height = 60,
                Dock = DockStyle.Fill,
                BackColor = Color.LightGray
            };
            btnClose.Click += BtnClose_Click;

            layout.Controls.Add(lblProblem, 0, 0);
            layout.Controls.Add(pnlResults, 0, 1);
            layout.Controls.Add(btnClose, 0, 2);

            this.Controls.Add(layout);
        }

        private void PopulateResults()
        {
            pnlResults.Controls.Clear();

            for (int i = 0; i < results.Count; i++)
            {
                var item = results[i];
                string cleanAnswerText = Regex.Replace(item.Text, @"\s*\(.*?\)", "").Trim();

                var questionPanel = new Panel
                {
                    AutoSize = true,
                    AutoSizeMode = AutoSizeMode.GrowAndShrink,
                    Margin = new Padding(5),
                    BorderStyle = BorderStyle.FixedSingle,
                    BackColor = Color.WhiteSmoke,
                    Padding = new Padding(10),
                    Dock = DockStyle.Top
                };

                var stack = new FlowLayoutPanel
                {
                    Dock = DockStyle.Fill,
                    FlowDirection = FlowDirection.TopDown,
                    AutoSize = true,
                    WrapContents = false
                };

                int panelInnerWidth = (int)(pnlResults.ClientSize.Width * 0.98) - questionPanel.Margin.Horizontal - questionPanel.Padding.Horizontal;

                var lblQuestion = CreateCustomLabel($"Вопрос {i + 1}: {item.QuestionText}                                                                                                 ", 16, FontStyle.Bold, panelInnerWidth);
                stack.Controls.Add(lblQuestion);

                // 🔹 Показ всех вариантов ответа
                var lblAnswersHeader = CreateCustomLabel("Варианты ответов:", 14, FontStyle.Bold, panelInnerWidth);
                stack.Controls.Add(lblAnswersHeader);

                for (int optIndex = 0; optIndex < item.AllOptions.Count; optIndex++)
                {
                    bool isSelected = (optIndex == item.SelectedOptionIndex);
                    var lblOption = CreateCustomLabel(
                        (isSelected ? "✔ " : "• ") + item.AllOptions[optIndex],
                        14,
                        isSelected ? FontStyle.Bold : FontStyle.Regular,
                        panelInnerWidth
                    );
                    if (isSelected)
                        lblOption.ForeColor = Color.DarkGreen;
                    stack.Controls.Add(lblOption);
                }

                var lblExplanation = CreateCustomLabel($"Объяснение: {(string.IsNullOrWhiteSpace(item.Explanation) ? "-" : item.Explanation)}", 14, FontStyle.Italic, panelInnerWidth);
                var lblResources = CreateCustomLabel($"Ресурсы: {string.Join(", ", item.Resources)}", 14, FontStyle.Regular, panelInnerWidth);

                stack.Controls.Add(lblExplanation);
                stack.Controls.Add(lblResources);

                questionPanel.Controls.Add(stack);
                pnlResults.Controls.Add(questionPanel);
            }

            pnlResults.Resize += (s, e) => UpdateLabelWidths();
        }

        private void UpdateLabelWidths()
        {
            foreach (Control ctrl in pnlResults.Controls)
            {
                if (ctrl is Panel panel)
                {
                    int panelInnerWidth = (int)(pnlResults.ClientSize.Width * 0.98) - panel.Margin.Horizontal - panel.Padding.Horizontal;

                    foreach (Control inner in panel.Controls)
                    {
                        if (inner is FlowLayoutPanel stack)
                        {
                            foreach (Control lbl in stack.Controls)
                            {
                                if (lbl is Label label)
                                    label.MaximumSize = new Size(panelInnerWidth, 0);
                            }
                        }
                    }
                }
            }
        }

        private Label CreateCustomLabel(string text, int fontSize, FontStyle style, int maxWidth)
        {
            return new Label
            {
                Text = text,
                Font = new Font("Segoe UI", fontSize, style),
                AutoSize = true,
                MaximumSize = new Size(maxWidth, 0),
                Padding = new Padding(5)
            };
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            updateCallback(results);
            this.Close();
            mainForm.Show();
        }
    }

    public class ResultItem
    {
        public string QuestionText { get; set; }
        public string TableText { get; set; } = string.Empty; // <-- новое свойство
        public string Text { get; set; }
        public List<string> Resources { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DurationHours { get; set; }
        public int Cost { get; set; }
        public string? Consequence { get; set; }
        public string Explanation { get; set; }

        public List<string> AllOptions { get; set; }
        public int SelectedOptionIndex { get; set; }

        public ResultItem()
        {
            Resources = new List<string>();
            Explanation = string.Empty;
            AllOptions = new List<string>();
        }
    }

}
