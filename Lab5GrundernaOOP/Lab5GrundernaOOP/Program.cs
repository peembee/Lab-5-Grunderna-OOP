using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;

namespace Lab5GrundernaOOP
{
    /* Mohammed Boukhedimi
       Klass: NET22 */
    internal class Program
    {
        static void Main(string[] args)
        {
            runProgram();
            Console.WriteLine("key to exit..");
            Console.ReadKey();
        }

        private static void runProgram()
        {
            Circle calcCircle = new Circle(5);  // creates a object to class: Circle
            Triangle calcTriangle = new Triangle(); // creates a object to class: Triangle

            string userDirection = ""; // variable to know what class the user wants to go into.
            string userCalculate = "";   // variable save what kind of calculations user wants to do.
            double countingNumbers; // Numbers the user want to calculate
            string result;// Display the result of calculations

            while (true) // Loop during the program run.
            {
                while (true) // asking user what shape (with error handling)
                {
                    Console.WriteLine("------------------------------");
                    Console.WriteLine("Exit program, press 0");
                    Console.WriteLine("Vad vill du räkna mått på?");
                    Console.WriteLine();
                    Console.WriteLine("#1 " + calcCircle);
                    Console.WriteLine("#2 " + calcTriangle);
                    Console.WriteLine();
                    Console.Write("Välj: ");
                    try
                    {
                        userDirection = Console.ReadLine();
                        if (userDirection == "1")
                        {
                            userDirection = calcCircle.ToString();
                        }
                        else if (userDirection == "2")
                        {
                            userDirection = calcTriangle.ToString();
                        }
                        else
                        {
                            userDirection = userDirection.ToLower();        // First to make sure all letters are lower,
                            userDirection = char.ToUpper(userDirection[0]) + userDirection.Substring(1);     // then converting first letter uppercase
                        }
                        if (userDirection == calcCircle.ToString() ^ userDirection == calcTriangle.ToString() ^ userDirection == "0")
                        {
                            Console.Clear();
                            break;
                        }
                    }
                    catch
                    {
                        // null
                    }
                    Console.Clear();
                }
                if (userDirection == "0") // if user want to close the program
                {
                    break;
                }

                while (true) // asking user what calculations. (error handling)
                {
                    Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Vald Shape: " + userDirection);
                    Console.WriteLine();
                    Console.WriteLine("Välj uträkning till");
                    Console.WriteLine("#1: Area:");
                    Console.WriteLine("#2: Omkrets:");
                    if (userDirection == calcCircle.ToString()) // if user choose circle, volume-counter will show
                    {
                        Console.WriteLine("#3 Volym (klot/Sfär)");
                    }
                    Console.WriteLine();
                    Console.Write("Val: ");
                    userCalculate = Console.ReadLine();

                    if (userCalculate == "1" || userCalculate == "2" || userCalculate == "3")
                    {
                        if (userCalculate == "1")
                        {
                            userCalculate = "area";
                        }
                        else if (userCalculate == "2")
                        {
                            userCalculate = "omkrets";
                        }
                        else if (userCalculate == "3")
                        {
                            if (userDirection == calcCircle.ToString()) // if user choosed circle, volume will be accepted as "3"
                            {
                                userCalculate = "volym";
                            }
                        }
                    }
                    try
                    {
                        userCalculate = userCalculate.ToLower(); // all letters are now lower to fit 'if - conditions'.
                        if (userCalculate == "area" || userCalculate == "omkrets" || userCalculate == "volym")
                        {
                            break;
                        }
                    }
                    catch
                    {
                        //null
                    }
                }

                result = "Shape: " + userDirection + ". Räknesätt till: " + userCalculate + ". Resultat "; // filling the variable for Display the result.            

                if (userDirection == calcCircle.ToString())  // If user wants to calculate a circle
                {
                    while (true) // error handling
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Vald Shape: " + userDirection);
                        Console.WriteLine("Räknesätt till: " + userCalculate);
                        Console.WriteLine();
                        Console.WriteLine("Area: skriv in radie för att ta reda på arean");
                        Console.WriteLine("Omkrets: skriv in diametern för att ta reda på omkretsen");
                        Console.WriteLine("Volym: skriv in radie för att ta reda på volymen");
                        Console.WriteLine();
                        Console.Write("skriv in tal: ");
                        try
                        {
                            countingNumbers = Convert.ToDouble(Console.ReadLine());
                            if (countingNumbers > 0)
                            {
                                break;
                            }
                        }
                        catch
                        {
                            //null
                        }
                    }
                    Console.Clear();
                    Console.WriteLine();

                    switch (userCalculate)
                    {
                        case "area":
                            Console.WriteLine(result + calcCircle.getArea(((float)countingNumbers))); // Printing the result: area
                            break;
                        case "omkrets":
                            Console.WriteLine(result + calcCircle.getCircumference(((float)countingNumbers))); // Printing the result: circumference
                            break;
                        case "volym":
                            Console.WriteLine(result + calcCircle.getVolume(((float)countingNumbers))); // Printing the result: volume                   
                            break;
                    }
                }

                else // If user wants to calculate a Triangle
                {
                    double baseOfTriangle = 0, heightOfTriangle = 0; // local variables. saves base and height from triangle for area
                    double[] sides = new double[3]; // local array. saves all sides of the triangle for circumference

                    while (true) // error handling
                    {
                        Console.Clear();
                        Console.WriteLine();
                        Console.WriteLine("Vald Shape: " + userDirection);
                        Console.WriteLine("Räknesätt till: " + userCalculate);
                        Console.WriteLine();

                        if (userCalculate == "area") // user choose Area: saving base and height variables due to user want
                        {
                            Console.WriteLine("Area: skriv in basen sedan höjden på triangeln"); 
                            while (true) // error handler
                            {
                                Console.Write("Basen: ");
                                try
                                {
                                    baseOfTriangle = Convert.ToDouble(Console.ReadLine());
                                    if (baseOfTriangle > 0)
                                    {
                                        break;
                                    }
                                }
                                catch
                                {
                                    //null
                                }
                            }
                            while (true)
                            {
                                Console.Write("Höjden: ");
                                try
                                {
                                    heightOfTriangle = Convert.ToDouble(Console.ReadLine());
                                    if (heightOfTriangle > 0)
                                    {
                                        break;
                                    }
                                }
                                catch
                                {
                                    // null
                                }
                            }
                            break;
                        }
                        else // user choose Circumference: saving users data into array 
                        {
                            int sideNumbers = 1; // local variable just to show side-numbers during the for-loop
                            Console.WriteLine("Omkrets: skriv in sidornas längd på triangeln");
                            for (int i = 0; i < sides.Length; i++)
                            {
                                while (true) // error handler
                                {
                                    Console.Write("Skriv in sida " + sideNumbers + ": ");
                                    try
                                    {
                                        sides[i] = Convert.ToDouble(Console.ReadLine());
                                        if (sides[i] > 0)
                                        {
                                            sideNumbers++;
                                            break;
                                        }                                           
                                    }
                                    catch
                                    {
                                        //null
                                    }
                                }
                            }
                            break;
                        }
                    }

                    Console.Clear();
                    Console.WriteLine();
                    switch (userCalculate)
                    {
                        case "area":
                            Console.WriteLine(result + calcTriangle.getArea((float)baseOfTriangle, (float)heightOfTriangle)); // Printing the result: area
                            break;
                        case "omkrets":
                            Console.WriteLine(result + calcTriangle.getCircumference((float)sides[0], (float)sides[1], (float)sides[2])); // Printing the result: circumference
                            break;
                    }
                }
                Console.WriteLine("Tangent för meny");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
