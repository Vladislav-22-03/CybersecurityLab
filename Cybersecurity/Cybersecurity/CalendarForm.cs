using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Cybersecurity
{
    public partial class CalendarForm : Form
    {
        private MonthCalendar monthCalendar;

        public CalendarForm(List<ResultItem> results)
        {
            this.Text = "Календарь работ";
            this.WindowState = FormWindowState.Maximized; // Полный экран
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            // Создаём надпись
            Label infoLabel = new Label
            {
                Text = "Жирным цветом выделены дни, за которые решается проблема",
                Font = new Font("Arial", 20, FontStyle.Bold),
                ForeColor = Color.Black,
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter
            };

            monthCalendar = new MonthCalendar
            {
                Dock = DockStyle.None, // Чтобы можно было центрировать
                MaxSelectionCount = 1,
                ShowToday = true,
                ShowTodayCircle = true
            };

            // Увеличиваем размеры
            monthCalendar.Size = new Size(900, 600);
            monthCalendar.Font = new Font("Arial", 18, FontStyle.Bold);

            // Центровка
            monthCalendar.Location = new Point(
                (this.ClientSize.Width - monthCalendar.Width) / 2,
                (this.ClientSize.Height - monthCalendar.Height) / 2
            );

            // Добавляем элементы
            this.Controls.Add(monthCalendar);
            this.Controls.Add(infoLabel);

            HighlightWorkDates(results);
            HighlightTodayAsStart();
            ScrollToWorkMonth(results);

            // При изменении размера окна — центрируем
            this.Resize += (s, e) =>
            {
                monthCalendar.Location = new Point(
                    (this.ClientSize.Width - monthCalendar.Width) / 2,
                    (this.ClientSize.Height - monthCalendar.Height) / 2
                );
            };
        }

        private void HighlightWorkDates(List<ResultItem> results)
        {
            var dates = new List<DateTime>();

            foreach (var item in results)
            {
                if (item.StartTime != DateTime.MinValue && item.EndTime != DateTime.MinValue)
                {
                    DateTime start = item.StartTime.Date;
                    DateTime end = item.EndTime.Date;

                    for (DateTime d = start; d <= end; d = d.AddDays(1))
                    {
                        if (!dates.Contains(d))
                            dates.Add(d);
                    }
                }
            }

            monthCalendar.BoldedDates = dates.ToArray();
        }

        private void HighlightTodayAsStart()
        {
            monthCalendar.SelectionStart = DateTime.Today;
            monthCalendar.SelectionEnd = DateTime.Today;
        }

        private void ScrollToWorkMonth(List<ResultItem> results)
        {
            var firstWorkDate = results
                .Where(r => r.StartTime != DateTime.MinValue)
                .OrderBy(r => r.StartTime)
                .Select(r => r.StartTime)
                .FirstOrDefault();

            if (firstWorkDate != DateTime.MinValue)
            {
                monthCalendar.SelectionStart = firstWorkDate;
                monthCalendar.SelectionEnd = firstWorkDate;
            }
        }
    }
}
