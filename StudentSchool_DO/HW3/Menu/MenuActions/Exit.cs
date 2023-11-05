using ConsoleOptions;

namespace Menu.MenuActions;

public class Exit : Action
{
    public static bool EndWorking { get; private set; } = false;
    public static int ID { get; private set; } = (int)MenuEnum.Start.Exit;

    public Exit()
    {
        Message = "-- Выполняется выход из программы --\n";
    }

    public override string PerformAction()
    {
        ConsoleServiceColors.HintsColor();
        EndWorking = true;

        return DoneMessage;
    }
}