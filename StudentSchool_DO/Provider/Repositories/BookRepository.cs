﻿using DbModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Provider.Repositories;

public class BookRepository : IBookRepository
{
    private readonly OfficeDbContext _context = new();

    public async Task AddAsync(DbBook book)
    {
        _context.Books.Add(book);

        await _context.SaveChangesAsync();
    }

    public async Task<DbBook?> GetAsync(Guid bookId)
    {
        return await _context.Books.FirstOrDefaultAsync(u => u.Id == bookId);
    }

    public async Task<List<DbBook>> GetAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task UpdateAsync(DbBook book, PropertyInfo property, string newValue)
    {
        if (int.TryParse(newValue, out var value))
        {
            property?.SetValue(book, value);
        }
        else
        {
            property?.SetValue(book, newValue);
        }

        await _context.SaveChangesAsync();
    }

    public async Task<DbBook?> UpdateAsync(DbBook? book)
    {
        DbBook? oldBook = await GetAsync(book.Id);

        if (oldBook is null)
        {
            return null;
        }

        foreach (PropertyInfo property in typeof(DbBook).GetProperties())
        {
            property?.SetValue(oldBook, property.GetValue(book));
        }

        await _context.SaveChangesAsync();

        return await GetAsync(book.Id);
    }

    public async Task DeleteAsync(DbBook book)
    {
        _context.Books.Remove(book);

        await _context.SaveChangesAsync();
    }
}