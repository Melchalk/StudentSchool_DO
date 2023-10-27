namespace HW2.Actions;

//Не правильно поняла задание, переделать

internal class Writer : Action
{
    readonly string filePath = Directory.GetCurrentDirectory() + "/URL.txt";

    public Writer()
    {
        CommonID++;
        ID = CommonID;
        ActionEnum = MenuEnum.Start.Write;
        Message = "-- Выполняется запись URL --";
        DoneMessage = "\nЗапись выполнена";
    }

    public override string PerformAction()
    {
        ConsoleHelper.Output("Введите URL: ");
        ConsoleServiceColors.OrdinaryColor();

        File.WriteAllText(filePath, ConsoleHelper.Input());

        return DoneMessage;
    }
}