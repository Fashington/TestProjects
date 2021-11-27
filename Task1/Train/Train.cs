using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
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

        public string ViewTrain()
        {
            if (train.Count() != 0)
            {
                string answer = "";
                foreach (TrainCar item in train)
                {
                    answer += "Class: " + item.trainCarType+ " | ";
                    answer += "Passanger capacity: " + item.passengerСapacity + " | ";
                    answer += "Luggage capacity: " + item.luggageCapacity + " |\n";
                }
                return answer;
            }
            else
            {
                return "Your train has no any train cars";
            }
        }

        public void SortByClass()
        {
            var orderByClass = from c in train
                               orderby c.trainCarType
                               select c;
            List<TrainCar> newTrain = new List<TrainCar>();
            foreach (var car in orderByClass)
            {
                newTrain.Add(car);
            }
            train.Clear();
            foreach (TrainCar car in newTrain)
            {
                train.Add(car);
            }
            newTrain.Clear();
        }

        public void SortByClassDescending()
        {
            var orderByClassDescending = from c in train
                               orderby c.trainCarType descending
                               select c;
            List<TrainCar> newTrain = new List<TrainCar>();
            foreach (var car in orderByClassDescending)
            {
                newTrain.Add(car);
            }
            train.Clear();
            foreach (TrainCar car in newTrain)
            {
                train.Add(car);
            }
            newTrain.Clear();
        }

        public string SearchOperation(int lowLimit, int upLimit)
        {
            var searchLowwerUpper = from item in train
                                    where item.passengerСapacity >= lowLimit && item.passengerСapacity <= upLimit
                                    select item;

            string answer = "";
            foreach (var item in searchLowwerUpper)
            {
                answer += "Class: " + item.trainCarType + " | ";
                answer += "Passanger capacity: " + item.passengerСapacity + " | ";
                answer += "Luggage capacity: " + item.luggageCapacity + " |\n";
                //Console.WriteLine("Class: {0} | Passenger capacity: {1} | Luggage capacity: {2}", item.trainCarType, item.passengerСapacity, item.luggageCapacity);
            }
            return answer;
        }

        public int TotalPassengerCapacity()
        {
            int TotalCapacity = 0;

            foreach (TrainCar car in train)
            {
                TotalCapacity =+ car.passengerСapacity;
            }

            return TotalCapacity;
        }

        public int TotalLuggageCapacity()
        {
            int TotalCapacity = 0;

            foreach (TrainCar car in train)
            {
                TotalCapacity = +car.luggageCapacity;
            }

            return TotalCapacity;
        }
    }
}
