using ConsoleOptions;

namespace Menu.MenuActions;

public class Fibonacci : Action
{
    public Fibonacci()
    {
        CommonID++;
        ID = CommonID;
        Message = "-- Выполняется вычисления числа Фибоначчи --";
        DoneMessage = "\nИскомое число Фибоначчи:";
    }

    public override string PerformAction()
    {
        ConsoleHelper.Output("Введите номер числа: ");
        ConsoleServiceColors.OrdinaryColor();

        if (!int.TryParse(ConsoleHelper.Input(), out int countNumber) || countNumber < 1)
        {
            throw new Exception(GeneralMenu.MISTAKE);
        }

        ulong fib1 = 1;
        ulong fib2 = 1;
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