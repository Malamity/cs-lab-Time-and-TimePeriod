using System;
using System.Collections.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Time_TimePeriod;


namespace Aplikacja
{
    class Program
    {
        static Time timePoint;

        static void Main(string[] args)
        {
            WriteYourNumber();
        }

        public static void WriteYourNumber()
        {
            bool canMakeOp = false;
            while(canMakeOp != true) 
            {
                Console.WriteLine("Podaj godzinę w formacie h:m:s");

                try
                {
                    timePoint = new Time(Console.ReadLine());
                    canMakeOp = true;
                }
                catch (FormatException ) { Console.WriteLine("Wprowadzono złe dane"); }
                catch (OverflowException ) { Console.WriteLine("Wprowadzono zbyt dużą lub ujemną liczbę"); }
                catch (IndexOutOfRangeException ) { Console.WriteLine("Wprowadzono niedokładne dane"); }
                catch (Exception) { Console.WriteLine("Wprowadzono błędne dane"); }

                Console.WriteLine($"Wybrałeś punkt na osi czasu= {timePoint.ToString()}");
                AddOrSubtract(timePoint);
            }
        }

        public static void AddOrSubtract(Time point)
        {
            Console.WriteLine();
            Console.WriteLine("Wpisz + jeżeli chcesz dodać lub - jeżeli chcesz odjąć lub * jeżeli chcesz pomnożyć");
            string mark;

            try
            {
                mark = Console.ReadLine();
            }
            catch (Exception) { throw new ArgumentException(nameof(mark), "błąd przy wprowadzaniu znaku"); }

            if(mark == "+")
            {
                AddTimePeriod(timePoint);
            }
            else if(mark == "-")
            {
                SubstractTimePeriod(timePoint);
            }
            else if (mark == "*")
            {
                Multiply(timePoint);
            }
            else
            {
                Console.WriteLine("Wprowadzono błedne dane");
                AddOrSubtract(timePoint);
            }
        }

        public static void Multiply(Time newtimepoint)
        {
            bool canMakeOp = false;
            int number = 1;
            Console.WriteLine("wpisz liczbe ile razy chcesz pomnożyć swoją godzinę");
            while (canMakeOp == false)
            {
                try
                {
                    number = int.Parse(Console.ReadLine());
                    canMakeOp = true;
                }
                catch (FormatException)
                {

                    Console.WriteLine("Błędne dane, należy wprwadzić cyfrę a nie inne znaki");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Wprowadzono zbyt dużą liczbę, proszę wprowadzić mniejszą liczbę");
                }
                catch (Exception)
                {

                    Console.WriteLine("Wprowadzono błedne dane, spróbuj jeszcze raz wpisując cyfre");
                    throw new ArgumentException(nameof(number), "wprowadzono błędne dane");
                }

            }
            Time newTimePoint = newtimepoint.Multiplication(number);
            Console.WriteLine("Twój nowy punkt na osi czasu = " + newTimePoint.ToString());
            AddOrSubtract(newTimePoint);
        }

        public static void SubstractTimePeriod(Time newtimepoint)
        {
            bool canMakeOp = false;
            TimePeriod timeperiod = new TimePeriod();
            while (canMakeOp != true)
            {

                Console.WriteLine("Podaj ile czasu chcesz odjąć w formacie h:m:s");
                try
                {
                    timeperiod = new TimePeriod(Console.ReadLine());
                    canMakeOp = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wprowadzono złe dane, spróbuj podobnie wpisując tylko liczby");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Wprowadzono zbyt dużą liczbę, spróbuj ponownie wpisując poprawne wielkości");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Wprowadzono niedokładne dane, muszą być wszystkie liczby i każda z nich musi być rozdzielone dwukropkiem");
                }
                catch (Exception)
                {

                    Console.WriteLine("Wprowadzono błedne dane, spróbuj jeszcze raz wpisując liczby oddzielone dwukropkiem");
                    throw new ArgumentException(nameof(timeperiod), "wprowadzono błędne dane");
                }
            }
            Time newTimePoint = newtimepoint.Minus(timeperiod);
            Console.WriteLine("Twój nowy punkt na osi czasu = " + newTimePoint.ToString());
            AddOrSubtract(newTimePoint);
        }
        public static void AddTimePeriod(Time newtimepoint)
        {
            TimePeriod timePeriod = new TimePeriod();
            bool canMakeOperation = false;
            while (canMakeOperation != true)
            {
                Console.WriteLine("Podaj ile czasu chcesz dodać w formacie h:m:s");

                try
                {
                    timePeriod = new TimePeriod(Console.ReadLine());
                    canMakeOperation = true;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Wprowadzono złe dane, spróbuj podobnie wpisując tylko liczby");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Wprowadzono zbyt dużą liczbę, spróbuj ponownie wpisując poprawne wielkości");
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Wprowadzono niedokładne dane, muszą być wszystkie liczby i każda z nich musi być rozdzielone dwukropkiem");
                }
                catch (Exception)
                {

                    Console.WriteLine("Wprowadzono błedne dane, spróbuj jeszcze raz wpisując liczby oddzielone dwukropkiem");
                    throw new ArgumentException(nameof(timePeriod), "wprowadzono błędne dane");
                }
            }

            Time newTimePoint = newtimepoint.Plus(timePeriod);
            Console.WriteLine("Twój nowy punkt na osi czasu = " + newTimePoint.ToString());
            AddOrSubtract(newTimePoint);
        }
    }
}