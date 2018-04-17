using System;

namespace TurtleGraphics
{
    class Program
    {
        static Floor floor = new Floor(20, 20);
        static void Main(string[] args)
        {
            Console.Write(
                "Turtle Graphics" + Environment.NewLine +
                "Select an option." + Environment.NewLine +
                "1 Insert Commands" + Environment.NewLine +
                "2 Real Time Drawing" + Environment.NewLine +
                "Option: "
            );

            string input = Console.ReadLine();
            while (input != "1" && input != "2")
            {
                Console.Write(
                    "Invalid Option!" + Environment.NewLine +
                    "Option: "
                );
                input = Console.ReadLine();
            }

            if (input == "1")
                InsertComands();
            else
                RealTime();
        }

        static void InsertComands()
        {
            Console.Clear();
            Console.WriteLine("Options: 1 Pen up. 2 Pen down. 4 Girar Izq. 3 Girar Der.");
            Console.WriteLine("         5 Move [steps], 6 Print 7 END_FLAG.");
            Console.WriteLine("Insert Commands, All one line, space between instructions");
            Console.Write("Commands> ");
            string input = Console.ReadLine();
            Console.Clear();
            string[] commands = input.Split(' ');
            for (int i = 0; i < commands.Length; i++)
            {
                switch (commands[i])
                {
                    case "7":
                        return;
                    case "1":
                        floor.PenUp();
                        break;
                    case "2":
                        floor.PenDown();
                        break;
                    case "4":
                        floor.TurnTurtleLeft();
                        break;
                    case "3":
                        floor.TurnTurtleRight();
                        break;
                    case "5":
                        try { floor.MoveTurtle(int.Parse(commands[++i])); }
                        catch (Exception) { }
                        break;
                    case "6":
                        Console.WriteLine(floor.ToString());
                        break;
                }
            }
        }

        static void RealTime()
        {
            Console.Clear();
            while (true)
            {
                Console.WriteLine(floor.ToString() + Environment.NewLine +
                    "turtle = " + floor.Turtle.ToString()
                );
                Console.WriteLine("Options: 1 Pen up. 2 Pen down. 4 Girar Izq. 3 Girar Der.");
                Console.WriteLine("         5 Move [steps] 6 Clear 7 QUIT.");
                Console.Write("Command: ");
                string input = Console.ReadLine();
                string[] args = input.Split(' ');
                switch (args[0])
                {
                    case "7":
                        return;
                    case "1":
                        floor.PenUp();
                        break;
                    case "2":
                        floor.PenDown();
                        break;
                    case "4":
                        floor.TurnTurtleLeft();
                        break;
                    case "3":
                        floor.TurnTurtleRight();
                        break;
                    case "5":
                        try
                        { floor.MoveTurtle(int.Parse(args[1])); }
                        catch (Exception) { }
                        break;
                    case "6":
                        floor.Clear();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
