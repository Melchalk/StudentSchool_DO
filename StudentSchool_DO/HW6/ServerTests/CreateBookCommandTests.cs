﻿using DbModels;
using FluentValidation.Results;
using Moq;
using Provider.Repositories;
using ServiceModels.Requests.Book;
using WebLibrary.Commands.Book.Book_commands;
using WebLibrary.Mappers.Book;
using WebLibrary.Validators;

namespace ServerTests;

public class CreateBookCommandTests
{
    private Mock<ICreateBookRequestValidator> _createBookValidatorMock;
    private Mock<IBookRepository> _bookRepository;
    private Mock<IBookMapper> _bookMapper;

    private CreaterBook _command;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _createBookValidatorMock = new Mock<ICreateBookRequestValidator>();
        _bookRepository = new Mock<IBookRepository>();
        _bookMapper = new Mock<IBookMapper>();

        _createBookValidatorMock
          .Setup(x => x.Validate(It.IsAny<CreateBookRequest>()))
          .Returns(new ValidationResult());

        _createBookValidatorMock
          .Setup(x => x.Validate(null))
          .Returns(new ValidationResult()
          {
              Errors = new()
              {
                  new ValidationFailure()
              }
          });

        _bookRepository
             .Setup(x => x.AddAsync(It.IsAny<DbBook>()));

        DbBook _dbBook = new()
        {
            Id = Guid.NewGuid(),
            Title = "Test",
            NumberPages = 1,
            YearPublishing = 1,
        };

        _bookMapper
            .Setup(x => x.Map(It.IsAny<CreateBookRequest>()))
            .Returns(_dbBook);

        _command = new CreaterBook(_bookRepository.Object, _createBookValidatorMock.Object, _bookMapper.Object);
    }

    [Test]
    public async Task CreateBookCommandReturnErrorsNotNullWhenRequestIsOk()
    {
        var request = new CreateBookRequest
        {
            Title = "Great Expectations",
            Author = "Charles Dickens",
            NumberPages = 250,
            YearPublishing = 2020
        };

        var actualResult = await _command.CreateAsync(request);

        Assert.That(actualResult.Errors, Is.Null);
    }

    [Test]
    public async Task CreateBookCommandReturnErrorsEqualsNullWhenRequestIsNotOk()
    {
        CreateBookRequest request = null;

        var actualResult = await _command.CreateAsync(request);

        Assert.That(actualResult.Errors, Is.Not.Null);
    }
}
