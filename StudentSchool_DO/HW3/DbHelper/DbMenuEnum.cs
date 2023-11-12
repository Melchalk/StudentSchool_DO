namespace DbHelper;

public enum DbEnum
{
    Create = 1,
    Read,
    Update,
    Delete
}

public enum Tables
{
    Readers = 1,
    Books
}

public enum ReaderAttributes
{
    Fullname,
    Telephone,
    RegistrationAddress,
    Age
}

public enum BookAttributes
{
    Title,
    Author,
    NumberPages,
    YearPublishing,
    CityPublishing,
    HallNo
}