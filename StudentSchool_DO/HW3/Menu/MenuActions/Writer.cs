using ConsoleOptions;
using System.Net;

namespace Menu.MenuActions;

public class Writer : Action
{
    readonly string _filePath = Directory.GetCurrentDirectory() + "/URL.txt";
    public static int ID { get; private set; }

    public Writer()
    {
        CommonID++;
        ID = CommonID;
        Message = "-- Выполняется запись URL --";
        DoneMessage = "\nЗапись выполнена";
    }

    public override string PerformAction()
    {
        ConsoleHelper.Output("Введите URL: ");
        ConsoleServiceColors.OrdinaryColor();

        string url = ConsoleHelper.Input();
        string codeOfPage;

        using (WebClient client = new())
        {
            codeOfPage = client.DownloadString(url);
        }

        File.WriteAllText(_filePath, codeOfPage);

        return DoneMessage;
    }
}