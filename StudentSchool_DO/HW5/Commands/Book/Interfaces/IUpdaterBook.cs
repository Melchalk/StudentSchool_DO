﻿using ServiceModels.Requests;
using WebLibrary.Commands.Common_interfaces;

namespace WebLibrary.Commands.Book.Interfaces;

public interface IUpdaterBook : IUpdater<CreateBookRequest>
{
}
