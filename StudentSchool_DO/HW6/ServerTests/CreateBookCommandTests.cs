using WebLibrary.Commands.Book.Book_commands;
using WebLibrary.Validators;
using Moq;
using FluentValidation;
using ServiceModels.Requests.Book;

namespace ServerTests;

public class CreateBookCommandTests
{
    private Mock<ICreateBookRequestValidator> _createUserValidatorMock;
    private CreaterBook _command;

    [OneTimeSetUp]
    public void OneTimeSetUp()
    {
        _createUserValidatorMock = new Mock<ICreateBookRequestValidator>();
        /*
        _createUserValidatorMock
          .Setup(x => x.Validate(It.IsAny<CreateBookRequest>()))
          .Returns(true);

        _createUserValidatorMock
          .Setup(x => x.Validate(null))
          .Returns(false);

        _command = new CreaterBook(_createUserValidatorMock.Object);
        */
    }

    //измененить названия
    [Test]
    public async Task CreateUserCommandReturnGuidWhenRequestIsOk()
    {
        var request = new CreateBookRequest
        {
            Title = "Great Expectations",
            Author = "Charles Dickens",
            NumberPages = 250,
            YearPublishing = 2020
        };

        var actualResult = await _command.CreateAsync(request);

        Assert.IsNull(actualResult.Errors);
        //Assert.IsInstanceOf(typeof(Guid), actualResult);
    }

    [Test]
    public async Task CreateUserCommandReturnNullWhenRequestIsNotOk()
    {
        CreateBookRequest request = null;

        var actualResult = await _command.CreateAsync(request);
        //точно?
        Assert.IsNotNull(actualResult.Errors);
    }
}
