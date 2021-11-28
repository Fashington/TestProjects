using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class Train
    {
        private List<TrainCar> trainCars = new List<TrainCar>();

        public void AddTrainCar(int passangerCapacity, int luggageCapacity, string trainCarType)
        {
            trainCars.Add(new TrainCar() { PassengerСapacity = passangerCapacity, LuggageCapacity = luggageCapacity, TrainCarType = trainCarType });
        }

        public void RemoveTrainCar(int index)
        {
            trainCars.RemoveAt(index);
        }

        public string ViewTrain()
        {
            if (trainCars.Count() != 0)
            {
                string answer = "";
                foreach (TrainCar item in trainCars)
                {
                    answer += "Class: " + item.TrainCarType+ " | ";
                    answer += "Passanger capacity: " + item.PassengerСapacity + " | ";
                    answer += "Luggage capacity: " + item.LuggageCapacity + " |\n";
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
            var orderByClass = trainCars.OrderBy(c => c.TrainCarType).ToList();
            trainCars.Clear();
            trainCars.AddRange(orderByClass);
        }

        public void SortByClassDescending()
        {
            var orderByClassDescending = trainCars.OrderByDescending(c => c.TrainCarType).ToList();
            trainCars.Clear();
            trainCars.AddRange(orderByClassDescending);
        }

        public string SearchOperation(int lowLimit, int upLimit)
        {
            var searchLowwerUpper = from item in trainCars
                                    where item.PassengerСapacity >= lowLimit && item.PassengerСapacity <= upLimit
                                    select item;

            string answer = "";
            foreach (var item in searchLowwerUpper)
            {
                answer = answer + $"Class: {item.TrainCarType} | Passanger capacity: {item.PassengerСapacity} | Luggage capacity: {item.LuggageCapacity}\n";
            }
            return answer;
        }

        public int TotalPassengerCapacity()
        {
            int totalCapacity = 0;

            foreach (TrainCar car in trainCars)
            {
                totalCapacity = totalCapacity + car.PassengerСapacity;
            }

            return totalCapacity;
        }

        public int TotalLuggageCapacity()
        {
            int totalCapacity = 0;

            foreach (TrainCar car in trainCars)
            {
                totalCapacity = totalCapacity + car.LuggageCapacity;
            }

            return totalCapacity;
        }
    }
}
