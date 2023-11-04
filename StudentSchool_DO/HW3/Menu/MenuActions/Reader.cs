using System.ComponentModel.Design;
using System.Text;
using ConsoleOptions;

namespace Menu.MenuActions;

public class Reader : Action
{
    const string FILE_PATH = @"C:\Users\Mel\Downloads\StudentSchool_DO\StudentSchool_DO\HW3\ForRead.txt";
    public static int ID { get; private set; } = (int)MenuEnum.Start.Read;

    public Reader()
    {
        Message = "-- Выполняется чтение из файла --";
        DoneMessage = "\nПрочтеные строки: ";
    }

    public override string PerformAction()
    {
        ConsoleHelper.Output("Введите количество строк: ");
        ConsoleServiceColors.OrdinaryColor();

        if (!int.TryParse(ConsoleHelper.Input(), out int countStr))
        {
            throw new Exception(GeneralMenu.MISTAKE);
        }

        StringBuilder stringBuilder = new();
        var stringOfText = File.ReadAllLines(FILE_PATH);

        stringBuilder.Append(stringOfText[0]);
        for (int indexStr = 1; indexStr < countStr && indexStr < stringOfText.Length; indexStr++)
        {
            stringBuilder.Append('\n');
            stringBuilder.Append(stringOfText[indexStr]);
        }

        if (stringOfText.Length < countStr)
        {
            stringBuilder.Append("\nВсе строки текста выведены");
        }

        return $"{DoneMessage}\n{stringBuilder}";
    }
}
