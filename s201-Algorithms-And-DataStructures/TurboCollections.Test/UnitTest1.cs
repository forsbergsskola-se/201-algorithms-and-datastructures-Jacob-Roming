namespace TurboCollections.Test;



public class MathsTests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void SayHelloExists()
    {
        TurboMaths.SayHello();
        Assert.Pass();
    }

    [Test]
    public void GetOddNumbersListTest()
    {
        List<int> list = new List<int>();
        list.Add(1);
        list.Add(3);
        list.Add(5);
        Assert.That(list, Is.EqualTo(TurboMaths.GetOddNumbersList(6)));
    }
    
    [Test]
    public void GetOddNumbersTest()
    {
        List<int> list = new List<int>();
        list.Add(1);
        list.Add(3);
        list.Add(5);
        List<int> secondList = new List<int>();
        foreach (var number in TurboMaths.GetOddNumbers(6))
        {
            secondList.Add(number);
        }
        Assert.That(list, Is.EqualTo(secondList));

        
    }


    [Test]
    public void TurboLinkStackAddValues()
    {
        TurboLinkedStack<int> stack = new TurboLinkedStack<int>();
        List<int> controlList = new List<int>();
        
        //Is formatting your code like this allowed?
        //I like it :)
        stack.Push(5); controlList.Add(5);
        stack.Push(8); controlList.Add(8);
        stack.Push(10); controlList.Add(10);
        List<int> stackOutput = new List<int>();
        foreach (var number in stack)
        {
            Console.WriteLine(number);
            stackOutput.Add(number);
        }
        stackOutput.Reverse();
        
        Assert.That(controlList, Is.EqualTo(stackOutput));
    }
    
    [Test]
    public void TurboLinkStackPopValues()
    {
        TurboLinkedStack<int> stack = new TurboLinkedStack<int>();
        List<int> controlList = new List<int>();
        stack.Push(2); controlList.Add(2);
        stack.Push(3); controlList.Add(3);
        stack.Push(5000); controlList.Add(5000);
        //push a value and then pop it before adding more stuff on top
        stack.Push(-54);
        stack.Pop();
        
        stack.Push(40); controlList.Add(40);
        stack.Push(29); controlList.Add(29);
        stack.Pop();
        stack.Push(29); //pop value before adding it again
        stack.Push(-1);
        stack.Pop(); //pop last value to see if that messes up the linking
        List<int> stackOutput = new List<int>();
        foreach (var number in stack)
        {
            Console.WriteLine(number);
            stackOutput.Add(number);
        }
        stackOutput.Reverse();
        
        Assert.That(controlList, Is.EqualTo(stackOutput));
    }
    
    [Test]
    public void TurboLinkStackClearValues()
    {
        TurboLinkedStack<int> stack = new TurboLinkedStack<int>();
        List<int> controlList = new List<int>();
        
        stack.Push(999);
        stack.Push(0);
        stack.Push(-1_000_000); //Write a bunch o' crap to the stack
        
        stack.Clear(); //Clear it all away
        
        stack.Push(20); controlList.Add(20); //Add real values
        stack.Push(18); controlList.Add(18);
        stack.Push(100); controlList.Add(100);
        List<int> stackOutput = new List<int>();
        foreach (var number in stack)
        {
            Console.WriteLine(number);
            stackOutput.Add(number);
        }
        stackOutput.Reverse();
        
        Assert.That(controlList, Is.EqualTo(stackOutput));
    }
    
    [Test]
    public void TurboLinkStackPeek()
    {
        TurboLinkedStack<int> stack = new TurboLinkedStack<int>();
        List<int> controlList = new List<int>();
        
        stack.Push(3);
        stack.Push(6);
        stack.Push(12);
        stack.Pop();
        List<int> stackOutput = new List<int>();
        foreach (var number in stack)
        {
            Console.WriteLine(number);
            stackOutput.Add(number);
        }
        stackOutput.Reverse();
        
        Assert.That(stack.Peek(), Is.EqualTo(6));
    }
    
    [Test]
    public void TurboLinkedStackPopReturnTest()
    {
        TurboLinkedStack<int> stack = new TurboLinkedStack<int>();
        List<int> controlList = new List<int>();
        //stack.Push(1);
        stack.Push(10); controlList.Add(10);
        stack.Push(20); controlList.Add(20);
        stack.Push(30); controlList.Add(30);
        
        List<int> outputList = new List<int>();
        outputList.Add(stack.Pop());
        outputList.Add(stack.Pop());
        outputList.Add(stack.Pop());
        outputList.Reverse();
        Assert.That(outputList, Is.EqualTo(controlList));
    }

    [Test]
    public void LinkAddTest()
    {
        TurboStack<int> stack = new TurboStack<int>();
        
        stack.Push(10);
        stack.Push(30);
        stack.Push(1);
        stack.Push(40);
        stack.Push(50);
        
        foreach (var number in stack)
        {
            Console.WriteLine(number);
        }
        Assert.Pass();
    }
    
    [Test]
    public void TurboStackPopValues()
    {
        TurboStack<int> stack = new TurboStack<int>();
        List<int> controlList = new List<int>();
        stack.Push(2); controlList.Add(2);
        stack.Push(3); controlList.Add(3);
        stack.Push(5000); controlList.Add(5000);
        //push a value and then pop it before adding more stuff on top
        stack.Push(-54);
        stack.Pop();
        
        stack.Push(40); controlList.Add(40);
        stack.Push(29); controlList.Add(29);
        stack.Pop();
        stack.Push(29); //pop value before adding it again
        stack.Push(-1);
        stack.Pop(); //pop last value to see if that messes up the linking
        List<int> stackOutput = new List<int>();
        foreach (var number in stack)
        {
            Console.WriteLine(number);
            stackOutput.Add(number);
        }
        stackOutput.Reverse();
        
        Assert.That(controlList, Is.EqualTo(stackOutput));
    }
    
    [Test]
    public void TurbokStackPeek()
    {
        TurboStack<int> stack = new TurboStack<int>();
        List<int> controlList = new List<int>();
        
        stack.Push(3);
        stack.Push(6);
        stack.Push(12);
        stack.Pop();
        List<int> stackOutput = new List<int>();
        foreach (var number in stack)
        {
            stackOutput.Add(number);
        }
        stackOutput.Reverse();
        
        Assert.That(stack.Peek(), Is.EqualTo(6));
    }

    [Test]
    public void TurboStackPopReturnTest()
    {
        TurboStack<int> stack = new TurboStack<int>();
        List<int> controlList = new List<int>();
        //stack.Push(1);
        stack.Push(10); controlList.Add(10);
        stack.Push(20); controlList.Add(20);
        stack.Push(30); controlList.Add(30);
        
        List<int> outputList = new List<int>();
        outputList.Add(stack.Pop());
        outputList.Add(stack.Pop());
        outputList.Add(stack.Pop());
        outputList.Reverse();
        Assert.That(outputList, Is.EqualTo(controlList));
    }
    
    [Test]
    public void TurboStackAddValues()
    {
        TurboStack<int> stack = new TurboStack<int>();
        List<int> controlList = new List<int>();
        
        //Is formatting your code like this allowed?
        //I like it :)
        stack.Push(5); controlList.Add(5);
        stack.Push(8); controlList.Add(8);
        stack.Push(10); controlList.Add(10);
        List<int> stackOutput = new List<int>();
        foreach (var number in stack)
        {
            Console.WriteLine(number);
            stackOutput.Add(number);
        }
        stackOutput.Reverse();
        
        Assert.That(controlList, Is.EqualTo(stackOutput));
    }
}