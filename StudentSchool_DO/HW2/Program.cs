using HW2;

while (!Menu.exit.endWorking)
{
    ConsoleHelper.Output(Menu.StartMenu());
    ConsoleServiceColors.OrdinaryColor();

    int numberAction = 0;

    if (int.TryParse(ConsoleHelper.Input(), out int checkAction))
    {
        numberAction = checkAction;
    }
    else
    {
        if (Menu.StartCheckMistake(numberAction))
        {
            continue;
        }

        break;
    }

    Menu.StartChoice(FromIntToAction(numberAction));
}

HW2.Actions.Action FromIntToAction(int numberOfID)
{
    if (numberOfID == Menu.read.ID)
    {
        return Menu.read;
    }
    else if (numberOfID == Menu.write.ID)
    {
        return Menu.write;
    }
    else if (numberOfID == Menu.fibonacci.ID)
    {
        return Menu.fibonacci;
    }
    else //(numberOfID == Menu.exit.ID)
    {
        return Menu.exit;
    }
}

/*Реализовать команды:

1. Вывод на консоль заданного количества строк текста из файла. Файл сохранён локально. текст - любой, минимум на пару страниц. Количество строк для прочтения задаётся с консоли.
2. Вывод на консоль n-ного числа ряда Фибоначчи. n- порядковый номер числа, задаётся с консоли.
3. Запись кода web-страницы в файл. Файл размещается локально. Адрес страницы (URL) задаётся с консоли.

Реализовать меню:

- Главное меню - появляется в консоли при запуске приложения, включает опции:
    - Чтение
    - Запись
    - Вывод числа Фибоначчи
    - Выход.

    При выборе одного из пунктов происходит переход в меню конкретной задачи. После выполнения конкретной задачи должен быть выбор:

    - Остаться (выполнить задачу снова)
    - Вернуться в главное меню.
*/