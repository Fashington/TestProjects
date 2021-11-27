using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    class OperationsMenu
    {
        public void BuildOperation(Train train)
        {
            string promt = "Choose a train car to add: ";
            string[] options = { "1A class (Passangers: 23; Luggage: 115 kg.)", "1B class (Passangers: 52; Luggage: 364 kg.)", "2A class (Passangers: 66; Luggage: 462 kg.)", "Back to main menu" };

            MenuLogic carMenu = new MenuLogic(promt, options);
            int selectedIndex = carMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    train.AddTrainCar(23, 115, "1A");
                    BuildOperation(train);
                    break;
                case 1:
                    train.AddTrainCar(52, 364, "1B");
                    BuildOperation(train);
                    break;
                case 2:
                    train.AddTrainCar(66, 462, "2A");
                    BuildOperation(train);
                    break;
                case 3:
                    Menu menu = new Menu();
                    menu.Start();
                    break;
            }
        }

        public void RemoveOperation(Train train)
        {
            int index;

            Console.Clear();
            Console.WriteLine("Enter index of train car you want to remove:");
            index = int.Parse(Console.ReadLine());
            train.RemoveTrainCar(index);
            ViewOperation(train);
        }

        public void ViewOperation(Train train)
        {
            string promt = train.ViewTrain() + "\nTotal passanger capacity: " + train.TotalPassengerCapacity() + "\nTotal luggage capacity: " + train.TotalLuggageCapacity();
            string[] options = { "Remove train car", "Sort by class", "Sort by class in descending order", "Search train car by passanger capacity", "Back to Main menu" };
            MenuLogic editMenu = new MenuLogic(promt, options);
            int selectedIndex = editMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    RemoveOperation(train);
                    break;
                case 1:
                    train.SortByClass();
                    ViewOperation(train);
                    break;
                case 2:
                    train.SortByClassDescending();
                    ViewOperation(train);
                    break;
                case 3:
                    Console.Clear();
                    SearchOperation(train);
                    Console.WriteLine("Press any key to return to previos menu");
                    Console.ReadLine();
                    ViewOperation(train);
                    break;
                case 4:
                    Menu menu = new Menu();
                    menu.Start();
                    break;
            }
        }

        public void SearchOperation(Train train)
        {
            int lowLimit;
            int upLimit;

            Console.WriteLine("Enter a lower limit of passangers");
            lowLimit = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter an upper limit of passangers");
            upLimit = int.Parse(Console.ReadLine());

            Console.WriteLine(train.SearchOperation(lowLimit, upLimit));
        }
    }
}
