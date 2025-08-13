using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cybersecurity
{
    public partial class StartForm : Form
    {
        private Label lblTitle;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtGroup;
        private Button btnStart;
        private Panel centerPanel;

        private Dictionary<TextBox, string> placeholders = new();

        public StartForm()
        {
            InitializeComponent();
            this.Text = "Лаба по Кибербезопасности";
            this.WindowState = FormWindowState.Maximized;
            this.BackColor = Color.White;

            InitializeLayout();
            this.Resize += (s, e) => CenterPanel();

            // Снять фокус со всех полей при старте
            this.Load += (s, e) => this.ActiveControl = null;
        }

        private void InitializeLayout()
        {
            centerPanel = new Panel
            {
                Width = 1000,
                Height = 600
            };

            this.Controls.Add(centerPanel);
            CenterPanel();

            lblTitle = new Label
            {
                Text = "Лабораторная работа по Кибербезопасности",
                Font = new Font("Segoe UI", 28, FontStyle.Bold),
                AutoSize = false,
                Width = centerPanel.Width,
                Height = 60,
                Top = 20,
                TextAlign = ContentAlignment.MiddleCenter
            };
            centerPanel.Controls.Add(lblTitle);

            txtLastName = CreatePlaceholderTextBox("Фамилия", 120);
            txtFirstName = CreatePlaceholderTextBox("Имя", 200);
            txtGroup = CreatePlaceholderTextBox("Группа", 280);

            btnStart = new Button
            {
                Text = "Приступить",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Width = 300,
                Height = 60,
                Top = 380,
                Left = (centerPanel.Width - 300) / 2
            };
            btnStart.Click += BtnStart_Click;
            centerPanel.Controls.Add(btnStart);
        }

        private TextBox CreatePlaceholderTextBox(string placeholder, int top)
        {
            var box = new TextBox
            {
                Font = new Font("Segoe UI", 16),
                Width = 400,
                Top = top,
                Left = (centerPanel.Width - 400) / 2,
                ForeColor = Color.Gray,
                Text = placeholder,
                Tag = false
            };

            placeholders[box] = placeholder;

            box.Click += (s, e) =>
            {
                if ((bool)box.Tag == false)
                {
                    box.Text = "";
                    box.ForeColor = Color.Black;
                    box.Tag = true;
                }
            };

            box.Enter += (s, e) =>
            {
                if ((bool)box.Tag == false)
                {
                    box.Text = "";
                    box.ForeColor = Color.Black;
                    box.Tag = true;
                }
            };

            box.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(box.Text))
                {
                    box.Text = placeholder;
                    box.ForeColor = Color.Gray;
                    box.Tag = false;
                }
            };

            centerPanel.Controls.Add(box);
            return box;
        }

        private void CenterPanel()
        {
            if (centerPanel != null)
            {
                centerPanel.Left = (this.ClientSize.Width - centerPanel.Width) / 2;
                centerPanel.Top = (this.ClientSize.Height - centerPanel.Height) / 2;
            }
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            string lastName = txtLastName.Text.Trim();
            string firstName = txtFirstName.Text.Trim();
            string group = txtGroup.Text.Trim();

            if (lastName == placeholders[txtLastName] || firstName == placeholders[txtFirstName] || group == placeholders[txtGroup])
            {
                MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mainForm = new CentralForm();
            this.Hide();
            mainForm.FormClosed += (s, args) => this.Close();
            mainForm.Show();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.ActiveControl = null;
        }
    }
}
