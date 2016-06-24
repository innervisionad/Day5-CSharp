using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Write a console application that prompts the user
            // to enter a list of integers, then offers them the choice of
            // getting the average of the list, sorting the list or
            // exiting the list
            
            //create an empty array for the use to store 10 numbers
             int[] numberAverage = new int[10];
            //create an array for the options available
            string[] commandArray = {"Average", "Sort", "List", "Exit"};
            //a boolean value to allow the program to exit upon the exit command
            bool running = true;

            // Welcome message and options available for use.
            Console.WriteLine("Welcome to my console program. Here you can add numbers, and use those numbers to obtain an average");
            Console.WriteLine("Please enter 10 numbers, pressing enter each time");
            //Console.ReadLine();

            // a for loop to add 10 numbers and store them in the array numberAverage
            for (int i = 0; i < 10; i++)
             {
                 Console.WriteLine("Please enter number {0}", i + 1);
                 numberAverage[i] = Convert.ToInt32(Console.ReadLine());
             }

            while (running)
            {
                //user inputs the command they would like to do
                Console.WriteLine("What would you like to do? {0}, {1}, {2}, or {3}", commandArray[0], commandArray[1], commandArray[2], commandArray[3]);  
                String command = Console.ReadLine();
             
                switch (command)
                {
                    case "Average":
                        //calculate the average of the numbers
                        double average = numberAverage.Average();
                        //display numbers onto the console window
                        Console.WriteLine("The Average of your numbers are {0}.", average);
                        break;

                    case "Sort":
                        //sort numbers in order
                        Array.Sort(numberAverage);
                        //confirmation of numbers being sorted
                        Console.WriteLine("Your numbers have been sorted!");
                        break;

                    case "List":
                        //display a list of the numbers
                        foreach (int i in numberAverage)
                        {
                            Console.WriteLine( i );
                        }
                        break;

                    case "Exit":
                        //exit the program
                        running = false;
                        break;
                    default:
                        //in case of a bad command, this will display on the screen and another use input would be required
                        Console.WriteLine("Command not recognised");
                        break;

                }

            }
     
        }
    }
}

