using System;
using static System.Console;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pathTotalActivities= @"c:\Users\munoz.txt";
            List<string> totalactivities = new List<string>();
            List<string> activities= new List<string>();
            List<DateTime> initialtime = new List<DateTime>();
            List<string> StartedActivities = new List<string>();
            List<string> StartedActivitiesRemaining= new List<string>();
            List<DateTime> completedtime = new List<DateTime>();
            List<string> CompletedActivities = new List<string>();
            List<TimeSpan> averagetime = new List<TimeSpan>();
            int incomplete;
            int inprogress;
            double averageseconds = 0;
            TimeSpan averagedate;
                        if (File.Exists("Activities.csv"))
                        {
                            string[] savedactivities = File.ReadAllLines("Activities.csv");
                            totalactivities=savedactivities.ToList();
                        }
            while (true)
            {
                int menu = Menu();
                switch (menu)
                {
                    case 1:
                    SeeCurrentList( totalactivities);
                    break;
                    case 2:
                        AddToDoList( totalactivities,  activities);
                        File.WriteAllLines("Activities.csv", totalactivities);
                        break;
                    case 3:
                        StartActivity( totalactivities,  activities,  StartedActivities,  StartedActivitiesRemaining,  initialtime);
                        break;
                    case 4:
                        CompleteActivity( totalactivities,  StartedActivities,  CompletedActivities,  completedtime);
                        break;
                    case 5:
                        RemoveActivity( totalactivities,  activities,  StartedActivities,  CompletedActivities,  StartedActivitiesRemaining);
                        break;
                    case 6:
                    StatsCalc( totalactivities,  StartedActivities,  StartedActivitiesRemaining,  CompletedActivities,  initialtime,  completedtime,  averagetime, out averagedate, ref averageseconds, out incomplete, out inprogress);
                        StatsView( totalactivities,  StartedActivities,   CompletedActivities,  initialtime,  completedtime,  averagetime,  ref averagedate,  ref averageseconds,  ref incomplete,  ref inprogress);
                        break;
                }
                if (menu == 7)
                {
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
                    string[] greetings = new string[] { "It is good to see you.", "How is it going?", "Hello, lovely user.", "Hello, there.", "Hey, how are things?", "What's up?", "How's everything going?", "Salut!", "Hey, how are you?", "Hello User, have a good day!!!" };
                    Random random = new Random();
                    ForegroundColor = ConsoleColor.White;
                    string randomgreeting = greetings[random.Next(greetings.Length)];
                    WriteLine($"{randomgreeting}");
                    string title = "TO DO LIST MENU";
                    ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(@$"{title,50}");
                     ForegroundColor = ConsoleColor.DarkYellow;
                    WriteLine("1. See current List");
                    ForegroundColor = ConsoleColor.Blue;
                    WriteLine("2. Add activities");
                    ForegroundColor = ConsoleColor.Green;
                    WriteLine("3. Start an activity.");
                    ForegroundColor = ConsoleColor.DarkMagenta;
                    WriteLine("4. Complete an activity");
                    ForegroundColor = ConsoleColor.Cyan;
                    WriteLine("5. Remove an activity");
                    ForegroundColor = ConsoleColor.Magenta;
                    WriteLine("6. See statitics");
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("7. Exit");
                    ForegroundColor = ConsoleColor.DarkGray;
                    Write("Type the number of the action you wamt to do: ");
                    ForegroundColor = ConsoleColor.White;
                    int choice = Convert.ToInt32(ReadLine());
                    if (choice == 1 || choice == 2 || choice == 3 || choice == 4 || choice == 5 || choice == 6 || choice == 7)
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

        static void AddToDoList( List<string> totalactivities, List<string> activities)
        {

            while (true)
            {
                string title = "TO DO LIST";
                ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@$"{title,50}");
                ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(@$"Type 'Back' to go back to the menu");
                ForegroundColor = ConsoleColor.White;
                if (totalactivities.Count == 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NO ACTIVITIES YET");
                }
                else
                {
                    for (int x = 0; x < totalactivities.Count; x++)
                    {
                        WriteLine($"{x + 1}.- {totalactivities[x]}");
                    }

                }

                ForegroundColor = ConsoleColor.Blue;
                Write("Add new activity: ");
                ForegroundColor = ConsoleColor.White;
                string? useractivities = ReadLine();
                if (useractivities != "" && useractivities != "Back" && useractivities != "back")
                {
                    totalactivities.Add(useractivities);
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
         static void AddToDoListSaved( List<string> totalactivities, List<string> activities,  string[] savedactivities)
        {

            while (true)
            {
                totalactivities = savedactivities.ToList();
                string title = "TO DO LIST";
                ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@$"{title,50}");
                ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(@$"Type 'Back' to go back to the menu");
                ForegroundColor = ConsoleColor.White;
                if (totalactivities.Count == 0)
                {
                    ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("NO ACTIVITIES YET");
                }
                else
                {
                    for (int x = 0; x < totalactivities.Count; x++)
                    {
                        WriteLine($"{x + 1}.- {totalactivities[x]}");
                    }

                }

                ForegroundColor = ConsoleColor.Blue;
                Write("Add new activity: ");
                ForegroundColor = ConsoleColor.White;
                string? useractivities = ReadLine();
                if (useractivities != "" && useractivities != "Back" && useractivities != "back")
                {
                    totalactivities.Add(useractivities);
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
        public static void StartActivity( List<string> totalactivities,  List<string> activities,  List<string> StartedActivities,  List<string> StartedActivitiesRemaining,  List<DateTime> initialtime)
        {
            while (true)
            {
                if (totalactivities.Count == 0)
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
                        AskforActivityStarting( totalactivities,  activities,  StartedActivities,  StartedActivitiesRemaining,  initialtime);
                        break;
                    }
                    break;
                }



            }
        }
        public static void AskforActivityStarting( List<string> totalactivities,  List<string> activities,  List<string> StartedActivities, List<string> StartedActivitiesRemaining,   List<DateTime> initialtime)
        {

            while (true)
            {
                string title = "CURRENT ACTIVITIES";
                ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@$"{title,50}");
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
                            StartedActivitiesRemaining.Add(activities[x]);
                            activities.RemoveAt(i-1);
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
        static void CompleteActivity( List<string> totalactivities,  List<string> StartedActivities,  List<string> CompletedActivities,  List<DateTime> completedTime)
        {
            while (true)
            {
                if (totalactivities.Count == 0)
                {
                    ForegroundColor = ConsoleColor.White;
                    string title = "STARTED ACTIVITIES";
                    ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(@$"{title,50}");
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("No activities yet");
                    ForegroundColor = ConsoleColor.DarkGray;
                    Write("Press any key to go back: ");
                    ReadKey();
                    Clear();
                    break;
                }
                if (StartedActivities.Count == 0 && totalactivities.Count > 0)
                {
                    ForegroundColor = ConsoleColor.White;
                    string title = "STARTED ACTIVITIES";
                    ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(@$"{title,50}");
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("You have not started an activity yet. Go back to the menu to start an activity.");
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
                        AskForActivityCompleting( StartedActivities,  CompletedActivities,  completedTime);
                        break;
                    }
                    break;

                }
            }
        }
        static void AskForActivityCompleting( List<string> StartedActivities,  List<string> CompletedActivities,  List<DateTime> completedTime)
        {
            while (true)
            {
                string title = "STARTED ACTIVITIES";
                ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(@$"{title,50}");
                ForegroundColor = ConsoleColor.DarkGray;
                WriteLine("0.- GO BACK");
                try
                {
                    for (int x = 0; x < StartedActivities.Count; x++)
                    {
                        ForegroundColor = ConsoleColor.White;
                        WriteLine($"{x + 1}.- {StartedActivities[x]}");
                    }
                    ForegroundColor = ConsoleColor.White;
                    Write("Put the number of the activity you would like to complete: ");
                    int i = Convert.ToInt32(ReadLine());
                    if (i == 0)
                    {
                        Clear();
                        break;
                    }
                    if (i > StartedActivities.Count)
                    {
                        Clear();
                        ForegroundColor = ConsoleColor.Red;
                        WriteLine("That is not within the range. Try again");
                        continue;
                    }
                    else
                    {

                        Clear();
                        for (int x = i - 1; x < StartedActivities.Count;)
                        {
                            CompletedActivities.Add(StartedActivities[x]);
                            completedTime.Add(DateTime.Now);
                            StartedActivities.RemoveAt(i-1);
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
        public static void RemoveActivity( List<string> totalactivities,  List<string> activities,  List<string> StartedActivities,  List<string> CompletedActivities,  List<string> StartedActivitiesRemaining)
        {
            while (true)
            {
                if (totalactivities.Count == 0)
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
                        try
                        {

                            ForegroundColor = ConsoleColor.DarkYellow;
                            WriteLine("REMOVE ACTIVITIES");
                            ForegroundColor = ConsoleColor.White;
                            WriteLine("1.-Remove ALL the activities");
                            WriteLine("2.-Remove a specific activity.");
                            WriteLine("3.-Back");
                            ForegroundColor = ConsoleColor.DarkGray;
                            Write("Type the number of the action you wamt to do: ");
                            ForegroundColor = ConsoleColor.White;
                            int choice = Convert.ToInt32(ReadLine());

                            if (choice == 1)
                            {
                                Clear();
                                totalactivities.Clear();
                            activities.Clear();
                                StartedActivities.Clear();
                                CompletedActivities.Clear();
                                StartedActivitiesRemaining.Clear();
                                WriteLine("Everything is clear. Press any key to continue");
                                ReadKey();
                                break;
                            }
                            if (choice == 2)
                            {
                                Clear();
                                while (true)
                                {
                                    string title = "REMOVE ACTIVITIES";
                                    ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine(@$"{title,50}");
                                    ForegroundColor = ConsoleColor.DarkGray;
                                    WriteLine("0.- GO BACK");
                                    try
                                    {

                                        for (int x = 0; x < totalactivities.Count; x++)
                                        {
                                            ForegroundColor = ConsoleColor.White;
                                            WriteLine($"{x + 1}.- {totalactivities[x]}");
                                            ForegroundColor = ConsoleColor.White;
                                        }
                                        Write("Put the number of the activity you would like to remove: ");
                                        int i = Convert.ToInt32(ReadLine());

                                        if (i == 0)
                                        {

                                            Clear();
                                            break;
                                        }
                                        if (i > totalactivities.Count)
                                        {
                                            Clear();
                                            ForegroundColor = ConsoleColor.Red;
                                            WriteLine("That is not within the range. Try again");
                                            continue;
                                        }
                                        else
                                        {
                                            Clear();
                                            totalactivities.RemoveAt(i - 1);
                                            activities.RemoveAt(i-1);
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
                            if (choice == 3)
                            {
                                Clear();
                                break;
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
                    break;
                }

            }
        }
        public static void SeeCurrentList( List<string> totalactivities)
        {
            while (true)
            {
                if (totalactivities.Count == 0)
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
   for (int x = 0; x < totalactivities.Count; x++)
                    {
                        WriteLine($"{x + 1}.- {totalactivities[x]}");
                    }
                    ReadKey();
                    break;
                    }
            }
        }
        public static void StatsCalc( List<string> totalactivities,  List<string> StartedActivities,  List<string> StartedActivitiesRemaining,  List<string> CompletedActivities,  List<DateTime> initialtime,  List<DateTime> completedtime,  List<TimeSpan> averagetime,out TimeSpan averagedate, ref double averageseconds, out int incomplete, out int inprogress)
        { 
                incomplete = totalactivities.Count - StartedActivitiesRemaining.Count;
                inprogress = StartedActivities.Count;
                for (int y = 0; y < completedtime.Count; y++)
                {
                    TimeSpan average = completedtime[y] - initialtime[y];
                    averagetime.Add(average);
                }

                for (int i = 0; i < averagetime.Count; i++)
                {
                    double totalseconds = +averagetime[i].TotalSeconds + 0;
                    averageseconds = totalseconds / averagetime.Count;
                }
                averagedate = TimeSpan.FromSeconds(averageseconds); 
            
        }
        public static void StatsView ( List<string> totalactivities,  List<string> StartedActivities, List<string> CompletedActivities,  List<DateTime> initialtime,  List<DateTime> completedtime,  List<TimeSpan> averagetime, ref TimeSpan averagedate, ref double averageseconds, ref int incomplete, ref int inprogress )
        {
            while (true)
            {
 Clear();
                ForegroundColor = ConsoleColor.Magenta;
                WriteLine("STATS");
                ForegroundColor = ConsoleColor.White;
                WriteLine($"1. Total amount of activities: {totalactivities.Count} ");
                WriteLine($"2. Current amount of incomplete activities: {incomplete}");
                 WriteLine($"3. Current amount of activities in progress: {inprogress}");
                WriteLine($"4. Current amount of completed activities: {CompletedActivities.Count}");
                WriteLine($"5. Average time to complete an activity: {averagedate.Days} d, {averagedate.Hours} h, {averagedate.Minutes} m, {averagedate.Seconds} s.");
                Write("Press any key to go back to the menu: ");
                ReadLine();
                Clear();
                break;
            }
        }
        enum status { Started}
    }
}