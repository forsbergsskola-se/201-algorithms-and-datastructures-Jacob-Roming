using TurboCollections;

namespace HashTests;

public class TurboHashTableTests
{
    [Test]
    public void AddingValuesTest()
    {
        TurboHashTable<int> table = new TurboHashTable<int>();
        
        Assert.That(table.Insert(10), Is.EqualTo(true));
        Assert.That(table.Insert(10), Is.EqualTo(false));
        Assert.That(table.Insert(170), Is.EqualTo(true));
    }
    
    [Test]
    public void AddingAndCheckingValuesTest()
    {
        TurboHashTable<int> table = new TurboHashTable<int>();
        
        Assert.That(table.Insert(10), Is.EqualTo(true));
        Assert.That(table.Insert(170), Is.EqualTo(true));
        Assert.That(table.Exists(10), Is.EqualTo(true));
        Assert.That(table.Exists(170), Is.EqualTo(true));
        Assert.That(table.Exists(5000), Is.EqualTo(false));
    }

    [Test]
    public void AddingAndRemovingValuesTest()
    {   
        TurboHashTable<int> table = new TurboHashTable<int>();
        Assert.That(table.Insert(10), Is.EqualTo(true));
        Assert.That(table.Insert(170), Is.EqualTo(true));
        Assert.That(table.Exists(170), Is.EqualTo(true));
        Assert.That(table.Delete(170), Is.EqualTo(true));
        Assert.That(table.Exists(170), Is.EqualTo(false));
        Assert.That(table.Exists(10), Is.EqualTo(true));
        Assert.That(table.Delete(10), Is.EqualTo(true));
        Assert.That(table.Exists(10), Is.EqualTo(false));
        table.printNextArray();
        table.printValueArray();
    }
}