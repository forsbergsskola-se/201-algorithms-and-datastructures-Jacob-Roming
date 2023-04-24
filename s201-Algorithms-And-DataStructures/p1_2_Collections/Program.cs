// See https://aka.ms/new-console-template for more information

using System.Collections;

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
for (int i = 0; i < list.Count; i++)
{
    Console.WriteLine(list[i]);
}
ArrayList secondList = new ArrayList();
secondList.Add(true);
secondList.Add("Forsbergs");
secondList.Add('a');
secondList.Add(1000);
secondList.Add(0.12f);

for (int i = 0; i < secondList.Count; i++)
{
    Console.WriteLine(secondList[i]);
}