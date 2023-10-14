var str1 = new[] { 1, 2 };
Console.WriteLine(str1[0]);
Change(str1);
Console.WriteLine(str1[0]);

void Change(int[] str)
{
    str = new[] { 3, 4 };
}

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