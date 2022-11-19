using System;
using static System.Console;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> activities = new List<string>();
            List<DateTime> initialtime = new List<DateTime>();
            List<string> StartedActivities = new List<string>();
            
            
                    
            while (true)
            {
                int menu = Menu();
                switch (menu)
                {
                    case 1:
                        AddToDoList(ref activities);
                        break;
                    case 2:
                        StartActivity(ref activities, ref StartedActivities, ref initialtime);
                        break;
                    case 4:
                        Stats(ref activities);
                        break;
                }
            }
        }

        static int Menu()
        {
            while (true)
            {
                try
                {
                    string[] greetings = new string[] { "It is good to see you", "How is it going?", "Hello, lovely user", "Hi, there", "Hey,How are things?" };
                    Random randon = new Random();

                    ForegroundColor = ConsoleColor.White;
                    string title = "TO DO LIST MENU";
                    ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@$"{title,50}");
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine("1. Add activities");
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("2. Start an activity.");
                    ForegroundColor = ConsoleColor.DarkMagenta;
                    WriteLine("3. Complete an activity");
                    ForegroundColor = ConsoleColor.DarkBlue;
                    WriteLine("4. See Statistics");
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("4. Exit");
                    ForegroundColor = ConsoleColor.DarkGray;
                    Write("Type the number of the action you wamt to do: ");
                    ForegroundColor = ConsoleColor.White;
                    int choice = Convert.ToInt32(ReadLine());
                    if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5)
                    {
                        Clear();
                        return choice;
                    }
                    else
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("That is not in the options. Try again");
                    }
                }
                catch
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("That is not in the options. Try again");
                }
            }
        }

        static void AddToDoList(ref List<string> activities)
        {

            while (true)
            {
                string title = "TO DO LIST";
                ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@$"{title,50}");
                ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(@$"Type 'Back' to go back to the menu");
                ForegroundColor = ConsoleColor.White;
                if (activities.Count == 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NO ACTIVITIES YET");
                }
                else
                {
                    for (int x = 0; x < activities.Count; x++)
                    {
                        WriteLine($"{x + 1}.- {activities[x]}");
                    }

                }

                ForegroundColor = ConsoleColor.Blue;
                Write("Add new activity: ");
                ForegroundColor = ConsoleColor.White;
                string? useractivities = ReadLine();
                if (useractivities != "" && useractivities != "Back" && useractivities != "back")
                {
                    activities.Add(useractivities);
                    Clear();
                }
                else if (useractivities == "")
                {
                    Clear();
                    continue;
                }
                else
                {
                    Clear();
                    break;
                }
            }
        }
        public static void Stats(ref List<string> activities)
        {
            while (true)
            {
                if (activities.Count == 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("No activities yet");
                }
                else
                {
                    for (int x = 0; x < activities.Count; x++)
                    {
                        WriteLine($"{x + 1}.- {activities[x]}");
                    }
                }
                ForegroundColor = ConsoleColor.Yellow;
                Write("Press 'Enter' to go back to the menu: ");
                ForegroundColor = ConsoleColor.White;
                ConsoleKey key = Console.ReadKey().Key;
                if (key == ConsoleKey.Enter)
                {
                    Clear();
                    break;
                }
                else
                {
                    Clear();
                    continue;
                }
            }
        }
        public static void StartActivity(ref List<string> activities, ref List<string> StartedActivities, ref List<DateTime> initialtime)
        {
            while (true)
            {
                if (activities.Count == 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("No activities yet");
                    ForegroundColor = ConsoleColor.DarkGray;
                    Write("Press any key to go back: ");
                    ReadKey();
                    Clear();
                    break;
                }
                else
                {
                    while (true)
                    {
                        AskforActivityStarting(ref activities, ref StartedActivities, ref initialtime);
                        ReadLine();
                        break;
                    }
                    break;
                }



            }
        }
        public static void AskforActivityStarting(ref List<string> activities, ref List<string>   StartedActivities, ref List<DateTime> initialtime)
        {

            while (true)
            {
                ForegroundColor = ConsoleColor.DarkGray;
                WriteLine("0.- GO BACK");
                try
                {
                    for (int x = 0; x < activities.Count; x++)
                    {
                        ForegroundColor = ConsoleColor.White;
                        WriteLine($"{x + 1}.- {activities[x]}");
                    }

                    ForegroundColor = ConsoleColor.White;
                    Write("Put the number of the activity you would like to start: ");
                    int i = Convert.ToInt32(ReadLine());
                    if (i == 0)
                    {
                        Clear();
                        break;
                    }
                    if (i > activities.Count)
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("That is not within the range. Try again");
                        continue;
                    }

                    else
                    {

                        Clear();
                        for (int x = i - 1; x < activities.Count;)
                        {
                            StartedActivities.Add(activities[x]);
                            initialtime.Add(DateTime.Now);
                            break;
                        }
                    }
                }
                catch
                {
                    Clear();
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("That is not valid. Try again");
                    continue;
                }
            }
        }
    }
}
