using Bank_Practice.Inside_Bank;
using Bank_Practice.Entities;

namespace Bank_Practice.Static_Classes
{
    public static class Configuration
    {
        private static Client[] GetClients()
        {
            Client c1 = new Client("Mike", "Tyson", 30, 5_000, "Canada", "Ring");
            Client c2 = new Client("Al", "Pacino", 50, 50_000, "USA", "Film Studio");
            Client c3 = new Client("Brad", "Pitt", 29, 50_000_000, "USA", "Best Actor in the World");
            Client c4 = new Client("Conor", "McGregor", 35, 5_000_000, "Ireland", "UFC");

            return new Client[] { c1, c2, c3, c4 };

        }
        public static Credit[] GetCreditedClients()
        {
            Client[] clients = GetClients();

            Credit cre1 = new Credit(clients[0], 200, 12);
            Credit cre2 = new Credit(clients[1], 4000, 12);
            Credit cre3 = new Credit(clients[2], 20_000, 24);
            Credit cre4 = new Credit(clients[3], 100_000, 12);


            return new Credit[] { cre1, cre2, cre3, cre4 };            
        }

        public static Worker[] GetWorkers()
        {
            Worker w1 = new Worker("Alex", "Talan", 25, "Programmer", 3_000);
            Worker w2 = new Worker("Max", "Holloway", 30, "Trader", 2_500);
            Worker w3 = new Worker("Paul", "Gonzalez", 20, "Graphic Designer", 4_000);
            Worker w4 = new Worker("Bruno", "Saturn", 31, "Artificial Intelligence Engineer", 20_000);

            return new Worker[] { w1, w2, w3, w4 };

        }

        public static Manager[] GetManagers()
        {
            Manager m1 = new Manager("Michael", "Jackson", 33, "Dance Manager", 40_000);
            Manager m2 = new Manager("Oreol", "Paulo", 35, "Risk Manager", 44_000);
            Manager m3 = new Manager("Anderson", "Silva", 33, "Business Manager", 50_000);

            return new Manager[] { m1, m2, m3 };

        }
        public static string[] GetCEOMenu()
        {            
            return new string[] { "Organize", "Show All Credited Clients", "Show Bank Info", 
                "Show All Managers", "Show All Workers", "Change Percentage", "Make Meeting",
                "Increase Manager Salary", "Increase Worker Salary", "Back" };
        }
        public static string[] GetClientMenu()
        {
            return new string[] { "Get Credit", "Pay Credit", "Show Credit Info", "Back" };
        }
        public static string[] GetClientHeadMenu()
        {
            return new string[] { "Register", "Login", "Exit"};
        }

        public static string[] GetManagerMenu()
        {
            return new string[] { "Calculate Salaries", "Organize", "Add Worker", "Back" };
        }
        public static string[] GetFirstMenu()
        {
            return new string[] { "CEO", "Manager", "Client", "Worker", "Exit" };
        }
        public static string[] GetMonthMenu()
        {
            return new string[] { "12 Month", "24 Month", "36 Month" };
        }
        public static string[] GetWorkerMenu()
        {
            return new string[] { "Show Added Operations", "Add Operation", "Back" };
        }
        public static void PrintMenu(in string[] menu)
        {
            System.Console.Clear();
            for (int i = 0; i < menu.Length; i++)
            {
                System.Console.WriteLine($"{i + 1}.{menu[i]}");
            }
        }

    }
}
