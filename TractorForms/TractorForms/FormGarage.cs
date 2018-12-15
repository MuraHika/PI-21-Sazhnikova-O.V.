using NLog;
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
        FormTractorConfig form;
        private const int countLevel = 5;
        private Logger logger;

        public FormGarage()
        {
            InitializeComponent();
            logger = LogManager.GetCurrentClassLogger();
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
                try
                {
                    int place = garage[listBoxLevel.SelectedIndex] + tractor;
                    logger.Info("Добавлен трактор " + tractor.ToString() + " на место " + place);
                    Draw();
                }
                catch (GarageOverflowException ex)
                {

                    MessageBox.Show(ex.Message, "Переполнение!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Неизвестная ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonTakeTractor_Click(object sender, EventArgs e)
        {
            if (listBoxLevel.SelectedIndex > -1)
            {
                if (maskedTextBoxTakePlace.Text != "")
                {
                    try
                    {
                        var tractor = garage[listBoxLevel.SelectedIndex] - Convert.ToInt32(maskedTextBoxTakePlace.Text);

                        Bitmap bmp = new Bitmap(pictureBoxViewTractor.Width, pictureBoxViewTractor.Height);
                        Graphics gr = Graphics.FromImage(bmp);
                        tractor.SetPosition(60, 50, pictureBoxViewTractor.Width, pictureBoxViewTractor.Height);
                        tractor.DrawTractor(gr);
                        pictureBoxViewTractor.Image = bmp;
                        logger.Info("Изъят трактор " + tractor.ToString() + " с места " + maskedTextBoxTakePlace.Text);
                        Draw();
                    }
                    catch (GarageNotFoundException ex)
                    {
                        MessageBox.Show(ex.Message, "Не найдено!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Bitmap bmp = new Bitmap(pictureBoxViewTractor.Width, pictureBoxViewTractor.Height);
                        pictureBoxViewTractor.Image = bmp;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Неизвестная ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
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
                try
                {
                    garage.SaveData(saveFileDialog.FileName);
                    MessageBox.Show("Сохранение прошло успешно!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Сохранено в файл " + saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при сохранении!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                try
                {
                    garage.LoadData(openFileDialog.FileName);
                    MessageBox.Show("Загрузили!", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    logger.Info("Загружено из файла " + openFileDialog.FileName);
                }
                catch (GarageOccupiedPlaceException ex)
                {
                    MessageBox.Show(ex.Message, "Занятое место", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Неизвестная ошибка при загрузки!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Draw();
            }
        }
    }
}