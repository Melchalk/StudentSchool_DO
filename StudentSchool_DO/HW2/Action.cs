using System.Text;
namespace HW2;

internal class Action
{
    public string Message { get; set; }
    public string DoneMessage { get; set; }

    public Action()
    {
        DoneMessage = "\nДействие выполнено";
    }

    public virtual string PerformAction()
    {
        return DoneMessage;
    }
}

internal class Read : Action
{
    readonly string filePath = @"C:\Users\Mel\Downloads\StudentSchool_DO\StudentSchool_DO\HW2\ForRead.txt";

    public Read()
    {
        Message = "-- Выполняется чтение из файла --";
        DoneMessage = "\nПрочтеные строки: ";
    }

    public override string PerformAction()
    {
        Console.Write("Введите количество строк: ");
        ConsoleServiceColors.OrdinaryColor();

        if (!int.TryParse(Console.ReadLine(), out int countStr))
        {
            Menu.MistakeAndTransition(Menu.tryAgain);
            return string.Empty;
        }

        StringBuilder stringBuilder = new();
        var stringOfText = File.ReadAllText(filePath).Replace(". ", ".\n").Split('\n');

        stringBuilder.Append(stringOfText[0]);
        for (int indexStr = 1; indexStr < countStr && indexStr < stringOfText.Length; indexStr++)
        {
            stringBuilder.Append('\n');
            stringBuilder.Append(stringOfText[indexStr]);
        }

        if (stringOfText.Length <  countStr)
        {
            stringBuilder.Append("\nВсе строки текста выведены");
        }


        return $"{DoneMessage}\n{stringBuilder}";
    }
}

internal class Write : Action
{
    readonly string filePath = Directory.GetCurrentDirectory() + "/URL.txt";

    public Write()
    {
        Message = "-- Выполняется запись URL --";
        DoneMessage = "\nЗапись выполнена";
    }

    public override string PerformAction()
    {
        Console.Write("Введите URL: ");
        ConsoleServiceColors.OrdinaryColor();

        File.WriteAllText(filePath, Console.ReadLine());

        return DoneMessage;
    }
}

internal class Fibonacci : Action
{
    public Fibonacci()
    {
        Message = "-- Выполняется вычисления числа Фибоначчи --";
        DoneMessage = "\nИскомое число Фибоначчи:";
    }

    public override string PerformAction()
    {
        Console.Write("Введите номер числа: ");
        ConsoleServiceColors.OrdinaryColor();

        if (!int.TryParse(Console.ReadLine(), out int countNumber) || countNumber < 1)
        {
            Menu.MistakeAndTransition(Menu.tryAgain);
            return string.Empty;
        }

        ulong fib1 = 1, fib2 = 1;
        countNumber -= 2;

        while (countNumber > 0)
        {
            ulong fib_sum = fib1 + fib2;
            fib1 = fib2;
            fib2 = fib_sum;
            countNumber -= 1;
        }

        return $"{DoneMessage} {fib2}";
    }
}

internal class Exit : Action
{
    public bool flagOfEnd = false;

    public Exit()
    {
        Message = "-- Выполняется выход из программы --";
    }

    public override string PerformAction()
    {
        ConsoleServiceColors.HintsColor();
        flagOfEnd = true;
        return DoneMessage;
    }
}