using System;
using static System.Console;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> activities = new List<string>();

            AddToDoList(ref activities );
        }
        
            static int Menu()
            {
                return 1;
            }
        
        static void AddToDoList(ref List<string> activities)
        {
 
            while (true)
            {
                string title = "TO DO LIST";
                ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(@$"{title,50}");
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
                        WriteLine($"{x+1} {activities[x]}");
                    }
                }

                ForegroundColor = ConsoleColor.Blue;
                Write("Add new activity: "); 
                 ForegroundColor = ConsoleColor.White;
                string? useractivities=ReadLine();
    if (useractivities!=""&&useractivities!="Exit"&&useractivities!="exit")
    {
                activities.Add(useractivities);
                Clear();
    }
    else if (useractivities=="")
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

    }
}
