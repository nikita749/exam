using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;//важно чтобы был подключён
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace plane
{ 
    public partial class Form1 : Form
    {
        Bitmap sky, plane; // то, что мы в дальнейшем будем отрисовывать (задник, самолет)
        Graphics g; // объект класса с помощью которого мы будем рисовать наши самолет и задник
        
        int dx; //преращение координаты x (для скорости)
        Rectangle rct; //координаты самолета
        Rectangle rct_new;  // координаты после приращения скорости и высоты
        
        Random rnd;
        Boolean demo = true;


        private void timer1_Tick(object sender, EventArgs e)
        {
            g.DrawImage(sky, new Point(0, 0)); // рисуем небо
            if (rct.X < ClientRectangle.Width) // если не вышли за края формы
            { 
                rct.X += dx; // заставляем самолет двигаться
            }
            else
            {
                //если вышли за края формы
                //перемещаем самолет с другого края на той же высоте
                rct.Y = rct_new.Y;
                rct.X = rct_new.X;
            }


            if (rct.Y > ClientRectangle.Height)
            {
                
            }


            g.DrawImage(plane, rct.X, rct.Y);

            if (!demo)
            {
                Invalidate(rct);
            }
            else
            {
                Rectangle reg = new Rectangle(20, 20, sky.Width - 40, sky.Height - 40);
                g.DrawRectangle(Pens.Black, reg.X, reg.Y, reg.Width - 1, reg.Height - 1);
                Invalidate(reg);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }



        private void button_UP_Click(object sender, EventArgs e)// потом заменим на управление из кабины
        {
            g.DrawImage(sky, new Point(0, 0));
            rct.Y -= 10; //заставили самолет подняться выше на 10(- потому что координаты 0,0 слева сверху)
            //задали новые координаты после приращения
            rct_new.Y = rct.Y;
            rct_new.X = rct.X;
        }

        private void button_DOWN_Click(object sender, EventArgs e)// потом заменим на управление из кабины
        {
            g.DrawImage(sky, new Point(0, 0));
            //заставили самолет спуститься ниже на 10 (+ потому что координаты 0,0 слева сверху)
            rct.Y += 10;
            //задали новые координаты после приращения
            rct_new.Y = rct.Y;
            rct_new.X = rct.X;
        }

        private void button_SPEED_PLUS_Click(object sender, EventArgs e) // потом заменим на управление из кабины
        {
            dx++; //увеличиваем скорость
        }

        private void button_SPEED_MINUS_Click(object sender, EventArgs e)// потом заменим на управление из кабины
        {
            dx--; //уменьшаем скорость
        }

        public Form1()
        {
            InitializeComponent();

            sky = new Bitmap("sky.jpg"); //говорим какой файл будет у нас задником
            plane = new Bitmap("plane.png"); //говорим какой файл будет у нас самолетом
            BackgroundImage = new Bitmap("sky.jpg");
            plane.MakeTransparent();


            ClientSize = new Size(new Point(BackgroundImage.Width, BackgroundImage.Height)); // область за которую нельзя вылететь
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            g = Graphics.FromImage(BackgroundImage);


            rct.X = -40; // изначальные координаты 
            rct.Y = 400; 
            rct.Width = plane.Width;
            rct.Height = plane.Height;
            dx = 2; // изначальная скорость
            timer1.Interval = 20;
            timer1.Enabled = true;



        }

    }
}
