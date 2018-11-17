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
        MultiLevelGarage garage;
        private const int countLevel = 5;

        public FormGarage()
        {
            InitializeComponent();
            garage = new MultiLevelGarage(countLevel, pictureBoxGarage.Width, pictureBoxGarage.Height);
            for (int i = 0; i < countLevel; i++)
            {
                listBoxLevel.Items.Add("Уровень " + (i + 1));
            }
            listBoxLevel.SelectedIndex = 0;
        }

        private void Draw()
        {
            Bitmap bmp = new Bitmap(pictureBoxGarage.Width, pictureBoxGarage.Height);
            Graphics gr = Graphics.FromImage(bmp);
            garage[listBoxLevel.SelectedIndex].Draw(gr);
            pictureBoxGarage.Image = bmp;
        }

        private void buttonSetTrator_Click(object sender, EventArgs e)
        {
            if (listBoxLevel.SelectedIndex > -1)
            {
                ColorDialog dialog = new ColorDialog();
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    var tractor = new Tractor(100, 1000, dialog.Color);
                    int place = garage[listBoxLevel.SelectedIndex] + tractor;
                    if (place == -1)
                    {
                        MessageBox.Show("Нет свободных мест", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    Draw();
                }
            }
        }

        private void buttonSetTractorWithLadle_Click(object sender, EventArgs e)
        {
            if (listBoxLevel.SelectedIndex > -1)
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
                            int place = garage[listBoxLevel.SelectedIndex] + tractor;
                            if (place == -1)
                            {
                                MessageBox.Show("Нет свободных мест", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            Draw();
                        }
                    }
                }
            }
        }

        private void buttonTakeTractor_Click(object sender, EventArgs e)
        {
            if (listBoxLevel.SelectedIndex > -1)
            {
                if (maskedTextBoxTakePlace.Text != "")
                {
                    var tractor = garage[listBoxLevel.SelectedIndex] - Convert.ToInt32(maskedTextBoxTakePlace.Text);
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

        private void listBoxLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            Draw();
        }
    }
}