using HW1;

Student student = new()
{
    Name = "Вася",
    Age = 20,
    StudentBag = new() { Capacity = 20 }
};

Console.Write("Введите количество пиццы: ");
int countPizza = int.Parse(Console.ReadLine());
if (!student.StudentBag.AddPizza(countPizza, student.StudentBag))
{
    Console.WriteLine("Вместимости сумки не хватает");
    return;
}

Console.Write("Введите количество пива: ");
int countBeer = int.Parse(Console.ReadLine());
if (!student.StudentBag.AddBeer(countBeer, student.StudentBag))
{
    Console.WriteLine("Вместимости сумки не хватает");
    return;
}

Console.WriteLine("\n---Информация о студенте---");
Console.WriteLine($"Имя: {student.Name}");
Console.WriteLine($"Количество пиццы: {student.StudentBag.PizzaPieces}");
Console.WriteLine($"Количество пива: {student.StudentBag.BeerBottles}");
Console.WriteLine($"Сытости: {student.CountSatiety(student)}");
Console.WriteLine($"Опьянение: {student.CountDrunk(student)}");