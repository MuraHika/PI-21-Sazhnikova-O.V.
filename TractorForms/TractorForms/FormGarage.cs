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
    public partial class FormGarage : Form
    {
        Garage<ITransport> garage;

        public FormGarage()
        {
            InitializeComponent();
            garage = new Garage<ITransport>(20, pictureBoxGarage.Width, pictureBoxGarage.Height);
            Draw();
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxGarage.Width, pictureBoxGarage.Height);
            Graphics gr = Graphics.FromImage(bmp);
            garage.Draw(gr);
            pictureBoxGarage.Image = bmp;
        }

        private void buttonSetTrator_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var tractor = new Tractor(100, 1000, dialog.Color);
                int place = garage + tractor;
                Draw();
            }
        }

        private void buttonSetTractorWithLadle_Click(object sender, EventArgs e)
        {
            ColorDialog dialog = new ColorDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ColorDialog dialogDop = new ColorDialog();
                if (dialogDop.ShowDialog() == DialogResult.OK)
                {
                    ColorDialog dialogGlass = new ColorDialog();
                    if (dialogGlass.ShowDialog() == DialogResult.OK)
                    {
                        var tractor = new TractorWithLadle(100, 1000, dialog.Color, dialogDop.Color, dialogGlass.Color, true);
                        int place = garage + tractor;
                        Draw();
                    }
                }
            }
        }

        private void buttonTakeTractor_Click(object sender, EventArgs e)
        {
            if (maskedTextBoxTakePlace.Text != "")
            {
                var tractor = garage - Convert.ToInt32(maskedTextBoxTakePlace.Text);
                if (tractor != null)
                {
                    Bitmap bmp = new Bitmap(pictureBoxViewTractor.Width, pictureBoxViewTractor.Height);
                    Graphics gr = Graphics.FromImage(bmp);
                    tractor.SetPosition(60, 50, pictureBoxViewTractor.Width, pictureBoxViewTractor.Height);
                    tractor.DrawTractor(gr);
                    pictureBoxViewTractor.Image = bmp;
                }
                else
                {
                    Bitmap bmp = new Bitmap(pictureBoxViewTractor.Width, pictureBoxViewTractor.Height);
                    pictureBoxViewTractor.Image = bmp;
                }
                Draw();
            }
        }
    }
}
