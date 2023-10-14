Console.WriteLine(FooBar(15));
Console.WriteLine(FooBar(5));
Console.WriteLine(FooBar(3));
Console.WriteLine(FooBar(17));

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