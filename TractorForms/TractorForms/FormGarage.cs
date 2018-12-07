﻿using System;
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
        FormTractorConfig form;
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
            form = new FormTractorConfig();
            form.AddEvent(AddTractor);
            form.Show();
        }

        private void AddTractor(ITransport tractor)
        {

            if (tractor != null && listBoxLevel.SelectedIndex > -1)
            {
                int place = garage[listBoxLevel.SelectedIndex] + tractor;
                if (place > -1)
                {
                    Draw();
                }
                else
                {
                    MessageBox.Show("Трактор не удалось поставить");
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

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (garage.SaveData(saveFileDialog.FileName))
                {
                    MessageBox.Show("Сохранение прошло успешно", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не сохранилось", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (garage.LoadData(openFileDialog.FileName))
                {
                    MessageBox.Show("Загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Не загрузили", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Draw();
            }
        }
    }
}