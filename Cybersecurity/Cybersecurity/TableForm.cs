using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Cybersecurity
{
    public partial class TableForm : Form
    {
        private DataGridView dgvTable;
        private List<ResultItem> results;
        private string incidentName;

        public TableForm(List<ResultItem> results, string incidentName)
        {
            this.results = results;
            this.incidentName = incidentName;

            this.Text = "Таблица";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label titleLabel = new Label
            {
                Text = $"Таблица для инцидента: {incidentName ?? "-"}",
                Font = new Font("Arial", 28, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 80
            };

            dgvTable = new DataGridView
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect
            };

            InitTableGrid();
            LoadResults();

            this.Controls.Add(dgvTable);
            this.Controls.Add(titleLabel);
        }

        private void InitTableGrid()
        {
            dgvTable.Columns.Clear();

            dgvTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "Text", HeaderText = "Ответы", FillWeight = 200 });
            dgvTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "Resources", HeaderText = "Использованные ресурсы", FillWeight = 150 });
            dgvTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "Duration", HeaderText = "Время (ч)", FillWeight = 70 });
            dgvTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "StartTime", HeaderText = "Начало", FillWeight = 90 });
            dgvTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "EndTime", HeaderText = "Завершение", FillWeight = 90 });
            dgvTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "Cost", HeaderText = "Стоимость", FillWeight = 70 });
            dgvTable.Columns.Add(new DataGridViewTextBoxColumn { Name = "Consequence", HeaderText = "Последствия", FillWeight = 100 });
        }

        private void LoadResults()
        {
            dgvTable.Rows.Clear();
            foreach (var item in results)
            {
                dgvTable.Rows.Add(
                    item.Text,
                    string.Join(", ", item.Resources),
                    item.DurationHours,
                    item.StartTime,
                    item.EndTime,
                    item.Cost,
                    item.Consequence ?? "-"
                );
            }
        }
    }
}
