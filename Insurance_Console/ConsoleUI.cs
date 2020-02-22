using Insurance_Challenge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insurance_Console
{
    public class ConsoleUI
    {
        private readonly Insurance_Repo _repo = new Insurance_Repo();
        private readonly Queue<Claim> _claim = new Queue<Claim>();

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
                    "1. Add Claim\n" +
                    "2. See Next Claim and remove from queue\n" +
                    "3. Show All Claims\n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();

                switch (userInput)
                {
                    case "1": //add claim
                        EnquiingClaimToQueue();
                        break;
                    case "2": //delete
                        DequeueClaimFromQueue();
                        break;
                    case "3"://see all
                        GetAllClaims();
                        break;
                    case "4"://exit
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }

        //create
        private void EnquiingClaimToQueue()
        {
            Claim content = new Claim();
            Console.WriteLine("Enter Claim ID.");
            content.ID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Add claim type by the following numbers\n" +
                "1. Auto \n" +
                "2. Home \n" +
                "3. Renters \n" +
                "4. Property \n");

            string type = Console.ReadLine();
            type = type.Replace(" ", "");
            type = type.Trim();

            switch (type)
            {
                case "1":
                    content.TypeOfClaim = ClaimType.Auto;
                    break;
                case "2":
                    content.TypeOfClaim = ClaimType.Home;
                    break;
                case "3":
                    content.TypeOfClaim = ClaimType.Renters;
                    break;
                case "4":
                    content.TypeOfClaim = ClaimType.Property;
                    break;
            }

            Console.WriteLine("Describe the incident");
            content.Description = Console.ReadLine();

            Console.WriteLine("How much money is this claim for?");
            content.Ammount = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("When did the incident happen?\n" +
                "Please enter date yyyy/mm/dd");
            content.DateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("When was the claim submitted?\n" +
                "Please enter date yyyy/mm/dd");
            content.DateClaimMade = Convert.ToDateTime(Console.ReadLine());

            _repo.EnquingClaimToQueue(content);
            Console.WriteLine("Your item has been added. Press any key to return to the menu.");
            Console.ReadKey();
        }

        //read
        private void GetAllClaims()
        {
            Console.Clear();

            Queue<Claim> directory = _repo.GetAllClaims();

            Console.WriteLine($"Current number of claims is: {directory.Count()}");
            foreach (Claim content in directory)
            {
                Console.WriteLine($"     {"Claim ID",-25}{"Claim Type",-25}{"Description",-25}{"Ammount",-12}{"Date Of Accident",-25}{"DateOfClaim",-27}{"Is Claim Valid",-25}");
                Console.WriteLine($"     {content.ID,-25}{content.TypeOfClaim,-25}{content.Description,-25}${content.Ammount,-10}{content.DateOfIncident,-25}{content.DateClaimMade,-32}{content.IsValid,-25}");

            }
            Console.WriteLine("Press any button to Continue.");
            Console.ReadLine();
        }
        //delete

        private void DequeueClaimFromQueue()
        {
            Console.Clear();
            Queue<Claim> current = _repo.GetAllClaims();

            if (current.Count > 0)
            {
                Claim peekClaim = current.Peek();
                Console.WriteLine("Here is the next queued claim.");
                Console.WriteLine($"{peekClaim.ID,-25}{peekClaim.TypeOfClaim,-25}{peekClaim.Description,-25}${peekClaim.Ammount,-10}{peekClaim.DateOfIncident,-25}{peekClaim.DateClaimMade,-32}{peekClaim.IsValid,-25}\n");

                Console.WriteLine("Would you like to proceed with this claim?\n" +
                    "1. Yes\n" +
                    "2. No");

                string peek = Console.ReadLine();
                peek = peek.Replace(" ", "");
                peek = peek.Trim();

                switch (peek)
                {
                    case "1":
                        current.Dequeue();
                        Console.WriteLine("This claim has been removed from the queue.\n" +
                            "Press any key to continue.");
                        Console.ReadKey();
                        break;
                    case "2":
                        break;
                }
            }
            else
            {
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
            }
        }
        private void SeedContent()
        {
            Claim one = new Claim(1432, ClaimType.Auto, "Totalled vehicle", 5000.00, new DateTime(2019, 01, 23), new DateTime(2020, 02, 15));
            _repo.EnquingClaimToQueue(one);

            Claim two = new Claim(3018, ClaimType.Home, "Tree hit home", 25000.00, new DateTime(2019, 11, 23), new DateTime(2020, 01, 15));
            _repo.EnquingClaimToQueue(two);

            Claim three = new Claim(142, ClaimType.Property, "Stolen pancake mix", 2.25, new DateTime(2020, 02, 15), new DateTime(2020, 02, 18));
            _repo.EnquingClaimToQueue(three);
        }

    }
}