using System.Numerics;
using System.Text.RegularExpressions;

class Calculator
{
    public static void Main(string[] args)
    {
        void printer(string msg)
        {
            Console.WriteLine(msg);
        }

        double sum(double x, double y)
        {
            return x + y;
        }
        double times(double x, double y)
        {
            return x * y;
        }
        double minus(double x, double y)
        {
            return x - y;
        }
        double split(double x, double y)
        {
            return x / y;
        }
        string fatorial(int x)
        {
            BigInteger total = x;

            void recursiveFatorial(int y)
            {
                if (y > 1)
                {
                    total = total * --y;
                    recursiveFatorial(y);
                }
                
            }
            recursiveFatorial(x);
            return "" + total;

        }

        void isNumberPrime(int x)
        {

            bool isPrime = true;

            if (x < 2)
            {
                isPrime = false;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(x); i++)
                {
                    if (x % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }
            }

            if (isPrime)
            {
                Console.WriteLine($"{x} is a prime number.");
            }
            else
            {
                Console.WriteLine($"{x} is not a prime number.");
            }
        }

        string inputer()
        {
            return Console.ReadLine();
        }

        printer("\nThe supla blaster calculator");
        printer("Input a number or write 'EXIT' to end the calculator");

        bool calculatorUse = true;

        double total = 0.0;
        while (calculatorUse)
        {
            printer(
                "\n ======================================================================= \n"
            );
            printer("TOTAL:" + total);

            string inputedText = inputer();

            if (inputedText == "EXIT" || inputedText == "exit")
            {
                calculatorUse = false;
            }

            bool validatedInput = validateNumber(inputedText);

            while (!validatedInput)
            {
                printer("the inputed value is not a number, try again");
                inputedText = inputer();
                validatedInput = validateNumber(inputedText);
            }
            total = double.Parse(inputedText);
            printer("now write a operation");

            string inputedOperation = inputer();
            bool validatedOperation = validateOperation(inputedOperation);

            if (inputedOperation != "!" && inputedOperation != "p")
            {

                while (!validatedOperation)
                {
                    printer("invalid operation, try again");
                    inputedOperation = inputer();
                    validatedOperation = validateOperation(inputedOperation);
                }

                inputedText = inputer();

                validatedInput = validateNumber(inputedText);

                while (!validatedInput)
                {
                    printer("the inputed value is not a number, try again");
                    inputedText = inputer();
                    validatedInput = validateNumber((inputedText));
                }
            }

            switch (inputedOperation)
            {
                case "+":
                    total = sum(total, double.Parse(inputedText));
                    break;
                case "-":
                    total = minus(total, double.Parse(inputedText));
                    break;
                case "*":
                    total = times(total, double.Parse(inputedText));
                    break;
                case "/":
                    total = split(total, double.Parse(inputedText));
                    break;
                case "!":
                    total = double.Parse(fatorial(int.Parse(inputedText)));
                    break;
                case "p":
                    isNumberPrime(int.Parse(inputedText));
                    break;

            }
        }
        bool validateNumber(string inputedText)
        {
            double number;
            bool isNumber = double.TryParse(inputedText, out number);
            return isNumber;
        }
        bool validateOperation(string inputedOperation)
        {
            if (
                inputedOperation == "+"
                || inputedOperation == "-"
                || inputedOperation == "/"
                || inputedOperation == "*"
                || inputedOperation == "!"
                || inputedOperation == "p"
            )
            {
                return true;

            }
            return false;
        }
    }
}
