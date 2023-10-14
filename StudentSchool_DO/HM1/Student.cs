namespace HW1;

internal class Student
{
    const double NormalSatiety = 30;
    const double NormalDrunk = 72;

    public string Name { get; set; }
    public int Age { get; set; }
    public Bag StudentBag { get; set; }

    public string CountSatiety(Student student)
    {
        if (student.Age <= 0 || student.StudentBag.PizzaPieces <= 0)
            return "Ошибка";

        //уславливаемся, что с возрастом нужно меньше пиццы для насыщения
        double levelSatiety = (student.StudentBag.PizzaPieces / student.Age) * 100;
        if (levelSatiety < NormalSatiety)
        {
            return "Голоден";
        }
        else if (levelSatiety > NormalSatiety)
        {
            return "Переел";
        }
        else
        {
            return "В самый раз";
        }
    }

    public string CountDrunk(Student student)
    {
        if (student.Age <= 0 || student.StudentBag.PizzaPieces <= 0)
            return "Ошибка";

        //уславливаемся, что с возрастом нужно больше пива для опьянения
        double levelDrunk = student.StudentBag.PizzaPieces * student.Age;
        if (levelDrunk < NormalDrunk)
        {
            return "Трезв";
        }
        else if (levelDrunk > NormalDrunk)
        {
            return "Перепил";
        }
        else
        {
            return "В самый раз";
        }
    }
}