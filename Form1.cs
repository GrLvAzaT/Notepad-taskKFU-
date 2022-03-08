using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;
using MetroFramework.Components;
using MetroFramework.Forms;


namespace TEXTWRITER_2._0
{
    public partial class Form1 : MetroForm
    {
        Color color = Color.DeepSkyBlue; //Создаем переменную типа Color присваиваем ей черный цвет.
        bool isPressed = false; //логическая переменная понадобиться для опеределения когда можно рисовать на panel
        Point CurrentPoint; //Текущая точка ресунка.
        Point PrevPoint; //Это начальная точка рисунка.
        Graphics g; //Создаем графический элемент.
        ColorDialog colorDialog = new ColorDialog(); //диалоговое окно для выбора цвета.
        int count = 1;

        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*txt|All files(*.*)|*.*";
            MetroStyleManager.Default.Style = MetroFramework.MetroColorStyle.Blue;
            MetroStyleManager.Default.Theme = MetroFramework.MetroThemeStyle.Light;
            label2.BackColor = Color.DeepSkyBlue; //По умолчанию для пера задан черный цвет, поэтому мы зададим такой же фон для label2
            g = panel1.CreateGraphics(); //Создаем область для работы с графикой на элементе panel
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TabPage new1 = new TabPage("new" + count);
            RichTextBox tb = new RichTextBox();
            DataGridView dt = new DataGridView();
            tb.Dock = DockStyle.Fill;
            tabControl1.TabPages.Add(new1);
            new1.Controls.Add(dt);
            //new1.Controls.Add(tb);
            tabControl1.SelectedTab = new1;
            count++;
        }
        private DataGridView GetDataGridView()
        {
            DataGridView dgv = null;
            TabPage dg = tabControl1.SelectedTab;
            if (dg != null)
            {
                dgv = dg.Controls[0] as DataGridView;
            }
            return dgv;
        }

