using ConsoleOptions;

namespace Menu.MenuActions;

public class Exit : Action
{
    bool endWorking = false;
    public static int ID { get; private set; }

    public Exit()
    {
        CommonID++;
        ID = CommonID;
        Message = "-- Выполняется выход из программы --";
    }

    public override string PerformAction()
    {
        ConsoleServiceColors.HintsColor();
        endWorking = true;

        return DoneMessage;
    }

    public bool EndWorking()
    {
        return endWorking;
    }
}