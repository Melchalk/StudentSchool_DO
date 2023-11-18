﻿using DbModels;
using WebLibrary.ModelRequest;

namespace WebLibrary.Mappers;

public class ReaderMapper : IReaderMapper
{
    public DbReader Map(ReaderRequest readerRequest)
    {
        DbReader reader = new()
        {
            Fullname = readerRequest.Fullname,
            Telephone = readerRequest.Telephone,
            RegistrationAddress = readerRequest.RegistrationAddress,
            Age = readerRequest.Age,
            CanTakeBooks = readerRequest.CanTakeBooks
        };

        return reader;
    }

    public ReaderRequest Map(DbReader reader)
    {
        ReaderRequest readerRequest = new()
        {
            Fullname = reader.Fullname,
            Telephone = reader.Telephone,
            RegistrationAddress = reader.RegistrationAddress,
            Age = reader.Age,
            CanTakeBooks = reader.CanTakeBooks
        };

        return readerRequest;
    }
}