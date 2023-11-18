var str1 = new[] { 1, 2 };
Console.WriteLine(str1[0]);
Change(str1);
Console.WriteLine(str1[0]);

RemakeArray(new int[,]
{
    {1, 2, 3},
    {0, 5, 0 }
});

void Change(int[] str)
{
    str = new[] { 3, 4 };
}

/*
void RemakeArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] != 0)
        {
            array[i] = 1;
        }
    }
}
*/
void RemakeArray(int[,] array)
{
    for (int i = 0; i < array.Rank; i++)
    {
        for (int j = 0; j <= array.GetUpperBound(0) + 1; j++)
        {
            if (array[i,j] != 0)
            {
                array[i,j] = 1;
            }
        }
    }
}

#pragma warning disable CS8321 // Локальная функция объявлена, но не используется
string FooBar(int num)
{
    if (num % 5 == 0 && num % 3 == 0)
    {
        return "foobar";
    }
    else if (num % 3 == 0)
    {
        return "foo";
    }
    else if (num % 5 == 0)
    {
        return "bar";
    }

    return "";
}
#pragma warning restore CS8321 // Локальная функция объявлена, но не используется