using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Train
    {
        private List<TrainCar> train = new List<TrainCar>();

        public void AddTrainCar(int i, int j, string t)
        {
            train.Add(new TrainCar() { passengerСapacity = i, luggageCapacity = j, trainCarType = t });
        }

        public void RemoveTrainCar(int i)
        {
            train.RemoveAt(i);
        }

        public void ViewTrain()
        {
            foreach(TrainCar item in train)
            {
                Console.WriteLine("{0} | {1} | {2}", item.trainCarType, item.passengerСapacity, item.luggageCapacity);
            }
        }
    }
}
