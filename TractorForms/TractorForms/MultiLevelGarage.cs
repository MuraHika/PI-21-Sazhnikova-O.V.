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

        public bool SaveData(string filename)
        {

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    WriteToFile("CountLeveles:" + garageStages.Count + Environment.NewLine, fs);
                    foreach (var level in garageStages)
                    {
                        WriteToFile("Level" + Environment.NewLine, fs);
                        for (int i = 0; i < countPlaces; i++)
                        {
                            var tractor = level[i];
                            if (tractor != null)
                            {
                                if (tractor.GetType().Name == "Tractor")
                                {
                                    WriteToFile(i + ":Tractor:", fs);
                                }
                                if (tractor.GetType().Name == "TractorWithLadle")
                                {
                                    WriteToFile(i + ":TractorWithLadle:", fs);
                                }
                                WriteToFile(tractor + Environment.NewLine, fs);
                            }
                        }
                    }
                }
            }
            return true;
        }

        private void WriteToFile(string text, FileStream stream)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(text);
            stream.Write(info, 0, info.Length);
        }
        public bool LoadData(string filename)
        {
            if (!File.Exists(filename))
            {
                return false;
            }

            string bufferTextFromFile = "";
            using (FileStream fs = new FileStream(filename, FileMode.Open))
            {
                using (BufferedStream bs = new BufferedStream(fs))
                {
                    byte[] b = new byte[fs.Length];
                    UTF8Encoding temp = new UTF8Encoding(true);
                    while (bs.Read(b, 0, b.Length) > 0)
                    {
                        bufferTextFromFile += temp.GetString(b);
                    }
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
                return false;
            }
            int counter = -1;
            ITransport tractor = null;
            for (int i = 1; i < strs.Length; ++i)
            {
                if (strs[i] == "Level")
                {
                    counter++;
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
                garageStages[counter][Convert.ToInt32(strs[i].Split(':')[0])] = tractor;
            }
            return true;
        }
    }
}
