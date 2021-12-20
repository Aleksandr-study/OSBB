using System;

class Program
{
    static void Main(string[] args)
    {
        Base all_quality = new Base();
        all_quality.Launch("20 accidents");
        Console.WriteLine(all_quality.archive.quality);
        all_quality.archive = archive.getQua("30 accidents");
        Console.WriteLine(all_quality.archive.quality);

        Console.ReadLine();
    }
}
class Base
{
    public archive archive { get; set; }
    public void Launch(string archiveName)
    {
        archive = archive.getQua(archiveName);
    }
}
class archive
{
    private static archive folder;

    public string quality { get; private set; }

    protected archive(string quality)
    {
        this.quality = quality;
    }

    public static archive getQua(string quality)
    {
        if (folder == null)
            folder = new archive(quality);
        else if (folder != new archive(quality))
        {
            folder = new archive(quality);
        }
        return folder;
    }
}