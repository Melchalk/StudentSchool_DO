namespace HW2.Actions;

internal class Exit : Action
{
    public bool endWorking = false;

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
}