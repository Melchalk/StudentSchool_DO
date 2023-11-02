using System.Net;

namespace HW2.Actions;

internal class Writer : Action
{
    readonly string _filePath = Directory.GetCurrentDirectory() + "/URL.txt";

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