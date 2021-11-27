using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Diagnostics;
using System.IO;

namespace Train
{
    class Menu
    {
        static Train newTrain = new Train();

        public void Start()
        {
            Title = "EPAM .Net Course. Task1";
            RunMainMenu();

            WriteLine("Press any key to exit...");
            ReadKey(true);
        }

        private void RunMainMenu()
        {
            string promt = "Train builder.\nUse arrow keys to cycle through options. Press ENTER to choose";
            string[] options = { "Build a train", "View train", "Exit" };
            MenuLogic mainMenu = new MenuLogic(promt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    OperationsMenu operation = new OperationsMenu();
                    operation.BuildOperation(newTrain);
                    break;
                case 1:
                    OperationsMenu viewOperation = new OperationsMenu();
                    viewOperation.ViewOperation(newTrain);
                    break;
                case 2:
                    ExitOption();
                    break;
            }
        }

        private void ExitOption()
        {
            WriteLine("\nPress any key to exit...");
            ReadKey(true);
            Environment.Exit(0);
        }
    }
}
