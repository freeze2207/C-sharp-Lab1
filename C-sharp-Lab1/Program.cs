using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace C_sharp_Lab1
{
    class Program
    {
        // TODO dont let them go to next step until value is valid
        static dynamic getValues(String sideString, object value)
        {
            double dValue = 0.0;
            string sValue = "";
            Console.Write("What is your {0} value: ", sideString);
            value = Console.ReadLine();
            sValue = value.ToString();
            if (sValue == "q")
            {
                System.Environment.Exit(0);
            }
            try
            {
                dValue = System.Convert.ToDouble(value);
            }
            catch (Exception exception)
            {
                if (exception is FormatException && sValue.Length == 1)
                {
                    return sValue;
                }
            }
            return dValue;

        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to Simple Calculator, press Q to Exit");

                double leftHandValue = 0.0f;
                double rightHandValue = 0.0f;
                string operation = "";

                leftHandValue = getValues("Left hand", leftHandValue);

                try
                {
                    operation = getValues("Operation [+ - * /]", operation);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                

                rightHandValue = getValues("Right hand", rightHandValue);

                switch (operation)
                {
                    case "+":
                        Console.WriteLine("The result is {0} {1} {2} = {3}", leftHandValue, operation, rightHandValue, leftHandValue + rightHandValue);
                        break;
                    case "-":
                        Console.WriteLine("The result is {0} {1} {2} = {3}", leftHandValue, operation, rightHandValue, leftHandValue - rightHandValue);
                        break;
                    case "*":
                        Console.WriteLine("The result is {0} {1} {2} = {3}", leftHandValue, operation, rightHandValue, leftHandValue * rightHandValue);
                        break;
                    case "/":
                        try
                        {
                            Console.WriteLine("The result is {0} {1} {2} = {3}", leftHandValue, operation, rightHandValue, leftHandValue / rightHandValue);
                        }
                        catch (ArithmeticException mathExc)
                        {
                            throw mathExc;
                        }
                        break;
                    default:
                        Console.WriteLine("Not a valid operation");
                        break;

                }

            }
        }
    }
}
