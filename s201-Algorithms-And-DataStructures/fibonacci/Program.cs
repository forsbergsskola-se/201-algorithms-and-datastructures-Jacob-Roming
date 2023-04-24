// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using fibonacci;

Console.WriteLine("Hello, World!");
Console.WriteLine("Input some number: ");
int input = Int32.Parse(Console.ReadLine());
Stopwatch timer = new Stopwatch();
timer.Start();
Console.WriteLine("Here is your number fibonaccid recursively: " + fibonacciRecursive.Fib(input));
timer.Stop();
Console.WriteLine("That took " + timer.ElapsedMilliseconds + " milliseconds");

timer.Reset();
timer.Start();
Console.WriteLine("Here is your number fibonaccid iteratively: " + fibonacciRecursive.FibIterative(input));
timer.Stop();
Console.WriteLine("That took " + timer.ElapsedMilliseconds + " milliseconds");
