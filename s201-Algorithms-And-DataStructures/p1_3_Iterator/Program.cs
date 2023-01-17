// See https://aka.ms/new-console-template for more information

using System.Collections;
using TurboCollections;

List<int> list = new List<int>();
list.Add(1);
list.Add(1);
list.Add(2);
list.Add(3);
list.Add(5);

IEnumerator enumerator = list.GetEnumerator();
int total = 0;
TurboMaths.GetOddNumbersList(total);
// use a loop to iterate using the enumerator
// and print each item to the console like this:
while (enumerator.MoveNext())
{
    Console.WriteLine($"Current Value: {enumerator.Current}");
    total += (int)enumerator.Current;
}
Console.WriteLine("The total is: " + total);
List<int> oddNumbers = TurboMaths.GetOddNumbersList(2_100_000_000);
for (int i = 0; i < oddNumbers.Count; i++)
{
    Console.WriteLine(oddNumbers[i]);
}

//Console.WriteLine(TurboMaths.GetOddNumbers(total));

foreach(var number in TurboMaths.GetOddNumbers(2_000_000_000)) {
    System.Console.WriteLine(number);
}