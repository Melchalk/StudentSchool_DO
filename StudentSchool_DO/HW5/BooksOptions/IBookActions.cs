using DbModels;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;

namespace WebLibrary.BooksOptions;

public interface IBookActions
{
    CreateBookResponse Create(BookRequest request);

    BookRequest Update(Guid id, BookRequest request);

    BookRequest Get(Guid id);

    void Delete(Guid id);
}