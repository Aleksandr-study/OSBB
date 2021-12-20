using System;
class Program
{
    static void Main(string[] args)
    {
        AboutAccident AboutAccident = new AboutAccident(new EndOfAccidentState());
        AboutAccident.Actual();
        AboutAccident.Frozen();
        AboutAccident.Frozen();
        AboutAccident.Frozen();
        AboutAccident.Actual();
        AboutAccident.Actual();
        AboutAccident.Actual();
        AboutAccident.Actual();
        Console.Read();
    }
}
class AboutAccident
{
    public IAboutAccidentState State { get; set; }

    public AboutAccident(IAboutAccidentState ws)
    {
        State = ws;
    }

    public void Actual()
    {
        State.Actual(this);
    }
    public void Frozen()
    {
        State.Frozen(this);
    }
}

interface IAboutAccidentState
{
    void Actual(AboutAccident AboutAccident);
    void Frozen(AboutAccident AboutAccident);
}

class archivingAccidentState : IAboutAccidentState
{
    public void Actual(AboutAccident AboutAccident)
    {
        Console.WriteLine("Справу витягнуто з архiву до вiддiлу");
        AboutAccident.State = new EndOfAccidentState();
    }

    public void Frozen(AboutAccident AboutAccident)
    {
        Console.WriteLine("Справа в архiвi");
    }
}
class EndOfAccidentState : IAboutAccidentState
{
    public void Actual(AboutAccident AboutAccident)
    {
        Console.WriteLine("Розгляд справи вiдновлюеться");
        AboutAccident.State = new ActualAboutAccidentState();
    }

    public void Frozen(AboutAccident AboutAccident)
    {
        Console.WriteLine("Справа йде в архiв");
        AboutAccident.State = new archivingAccidentState();
    }
}
class ActualAboutAccidentState : IAboutAccidentState
{
    public void Actual(AboutAccident AboutAccident)
    {
        Console.WriteLine("Справа все ще розглядаеться");
    }

    public void Frozen(AboutAccident AboutAccident)
    {
        Console.WriteLine("Розгляд справи завершено");
        AboutAccident.State = new EndOfAccidentState();
    }
}