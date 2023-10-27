namespace HW2.Actions;

internal class Exit : Action
{
    public bool flagOfEnd = false;

    public Exit()
    {
        CommonID++;
        ID = CommonID;
        ActionEnum = MenuEnum.Start.Exit;
        Message = "-- Выполняется выход из программы --";
    }

    public override string PerformAction()
    {
        ConsoleServiceColors.HintsColor();
        flagOfEnd = true;

        return DoneMessage;
    }
}