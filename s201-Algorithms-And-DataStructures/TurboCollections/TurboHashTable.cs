using System.ComponentModel.Design.Serialization;

namespace TurboCollections;

public class TurboHashTable<T>
{
    private T[] values;
    private int[] next;

    public TurboHashTable()
    {
        values = new T[16];
        next = new int[16];
        Array.Fill(next, -1);
    }

    public bool Exists(T input)
    {
        int hash = GetHash(input);
        if (values[hash].Equals(default(T)) == false)
        {
            if (values[hash]!.Equals(input))
            {
                return true;
            }
        }
        if (next[hash] != -1)
        {
            int thingsWeAreChecking = hash;
            while (next[thingsWeAreChecking] != -1)
            {
                
                if (values[thingsWeAreChecking].Equals(input))
                {
                    return true;
                }
                thingsWeAreChecking = next[thingsWeAreChecking];
            }
            
            //Having another if check here just to make the logic work is stupid and ugly, but Im too tired to think up a 
            //real solution :(
            if (values[thingsWeAreChecking].Equals(input))
            {
                return true;
            }
        }

        return false;
    }

    public bool Delete(T input)
    {
        int hash = GetHash(input);
        if (values[hash].Equals(default(T)) == false)
        {
            if (values[hash]!.Equals(input))
            {
                if (next[hash] != -1)
                {
                    values[hash] = values[next[hash]];
                    next[hash] = next[next[hash]];
                    return true;
                }

                values[hash] = default(T);
                return true;

            }
        }
        //This is fucking awful
        if (next[hash] != -1)
        {
            int thingsWeAreChecking = hash;
            while (next[thingsWeAreChecking] != -1)
            {
                
                if (values[thingsWeAreChecking].Equals(input))
                {
                    if (next[thingsWeAreChecking] != -1)
                    {
                        values[thingsWeAreChecking] = values[next[thingsWeAreChecking]];
                        next[thingsWeAreChecking] = next[next[thingsWeAreChecking]];
                        return true;
                    }

                    values[thingsWeAreChecking] = default(T);
                    return true;
                }
                thingsWeAreChecking = next[thingsWeAreChecking];
            }
            
            //Having another if check here just to make the logic work is stupid and ugly, but Im too tired to think up a 
            //real solution :(
            if (values[thingsWeAreChecking].Equals(input))
            {
                if (next[thingsWeAreChecking] != -1)
                {
                    values[thingsWeAreChecking] = values[next[hash]];
                    next[thingsWeAreChecking] = next[next[hash]];
                    return true;
                }

                values[thingsWeAreChecking] = default(T);
                return true;
            }
        }

        return false;
    }

    private int GetHash(T input)
    {
        return input.GetHashCode() % 16;
    }

    public bool Insert(T input)
    {
        int hash = GetHash(input);
        if (values[hash].Equals(default(T)))
        {
            values[hash] = input;
            next[hash] = -1;
            return true;
        }

        if (values[hash].Equals(input))
        {
            return false;
        }


        int last = hash;
        for (int i = hash + 1; i < hash + 3; i++)
        {
            if (values[i].Equals(input))
            {
                return false;
            }
            if (values[i].Equals(default(T)))
            {
                values[i] = input;
                next[i] = -1;
                next[last] = i;
                return true;
            }

            last = i;
        }
        return false;
    }

    public void printNextArray()
    {
        for (int i = 0; i < next.Length; i++)
        {
            Console.WriteLine("index " + i + " has the value " + next[i]);
        }
    }
    
    public void printValueArray()
    {
        for (int i = 0; i < values.Length; i++)
        {
            Console.WriteLine("index " + i + " has the value " + values[i]);
        }
    }
}