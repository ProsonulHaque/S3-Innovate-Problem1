using System;

namespace Problem1
{
    class Program
    {
        static void billCounter(DateTime start, DateTime end)
        {
            DateTime peakStart = new DateTime(start.Year, start.Month, start.Day, 9, 0, 0);
            DateTime peakEnd = new DateTime(start.Year, start.Month, start.Day, 22, 59, 59);

            double bill = 0; //Count in paisa

            while(start < end)
            {
                if(start.AddSeconds(20) >= peakStart && start.AddSeconds(20) <= peakEnd)
                {
                    bill += 30;
                    Console.WriteLine($"{start} + 20 second ({start.AddSeconds(20)}) = {30} paisa");
                }
                else
                {
                    bill += 20;
                    Console.WriteLine($"{start} + 20 second ({start.AddSeconds(20)}) = {20} paisa");
                }

                start = start.AddSeconds(20);

                if(start.Date > peakStart.Date){
                    peakStart = peakStart.AddDays(1);
                    peakEnd = peakEnd.AddDays(1);
                }
            }

            bill /= 100; //Convert to Tk

            Console.WriteLine($"\nBill: {bill}Tk");
        }
        
        static void Main(string[] args)
        {
            DateTime startTime = new DateTime(), endTime = new DateTime();

            try
            {
                Console.WriteLine("Start time: ");
                DateTime.TryParse(Console.ReadLine(), out startTime);
                
                Console.WriteLine("End time: ");
                DateTime.TryParse(Console.ReadLine(), out endTime);
                
                Console.WriteLine("**********************Bill History**********************");
                
                billCounter(startTime, endTime);
            }
            catch (System.Exception)
            {
                Console.WriteLine("You have entered an incorrect value.");
            }
        }
    }
}
