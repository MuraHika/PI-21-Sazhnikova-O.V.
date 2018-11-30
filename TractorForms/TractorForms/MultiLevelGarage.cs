using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TractorForms
{
    public class MultiLevelGarage
    {
        List<Garage<ITransport>> garageStages;
        private const int countPlaces = 20;

        public MultiLevelGarage(int countStages, int screenWidth, int screenHeight)
        {
            garageStages = new List<Garage<ITransport>>();
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
    }
}
