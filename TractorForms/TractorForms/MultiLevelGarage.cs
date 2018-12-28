using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    public class MultiLevelGarage
    {
        List<Garage<ITransport>> garageStages;
        private int screenWidth;
        private int screenHeight;
        private const int countPlaces = 20;

        public MultiLevelGarage(int countStages, int screenWidth, int screenHeight)
        {
            garageStages = new List<Garage<ITransport>>();
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;
            for (int i = 0; i < countStages; ++i)
            {
                garageStages.Add(new Garage<ITransport>(countPlaces, screenWidth, screenHeight));
            }
        }

        public Garage<ITransport> this[int ind]
        {
            get
            {
                if (ind > -1 && ind < garageStages.Count)
                {
                    return garageStages[ind];
                }
                return null;
            }
        }

        public void SaveData(string filename)
        {
            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                WriteToFile("CountLeveles:" + garageStages.Count + Environment.NewLine, fs);
                foreach (var level in garageStages)
                {
                    WriteToFile("Level" + Environment.NewLine, fs);
                    foreach (ITransport tractor in level)
                    {
                        if (tractor.GetType().Name == "Tractor")
                        {
                            WriteToFile(level.GetKey + ":Tractor:", fs);
                        }
                        if (tractor.GetType().Name == "TractorWithLadle")
                        {
                            WriteToFile(level.GetKey + ":TractorWithLadle:", fs);
                        }
                        WriteToFile(tractor + Environment.NewLine, fs);
                    }
                }
            }
        }

        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }

        public void LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }

            string bufferTextFromFile = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                byte[] b = new byte[fs.Length];
                UTF8Encoding temp = new UTF8Encoding(true);
                while (fs.Read(b, 0, b.Length) > 0)
                {
                    bufferTextFromFile += temp.GetString(b);
                }
            }
            bufferTextFromFile = bufferTextFromFile.Replace("\r", "");
            var strs = bufferTextFromFile.Split('\n');
            if (strs[0].Contains("CountLeveles"))
            {
                int count = Convert.ToInt32(strs[0].Split(':')[1]);
                if (garageStages != null)
                {
                    garageStages.Clear();
                }
                garageStages = new List<Garage<ITransport>>(count);
            }
            else
            {
                throw new Exception("Неверный фомат файла!");
            }
            int counter = -1;
            int counterTractor = 0;
            ITransport tractor = null;
            for (int i = 1; i < strs.Length; ++i)
            {
                if (strs[i] == "Level")
                {
                    counter++;
                    counterTractor = 0;
                    garageStages.Add(new Garage<ITransport>(countPlaces, screenWidth, screenHeight));
                    continue;
                }
                if (string.IsNullOrEmpty(strs[i]))
                {
                    continue;
                }
                if (strs[i].Split(':')[1] == "Tractor")
                {
                    tractor = new Tractor(strs[i].Split(':')[2]);
                }
                else if (strs[i].Split(':')[1] == "TractorWithLadle")
                {
                    tractor = new TractorWithLadle(strs[i].Split(':')[2]);
                }
                garageStages[counter][counterTractor++] = tractor;
            }
        }

        public void Sort()
        {
            garageStages.Sort();
        }
    }
}
