using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Premium
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "PDF файлы|*.pdf";
            save.FileName = "премия.pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                // Создаем PDF документ
                PdfDocument document = new PdfDocument();
                document.Info.Title = "Приказ";

                // Добавляем страницу
                PdfPage page = document.AddPage();
                XGraphics gfx = XGraphics.FromPdfPage(page);

                // шрифты
                XFont fontNormal = new XFont("Arial", 12);
                XFont fontLarge = new XFont("Arial", 20);
                XFont fontTitle = new XFont("Times New Roman", 24);

                // Пишем текст на странице
                gfx.DrawString("Приказ № 12 " +
                    "О лишении премии работника ",
                    fontTitle,
                    XBrushes.Black,
                    new XPoint(50, 50));

                gfx.DrawString($"Дата: {DateTime.Now:dd.MM.yyyy}",
                    fontNormal,
                    XBrushes.Black,
                    new XPoint(50, 70));

                // Получаем текст из TextBox
                string userText = textBox1.Text;

                // Добавляем перенос строки если текст длинный
                string reasonText = "В связи с " + userText;

                gfx.DrawString(reasonText,
                    fontNormal,
                    XBrushes.Black,
                    new XPoint(50, 100));

                gfx.DrawString("приказываю:",
                    fontNormal,
                    XBrushes.Black,
                    new XPoint(50, 130));

                // Список задач
                string[] tasks = {
                    "1. ",
                    "2. ",
                    "3. "
                };

                int y = 160;
                foreach (var task in tasks)
                {
                    gfx.DrawString(task, fontNormal, XBrushes.Black,
                        new XPoint(70, y));
                    y += 30;
                }

                // Сохраняем PDF
                document.Save(save.FileName);
                document.Close();

                MessageBox.Show($"PDF создан: {save.FileName}");
            }
        }
    }
}