        private RichTextBox GetRichTextBox()
        {
            RichTextBox rtb = null;
            TabPage tp = tabControl1.SelectedTab;
            if (tp != null)
            {
                rtb = tp.Controls[0] as RichTextBox;
            }
            return rtb;
            
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() ==
    System.Windows.Forms.DialogResult.OK &&
    openFileDialog1.FileName.Length > 0)
            {
                try
                {
                    GetRichTextBox().LoadFile(openFileDialog1.FileName,
                       RichTextBoxStreamType.RichText);
                }
                catch (System.ArgumentException ex)
                {
                    GetRichTextBox().LoadFile(openFileDialog1.FileName,
                       RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetRichTextBox().BackColor = Color.White;

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Paste();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog savefile = new SaveFileDialog();
            savefile.DefaultExt = ".txt";
            savefile.Filter = "Test files|*.txt ";
            if(savefile.ShowDialog()==System.Windows.Forms.DialogResult.OK && savefile.FileName.Length > 0)
            {
                using(StreamWriter sw = new StreamWriter(savefile.FileName, true))
                {
                    sw.WriteLine(GetRichTextBox().Text);
                    sw.Close();
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            int index = 0;
            String temp = GetRichTextBox().Text;
            GetRichTextBox().Text = "";
            GetRichTextBox().Text = temp;
            while (index < GetRichTextBox().Text.LastIndexOf(toolStripTextBox1.Text))
            {
                GetRichTextBox().Find(toolStripTextBox1.Text, index, GetRichTextBox().TextLength, RichTextBoxFinds.None);
                GetRichTextBox().SelectionBackColor = Color.Orange;
                index = GetRichTextBox().Text.IndexOf(toolStripTextBox1.Text, index) + 1;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void feedBackToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FeedBack frm = new FeedBack())
            {
                frm.ShowDialog();
            }
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Form3 frm = new Form3())
            {
                frm.ShowDialog();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK) //Если окно закрылось с OK, то меняем цвет для пера и фона label2
            {
                color = colorDialog.Color; //меняем цвет для пера
                label2.BackColor = colorDialog.Color; //меняем цвет для Фона label2
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
            CurrentPoint = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPressed)
            {
                PrevPoint = CurrentPoint;
                CurrentPoint = e.Location;
                my_Pen();
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh(); //Очищает элемент Panel
        }
        private void my_Pen()
        {
            Pen pen = new Pen(color, (float)numericUpDown1.Value); //Создаем перо, задаем ему цвет и толщину.
            g.DrawLine(pen, CurrentPoint, PrevPoint); //Соединияем точки линиями
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                GetRichTextBox().SelectionFont = fontDialog1.Font;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void инструментыToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void цветТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                GetRichTextBox().SelectionColor = colorDialog1.Color;
            }

        }
        /// <summary>
        /// Настройка параметров страницы
        /// </summary>
        private void MenuFilePageSetup()
        {
            pageSetupDialog1.ShowDialog();
        }
        private void pageSetupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuFilePageSetup();
        }
        /// <summary>
        /// StringReader для печати содержимого редактора текста
        /// </summary>
        private StringReader m_myReader;

        /// <summary>
        /// Номер текущей распечатываемой страницы документа
        /// </summary>
        private uint m_PrintPageNumber;
        /// <summary>
        /// Предварительный просмотр перед печатью документа
        /// </summary>
        private void MenuFilePrintPreview()
        {
            m_PrintPageNumber = 1;

            string strText = this.GetRichTextBox().Text;
            m_myReader = new StringReader(strText);
            Margins margins = new Margins(100, 50, 50, 50);

            printDocument1.DefaultPageSettings.Margins = margins;
            printPreviewDialog1.ShowDialog();

            m_myReader.Close();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuFilePrintPreview();
        }
        /// <summary>
        /// Печать документа
        /// </summary>
        private void MenuFilePrint()
        {
            m_PrintPageNumber = 1;

            string strText = this.GetRichTextBox().Text;
            m_myReader = new StringReader(strText);

            Margins margins = new Margins(100, 50, 50, 50);
            printDocument1.DefaultPageSettings.Margins = margins;

            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                this.printDocument1.Print();
            }
            m_myReader.Close();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuFilePrint();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int lineCount = 0;       // счетчик строк
            float linesPerPage = 0;  // количество строк на одной странице
            float yLinePosition = 0; // текущая позиция при печати по 
                                     // вертикальной оси
            string currentLine = null;  // текст текущей строки

            // Шрифт для печати текста
            Font printFont = this.GetRichTextBox().Font;

            // Кисть для печати текста
            SolidBrush printBrush = new SolidBrush(Color.Black);

            // Размер отступа слева
            float leftMargin = e.MarginBounds.Left;

            // Размер отступа сверху
            float topMargin = e.MarginBounds.Top +
               3 * printFont.GetHeight(e.Graphics);

            // Вычисляем количество строк на одной странице с учетом отступа
            linesPerPage = (e.MarginBounds.Height -
               6 * printFont.GetHeight(e.Graphics)) /
               printFont.GetHeight(e.Graphics);

            // Цикл печати всех строк страницы
            while (lineCount < linesPerPage &&
               ((currentLine = m_myReader.ReadLine()) != null))
            {
                // Вычисляем позицию очередной распечатываемой строки
                yLinePosition = topMargin + (lineCount *
                  printFont.GetHeight(e.Graphics));

                // Печатаем очередную строку
                e.Graphics.DrawString(currentLine, printFont, printBrush,
                  leftMargin, yLinePosition, new StringFormat());

                // Переходим к следующей строке
                lineCount++;
            }

            // Печать колонтитулов страницы

            // Номер текущей страницы
            string sPageNumber = "Page " + m_PrintPageNumber.ToString();

            // Вычисляем размеры прямоугольной области, занимаемой верхним 
            // колонтитулом страницы
            SizeF stringSize = new SizeF();
            stringSize = e.Graphics.MeasureString(sPageNumber, printFont,
               e.MarginBounds.Right - e.MarginBounds.Left);

            // Печатаем номер страницы
            e.Graphics.DrawString(sPageNumber, printFont, printBrush,
               e.MarginBounds.Right - stringSize.Width, e.MarginBounds.Top,
               new StringFormat());

            // Печатаем имя файла документа
            e.Graphics.DrawString(this.Text, printFont, printBrush,
               e.MarginBounds.Left, e.MarginBounds.Top, new StringFormat());

            // Кисть для рисования горизонтальной линии, 
            // отделяющей верхний колонтитул
            Pen colontitulPen = new Pen(Color.Black);
            colontitulPen.Width = 2;

            // Рисуем верхнюю линию
            e.Graphics.DrawLine(colontitulPen,
               leftMargin,
               e.MarginBounds.Top + printFont.GetHeight(e.Graphics) + 3,
               e.MarginBounds.Right, e.MarginBounds.Top +
               printFont.GetHeight(e.Graphics) + 3);

            // Рисуем линию, отделяющую нижний колонтитул документа
            e.Graphics.DrawLine(colontitulPen,
               leftMargin, e.MarginBounds.Bottom - 3,
               e.MarginBounds.Right, e.MarginBounds.Bottom - 3);

            // Печатаем текст нижнего колонтитула
            e.Graphics.DrawString(
            "TextWriter 2.0 from Mini studio™, https://vk.com/ministudi",
               printFont, printBrush,
               e.MarginBounds.Left, e.MarginBounds.Bottom, new StringFormat());

            // Если напечатаны не все строки документа, 
            // переходим к следующей странице
            if (currentLine != null)
            {
                e.HasMorePages = true;
                m_PrintPageNumber++;
            }

            // Иначе завершаем печать страницы
            else
                e.HasMorePages = false;

            // Освобождаем ненужные более ресурсы
            printBrush.Dispose();
            colontitulPen.Dispose();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().Text = "";
        }

        private void makeBIGTheTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().SelectedText = GetRichTextBox().SelectedText.ToUpper();
        }

