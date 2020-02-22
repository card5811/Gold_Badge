using Badge_Challenege;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge_Console
{
    class Badge_Console
    {
        private readonly Badge_Repo _repo = new Badge_Repo();
        private readonly Badge _badge = new Badge();
        Dictionary<int, List<string>> _access = new Dictionary<int, List<string>>();
        private int keyToMatch;

        static void Main(string[] args)
        {
            Badge_Console ui = new Badge_Console();
            ui.Run();
        }

        public void Run()
        {
            SeedContent();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Select an option by number. \n" +
                    "1. Add an Id number and assign access\n" +
                    "2. Edit ID and access\n" +
                    "3. Show All ID and door Access\n" +
                    "4. Delete an ID\n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1": //add id
                        AddToDictionary();
                        break;
                    case "2": //find specific id
                        GetContentById();
                        break;
                    case "3"://see all
                        GetAllContent();
                        break;
                    case "4":
                        //UpdateExistingContent();
                        break;
                    case "5"://exit
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        //create
        private void AddToDictionary()
        {
            Badge content = new Badge();
            Console.WriteLine("Enter Claim ID.");
            content.ID = Convert.ToInt32(Console.ReadLine());

            List<string> doors = new List<string>();
            Console.WriteLine("What doors will the ID have access to?");
            doors.Add(Console.ReadLine());
        }

        //read
        private void GetContentById()
        {
            Console.Clear();

            Dictionary<int, List<string>> access = new Dictionary<int, List<string>>();

            foreach (var data in access)
            {
                Console.WriteLine($"     {"ID",-25}{"Door Accessed",-25}");
                Console.WriteLine($"     {_access.Keys,-25}{_access.Values,-25}");

            }
            Console.WriteLine("Press any button to Continue.");
            Console.ReadLine();
        }

        private void GetAllContent()
        {
            Console.Clear();

            Dictionary<int, List<string>> access = _repo.GetAllContent();

            foreach (var content in access)
            {
                Console.WriteLine($"     {"Claim ID",-25}{"Claim Type",-25}");
                Console.WriteLine($"     {access.Keys,-25}{access.Values,-25}");

            }
            Console.WriteLine("Press any button to Continue.");
            Console.ReadLine();

        }
        //edit

        private void UpdateExistingContent()
        {
            Console.Clear();

            Console.WriteLine("Enter the ID number you want.");
            int id = Convert.ToInt32(Console.ReadLine());
            Dictionary<int, List<string>> existingContent = _repo.GetAllContent();

            if (existingContent == null)
            {
                Console.WriteLine("There is no content.\n" +
                    "Press any key to continue...");
                Console.ReadKey();
            }
            else
            {
                Dictionary<int, List<string>> content = new Dictionary<int, List<string>>();
                Console.WriteLine($"Current ID is {existingContent.Keys}");

                Console.WriteLine($"Current door Access is {existingContent.Values}." +
                    $"\nPlease enter new description:");
                content.Add(_access = new Dictionary<int, List<string>>());

                _access.UpdateExistingContent(existingContent.TryGetValue, content);
                Console.WriteLine("Your content has been updated. Press any key to continue...");
                Console.ReadKey();

            }
       
            private void SeedContent()
            {
                Dictionary<int, List<string>> one = new Dictionary<int, List<string>>(1, "A1");
                _access.AddToDictionary(one);
            }
    }
}
