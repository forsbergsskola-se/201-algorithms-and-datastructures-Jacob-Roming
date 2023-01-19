// See https://aka.ms/new-console-template for more information

using TurboCollections;

Console.WriteLine("Hello, World!");

TurboList<string> customers = new TurboList<string>();

while (true)
{
    Console.WriteLine("Choose and option: \n (1) Add a Customer\n(2) Remove a Customer by name\n(3) Remove a Customer by index\n(4) Display all Customers");
    string input = Console.ReadLine();
    switch (input)
    {
        case "1":
            Console.WriteLine("Input name");
            customers.Add(Console.ReadLine());
            break;
        case "2":
            Console.WriteLine("Input the name of the customer that you want to remove");
            try
            {
                customers.Remove(Console.ReadLine());
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            break;
        case "3":
            Console.WriteLine("Input the index of the customer that you want to remove");
            try
            {
                customers.RemoveAt(Int32.Parse(Console.ReadLine()));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            break;
        case "4":
            foreach (var variable in customers)
        {
            Console.WriteLine(variable);
        }

            break;
    }
}