using DbModels;
using WebLibrary.ModelRequest;
using WebLibrary.ModelResponse;

namespace WebLibrary.BooksOptions;

public interface IBookActions
{
    CreateBookResponse Create(BookRequest request);

    BookRequest Get(Guid id);

    BookRequest Update(Guid id, BookRequest request);

    void Delete(Guid id);
}