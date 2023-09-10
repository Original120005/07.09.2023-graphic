using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace _06._09._2023_graphic
{
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        Graphics g;

        public Form1()
        {
            InitializeComponent();

            bitmap = new Bitmap(this.Width, this.Height);

            comboBox1.SelectionLength = 0;
            comboBox1.Items.Add("y = kx");
            comboBox1.Items.Add("y = kx + b");
            comboBox1.Items.Add("y = x^2");
            comboBox1.Items.Add("y = ax^2 + bx + c");
            comboBox1.Items.Add("y = x^3");
            comboBox1.Items.Add("y = x^1/2");
            comboBox1.Items.Add("y = sinx");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBox1.SelectedIndex;
            switch (index)
            {
                case 0:
                    textBox1.Text = "Прямая";
                    textBox2.Text = "Cамый простой частный случай линейной зависимости - прямая пропорциональность у = kx, где k ≠ 0 - коэффициент пропорциональности. На рисунке пример для k = 1, т.е. фактически приведенный график иллюстрирует функциональную зависимость, которая задаёт равенство значения функции значению аргумента.";
                    break;

                case 1:
                    textBox1.Text = "Прямая";
                    textBox2.Text = "Общий случай линейной зависимости: коэффициенты k и b - любые действительные числа. Здесь k = 0.5, b = -1.";
                    break;

                case 2:
                    textBox1.Text = "Парабола";
                    textBox2.Text = "Простейший случай квадратичной зависимости - симметричная парабола с вершиной в начале координат.";
                    break;

                case 3:
                    textBox1.Text = "Парабола";
                    textBox2.Text = "Общий случай квадратичной зависимости: коэффициент a - произвольное действительное число не равное нулю (a принадлежит R, a ≠ 0), b, c - любые действительные числа.";
                    break;

                case 4:
                    textBox1.Text = "Кубическая парабола";
                    textBox2.Text = "Самый простой случай для целой нечетной степени. Случаи с коэффициентами изучаются в разделе \"Движение графиков функций\".";
                    break;

                case 5:
                    textBox1.Text = "График функции\r\ny = √x";
                    textBox2.Text = "Самый простой случай для дробной степени (x1/2 = √x__). Случаи с коэффициентами изучаются в разделе \"Движение графиков функций\".";
                    break;

                case 6:
                    textBox1.Text = "Синусоида";
                    textBox2.Text = "Тригонометрическая функция синус. Случаи с коэффициентами изучаются в разделе \"Движение графиков функций\".";
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            g = Graphics.FromImage(pictureBox1.Image = bitmap);
            g.DrawLine(Pens.Black, 0, pictureBox1.Height / 2, pictureBox1.Width, pictureBox1.Height / 2);
            g.DrawLine(Pens.Black, pictureBox1.Width / 2, 0, pictureBox1.Width / 2, pictureBox1.Height);

            Graphics gr = pictureBox1.CreateGraphics();
            gr = Graphics.FromImage(pictureBox1.Image = bitmap);


            int a = 1;
            int b = 0;
            int c = 0;
            double x, y;
            int orgio_x = pictureBox1.Width / 2;
            int orgio_y = pictureBox1.Height / 2;

            Bitmap bit = new Bitmap(1, 1);
            bit.SetPixel(0, 0, Color.Red);


            int index = comboBox1.SelectedIndex;
            switch (index)
            {
                case 0:
                    gr.DrawLine(Pens.Red, 10, 338, 338, 10);
                    break;

                case 1:
                    gr.DrawLine(Pens.Red, 10, 338, 338, 40);
                    break;

                case 2:
                    for (double i = 0; i < 10000; i += 0.01)
                    {
                        x = i;
                        y = (a * (x * x)) + ((b * x) + c);
                        gr.DrawImageUnscaled(bit, orgio_x + (int)x, orgio_y - (int)y);
                        gr.DrawImageUnscaled(bit, orgio_x - (int)x, orgio_y - (int)y);
                    }
                    break;

                case 3:
                    int orgio2_x = 170;
                    int orgio2_y = 210;

                    for (double i = 0; i < 10000; i += 0.01)
                    {
                        x = i;
                        y = (a * (x * x)) + ((b * x) + c);
                        gr.DrawImageUnscaled(bit, orgio2_x + (int)x, orgio2_y - (int)y);
                        gr.DrawImageUnscaled(bit, orgio2_x - (int)x, orgio2_y - (int)y);
                    }
                    break;

                case 4:
                    for (double i = 0; i < 10000; i += 0.01)
                    {
                        x = i;
                        y = (a * (x * x)) + ((b * x) + c);
                        gr.DrawImageUnscaled(bit, orgio_x + (int)x, orgio_y - (int)y);
                        gr.DrawImageUnscaled(bit, orgio_x - (int)x, orgio_y + (int)y);
                    }
                    break;

                case 5:
                    int orgio3_x = 177;
                    int orgio3_y = 171;

                    for (double i = 0; i < 10000; i += 0.01)
                    {
                        x = i;
                        y = (a * (x * x)) + ((b * x) + c);
                        gr.DrawImageUnscaled(bit, orgio3_x + (int)y, orgio3_y - (int)x);
                    }
                    break;

                case 6:
                    Point[] points = new Point[1000];

                    for (int i = 0; i < points.Length; i++)
                    {
                        points[i] = new Point(i, (int)(Math.Sin((double)i / 10) * 10 + 171));
                    }
                    gr.DrawLines(Pens.Red, points);
                    break;
            }
        }


    }
}

