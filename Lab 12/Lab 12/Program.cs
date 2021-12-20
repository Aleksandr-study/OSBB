using System;

class Program
{
    static void Main(string[] args)
    {
        database data = new database();
        User Sasha = new User();
        Sasha.PrintData(data);
        Console.Read();
    }
}

class User
{
    public void PrintData(database database)
    {
        DataIterator iterator = database.CreateNumerator();
        while (iterator.ToNextTerr())
        {
            Terr Terr = iterator.Next();
            Console.WriteLine(Terr.Name);
        }
    }
}

interface DataIterator
{
    bool ToNextTerr();
    Terr Next();
}
interface TerrClassification
{
    DataIterator CreateNumerator();
    int Count { get; }
    Terr this[int index] { get; }
}
class Terr
{
    public string Name { get; set; }
}

class database : TerrClassification
{
    private Terr[] Terrs;
    public database()
    {
        Terrs = new Terr[]
        {
            new Terr {Name="*Данi: сновнi областi*"},
            new Terr {Name="*Статистика з зони вiйни*"},
            new Terr {Name="*Статистика по окупованим територiям*"}
        };
    }
    public int Count
    {
        get { return Terrs.Length; }
    }

    public Terr this[int index]
    {
        get { return Terrs[index]; }
    }
    public DataIterator CreateNumerator()
    {
        return new databaseNumerator(this);
    }
}
class databaseNumerator : DataIterator
{
    TerrClassification total_quantity;
    int index = 0;
    public databaseNumerator(TerrClassification a)
    {
        total_quantity = a;
    }
    public bool ToNextTerr()
    {
        return index < total_quantity.Count;
    }

    public Terr Next()
    {
        return total_quantity[index++];
    }
}