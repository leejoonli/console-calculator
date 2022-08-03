using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool close_app = false;

            Console.WriteLine("Console Calculator in C#\r");
            Console.WriteLine("------------------------\n");

            while(!close_app)
            {
                string op = "";
                string num_input_one = "";
                string num_input_two = "";
                double result = 0;
                double clean_num_one = 0;
                double clean_num_two = 0;

                Console.Write("Type a number, and then press Enter:\n");
                num_input_one = Console.ReadLine();

                while (!double.TryParse(num_input_one, out clean_num_one))
                {
                    Console.Write("This is not a valid input. Please enter an integer value:\n");
                    num_input_one = Console.ReadLine();
                }

                Console.Write("Type another number, and then press Enter:\n");
                num_input_two = Console.ReadLine();

                while (!double.TryParse(num_input_two, out clean_num_two))
                {
                    Console.Write("This is not a valid input. Please enter an integer value:\n");
                    num_input_two = Console.ReadLine();
                }

                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\ta - Add");
                Console.WriteLine("\ts - Subtract");
                Console.WriteLine("\tm - Multiply");
                Console.WriteLine("\td - Divide");
                Console.WriteLine("Your option?");

                op = Console.ReadLine();

                try
                {
                    result = Calculator.Operation(clean_num_one, clean_num_two, op);
                    if (double.IsNaN(result))
                    {
                        Console.WriteLine("This operation will result in a mathematical error.\n");
                    }
                    else Console.WriteLine("Your result: {0:0.##}\n", result);
                }
                catch (Exception e)
                {
                    Console.WriteLine("An exception occurred trying to do the math.\n - Detail: " + e.Message);
                }

                Console.WriteLine("------------------------\n");

                Console.WriteLine("Type 'exit' and Enter to close the app, or press any other key and Enter to continue: ");

                if(Console.ReadLine() == "exit")
                {
                    close_app = true;
                }
                Console.WriteLine("\n");
            }
            return;
        }
    }

    internal class Calculator
    {
        public static double Operation(double num_one, double num_two, string op)
        {
            double result = double.NaN;

            switch(op)
            {
                case "a":
                    result = num_one + num_two;
                    break;
                case "s":
                    result = num_one - num_two;
                    break;
                case "m":
                    result = num_one * num_two;
                    break;
                case "d":
                    if(num_two != 0)
                    {
                        result = num_one / num_two;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
    }
}
