using System;
class Program
{
    static void Main(string[] args)
    {
        // юзер
        User Sasha = new User();
        // області
        mainRegions regions = new mainRegions();
        // працюємо з ними
        Sasha.working(regions);
        // треба працювати з зоною Ато
        ATO to_ATO = new ATO();
        // переключаемося
        myWork changing_ = new MainToATO(to_ATO);
        // продовжуємо роботу - з поправкою на АТО
        Sasha.working(changing_);

        Console.Read();
    }
}
interface myWork
{
    void cheking();
}
// класс роботи з областями
class mainRegions : myWork
{
    public void cheking()
    {
        Console.WriteLine("Змiна даних по основним областям");
    }
}
class User
{
    public void working(myWork changing)
    {
        changing.cheking();
    }
}
// інтерфейс роботи з АТО
interface war_casualties
{
    void war_checking();
}
// класс для АТО-поправок
class ATO : war_casualties
{
    public void war_checking()
    {
        Console.WriteLine("Змiна даних з поправкою на бойовi iнциденти");
    }
}
// Адаптер 
class MainToATO : myWork
{
    ATO war_correction;
    public MainToATO(ATO c)
    {
        war_correction = c;
    }

    public void cheking()
    {
        war_correction.war_checking();
    }
}