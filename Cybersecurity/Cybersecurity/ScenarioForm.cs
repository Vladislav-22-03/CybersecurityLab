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

        private Scenario scenario;
        private int currentStepIndex = 0;
        private int[] selectedOptionIndices;

        private Form mainForm;

        public ScenarioForm(Scenario scenario, Form mainForm)
        {
            this.scenario = scenario ?? throw new ArgumentNullException(nameof(scenario));
            this.mainForm = mainForm ?? throw new ArgumentNullException(nameof(mainForm));

            selectedOptionIndices = new int[scenario.Steps.Count];
            for (int i = 0; i < selectedOptionIndices.Length; i++)
                selectedOptionIndices[i] = 0;

            this.Text = $"Вариант {scenario.VariantId + 1}";
            this.WindowState = FormWindowState.Maximized;

            this.Load += ScenarioForm_Load;
            this.FormClosed += ScenarioForm_FormClosed;
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
                Width = w - 200,
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
                Top = h - 130
            };
            btnNext.Click += BtnNext_Click;
            this.Controls.Add(btnNext);

            ShowStep();
        }

        private void ShowStep()
        {
            var step = scenario.Steps[currentStepIndex];
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

            btnNext.Text = currentStepIndex == scenario.Steps.Count - 1 ? "Завершить" : "Далее";

            btnBack.Enabled = currentStepIndex > 0;
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                if (radioOptions[i].Checked)
                {
                    selectedOptionIndices[currentStepIndex] = i;
                    break;
                }
            }

            if (currentStepIndex < scenario.Steps.Count - 1)
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
            if (currentStepIndex > 0)
            {
                currentStepIndex--;
                ShowStep();
            }
        }

        private void ShowResult()
        {
            var results = new List<ResultItem>();
            DateTime currentTime = MoveToNextWorkingTime(scenario.StartTime);

            for (int i = 0; i < scenario.Steps.Count; i++)
            {
                var option = scenario.Steps[i].Options[selectedOptionIndices[i]];
                int hoursToAdd = option.TimeHours;

                DateTime startTime = currentTime;
                DateTime endTime = AddWorkingHours(currentTime, hoursToAdd);

                int duration = option.TimeHours;

                results.Add(new ResultItem
                {
                    Text = option.Text,              
                    Resources = option.Resources,
                    StartTime = startTime,
                    EndTime = endTime,
                    DurationHours = duration,
                    Cost = option.Cost,
                    Consequence = option.Consequence
                });

                currentTime = endTime;
            }

            var resultForm = new ResultForm(results, scenario.Incident, this.mainForm);
            resultForm.FormClosed += (s, e) =>
            {
                this.mainForm.Show();
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
            {
                time = time.Date.AddHours(8);
            }
            else if (time.Hour >= 17 || (time.Hour == 16 && time.Minute > 0))
            {
                time = time.AddDays(1).Date.AddHours(8);
                while (time.DayOfWeek == DayOfWeek.Saturday || time.DayOfWeek == DayOfWeek.Sunday)
                {
                    time = time.AddDays(1);
                }
            }
            else if (time.Hour >= 12 && time.Hour < 13)
            {
                time = time.Date.AddHours(13);
            }

            return time;
        }

        private DateTime AddWorkingHours(DateTime start, int hoursToAdd)
        {
            DateTime current = MoveToNextWorkingTime(start);
            int hoursLeft = hoursToAdd;

            while (hoursLeft > 0)
            {
                while (current.DayOfWeek == DayOfWeek.Saturday || current.DayOfWeek == DayOfWeek.Sunday)
                {
                    current = current.AddDays(1).Date.AddHours(8);
                }

                DateTime workStartMorning = current.Date.AddHours(8);
                DateTime workEndMorning = current.Date.AddHours(12);
                DateTime workStartAfternoon = current.Date.AddHours(13);
                DateTime workEndAfternoon = current.Date.AddHours(17);

                if (current < workStartMorning)
                {
                    current = workStartMorning;
                }

                if (current >= workEndAfternoon)
                {
                    current = current.AddDays(1).Date.AddHours(8);
                    continue;
                }

                if (current >= workStartMorning && current < workEndMorning)
                {
                    int availableHours = (int)(workEndMorning - current).TotalHours;
                    int hoursToWork = Math.Min(availableHours, hoursLeft);
                    current = current.AddHours(hoursToWork);
                    hoursLeft -= hoursToWork;

                    if (hoursLeft > 0 && current == workEndMorning)
                    {
                        current = current.Date.AddHours(13);
                    }
                }
                else if (current >= workStartAfternoon && current < workEndAfternoon)
                {
                    int availableHours = (int)(workEndAfternoon - current).TotalHours;
                    int hoursToWork = Math.Min(availableHours, hoursLeft);
                    current = current.AddHours(hoursToWork);
                    hoursLeft -= hoursToWork;
                }
                else if (current >= workEndMorning && current < workStartAfternoon)
                {
                    current = current.Date.AddHours(13);
                }
                else
                {
                    current = current.Date.AddDays(1).AddHours(8);
                }
            }

            return current;
        }

        private void ScenarioForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            mainForm.Show();
        }
    }
}
