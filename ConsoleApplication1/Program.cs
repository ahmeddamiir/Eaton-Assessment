using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApplication1
{
    // Monitor class that has "name" and "measurements" properties
    internal class Monitor
    {
        public string Name { get; }
        public List<int> Measurements { get; }
        
        public Monitor(string name)
        {
            Name = name;
            Measurements = new List<int>();
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            // Prompt the user for the number of monitors and save it to a variable
            Console.Write("How many monitor devices you have? ");
            
            if (int.TryParse(Console.ReadLine(), out var numberOfMonitors)) // valid number checker
            {
                var monitorsArray = new Monitor[numberOfMonitors]; // Each element in the array is a monitor device
            
                // Fulfill each element with the monitor device
                for (var i = 0; i < numberOfMonitors; i++)
                { 
                    monitorsArray[i] = new Monitor("MonitorDevice" + (i+1));
                }
                
                // Iterate over each monitor and get it's measurements from user
                foreach (var monitor in monitorsArray)
                {
                    
                    // Prompt for measurements of each monitor with conditional access space split between each measurement
                    Console.WriteLine("Enter " + monitor.Name + "'s measurements");
                    var measurements = Console.ReadLine()?.Split(' ');
                    
                    try
                    {
                        // Fulfill the original measurement property of devices with each parsed measurement
                        if (measurements != null)
                            foreach (var measurement in measurements)
                            {
                                monitor.Measurements.Add(int.Parse(measurement));
                            }
                    }
                    catch (FormatException) // Throw incorrect format error for uncooperative user
                    {
                        Console.WriteLine("Incorrect measurements");
                        Console.ReadKey();
                    }
                    
                }

                // Get the sum of all measurements of each monitor device (I used LINQ expression instead of looping)
                var measurementsCount = monitorsArray.Sum(monitor => monitor.Measurements.Count);

                // Output required in a user-friendly message
                Console.WriteLine("Number of correct messages read from each monitor device are " + measurementsCount);
                Console.ReadKey();
            }
            
            // A user-friendly error if the user didn't co-operate
            else 
            {
                Console.WriteLine("Please type a correct number!");
                Console.ReadKey();
            }
        }
    }
}