// See https://aka.ms/new-console-template for more information

using System.Net.Mime;
using TurboCollections;

Console.WriteLine("Hello, World!");
TurboQueue<String> queue = new TurboQueue<string>();

while (true)
{
    Console.WriteLine("What would you like to do? (s)kip or (a)dd?");
    String input = Console.ReadLine();

    switch (input)
    {
        case "a":
            Console.WriteLine("Please input song name: ");
            queue.Enqueue(Console.ReadLine());
            break;
        case "s":
            if(queue.Count > 0)
                queue.Dequeue();
            break;
        default:
            Console.WriteLine("This program is bad and has no input quality of life features, thank you for understanding :)");
            break;
    }

    if (queue.Count != 0)
    {
        Console.WriteLine("Now playing: " + queue.Peek());
    }
    else
    {
        Console.WriteLine("The queue is empty!");
    }
    
}