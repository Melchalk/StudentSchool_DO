using ConsoleOptions;

namespace Menu;

internal class DatabaseMenu
{
    internal static string DbMenu()
    {
        ConsoleServiceColors.ColorForMenu();

        string DbMenuText = "\nВыберите действие:\n" +
            $"Создать ({MenuEnum.CRUD.Create})\n" +
            $"Прочитать ({MenuEnum.CRUD.Read})\n" +
            $"Обновить ({MenuEnum.CRUD.Update})\n" +
            $"Удалить ({MenuEnum.CRUD.Delete})\n" +
            "Номер - ";

        return DbMenuText;
    }
}