        private void makeSmallTheTextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().SelectedText = GetRichTextBox().SelectedText.ToLower();
        }

        private void textLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().SelectionAlignment = HorizontalAlignment.Left;
        }

        private void textRightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetRichTextBox().SelectionAlignment = HorizontalAlignment.Center;
        }

        private void textRightToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GetRichTextBox().SelectionAlignment = HorizontalAlignment.Right;
        }

        private void loadImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Images |*.png;*.jpg";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Image image = Image.FromFile(dialog.FileName);
                Clipboard.SetImage(image);
                GetRichTextBox().Paste();
            }
        }

        private void generationPassToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string parameters = "1234567890qwertyuiopasdfghjklzxcvbnmZXCVBNMLKJHGFDSAQWERTYUIOP";
            int kol = 10;
            string result = "";

            Random rnd = new Random();
            int lng = parameters.Length;

            for (int i = 0; i < kol; i++)
            {
                result += parameters[rnd.Next(lng)];
            }
            GetRichTextBox().Text = result;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            textBox1.Text += (sender as Button).Text;
        }

        double a = 0, b = 0, c = 0;

        private void button20_Click(object sender, EventArgs e)
        {
            b = Convert.ToDouble(textBox1.Text);
            switch (znak)
            {
                case '+': c = a + b;
                    break;
                case '-':c = a - b;
                    break;
                case 'x': c = a * b;
                    break;
                case '/': c = a / b;
                    break;
            }
            textBox1.Text = c.ToString();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                if (textBox1.Text[0] == '-')
                    textBox1.Text = textBox1.Text.Remove(0, 1);
                else textBox1.Text = '-' + textBox1.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length -1,1);
        }

        char znak = '+';

        private void button2_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            znak = (sender as Button).Text[0];
            textBox1.Clear();
        }
    }
}
