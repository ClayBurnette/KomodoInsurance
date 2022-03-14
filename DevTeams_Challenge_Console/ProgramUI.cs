using DevTeams_Challenge_Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevTeams_Challenge_Console
{
    class ProgramUI
    {
        private readonly DeveloperRepo _developerRepoUI = new DeveloperRepo();
        private readonly DevTeamRepo _devTeamRepoUI = new DevTeamRepo();
        // Starts My Application
        public void Run()
        {
            SetContent();
            DevMenu();
        }
        private void DevMenu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {
                // Options For User 
                Console.WriteLine("\nUsing the associated number, make a selection from the options below:\n" +
                    "\n" +
                    "1. Add New Development Teams To The Database.\n" +
                    "2. Add New Developers To The Database.\n" +
                    "3. View Current Development Teams.\n" +
                    "4. View Current Development Teams & Team Members.\n" +
                    "5. View Current Developers.\n" +
                    "6. Add A Developer To A Current Development Team.\n" +
                    "7. Remove A Development Team From The Database.\n" +
                    "8. Remove A Developer From The Database.\n" +
                    "9. Update Current Developer Information.\n" +
                    "10. Update Current Development Team Information.\n" +
                    "11. View Developers Who Need Pluralsight Access.\n" +
                    "0. Exit The Application\n");
                // User Input
                string devMenuInput = Console.ReadLine();

                switch (devMenuInput)
                {
                    case "1":
                        // Create Dev Team 
                        CreateDevTeam();
                        break;
                    case "2":
                        // Create Developer
                        CreateNewDeveloper();
                        break;
                    case "3":
                        // View Dev Team
                        DisplayIndTeam();
                        break;
                    case "4":
                        // View Dev Teams and Members
                        DisplayAllDevTeams();
                        break;
                    case "5":
                        // Current Developers
                        DisplayAllDevelopers();
                        break;
                    case "6":
                        // Add Developers To A Dev Team
                        AddDevToTeam();
                        break;
                    case "7":
                        // Remove Dev Team
                        RemoveDevTeam();
                        break;
                    case "8":
                        // Remove A Developer
                        RemoveDeveloper();
                        break;
                    case "9":
                        // Update Developer
                        UpdateDeveloper();
                        break;
                    case "10":
                        // Update a Development Team
                        UpdateTeam();
                        break;
                    case "11":
                        // View Developers Needing Pluralsight 
                        PluralLic();
                        break;
                    case "0":
                        // Exit The Application
                        Console.WriteLine("Exiting the Application....");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("/nPlease Enter a Valid Number.");
                        break;
                }
                Console.WriteLine("\nPress Any Key to Continue...\n");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateDevTeam()
        {
            bool exitMethodCrTe = true;
            while (exitMethodCrTe)
            {
                Console.Clear();
                DevTeam newDevTeam = new DevTeam();
                // Create Dev Team
                Console.WriteLine("\nCreate A Name For The New Development Team.");
                string devTeamName = Console.ReadLine();

                newDevTeam.DevTeamName = devTeamName;

                Console.WriteLine("\nEnter the Development Team ID #: 1 to 10");
                string devTeamStr = Console.ReadLine();

                int devTeamIdInt = Convert.ToInt32(devTeamStr);
                newDevTeam.DevTeamId = CheckTeamIdRange(devTeamIdInt);

                Console.WriteLine("\nType \"Add\" To Create Another Development Team.");

                Console.WriteLine("\nType \"Exit\" When Finished with Entries.");
                string exitCreDevTeam = Console.ReadLine().ToLower();

                bool createDevTeam = _devTeamRepoUI.AddDevTeamToList(newDevTeam);

                if (createDevTeam == true)
                {
                    Console.WriteLine("\nDevelopment Teams Added.");
                }
                if (exitCreDevTeam == "exit")
                {
                    exitMethodCrTe = false;
                }
            }
        }
        private void CreateNewDeveloper()
        {
            bool exitMethodCr = true;
            while (exitMethodCr)
            {
                Console.Clear();
                Developer newDeveloper = new Developer();
                // Create A Developer
                Console.WriteLine("\nEnter The Developer's First Name.");
                string firstNameStr = Console.ReadLine();
                newDeveloper.FirstName = firstNameStr;

                Console.WriteLine("\nEnter The Developer's Last Name.");
                string LastNameStr = Console.ReadLine();
                newDeveloper.LastName = LastNameStr;

                Console.WriteLine("\nEnter the Developer's ID #: 1 to 30.");
                string devIdStr = Console.ReadLine();
                newDeveloper.DevId = CheckDevIdRange(Convert.ToInt32(devIdStr));

                Convert.ToInt32(devIdStr);

                Console.WriteLine("\nEnter (Yes/No) if the Developer *Posseses a Pluralsight License.");
                string devLicense = Console.ReadLine().ToLower();

                if (devLicense == "yes")
                {
                    newDeveloper.HasLicense = true;
                }
                else
                {
                    newDeveloper.HasLicense = false;
                }
                bool addDeveloper = _developerRepoUI.AddDeveloperToList(newDeveloper);

                Console.WriteLine("\nType \"Add\" To Create Another Developer.");
                
                Console.WriteLine("\nType \"Exit\" When Finished with Entries.");
                string exitCreDev = Console.ReadLine().ToLower();

                if (addDeveloper == true)
                {
                    Console.WriteLine("\nDevelopers Added.");
                }
                if (exitCreDev == "exit")
                {
                    exitMethodCr = false;
                }
            }
        }
        private void DisplayIndTeam()
        {
            // View Dev Team
            Console.Clear();
            List<DevTeam> listIndDevT = _devTeamRepoUI.GetDevTeams();

            foreach (DevTeam devTe in listIndDevT)
            {
                Console.WriteLine($"\nDevelopment Team Name: {devTe.DevTeamName}" +
                    $"\nDevelopment Team ID Number: {devTe.DevTeamId}");
            }
        }
        private void DisplayAllDevTeams()
        {
            // View Teams & Team Members
            Console.Clear();
            List<DevTeam> listofDevTeams = _devTeamRepoUI.GetDevTeams();

            foreach (DevTeam devTeams in listofDevTeams)
            {
                Console.WriteLine($"\nDevelopment Team ID Number: {devTeams.DevTeamId}" +
                    $"\nDevelopment Team Name: {devTeams.DevTeamName}");
                foreach (Developer dev in devTeams.DevTeamMembers)
                {
                    Console.WriteLine($"\nDeveloper ID#: {dev.DevId}" +
                        $"\nDeveloper First Name: {dev.FirstName}" +
                        $"\nDeveloper Last Name: {dev.LastName}");
                }
            }
        }
        private void DisplayAllDevelopers()
        {
            // View Current Developes   
            Console.Clear();
            List<Developer> listofDevelopers = _developerRepoUI.GetDevelopers();

            foreach (Developer developer in listofDevelopers)
            {
                Console.WriteLine($"\nDeveloper ID Number: {developer.DevId}" +
                    $"\nDeveloper First Name: {developer.FirstName}" +
                    $"\nDeveloper Last Name: {developer.LastName}" +
                    $"\nDeveloper Has a License: {developer.HasLicense}\n");
            }
        }
        private async void AddDevToTeam()
        {
            bool exitMethodAddTe = true;
            while (exitMethodAddTe)
            {
                // Add A Developer To A Current Dev Team
                Console.Clear();
                _developerRepoUI.GetDevelopers();
                List<DevTeam> devAddTeam = _devTeamRepoUI.GetDevTeams();
                // Display Content
                DisplayBoth();
                Console.WriteLine("\nPlease Enter Developer ID # (1 to 30): \n");
                string localDev = Console.ReadLine();
                CheckDevIdRange(Convert.ToInt32(localDev));

                Console.WriteLine($"\nPlease Enter the Development Team Number to Assign Developer.");
                string localDevTeamStr = Console.ReadLine();
                Int32.TryParse(localDevTeamStr, out int localDevTeamId);

                DevTeam checkedDevId = _devTeamRepoUI.GetDevTeamId(localDevTeamId);
                foreach (DevTeam developerId in devAddTeam)
                {
                    if (localDevTeamId <= 10)
                    {
                        if (checkedDevId == null)
                        {
                            Console.WriteLine($"\nDeveloper Number: {localDev} Added To Development Team Number: {localDevTeamStr}\n");
                            _devTeamRepoUI.AddDevTeamMember(localDevTeamId);
                            await Task.Delay(1500);
                        }
                        else
                        {
                            Console.WriteLine($"\nDeveloper Number: {localDev} is Already Assigned To A Development Team.\n");
                            await Task.Delay(1500);
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nEnter a Valid Development Team ID #:\n");
                    }
                    Console.WriteLine("\nType \"Exit\" When Finished with Entries.");
                    string exitMethDis = Console.ReadLine().ToLower();

                    if (exitMethDis == "exit")
                    {
                        exitMethodAddTe = false;
                    }
                }
            }
        }
        private void RemoveDevTeam()
        {
            // Remove A Development Team
            _devTeamRepoUI.GetDevTeams();
            Console.Clear();
            // Display All Content
            DisplayIndTeam();

            Console.WriteLine("\nEnter the Development Team ID #:(1-10) for Removal.\n");
            string removeDevTeamID = Console.ReadLine();
            Int32.TryParse(removeDevTeamID, out int removeDevTeamInt);
            _devTeamRepoUI.RemoveDevTeamFromList(removeDevTeamInt);
        }
        private void RemoveDeveloper()
        {
            // Remove Developer From The Database
            _developerRepoUI.GetDevelopers();
            Console.Clear();
            DisplayAllDevelopers();

            Console.WriteLine("\nEnter the Developer ID #:(1-30) That You Want To Remove.\n");
            int removeDevId = Convert.ToInt32(Console.ReadLine());

            bool confirmDevDel = _developerRepoUI.RemoveDeveoperFromList(removeDevId);
            if (confirmDevDel == true)
            {
                Console.WriteLine($"\nDevelopment Team Member {confirmDevDel} was Removed.\n");
            }
        }
        private void UpdateDeveloper()
        {
            // Update Current Developer Information
            Developer newDev = new Developer();
            Console.Clear();
            DisplayAllDevelopers();

            Console.WriteLine("\nEnter the Developers ID Number.");
            int originId = Convert.ToInt32(Console.ReadLine());
            Developer oldDev = _developerRepoUI.GetDeveloperId(originId);

            Console.WriteLine("\nEnter the Developer's New ID #: 1 to 30.");
            newDev.DevId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter the Developer's New First Name.");
            newDev.FirstName = Console.ReadLine();

            Console.WriteLine("\nEnter the Developer's New Last Name.");
            newDev.LastName = Console.ReadLine();

            Console.WriteLine("\nEnter (Yes/No) If The Developer Has a Pluralsight License.");
            string newLic = Console.ReadLine().ToLower();

            if (newLic == "yes")
            {
                newDev.HasLicense = true;
            }
            else
            {
                newDev.HasLicense = false;
            }
            _developerRepoUI.UpdateDevelopers(oldDev, newDev);
        }
        private void UpdateTeam()
        {
            // Update Current Development Team Information
            DevTeam newTeam = new DevTeam();
            Console.Clear();
            DisplayIndTeam();

            Console.WriteLine("\nEnter the Development Team ID Number for Updating.");
            int teOriginId = Convert.ToInt32(Console.ReadLine());

            DevTeam oldDev = _devTeamRepoUI.GetDevTeamId(teOriginId);

            Console.WriteLine("\nEnter the New Development Team ID #: 1 to 10");
            newTeam.DevTeamId = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nEnter the New Name for the Development Team.");
            newTeam.DevTeamName = Console.ReadLine();
            newTeam.DevTeamMembers = oldDev.DevTeamMembers;
            _devTeamRepoUI.UpdateDevTeams(oldDev, newTeam);
        }
        private void PluralLic()
        {
            // View Developers Who Need Pluralsight Access
            Console.Clear();
            List<Developer> pluralDev = _developerRepoUI.GetDevoperPlural();

            foreach (Developer dev in pluralDev)
            {
                Console.WriteLine($"\nDeveloper ID: {dev.DevId}" +
                    $"\nFirst Name: {dev.FirstName}" +
                    $"\nLast Name: {dev.LastName}.\n");
            }
        }
        // Data Functions
        public int CheckDevIdRange(int idNumCheck)
        {
            if (idNumCheck <= 30)
            {
                return idNumCheck;
            }
            else
            {
                Console.WriteLine("\nPlease Re-Enter the Developer's ID #: 1 to 30.\n");
                string devIdStrRe = Console.ReadLine();
                // Exit Console
                idNumCheck = Convert.ToInt32(devIdStrRe);
                return idNumCheck;
            }
        }
        public int CheckTeamIdRange(int idTeamCheck)
        {
            if (idTeamCheck <= 10)
            {
                return idTeamCheck;
            }
            else
            {
                Console.WriteLine("\nPlease Re-Enter the Developer's ID #: 1 to 10.\n");
                string devIdStrRe = Console.ReadLine();
                // Exit Console
                idTeamCheck = Convert.ToInt32(devIdStrRe);
                return idTeamCheck;
            }
        }
        private void DisplayBoth()
        {
            List<Developer> displayBoth = _developerRepoUI.GetDevelopers();
            List<DevTeam> displayTeam = _devTeamRepoUI.GetDevTeams();

            foreach (Developer dev in displayBoth)
            {
                Console.WriteLine($"\nDeveloper ID Number: {dev.DevId}" +
                    $"\nDeveloper First Name: {dev.FirstName}" +
                    $"\nDeveloper Last Name: {dev.LastName}" +
                    $"\nDeveloper Has a License: {dev.HasLicense}\n");
            }
            foreach (DevTeam devTeam in displayTeam)
            {
                Console.WriteLine($"\nDevelopment Team Name: {devTeam.DevTeamName}" +
                $"\nDevelopment Team ID Number: {devTeam.DevTeamId}");
            }
        }
        // Content Section
        private void SetContent()
        {
            Developer dev1 = new Developer("Clay", "Burnette", 1, false);
            Developer dev2 = new Developer("Jacob", "Brown", 2, false);
            Developer dev3 = new Developer("Paul", "Niemczyk", 3, true);
            Developer dev4 = new Developer("TJ", "Hindman", 4, false);
            Developer dev5 = new Developer("Ethan", "Starling", 5, true);
            Developer dev6 = new Developer("Avery", "Finchum", 6, true);
            Developer dev7 = new Developer("Stephen", "Reilly", 7, false);
            Developer dev8 = new Developer("Chris", "Pettigrew", 8, true);
            Developer dev9 = new Developer("Hayden", "Linville", 9, true);
            Developer dev10 = new Developer("Cyrus", "Spencer", 10, false);
            Developer dev11 = new Developer("Victor", "Ryan", 11, true);
            Developer dev12 = new Developer("Corey", "Pfleiger", 12, false);

            _developerRepoUI.AddDeveloperToList(dev1);
            _developerRepoUI.AddDeveloperToList(dev2);
            _developerRepoUI.AddDeveloperToList(dev3);
            _developerRepoUI.AddDeveloperToList(dev4);
            _developerRepoUI.AddDeveloperToList(dev5);
            _developerRepoUI.AddDeveloperToList(dev6);
            _developerRepoUI.AddDeveloperToList(dev7);
            _developerRepoUI.AddDeveloperToList(dev8);
            _developerRepoUI.AddDeveloperToList(dev9);
            _developerRepoUI.AddDeveloperToList(dev10);
            _developerRepoUI.AddDeveloperToList(dev11);
            _developerRepoUI.AddDeveloperToList(dev12);


            List<Developer> devTeamMem1 = new List<Developer>
            {
                dev1,
                dev2,
                dev3
            };
            List<Developer> devTeamMem2 = new List<Developer>
            {
                dev4,
                dev5,
                dev6
            };
            List<Developer> devTeamMem3 = new List<Developer>
            {
                dev7,
                dev8,
                dev9
            };
            List<Developer> devTeamMem4 = new List<Developer>
            {
                dev10,
                dev11,
                dev12
            };
            DevTeam devT1 = new DevTeam("Hacking Hackathons", 1, devTeamMem1);
            DevTeam devT2 = new DevTeam("Mighty Programmers", 2, devTeamMem2);
            DevTeam devT3 = new DevTeam("System Breakers", 3, devTeamMem3);
            DevTeam devT4 = new DevTeam("Runtime Terror", 4, devTeamMem4);

            _devTeamRepoUI.AddDevTeamToList(devT1);
            _devTeamRepoUI.AddDevTeamToList(devT2);
            _devTeamRepoUI.AddDevTeamToList(devT3);
            _devTeamRepoUI.AddDevTeamToList(devT4);
        }
    }
}