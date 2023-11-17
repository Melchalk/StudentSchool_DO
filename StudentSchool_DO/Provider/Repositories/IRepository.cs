﻿using Microsoft.EntityFrameworkCore;

namespace Provider.Repositories;

internal interface IRepository<T> where T : class
{
    void Add(T entity);

    T Get(Guid id);

    DbSet<T> Get();

    T Update(T entity);

    void Delete(T entity);
}