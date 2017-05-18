using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CreditCardValidator;
using GoogleMaps;
using System.Diagnostics;
namespace Tutorial

{   public static class globals
    {
        public static string answer { get; set; }
        public static string answer2 { get; set; }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            // Pi.PiNumber();
            // fib.fibonacci();
            // creditcardValid.MainCard();
            // maps.mainMaps();
            sorting.SortMain();
        }
    }

     class Pi
    {
         public static void PiNumber()
        {
            int num;
            Console.WriteLine("How many decimal places do you want to see pi?");
            num = int.Parse(Console.ReadLine());
            Console.WriteLine(decimal.Round((decimal)Math.PI, num, MidpointRounding.AwayFromZero));
            string s = Console.ReadLine();
        }
    }

    class fib
    {
        public static void fibonacci()
        {
            int num;
            Console.WriteLine("What Number do you want to Calculate Fib number Upto?");
            num = int.Parse(Console.ReadLine());
            int value = fib.fibnum(num);
            Console.WriteLine("The fib number closest to the value you entered is: " + value);
            string s = Console.ReadLine();
        }

        public static int fibnum(int a)
        {
            int i = 0, current = 0, next = 0, first =0, second = 1;
            while(next < a)
            {
                Console.WriteLine(first);
                current = next;
                //if (i == 0) current = 0;
               
                    next = first + second;
                    first = second;
                    second = next;
                
               
                i++;
            }
            return current;
        }
    }

    class creditcardValid
    {
        public static void MainCard()
        {
            Console.WriteLine("Would You like to Validate a Credit Card number (Enter '1'), or Do you want to Generate a Credit Card Number (Enter '2')?");
            var answer = Console.ReadLine();
            while (answer != "1" && answer != "2")
            {
                Console.WriteLine("No Valid answer detected, please try again");
                answer = Console.ReadLine();
            }
            if (answer == "1") CheckCard();
            if (answer == "2") GenCard();

            return;
        }
        public static void CheckCard()
        {
            Console.WriteLine("Please Enter the Credit Card Number: ");
            string CCNum = Console.ReadLine();
            bool result = CCNum.All(char.IsDigit);
            while (CCNum.Length < 14 || result == false)
            {
                Console.WriteLine("Incorrect Credit Card Number provided, please provide a valid number");
                CCNum = Console.ReadLine();
                result = CCNum.All(char.IsDigit);

            }
            CreditCardDetector detector = new CreditCardDetector(CCNum);
            Console.WriteLine("Is the Credit Card valid? " + detector.IsValid());
            Console.ReadLine();
        }

        public static void GenCard()
        {
            Console.WriteLine("Do you want to Generate a Visa Credit Card Number? Y/N");
            var answer = "n";
            string number = "";
            answer = Console.ReadLine();
            if (answer == "y" || answer == "Y")
            {
                number = CreditCardFactory.RandomCardNumber(CardIssuer.Visa);
                Console.WriteLine(number);
                Console.ReadLine();
            }
            else Console.WriteLine("No selected, no Credit Card Number will be generated");
            return;
        }
    }

    class maps
    {
       public static void mainMaps()
        {
            Console.WriteLine("Do you want to find the coordinates for a City (Enter 1) or Find the distance between two Cities (Enter 2) ? ");
            string answer = Console.ReadLine();
            while (answer != "1" && answer != "2")
            {
                Console.WriteLine("Incorrect input, please try again");
                answer = Console.ReadLine();
            }
            if (answer == "1") findOnMap();
            if (answer == "2") FindDist();
        }

        static void findOnMap()
        {
            Console.WriteLine("Please Input the Address to find Coordinates (City, Country): ");
            var address = Console.ReadLine();
            var locationservice = new GoogleMaps.LocationServices.GoogleLocationService();
            var point = locationservice.GetLatLongFromAddress(address);

            var longitude = point.Longitude;
            var latitude = point.Latitude;

            Console.WriteLine("The latitude, Longitude of the given address is : " + latitude + "," + longitude);
            Console.ReadLine();
        }

        static void FindDist()
        {
            Console.WriteLine("Please Enter the 2 Cities you want to calculate the distance between [ City 1, Country; city 2, Country] ?");
            string addresses = Console.ReadLine();
            while(!addresses.Contains(";") && addresses.Count(c => c == ',') < 2 && addresses.Length < 10)
            {
                Console.WriteLine("Incorrect address inputted, Please Try again");
                 addresses = Console.ReadLine();
            }
            string[] address1 = addresses.Split(';');
            Console.WriteLine("The Address are: " + address1[0] + "; " + address1[1]);
            Console.ReadLine();
            var locationservice = new GoogleMaps.LocationServices.GoogleLocationService();
            var point1 = locationservice.GetLatLongFromAddress(address1[0]);
            var point2 = locationservice.GetLatLongFromAddress(address1[1]);
            double dist = CalculateDistance(point1.Latitude, point1.Longitude, point2.Latitude, point2.Longitude);
            Console.Write("The Distance between the 2 cities is: " + Math.Round(dist, 2) + "km");
            Console.ReadLine();
        }

        private static Double rad2deg(Double rad)
        {
            return (rad / Math.PI * 180.0);
        }

        private static Double deg2rad(Double deg)
        {
            return (deg * Math.PI / 180.0);
        }

        private const Double kEarthRadiusKms = 6376.5;

        private static Double CalculateDistance(Double latitude1, Double longitude1, Double latitude2, Double longitude2)
        {
            double theta = longitude1 - longitude2;
            double dist = Math.Sin(deg2rad(latitude1)) * Math.Sin(deg2rad(latitude2)) + Math.Cos(deg2rad(latitude1)) * Math.Cos(deg2rad(latitude2)) * Math.Cos(deg2rad(theta));
            dist = Math.Acos(dist);
            dist = rad2deg(dist);
            dist = dist * 60 * 1.1515;
            dist = dist * 1.609344;
            return (dist);
        }


    }

    class sorting
    {
        public static void SortMain()
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Do you want to sort Bubbles(1) or Merge (2)?");
            
            string answer = Console.ReadLine();
            while (answer != "exit")
            {
                sw.Reset();
                Console.WriteLine("Do You Want to use Predefined values? (y/n)");
                globals.answer2 = Console.ReadLine();
                answer = Console.ReadLine();
                while (answer != "1" && answer != "2")
                {
                    Console.WriteLine("No Valid Input Detected, please press 1 for Bubble, and 2 For Merge");
                    answer = Console.ReadLine();
                }

            if (answer == "1")
            {

                Console.WriteLine("We Will now begin Bubbles!");
                sw.Start();
                BubbleSort();
                sw.Stop();
                }

            else if (answer == "2")
            {
                Console.WriteLine("We Will now begin Merge!");
                sw.Start();
                MergeSort();
                sw.Stop();
            }
            
            Console.WriteLine("For your option, the time takes was: " + sw.Elapsed);
        } }

        static void BubbleSort()
        { int[] ints;
            if (globals.answer2 == "n") { 
            Console.WriteLine("Please input the numbers you want sorted, followed by a comma after eaach value: ");
            string numbers = Console.ReadLine();
            ints = numbers.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
        }
            else
            {
                 ints = new int[] { 3, 2, 1, 4, 5, 6, 8, 4, 9, 6, 5, 4, 7, 8, 9, 6, 5, 4, 7, 8, 5, 6, 9, 8, 5, 1, 2, 2, 3, 22, 11, 55, 66, 48, 52, 33, 221, 551 };
            }
            int temp = 0;

            for(int i =0; i < ints.Length; i++)
            {
                for(int x =0; x < ints.Length - 1; x++)
                {
                    if(ints[x] > ints[x+1])
                    {
                        temp = ints[x + 1];
                        ints[x + 1] = ints[x];
                        ints[x] = temp;
                    }
                }
            }

            ints.ToList().ForEach(i => Console.Write(i.ToString() + ","));
            Console.Write(" ");
            //      Console.ReadLine();
        }

       static void MergeSort()
        {
            int[] ints;
            if (globals.answer2 == "n")
            {
                Console.WriteLine("Please input the numbers you want sorted, followed by a comma after eaach value: ");
                string numbers = Console.ReadLine();
                ints = numbers.Split(',').Select(n => Convert.ToInt32(n)).ToArray();
            }
            else
            {
                ints = new int[] { 3, 2, 1, 4, 5, 6, 8, 4, 9, 6, 5, 4, 7, 8, 9, 6, 5, 4, 7, 8, 5, 6, 9, 8, 5, 1, 2, 2, 3, 22, 11, 55, 66, 48, 52, 33, 221, 551 };
            }

            int[] sorted = split(ints);
            Console.WriteLine("The Sorted Numbers Are:");
            foreach (int value in sorted)
            {
                Console.Write(value + ",");
            }
            Console.Write(" ");
            //     Console.Read();


        }
      static  int[] split(int[] a)
        { if (a.Length == 1) return a;
            int[] l1, l2;
            Split(a, a.Length / 2, out l1, out l2);
            l1 = split(l1);
            l2 = split(l2);
            return join(l1, l2);
        }
      static  int[] join(int[] a1, int[] a2)
        { int counter = 0;
            List<int> c = new List<int>();
            List<int> l1 = a1.ToList();
            List<int> l2 = a2.ToList();
    //        Console.WriteLine("L1");
      //      l1.ForEach(Console.WriteLine);
  //          Console.WriteLine("//");
   //         l2.ForEach(Console.WriteLine);
            while (l1.Count > 0 && l2.Count > 0)
            {
                if(l1[0] <= l2[0])
                {
     //               Console.WriteLine("l1 G " + l1[0]);
                    c.Add(l1[0]);
                    counter++;
                    l1.RemoveAt(0);
                }
                else if (l1[0] > l2[0])
                {
       //             Console.WriteLine("l2 G " + l2[0]);
                    c.Add(l2[0]);
                    counter++;
                    l2.RemoveAt(0);
                }

     //           Console.WriteLine("Current count: " + l1.Count + "," + l2.Count);
                
            }
            counter = 0;
            while(l1.Count > 0)
            {
     //           Console.WriteLine("l1 Alone " + l1[0]);
                c.Add(l1[0]);
                l1.RemoveAt(0);
            }

            while (l2.Count > 0)
            {
      //          Console.WriteLine("l2 Alone " + l2[0]);
                c.Add(l2[0]);
                l2.RemoveAt(0);
            }
        //    Console.WriteLine("current C");
       //     c.ForEach (Console.WriteLine);
            int[] c2 = c.ToArray();
            return c2;
        }
       static public void Split<T>(T[] array, int index, out T[] first, out T[] second)
        {
            first = array.Take(index).ToArray();
            second = array.Skip(index).ToArray();
       //     Console.WriteLine("1, Length = " + first.Length);
            foreach(T val in first)
            {
      //          Console.WriteLine(val);
            }
      //      Console.WriteLine("2, Length = " + second.Length);
     //       foreach (T val in second)
            {
      //          Console.WriteLine(val);
            }
        }
    }


}
