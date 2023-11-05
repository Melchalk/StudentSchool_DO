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
    Registration_address,
    Age
}

public enum BookAttributes
{
    Title,
    Author,
    Number_pages,
    Year_publishing,
    City_publishing,
    Hall_no
}