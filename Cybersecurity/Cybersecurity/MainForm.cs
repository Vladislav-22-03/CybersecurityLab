using System;
using System.Windows.Forms;

namespace Cybersecurity
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            this.Text = "Кибербезопасность – Выбор варианта";
            this.WindowState = FormWindowState.Maximized;
            this.Load += MainForm_Load;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CreateVariantButtons();
        }

        private void CreateVariantButtons()
        {
            int buttonWidth = 200;
            int buttonHeight = 80;
            int spacing = 40;
            int cols = 5;
            int rows = 3;

            int totalWidth = cols * buttonWidth + (cols - 1) * spacing;
            int totalHeight = rows * buttonHeight + (rows - 1) * spacing;

            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int startY = (this.ClientSize.Height - totalHeight) / 2;

            for (int i = 0; i < 15; i++)
            {
                int col = i % cols;
                int row = i / cols;

                Button btn = new Button
                {
                    Text = $"Вариант {i + 1}",
                    Width = buttonWidth,
                    Height = buttonHeight,
                    Left = startX + col * (buttonWidth + spacing),
                    Top = startY + row * (buttonHeight + spacing),
                    Font = new System.Drawing.Font("Segoe UI", 14, System.Drawing.FontStyle.Bold),
                    Tag = i
                };

                btn.Click += VariantButton_Click;
                this.Controls.Add(btn);
            }
        }

        private void VariantButton_Click(object sender, EventArgs e)
        {
            if (sender is Button clickedButton && clickedButton.Tag is int variantId)
            {
                Scenario scenario = ScenarioManager.GetScenario(variantId);

                ScenarioForm form = new ScenarioForm(scenario, this);
                form.Show();

                this.Hide();
            }
        }
    }
}
