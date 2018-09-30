using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TractorForms
{
    public partial class TractorForm : Form
    {
        private TractorWithLadle tractor;

        public TractorForm()
        {
            InitializeComponent();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxTractor.Width, pictureBoxTractor.Height);
            Graphics gr = Graphics.FromImage(bmp);
            tractor.DrawTractor(gr);
            pictureBoxTractor.Image = bmp;
        }

        //Метод клика для создания трактора
        private void buttonCreate_Click(object sender, EventArgs e)
        {
            Random rnd = new Random();
            tractor = new TractorWithLadle(rnd.Next(50, 70), rnd.Next(1000, 2000), Color.Red, Color.Black, Color.Blue, true);
            tractor.SetPosition(rnd.Next(50, 100), rnd.Next(50, 300), pictureBoxTractor.Width, pictureBoxTractor.Height);
            Draw();
        }

        //Метод клика по кнопке управления
        private void buttonMove_Click(object sender, EventArgs e)
        {
            //получаем имя кнопки
            string name = (sender as Button).Name;
            switch (name)
            {
                //вверх
                case "buttonUp":
                    tractor.MoveTransport(Direction.Up);
                    break;
                //вниз
                case "buttonDown":
                    tractor.MoveTransport(Direction.Down);
                    break;
                //влево
                case "buttonLeft":
                    tractor.MoveTransport(Direction.Left);
                    break;
                //вправо
                case "buttonRight":
                    tractor.MoveTransport(Direction.Right);
                    break;
            }
            Draw();
        }
    }
}
