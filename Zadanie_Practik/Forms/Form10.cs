using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Zadanie_Practik
{
    public partial class Form10 : Form
    {
        public Form10()
        {
            InitializeComponent();
        }

        private string text = String.Empty;

        private void button1_Click_1(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }
        private Bitmap CreateImage(int Width, int Height)
        {
            Random rnd = new Random();

            //Создадим изображение
            Bitmap result = new Bitmap(Width, Height);

            //Вычислим позицию текста
            int Xpos = 10;
            int Ypos = 10;

            //Добавим различные цвета ддя текста
            Brush[] colors = {
                     Brushes.Black,
                     Brushes.Red,
                     Brushes.RoyalBlue,
                     Brushes.Green,
                     Brushes.Yellow,
                     Brushes.White,
                     Brushes.Tomato,
                     Brushes.Sienna,
                     Brushes.Pink };

            //Добавим различные цвета линий
            Pen[] colorpens = {
                     Pens.Black,
                     Pens.Red,
                     Pens.RoyalBlue,
                     Pens.Green,
                     Pens.Yellow,
                     Pens.White,
                     Pens.Tomato,
                     Pens.Sienna,
                     Pens.Pink };

            //Делаем случайный стиль текста
            FontStyle[] fontstyle = {
                     FontStyle.Bold,
                     FontStyle.Italic,
                     FontStyle.Regular,
                     FontStyle.Strikeout,
                     FontStyle.Underline};

            //Добавим различные углы поворота текста
            Int16[] rotate = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6 };

            //Укажем где рисовать
            Graphics g = Graphics.FromImage((Image)result);

            //Пусть фон картинки будет серым
            g.Clear(Color.Gray);

            //Делаем случайный угол поворота текста
            g.RotateTransform(rnd.Next(rotate.Length));

            //Сгенерируем текст
            text = String.Empty;
            string ALF = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += ALF[rnd.Next(ALF.Length)];

            //Нарисуем сгенирируемый текст
            g.DrawString(text,
                         new Font("Arial", 25, fontstyle[rnd.Next(fontstyle.Length)]),
                         colors[rnd.Next(colors.Length)],
                         new PointF(Xpos, Ypos));

            //Добавим немного помех
            //Линии из углов
            g.DrawLine(colorpens[rnd.Next(colorpens.Length)],
                       new Point(0, 0),
                       new Point(Width - 1, Height - 1));
            g.DrawLine(colorpens[rnd.Next(colorpens.Length)],
                       new Point(0, Height - 1),
                       new Point(Width - 1, 0));

            //Белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (rnd.Next() % 20 == 0)
                        result.SetPixel(i, j, Color.White);

            return result;
        }

        //Выводим текст на картинку при запуске приложения
        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = this.CreateImage(pictureBox1.Width, pictureBox1.Height);
        }

        //Выполняем проверку, правильно ли пользователь вввел текст с картинки
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == this.text)
                MessageBox.Show("Верно!");
            else
                MessageBox.Show("Ошибка!");
        }

        
    }
}


