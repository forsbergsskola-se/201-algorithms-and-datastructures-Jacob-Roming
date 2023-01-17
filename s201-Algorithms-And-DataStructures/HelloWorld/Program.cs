// See https://aka.ms/new-console-template for more information

using System.Collections;
using TurboCollections;

TurboMaths.SayHello();


List<object> list = new List<object>();
list.Add(5);
list.Add("Marc");
list.Add(true);
list.Add('a');

IEnumerator enumerator = list.GetEnumerator();
// use a loop to iterate using the enumerator
// and print each item to the console like this:
while (enumerator.MoveNext())
{
    Console.WriteLine($"Current Value: {enumerator.Current}");
}
//Console.WriteLine($"Current Value: {howEverYouGetTheCurrentValue}");