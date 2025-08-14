using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Cybersecurity
{
    public partial class ScenarioForm : Form
    {
        private Label lblQuestion;
        private RadioButton[] radioOptions = new RadioButton[4];
        private PictureBox[] infoIcons = new PictureBox[4];
        private ToolTip toolTip;
        private Button btnNext;
        private Button btnBack;
        private TextBox txtExplanation;
        private Label lblExplanation;

        private Scenario scenario;
        private List<Step> steps; // универсальный список шагов
        private int currentStepIndex = 0;
        private int[] selectedOptionIndices;
        private string[] explanations;

        private CentralForm centralForm;

        // Конструктор с Scenario
        public ScenarioForm(Scenario scenario, CentralForm centralForm)
        {
            this.scenario = scenario ?? throw new ArgumentNullException(nameof(scenario));
            this.centralForm = centralForm ?? throw new ArgumentNullException(nameof(centralForm));

            steps = scenario.Steps;
            InitStepArrays();

            this.Text = $"Вариант {scenario.VariantId + 1}";
            this.WindowState = FormWindowState.Maximized;

            this.Load += ScenarioForm_Load;
            this.FormClosed += ScenarioForm_FormClosed;
        }

        // Универсальный конструктор с вопросом и таблицей
        public ScenarioForm(string question, List<Option> options, CentralForm centralForm, string explanation = "")
        {
            if (string.IsNullOrWhiteSpace(question))
                throw new ArgumentNullException(nameof(question));
            if (options == null || options.Count != 4)
                throw new ArgumentException("Options должен содержать ровно 4 элемента");

            this.centralForm = centralForm ?? throw new ArgumentNullException(nameof(centralForm));

            steps = new List<Step>
            {
                new Step
                {
                    Question = question,
                    Options = options
                }
            };
            InitStepArrays();
            explanations[0] = explanation;

            this.Text = "Ввод данных";
            this.WindowState = FormWindowState.Maximized;

            this.Load += ScenarioForm_Load;
            this.FormClosed += ScenarioForm_FormClosed;
        }

        private void InitStepArrays()
        {
            selectedOptionIndices = new int[steps.Count];
            explanations = new string[steps.Count];

            for (int i = 0; i < selectedOptionIndices.Length; i++)
            {
                selectedOptionIndices[i] = 0;
                explanations[i] = "";
            }
        }

        private void ScenarioForm_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
            int w = this.ClientSize.Width;
            int h = this.ClientSize.Height;

            lblQuestion = new Label
            {
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                AutoSize = false,
                Width = w - 550,
                Height = 150,
                Left = 100,
                Top = 50
            };
            this.Controls.Add(lblQuestion);

            toolTip = new ToolTip();

            for (int i = 0; i < 4; i++)
            {
                radioOptions[i] = new RadioButton
                {
                    Font = new Font("Segoe UI", 16),
                    AutoSize = true,
                    Left = 100,
                    Top = 220 + i * 90
                };
                this.Controls.Add(radioOptions[i]);

                infoIcons[i] = new PictureBox
                {
                    Size = new Size(30, 30),
                    Image = SystemIcons.Information.ToBitmap(),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Cursor = Cursors.Hand,
                    Top = radioOptions[i].Top + (radioOptions[i].Height - 30) / 2
                };
                this.Controls.Add(infoIcons[i]);
            }

            lblExplanation = new Label
            {
                Text = "Объясните свой выбор",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Left = this.ClientSize.Width - 450,
                Top = 55,
                AutoSize = true
            };
            this.Controls.Add(lblExplanation);

            txtExplanation = new TextBox
            {
                Font = new Font("Segoe UI", 14),
                Multiline = true,
                ScrollBars = ScrollBars.Vertical,
                Width = 400,
                Height = h - 200,
                Left = this.ClientSize.Width - 450,
                Top = 100,
                Text = ""
            };
            txtExplanation.TextChanged += TxtExplanation_TextChanged;
            this.Controls.Add(txtExplanation);

            btnBack = new Button
            {
                Text = "Назад",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Width = 180,
                Height = 70,
                Left = (w / 2) - 190,
                Top = h - 130,
                Enabled = false
            };
            btnBack.Click += BtnBack_Click;
            this.Controls.Add(btnBack);

            btnNext = new Button
            {
                Text = "Далее",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Width = 180,
                Height = 70,
                Left = (w / 2) + 10,
                Top = h - 130,
                Enabled = false
            };
            btnNext.Click += BtnNext_Click;
            this.Controls.Add(btnNext);

            ShowStep();
        }

        private void TxtExplanation_TextChanged(object sender, EventArgs e)
        {
            btnNext.Enabled = !string.IsNullOrWhiteSpace(txtExplanation.Text);
        }

        private void ShowStep()
        {
            var step = steps[currentStepIndex];
            lblQuestion.Text = step.Question;

            for (int i = 0; i < 4; i++)
            {
                radioOptions[i].Text = step.Options[i].Text;
                radioOptions[i].Checked = (selectedOptionIndices[currentStepIndex] == i);

                Size textSize = TextRenderer.MeasureText(radioOptions[i].Text, radioOptions[i].Font);
                radioOptions[i].Width = textSize.Width + 10;
                radioOptions[i].Height = textSize.Height + 10;

                infoIcons[i].Left = radioOptions[i].Left + radioOptions[i].Width + 5;
                infoIcons[i].Top = radioOptions[i].Top + (radioOptions[i].Height - infoIcons[i].Height) / 2;

                string description = step.Options[i].Description ?? "Нет описания";
                toolTip.SetToolTip(infoIcons[i], description);
            }

            txtExplanation.Text = explanations[currentStepIndex];
            btnNext.Enabled = !string.IsNullOrWhiteSpace(txtExplanation.Text);

            btnNext.Text = currentStepIndex == steps.Count - 1 ? "Завершить" : "Далее";
            btnBack.Enabled = currentStepIndex > 0;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            explanations[currentStepIndex] = txtExplanation.Text;
            for (int i = 0; i < 4; i++)
            {
                if (radioOptions[i].Checked)
                {
                    selectedOptionIndices[currentStepIndex] = i;
                    break;
                }
            }

            if (currentStepIndex < steps.Count - 1)
            {
                currentStepIndex++;
                ShowStep();
            }
            else
            {
                ShowResult();
            }
        }

        private void BtnBack_Click(object sender, EventArgs e)
        {
            explanations[currentStepIndex] = txtExplanation.Text;

            if (currentStepIndex > 0)
            {
                currentStepIndex--;
                ShowStep();
            }
        }

        private void ShowResult()
        {
            explanations[currentStepIndex] = txtExplanation.Text;

            if (scenario != null)
            {
                centralForm.SetCurrentScenario(scenario);
            }

            var results = new List<ResultItem>();
            DateTime currentTime = scenario != null ? MoveToNextWorkingTime(scenario.StartTime) : DateTime.Now;

            for (int i = 0; i < steps.Count; i++)
            {
                var step = steps[i];
                var option = step.Options[selectedOptionIndices[i]];
                int hoursToAdd = option.TimeHours;

                DateTime startTime = currentTime;
                DateTime endTime = AddWorkingHours(currentTime, hoursToAdd);

                results.Add(new ResultItem
                {
                    QuestionText = step.Question,
                    TableText = step.Table,
                    Text = option.Text,
                    Resources = option.Resources,
                    StartTime = startTime,
                    EndTime = endTime,
                    DurationHours = option.TimeHours,
                    Cost = option.Cost,
                    Consequence = option.Consequence,
                    Explanation = explanations[i],
                    AllOptions = step.Options.ConvertAll(o => o.Text),
                    SelectedOptionIndex = selectedOptionIndices[i]
                });

                currentTime = endTime;
            }

            var resultForm = new ResultForm(results, scenario?.Incident, this.centralForm, (updatedResults) =>
            {
                this.centralForm.UpdateResults(updatedResults);
            });

            resultForm.FormClosed += (s, e) =>
            {
                this.centralForm.Show();
                this.Close();
            };

            resultForm.Show();
            this.Hide();
        }

        private DateTime MoveToNextWorkingTime(DateTime time)
        {
            while (time.DayOfWeek == DayOfWeek.Saturday || time.DayOfWeek == DayOfWeek.Sunday)
            {
                time = time.AddDays(1).Date.AddHours(8);
            }

            if (time.Hour < 8)
                time = time.Date.AddHours(8);
            else if (time.Hour >= 17)
                time = time.AddDays(1).Date.AddHours(8);
            else if (time.Hour >= 12 && time.Hour < 13)
                time = time.Date.AddHours(13);

            return time;
        }

        private DateTime AddWorkingHours(DateTime start, int hoursToAdd)
        {
            DateTime current = MoveToNextWorkingTime(start);
            int hoursLeft = hoursToAdd;

            while (hoursLeft > 0)
            {
                while (current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday)
                    current = current.AddDays(1).Date.AddHours(8);

                DateTime morningStart = current.Date.AddHours(8);
                DateTime morningEnd = current.Date.AddHours(12);
                DateTime afternoonStart = current.Date.AddHours(13);
                DateTime afternoonEnd = current.Date.AddHours(17);

                if (current < morningStart)
                    current = morningStart;

                if (current >= afternoonEnd)
                {
                    current = current.AddDays(1).Date.AddHours(8);
                    continue;
                }

                DateTime periodEnd;
                if (current < morningEnd)
                    periodEnd = morningEnd;
                else if (current >= afternoonStart)
                    periodEnd = afternoonEnd;
                else
                    periodEnd = afternoonStart;

                int availableHours = (int)(periodEnd - current).TotalHours;
                int hoursToWork = Math.Min(availableHours, hoursLeft);

                current = current.AddHours(hoursToWork);
                hoursLeft -= hoursToWork;

                if (current == morningEnd)
                    current = afternoonStart;
                else if (current == afternoonEnd)
                    current = current.AddDays(1).Date.AddHours(8);
            }

            return current;
        }

        private void ScenarioForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            centralForm.Show();
        }
    }
}
