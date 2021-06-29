using Developers;
using DeveloperTeams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interface
{
    class ProgramUI
    {
        protected readonly DevRepo _devDirectory = new DevRepo();
        protected readonly DevTeamRepo _devTeamDirectory = new DevTeamRepo();

        public void Run()
        {
            DisplayMenu();
        }

        private void DisplayMenu()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine(
                    "What can I help you with today? \n" +
                    "1. Add, update, or remove developers \n" +
                    "2. Create, change, or delete teams \n" +
                    "3. Exit \n" +
                    "Enter the number of the option you would like to select");

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine(
                            "What would you like to do?\n" +
                            "1. Create a new developer\n" +
                            "2. Update developer info\n" +
                            "3. Remove a developer\n" +
                            "4. List all developers\n" +
                            "Enter the number of the option you would like to select");
                            string userInputDev = Console.ReadLine();
                        switch (userInputDev)
                        {
                            case "1":
                                CreateDeveloper();
                                break;
                            case "2":
                                UpdateDeveloper();
                                break;
                            case "3":
                                DeleteDeveloper();
                                break;
                            case "4":
                                ListDevelopers();
                                break;
                            default:
                                Console.WriteLine("Please enter a valid option 1-4");
                                ReduceRed();
                                break;
                        }
                        break;

                    case "2":
                        Console.Clear();
                        Console.WriteLine(
                            "What would you like to do?\n" +
                            "1. Create a new team\n" +
                            "2. Change team info\n" +
                            "3. Add a developer to a team\n" +
                            "4. Remove a developer from the team\n" +
                            "5. List all teams\n" +
                            "Enter the number of the option you would like to select");
                            string userInputTeam = Console.ReadLine();
                        switch (userInputTeam)
                        {
                            case "1":
                                CreateTeam();
                                break;
                            case "2":
                                ChangeTeamDetails();
                                break;
                            case "3":
                                AddDeveloper();
                                break;
                            case "4":
                                RemoveDeveloper();
                                break;
                            case "5":
                                ListTeams();
                                break;
                            default:
                                Console.WriteLine("Please enter a valid option 1-5");
                                ReduceRed();
                                break;
                        }
                        break;
                    case "3":
                        isRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid option 1-3");
                        ReduceRed();
                        break;
                }
            }


        }
        private void CreateDeveloper()
        {
            Console.Clear();

            Console.WriteLine("What is the developer's ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("What is their first name?\n");
            string first = Console.ReadLine();

            Console.WriteLine("What is their last name?\n");
            string last = Console.ReadLine();

            Console.WriteLine("Do they have access to Pluralsight? \n Enter yes or no:");
            string userInput = Console.ReadLine();
            bool access = false;
            switch (userInput.ToLower())
            {
                case "yes":
                    access = true;
                    break;
                case "no":
                    access = false;
                    break;
                default:
                    access = false;
                    break;
            }

            Devs developer = new Devs(id, first, last, access);
            _devDirectory.AddDeveloper(developer);
            ReduceRed();
        }

        private void UpdateDeveloper()
        {
            Console.Clear();

            Console.WriteLine("Which developer would you like to update?");
            _devDirectory.DisplayAll();
            Console.WriteLine("Enter their unique ID:");
            int userInput = int.Parse(Console.ReadLine());

            //Console.Clear();

            Console.WriteLine("Enter their new ID:");
            int newID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter their first name:");
            string newFirst = Console.ReadLine();

            Console.WriteLine("Enter their last name:");
            string newLast = Console.ReadLine();

            Console.WriteLine("Do they have access to Pluralsight? \n Enter yes or no:");
            string userInput2 = Console.ReadLine();
            bool newAccess = false;
            switch (userInput2.ToLower())
            {
                case "yes":
                    newAccess = true;
                    break;
                case "no":
                    newAccess = false;
                    break;
                default:
                    newAccess = false;
                    break;
            }

            Devs updatedInfo = new Devs(newID, newFirst, newLast, newAccess);

            _devDirectory.UpdateDev(userInput, updatedInfo);
            ReduceRed();
        }

        private void DeleteDeveloper()
        {
            Console.Clear();

            Console.WriteLine("Which developer would you like to remove?");
            _devDirectory.DisplayAll();
            Console.WriteLine("Enter their unique ID:");
            int devID = int.Parse(Console.ReadLine());
            _devDirectory.RemoveDev(_devDirectory.GetByID(devID));
            ReduceRed();

        }

        private void ListDevelopers()
        {
            _devDirectory.DisplayAll();
            ReduceRed();
        }

        private void CreateTeam()
        {
            Console.Clear();

            Console.WriteLine("What is the Team ID:");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("What is the Team Name?\n");
            string name = Console.ReadLine();

            DevTeam team = new DevTeam(id, name);
            _devTeamDirectory.AddTeam(team);
            ReduceRed();
        }

        private void ChangeTeamDetails()
        {
            Console.Clear();

            Console.WriteLine("Which team would you like to change?");
            _devTeamDirectory.DisplayAllTeams();
            Console.WriteLine("Enter the Team ID:");
            int userInput = int.Parse(Console.ReadLine());

            //Console.Clear();

            Console.WriteLine("Enter the new Team ID:");
            int newID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the new Name:");
            string newName = Console.ReadLine();

            DevTeam updatedInfo = new DevTeam(newID, newName);

            _devTeamDirectory.UpdateTeam(userInput, updatedInfo);
            ReduceRed();
        }

        private void AddDeveloper()
        {
            Console.Clear();

            Console.WriteLine("Which team would you like to add a member to?");
            _devTeamDirectory.DisplayAllTeams();
            Console.WriteLine("Enter the Team ID:");
            int teamID = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Who would you like to add to this team?");
            _devDirectory.DisplayAll();
            Console.WriteLine("Enter their unique ID");
            int devID = int.Parse(Console.ReadLine());

            _devTeamDirectory.AddTeamMember(teamID, devID);
            ReduceRed();
        }

        private void RemoveDeveloper()
        {
            Console.Clear();

            Console.WriteLine("Which team would you like to remove a member from?");
            _devTeamDirectory.DisplayAllTeams();
            Console.WriteLine("Enter the Team ID:");
            int teamID = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Who would you like to remove from this team?");
            DevTeam team = _devTeamDirectory.GetByTeamID(teamID);
            foreach(int id in team.DevList)
            {
                Devs dev = _devDirectory.GetByID(id);
                Console.WriteLine($"{dev.ID} {dev.FullName}");
            }
            Console.WriteLine("Enter their unique ID");
            int devID = int.Parse(Console.ReadLine());

            _devTeamDirectory.RemoveTeamMember(teamID, devID);
            ReduceRed();
        }

        private void ListTeams()
        {
            _devTeamDirectory.DisplayAllTeams();
            ReduceRed();
        }

        private void ReduceRed()
        {
            Console.WriteLine("Press any key to return to the main menu...");
            Console.ReadKey();
        }
    }
}
